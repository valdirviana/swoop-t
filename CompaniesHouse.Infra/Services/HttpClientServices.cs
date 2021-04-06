using CompaniesHouse.Application.Interfaces;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace CompaniesHouse.Infra.Services
{
    public class HttpClientServices : IHttpClientServices
    {
        private readonly IHttpClientFactory _clientFactory;
        private readonly IConfiguration _configuration;

        public HttpClientServices(IHttpClientFactory clientFactory, IConfiguration configuration)
        {
            _clientFactory = clientFactory;
            _configuration = configuration;
        }

        public async Task<T> GetCompanyEntities<T>(string Q)
        {
            var BaseHost = _configuration["Api:BaseUrl"];
            var Key = _configuration["Api:Key"];
            var Size = _configuration["Api:Size"];
            var Host = $"{BaseHost}/search/companies?q={Q}&items_per_page={Size}";

            var request = new HttpRequestMessage(HttpMethod.Get, Host);
            request.Headers.Add("Authorization", Key);

            var client = _clientFactory.CreateClient();

            var response = await client.SendAsync(request);

            if (response.IsSuccessStatusCode)
            {
                using var responseStream = await response.Content.ReadAsStreamAsync();
                var entity = await JsonSerializer.DeserializeAsync<T>(responseStream);
                return entity;
            }
            else
            {
                return default;
            }
        }

        public async Task<T> GetCompanyEntity<T>(string EntityNumber)
        {
            var BaseHost = _configuration["Api:BaseUrl"];
            var Key = _configuration["Api:Key"];
            var Host = $"{BaseHost}/company/{EntityNumber}";

            var request = new HttpRequestMessage(HttpMethod.Get, Host);
            request.Headers.Add("Authorization", Key);

            var client = _clientFactory.CreateClient();

            var response = await client.SendAsync(request);

            if (response.IsSuccessStatusCode)
            {
                using var responseStream = await response.Content.ReadAsStreamAsync();
                var entity = await JsonSerializer.DeserializeAsync<T>(responseStream);
                return entity;
            }
            else
            {
                return default;
            }
        }
    }
}
