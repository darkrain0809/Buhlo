using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace coctails
{
    public partial class warehouseman : Form
    {
        public static int id1 = 0, id2=0, numdel=0;
        public static String qdel = "";
        public warehouseman()
        {
            InitializeComponent();
            dataGridView2.DataSource = DB.Query("select * from products order by idproducts;");
            dataGridView1.DataSource = DB.Query("select * from `tare` order by idtare;");
            id1 = dataGridView2.RowCount;
            id2 = dataGridView1.RowCount;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (numdel!=0)
            DB.Query1(qdel);
            int i = 1;
            DataTable changes = ((DataTable)dataGridView2.DataSource).GetChanges();

            foreach (DataGridViewRow r in dataGridView2.Rows)
            {
                i++;
                if (i <= id1)
                {
                    if (changes != null)
                    {
                        DB.Query1("update products set name='" + r.Cells["name"].Value + "', price='" + r.Cells["price"].Value + "', type='" + r.Cells["type"].Value + "', amount='" + r.Cells["amount"].Value + "', atype='" + r.Cells["atype"].Value + "' where idproducts='" + r.Cells["idproducts"].Value + "';");
                    }
                }
                else
                {
                    if (changes != null)
                    {
                        DB.Query1("INSERT INTO `products` (`idproducts`, `name`, `price`, `type`, `amount`, `atype`) VALUES ('"+r.Cells["idproducts"].Value+"', '"+r.Cells["name"].Value+"', '"+r.Cells["price"].Value+"', '"+r.Cells["type"].Value+"', '"+r.Cells["amount"].Value+"', '"+r.Cells["atype"].Value+"');");
                    }
                }
            }
            
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView2_AllowUserToDeleteRowsChanged(object sender, EventArgs e)//не то
        {
            numdel++;
            DataRow row = (dataGridView1.SelectedRows[0].DataBoundItem as DataRowView).Row;
            qdel += "DELETE FROM `products` WHERE `idproducts`='"+row["idproducts"]+"'; ";
        }

        private void button5_Click(object sender, EventArgs e)
        {
            dataGridView2.DataSource = DB.Query("select * from `products` order by idproducts;");
            dataGridView1.DataSource = DB.Query("select * from `tare`;");
            id1 = dataGridView2.RowCount;
            id2 = dataGridView1.RowCount;
            numdel = 0;
        }

        private void dataGridView2_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
                numdel++;
                int id = e.RowIndex;
                //DataRow row = (dataGridView1.SelectedRows[0].DataBoundItem as DataRowView).Row;
                qdel += "DELETE FROM `products` WHERE `idproducts`='" + id + "'; ";
        }
    }
}
