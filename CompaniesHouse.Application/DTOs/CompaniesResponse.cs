using System.Collections.Generic;

namespace CompaniesHouse.Application.DTOs.Companies
{
    public class Links
    {
        public string self { get; set; }
    }

    public class Matches
    {
        public List<int> title { get; set; }
        public List<int> snippet { get; set; }
    }

    public class Address
    {
        public string locality { get; set; }
        public string premises { get; set; }
        public string region { get; set; }
        public string postal_code { get; set; }
        public string address_line_1 { get; set; }
        public string country { get; set; }
        public string address_line_2 { get; set; }
    }

    public class Item
    {
        public string snippet { get; set; }
        public Links links { get; set; }
        public Matches matches { get; set; }
        public string kind { get; set; }
        public string address_snippet { get; set; }
        public string title { get; set; }
        public string company_status { get; set; }
        public string company_number { get; set; }
        public List<string> description_identifier { get; set; }
        public Address address { get; set; }
        public string description { get; set; }
        public string date_of_creation { get; set; }
        public string company_type { get; set; }
        public string date_of_cessation { get; set; }
    }

    public class CompaniesResponse
    {
        public int start_index { get; set; }
        public int page_number { get; set; }
        public int items_per_page { get; set; }
        public string kind { get; set; }
        public int total_results { get; set; }
        public List<Item> items { get; set; }
    }


}
