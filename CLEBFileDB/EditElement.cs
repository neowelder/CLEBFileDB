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
    public partial class EditElement : Form
    {
        public static String xname;
        public static String xlastname;
        public static String xaddress;
        public static String xphone;
        public static String xmail;
        public EditElement()
        {
            InitializeComponent();
            if (xname != "" && xlastname != "" && xaddress != "" && xphone != "" && xmail!="") {
                name.Text = xname;
                lastname.Text = xlastname;
                address.Text = xaddress;
                phone.Text = xphone;
                mail.Text = xmail;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            // seccion de borrado
            if (name.Text != "" && lastname.Text != "" && address.Text != "" && phone.Text != "" && mail.Text != "") {
                StreamReader reader = new StreamReader("elements.cvs");
                StreamWriter writer = new StreamWriter("t.tmp");
                String r = reader.ReadLine();
                while (r != "") {
                    String[] tokens = r.Split(',');
                    if(tokens[0]!=name.Text && tokens[1]!=lastname.Text&&tokens[2]!=address.Text&& tokens[3]!=phone.Text && tokens[4]!=mail.Text){
                        writer.WriteLine(r);
                    }
                    r = reader.ReadLine();
                }
                writer.Close();
                reader.Close();

                File.Delete("elements.csv");
                File.Move("t.tmp", "elements.cvs");
                Form1.load();
                this.Close();
            
            }
        }
    }
}
