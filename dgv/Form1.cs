using dgv.Models;
using Microsoft.IdentityModel.Tokens;

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
            var q = database.Orders.AsQueryable();


            string key = textBox1.Text.Trim();
            if (!string.IsNullOrEmpty(key))
            {
                q = q.Where(a =>
                    a.Buyer.Username.Contains(key) ||
                    a.Product.Name.Contains(key));
            }
            if (comboBox1.SelectedIndex > 0)
            {
                if (comboBox1.SelectedItem.ToString() == "正常")
                    q = q.Where(a => a.Status == 1);
                else
                    q = q.Where(a => a.Status != 1);
            }
            if (checkBox1.Checked)
            {
                q = q.Where(a => a.UpdateDateTime != null);
            }
            DateTime from = dateTimePicker1.Value.Date;
            DateTime to = dateTimePicker2.Value.Date.AddDays(1);
            q = q.Where(a => a.CreateDateTime >= from && a.CreateDateTime < to);



            dataGridView1.DataSource = q.Select(a => new
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

        private void Form1_Load(object sender, EventArgs e)
        {
            comboBox1.Items.Clear();
            comboBox1.Items.Add("全部");
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

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }
        //private void com
    }
}
