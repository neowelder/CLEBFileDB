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
    public partial class Element : Form
    {
        public Element()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(name.Text!=""&&lastname.Text!=""&&address.Text!=""&&phone.Text!=""&&mail.Text!=""){
                StreamWriter writer = File.AppendText("elements.csv");
                writer.WriteLine(name.Text+","+lastname.Text+","+address.Text+","+phone.Text+","+mail.Text);
                writer.Close();
                MessageBox.Show("Elemento agregado exitosamente !");
                name.Text = "";
                lastname.Text = "";
                address.Text = "";
                phone.Text = "";
                mail.Text = "";
                Form1.load();
            }
        }
    }
}
