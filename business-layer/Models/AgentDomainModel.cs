namespace data_access_layer.Models
{
    public class AgentDomainModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string ZipCode { get; set; }
        public int Tier { get; set; }
        public AgentPhone Phone { get; set; }

        public class AgentPhone
        {
            public string Primary { get; set; }
            public string Mobile { get; set; }
        }
    }
}