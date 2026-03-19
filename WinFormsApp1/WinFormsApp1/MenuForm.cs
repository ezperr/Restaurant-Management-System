using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsApp1
{
    public partial class MenuForm : Form
    {
        database db = new database();

        public MenuForm()
        {
            InitializeComponent();
            LoadMenu();
        }
        private void LoadMenu()
        {
            string sql = "SELECT idmenu AS 'ID', name AS 'Название', price AS 'Цена', description AS 'Описание' FROM menu ORDER BY name";
            DataTable dt = db.ExecuteQuery(sql);
            if (dt != null)
                dataGridViewMenu.DataSource = dt;
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            LoadMenu();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            string name = Microsoft.VisualBasic.Interaction.InputBox("Введите название блюда:", "Добавление блюда");
            if (string.IsNullOrWhiteSpace(name)) return;

            string priceStr = Microsoft.VisualBasic.Interaction.InputBox("Введите цену:", "Добавление блюда");
            if (!decimal.TryParse(priceStr, out decimal price) || price <= 0)
            {
                MessageBox.Show("Некорректная цена!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string description = Microsoft.VisualBasic.Interaction.InputBox("Введите описание (можно оставить пустым):", "Добавление блюда");

            string sql;
            if (string.IsNullOrWhiteSpace(description))
                sql = $"INSERT INTO menu (name, price) VALUES ('{name}', {price.ToString(System.Globalization.CultureInfo.InvariantCulture)})";
            else
                sql = $"INSERT INTO menu (name, price, description) VALUES ('{name}', {price.ToString(System.Globalization.CultureInfo.InvariantCulture)}, '{description}')";

            int result = db.ExecuteNonQuery(sql);
            if (result > 0)
            {
                MessageBox.Show("Блюдо добавлено!", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadMenu(); // обновляем список
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dataGridViewMenu.SelectedRows.Count == 0)
            {
                MessageBox.Show("Выберите блюдо для удаления!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int id = Convert.ToInt32(dataGridViewMenu.SelectedRows[0].Cells["ID"].Value);
            string name = dataGridViewMenu.SelectedRows[0].Cells["Название"].Value.ToString();

            DialogResult dr = MessageBox.Show($"Удалить блюдо «{name}»?", "Подтверждение",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                string sql = $"DELETE FROM menu WHERE idmenu = {id}";
                int result = db.ExecuteNonQuery(sql);
                if (result > 0)
                {
                    MessageBox.Show("Блюдо удалено!", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadMenu();
                }
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dataGridViewMenu.SelectedRows.Count == 0)
            {
                MessageBox.Show("Выберите блюдо для изменения!", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int id = Convert.ToInt32(dataGridViewMenu.SelectedRows[0].Cells["ID"].Value);
            string currentName = dataGridViewMenu.SelectedRows[0].Cells["Название"].Value.ToString();
            decimal currentPrice = Convert.ToDecimal(dataGridViewMenu.SelectedRows[0].Cells["Цена"].Value);
            string currentDescription = dataGridViewMenu.SelectedRows[0].Cells["Описание"].Value?.ToString() ?? "";

            string newName = Microsoft.VisualBasic.Interaction.InputBox(
                "Введите новое название блюда:",
                "Изменение блюда",
                currentName);
            if (string.IsNullOrWhiteSpace(newName)) return;

            string priceStr = Microsoft.VisualBasic.Interaction.InputBox(
                "Введите новую цену:",
                "Изменение блюда",
                currentPrice.ToString("F2")); 
            if (!decimal.TryParse(priceStr, out decimal newPrice) || newPrice <= 0)
            {
                MessageBox.Show("Некорректная цена!", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string newDescription = Microsoft.VisualBasic.Interaction.InputBox(
                "Введите новое описание (можно оставить пустым):",
                "Изменение блюда",
                currentDescription);

            string sql;
            if (string.IsNullOrWhiteSpace(newDescription))
            {
                sql = $"UPDATE menu SET name = '{newName}', price = {newPrice.ToString(System.Globalization.CultureInfo.InvariantCulture)} WHERE idmenu = {id}";
            }
            else
            {
                sql = $"UPDATE menu SET name = '{newName}', price = {newPrice.ToString(System.Globalization.CultureInfo.InvariantCulture)}, description = '{newDescription}' WHERE idmenu = {id}";
            }

            int result = db.ExecuteNonQuery(sql);

            if (result > 0)
            {
                MessageBox.Show("Блюдо успешно изменено!", "Успех",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadMenu(); 
            }
        }
    }
}
