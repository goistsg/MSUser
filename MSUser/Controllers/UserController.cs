using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MSUser.Models;
using MSUser.Services;

namespace MSUser.Controllers
{
    [Authorize("Bearer")]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private UserService _service;

        public UserController(UserService service)
        {
            _service = service;
        }

        [HttpGet]
        public IEnumerable<User> Get()
        {
            return _service.findAll();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var user = _service.find(id);
            if (user != null)
                return new ObjectResult(user);
            else
                return NotFound();
        }

        // POST api/values
        [HttpPost]
        public String Post([FromBody] User user)
        {
            return _service.create(user);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public String Put([FromBody] User user)
        {
            return _service.edit(user);
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public String Delete(int id)
        {
            return _service.delete(id);
        }
    }
}
