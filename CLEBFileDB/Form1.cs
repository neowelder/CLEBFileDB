using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace CLEBFileDB
{
    public partial class Form1 : Form
    {
        public static DataGridView data1;
        public static void load() {
            data1.Columns.Clear();
            data1.Rows.Clear();
            Persons.initialize();
            StreamReader reader = new StreamReader("elements.csv");
            String r = reader.ReadLine();
            int cnt = 0;
            while (r != null)
            {
                if (r != null)
                {
                    String[] tokens = r.Split(',');
                    if (tokens.Length == 5)
                    {
                        Person p = new Person();
                        p.name = tokens[0];
                        p.lastname = tokens[1];
                        p.address = tokens[2];
                        p.phone = tokens[3];
                        p.mail = tokens[4];
                        Persons.person.Add(p);
                    }
                }
                r = reader.ReadLine();
                cnt++;
            }
            reader.Close();
            if (cnt == 0)
            {
                MessageBox.Show("No hay elementos agregados al archivo \"elements.csv\"!");
            }
            else
            {
                data1.Columns.Add("Nombre", "Nombre");
                data1.Columns.Add("Apellido", "Apellido");
                data1.Columns.Add("Direccion", "Direccion");
                data1.Columns.Add("Telefono", "Telefono");
                data1.Columns.Add("Email", "Email");
                foreach (Person px in Persons.person)
                {
                    data1.Rows.Add(px.name, px.lastname, px.address, px.phone, px.mail);
                }
            }

        
        }
        public Form1()
        {

            data1 = dataGridView1;
            Persons.initialize();
            InitializeComponent();
            if (!File.Exists("elements.csv"))
            {
                MessageBox.Show("No hay elementos agregados al archivo \"elements.csv\"!");
            }
            else {
                data1 = dataGridView1;
                load();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Element el = new Element();
            el.ShowDialog();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            EditElement.xname = data1.Rows[e.RowIndex].Cells[0].Value.ToString();
            EditElement.xlastname = data1.Rows[e.RowIndex].Cells[1].Value.ToString();
            EditElement.xaddress = data1.Rows[e.RowIndex].Cells[2].Value.ToString();
            EditElement.xphone = data1.Rows[e.RowIndex].Cells[3].Value.ToString();
            EditElement.xmail = data1.Rows[e.RowIndex].Cells[4].Value.ToString();
            EditElement el = new EditElement();
            el.ShowDialog();
        }
    }
}
