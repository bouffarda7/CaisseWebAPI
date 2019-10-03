using CaisseWebDAL.Helpers;
using CaisseWebDAL.Models;
using CaisseWebDAL.Repositories;
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
        private readonly CompteRepositoryImpl _compteRepository;

        public CompteController(ILogger<CompteController> logger, CompteRepositoryImpl compteRepositoryImpl)
        {
            _logger = logger;
            _compteRepository = compteRepositoryImpl;
        }


        [HttpGet]
        public IEnumerable<Compte> Get()
        {

            return _compteRepository.RetreiveAll();
        }

        [HttpGet("{id}")]
        public Compte GetById(int id)
        {

            return _compteRepository.RetreiveById(id);
        }

        [HttpPost("login")]
        public IActionResult Connexion([FromBody] CompteConnexion compteConnexion)
        {

            Compte compte = new Compte();

            try
            {
                if (InputValidationHelper.IsValidEmail(compteConnexion.NomDeConnexion))
                    compte = _compteRepository.RetreiveByEmail(compteConnexion.NomDeConnexion);
                else
                    compte = _compteRepository.RetreiveByUsername(compteConnexion.NomDeConnexion);

                if (string.IsNullOrEmpty(compte.MPUtil))
                    throw new Exception();

                if (!PasswordHelper.VerifyPassword(compteConnexion.MotDePasse, compte.MPUtil))
                    throw new Exception();

                return Ok("allo");
            }
            catch(Exception e)
            {
                _logger.LogInformation(e.Message);
                return Unauthorized("Informations erronées");
            }
        }

        [HttpPost("signup")]
        public IActionResult Inscription(Compte compte)
        {
            try
            {

                if (!InputValidationHelper.IsValidEmail(compte.EmailPers))
                    return BadRequest("Adresse courriel invalide");

                if(!InputValidationHelper.IsValidUsername(compte.NomUtil))
                    return BadRequest("Nom d'utilisateur invalide");

                if(!InputValidationHelper.IsValidFirstName(compte.PrenomPers))
                    return BadRequest("Nom invalide");

                if (!InputValidationHelper.IsValidLastName(compte.NomPers))
                    return BadRequest("Prénom invalide");

                if(!InputValidationHelper.IsValidBirthDate(compte.DateNaissance))
                    return BadRequest("Vous devez être âgé de 18 ans ou plus");

                if (!InputValidationHelper.IsValidPassword(compte.MPUtil))
                    return BadRequest("Le mot de passe doit contenir au moins 1 majuscule, 1 minuscule, 1 chiffre," +
                        " 1 caractère spécial ainsi qu'être d'une longueur minimale de 5 caractères");

                if(!InputValidationHelper.IsValidAddress(compte.Adresse))
                    return BadRequest("Adresse invalide");

                return Created("", "");
            }
            catch(Exception e)
            {
                _logger.LogInformation(e.Message);
                return BadRequest("Informations erronées");
            }
        }


    }
}
