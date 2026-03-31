
using Microsoft.AspNetCore.Mvc;
using PasswordManager.Models.ViewModels;
using PasswordManager.Services;

namespace PasswordManager.ApiControllers
{

    [ApiController]
    [Route("api/passwordtools")]



    public class PasswordToolsApiController : ControllerBase
    {
        private readonly IPasswordService _passwordService;

        public PasswordToolsApiController(IPasswordService passwordService)
            => _passwordService = passwordService;



       
        [HttpPost("generate")]
        public IActionResult Generate([FromBody] PasswordOptions opts)
        {
            var password = _passwordService.GeneratePassword(opts);


            return Ok(new { password });
        }

        


        [HttpGet("strength")]
        public IActionResult CheckStrength([FromQuery] string pw)
        {
            var result = _passwordService.CheckStrength(pw);


            return Ok(result);



        }
    }

