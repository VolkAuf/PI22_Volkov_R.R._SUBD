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
using WarehouseBusinessLogic.ViewModels;

namespace WarehouseView
{
    public partial class FormExpenseStatementProducts : Form
    {
        [Dependency]
        public new IUnityContainer Container { get; set; }
        public int Id { get => Convert.ToInt32(comboBoxProduct.SelectedValue); set => comboBoxProduct.SelectedValue = value; }
        public string ProductName => comboBoxProduct.Text;
        public int Count { get => Convert.ToInt32(textBoxCount.Text); set => textBoxCount.Text = value.ToString(); }
        public int Price { get => Convert.ToInt32(textBoxPrice.Text); set => textBoxPrice.Text = value.ToString(); }
        private readonly ProductLogic productLogic;

        public FormExpenseStatementProducts(ProductLogic logic)
        {
            InitializeComponent();
            List<ProductViewModel> list = logic.Read(null);
            if (list != null)
            {
                comboBoxProduct.DisplayMember = "Name";
                comboBoxProduct.ValueMember = "Id";
                comboBoxProduct.DataSource = list;
                comboBoxProduct.SelectedItem = null;
            }
        }
        private void ButtonSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxCount.Text))
            {
                MessageBox.Show("Заполните поле Количество", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (comboBoxProduct.SelectedValue == null)
            {
                MessageBox.Show("Выберите компонент", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            DialogResult = DialogResult.OK;
            Close();
        }
        private void ButtonCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
