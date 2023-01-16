using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Text.RegularExpressions;

namespace quiz3.Filters
{
    public class CheckFilter : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {

            private static bool IsValid(string email)
            {
                string regex = @"^[^@\s]+@[^@\s]+\.(com|net|org|gov)$";
                return Regex.IsMatch(email, regex, RegexOptions.IgnoreCase);
            }
        }


    }
}
