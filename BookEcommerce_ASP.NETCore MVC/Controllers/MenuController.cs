using Microsoft.AspNetCore.Mvc;
using ClassLibrary_RepositoryDLL.Services;
using ClassLibrary_RepositoryDLL.Entities;
using ClassLibrary_RepositoryDLL.Repository;
using ClassLibrary_RepositoryDLL.Repository.Interface;
using System.Collections.Generic;
using System.Threading.Tasks;
using ClassLibrary_RepositoryDLL.Models;
using System.Linq;

namespace BookEcommerce_ASP.NETCore_MVC.Controllers
{
   
    public class MenuController : Controller
    { 
        private readonly IMenuService _repo;
        private readonly BookEcommerceContext _context;

        public MenuController(IMenuService repo, BookEcommerceContext context)
        {
            _repo = repo;
            _context = context;
        }

        public IActionResult Index()
        {
            var menu = _repo.getAllCategories();
            return View(menu);
        }
    }
}