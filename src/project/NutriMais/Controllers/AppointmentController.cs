using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NutriMais.Models;
using NutriMais.Repositories.Appointment;
using NutriMais.Repositories.User;
using NutriMais.Requests.Appointment;
using NutriMais.Services.Appointment;
using System.Security.Claims;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNet.Identity;

namespace NutriMais.Controllers
{
    [Authorize]
    public class AppointmentController : BaseController
    {
        private readonly AppointmentServiceInterface _service;
        private readonly UserRepositoryInterface _userRepository;
        private readonly AppointmentRepositoryInterface _repository;

        public AppointmentController(AppointmentServiceInterface service, UserRepositoryInterface userRepository, AppointmentRepositoryInterface repository)
        {
            _service = service;
            _userRepository = userRepository;
            _repository = repository;
        }

        public async Task<IActionResult> Index()
        {
            var user = await _userRepository.Find(User.Identity.GetUserId());
            ViewData["User"] = user;
            return View(await _repository.GetAppointmentsOf(user));
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id != null)
            {
                try
                {
                    var user = await _userRepository.Find(User.Identity.GetUserId());
                    var model = await _repository.Find(id.Value);
                    if (model.CanSeeAppointment(user))
                    {
                        ViewData["User"] = user;
                        ViewData["Appointments"] = await _repository.GetConfirmedAppointmentsOf(user);
                        return View(model);
                    }

                    return Unauthorized();
                }
                catch (KeyNotFoundException)
                {
                    return NotFound();
                }
            }

            return NotFound();
        }

        public async Task<IActionResult> Create()
        {
            var user = await _userRepository.Find(User.Identity.GetUserId());
            ViewData["Appointments"] = await _repository.GetConfirmedAppointmentsOf(user);
            ViewData["Participants"] = await _userRepository.GetParticipantsFor(user);
            ViewData["User"] = user;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([FromBody] AppointmentModel appointmentModel)
        {
            if (ModelState.IsValid)
            {
                await _repository.InsertNewAppointment(await _userRepository.Find(User.Identity.GetUserId()), appointmentModel);
                Response.StatusCode = StatusCodes.Status201Created;
                return new JsonResult(appointmentModel);
            }

            return ValidationErrorResponse();
        }

        [Route("/Appointment/Refuse/{id}")]
        [HttpPut]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> RefuseAppointment(int? id, [FromBody] RefuseAppointmentRequest request)
        {
            if (id != null)
            {
                if (ModelState.IsValid)
                {
                    try
                    {
                        var user = await _userRepository.Find(User.Identity.GetUserId());
                        var model = await _repository.Find(id.Value);
                        _service.RefuseAppointment(model, request.Reason, user);
                        await _repository.UpdateAppointment(model);
                        return Ok();
                    }
                    catch (KeyNotFoundException)
                    {
                        return NotFound();
                    }
                    catch (UnauthorizedAccessException)
                    {
                        return Unauthorized();
                    }
                }


                return ValidationErrorResponse();
            }

            return NotFound();
        }

        [Route("/Appointment/Confirm/{id}")]
        [HttpPut]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ConfirmAppointment(int? id)
        {
            if (id != null)
            {
                try
                {
                    var user = await _userRepository.Find(User.Identity.GetUserId());
                    var model = await _repository.Find(id.Value);
                    _service.ConfirmAppointment(model, user);
                    await _repository.UpdateAppointment(model);
                    return Ok();
                }
                catch (KeyNotFoundException)
                {
                    return NotFound();
                }
                catch (UnauthorizedAccessException)
                {
                    return Unauthorized();
                }
            }

            return NotFound();
        }

        [Route("/Appointment/Cancel/{id}")]
        [HttpPut]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CancelAppointment(int? id, [FromBody] RefuseAppointmentRequest request)
        {
            if (id != null)
            {
                try
                {
                    var user = await _userRepository.Find(User.Identity.GetUserId());
                    var model = await _repository.Find(id.Value);
                    _service.CancelAppointment(model, request.Reason, user);
                    await _repository.UpdateAppointment(model);
                    return Ok();
                }
                catch (KeyNotFoundException)
                {
                    return NotFound();
                }
                catch (UnauthorizedAccessException)
                {
                    return Unauthorized();
                }
            }

            return NotFound();
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id != null)
            {
                try
                {
                    var user = await _userRepository.Find(User.Identity.GetUserId());
                    var model = await _repository.Find(id.Value);
                    if (model.CanEditAppointment(user))
                    {
                        ViewData["User"] = user;
                        ViewData["Appointments"] = await _repository.GetConfirmedAppointmentsOf(user);
                        ViewData["Participants"] = await _userRepository.GetParticipantsFor(user);
                        return View(model);
                    }

                    return Unauthorized();
                }
                catch (KeyNotFoundException)
                {
                    return NotFound();
                }
            }

            return NotFound();
        }

        [HttpPut]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int? id, [FromBody] UpdateAppointmentRequest request)
        {
            if (id != null)
            {
                try
                {
                    var user = await _userRepository.Find(User.Identity.GetUserId());
                    var model = await _repository.Find(id.Value);
                    _service.UpdateAppointment(request, model, user);
                    await _repository.UpdateAppointment(model);
                    return Ok();
                }
                catch (KeyNotFoundException)
                {
                    return NotFound();
                }
                catch (UnauthorizedAccessException)
                {
                    return Unauthorized();
                }
            }

            return NotFound();
        }
    }
}
