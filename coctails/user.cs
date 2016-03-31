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
    public partial class user : Form
    {
        static int i = 0;

        public user()
        {
            InitializeComponent();
            comboBox1.DataSource = DB.Query("select name from `cocktailrec`;");
            comboBox1.DisplayMember = "name";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //RowHeadersVisible = false - для того, чтобы убрать хедеры в датагрид
            DataTable dt = new DataTable();
            dt = DB.Query("select cocktailrec.price from cocktailrec where name = '" + comboBox1.GetItemText(comboBox1.SelectedItem) + "';");
            double pr = Convert.ToDouble(dt.Rows[0].ItemArray[0]);
            double num =Convert.ToDouble(textBox4.Text);
            //int n1 = Convert.ToInt32(dataGridView1.Rows[i].Cells[1].Value);
            num+=Convert.ToDouble(dt.Rows[0].ItemArray[0]);
            textBox4.Text = num.ToString();
            dataGridView1.Rows.Add();
            dataGridView1.Rows[i].Cells[0].Value = comboBox1.GetItemText(comboBox1.SelectedItem);
            dataGridView1.Rows[i].Cells[1].Value = 1;
            dataGridView1.Rows[i].Cells[2].Value = pr;
            i++;
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
        }

        private void button3_Click(object sender, EventArgs e)
        {
            /*int a=0;
            foreach (DataGridViewRow r in dataGridView1.Rows)
            {
                //dtb.Rows.Add(dataGridView1.Rows[a]);
                dtb.Rows.Add(r);
                a++;
            }
                Order.ord = dataGridView1;
            chbarman b1 = new chbarman();
            b1.ShowDialog();
            this.Visible = false;*/
            DialogResult = System.Windows.Forms.DialogResult.OK;
        }

        //public List<DataGridViewRow> GetDataRow()
        //{
        //    List<DataGridViewRow> dataRow = new List<DataGridViewRow>();
        //    foreach (DataGridViewRow row in dataGridView1.Rows)
        //    {
        //        dataRow.Add(row);
        //    }
        //    return dataRow;
        //}
        public DataGridView GetDataRow(DataGridView dgv)
        {
            dgv.Columns.Add("name", "name");
            dgv.Columns.Add("amount", "amount");
            dgv.Columns.Add("price", "price");
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                dgv.Rows.Add(
                    row.Cells[0].Value,
                    row.Cells[1].Value,
                    row.Cells[2].Value
                    );
            }
            i = 0;
            return dgv;
        }

        private void user_FormClosing(object sender, FormClosingEventArgs e)
        {
            i = 0;
        }

        private void user_Load(object sender, EventArgs e)
        {
        }
    }
}
