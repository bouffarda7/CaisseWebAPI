using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CaisseWebAPI.DAL;
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
        private readonly CaisseWebDbContext _db;


        public ProduitController(ILogger<ProduitController> logger, CaisseWebDbContext context)
        {
            _logger = logger;
            _db = context;
        }

        [HttpGet]
        public IEnumerable<Produit> Get()
        {
            List<Produit> Produits = _db.Produit.ToList();
            return Produits == null ? new List<Produit>() : Produits;
        }
    }
}