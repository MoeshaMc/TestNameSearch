using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NameSearch.Interfaces;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace NameSearch.Controllers
{
    [Route("user/")]
    public class UserController : Controller
    {
        private readonly IUserRepository _userRepository;


        public UserController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
           
        }

        
        IActionResult GetBySearchString(string searchString)
        {
            var listModel = _userRepository.GetUsers(searchString);
            if (listModel == null)
                return NotFound();
            
            return Ok(listModel);
        }
    }
}
