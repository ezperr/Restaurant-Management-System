using System;
using System.Data;
using System.Windows.Forms;

namespace WinFormsApp1
{
    public partial class OrdersForm : Form
    {
        database db = new database();

        // Переменная для хранения ID выбранного заказа
        private int currentOrderId = 0;

        public OrdersForm()
        {
            InitializeComponent();
            LoadTables();
            LoadMenu();
            LoadOrders();   
        }

        // только  свободные столы
        private void LoadTables()
        {
            string sql = "SELECT idtables, number FROM tables WHERE status = 'Свободен' ORDER BY number";
            DataTable dt = db.ExecuteQuery(sql);
            if (dt != null)
            {
                cmbTables.DisplayMember = "number";
                cmbTables.ValueMember = "idtables";
                cmbTables.DataSource = dt;
            }
        }

        private void LoadMenu()
        {
            string sql = "SELECT idmenu, name, price FROM menu ORDER BY name";
            DataTable dt = db.ExecuteQuery(sql);
            if (dt != null)
            {
                cmbMenu.DisplayMember = "name";
                cmbMenu.ValueMember = "idmenu";
                cmbMenu.DataSource = dt;
            }
        }

        private void LoadOrders()
        {
            string sql = @"
                SELECT 
                    o.idorders AS 'ID',
                    o.table_id AS 'TableID',  
                    t.number AS 'Столик',
                    o.status AS 'Статус',
                    o.total AS 'Сумма',
                    o.created_at AS 'Дата'
                FROM orders o
                LEFT JOIN tables t ON o.table_id = t.idtables
                ORDER BY o.created_at DESC";
            DataTable dt = db.ExecuteQuery(sql);
            if (dt != null)
            {
                dgvOrders.DataSource = dt;
                if (dgvOrders.Columns["ID"] != null)
                    dgvOrders.Columns["ID"].Visible = false;
                if (dgvOrders.Columns["TableID"] != null)
                    dgvOrders.Columns["TableID"].Visible = false;
            }
        }

        private void LoadOrderItems(int orderId)
        {
            string sql = @"
                SELECT 
                    oi.idorder_items AS 'ID',
                    m.name AS 'Блюдо',
                    oi.quantity AS 'Количество',
                    m.price AS 'Цена',
                    (oi.quantity * m.price) AS 'Стоимость'
                FROM order_items oi
                JOIN menu m ON oi.menu_id = m.idmenu
                WHERE oi.order_id = " + orderId;
            DataTable dt = db.ExecuteQuery(sql);
            if (dt != null)
            {
                dgvItems.DataSource = dt;
                if (dgvItems.Columns["ID"] != null)
                    dgvItems.Columns["ID"].Visible = false;

                decimal total = 0;
                foreach (DataRow row in dt.Rows)
                    total += Convert.ToDecimal(row["Стоимость"]);
                lblTotal.Text = "Сумма: " + total.ToString("F2") + " руб.";
            }
        }

        private void RecalculateOrderTotal(int orderId)
        {
            string sql = @"
                SELECT SUM(oi.quantity * m.price) AS total
                FROM order_items oi
                JOIN menu m ON oi.menu_id = m.idmenu
                WHERE oi.order_id = " + orderId;
            DataTable dt = db.ExecuteQuery(sql);
            if (dt != null && dt.Rows.Count > 0 && dt.Rows[0]["total"] != DBNull.Value)
            {
                decimal total = Convert.ToDecimal(dt.Rows[0]["total"]);
                string updateSql = $"UPDATE orders SET total = {total.ToString(System.Globalization.CultureInfo.InvariantCulture)} WHERE idorders = {orderId}";
                db.ExecuteNonQuery(updateSql);
            }
        }


        private void btnRefreshOrders_Click(object sender, EventArgs e)
        {
            LoadOrders();
            // Очистить детали
            dgvItems.DataSource = null;
            lblTotal.Text = "Сумма: 0 руб.";
            currentOrderId = 0;
        }

