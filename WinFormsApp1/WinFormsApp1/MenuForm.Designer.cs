namespace WinFormsApp1
{
    partial class MenuForm
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
            dataGridViewMenu = new DataGridView();
            btnLoad = new Button();
            btnAdd = new Button();
            btnDelete = new Button();
            btnEdit = new Button();
            btnBack = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridViewMenu).BeginInit();
            SuspendLayout();
            // 
            // dataGridViewMenu
            // 
            dataGridViewMenu.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewMenu.Location = new Point(29, 26);
            dataGridViewMenu.Name = "dataGridViewMenu";
            dataGridViewMenu.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewMenu.Size = new Size(447, 400);
            dataGridViewMenu.TabIndex = 1;
            // 
            // btnLoad
            // 
            btnLoad.Location = new Point(618, 51);
            btnLoad.Name = "btnLoad";
            btnLoad.Size = new Size(75, 23);
            btnLoad.TabIndex = 2;
            btnLoad.Text = "Загрузить";
            btnLoad.UseVisualStyleBackColor = true;
            btnLoad.Click += btnLoad_Click;
            // 
            // btnAdd
            // 
            btnAdd.Location = new Point(618, 97);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(75, 23);
            btnAdd.TabIndex = 3;
            btnAdd.Text = "Добавить";
            btnAdd.UseVisualStyleBackColor = true;
            btnAdd.Click += btnAdd_Click;
            // 
            // btnDelete
            // 
            btnDelete.Location = new Point(618, 142);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(75, 23);
            btnDelete.TabIndex = 4;
            btnDelete.Text = "Удалить";
            btnDelete.UseVisualStyleBackColor = true;
            btnDelete.Click += btnDelete_Click;
            // 
            // btnEdit
            // 
            btnEdit.Location = new Point(618, 188);
            btnEdit.Name = "btnEdit";
            btnEdit.Size = new Size(75, 23);
            btnEdit.TabIndex = 5;
            btnEdit.Text = "Изменить";
            btnEdit.UseVisualStyleBackColor = true;
            btnEdit.Click += btnEdit_Click;
            // 
            // btnBack
            // 
            btnBack.Location = new Point(618, 235);
            btnBack.Name = "btnBack";
            btnBack.Size = new Size(75, 23);
            btnBack.TabIndex = 6;
            btnBack.Text = "Назад";
            btnBack.UseVisualStyleBackColor = true;
            btnBack.Click += btnBack_Click;
            // 
            // MenuForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnBack);
            Controls.Add(btnEdit);
            Controls.Add(btnDelete);
            Controls.Add(btnAdd);
            Controls.Add(btnLoad);
            Controls.Add(dataGridViewMenu);
            Name = "MenuForm";
            Text = "Меню";
            ((System.ComponentModel.ISupportInitialize)dataGridViewMenu).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dataGridViewMenu;
        private Button btnLoad;
        private Button btnAdd;
        private Button btnDelete;
        private Button btnEdit;
        private Button btnBack;
    }
}