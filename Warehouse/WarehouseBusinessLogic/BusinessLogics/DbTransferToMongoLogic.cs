using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WarehouseBusinessLogic.ModelForTransfer;

namespace WarehouseBusinessLogic.BusinessLogics
{
    public class DbTransferToMongoLogic
    {
        static string connectionString = "mongodb://localhost:27017";
        static string DatabaseString = "Warehouse7";
        static string ProductCollectionString = "Product";
        static string ExpensesCollectionString = "Expenses";
        static string ReceiptCollectionString = "Receipt";

        public static async Task SaveProduct(ProductDocumentModel model)
        {
            var client = new MongoClient(connectionString);
            var database = client.GetDatabase(DatabaseString);
            var collection = database.GetCollection<ProductDocumentModel>(ProductCollectionString);
            await collection.InsertOneAsync(model);
        }
        public static async Task SaveExpenses(ExpensesDocumentModel model)
        {
            var client = new MongoClient(connectionString);
            var database = client.GetDatabase(DatabaseString);
            var collection = database.GetCollection<ExpensesDocumentModel>(ExpensesCollectionString);
            await collection.InsertOneAsync(model);
        }
        public static async Task SaveReceipt(ReceiptDocumentModel model)
        {
            var client = new MongoClient(connectionString);
            var database = client.GetDatabase(DatabaseString);
            var collection = database.GetCollection<ReceiptDocumentModel>(ReceiptCollectionString);
            await collection.InsertOneAsync(model);
        }
        public static async Task<ObjectId> FindProduct(ProductDocumentModel model)
        {
            var client = new MongoClient(connectionString);
            var database = client.GetDatabase(DatabaseString);
            var collection = database.GetCollection<ProductDocumentModel>(ProductCollectionString);
            var filter = new BsonDocument("name", model.Name);
            var result = await collection.FindAsync(filter);
            return result.FirstOrDefault().Id;
        }
    }
}
