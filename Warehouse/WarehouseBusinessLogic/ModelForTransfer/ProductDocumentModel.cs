using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Text;

namespace WarehouseBusinessLogic.ModelForTransfer
{
    public class ProductDocumentModel
    {
        public ObjectId Id { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public int Count { get; set; }
        public string GrouppName { get; set; }
    }
}
