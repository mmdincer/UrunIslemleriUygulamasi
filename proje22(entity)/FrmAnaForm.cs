using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace proje22_entity_
{
    public partial class FrmAnaForm : Form
    {
        public FrmAnaForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 fr = new Form1();
            fr.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FrmUrun frmUrun = new FrmUrun();
            frmUrun.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            FrmIstatistik frm = new FrmIstatistik();   
            frm.Show();
        }
    }
}
