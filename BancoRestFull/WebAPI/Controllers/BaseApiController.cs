﻿using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{

    
    [ApiController]

    [Route("api/v{version:ApiVersion}/[controller]")]
    public abstract class BaseApiController : ControllerBase
    {
        private IMediator _mediator;


        protected IMediator Mediator => _mediator ??= HttpContext.RequestServices.GetService<Mediator>();



    }
}
