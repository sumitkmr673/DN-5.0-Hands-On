using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.IO;

namespace EmployeeApi.Filters
{
    // Inheriting from ExceptionFilterAttribute to use as a controller attribute
    public class CustomExceptionFilter : ExceptionFilterAttribute
    {
        public override void OnException(ExceptionContext context)
        {
            // 1. Fetch the exception detail
            var exceptionMessage = context.Exception.Message;

            // 2. Write it to a File in the system
            var filePath = Path.Combine(Directory.GetCurrentDirectory(), "ErrorLog.txt");
            File.AppendAllText(filePath, $"[{DateTime.Now}] Crash Report: {exceptionMessage}\n");

            // 3. Set the Result property to a 500 Internal Server Error
            context.Result = new ObjectResult(new { Error = "Internal Server Error", Message = exceptionMessage })
            {
                StatusCode = 500
            };

            // Set ExceptionHandled to true
            context.ExceptionHandled = true;
        }
    }
}