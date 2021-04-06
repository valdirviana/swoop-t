namespace CompaniesHouse.Application.CacheKeys
{
    public static class CompanyCacheKeys
    {
        public static string ListKey => "Company";

        public static string GetKey(string CompanyNumber) => $"Company-{CompanyNumber}";

    }
}
