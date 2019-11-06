using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NameSearch.Interfaces;
using NameSearch.Models;

namespace NameSearch.Controllers
{
    public class HomeController : Controller
    {

        private readonly IUserRepository _userRepository;
        private UserTableViewModel _viewModel = new UserTableViewModel();
        private readonly ILogger<HomeController> _logger;
        private  IEnumerable<User> users = new List<User>();

        public HomeController(ILogger<HomeController> logger, IUserRepository userRepository, UserTableViewModel userTableViewModel)
        {
            _logger = logger;
            _userRepository = userRepository;
            _viewModel = userTableViewModel;
        }

     
       
        public IActionResult Index(string searchString)
        {
             //ViewData.TryGetValue("SearchString", out searchString);
            if (searchString == null)
            {
                return View(_viewModel.UserList);
            }
            var listModel = _userRepository.GetUsers(searchString.ToString());

            if (listModel == null)
                return null;
            var vm = new UserTableViewModel().UserList = users;
            _viewModel = (UserTableViewModel)vm;
            users = listModel;
            _viewModel.UserList = new List<User>();
            return View(listModel);
                
            
        }
        public IActionResult Getlist()
        {
           
           return View( GetBySearchString());
        }
        public IEnumerable<User> GetBySearchString()
        {
            object searchString;

            ViewData.TryGetValue("SearchString", out searchString);

            var listModel = _userRepository.GetUsers(searchString.ToString());

            if (listModel == null)
                return null;
            var vm = new UserTableViewModel().UserList = users;
            _viewModel = (UserTableViewModel)vm;
            users = listModel;
            return listModel;
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
