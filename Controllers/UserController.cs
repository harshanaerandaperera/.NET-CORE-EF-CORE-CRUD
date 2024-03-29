﻿using CRUD.Models;
using CRUD.Models.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CRUD.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : Controller
    {
        private readonly IDataRepository<User> dataRepository;

        public UserController(IDataRepository<User> dRepository)
        {
            this.dataRepository = dRepository;
        }


        /// <summary>
        /// [Lookup] Returns a list of users 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult Get()
        {
            return Ok(dataRepository.GetAll());
        }

        /// <summary>
        /// [Get] Returns a user object by id passed in as a parameter.
        /// </summary>
        /// <param name="id">Id of the user</param>
        /// <returns></returns>
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult Get(int id)
        {
            var user = dataRepository.Get(id);
            if (user == null)
            {
                return NotFound("User Not Found. ");
            }
            return Ok(user);
        }

        /// <summary>
        /// [Post] Creates an user
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public IActionResult Post([FromBody]User user)
        {
            if (user == null)
            {
                return BadRequest("Invalid Payload.");
            }
            dataRepository.Add(user);
            return Created("", user);
        }

        /// <summary>
        /// [PUT] Updates an user for a given id
        /// </summary>
        /// <param name="id"></param>
        /// <param name="user"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult Put(int id, [FromBody]User user)
        {
            if (user == null)
            {
                return BadRequest("Invalid Payload");
            }
            var userToUpdate = dataRepository.Get(id);
            if (userToUpdate == null)
            {
                return NotFound("User Not Found. ");
            }
            dataRepository.Update(userToUpdate, user);
            return Ok(userToUpdate);
        }

        /// <summary>
        /// [DELETE] Deletes an user for a given id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult Delete(int id)
        {
            var user = dataRepository.Get(id);
            if (user == null)
            {
                return NotFound("User Not Found. ");
            }
            dataRepository.Delete(user);
            return Ok(user);
        }
    }
}
