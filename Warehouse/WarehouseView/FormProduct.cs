using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Unity;
using WarehouseBusinessLogic.BindingModels;
using WarehouseBusinessLogic.BusinessLogics;

namespace WarehouseView
{
    public partial class FormProduct : Form
    {
        [Dependency]
        public new IUnityContainer Container { get; set; }
        private readonly GrouppLogic _logicG;
        private readonly ProductLogic _logicP;
        public int Id { set => id = value; }
        private int? id;
        public FormProduct(GrouppLogic logiG, ProductLogic logiP)
        {
            InitializeComponent();
            _logicG = logiG;
            _logicP = logiP;
        }
        private void FormProduct_Load(object sender, EventArgs e)
        {
            try
            {
                List<WarehouseBusinessLogic.ViewModels.GrouppViewModel> view = _logicG.Read(null);
                if (view != null)
                {
                    comboBoxGroupp.DisplayMember = "Name";
                    comboBoxGroupp.ValueMember = "Id";
                    comboBoxGroupp.DataSource = view;
                    comboBoxGroupp.SelectedItem = null;
                }
                if (id.HasValue)
                {
                    WarehouseBusinessLogic.ViewModels.ProductViewModel product = _logicP.Read(new ProductBindingModel { Id = id })?[0];
                    comboBoxGroupp.SelectedValue = product.GrouppId;
                    textBoxCount.Text = product.Count.ToString();
                    textBoxProduct.Text = product.Name;
                    textBoxPrice.Text = product.Price.ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ButtonSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxCount.Text))
            {
                MessageBox.Show("Заполните поле Количество", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (comboBoxGroupp.SelectedValue == null)
            {
                MessageBox.Show("Выберите группу", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            try
            {
                _logicP.CreateOrUpdate(new ProductBindingModel
                {
                    Id = id,
                    GrouppId = Convert.ToInt32(comboBoxGroupp.SelectedValue),
                    Name = textBoxProduct.Text,
                    Price = Convert.ToInt32(textBoxPrice.Text),
                    Count = Convert.ToInt32(textBoxCount.Text),
                });
                MessageBox.Show("Сохранение прошло успешно", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information);
                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void ButtonCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
