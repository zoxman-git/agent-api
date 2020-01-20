using data_access_layer.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace data_access_layer
{
    public class FileRepository<T> : IRepository<T> where T : IEntity
    {
        private Dictionary<Type, string> _dataFiles = new Dictionary<Type, string>()
        {
            { typeof(AgentDataModel), "agent_data.json" },
            { typeof(CustomerDataModel), "customer_data.json" }
        };
        private string _filePath;

        public FileRepository()
        {
            _filePath = _dataFiles[typeof(T)];
        }

        public IEnumerable<T> Get()
        {
            List<T> response;
            
            response = JsonConvert.DeserializeObject<List<T>>(File.ReadAllText(_filePath));

            return response;
        }

        public void Add(T entity)
        {
            var entities = Get().ToList();

            entities.Add(entity);

            File.WriteAllText(_filePath, JsonConvert.SerializeObject(entities, Formatting.Indented));
        }

        public void Delete(int id)
        {
            var entities = Get().ToList();
            var entityToDelete = entities.Find(x => x.Id == id);
            
            entities.Remove(entityToDelete);
            
            File.WriteAllText(_filePath, JsonConvert.SerializeObject(entities, Formatting.Indented));
        }

        public void Update(T entity)
        {
            var entities = Get().ToList();
            var entityToUpdateIndex = entities.FindIndex(x => x.Id == entity.Id);

            entities[entityToUpdateIndex] = entity;

            File.WriteAllText(_filePath, JsonConvert.SerializeObject(entities, Formatting.Indented));
        }

        public T FindById(int id)
        {
            var entities = Get().ToList();
            var entityToFind = entities.Find(x => x.Id == id);

            return entityToFind;
        }
    }
}
