using System;
using System.Collections.Generic;
using System.Text;
using WarehouseBusinessLogic.BindingModels;
using WarehouseBusinessLogic.Interfaces;
using WarehouseBusinessLogic.ViewModels;

namespace WarehouseBusinessLogic.BusinessLogics
{
    public class DocumentReceiptLogic
    {
        private readonly IDocumentReceiptStorage documentReceiptStorage;
        private readonly IDocumentReceiptStorageRedis documentReceiptStorageRedis;

        public DocumentReceiptLogic(IDocumentReceiptStorage documentReceiptStorage, IDocumentReceiptStorageRedis documentReceiptStorageRedis)
        {
            this.documentReceiptStorageRedis = documentReceiptStorageRedis;
            this.documentReceiptStorage = documentReceiptStorage;
        }

        public List<DocumentReceiptViewModel> Read(DocumentReceiptBindingModel model)
        {
            if (model == null)
            {
                var redisStorage = documentReceiptStorageRedis.GetFullList();
                if (redisStorage != null && redisStorage.Count > 0)
                {
                    return redisStorage;
                }
                return documentReceiptStorage.GetFullList();
            }
            if (model.Id.HasValue)
            {
                var redisStorage = documentReceiptStorageRedis.GetElement(model);
                if (redisStorage != null)
                {
                    return new List<DocumentReceiptViewModel> { redisStorage };
                }
                return new List<DocumentReceiptViewModel> { documentReceiptStorage.GetElement(model) };
            }
            var redis = documentReceiptStorageRedis.GetFilteredList(model);
            if (redis != null && redis.Count > 0)
            {
                return redis;
            }
            return documentReceiptStorage.GetFilteredList(model);
        }
        public void UpdateCashe()
        {
            documentReceiptStorageRedis.DeleteAll();
            var pgsql = documentReceiptStorage.GetFullList();
            foreach (var product in pgsql)
            {
                documentReceiptStorageRedis.InsertOrUpdate(new DocumentReceiptBindingModel
                {
                    Id = product.Id,
                    Provider = product.Provider,
                    DateArrival = product.DateArrival,
                    Price = product.Price,
                    Count = product.Count,
                    ProductCount = product.ProductCount,
                    ProductName = product.ProductName,
                    ProductPrice = product.ProductPrice,
                    GrouppName = product.GrouppName
                });
            }
        }
    }
}
