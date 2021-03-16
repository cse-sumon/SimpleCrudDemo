using Microsoft.AspNetCore.Mvc;
using Repository.IRepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ViewModel;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepo _userRepo;
        public UserController(IUserRepo userRepo)
        {
            _userRepo = userRepo;
        }
        // GET: api/User
        [HttpGet]
        public IActionResult GetAllUsers()
        {
            try
            {
                return Ok(_userRepo.GetAll());
            }
            catch (Exception)
            {

                throw;
            }
        }

        // GET api/User/5
        [HttpGet("{id}")]
        public IActionResult GetUser(int id)
        {
            try
            {
                var user = _userRepo.Get(id);
                if (user == null)
                {
                    return NotFound();
                }
                return Ok(user);
            }
            catch (Exception)
            {

                throw;
            }
        }

        // POST api/User
        [HttpPost]
        public IActionResult PostUser(UserViewModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(model);
                _userRepo.Save(model);
                return Ok();
            }
            catch (Exception)
            {

                throw;
            }
        }

        // PUT api/User/5
        [HttpPut("{id}")]
        public IActionResult PutUser(UserViewModel model, int id)
        {
            try
            {
                if (id != model.Id || !ModelState.IsValid)
                    return BadRequest(model);

                _userRepo.Update(model);
                return Ok();
            }
            catch (Exception)
            {

                throw;
            }
        }

        // DELETE api/User/5
        [HttpDelete("{id}")]
        public IActionResult DeleteUser(int id)
        {
            try
            {
                var user = _userRepo.Get(id);
                if (user == null)
                    return NotFound();

                _userRepo.Delete(id);
                return NoContent();
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
