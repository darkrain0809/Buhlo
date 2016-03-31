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

    public partial class barman : Form
    {
        public barman()
        {
            InitializeComponent();
            comboBox1.DataSource = DB.Query("select name from `cocktailrec` order by name;");
            comboBox1.DisplayMember = "name";
            dataGridView1.RowHeadersVisible = false;
            dataGridView1.DataSource = DB.Query("select distinct products.name, prodam from `products`, recipe, cocktailrec where recipe.productid = products.idproducts and coctailid = (select idcocktailrec from cocktailrec where cocktailrec.name='" + comboBox1.GetItemText(comboBox1.SelectedItem) + "');");
            DataTable dt = new DataTable();
            dt = DB.Query("select distinct tare.type, cocktailrec.price from tare, cocktailrec where (select idtare from cocktailrec where cocktailrec.name='" + comboBox1.GetItemText(comboBox1.SelectedItem) + "') = tare.idtare;");
            textBox1.Text = dt.Rows[0].ItemArray[0].ToString();
            textBox2.Text = dt.Rows[0].ItemArray[1].ToString();

            //listBox1.DataSource = DB.Query("select name from `products`;");
            //dataGridView1.DataSource = DB.Query("select * from `tare`;");

        }
        private void comboBox1_SelectedValueChanged(object sender, EventArgs e)
        {
            if (comboBox1.GetItemText(comboBox1.SelectedItem) != "System.Data.DataRowView")
            {
                dataGridView1.DataSource = DB.Query("select distinct products.name, prodam from `products`, recipe, cocktailrec where recipe.productid = products.idproducts and coctailid = (select idcocktailrec from cocktailrec where cocktailrec.name='" + comboBox1.GetItemText(comboBox1.SelectedItem) + "');");
                DataTable dt = new DataTable();
                dt = DB.Query("select distinct tare.type, cocktailrec.price from tare, cocktailrec where (select idtare from cocktailrec where cocktailrec.name='" + comboBox1.GetItemText(comboBox1.SelectedItem) + "') = tare.idtare;");
                textBox1.Text = dt.Rows[0].ItemArray[0].ToString();
                textBox2.Text = dt.Rows[0].ItemArray[1].ToString();               
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

    }
}
