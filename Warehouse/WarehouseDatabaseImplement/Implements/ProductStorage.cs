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
    }
}
