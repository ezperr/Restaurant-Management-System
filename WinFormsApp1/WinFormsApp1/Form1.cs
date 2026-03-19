using System.Windows.Forms;

namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnTables_Click(object sender, EventArgs e)
        {
            TableForm form = new TableForm();
            form.Show();
        }

        private void btnMenu_Click(object sender, EventArgs e)
        {
            MenuForm form = new MenuForm();
            form.Show();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnOrders_Click(object sender, EventArgs e)
        {
            OrdersForm form = new OrdersForm();
            form.Show();
        }
    }
}
