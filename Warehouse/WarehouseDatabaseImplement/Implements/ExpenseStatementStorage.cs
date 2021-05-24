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
    public class ExpenseStatementStorage : IExpenseStatementStorage
    {
        public List<ExpenseStatementViewModel> GetFullList()
        {
            using (var context = new WarehouseDatabase())
            {
                return context.Expensestatement
               .Include(rec => rec.Expensestatementproduct)
               .ThenInclude(rec => rec.Product)
               .ToList()
               .Select(rec => new ExpenseStatementViewModel
               {
                   Id = rec.Id,
                   DateDeparture = rec.Datedeparture,
                   Customer = rec.Customer,
                   ExpenseStatementProducts = rec.Expensestatementproduct
                   .ToDictionary(recd => recd.ProductId, recd => (recd.Product?.Name, recd.Price, recd.Count))
               })
               .ToList();
            }
        }
        public List<ExpenseStatementViewModel> GetFilteredList(ExpenseStatementBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            using (var context = new WarehouseDatabase())
            {
                return context.Expensestatement
                .Include(rec => rec.Expensestatementproduct)
                .ThenInclude(rec => rec.Product)
                .Where(rec => rec.Customer.Contains(model.Customer))
                .ToList()
                .Select(rec => new ExpenseStatementViewModel
                {
                    Id = rec.Id,
                    DateDeparture = rec.Datedeparture,
                    Customer = rec.Customer,
                    ExpenseStatementProducts = rec.Expensestatementproduct
                   .ToDictionary(recd => recd.ProductId, recd => (recd.Product?.Name, recd.Price, recd.Count))
                })
                .ToList();
            }
        }
        public ExpenseStatementViewModel GetElement(ExpenseStatementBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            using (var context = new WarehouseDatabase())
            {
                var expensestatement = context.Expensestatement
                .Include(rec => rec.Expensestatementproduct)
                .ThenInclude(rec => rec.Product)
                .FirstOrDefault(rec => rec.Customer == model.Customer || rec.Id == model.Id);
                return expensestatement != null ?
                new ExpenseStatementViewModel
                {
                    Id = expensestatement.Id,
                    DateDeparture = expensestatement.Datedeparture,
                    Customer = expensestatement.Customer,
                    ExpenseStatementProducts = expensestatement.Expensestatementproduct
                   .ToDictionary(recd => recd.ProductId, recd => (recd.Product?.Name, recd.Price, recd.Count))
                } :
                null;
            }
        }
        public void Insert(ExpenseStatementBindingModel model)
        {
            using (var context = new WarehouseDatabase())
            {
                using (var transaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        Expensestatement expensesStatement = new Expensestatement
                        {
                            Datedeparture = model.DateDeparture,
                            Customer = model.Customer,

                        };
                        context.Expensestatement.Add(expensesStatement);
                        context.SaveChanges();
                        CreateModel(model, expensesStatement, context);
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
        public void Update(ExpenseStatementBindingModel model)
        {
            using (var context = new WarehouseDatabase())
            {
                using (var transaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        var element = context.Expensestatement.FirstOrDefault(rec => rec.Id == model.Id);
                        if (element == null)
                        {
                            throw new Exception("Элемент не найден");
                        }
                        element.Customer = model.Customer;
                        element.Datedeparture = model.DateDeparture;
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
        public void Delete(ExpenseStatementBindingModel model)
        {
            using (var context = new WarehouseDatabase())
            {
                Groupp element = context.Groupp.FirstOrDefault(rec => rec.Id == model.Id);
                if (element != null)
                {
                    context.Groupp.Remove(element);
                    context.SaveChanges();
                }
                else
                {
                    throw new Exception("Элемент не найден");
                }
            }
        }
        private Expensestatement CreateModel(ExpenseStatementBindingModel model, Expensestatement expenseStatement, WarehouseDatabase context)
        {
            if (model.Id.HasValue)
            {
                var expensestatementproduct = context.Expensestatementproduct.Where(rec => rec.ExpensestatementId == model.Id.Value).ToList();
                // удалили те, которых нет в модели
                context.Expensestatementproduct.RemoveRange(expensestatementproduct.Where(rec => !model.ExpenseStatementProducts.ContainsKey(rec.ProductId)).ToList());
                context.SaveChanges();
                // обновили количество у существующих записей
                foreach (var updateProduct in expensestatementproduct)
                {
                    updateProduct.Count = model.ExpenseStatementProducts[updateProduct.ProductId].Item2;
                    model.ExpenseStatementProducts.Remove(updateProduct.ProductId);
                }
                context.SaveChanges();
            }
            // добавили новые
            foreach (var esp in model.ExpenseStatementProducts)
            {
                context.Expensestatementproduct.Add(new Expensestatementproduct
                {
                    ProductId = esp.Key,
                    ExpensestatementId = expenseStatement.Id,
                    Price = esp.Value.Item2,
                    Count = esp.Value.Item3
                });
                context.SaveChanges();
            }
            return expenseStatement;
        }
    }
}
