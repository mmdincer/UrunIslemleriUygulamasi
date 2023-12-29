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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        DBEntityUrunEntities db = new DBEntityUrunEntities();
        private void btnlistele_Click(object sender, EventArgs e)
        {
           dataGridView1.DataSource = db.tblkategori.ToList();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            tblkategori t = new tblkategori();
            t.ad = textBox2.Text;
            db.tblkategori.Add(t);
            db.SaveChanges();
            MessageBox.Show("Kategori eklendi.");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int x=Convert.ToInt32(textBox1.Text);
            var ktgr = db.tblkategori.Find(x);
            db.tblkategori.Remove(ktgr);
            db.SaveChanges();
            MessageBox.Show("Kategori silindi.");

        }

        private void button4_Click(object sender, EventArgs e)
        {
            int x = Convert.ToInt32(textBox1.Text);
            var ktgr = db.tblkategori.Find(x);
            ktgr.ad = textBox2.Text;
            db.SaveChanges();
            MessageBox.Show("Kategori güncellendi.");

        }
    }
}
