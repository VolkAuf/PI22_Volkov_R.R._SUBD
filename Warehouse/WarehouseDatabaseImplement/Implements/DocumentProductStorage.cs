using System;
using System.Collections.Generic;
using System.Text;
using WarehouseBusinessLogic.BindingModels;
using WarehouseBusinessLogic.Interfaces;
using WarehouseBusinessLogic.ViewModels;

namespace WarehouseDatabaseImplement.Implements
{
    public class DocumentProductStorage : IDocumentProductStorage
    {
        public DocumentProductViewModel GetElement(DocumentProductBindingModel model)
        {
            throw new NotImplementedException();
        }

        public List<DocumentProductViewModel> GetFilteredList(DocumentProductBindingModel model)
        {
            throw new NotImplementedException();
        }

        public List<DocumentProductViewModel> GetFullList()
        {
            throw new NotImplementedException();
        }
    }
}
