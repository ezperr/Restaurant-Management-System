namespace WinFormsApp1
{
    partial class OrdersForm
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
            dgvOrders = new DataGridView();
            btnRefreshOrders = new Button();
            dgvItems = new DataGridView();
            lblTotal = new Label();
            btnChangeStatus = new Button();
            label1 = new Label();
            cmbTables = new ComboBox();
            btnCreateOrder = new Button();
            label2 = new Label();
            cmbMenu = new ComboBox();
            label3 = new Label();
            txtQuantity = new TextBox();
            btnAddItem = new Button();
            btnBack = new Button();
            btnDeleteOrder = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvOrders).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvItems).BeginInit();
            SuspendLayout();
            // 
            // dgvOrders
            // 
            dgvOrders.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvOrders.Location = new Point(12, 12);
            dgvOrders.MultiSelect = false;
            dgvOrders.Name = "dgvOrders";
            dgvOrders.ReadOnly = true;
            dgvOrders.RowHeadersVisible = false;
            dgvOrders.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvOrders.Size = new Size(414, 210);
            dgvOrders.TabIndex = 0;
            dgvOrders.SelectionChanged += dgvOrders_SelectionChanged;
            // 
            // btnRefreshOrders
            // 
            btnRefreshOrders.Location = new Point(459, 50);
            btnRefreshOrders.Name = "btnRefreshOrders";
            btnRefreshOrders.Size = new Size(105, 43);
            btnRefreshOrders.TabIndex = 1;
            btnRefreshOrders.Text = "Обновить заказы";
            btnRefreshOrders.UseVisualStyleBackColor = true;
            btnRefreshOrders.Click += btnRefreshOrders_Click;
            // 
            // dgvItems
            // 
            dgvItems.AllowUserToAddRows = false;
            dgvItems.AllowUserToDeleteRows = false;
            dgvItems.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvItems.Location = new Point(12, 241);
            dgvItems.MultiSelect = false;
            dgvItems.Name = "dgvItems";
            dgvItems.ReadOnly = true;
            dgvItems.RowHeadersVisible = false;
            dgvItems.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvItems.Size = new Size(414, 197);
            dgvItems.TabIndex = 2;
            // 
            // lblTotal
            // 
            lblTotal.AutoSize = true;
            lblTotal.Font = new Font("Segoe UI", 20.25F, FontStyle.Bold, GraphicsUnit.Point, 204);
            lblTotal.Location = new Point(432, 401);
            lblTotal.Name = "lblTotal";
            lblTotal.Size = new Size(191, 37);
            lblTotal.TabIndex = 3;
            lblTotal.Text = "Сумма: 0 руб";
            // 
            // btnChangeStatus
            // 
            btnChangeStatus.Location = new Point(459, 132);
            btnChangeStatus.Name = "btnChangeStatus";
            btnChangeStatus.Size = new Size(105, 43);
            btnChangeStatus.TabIndex = 4;
            btnChangeStatus.Text = "Изменить статус";
            btnChangeStatus.UseVisualStyleBackColor = true;
            btnChangeStatus.Click += btnChangeStatus_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 204);
            label1.Location = new Point(621, 26);
            label1.Name = "label1";
            label1.Size = new Size(50, 21);
            label1.TabIndex = 5;
            label1.Text = "Стол:";
            label1.Click += label1_Click;
            // 
            // cmbTables
            // 
            cmbTables.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbTables.FormattingEnabled = true;
            cmbTables.Location = new Point(667, 26);
            cmbTables.Name = "cmbTables";
            cmbTables.Size = new Size(59, 23);
            cmbTables.TabIndex = 6;
            cmbTables.SelectedIndexChanged += cmbTables_SelectedIndexChanged;
            // 
            // btnCreateOrder
            // 
            btnCreateOrder.BackColor = Color.FromArgb(192, 255, 192);
            btnCreateOrder.Location = new Point(621, 50);
            btnCreateOrder.Name = "btnCreateOrder";
            btnCreateOrder.Size = new Size(105, 43);
            btnCreateOrder.TabIndex = 7;
            btnCreateOrder.Text = "Создать заказ";
            btnCreateOrder.UseVisualStyleBackColor = false;
            btnCreateOrder.Click += btnCreateOrder_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 204);
            label2.Location = new Point(427, 321);
            label2.Name = "label2";
            label2.Size = new Size(64, 21);
            label2.TabIndex = 8;
            label2.Text = "Блюда:";
            label2.Click += label2_Click;
            // 
            // cmbMenu
            // 
            cmbMenu.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbMenu.FormattingEnabled = true;
            cmbMenu.Location = new Point(501, 319);
            cmbMenu.Name = "cmbMenu";
            cmbMenu.Size = new Size(121, 23);
            cmbMenu.TabIndex = 9;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 204);
            label3.Location = new Point(427, 350);
            label3.Name = "label3";
            label3.Size = new Size(68, 21);
            label3.TabIndex = 10;
            label3.Text = "Кол-во:";
            label3.Click += label3_Click;
            // 
            // txtQuantity
            // 
            txtQuantity.Location = new Point(501, 348);
            txtQuantity.Name = "txtQuantity";
            txtQuantity.Size = new Size(121, 23);
            txtQuantity.TabIndex = 11;
            txtQuantity.Text = "1";
            // 
            // btnAddItem
            // 
            btnAddItem.Location = new Point(651, 303);
            btnAddItem.Name = "btnAddItem";
            btnAddItem.Size = new Size(69, 52);
            btnAddItem.TabIndex = 12;
            btnAddItem.Text = "Добавить позицию";
            btnAddItem.UseVisualStyleBackColor = true;
            btnAddItem.Click += btnAddItem_Click;
            // 
            // btnBack
            // 
            btnBack.Location = new Point(713, 415);
            btnBack.Name = "btnBack";
            btnBack.Size = new Size(75, 23);
            btnBack.TabIndex = 13;
            btnBack.Text = "Назад";
            btnBack.UseVisualStyleBackColor = true;
            btnBack.Click += btnBack_Click;
            // 
            // btnDeleteOrder
            // 
            btnDeleteOrder.BackColor = Color.FromArgb(255, 192, 192);
            btnDeleteOrder.Location = new Point(621, 132);
            btnDeleteOrder.Name = "btnDeleteOrder";
            btnDeleteOrder.Size = new Size(105, 43);
            btnDeleteOrder.TabIndex = 14;
            btnDeleteOrder.Text = "Удалить заказ";
            btnDeleteOrder.UseVisualStyleBackColor = false;
            btnDeleteOrder.Click += btnDeleteOrder_Click;
            // 
            // OrdersForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnDeleteOrder);
            Controls.Add(btnBack);
            Controls.Add(btnAddItem);
            Controls.Add(txtQuantity);
            Controls.Add(label3);
            Controls.Add(cmbMenu);
            Controls.Add(label2);
            Controls.Add(btnCreateOrder);
            Controls.Add(cmbTables);
            Controls.Add(label1);
            Controls.Add(btnChangeStatus);
            Controls.Add(lblTotal);
            Controls.Add(dgvItems);
            Controls.Add(btnRefreshOrders);
            Controls.Add(dgvOrders);
            Name = "OrdersForm";
            Text = "Заказы";
            ((System.ComponentModel.ISupportInitialize)dgvOrders).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvItems).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dgvOrders;
        private Button btnRefreshOrders;
        private DataGridView dgvItems;
        private Label lblTotal;
        private Button btnChangeStatus;
        private Label label1;
        private ComboBox cmbTables;
        private Button btnCreateOrder;
        private Label label2;
        private ComboBox cmbMenu;
        private Label label3;
        private TextBox txtQuantity;
        private Button btnAddItem;
        private Button btnBack;
        private Button btnDeleteOrder;
    }
}