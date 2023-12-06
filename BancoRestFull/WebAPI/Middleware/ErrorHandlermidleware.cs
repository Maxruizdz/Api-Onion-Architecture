﻿using Application.Wrappers;
using System.Linq.Expressions;
using System.Net;
using System.Text.Json;

namespace WebAPI.Middleware
{
    public class ErrorHandlermidleware
    {

        private readonly RequestDelegate _next;


        public ErrorHandlermidleware(RequestDelegate next) { 
        
        this._next = next;
        
       }

        public async Task Invoke(HttpContext context) {

            try {


                await _next(context);
            
            
            
            
            
            
            }
            catch (Exception error)
            {
             var response= context.Response;
                response.ContentType = "application/json";
                var responseModel = new Response<string>() { Success= false, Message=error?.Message };

                switch(error){

                    case Application.Exceptions.ApiException e:
                        response.StatusCode = (int)HttpStatusCode.BadRequest;
                        break;
                    case Application.Exceptions.ValidationException e:
                        response.StatusCode = (int)HttpStatusCode.BadRequest;
                        responseModel.Errors=e.Errors;
                        break;

                    case KeyNotFoundException e:
                        response.StatusCode= (int)HttpStatusCode.NotFound;
                        break;

                    default:
                        response.StatusCode = (int)HttpStatusCode.BadRequest;
                        break;
                }
            
            
            
            var result= JsonSerializer.Serialize(responseModel);
                await response.WriteAsync(result);
            
            }
        
        
        
        
        }
    }
}
