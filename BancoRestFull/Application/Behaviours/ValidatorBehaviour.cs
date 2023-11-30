using FluentValidation;
using MediatR;
using System;
using System.Buffers;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Behaviours
{
    public class ValidatorBehaviour<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> where TRequest : IRequest<TResponse>
    {
        private readonly IEnumerable<IValidator<TRequest>> _validators;

        public ValidatorBehaviour(IEnumerable<IValidator<TRequest>> validator)
        {


            _validators = validator;
        }

        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            if (_validators.Any())
            {
                var context = new FluentValidation.ValidationContext<TRequest>(request);

                var ValidationResult = await Task.WhenAll(_validators.Select(p => p.ValidateAsync(context, cancellationToken)));
                var failures = ValidationResult.SelectMany(r => r.Errors).Where(p=> p!=null).ToList();

                if (failures.Count!= 0) {
                    throw new Exceptions.ValidationException(failures);
                
                }
            }
            return await next();



        }
    }
}
