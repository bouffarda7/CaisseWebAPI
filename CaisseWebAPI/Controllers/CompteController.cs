using CaisseWebAPI.DAL;
using CaisseWebAPI.Helpers;
using CaisseWebAPI.Models;
using CaisseWebDAL.Helpers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CaisseWebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CompteController : ControllerBase
    {

        private readonly ILogger<CompteController> _logger;
        private readonly CaisseWebDbContext _db;

        public CompteController(ILogger<CompteController> logger, CaisseWebDbContext context)
        {
            _logger = logger;
            _db = context;

        }


        [HttpGet]
        public IEnumerable<Compte> Get()
        {
            List<Compte> Comptes = _db.Compte.ToList();
            return Comptes == null ? new List<Compte>() : Comptes;
        }

        [HttpGet("{id}")]
        public Compte GetById(int id)
        {
            Compte Compte = _db.Compte.FirstOrDefault(compte => compte.Id == id);
            return Compte == null ? new Compte() : Compte;
            
        }

        [HttpPost("login")]
        public IActionResult Connexion([FromBody] CompteConnexion compteConnexion)
        {

            Compte compte = new Compte();
           

            try
            {
                if (compteConnexion == null)
                    throw new ArgumentNullException(nameof(compteConnexion));

                if (InputValidationHelper.IsValidEmail(compteConnexion.NomDeConnexion))
                    compte = _db.Compte.Where(c => c.Email == compteConnexion.NomDeConnexion).FirstOrDefault();
                else
                    compte = _db.Compte.Where(c => c.Email == compteConnexion.NomDeConnexion).FirstOrDefault();

                if (string.IsNullOrEmpty(compte.MotPasse))
                    throw new ArgumentNullException(compte.MotPasse);

                if (!PasswordHelper.VerifyPassword(compteConnexion.MotDePasse, compte.MotPasse))
                    throw new ArgumentException(compte.MotPasse);

                return Ok("allo");
            }
            catch (ArgumentNullException)
            {
                return Unauthorized("Informations erronées");

            }
        }

        [HttpPost("signup")]
        public IActionResult Inscription(Compte compte)
        {
            Adresse adresse;
            try
            {
                if (compte == null)
                    throw new ArgumentNullException(nameof(compte));


                if (!InputValidationHelper.IsValidEmail(compte.Email))
                    return BadRequest("Adresse courriel invalide");

                if(!InputValidationHelper.IsValidUsername(compte.NomUtilisateur))
                    return BadRequest("Nom d'utilisateur invalide");

                if(!InputValidationHelper.IsValidFirstName(compte.Prenom))
                    return BadRequest("Nom invalide");

                if (!InputValidationHelper.IsValidLastName(compte.Nom))
                    return BadRequest("Prénom invalide");

                if(!InputValidationHelper.IsValidBirthDate(compte.DateNaissance))
                    return BadRequest("Vous devez être âgé de 18 ans ou plus");

                if (!InputValidationHelper.IsValidPassword(compte.MotPasse))
                    return BadRequest("Le mot de passe doit contenir au moins 1 majuscule, 1 minuscule, 1 chiffre," +
                        " 1 caractère spécial ainsi qu'être d'une longueur minimale de 5 caractères");

                if(!InputValidationHelper.IsValidAddress(compte.Adresse))
                    return BadRequest("Adresse invalide");

                compte.MotPasse = PasswordHelper.HashPassword(compte.MotPasse);

                adresse = _db.Adresse.Where(a => a.NumeroCivique == compte.Adresse.NumeroCivique &&
                                                        a.Rue == compte.Adresse.Rue && a.Ville == compte.Adresse.Ville &&
                                                        a.CodePostal == compte.Adresse.CodePostal).FirstOrDefault();
                if (adresse != null)
                    compte.Adresse = adresse;

                _db.Add(compte);
                _db.SaveChanges();


                return Created("", "");
            }
            catch (ArgumentNullException)
            {
                return Unauthorized("Informations erronées");

            }
        }


    }
}
