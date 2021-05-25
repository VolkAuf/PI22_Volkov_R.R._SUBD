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

namespace WarehouseView
{
    public partial class FormMain : Form
    {
        [Dependency]
        public new IUnityContainer Container { get; set; }

        public FormMain()
        {
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
    }
}
