using CompaniesHouse.Application.Interfaces;
using CompaniesHouse.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CompaniesHouse.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyController : ControllerBase
    {

        private readonly ILogger<CompanyController> _logger;
        private readonly ICompanyService _companyService;
        public CompanyController(ILogger<CompanyController> logger, ICompanyService companyService)
        {
            _logger = logger;
            _companyService = companyService;
        }

        [HttpGet("{CompanyNumber}")]
        public async Task<Company> Get(string CompanyNumber)
            => await _companyService.GetCompanyByNumber(CompanyNumber);

        [HttpGet]
        public async Task<List<Company>> GetByQuery(
            [FromQuery(Name = "q")] string Q)
            => await _companyService.GetCompanyBySearch(Q);
    }
}

