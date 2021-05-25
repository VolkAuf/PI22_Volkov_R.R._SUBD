
namespace WarehouseView
{
    partial class FormQuery
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.buttonProduct = new System.Windows.Forms.Button();
            this.buttonDateExpense = new System.Windows.Forms.Button();
            this.buttonDateReceipt = new System.Windows.Forms.Button();
            this.dataGridView = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonProduct
            // 
            this.buttonProduct.Location = new System.Drawing.Point(6, 10);
            this.buttonProduct.Name = "buttonProduct";
            this.buttonProduct.Size = new System.Drawing.Size(139, 46);
            this.buttonProduct.TabIndex = 0;
            this.buttonProduct.Text = "Запрос 1";
            this.buttonProduct.UseVisualStyleBackColor = true;
            this.buttonProduct.Click += new System.EventHandler(this.buttonProduct_Click);
            // 
            // buttonDateExpense
            // 
            this.buttonDateExpense.Location = new System.Drawing.Point(375, 10);
            this.buttonDateExpense.Name = "buttonDateExpense";
            this.buttonDateExpense.Size = new System.Drawing.Size(139, 46);
            this.buttonDateExpense.TabIndex = 1;
            this.buttonDateExpense.Text = "Запрос 2";
            this.buttonDateExpense.UseVisualStyleBackColor = true;
            this.buttonDateExpense.Click += new System.EventHandler(this.buttonDateExpense_Click);
            // 
            // buttonDateReceipt
            // 
            this.buttonDateReceipt.Location = new System.Drawing.Point(756, 10);
            this.buttonDateReceipt.Name = "buttonDateReceipt";
            this.buttonDateReceipt.Size = new System.Drawing.Size(134, 47);
            this.buttonDateReceipt.TabIndex = 2;
            this.buttonDateReceipt.Text = "Запрос 3";
            this.buttonDateReceipt.UseVisualStyleBackColor = true;
            this.buttonDateReceipt.Click += new System.EventHandler(this.buttonDateReceipt_Click);
            // 
            // dataGridView
            // 
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.Location = new System.Drawing.Point(6, 66);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.RowHeadersWidth = 51;
            this.dataGridView.RowTemplate.Height = 24;
            this.dataGridView.Size = new System.Drawing.Size(884, 372);
            this.dataGridView.TabIndex = 11;
            // 
            // FormQuery
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(902, 448);
            this.Controls.Add(this.dataGridView);
            this.Controls.Add(this.buttonDateReceipt);
            this.Controls.Add(this.buttonDateExpense);
            this.Controls.Add(this.buttonProduct);
            this.Name = "FormQuery";
            this.Text = "FormQuery2";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonProduct;
        private System.Windows.Forms.Button buttonDateExpense;
        private System.Windows.Forms.Button buttonDateReceipt;
        private System.Windows.Forms.DataGridView dataGridView;
    }
}