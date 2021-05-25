using Newtonsoft.Json;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Text;
using WarehouseBusinessLogic.BindingModels;
using WarehouseBusinessLogic.Interfaces;
using WarehouseBusinessLogic.ViewModels;

namespace WarehouseDatabaseImplement.Implements
{
    public class DocumentProductStorageRedis : IDocumentProductStorageRedis
    {
        public void DeleteAll()
        {
            using (var client = ConnectionMultiplexer.Connect("localhost"))
            {
                var db = client.GetDatabase();
                var product = db.SetMembers("Product");
                db.SetRemove("Product", product);
            }
        }
        public void InsertOrUpdate(DocumentProductBindingModel model)
        {
            if (model == null)
            {
                return;
            }
            using (var client = ConnectionMultiplexer.Connect("localhost"))
            {
                var db = client.GetDatabase();
                db.SetAdd("Product", JsonConvert.SerializeObject(model));
            }
        }

        public DocumentProductViewModel GetElement(DocumentProductBindingModel model)
        {
            throw new NotImplementedException();
        }

        public List<DocumentProductViewModel> GetFilteredList(DocumentProductBindingModel model)
        {
            throw new NotImplementedException();
        }

        public List<DocumentProductViewModel> GetFullList()
        {
            throw new NotImplementedException();
        }
    }
}
