using MaterialSkin;
using MaterialSkin.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;

namespace Projectrecipe
{
    public partial class AnaEkran : MaterialForm
    {
        OleDbConnection conn = new OleDbConnection("Provider=Microsoft.ACE.OleDb.12.0;Data Source=tarif.accdb");

        public AnaEkran()
        {
            InitializeComponent();
            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            materialSkinManager.ColorScheme = new ColorScheme(Primary.Lime900, Primary.Brown500, Primary.Indigo800, Accent.LightBlue200, TextShade.WHITE);
            materialDivider1.BackColor= System.Drawing.Color.BurlyWood;
            yenitarifekle.ForeColor = System.Drawing.Color.Sienna;
            

        }
        private void AnaEkran_Load(object sender, EventArgs e)
        {
            listView1.Items.Clear();
            conn.Open();
            OleDbCommand komut = new OleDbCommand();
            komut.Connection = conn;
            komut.CommandText = ("SELECT * from tarifler1 order by ID desc");
            OleDbDataReader oku = komut.ExecuteReader();
            while(oku.Read())
            {
                ListViewItem ekle = new ListViewItem();
                ekle.Text = oku["tarif_isim"].ToString();
                ekle.SubItems.Add(oku["tarif_kategori"].ToString());
                listView1.Items.Add(ekle);

            }
            conn.Close();
        }
        
        private void yenitarifekle_Click(object sender, EventArgs e)
        {
            TarifEkle recipeadd = new TarifEkle();
            recipeadd.Show();
            Hide();
        }
       
        #region Kategori Butonları

        private void tarifler_Click(object sender, EventArgs e)
        {
            listView1.Items.Clear();
            conn.Open();
            OleDbCommand komut = new OleDbCommand();
            komut.Connection = conn;
            komut.CommandText = ("SELECT * from tarifler1");
            OleDbDataReader oku = komut.ExecuteReader();
            while (oku.Read())
            {
                ListViewItem ekle = new ListViewItem();
                ekle.Text = oku["tarif_isim"].ToString();
                ekle.SubItems.Add(oku["tarif_kategori"].ToString());
                listView1.Items.Add(ekle);

            }
            conn.Close();
        }

        private void aperatif_Click(object sender, EventArgs e)
        {
            listView1.Items.Clear();
            conn.Open();
            OleDbCommand komut = new OleDbCommand();
            komut.Connection = conn;
            komut.CommandText = ("SELECT * FROM tarifler1 WHERE tarif_kategori = 'Aperatifler/ Atıştırmalıklar'");
            OleDbDataReader oku = komut.ExecuteReader();
            while (oku.Read())
            {
                ListViewItem ekle = new ListViewItem();
                ekle.Text = oku["tarif_isim"].ToString();
                ekle.SubItems.Add(oku["tarif_kategori"].ToString());
                listView1.Items.Add(ekle);
            }
            conn.Close();

        }

        private void kahvaltilik_Click(object sender, EventArgs e)
        {
            listView1.Items.Clear();
            conn.Open();
            OleDbCommand komut = new OleDbCommand();
            komut.Connection = conn;
            komut.CommandText = ("SELECT * FROM tarifler1 WHERE tarif_kategori = 'Kahvaltılıklar'");
            OleDbDataReader oku = komut.ExecuteReader();
            while (oku.Read())
            {
                ListViewItem ekle = new ListViewItem();
                ekle.Text = oku["tarif_isim"].ToString();
                ekle.SubItems.Add(oku["tarif_kategori"].ToString());
                listView1.Items.Add(ekle);

            }
            conn.Close();
        }

        private void hamurisi_Click(object sender, EventArgs e)
        {
            listView1.Items.Clear();
            conn.Open();
            OleDbCommand komut = new OleDbCommand();
            komut.Connection = conn;
            komut.CommandText = ("SELECT * FROM tarifler1 WHERE tarif_kategori = 'Hamur İşleri'");
            OleDbDataReader oku = komut.ExecuteReader();
            while (oku.Read())
            {
                ListViewItem ekle = new ListViewItem();
                ekle.Text = oku["tarif_isim"].ToString();
                ekle.SubItems.Add(oku["tarif_kategori"].ToString());
                listView1.Items.Add(ekle);
            }
            conn.Close();
        }

        private void tatli_Click(object sender, EventArgs e)
        {
            listView1.Items.Clear();
            conn.Open();
            OleDbCommand komut = new OleDbCommand();
            komut.Connection = conn;
            komut.CommandText = ("SELECT * FROM tarifler1 WHERE tarif_kategori = 'Tatlılar'");
            OleDbDataReader oku = komut.ExecuteReader();
            while (oku.Read())
            {
                ListViewItem ekle = new ListViewItem();
                ekle.Text = oku["tarif_isim"].ToString();
                ekle.SubItems.Add(oku["tarif_kategori"].ToString());
                listView1.Items.Add(ekle);
            }
            conn.Close();
        }

        private void anayemek_Click(object sender, EventArgs e)
        {
            listView1.Items.Clear();
            conn.Open();
            OleDbCommand komut = new OleDbCommand();
            komut.Connection = conn;
            komut.CommandText = ("SELECT * FROM tarifler1 WHERE tarif_kategori = 'Ana Yemekler'");
            OleDbDataReader oku = komut.ExecuteReader();
            while (oku.Read())
            {
                ListViewItem ekle = new ListViewItem();
                ekle.Text = oku["tarif_isim"].ToString();
                ekle.SubItems.Add(oku["tarif_kategori"].ToString());
                listView1.Items.Add(ekle);
            }
            conn.Close();
        }

        private void icecek_Click(object sender, EventArgs e)
        {
            listView1.Items.Clear();
            conn.Open();
            OleDbCommand komut = new OleDbCommand();
            komut.Connection = conn;
            komut.CommandText = ("SELECT * FROM tarifler1 WHERE tarif_kategori = 'İçecekler'");
            OleDbDataReader oku = komut.ExecuteReader();
            while (oku.Read())
            {
                ListViewItem ekle = new ListViewItem();
                ekle.Text = oku["tarif_isim"].ToString();
                ekle.SubItems.Add(oku["tarif_kategori"].ToString());
                listView1.Items.Add(ekle);
            }
            conn.Close();
        }
        #endregion

        private void tarifgoster_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                var item = listView1.SelectedItems[0];
                TarifGoruntule goruntule = new TarifGoruntule(listView1.SelectedItems[0].Text);
                goruntule.Show();
                Hide();
            }
        }

        private void AnaEkran_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void copyright_Click(object sender, EventArgs e)
        {
            MessageBox.Show("                         Ceren Cömert \nBalıkesir Üniversitesi Bilgisayar Mühendisliği\n 2.Sınıf Görsel Programlama Dönem Projesi\n                             10.05.2017");
        }
    }
}
