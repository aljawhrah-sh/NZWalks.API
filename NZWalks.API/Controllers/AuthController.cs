using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using NZWalks.API.Models.DTO;
using NZWalks.API.Repository;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace NZWalks.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : Controller
    {

        private readonly UserManager<IdentityUser> userManager;
        private readonly ITokenRepository tokenRepository;

        public AuthController(UserManager<IdentityUser> userManager, ITokenRepository tokenRepository)
        {
            this.userManager = userManager;
            this.tokenRepository = tokenRepository;
        }

        //post: /api/auth/register
        [HttpPost]
        public async Task<IActionResult> Register([FromBody] RegisterDTO registerDTO)
        {

            var identityUser = new IdentityUser
            {
                UserName = registerDTO.username,
                Email = registerDTO.username
            };

            var identityResult = await userManager.CreateAsync(identityUser, registerDTO.password);
            if (identityResult.Succeeded)
            {
                //add role to the user
                if(registerDTO.roles != null)
                {
                    identityResult = await userManager.AddToRolesAsync(identityUser, registerDTO.roles);
                }
                if (identityResult.Succeeded)
                {
                    return Ok("user was registered! Please login.");
                }
            }

            return BadRequest("unable to register user");
        }

        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> Login([FromBody]LoginDTO loginDTO)
        {
            var user = await userManager.FindByEmailAsync(loginDTO.username);

            //if user is found check password
            if(user != null)
            {
                var checkPasswordResult = await userManager.CheckPasswordAsync(user ,loginDTO.password);

                //if password is correct return ok
                if(checkPasswordResult)
                {
                    //get role of user
                    var roles = await userManager.GetRolesAsync(user);
                    if(roles != null)
                    {
                        //create a token
                        var jwtToken = tokenRepository.CreateJWTtoken(user, roles.ToList());

                        var response = new LoginResponse
                        {
                            JWTtoken = jwtToken
                        };

                     return Ok(response);
                    }

                   
                }
            }

            //user not found
            return BadRequest("username or password is not correct");
        }
    }
}

