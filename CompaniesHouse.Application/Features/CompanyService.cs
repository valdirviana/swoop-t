using CompaniesHouse.Application.CacheKeys;
using CompaniesHouse.Application.DTOs.Companies;
using CompaniesHouse.Application.DTOs.Company;
using CompaniesHouse.Application.Interfaces;
using CompaniesHouse.Domain.Entities;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CompaniesHouse.Application.Features
{
    public class CompanyService : ICompanyService
    {
        private readonly IHttpClientServices _httpClient;
        private readonly IMemoryCache _cache;
        private readonly IConfiguration _configuration;

        public CompanyService(IHttpClientServices httpClient, IMemoryCache cache, IConfiguration configuration)
        {
            _httpClient = httpClient;
            _cache = cache;
            _configuration = configuration;
        }

        public async Task<Company> GetCompanyByNumber(string CompanyNumber)
        {
            var result = await _cache.GetOrCreate(CompanyCacheKeys.GetKey(CompanyNumber), async entry =>
            {
                entry.AbsoluteExpirationRelativeToNow = TimeSpan.FromSeconds(Convert.ToDouble(_configuration["Cache"]));
                return await _httpClient.GetCompanyEntity<CompanyResponse>(CompanyNumber); ;
            });


            if (result != null)
            {
                var company = new Company()
                {
                    Name = result.company_name,
                    RegistrationNumber = result.company_number,
                    Age = (DateTime.Now.Date - DateTime.Parse(result.date_of_creation).Date).Days,
                    Address = $"{result.registered_office_address.address_line_1} {result.registered_office_address.address_line_2} {result.registered_office_address.postal_code} {result.registered_office_address.locality} {result.registered_office_address.country}"
                };

                return company;
            }

            return null;
        }

        public async Task<List<Company>> GetCompanyBySearch(string Query)
        {
            var results = await _httpClient.GetCompanyEntities<CompaniesResponse>(Query); ;

            var companies = new List<Company>();

            if (results != null)
            {
                results.items.ForEach(result =>
                {
                    var company = new Company()
                    {
                        Name = result.title,
                        RegistrationNumber = result.company_number,
                        Age = (DateTime.Now.Date - DateTime.Parse(result.date_of_creation).Date).Days,
                        Address = $"{result.address.address_line_1} {result.address.address_line_2} {result.address.postal_code} {result.address.locality} {result.address.country}"
                    };

                    companies.Add(company);
                });
               
            }

            return companies;
        }
    }
}
