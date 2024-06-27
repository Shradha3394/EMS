using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using UserManagement.Common.Models;

namespace UserManagement.Api.Filters
{
    public class ValidateDtoAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if (!context.ModelState.IsValid)
            {
                var errors = context.ModelState.Values
                                 .SelectMany(v => v.Errors)
                                 .Select(e => e.ErrorMessage)
                                 .ToList();

                var response = new BaseResponse<object>
                {
                    IsSuccess = false,
                    ErrorMessage = string.Join(";", errors),
                    ErrorCode = "400"
                };

                context.Result = new BadRequestObjectResult(response);
            }
        }
    }
}
