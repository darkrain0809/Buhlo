using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace coctails
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

        }

        List<DataGridViewRow> dataRow = new List<DataGridViewRow>();
        DataGridView dgv = new DataGridView();
        private void button1_Click(object sender, EventArgs e)
        {
            //user u1 = new user();
            //u1.ShowDialog();
            //if(u1.DialogResult == System.Windows.Forms.DialogResult.OK)
            //{
            //    dataRow.Clear();
            //    dataRow = u1.GetDataRow();
            //}
            user u1 = new user();
            u1.ShowDialog();
            if (u1.DialogResult == System.Windows.Forms.DialogResult.OK)
            {
                dataRow.Clear();
                dgv = u1.GetDataRow(dgv);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            chbarman cb1 = new chbarman(dgv);//открытие формы бармен
            cb1.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            warehouseman w1 = new warehouseman();
            w1.ShowDialog();
        }
    }
}
