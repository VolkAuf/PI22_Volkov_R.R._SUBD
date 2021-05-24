using System;
using System.Collections.Generic;
using System.Text;
using WarehouseBusinessLogic.BindingModels;
using WarehouseBusinessLogic.Interfaces;
using WarehouseBusinessLogic.ViewModels;

namespace WarehouseBusinessLogic.BusinessLogics
{
    public class ExpenseStatementLogic
    {
        private readonly IExpenseStatementStorage _expenseStatementStorage;
        public ExpenseStatementLogic(IExpenseStatementStorage expenseStatementStorage)
        {
            _expenseStatementStorage = expenseStatementStorage;
        }
        public List<ExpenseStatementViewModel> Read(ExpenseStatementBindingModel model)
        {
            if (model == null)
            {
                return _expenseStatementStorage.GetFullList();
            }
            if (model.Id.HasValue)
            {
                return new List<ExpenseStatementViewModel> { _expenseStatementStorage.GetElement(model) };
            }
            return _expenseStatementStorage.GetFilteredList(model);
        }
        public void CreateOrUpdate(ExpenseStatementBindingModel model)
        {
            if (model.Id.HasValue)
            {
                _expenseStatementStorage.Update(model);
            }
            else
            {
                _expenseStatementStorage.Insert(model);
            }
        }
        public void Delete(ExpenseStatementBindingModel model)
        {
            ExpenseStatementViewModel element = _expenseStatementStorage.GetElement(new ExpenseStatementBindingModel { Id = model.Id });
            if (element == null)
            {
                throw new Exception("Элемент не найден");
            }
            _expenseStatementStorage.Delete(model);
        }
    }
}
