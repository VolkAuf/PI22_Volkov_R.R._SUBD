using System;
using System.Collections.Generic;
using System.Text;
using WarehouseBusinessLogic.BindingModels;
using WarehouseBusinessLogic.Interfaces;
using WarehouseBusinessLogic.ViewModels;

namespace WarehouseBusinessLogic.BusinessLogics
{
    public class DocumentExpensesLogic
    {
        private readonly IDocumentExpensesStorage documentExpensesStorage;
        private readonly IDocumentExpensesStorageRedis documentExpensesStorageRedis;
        private readonly IProductStorage productStorage;

        public DocumentExpensesLogic(IDocumentExpensesStorage documentExpensesStorage, IDocumentExpensesStorageRedis documentExpensesStorageRedis,
            IProductStorage productStorage)
        {
            this.documentExpensesStorageRedis = documentExpensesStorageRedis;
            this.documentExpensesStorage = documentExpensesStorage;
            this.productStorage = productStorage;
        }

        public List<DocumentExpensesViewModel> Read(DocumentExpensesBindingModel model)
        {
            if (model == null)
            {
                var redisStorage = documentExpensesStorageRedis.GetFullList();
                if (redisStorage != null && redisStorage.Count > 0)
                {
                    return redisStorage;
                }
                return productStorage.GetDocExpenses();
            }
            if (model.Id.HasValue)
            {
                var redisStorage = documentExpensesStorageRedis.GetElement(model);
                if (redisStorage != null)
                {
                    return new List<DocumentExpensesViewModel> { redisStorage };
                }
                return new List<DocumentExpensesViewModel> { documentExpensesStorage.GetElement(model) };
            }
            var redis = documentExpensesStorageRedis.GetFilteredList(model);
            if (redis != null && redis.Count > 0)
            {
                return redis;
            }
            return documentExpensesStorage.GetFilteredList(model);
        }
        public void UpdateCashe()
        {
            documentExpensesStorageRedis.DeleteAll();
            var pgsql = productStorage.GetDocExpenses();
            foreach (var product in pgsql)
            {
                documentExpensesStorageRedis.InsertOrUpdate(new DocumentExpensesBindingModel
                {
                    Id = product.Id,
                    DateDeparture = product.DateDeparture,
                    Customer = product.Customer,
                    Price = product.Price,
                    Count = product.Count,
                    ProductCount =product.ProductCount,
                    ProductName = product.ProductName,
                    ProductPrice = product.ProductPrice,
                    GrouppName = product.GrouppName
                });
            }
        }
    }
}
