using System;
using System.Collections.Generic;
using System.Text;
using WarehouseBusinessLogic.BindingModels;
using WarehouseBusinessLogic.ViewModels;

namespace WarehouseBusinessLogic.Interfaces
{
    public interface IExpenseStatementStorage
    {
        List<ExpenseStatementViewModel> GetFullList();
        List<ExpenseStatementViewModel> GetFilteredList(ExpenseStatementBindingModel model);
        ExpenseStatementViewModel GetElement(ExpenseStatementBindingModel model);
        void Insert(ExpenseStatementBindingModel model);
        void Update(ExpenseStatementBindingModel model);
        void Delete(ExpenseStatementBindingModel model);
    }
}
