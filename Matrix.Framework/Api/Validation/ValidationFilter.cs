using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Matrix.Framework.Api.Validation
{
    public class ValidationFilter : IAsyncActionFilter
    {
        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            if (!context.ModelState.IsValid)
            {
                throw new ValidationException(new ValidationErrorResponse
                {
                    Method = context.ActionDescriptor.AttributeRouteInfo.Template,
                    Errors = context.ModelState.Select(i => new ValidationError
                    {
                        Property = i.Key,
                        Errors = i.Value.Errors.Select(e => e.ErrorMessage).ToList()
                    }).ToList()
                });
            }

            await next.Invoke();
        }
    }
}