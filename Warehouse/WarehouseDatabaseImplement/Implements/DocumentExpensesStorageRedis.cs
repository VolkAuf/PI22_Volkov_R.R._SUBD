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
    public class DocumentExpensesStorageRedis : IDocumentExpensesStorageRedis
    {
        public DocumentExpensesViewModel GetElement(DocumentExpensesBindingModel model)
        {
            throw new NotImplementedException();
        }

        public List<DocumentExpensesViewModel> GetFilteredList(DocumentExpensesBindingModel model)
        {
            throw new NotImplementedException();
        }

        public List<DocumentExpensesViewModel> GetFullList()
        {
            throw new NotImplementedException();
        }
        public void DeleteAll()
        {
            using (var client = ConnectionMultiplexer.Connect("localhost"))
            {
                var db = client.GetDatabase();
                var expenses = db.SetMembers("Expenses");
                db.SetRemove("Expenses", expenses);
            }
        }
        public void InsertOrUpdate(DocumentExpensesBindingModel model)
        {
            if (model == null)
            {
                return;
            }
            using (var client = ConnectionMultiplexer.Connect("localhost"))
            {
                var db = client.GetDatabase();
                db.SetAdd("Expenses", JsonConvert.SerializeObject(model));
            }
        }
    }
}
