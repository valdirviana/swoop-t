namespace CompaniesHouse.Domain.Entities
{
    public record Company
    {
        public string Name { get; init; }
        public string RegistrationNumber { get; init; }
        public int Age { get; init; }
        public string Address { get; init; }
    }
}
