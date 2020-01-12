using FluentValidation;
using MediatR.Pipeline;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ToDo.Core.Common.Behaviors
{
    public class ValidationPreProcessor<TRequest> : IRequestPreProcessor<TRequest>
    {
        private readonly IValidator<TRequest> _validator;

        public ValidationPreProcessor(IServiceProvider serviceProvider)
        {
            // Use service locator to avoid DI validation. It is required for the case when no validator is provided for the request.
            // As an alternative: Disable validation in host building.
            // TODO: Decide if it is a valida case, or it is better to define validator for any request.
            _validator = serviceProvider.GetService(typeof(IValidator<TRequest>)) as IValidator<TRequest>;
        }


        public async Task Process(TRequest request, CancellationToken cancellationToken)
        {
            if(_validator != null)
            {
                await _validator.ValidateAndThrowAsync(request);
            }
        }
    }
}
