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
    public class DocumentReceiptStorageRedis : IDocumentReceiptStorageRedis
    {
        public void DeleteAll()
        {
            using (var client = ConnectionMultiplexer.Connect("localhost"))
            {
                var db = client.GetDatabase();
                var receipt = db.SetMembers("Receipt");
                db.SetRemove("Receipt", receipt);
            }
        }
        public void InsertOrUpdate(DocumentReceiptBindingModel model)
        {
            if (model == null)
            {
                return;
            }
            using (var client = ConnectionMultiplexer.Connect("localhost"))
            {
                var db = client.GetDatabase();
                db.SetAdd("Receipt", JsonConvert.SerializeObject(model));
            }
        }

        public DocumentReceiptViewModel GetElement(DocumentReceiptBindingModel model)
        {
            throw new NotImplementedException();
        }

        public List<DocumentReceiptViewModel> GetFilteredList(DocumentReceiptBindingModel model)
        {
            throw new NotImplementedException();
        }

        public List<DocumentReceiptViewModel> GetFullList()
        {
            throw new NotImplementedException();
        }
    }
}
