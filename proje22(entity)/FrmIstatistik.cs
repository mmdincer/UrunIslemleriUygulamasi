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
    public partial class FrmIstatistik : Form
    {
        public FrmIstatistik()
        {
            InitializeComponent();
        }
        DBEntityUrunEntities db = new DBEntityUrunEntities();

        private void FrmIstatistik_Load(object sender, EventArgs e)
        {
            label2.Text = db.tblkategori.Count().ToString();
            label5.Text = db.tblurun.Count().ToString();
            label7.Text = db.tblmusteri.Count(x=>x.durum==true).ToString();
            label3.Text = db.tblmusteri.Count(x=>x.durum==false).ToString();
            label11.Text = db.tblurun.Sum(y=>y.stok).ToString();
            label19.Text = db.tblsatis.Sum(z=>z.fiyat).ToString() + " TL";
            label9.Text = (from x in db.tblurun orderby x.fiyat ascending select x.urunad).FirstOrDefault();
            label13.Text = (from x in db.tblurun orderby x.fiyat descending select x.urunad).FirstOrDefault();
            label15.Text = db.tblurun.Count(x=>x.kategori==1).ToString();
            label17.Text = db.tblurun.Count(x=>x.urunad=="buzdolabı").ToString();
            label23.Text = (from x in db.tblmusteri select x.sehir).Distinct().Count().ToString();
            label21.Text = db.markagetir().FirstOrDefault();





        }
    }
}
