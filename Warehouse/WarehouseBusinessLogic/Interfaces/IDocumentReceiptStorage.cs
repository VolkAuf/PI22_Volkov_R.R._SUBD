using System;
using System.Collections.Generic;
using System.Text;
using WarehouseBusinessLogic.BindingModels;
using WarehouseBusinessLogic.ViewModels;

namespace WarehouseBusinessLogic.Interfaces
{
    public interface IDocumentReceiptStorage
    {
        List<DocumentReceiptViewModel> GetFullList();
        List<DocumentReceiptViewModel> GetFilteredList(DocumentReceiptBindingModel model);
        DocumentReceiptViewModel GetElement(DocumentReceiptBindingModel model);
    }
}
