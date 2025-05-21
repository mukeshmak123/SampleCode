using System.Net;
using System.Security.Cryptography;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebFox.Controllers
{
    public class SecureCookieTest1 : ControllerBase
    {
        [HttpGet]
        [HttpPost]
        public IActionResult DoPost()
        {
            return DoGet();
        }

        public IActionResult DoGet()
        {
            Unsafe();
            return Ok();
        }

        public void Unsafe()
        {
            string password = "p-" + RandomNumberGenerator.GetInt32(200000000, 2000000000);

            var cookieOptions = new CookieOptions
            {
                Path = "/",
                HttpOnly = true,
                Secure = true,
                SameSite = SameSiteMode.Strict
            };
            Response.Cookies.Append("password", password, cookieOptions);
        }
    }
}
