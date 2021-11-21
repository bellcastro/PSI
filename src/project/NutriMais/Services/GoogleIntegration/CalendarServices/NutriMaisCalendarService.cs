using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Google.Apis.Services;
using Google.Apis.Calendar.v3;
using Google.Apis.Calendar.v3.Data;
using Google.Apis.Sheets.v4;
using Google.Apis.Sheets.v4.Data;
using NutriMais.Models;

namespace NutriMais.Services.GoogleIntegration.CalendarServices
{
    public class NutriMaisCalendarService : CalendarServiceInterface
    {
        const string SHEET_ID    = "1OUfAvIXfP2zgX7w9LVYKvWHVdDp3qW0iD_TY4losCxU";
        private readonly SheetsService _sheetsService;

        public NutriMaisCalendarService(SheetsService calendarService)
        {
            _sheetsService = calendarService;
        }


        public string GenerateEventLink(AppointmentModel model)
        {
            return GetEventLink(model);
        }

        private void CreateEvent(AppointmentModel model)
        {
            var rowEvent = new ValueRange()
            {
                Values = new string[][] {
                    new string[] { 
                        model.Title, 
                        model.StartsAt.ToString(),
                        model.EndsAt.ToString(),
                        model.Description, 
                        model.Owner.Email, 
                        model.Participant.Email, 
                        "",
                        model.Id.ToString()
                    }
                }
            };

            var request = _sheetsService.Spreadsheets.Values.Append(rowEvent, SHEET_ID, "Eventos!A2:H300");
            request.ValueInputOption = SpreadsheetsResource.ValuesResource.AppendRequest.ValueInputOptionEnum.USERENTERED;
            request.Execute();
        }

        private string GetEventLink (AppointmentModel model, bool retry = true)
        {
            var request = _sheetsService.Spreadsheets.Values.Get(SHEET_ID, "Eventos!A2:H300").Execute();
            if (request.Values != null && request.Values.Count > 0)
            {
                foreach (var item in request.Values)
                {
                    if(item.Count >= 7 && (string) item[7] == model.Id.ToString())
                    {
                        return (string) item[6];
                    }
                }
            }

            if (retry)
            {
                CreateEvent(model);
                System.Threading.Thread.Sleep(3000);
                return GetEventLink(model, false);
            }

            return "";
        }
    }
}
