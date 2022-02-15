using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using University.BL.Dtos;

namespace University.Api.Controllers
{
    [AllowAnonymous]
    public class AccountController : ApiController
    {
        /// <summary>
        /// Realiza la authenticación del usuario
        /// </summary>
        /// <param name="loginDTO"></param>
        /// <returns></returns>
        [HttpPost]
        public IHttpActionResult Login(LoginDTO loginDTO)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            bool isCredentialValid = loginDTO.Password == "123456";
            if(!isCredentialValid)
            {
                return Unauthorized();
            }
            var token = TokenGenerator.GenerateTokenJwt(loginDTO.Username);
            return Ok(token);
        }
    }
}
