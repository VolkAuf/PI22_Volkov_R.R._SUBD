using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Text;

namespace WarehouseBusinessLogic.ModelForTransfer
{
    public class ExpensesDocumentModel
    {
        public ObjectId Id { get; set; }
        public string Customer { get; set; }
        public DateTime DateDeparture { get; set; }
        public int Price { get; set; }
        public int Count { get; set; }
        public Product Product { get; set; }
    }
}
