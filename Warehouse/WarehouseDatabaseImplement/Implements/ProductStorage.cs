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
    public class ProductStorage : IProductStorage
    {
        public List<ProductViewModel> GetFullList()
        {
            using (WarehouseDatabase context = new WarehouseDatabase())
            {
                return context.Product
                .Include(rec => rec.Groupp)
                .Select(rec => new ProductViewModel
                {
                    Id = rec.Id,
                    GrouppId = (int) rec.GrouppId,
                    GrouppName = rec.Groupp.Name,
                    Name = rec.Name,
                    Price = rec.Price,
                    Count = rec.Count
                })
                .ToList();
            }
        }
        public List<ProductViewModel> GetFilteredList(ProductBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            using (WarehouseDatabase context = new WarehouseDatabase())
            {
                return context.Product
                .Include(rec => rec.Groupp)
                .Where(rec => rec.GrouppId == model.GrouppId)
                .Select(rec => new ProductViewModel
                {
                    Id = rec.Id,
                    GrouppId = (int)rec.GrouppId,
                    GrouppName = rec.Groupp.Name,
                    Name = rec.Name,
                    Price = rec.Price,
                    Count = rec.Count
                })
                .ToList();
            }
        }
        public ProductViewModel GetElement(ProductBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            using (WarehouseDatabase context = new WarehouseDatabase())
            {
                Product product = context.Product
                .Include(rec => rec.Groupp)
                .FirstOrDefault(rec => rec.Id == model.Id);
                return product != null ?
                new ProductViewModel
                {
                    Id = product.Id,
                    GrouppId = (int)product.GrouppId,
                    GrouppName = product.Groupp.Name,
                    Name = product.Name,
                    Price = product.Price,
                    Count = product.Count
                } :
                null;
            }
        }
        public void Insert(ProductBindingModel model)
        {
            using (WarehouseDatabase context = new WarehouseDatabase())
            {
                Product product = new Product
                {
                    GrouppId = model.GrouppId,
                    Name = model.Name,
                    Price = model.Price,
                    Count = model.Count
                };
                context.Product.Add(product);
                context.SaveChanges();
                CreateModel(model, product);
                context.SaveChanges();
            }
        }
        public void Update(ProductBindingModel model)
        {
            using (WarehouseDatabase context = new WarehouseDatabase())
            {
                Product element = context.Product.FirstOrDefault(rec => rec.Id == model.Id);
                if (element == null)
                {
                    throw new Exception("Элемент не найден");
                }
                element.GrouppId = model.GrouppId;
                element.Count = model.Count;
                element.Name = model.Name;
                element.Price = model.Price;
                element.Count = model.Count;
                CreateModel(model, element);
                context.SaveChanges();
            }
        }
        public void Delete(ProductBindingModel model)
        {
            using (WarehouseDatabase context = new WarehouseDatabase())
            {
                Product element = context.Product.FirstOrDefault(rec => rec.Id == model.Id);
                if (element != null)
                {
                    context.Product.Remove(element);
                    context.SaveChanges();
                }
                else
                {
                    throw new Exception("Элемент не найден");
                }
            }
        }
        private Product CreateModel(ProductBindingModel model, Product product)
        {
            if (model == null)
            {
                return null;
            }
            using (WarehouseDatabase context = new WarehouseDatabase())
            {
                Groupp element = context.Groupp.FirstOrDefault(rec => rec.Id == model.GrouppId);
                if (element != null)
                {
                    if (element.Product == null)
                    {
                        element.Product = new List<Product>();
                    }
                    element.Product.Add(product);
                    context.Groupp.Update(element);
                    context.SaveChanges();
                }
                else
                {
                    throw new Exception("Элемент не найден");
                }
            }
            return product;
        }

        public List<ProductExpenseQueryViewModel> GetQueryExpensesList()
        {
            using (WarehouseDatabase context = new WarehouseDatabase())
            {
                var products = context.Product
                .Include(rec => rec.Expensestatementproduct)
                .ThenInclude(rec => rec.Expensestatement)
                .ToList();

                var list = new List<ProductExpenseQueryViewModel>();
                foreach(var product in products)
                {
                    foreach (var pr in product.Expensestatementproduct) 
                    {
                        list.Add(new ProductExpenseQueryViewModel
                        {
                            Name = product.Name,
                            Price = product.Price,
                            Customer = pr.Expensestatement.Customer,
                            PriceExpense = pr.Price,
                            DateDeparture = pr.Expensestatement.Datedeparture,
                            CountExpense = pr.Count
                        });
                    }
                }
                return list;
            }
        }

        public List<ProductReceiptQueryViewModel> GetQueryReceiptsList()
        {
            using (WarehouseDatabase context = new WarehouseDatabase())
            {
                var products = context.Product
                .Include(rec => rec.Receiptstatementproduct)
                .ThenInclude(rec => rec.Receiptstatement)
                .ToList();

                var list = new List<ProductReceiptQueryViewModel>();
                foreach (var product in products)
                {
                    foreach (var pr in product.Receiptstatementproduct)
                    {
                        list.Add(new ProductReceiptQueryViewModel
                        {
                            Name = product.Name,
                            Price = product.Price,
                            Provider = pr.Receiptstatement.Provider,
                            PriceReceipt = pr.Price,
                            DateArrival = pr.Receiptstatement.Datearrival,
                            CountReceipt = pr.Count
                        });
                    }
                }
                return list;
            }
        }

        public List<DocumentReceiptViewModel> GetDocReceipt()
        {
            using (WarehouseDatabase context = new WarehouseDatabase())
            {
                var products = context.Product
                .Include(rec => rec.Groupp)
                .Include(rec => rec.Receiptstatementproduct)
                .ThenInclude(rec => rec.Receiptstatement)
                .ToList();

                var list = new List<DocumentReceiptViewModel>();
                foreach (var product in products)
                {
                    foreach (var pr in product.Receiptstatementproduct)
                    {
                        list.Add(new DocumentReceiptViewModel
                        {
                            ProductName = product.Name,
                            ProductPrice = product.Price,
                            ProductCount = product.Count,
                            GrouppName = product.Groupp.Name,
                            Provider = pr.Receiptstatement.Provider,
                            Price = pr.Price,
                            DateArrival = pr.Receiptstatement.Datearrival,
                            Count = pr.Count
                        });
                    }
                }
                return list;
            }
        }

        public List<DocumentExpensesViewModel> GetDocExpenses()
        {
            using (WarehouseDatabase context = new WarehouseDatabase())
            {
                var products = context.Product
                .Include(rec => rec.Groupp)
                .Include(rec => rec.Expensestatementproduct)
                .ThenInclude(rec => rec.Expensestatement)
                .ToList();

                var list = new List<DocumentExpensesViewModel>();
                foreach (var product in products)
                {
                    foreach (var pr in product.Expensestatementproduct)
                    {
                        list.Add(new DocumentExpensesViewModel
                        {
                            ProductName = product.Name,
                            ProductPrice = product.Price,
                            ProductCount = product.Count,
                            GrouppName = product.Groupp.Name,
                            Customer = pr.Expensestatement.Customer,
                            Price = pr.Price,
                            DateDeparture = pr.Expensestatement.Datedeparture,
                            Count = pr.Count
                        });
                    }
                }
                return list;
            }
        }
    }
}
