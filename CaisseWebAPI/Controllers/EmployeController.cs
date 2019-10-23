using System;
using System.Collections.Generic;
using System.Linq;
using CaisseWebAPI.DAL;
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
        private readonly CaisseWebDbContext _db;


        public EmployeController(ILogger<EmployeController> logger, CaisseWebDbContext context)
        {
            _logger = logger;

            _db = context;
        }

        [HttpGet]
        public IEnumerable<Employe> Get()
        {

            List<Employe> Employes = _db.Employe.ToList();
            return Employes == null ? new List<Employe>() : Employes;
        }

        [HttpPost]
        public IActionResult CreerNouvelEmploye(string Employe)
        {/*
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


            
            */
            return BadRequest("Error");
        }


        [HttpPost("login")]
        public IActionResult ConnexionEmploye(string EmployeCred)
        {
            /*if (!InputValidationHelper.IsValidUsername(EmployeCred.NomUtilisateur))
                return BadRequest("Informations invalides");

            if (!InputValidationHelper.IsValidPassword(EmployeCred.MPEmploye))
                return BadRequest("Informations invalides");*/

            /*if(BCrypt.Net.BCrypt.Verify(EmployeCred.MPEmploye, 
                _employeRepository.RetreivePasswordByUsername(EmployeCred.NomUtilisateur)))              
            {
                return Ok("TOKEN");
            }
            */
            return BadRequest("Error");
        }
    }
}
