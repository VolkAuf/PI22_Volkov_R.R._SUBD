using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Text;

namespace WarehouseBusinessLogic.ModelForTransfer
{
    public class ReceiptDocumentModel
    {
        public ObjectId Id { get; set; }
        public string Provider { get; set; }
        public DateTime DateArrival { get; set; }
        public int Price { get; set; }
        public int Count { get; set; }
        public Product Product { get; set; }
    }
}
