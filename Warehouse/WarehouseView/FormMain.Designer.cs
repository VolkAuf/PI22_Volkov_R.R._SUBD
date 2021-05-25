
namespace WarehouseView
{
    partial class FormMain
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
            this.buttonGroupps = new System.Windows.Forms.Button();
            this.buttonProducts = new System.Windows.Forms.Button();
            this.buttonExpenseStatements = new System.Windows.Forms.Button();
            this.buttonReceiptStatements = new System.Windows.Forms.Button();
            this.buttonQuery = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // buttonGroupps
            // 
            this.buttonGroupps.Location = new System.Drawing.Point(115, 13);
            this.buttonGroupps.Name = "buttonGroupps";
            this.buttonGroupps.Size = new System.Drawing.Size(83, 27);
            this.buttonGroupps.TabIndex = 1;
            this.buttonGroupps.Text = "Groupps";
            this.buttonGroupps.UseVisualStyleBackColor = true;
            this.buttonGroupps.Click += new System.EventHandler(this.buttonGroupps_Click);
            // 
            // buttonProducts
            // 
            this.buttonProducts.Location = new System.Drawing.Point(13, 13);
            this.buttonProducts.Name = "buttonProducts";
            this.buttonProducts.Size = new System.Drawing.Size(83, 26);
            this.buttonProducts.TabIndex = 2;
            this.buttonProducts.Text = "Products";
            this.buttonProducts.UseVisualStyleBackColor = true;
            this.buttonProducts.Click += new System.EventHandler(this.buttonProducts_Click);
            // 
            // buttonExpenseStatements
            // 
            this.buttonExpenseStatements.Location = new System.Drawing.Point(216, 12);
            this.buttonExpenseStatements.Name = "buttonExpenseStatements";
            this.buttonExpenseStatements.Size = new System.Drawing.Size(152, 28);
            this.buttonExpenseStatements.TabIndex = 3;
            this.buttonExpenseStatements.Text = "ExpenseStatements";
            this.buttonExpenseStatements.UseVisualStyleBackColor = true;
            this.buttonExpenseStatements.Click += new System.EventHandler(this.buttonExpenseStatements_Click);
            // 
            // buttonReceiptStatements
            // 
            this.buttonReceiptStatements.Location = new System.Drawing.Point(387, 11);
            this.buttonReceiptStatements.Name = "buttonReceiptStatements";
            this.buttonReceiptStatements.Size = new System.Drawing.Size(152, 28);
            this.buttonReceiptStatements.TabIndex = 4;
            this.buttonReceiptStatements.Text = "ReceiptStatements";
            this.buttonReceiptStatements.UseVisualStyleBackColor = true;
            this.buttonReceiptStatements.Click += new System.EventHandler(this.buttonReceiptStatements_Click);
            // 
            // buttonQuery
            // 
            this.buttonQuery.Location = new System.Drawing.Point(563, 11);
            this.buttonQuery.Name = "buttonQuery";
            this.buttonQuery.Size = new System.Drawing.Size(120, 28);
            this.buttonQuery.TabIndex = 5;
            this.buttonQuery.Text = "Query";
            this.buttonQuery.UseVisualStyleBackColor = true;
            this.buttonQuery.Click += new System.EventHandler(this.buttonQuery_Click);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.buttonQuery);
            this.Controls.Add(this.buttonReceiptStatements);
            this.Controls.Add(this.buttonExpenseStatements);
            this.Controls.Add(this.buttonProducts);
            this.Controls.Add(this.buttonGroupps);
            this.Name = "FormMain";
            this.Text = "FormMain";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonGroupps;
        private System.Windows.Forms.Button buttonProducts;
        private System.Windows.Forms.Button buttonExpenseStatements;
        private System.Windows.Forms.Button buttonReceiptStatements;
        private System.Windows.Forms.Button buttonQuery;
    }
}