using System;
using System.Data;
using System.Windows.Forms;

namespace WinFormsApp1
{
    public partial class TableForm : Form
    {
        database db = new database();

        public TableForm()
        {
            InitializeComponent();
            LoadTables();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void LoadTables()
        {
            string sql = "SELECT idtables AS 'ID', number AS 'Номер', seats AS 'Мест', status AS 'Статус' FROM tables ORDER BY number";
            DataTable dt = db.ExecuteQuery(sql);
            if (dt != null)
                dataGridView1.DataSource = dt;
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            LoadTables();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            string number = Microsoft.VisualBasic.Interaction.InputBox("Введите номер столика:", "Добавление столика");
            if (string.IsNullOrWhiteSpace(number)) return;
            string seatsStr = Microsoft.VisualBasic.Interaction.InputBox("Введите количество мест:", "Добавление столика");
            if (!int.TryParse(seatsStr, out int seats) || seats <= 0)
            {
                MessageBox.Show("Некорректное количество мест!");
                return;
            }
            string sql = $"INSERT INTO tables (number, seats, status) VALUES ('{number}', {seats}, 'Свободен')";
            int result = db.ExecuteNonQuery(sql);
            if (result > 0)
            {
                MessageBox.Show("Столик добавлен!");
                LoadTables();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Выберите столик для удаления!");
                return;
            }
            int id = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["ID"].Value);
            string number = dataGridView1.SelectedRows[0].Cells["Номер"].Value.ToString();

            DialogResult dr = MessageBox.Show($"Удалить столик №{number}?", "Подтверждение",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                string sql = $"DELETE FROM tables WHERE idtables = {id}";
                int result = db.ExecuteNonQuery(sql);
                if (result > 0)
                {
                    MessageBox.Show("Столик удалён!");
                    LoadTables();
                }
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Выберите столик для изменения!", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int id = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["ID"].Value);
            string currentNumber = dataGridView1.SelectedRows[0].Cells["Номер"].Value.ToString();
            int currentSeats = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["Мест"].Value);
            string currentStatus = dataGridView1.SelectedRows[0].Cells["Статус"].Value.ToString();

            string newNumber = Microsoft.VisualBasic.Interaction.InputBox(
                "Введите новый номер столика:",
                "Изменение столика",
                currentNumber);
            if (string.IsNullOrWhiteSpace(newNumber)) return;

            string seatsStr = Microsoft.VisualBasic.Interaction.InputBox(
                "Введите новое количество мест:",
                "Изменение столика",
                currentSeats.ToString());
            if (!int.TryParse(seatsStr, out int newSeats) || newSeats <= 0)
            {
                MessageBox.Show("Некорректное количество мест!", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string newStatus = Microsoft.VisualBasic.Interaction.InputBox(
                "Введите новый статус (Свободен, Занят, Забронирован):",
                "Изменение столика",
                currentStatus);
            if (string.IsNullOrWhiteSpace(newStatus)) return;

            if (newStatus != "Свободен" && newStatus != "Занят" && newStatus != "Забронирован")
            {
                MessageBox.Show("Статус должен быть: Свободен, Занят или Забронирован!",
                    "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // запрос на обновление
            string sql = $"UPDATE tables SET number = '{newNumber}', seats = {newSeats}, status = '{newStatus}' WHERE idtables = {id}";

            int result = db.ExecuteNonQuery(sql);

            if (result > 0)
            {
                MessageBox.Show("Столик успешно изменён!", "Успех",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadTables(); 
            }
        }
    }
}