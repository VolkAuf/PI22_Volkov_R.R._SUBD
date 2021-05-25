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
    public partial class FormQuery : Form
    {
        private readonly ProductLogic productLogic;

        public FormQuery(ProductLogic productLogic)
        {
            this.productLogic = productLogic;
            InitializeComponent();
        }
        
        private void buttonProduct_Click(object sender, EventArgs e)
        {
            try
            {
                var list = productLogic.Read(null);
                if (list != null)
                {
                    dataGridView.DataSource = list;
                    dataGridView.Columns[0].Visible = false;
                    dataGridView.Columns[3].Visible = false;
                    dataGridView.Columns[4].Visible = false;
                    dataGridView.Columns[5].Visible = false;
                    dataGridView.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    dataGridView.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonDateExpense_Click(object sender, EventArgs e)
        {
            try
            {
                var list = productLogic.ReadQueryExpenses();
                if (list != null)
                {
                    dataGridView.DataSource = list;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonDateReceipt_Click(object sender, EventArgs e)
        {
            try
            {
                var list = productLogic.ReadQueryReceipts();
                if (list != null)
                {
                    dataGridView.DataSource = list;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
