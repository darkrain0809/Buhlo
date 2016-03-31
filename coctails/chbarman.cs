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
    public partial class chbarman : Form
    {
        //List<DataGridViewRow> dataRow = new List<DataGridViewRow>();
        //public chbarman(List<DataGridViewRow> dataRow)
        //{
        //    InitializeComponent();
        //    //this.dataGridView1.DataSource = Order.ord.DataSource;
        //    // http://www.cyberforum.ru/windows-forms/thread1362615.html таймер
        //    this.dataRow = dataRow; 
        //    foreach (DataGridViewRow row in dataRow)
        //    {
        //        dataGridView1.Rows.Add(row.Clone());
        //    }

        //}
        DataGridView dgv = new DataGridView();
        public chbarman(DataGridView dgv)
        {
            InitializeComponent();
            //this.dataGridView1.DataSource = Order.ord.DataSource;
            // http://www.cyberforum.ru/windows-forms/thread1362615.html таймер
            this.dgv = dgv;
            foreach (DataGridViewRow row in dgv.Rows)
            {
                dataGridView1.Rows.Add(
                    row.Cells[0].Value,
                    row.Cells[1].Value,
                    row.Cells[2].Value
                    );
            }


        }
        public chbarman()
        {
            InitializeComponent();

            //this.dataGridView1.DataSource = Order.ord.DataSource;
            // http://www.cyberforum.ru/windows-forms/thread1362615.html таймер
        }



        private void button1_Click(object sender, EventArgs e)
        {
            barman b1 = new barman();
            b1.ShowDialog();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void chbarman_Shown(object sender, EventArgs e)
        {

        }
    }
}
