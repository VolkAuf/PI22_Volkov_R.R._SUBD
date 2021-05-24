using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WarehouseBusinessLogic.BindingModels;
using WarehouseBusinessLogic.Interfaces;
using WarehouseBusinessLogic.ViewModels;
using WarehouseDatabaseImplement.DatabaseContext;
using WarehouseDatabaseImplement.Models;

namespace WarehouseDatabaseImplement.Implements
{
    public class ReceiptStatementStorage : IReceiptStatementStorage
    {
        public List<ReceiptStatementViewModel> GetFullList()
        {
            using (var context = new WarehouseDatabase())
            {
                return context.Receiptstatement
               .Include(rec => rec.Receiptstatementproduct)
               .ThenInclude(rec => rec.Product)
               .ToList()
               .Select(rec => new ReceiptStatementViewModel
               {
                   Id = rec.Id,
                   DateArrival = rec.Datearrival,
                   Provider = rec.Provider,
                   ReceiptStatementProducts = rec.Receiptstatementproduct
                   .ToDictionary(recd => recd.ProductId, recd => (recd.Product?.Name, recd.Price, recd.Count))
               })
               .ToList();
            }
        }
        public List<ReceiptStatementViewModel> GetFilteredList(ReceiptStatementBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            using (var context = new WarehouseDatabase())
            {
                return context.Receiptstatement
                .Include(rec => rec.Receiptstatementproduct)
                .ThenInclude(rec => rec.Product)
                .Where(rec => rec.Provider.Contains(model.Provider))
                .ToList()
                .Select(rec => new ReceiptStatementViewModel
                {
                    Id = rec.Id,
                    DateArrival = rec.Datearrival,
                    Provider = rec.Provider,
                    ReceiptStatementProducts = rec.Receiptstatementproduct
                   .ToDictionary(recd => recd.ProductId, recd => (recd.Product?.Name, recd.Price, recd.Count))
                })
                .ToList();
            }
        }
        public ReceiptStatementViewModel GetElement(ReceiptStatementBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            using (var context = new WarehouseDatabase())
            {
                var receiptStatement = context.Receiptstatement
                .Include(rec => rec.Receiptstatementproduct)
                .ThenInclude(rec => rec.Product)
                .FirstOrDefault(rec => rec.Provider == model.Provider || rec.Id == model.Id);
                return receiptStatement != null ?
                new ReceiptStatementViewModel
                {
                    Id = receiptStatement.Id,
                    DateArrival = receiptStatement.Datearrival,
                    Provider = receiptStatement.Provider,
                    ReceiptStatementProducts = receiptStatement.Receiptstatementproduct
                   .ToDictionary(recd => recd.ProductId, recd => (recd.Product?.Name, recd.Price, recd.Count))
                } :
                null;
            }
        }
        public void Insert(ReceiptStatementBindingModel model)
        {
            using (var context = new WarehouseDatabase())
            {
                using (var transaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        Receiptstatement receiptStatement = new Receiptstatement
                        {
                            Datearrival = DateTime.Now,
                            Provider = model.Provider,

                        };
                        context.Receiptstatement.Add(receiptStatement);
                        context.SaveChanges();
                        CreateModel(model, receiptStatement, context);
                        context.SaveChanges();
                        transaction.Commit();
                    }
                    catch
                    {
                        transaction.Rollback();
                        throw;
                    }
                }
            }
        }
        public void Update(ReceiptStatementBindingModel model)
        {
            using (var context = new WarehouseDatabase())
            {
                using (var transaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        var element = context.Receiptstatement.FirstOrDefault(rec => rec.Id == model.Id);
                        if (element == null)
                        {
                            throw new Exception("Элемент не найден");
                        }
                        element.Provider = model.Provider;
                        CreateModel(model, element, context);
                        context.SaveChanges();
                        transaction.Commit();
                    }
                    catch
                    {
                        transaction.Rollback();
                        throw;
                    }
                }
            }
        }
        public void Delete(ReceiptStatementBindingModel model)
        {
            using (var context = new WarehouseDatabase())
            {
                Receiptstatement element = context.Receiptstatement.FirstOrDefault(rec => rec.Id == model.Id);
                if (element != null)
                {
                    context.Receiptstatement.Remove(element);
                    context.SaveChanges();
                }
                else
                {
                    throw new Exception("Элемент не найден");
                }
            }
        }
        private Receiptstatement CreateModel(ReceiptStatementBindingModel model, Receiptstatement receiptStatement, WarehouseDatabase context)
        {
            if (model.Id.HasValue)
            {
                var receiptStatementProduct = context.Receiptstatementproduct.Where(rec => rec.ReceiptstatementId == model.Id.Value).ToList();
                // удалили те, которых нет в модели
                context.Receiptstatementproduct.RemoveRange(receiptStatementProduct.Where(rec => !model.ReceiptStatementProducts.ContainsKey(rec.ProductId)).ToList());
                context.SaveChanges();
                // обновили количество у существующих записей
                foreach (var updateProduct in receiptStatementProduct)
                {
                    updateProduct.Count = model.ReceiptStatementProducts[updateProduct.ProductId].Item2;
                    model.ReceiptStatementProducts.Remove(updateProduct.ProductId);
                }
                context.SaveChanges();
            }
            // добавили новые
            foreach (var esp in model.ReceiptStatementProducts)
            {
                context.Receiptstatementproduct.Add(new Receiptstatementproduct
                {
                    ProductId = esp.Key,
                    ReceiptstatementId = receiptStatement.Id,
                    Price = esp.Value.Item2,
                    Count = esp.Value.Item3
                });
                context.SaveChanges();
            }
            return receiptStatement;
        }
    }
}
