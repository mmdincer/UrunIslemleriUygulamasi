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
    public partial class FrmGiris : Form
    {
        public FrmGiris()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DBEntityUrunEntities db = new DBEntityUrunEntities();
            var sorgu = from x in db.tbladmin where x.kullanıcı == textBox1.Text && x.sifre == textBox2.Text select x;
            if (sorgu.Any())
            {
                FrmAnaForm form = new FrmAnaForm();
                form.Show();
                this.Hide();
            }
            else
                MessageBox.Show("Hatalı Giriş");
        }
    }
}
