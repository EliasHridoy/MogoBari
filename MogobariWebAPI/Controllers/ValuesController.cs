using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper.Configuration;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.Extensions.Configuration;
using MogobariWebAPI.BL.Interface;

namespace MogobariWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        public Microsoft.Extensions.Configuration.IConfiguration Configuration { get; }

        private readonly ITokenManager _token;

        public ValuesController(Microsoft.Extensions.Configuration.IConfiguration configuration, ITokenManager tokenManager)
        {
            Configuration = configuration;
            _token = tokenManager;
        }
        // GET api/values
        [HttpGet]
        public ActionResult<object> Get()
        {
            string a = "hello";
            byte[] hash, salt;
            _token.GenerateHash(a, out hash, out  salt);
            
            string Hash = Encoding.ASCII.GetString(hash);
            string Salt = Encoding.ASCII.GetString(salt);

            byte[] hash1;// = Encoding.ASCII.GetBytes(Hash);
            byte[] salt1;// = Encoding.ASCII.GetBytes(Salt);

             _token.GenerateHash(a, out hash1, out salt1);


            

            return new { 
                HH=hash,               
                HHH=hash1,
                SS=salt,
                sss=salt1
            };
            //return a;

        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
