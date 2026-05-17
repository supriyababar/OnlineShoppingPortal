using Microsoft.AspNetCore.Mvc;
using AuthWebAPI.Models;

namespace AuthWebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        public AuthController(){}

        [HttpPost]
        public ActionResult<string> Login(Credential credential)
        {
            if (credential.UserName=="shital" && credential.Password=="jadhav")
            {
                return Ok("valid");
            }
            else
            {
                return NotFound();
            }
        }


        [HttpPost]
        public ActionResult<string> Register(User user)
        {
            if (user !=null)
            {

                return Ok("valid");
            }
            else
            {
                return NotFound();
            }
        }

        

        [HttpPut]
        public ActionResult<string> ChangePassword(string userName, string oldPassword, string newPassword)
        {
            if (userName !=null)
            {

                return Ok("password is changed");
            }
            else
            {
                return NotFound();
            }
        }

    } 
}