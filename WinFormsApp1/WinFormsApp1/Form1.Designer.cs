namespace WinFormsApp1
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            btnTables = new Button();
            btnMenu = new Button();
            btnOrders = new Button();
            btnExit = new Button();
            SuspendLayout();
            // 
            // btnTables
            // 
            btnTables.Font = new Font("Microsoft Sans Serif", 20.25F, FontStyle.Regular, GraphicsUnit.Point, 204);
            btnTables.Location = new Point(380, 101);
            btnTables.Name = "btnTables";
            btnTables.Size = new Size(154, 58);
            btnTables.TabIndex = 0;
            btnTables.Text = "Столы\r\n";
            btnTables.UseVisualStyleBackColor = true;
            btnTables.Click += btnTables_Click;
            // 
            // btnMenu
            // 
            btnMenu.Font = new Font("Segoe UI", 20.25F, FontStyle.Regular, GraphicsUnit.Point, 204);
            btnMenu.Location = new Point(380, 184);
            btnMenu.Name = "btnMenu";
            btnMenu.Size = new Size(154, 58);
            btnMenu.TabIndex = 1;
            btnMenu.Text = "Меню";
            btnMenu.UseVisualStyleBackColor = true;
            btnMenu.Click += btnMenu_Click;
            // 
            // btnOrders
            // 
            btnOrders.Font = new Font("Segoe UI Semibold", 24F, FontStyle.Bold, GraphicsUnit.Point, 204);
            btnOrders.Location = new Point(88, 101);
            btnOrders.Name = "btnOrders";
            btnOrders.Size = new Size(227, 141);
            btnOrders.TabIndex = 2;
            btnOrders.Text = "Заказы";
            btnOrders.UseVisualStyleBackColor = true;
            btnOrders.Click += btnOrders_Click;
            // 
            // btnExit
            // 
            btnExit.Location = new Point(713, 415);
            btnExit.Name = "btnExit";
            btnExit.Size = new Size(75, 23);
            btnExit.TabIndex = 3;
            btnExit.Text = "Выход";
            btnExit.UseVisualStyleBackColor = true;
            btnExit.Click += btnExit_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Control;
            ClientSize = new Size(800, 450);
            Controls.Add(btnExit);
            Controls.Add(btnOrders);
            Controls.Add(btnMenu);
            Controls.Add(btnTables);
            Name = "Form1";
            Text = "Главное меню";
            Load += Form1_Load;
            ResumeLayout(false);
        }

        #endregion

        private Button btnTables;
        private Button btnMenu;
        private Button btnOrders;
        private Button btnExit;
    }
}
