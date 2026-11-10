using dgv.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace dgv
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        BcAnmContext database = new BcAnmContext();

        private void Form2_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = database.Employees.Select(a => new
            {
                員工名稱 = a.Account.FirstName + a.Account.LastName,
                建立時間 = a.CreateDateTime,
               
            }).ToList();
            dataGridView2.DataSource = database.Machines.Select(a => new
            {
                機器名稱 = a.Name,
                建立時間 = a.MachineCreateDateTime,
                狀態 = a.Status



            }).ToList();
        }
    }
}
