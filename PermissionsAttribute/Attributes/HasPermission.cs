using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using PermissionsAttribute.Models;

namespace PermissionsAttribute.Controllers
{
    public class HasPermission : ActionFilterAttribute,IAuthorizationFilter
    {
        private Permission _permission;

        public HasPermission(Permission permission)
        {
            _permission = permission;
        }

        public void OnAuthorization(AuthorizationFilterContext context)
        {
            var hasClaim = context.HttpContext.User.Claims.Any(c => c.Type == "permission" && c.Value == _permission.ToString());
            if (!hasClaim)
            {
                context.Result = new ForbidResult();
            }
        }
    }
}