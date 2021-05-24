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
using WarehouseBusinessLogic.BindingModels;
using WarehouseBusinessLogic.BusinessLogics;
using WarehouseBusinessLogic.ViewModels;

namespace WarehouseView
{
    public partial class FormReceiptStatement : Form
    {
        [Dependency]
        public new IUnityContainer Container { get; set; }
        public int Id { set => id = value; }
        private readonly ReceiptStatementLogic logic;
        private int? id;
        private Dictionary<int, (string, int, int)> ReceiptStatementProducts;
        public FormReceiptStatement(ReceiptStatementLogic service)
        {
            InitializeComponent();
            logic = service;
        }
        private void FormExpenseStatement_Load(object sender, EventArgs e)
        {
            if (id.HasValue)
            {
                try
                {
                    ReceiptStatementViewModel view = logic.Read(new ReceiptStatementBindingModel { Id = id.Value })?[0];
                    if (view != null)
                    {
                        textBoxName.Text = view.Provider;
                        ReceiptStatementProducts = view.ReceiptStatementProducts;
                        LoadData();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                ReceiptStatementProducts = new Dictionary<int, (string, int, int)>();
            }
        }
        private void LoadData()
        {
            try
            {
                if (ReceiptStatementProducts != null)
                {
                    dataGridView.Rows.Clear();
                    foreach (KeyValuePair<int, (string, int, int)> esp in ReceiptStatementProducts)
                    {
                        dataGridView.Rows.Add(new object[] { esp.Key, esp.Value.Item1, esp.Value.Item2, esp.Value.Item3 });
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void ButtonAdd_Click(object sender, EventArgs e)
        {
            var form = Container.Resolve<FormReceiptStatementProducts>();
            if (form.ShowDialog() == DialogResult.OK)
            {
                if (ReceiptStatementProducts.ContainsKey(form.Id))
                {
                    ReceiptStatementProducts[form.Id] = (form.ProductName, form.Count, form.Price);
                }
                else
                {
                    ReceiptStatementProducts.Add(form.Id, (form.ProductName, form.Count, form.Price));
                }
                LoadData();
            }
        }
        private void ButtonUpd_Click(object sender, EventArgs e)
        {
            if (dataGridView.SelectedRows.Count == 1)
            {
                var form = Container.Resolve<FormReceiptStatementProducts>();
                int id = Convert.ToInt32(dataGridView.SelectedRows[0].Cells[0].Value);
                form.Id = id;
                form.Count = ReceiptStatementProducts[id].Item2;
                if (form.ShowDialog() == DialogResult.OK)
                {
                    ReceiptStatementProducts[form.Id] = (form.ProductName, form.Count, form.Price);
                    LoadData();
                }
            }
        }
        private void ButtonDel_Click(object sender, EventArgs e)
        {
            if (dataGridView.SelectedRows.Count == 1)
            {
                if (MessageBox.Show("Удалить запись", "Вопрос", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    try
                    {
                        ReceiptStatementProducts.Remove(Convert.ToInt32(dataGridView.SelectedRows[0].Cells[0].Value));
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    LoadData();
                }
            }
        }
        private void ButtonRef_Click(object sender, EventArgs e)
        {
            LoadData();
        }
        private void ButtonSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxName.Text))
            {
                MessageBox.Show("Заполните название", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (ReceiptStatementProducts == null || ReceiptStatementProducts.Count == 0)
            {
                MessageBox.Show("Заполните компоненты", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            try
            {
                logic.CreateOrUpdate(new ReceiptStatementBindingModel
                {
                    Id = id,
                    Provider = textBoxName.Text,
                    ReceiptStatementProducts = ReceiptStatementProducts
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