        private void dgvOrders_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvOrders.SelectedRows.Count > 0)
            {
                DataGridViewRow row = dgvOrders.SelectedRows[0];
                currentOrderId = Convert.ToInt32(row.Cells["ID"].Value);
                LoadOrderItems(currentOrderId);
            }
        }

        private void btnCreateOrder_Click(object sender, EventArgs e)
        {
            if (cmbTables.SelectedValue == null)
            {
                MessageBox.Show("Выберите столик!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int tableId = (int)cmbTables.SelectedValue;

            string sql = $"INSERT INTO orders (table_id, status, total) VALUES ({tableId}, 'Новый', 0)";
            int result = db.ExecuteNonQuery(sql);
            if (result > 0)
            {
                //  обновление статуса у стола
                string updateTableSql = $"UPDATE tables SET status = 'Занят' WHERE idtables = {tableId}";
                db.ExecuteNonQuery(updateTableSql);
                MessageBox.Show("Заказ создан!", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadOrders();
                LoadTables();
            }
        }

        private void btnAddItem_Click(object sender, EventArgs e)
        {
            if (currentOrderId == 0)
            {
                MessageBox.Show("Сначала выберите заказ в списке!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (cmbMenu.SelectedValue == null)
            {
                MessageBox.Show("Выберите блюдо!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!int.TryParse(txtQuantity.Text, out int quantity) || quantity <= 0)
            {
                MessageBox.Show("Введите корректное количество!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int menuId = (int)cmbMenu.SelectedValue;

            string sql = $"INSERT INTO order_items (order_id, menu_id, quantity) VALUES ({currentOrderId}, {menuId}, {quantity})";
            int result = db.ExecuteNonQuery(sql);
            if (result > 0)
            {
                RecalculateOrderTotal(currentOrderId);
                LoadOrderItems(currentOrderId);
                LoadOrders();
                MessageBox.Show("Позиция добавлена!", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnChangeStatus_Click(object sender, EventArgs e)
        {
            if (currentOrderId == 0)
            {
                MessageBox.Show("Выберите заказ!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string newStatus = Microsoft.VisualBasic.Interaction.InputBox(
                "Введите новый статус (Новый, Готовится, Готов, Подан, Оплачен):",
                "Изменение статуса",
                "Новый");
            if (string.IsNullOrWhiteSpace(newStatus)) return;

            if (newStatus != "Новый" && newStatus != "Готовится" && newStatus != "Готов" && newStatus != "Подан" && newStatus != "Оплачен")
            {
                MessageBox.Show("Недопустимый статус!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string sql = $"UPDATE orders SET status = '{newStatus}' WHERE idorders = {currentOrderId}";
            int result = db.ExecuteNonQuery(sql);
            if (result > 0)
            {
                MessageBox.Show("Статус обновлён!", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadOrders(); 
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void btnDeleteOrder_Click(object sender, EventArgs e)
        {
            if (currentOrderId == 0)
            {
                MessageBox.Show("Выберите заказ для удаления!", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            int tableId = Convert.ToInt32(dgvOrders.SelectedRows[0].Cells["TableID"].Value);
            string tableNumber = dgvOrders.SelectedRows[0].Cells["Столик"].Value.ToString();

            DialogResult dr = MessageBox.Show(
                $"Удалить заказ для столика {tableNumber}?\nВсе позиции заказа также будут удалены!",
                "Подтверждение удаления",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (dr == DialogResult.Yes)
            {
                string sql = $"DELETE FROM orders WHERE idorders = {currentOrderId}";
                int result = db.ExecuteNonQuery(sql);

                if (result > 0)
                {
                    string freeTableSql = $"UPDATE tables SET status = 'Свободен' WHERE idtables = {tableId}";
                    db.ExecuteNonQuery(freeTableSql);
                    MessageBox.Show("Заказ удалён!", "Успех",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    currentOrderId = 0;
                    dgvItems.DataSource = null;
                    lblTotal.Text = "Сумма: 0 руб.";
                    LoadOrders();
                    LoadTables();
                }
            }
        }

        private void cmbTables_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}