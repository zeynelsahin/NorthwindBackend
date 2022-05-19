using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Net;
using System.Threading.Tasks;
using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Http;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace Core.Extensions
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;

        public ExceptionMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (Exception e)
            {
                await HandleExceptionAsync(httpContext, e);
            }
        }

        private Task HandleExceptionAsync(HttpContext httpContext, Exception e)
        {
            httpContext.Response.ContentType = "application/json";
            httpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

            var message = "Internal Server Error";

            IEnumerable<ValidationFailure> errors;
            if (e.GetType() == typeof(ValidationException))
            {
                message = e.Message;
                errors = ((ValidationException)e).Errors;
                httpContext.Response.StatusCode = 400;
                return httpContext.Response.WriteAsync(new ValidationErrorDetails()
                {
                    StatusCode = 400,
                    Message = message,
                    Errors = errors
                }.ToString());
            }
            else if (e.GetType() == typeof(AuthorizedException))
            {
                return httpContext.Response.WriteAsync(new ErrorDetails
                {
                    StatusCode = httpContext.Response.StatusCode,
                    Message = e.Message
                }.ToString());
            }
            else if (e.GetType() == typeof(SqlNullValueException))
            {
                return httpContext.Response.WriteAsync(new ErrorDetails
                {
                    Message = "Boş geçilmemisi gereken alan boş geçilmiş"
                }.ToString());
            }
            else if (e.GetType() == typeof(DbUpdateException))
            {
                return httpContext.Response.WriteAsync(new ErrorDetails
                {
                    Message = "Sql server kısıt hatası"
                }.ToString());
            }
            else if (e.GetType() == typeof(SqlException))
            {
                return httpContext.Response.WriteAsync(new ErrorDetails
                {
                    Message = "Sql hatası"
                }.ToString());
            }

            return httpContext.Response.WriteAsync(new ErrorDetails
            {
                StatusCode = httpContext.Response.StatusCode,
                Message = message
            }.ToString());
        }
    }
}