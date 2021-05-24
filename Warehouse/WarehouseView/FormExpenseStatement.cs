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
    public partial class FormExpenseStatement : Form
    {
        [Dependency]
        public new IUnityContainer Container { get; set; }
        public int Id { set => id = value; }
        private readonly ExpenseStatementLogic logic;
        private int? id;
        private Dictionary<int, (string, int, int)> ExpenseStatementProducts;
        public FormExpenseStatement(ExpenseStatementLogic service)
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
                    ExpenseStatementViewModel view = logic.Read(new ExpenseStatementBindingModel { Id = id.Value })?[0];
                    if (view != null)
                    {
                        textBoxName.Text = view.Customer;
                        ExpenseStatementProducts = view.ExpenseStatementProducts;
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
                ExpenseStatementProducts = new Dictionary<int, (string, int, int)>();
            }
        }
        private void LoadData()
        {
            try
            {
                if (ExpenseStatementProducts != null)
                {
                    dataGridView.Rows.Clear();
                    foreach (KeyValuePair<int, (string, int, int)> esp in ExpenseStatementProducts)
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
            var form = Container.Resolve<FormExpenseStatementProducts>();
            if (form.ShowDialog() == DialogResult.OK)
            {
                if (ExpenseStatementProducts.ContainsKey(form.Id))
                {
                    ExpenseStatementProducts[form.Id] = (form.ProductName, form.Count, form.Price);
                }
                else
                {
                    ExpenseStatementProducts.Add(form.Id, (form.ProductName, form.Count, form.Price));
                }
                LoadData();
            }
        }
        private void ButtonUpd_Click(object sender, EventArgs e)
        {
            if (dataGridView.SelectedRows.Count == 1)
            {
                var form = Container.Resolve<FormExpenseStatementProducts>();
                int id = Convert.ToInt32(dataGridView.SelectedRows[0].Cells[0].Value);
                form.Id = id;
                form.Count = ExpenseStatementProducts[id].Item2;
                if (form.ShowDialog() == DialogResult.OK)
                {
                    ExpenseStatementProducts[form.Id] = (form.ProductName, form.Count, form.Price);
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
                        ExpenseStatementProducts.Remove(Convert.ToInt32(dataGridView.SelectedRows[0].Cells[0].Value));
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
            if (ExpenseStatementProducts == null || ExpenseStatementProducts.Count == 0)
            {
                MessageBox.Show("Заполните компоненты", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            try
            {
                logic.CreateOrUpdate(new ExpenseStatementBindingModel
                {
                    Id = id,
                    Customer = textBoxName.Text,
                    DateDeparture = DateTime.Now,
                    ExpenseStatementProducts = ExpenseStatementProducts
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
