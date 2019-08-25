using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InsightConsulting.Domain;
using InsightConsulting.Domain.Entities;
using InsightConsulting.Domain.Services;
using Microsoft.AspNetCore.Mvc;

namespace InsightConsulting.API.Controllers
{
    [Produces("application/json")]
    [Route("api/UsersApi")]
    [ApiController]
    public class UsersApiController : ControllerBase
    {
        private readonly InsightConsultingDomain _context;

        public UsersApiController(InsightConsultingDomain insightConsultingDomain)
        {
            _context = insightConsultingDomain;
        }

        // GET: api/UsersApi
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Users>>> GetAllUsers()
        {
            try
            {
                return await Task.Run(() =>
                UserServices.GetAll(_context).ToList()
                );
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET: api/UsersApi/5
        [HttpGet("{id}", Name = "Get")]
        public async Task<ActionResult<Users>> GetUser(int? id)
        {
            try
            {
                return await Task.Run(() =>
                UserServices.GetUser(_context, id)
                );
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        
        // POST: api/UsersApi
        [HttpPost]
        public async Task<ActionResult> AddUser([FromBody]Users user)
        {
            try
            {
                var result = await Task.Run(() =>
                  UserServices.AddUser(_context,user)
                );

                return CreatedAtAction("GetUsers", new { user = user.Id }, user);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        
        // PUT: api/UsersApi/5
        [HttpPut("{id}")]
        public async Task<ActionResult<Users>> UpdateUser(int id, [FromBody]Users user)
        {
            try
            {
                if (id != user.Id)
                {
                    return BadRequest();
                }

               var result = await Task.Run(() =>
                    UserServices.UpdateUser(_context, user)
                );

                return result;
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Users>> DeleteUser(int id)
        {
            try
            {
                if (id == 0)
                {
                    return NotFound();
                }

               var user =  await Task.Run(() =>
                 UserServices.Delete(_context, id)
             );
               
                return user;
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
