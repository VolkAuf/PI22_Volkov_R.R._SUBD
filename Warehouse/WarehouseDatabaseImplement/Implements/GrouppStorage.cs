using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using WarehouseBusinessLogic.BindingModels;
using WarehouseBusinessLogic.Interfaces;
using WarehouseBusinessLogic.ViewModels;
using WarehouseDatabaseImplement.DatabaseContext;
using WarehouseDatabaseImplement.Models;

namespace WarehouseDatabaseImplement.Implements
{
    public class GrouppStorage : IGrouppStorage
    {
        public List<GrouppViewModel> GetFullList()
        {
            using (var context = new WarehouseDatabase())
            {
                return context.Groupp
                .ToList()
                .Select(rec => new GrouppViewModel
                {
                    Id = rec.Id,
                    Name = rec.Name
                })
                .ToList();
            }
        }
        public List<GrouppViewModel> GetFilteredList(GrouppBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            using (var context = new WarehouseDatabase())
            {
                return context.Groupp
                .ToList()
                .Select(rec => new GrouppViewModel
                {
                    Id = rec.Id,
                    Name = rec.Name
                })
                .ToList();
            }
        }
        public GrouppViewModel GetElement(GrouppBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            using (var context = new WarehouseDatabase())
            {
                var groupp = context.Groupp
                .FirstOrDefault(rec => rec.Id == model.Id);
                return groupp != null ?
                new GrouppViewModel
                {
                    Id = groupp.Id,
                    Name = groupp.Name
                } :
                null;
            }
        }
        public void Insert(GrouppBindingModel model)
        {
            using (var context = new WarehouseDatabase())
            {
                using (var transaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        Groupp groupp = new Groupp
                        {
                            Name = model.Name
                        };
                        context.Groupp.Add(groupp);
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
        public void Update(GrouppBindingModel model)
        {
            using (var context = new WarehouseDatabase())
            {
                using (var transaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        var element = context.Groupp.FirstOrDefault(rec => rec.Id == model.Id);
                        if (element == null)
                        {
                            throw new Exception("Элемент не найден");
                        }
                        element.Name = model.Name;
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
        public void Delete(GrouppBindingModel model)
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
    }
}
