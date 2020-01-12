using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using PermissionsAttribute.DAL;
using PermissionsAttribute.Models;

namespace PermissionsAttribute.Controllers
{
    public class ProfileController : Controller
    {
        private IProfileRepository _repository;

        public ProfileController(IProfileRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        [HasPermission(Permission.GetAll)]
        public IEnumerable<Profile> Get()
        {
            var profiles = _repository.Get(x => true);
            return profiles;
        }

        [HttpGet]
        [HasPermission(Permission.GetById)]
        [Route("[controller]/[action]/{id}")]
        public Profile Get(int id)
        {
            var profile = _repository.GetById(id);
            return profile;
        }

        [HttpPatch]
        [HasPermission(Permission.Update)]
        public IActionResult Update([FromBody] Profile profile)
        {
            if (profile == null)
            {
                return BadRequest();
            }
            _repository.Update(profile);
            return Ok();
        }

        [HttpPut]
        [HasPermission(Permission.Create)]
        public IActionResult Create([FromBody] Profile profile)
        {
            if (profile==null)
            {
                return BadRequest();
            }
            _repository.Create(profile);
            return Ok();
        }

        [HttpDelete]
        [HasPermission(Permission.Delete)]
        public IActionResult Delete(int? id)
        {
            if (id==null)
            {
                return BadRequest();
            }
            _repository.Delete((int)id);
            return Ok();
        }
    }
}