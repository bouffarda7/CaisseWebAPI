using CaisseWebDAL.Models;
using CaisseWebDAL.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
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

    }
}
