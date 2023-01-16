using Microsoft.AspNetCore.Mvc;
using quiz3.Filters;
using quiz3.Linq;
using quiz3.Models;

namespace quiz3.Controllers
{
    public class TestController : ControllerBase
    {
        [HttpGet]
        [Route("email/{number}")]

        [CheckFilter]

        public JsonResult GetEmail(string emails)
        {
            Database db = new Database();
            var email = db.emails.FirstOrDefault(f => f.email == emails);
            var response = new ResponseModel
            {
                StatusCode = 200,
                Message = "Success",
                Data = email
            };
            return new JsonResult(email);
        }

        
        [HttpPost] 
        [Route("email")]
        public JsonResult CreateStudent([FromBody] CrateEmailsRequest request)
        {
            Database db = new Database();


            var newEmail = new Email  
                                      
            {
                email = request.email,

            };
            db.emails.Add(newEmail);

            var response = new ResponseModel
            {
                StatusCode = 200,
                Message = "Success",
                Data = newEmail
            };
            return new JsonResult(response);
        }

        [HttpDelete]  //DELETE İÇİN REQUEST MODEL OLUŞTURMAYA GEREK YOK
        [Route("email/{email}")]
        public JsonResult DeleteStudent(string emails)
        {
            Database db = new Database();
            var email = db.emails.FirstOrDefault(f => f.email == emails);
            if (email == null)
            {
                var errorResponse = new ResponseModel
                {
                    StatusCode = 404,
                    Message = "Not Found",
                    Data = null
                };
                return new JsonResult(errorResponse);
            }

            db.emails.Remove(email);

            var response = new ResponseModel
            {
                StatusCode = 200,
                Message = "Success",
                Data = db.emails
            };
            return new JsonResult(response);
        }
    }
}
