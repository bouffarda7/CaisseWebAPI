using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CaisseWebDAL.Models;
using CaisseWebDAL.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CaisseWebAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ProduitController : ControllerBase
    {

        private readonly ILogger<ProduitController> _logger;
        private readonly ProduitRepositoryImpl _produitRepository;


        public ProduitController(ILogger<ProduitController> logger, ProduitRepositoryImpl produitRepositoryImpl)
        {
            _logger = logger;
            _produitRepository = produitRepositoryImpl;
        }

        [HttpGet]
        public IEnumerable<Produit> Get()
        {

            return _produitRepository.RetreiveAll();
        }
    }
}