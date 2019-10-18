using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BCrypt.Net;
using CaisseWebDAL.Helpers;
using CaisseWebDAL.Models;
using CaisseWebDAL.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CaisseWebAPI.Controllers
{
    [Produces("application/json")]
    [ApiController]
    [Route("[controller]")]
    public class EmployeController : ControllerBase
    {

        private readonly ILogger<EmployeController> _logger;
        private readonly EmployeRepositoryImpl _employeRepository;
        private readonly CompteRepositoryImpl _compteRepository;

        public EmployeController(ILogger<EmployeController> logger, 
            EmployeRepositoryImpl employeRepositoryImpl, CompteRepositoryImpl compteRepositoryImpl)
        {
            _logger = logger;
            _employeRepository = employeRepositoryImpl;
            _compteRepository = compteRepositoryImpl;
        }

        [HttpGet]
        public IEnumerable<string> Get()
        {

            return null;
        }

        [HttpPost]
        public IActionResult CreerNouvelEmploye(Employe Employe)
        {
            try
            {
                if (!InputValidationHelper.IsValidUsername(Employe.NomUtilisateur))
                    return BadRequest("Informations invalides");

                if (!InputValidationHelper.IsValidPassword(Employe.MPEmploye))
                    return BadRequest("Informations invalides");

                Employe.Compte = _compteRepository.RetreiveByEmail(Employe.Compte.EmailPers);
                if (Employe.Compte.Id == 0)
                {
                    BadRequest("Error");
                }

                _employeRepository.Create(Employe);
                
                if(Employe.Id != 0)
                    return Ok("OK");
            }
            catch(Exception e)
            {
                _logger.LogInformation(e.Message);
                return BadRequest("Error");
            }


            

            return BadRequest("Error");
        }


        [HttpPost("login")]
        public IActionResult ConnexionEmploye(Employe EmployeCred)
        {
            if (!InputValidationHelper.IsValidUsername(EmployeCred.NomUtilisateur))
                return BadRequest("Informations invalides");

            if (!InputValidationHelper.IsValidPassword(EmployeCred.MPEmploye))
                return BadRequest("Informations invalides");

            if(BCrypt.Net.BCrypt.Verify(EmployeCred.MPEmploye, 
                _employeRepository.RetreivePasswordByUsername(EmployeCred.NomUtilisateur)))              
            {
                return Ok("TOKEN");
            }

            return BadRequest("Error");
        }
    }
}
