using System;

namespace data_access_layer.Models
{
    public class CustomerDomainModel
    {
        public int Id { get; set; }
        public int AgentId { get; set; }
        public Guid Guid { get; set; }
        public bool IsActive { get; set; }
        public string Balance { get; set; }
        public byte Age { get; set; }
        public string EyeColor { get; set; }
        public CustomerName Name { get; set; }
        public string Company { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public DateTime Registered { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public string[] Tags { get; set; }

        public class CustomerName
        {
            public string First { get; set; }
            public string Last { get; set; }
        }
    }
}