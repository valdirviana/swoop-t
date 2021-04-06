using CompaniesHouse.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CompaniesHouse.Application.Interfaces
{
    public interface ICompanyService
    {
        Task<Company> GetCompanyByNumber(string CompanyNumber);
        Task<List<Company>> GetCompanyBySearch(string Query);
    }
}
