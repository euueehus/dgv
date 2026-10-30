using dgv.Models;

namespace dgv
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        BcAnmContext database = new BcAnmContext();
        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            comboBox1.Items.Clear();
            comboBox1.Items.Add("正常");
            comboBox1.Items.Add("異常");
            dataGridView1.DataSource = database.Orders.Select(a => new
            {
                客戶名稱 = a.Buyer.Username,
                產品名稱 = a.Product.Name,
                產品售價 = a.Product.Price,
                服務費用 = a.ServiceCharge,
                訂單總價 = a.TotalAmount,
                建立時間 = a.CreateDateTime,
                訂單狀態 = a.Status == 1 ? "正常" : "異常",
                更動時間 = a.UpdateDateTime,

            }).ToList();

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void dateTimePicker3_ValueChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        //private void com
    }
}
