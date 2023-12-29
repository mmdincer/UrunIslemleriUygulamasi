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
    public partial class FrmUrun : Form
    {
        public FrmUrun()
        {
            InitializeComponent();
        }

        DBEntityUrunEntities db = new DBEntityUrunEntities();
        private void btnlistele_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = (from x in db.tblurun
                                        select new
                                        {                                           
                                            x.urunid,
                                            x.urunad,
                                            x.marka,
                                            x.stok,
                                            x.fiyat,
                                            x.tblkategori.ad,
                                            x.durum
                                        }).ToList();
            ;
        }

        private void btnekle_Click(object sender, EventArgs e)
        {
            tblurun t = new tblurun();
            t.urunad = txtad.Text;
            t.marka = txtmarka.Text;
            t.stok = short.Parse(txtstok.Text);
            t.fiyat = decimal.Parse(txtfiyat.Text);
            t.durum = true;
            t.kategori = int.Parse(cmbkategori.Text);
            db.tblurun.Add(t);
            db.SaveChanges();
            MessageBox.Show("Ürün sisteme kaydedildi.");
        }

        private void btnsil_Click(object sender, EventArgs e)
        {
            int x = Convert.ToInt32(txtid.Text);
            var urun = db.tblurun.Find(x);
            db.tblurun.Remove(urun);
            db.SaveChanges();
            MessageBox.Show("Ürün silindi.");

        }

        private void btnguncelle_Click(object sender, EventArgs e)
        {
            int x = Convert.ToInt32(txtid.Text);
            var urun = db.tblurun.Find(x);
            urun.urunad = txtad.Text;
            urun.marka = txtmarka.Text;
            urun.stok = short.Parse(txtstok.Text);
            urun.fiyat = decimal.Parse(txtfiyat.Text);
            urun.durum = true;
            urun.kategori = int.Parse(cmbkategori.Text);
            db.SaveChanges();
            MessageBox.Show("Ürün güncellendi.");

        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int secilen = dataGridView1.SelectedCells[0].RowIndex;

            txtid.Text = dataGridView1.Rows[secilen].Cells[0].Value.ToString();
            txtad.Text = dataGridView1.Rows[secilen].Cells[1].Value.ToString();
            txtmarka.Text = dataGridView1.Rows[secilen].Cells[2].Value.ToString();
            txtstok.Text = dataGridView1.Rows[secilen].Cells[3].Value.ToString();
            txtfiyat.Text = dataGridView1.Rows[secilen].Cells[4].Value.ToString();
            txtdurum.Text = dataGridView1.Rows[secilen].Cells[6].Value.ToString();
            cmbkategori.Text = dataGridView1.Rows[secilen].Cells[5].Value.ToString();
        }


        private void FrmUrun_Load(object sender, EventArgs e)
        {
            var kategoriler = (from x in db.tblkategori 
                               select new 
                               { 
                                   x.id, 
                                   x.ad 
                               }
                               ).ToList();

            cmbkategori.ValueMember = "id";
            cmbkategori.DisplayMember = "ad";
            cmbkategori.DataSource = kategoriler;
        }

        private void btntemizle_Click(object sender, EventArgs e)
        {
            txtid.Text = "";
            txtad.Text = "";
            txtmarka.Text = "";
            txtstok.Text = "";
            txtfiyat.Text = "";
            txtdurum.Text = "";
            cmbkategori.Text = "";
        }
    }
}
