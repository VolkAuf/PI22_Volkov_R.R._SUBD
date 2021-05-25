using System;
using System.Collections.Generic;
using System.Text;
using WarehouseBusinessLogic.BindingModels;
using WarehouseBusinessLogic.ViewModels;

namespace WarehouseBusinessLogic.Interfaces
{
    public interface IDocumentProductStorage
    {
        List<DocumentProductViewModel> GetFullList();
        List<DocumentProductViewModel> GetFilteredList(DocumentProductBindingModel model);
        DocumentProductViewModel GetElement(DocumentProductBindingModel model);
    }
}
