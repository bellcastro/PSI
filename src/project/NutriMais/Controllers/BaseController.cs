using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace NutriMais.Controllers
{
	public class BaseController : Controller
    {
        public IActionResult ValidationErrorResponse()
        {
            var errorList = ModelState
                .Where(kvp => kvp.Value.Errors.Count > 0)
                .ToDictionary(kvp => kvp.Key, kvp => kvp.Value.Errors.Select(e => e.ErrorMessage).ToArray());

            Response.StatusCode = StatusCodes.Status400BadRequest;
            return new JsonResult(errorList);
        }
    }
}
