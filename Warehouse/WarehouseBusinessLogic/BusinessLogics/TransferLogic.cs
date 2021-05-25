using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WarehouseBusinessLogic.BindingModels;
using WarehouseBusinessLogic.Interfaces;
using WarehouseBusinessLogic.ModelForTransfer;

namespace WarehouseBusinessLogic.BusinessLogics
{
    public class TransferLogic
    {
        private readonly IProductStorage productStorage;
        private readonly IExpenseStatementStorage expenseStatementStorage;
        private readonly IReceiptStatementStorage receiptStatementStorage;
        private readonly IGrouppStorage grouppStorage;

        public TransferLogic(IProductStorage productStorage, IExpenseStatementStorage expenseStatementStorage,
            IReceiptStatementStorage receiptStatementStorage, IGrouppStorage grouppStorage)
        {
            this.productStorage = productStorage;
            this.expenseStatementStorage = expenseStatementStorage;
            this.receiptStatementStorage = receiptStatementStorage;
            this.grouppStorage = grouppStorage;
        }

        public async void TransferAll()
        {
            var products = await Task.Run(() => productStorage.GetFullList());

            await Task.Run(async () =>
            {
                foreach (var product in products)
                {
                    await DbTransferToMongoLogic.SaveProduct(new ProductDocumentModel
                    {
                        Name = product.Name,
                        Price = product.Price,
                        Count = product.Count,
                        GrouppName = product.GrouppName
                    });
                }
            });

            await Task.Run(async () =>
            {
                var ep = await Task.Run(() => productStorage.GetDocExpenses());
                foreach (var expens in ep)
                {
                    var prod = new Product();
                    prod.Name = expens.ProductName;
                    prod.Price = expens.ProductPrice;
                    prod.Count = expens.ProductCount;
                    prod.GrouppName = expens.GrouppName;
                    await DbTransferToMongoLogic.SaveExpenses(new ExpensesDocumentModel
                    {
                        Count = expens.Count,
                        Customer = expens.Customer,
                        DateDeparture = expens.DateDeparture,
                        Price = expens.Price,
                        Product = prod
                    });
                }
            });
            await Task.Run(async () =>
            {
                var rc = await Task.Run(() => productStorage.GetDocReceipt());
                foreach (var receipt in rc)
                {
                    var prod = new Product();
                    prod.Name = receipt.ProductName;
                    prod.Price = receipt.Price;
                    prod.Count = receipt.Count;
                    prod.GrouppName = receipt.GrouppName;
                    await DbTransferToMongoLogic.SaveReceipt(new ReceiptDocumentModel
                    {
                        Count = receipt.Count,
                        Provider = receipt.Provider,
                        DateArrival = receipt.DateArrival,
                        Price = receipt.Price,
                        Product = prod
                    });
                }
            });
        } 
    }
}
