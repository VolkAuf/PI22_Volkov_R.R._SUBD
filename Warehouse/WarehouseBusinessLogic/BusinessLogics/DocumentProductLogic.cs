using System;
using System.Collections.Generic;
using System.Text;
using WarehouseBusinessLogic.BindingModels;
using WarehouseBusinessLogic.Interfaces;
using WarehouseBusinessLogic.ViewModels;

namespace WarehouseBusinessLogic.BusinessLogics
{
    public class DocumentProductLogic
    {
        private readonly IDocumentProductStorage documentProductStorage;
        private readonly IDocumentProductStorageRedis documentProductStorageRedis;
        private readonly IProductStorage productStorage;

        public DocumentProductLogic(IDocumentProductStorage documentProductStorage, IDocumentProductStorageRedis documentProductStorageRedis,
            IProductStorage productStorage)
        {
            this.documentProductStorageRedis = documentProductStorageRedis;
            this.documentProductStorage = documentProductStorage;
            this.productStorage = productStorage;
        }

        public List<DocumentProductViewModel> Read(DocumentProductBindingModel model)
        {
            if (model == null)
            {
                var redisStorage = documentProductStorageRedis.GetFullList();
                if (redisStorage != null && redisStorage.Count > 0)
                {
                    return redisStorage;
                }
                return documentProductStorage.GetFullList();
            }
            if (model.Id.HasValue)
            {
                var redisStorage = documentProductStorageRedis.GetElement(model);
                if (redisStorage != null)
                {
                    return new List<DocumentProductViewModel> { redisStorage };
                }
                return new List<DocumentProductViewModel> { documentProductStorage.GetElement(model) };
            }
            var redis = documentProductStorageRedis.GetFilteredList(model);
            if (redis != null && redis.Count > 0)
            {
                return redis;
            }
            return documentProductStorage.GetFilteredList(model);
        }
        public void UpdateCashe()
        {
            documentProductStorageRedis.DeleteAll();
            var pgsql = productStorage.GetFullList();
            foreach (var product in pgsql)
            {
                documentProductStorageRedis.InsertOrUpdate(new DocumentProductBindingModel
                {
                    Id = product.Id,
                    Name = product.Name,
                    GrouppName = product.GrouppName,
                    Price = product.Price,
                    Count = product.Count
                });
            }
        }
    }
}
