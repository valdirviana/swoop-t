using System.Threading.Tasks;

namespace CompaniesHouse.Application.Interfaces
{
    public interface IHttpClientServices
    {
        Task<T> GetCompanyEntity<T>(string EntityNumber);
        Task<T> GetCompanyEntities<T>(string Q);
    }
}
