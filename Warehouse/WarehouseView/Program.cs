using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Unity;
using Unity.Lifetime;
using WarehouseBusinessLogic.BusinessLogics;
using WarehouseBusinessLogic.Interfaces;
using WarehouseDatabaseImplement.Implements;

namespace WarehouseView
{
    static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            var container = BuildUnityContainer();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(container.Resolve<FormMain>());
        }
        private static IUnityContainer BuildUnityContainer()
        {
            var currentContainer = new UnityContainer();
            currentContainer.RegisterType<IGrouppStorage, GrouppStorage>(new HierarchicalLifetimeManager());
            currentContainer.RegisterType<IProductStorage, ProductStorage>(new HierarchicalLifetimeManager());
            currentContainer.RegisterType<IExpenseStatementStorage, ExpenseStatementStorage>(new HierarchicalLifetimeManager());
            currentContainer.RegisterType<IReceiptStatementStorage, ReceiptStatementStorage>(new HierarchicalLifetimeManager());
            currentContainer.RegisterType<GrouppLogic>(new HierarchicalLifetimeManager());
            currentContainer.RegisterType<ProductLogic>(new HierarchicalLifetimeManager());
            currentContainer.RegisterType<ExpenseStatementLogic>(new HierarchicalLifetimeManager());
            currentContainer.RegisterType<ReceiptStatementLogic>(new HierarchicalLifetimeManager());
            return currentContainer;
        }
    }
}
