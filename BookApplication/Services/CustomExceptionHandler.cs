using BookApplication.Services;
using Microsoft.AspNetCore.Mvc.Filters;

namespace BookApplication.Services
{
    public class CustomExceptionHandler : IExceptionFilter
    {
        private SingletonLoggingService _logging;
        public void OnException(ExceptionContext context)
        {
            _logging.Log(context.Exception.ToString());
            context.ExceptionHandled = true;
        }
    }
}