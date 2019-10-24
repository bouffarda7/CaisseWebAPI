using System;
using System.Collections.Generic;
using System.Linq;
using CaisseWebAPI.DAL;
using CaisseWebAPI.Helpers;
using CaisseWebAPI.Models;
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
        public IActionResult CreerNouvelEmploye(Employe Employe)
        {
            try
            {
                if (Employe == null)
                    throw new ArgumentNullException(nameof(Employe));

                if (Employe.Compte == null)
                    throw new NullReferenceException();

                if (!InputValidationHelper.IsValidUsername(Employe.NomUtilisateur))
                    throw new ArgumentException(Employe.NomUtilisateur);

                if (!InputValidationHelper.IsValidPassword(Employe.MotPasse))
                    throw new ArgumentException(Employe.MotPasse);

                Employe.Compte = _db.Compte.Where(c => c.Email == Employe.Compte.Email).FirstOrDefault();
                if (Employe.Compte.Id == 0)
                {
                    BadRequest("Error");
                }

                _db.Employe.Add(Employe);
                _db.SaveChanges();
                
                if(Employe.Id != 0)
                    return Ok("OK");

                return BadRequest("Error");
            }
            catch (ArgumentNullException)
            {
                return BadRequest("Requête invalide");
            }
            catch (ArgumentException)
            {
                return BadRequest("Informations erronées");
            }
            catch(NullReferenceException)
            {
                return BadRequest("Requête invalide");
            }

           
        }


        [HttpPost("login")]
        public IActionResult ConnexionEmploye(CompteConnexion CompteConnexion)
        {
            string motPasse = "";
            try
            {
                if (CompteConnexion == null)             
                    throw new ArgumentNullException(nameof(CompteConnexion));


                if (!InputValidationHelper.IsValidUsername(CompteConnexion.NomDeConnexion))
                    throw new ArgumentException(CompteConnexion.NomDeConnexion);

                if (!InputValidationHelper.IsValidPassword(CompteConnexion.MotDePasse))
                    throw new ArgumentException(CompteConnexion.MotDePasse);

                motPasse = _db.Employe.Where(e => e.NomUtilisateur == CompteConnexion.NomDeConnexion)
                    .Select(e => e.MotPasse).FirstOrDefault();

                if(string.IsNullOrEmpty(motPasse))
                    throw new ArgumentException(CompteConnexion.NomDeConnexion);



                if (!BCrypt.Net.BCrypt.Verify(CompteConnexion.MotDePasse, motPasse))
                    throw new ArgumentException(CompteConnexion.MotDePasse);
                
                
                return Ok("TOKEN");              

            }
            catch (ArgumentNullException)
            {
                return BadRequest("Requête invalide");
            }
            catch (ArgumentException)
            {
                return BadRequest("Informations erronées");
            }

        }
    }
}
