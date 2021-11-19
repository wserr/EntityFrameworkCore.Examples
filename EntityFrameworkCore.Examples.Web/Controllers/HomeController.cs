using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using EntityFramework.Examples.Web.Models;
using EntityFrameworkCore.Examples.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace EntityFramework.Examples.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IConfiguration _configuration;

        public HomeController(ApplicationDbContext dbContext, IConfiguration configuration)
        {
            _dbContext = dbContext;
            _configuration = configuration;
        }

        public async Task<IActionResult> Person()
        {
            ViewData["GithubLink"] = _configuration.GetValue<string>("GithubLink");
            return View(new PersonModel(await _dbContext.Persons.ToListAsync(), _dbContext.ConnectionString));
        }
    }
}