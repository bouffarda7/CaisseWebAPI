using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CaisseWebDAL.Models;
using CaisseWebDAL.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CaisseWebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EmployeController : ControllerBase
    {

        private readonly ILogger<EmployeController> _logger;

        public EmployeController(ILogger<EmployeController> logger)
        {
            _logger = logger;
          
        }

        [HttpGet]
        public IEnumerable<string> Get()
        {

            return null;
        }

        [HttpPost]
        public string ConnexionEmploye(object EmployeCred)
        {
            return "";
        }
    }
}
