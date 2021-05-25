using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Unity;
using WarehouseBusinessLogic.BusinessLogics;

namespace WarehouseView
{
    public partial class FormMain : Form
    {
        [Dependency]
        public new IUnityContainer Container { get; set; }
        private readonly TransferLogic transferLogic;
        private readonly DocumentExpensesLogic documentExpensesLogic;
        private readonly DocumentProductLogic documentProductLogic;
        private readonly DocumentReceiptLogic documentReceiptLogic;

        public FormMain(TransferLogic transferLogic, DocumentExpensesLogic documentExpensesLogic,
            DocumentProductLogic documentProductLogic, DocumentReceiptLogic documentReceiptLogic)
        {
            this.transferLogic = transferLogic;
            this.documentProductLogic = documentProductLogic;
            this.documentExpensesLogic = documentExpensesLogic;
            this.documentReceiptLogic = documentReceiptLogic;
            InitializeComponent();
        }

        private void buttonProducts_Click(object sender, EventArgs e)
        {
            var form = Container.Resolve<FormProducts>();
            form.ShowDialog();
        }

        private void buttonGroupps_Click(object sender, EventArgs e)
        {
            var form = Container.Resolve<FormGroupps>();
            form.ShowDialog();
        }

        private void buttonExpenseStatements_Click(object sender, EventArgs e)
        {
            var form = Container.Resolve<FormExpenseStatements>();
            form.ShowDialog();
        }

        private void buttonReceiptStatements_Click(object sender, EventArgs e)
        {
            var form = Container.Resolve<FormReceiptStatements>();
            form.ShowDialog();
        }

        private void buttonQuery_Click(object sender, EventArgs e)
        {
            var form = Container.Resolve<FormQuery>();
            form.ShowDialog();
        }

        private void buttonTransfer_Click(object sender, EventArgs e)
        {
            transferLogic.TransferAll();
        }

        private void buttonRedicProduct_Click(object sender, EventArgs e)
        {
            documentProductLogic.UpdateCashe();
        }

        private void buttonRedicExpenses_Click(object sender, EventArgs e)
        {
            documentExpensesLogic.UpdateCashe();
        }

        private void buttonRedicReceipt_Click(object sender, EventArgs e)
        {
            documentReceiptLogic.UpdateCashe();
        }
    }
}
