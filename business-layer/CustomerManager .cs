using data_access_layer;
using data_access_layer.Models;
using Microsoft.AspNetCore.JsonPatch;
using System.Collections.Generic;
using System.Linq;

namespace business_layer
{
    public class CustomerManager : ICustomerManager
    {
        private readonly ICustomerRepository _customerRepository;

        public CustomerManager(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public IEnumerable<CustomerDomainModel> Get()
        {
            var customerDomainModels = new List<CustomerDomainModel>();
            var customerDataModels = _customerRepository.Get();

            customerDomainModels.AddRange(customerDataModels.Select(x =>
            new CustomerDomainModel()
            {
                Id = x.Id,
                AgentId = x.AgentId,
                Guid = x.Guid,
                IsActive = x.IsActive,
                Balance = x.Balance,
                Age = x.Age,
                EyeColor = x.EyeColor,
                Name = new CustomerDomainModel.CustomerName()
                {
                    First = x.Name.First,
                    Last = x.Name.Last
                },
                Company = x.Company,
                Email = x.Email,
                Phone = x.Phone,
                Address = x.Address,
                Registered = x.Registered,
                Latitude = x.Latitude,
                Longitude = x.Longitude,
                Tags = x.Tags
            }));

            return customerDomainModels;
        }

        public IEnumerable<CustomerNameAddressDomainModel> GetByAgentId(int agentId)
        {
            var customerDomainModels = new List<CustomerNameAddressDomainModel>();
            var customerDataModels = _customerRepository.GetByAgentId(agentId);

            customerDomainModels.AddRange(customerDataModels.Select(x =>
            {
                var address = x.Address.Split(", ");
                var city = address[1];
                var state = address[2];

                return new CustomerNameAddressDomainModel()
                {
                    FirstName = x.Name.First,
                    LastName = x.Name.Last,
                    City = city,
                    State = state
                };
            }));

            return customerDomainModels;
        }

        public void Add(CustomerDomainModel customerDomainModel)
        {
            var customerDataModel = new CustomerDataModel()
            {
                Id = customerDomainModel.Id,
                AgentId = customerDomainModel.AgentId,
                Guid = customerDomainModel.Guid,
                IsActive = customerDomainModel.IsActive,
                Balance = customerDomainModel.Balance,
                Age = customerDomainModel.Age,
                EyeColor = customerDomainModel.EyeColor,
                Name = new CustomerDataModel.CustomerName()
                {
                    First = customerDomainModel.Name.First,
                    Last = customerDomainModel.Name.Last
                },
                Company = customerDomainModel.Company,
                Email = customerDomainModel.Email,
                Phone = customerDomainModel.Phone,
                Address = customerDomainModel.Address,
                Registered = customerDomainModel.Registered,
                Latitude = customerDomainModel.Latitude,
                Longitude = customerDomainModel.Longitude,
                Tags = customerDomainModel.Tags
            };

            _customerRepository.Add(customerDataModel);
        }

        public void Delete(int id)
        {
            _customerRepository.Delete(id);
        }

        public void Update(CustomerDomainModel customerDomainModel)
        {
            var customerDataModel = new CustomerDataModel()
            {
                Id = customerDomainModel.Id,
                AgentId = customerDomainModel.AgentId,
                Guid = customerDomainModel.Guid,
                IsActive = customerDomainModel.IsActive,
                Balance = customerDomainModel.Balance,
                Age = customerDomainModel.Age,
                EyeColor = customerDomainModel.EyeColor,
                Name = new CustomerDataModel.CustomerName()
                {
                    First = customerDomainModel.Name.First,
                    Last = customerDomainModel.Name.Last
                },
                Company = customerDomainModel.Company,
                Email = customerDomainModel.Email,
                Phone = customerDomainModel.Phone,
                Address = customerDomainModel.Address,
                Registered = customerDomainModel.Registered,
                Latitude = customerDomainModel.Latitude,
                Longitude = customerDomainModel.Longitude,
                Tags = customerDomainModel.Tags
            };

            _customerRepository.Update(customerDataModel);
        }

        public void Patch(int id, JsonPatchDocument<CustomerDomainModel> customerDomainModel)
        {
            var customerToPatchDataModel = _customerRepository.FindById(id);
            var customerToPatchDomainModel = new CustomerDomainModel();

            customerToPatchDomainModel.Id = customerToPatchDataModel.Id;
            customerToPatchDomainModel.AgentId = customerToPatchDataModel.AgentId;
            customerToPatchDomainModel.Guid = customerToPatchDataModel.Guid;
            customerToPatchDomainModel.IsActive = customerToPatchDataModel.IsActive;
            customerToPatchDomainModel.Balance = customerToPatchDataModel.Balance;
            customerToPatchDomainModel.Age = customerToPatchDataModel.Age;
            customerToPatchDomainModel.EyeColor = customerToPatchDataModel.EyeColor;
            customerToPatchDomainModel.Name = new CustomerDomainModel.CustomerName()
            {
                First = customerToPatchDataModel.Name.First,
                Last = customerToPatchDataModel.Name.Last
            };
            customerToPatchDomainModel.Company = customerToPatchDataModel.Company;
            customerToPatchDomainModel.Email = customerToPatchDataModel.Email;
            customerToPatchDomainModel.Phone = customerToPatchDataModel.Phone;
            customerToPatchDomainModel.Address = customerToPatchDataModel.Address;
            customerToPatchDomainModel.Registered = customerToPatchDataModel.Registered;
            customerToPatchDomainModel.Latitude = customerToPatchDataModel.Latitude;
            customerToPatchDomainModel.Longitude = customerToPatchDataModel.Longitude;
            customerToPatchDomainModel.Tags = customerToPatchDataModel.Tags;

            customerDomainModel.ApplyTo(customerToPatchDomainModel);

            var patchedCustomerDataModel = new CustomerDataModel()
            {
                Id = customerToPatchDomainModel.Id,
                AgentId = customerToPatchDomainModel.AgentId,
                Guid = customerToPatchDomainModel.Guid,
                IsActive = customerToPatchDomainModel.IsActive,
                Balance = customerToPatchDomainModel.Balance,
                Age = customerToPatchDomainModel.Age,
                EyeColor = customerToPatchDomainModel.EyeColor,
                Name = new CustomerDataModel.CustomerName()
                {
                    First = customerToPatchDomainModel.Name.First,
                    Last = customerToPatchDomainModel.Name.Last
                },
                Company = customerToPatchDomainModel.Company,
                Email = customerToPatchDomainModel.Email,
                Phone = customerToPatchDomainModel.Phone,
                Address = customerToPatchDomainModel.Address,
                Registered = customerToPatchDomainModel.Registered,
                Latitude = customerToPatchDomainModel.Latitude,
                Longitude = customerToPatchDomainModel.Longitude,
                Tags = customerToPatchDomainModel.Tags
            };

            _customerRepository.Update(patchedCustomerDataModel);
        }

        public CustomerDomainModel FindById(int id)
        {
            var customerDomainModel = new CustomerDomainModel();
            var customerDataModel = _customerRepository.FindById(id);

            customerDomainModel.Id = customerDataModel.Id;
            customerDomainModel.AgentId = customerDataModel.AgentId;
            customerDomainModel.Guid = customerDataModel.Guid;
            customerDomainModel.IsActive = customerDataModel.IsActive;
            customerDomainModel.Balance = customerDataModel.Balance;
            customerDomainModel.Age = customerDataModel.Age;
            customerDomainModel.EyeColor = customerDataModel.EyeColor;
            customerDomainModel.Name = new CustomerDomainModel.CustomerName()
            {
                First = customerDataModel.Name.First,
                Last = customerDataModel.Name.Last
            };
            customerDomainModel.Company = customerDataModel.Company;
            customerDomainModel.Email = customerDataModel.Email;
            customerDomainModel.Phone = customerDataModel.Phone;
            customerDomainModel.Address = customerDataModel.Address;
            customerDomainModel.Registered = customerDataModel.Registered;
            customerDomainModel.Latitude = customerDataModel.Latitude;
            customerDomainModel.Longitude = customerDataModel.Longitude;
            customerDomainModel.Tags = customerDataModel.Tags;

            return customerDomainModel;
        }
    }
}
