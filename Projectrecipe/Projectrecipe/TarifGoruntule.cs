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

    public partial class TarifGoruntule : MaterialForm
    {
        string tarifismi;
        string tarif;

        OleDbConnection conn = new OleDbConnection("Provider=Microsoft.ACE.OleDb.12.0;Data Source=tarif.accdb");
        OleDbCommand sql = new OleDbCommand();


        public TarifGoruntule(string tarif)
        {
            InitializeComponent();
            tarifismi = tarif;

        }

        public TarifGoruntule()
        {
            InitializeComponent();
            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            materialSkinManager.ColorScheme = new ColorScheme(Primary.Lime900, Primary.Brown500, Primary.Indigo800, Accent.LightBlue200, TextShade.WHITE);

        }
        private void geridon_Click(object sender, EventArgs e)
        {
            AnaEkran mainmenu = new AnaEkran();
            mainmenu.Show();
            Hide();
        }


        private void TarifGoruntule_Load(object sender, EventArgs e)
        {
            
            #region combobox
            comboBox1.Items.Add("Kahvaltılıklar");
            comboBox1.Items.Add("Aperatifler/ Atıştırmalıklar");
            comboBox1.Items.Add("Hamur İşleri");
            comboBox1.Items.Add("Tatlılar");
            comboBox1.Items.Add("Ana Yemekler");
            comboBox1.Items.Add("İçecekler");
            #endregion

            conn.Open();
            try
            {
                OleDbCommand komut = new OleDbCommand();
                komut.Connection = conn;
                komut.CommandText = ("SELECT  * FROM tarifler1 WHERE tarif_isim = '" + tarifismi + "'");
                OleDbDataReader oku = komut.ExecuteReader();
                while (oku.Read())
                {
                    tarifismitext.Text = tarifismi;
                    comboBox1.SelectedIndex = comboBox1.Items.IndexOf(oku["tarif_kategori"].ToString());
                    kisisayisitext.Text = oku["tarif_kisisayisi"].ToString();
                    hzrtext.Text = oku["tarif_hazirlamasuresi"].ToString();
                    psrtext.Text = oku["tarif_pisirmesuresi"].ToString();
                    malzemetext.Text = oku["tarif_malzemeler"].ToString();
                    yaptext.Text = oku["tarif_yapim"].ToString();
                   foto.ImageLocation = oku["tarif_resim"].ToString();
                   resimyol.Text = oku["tarif_resim"].ToString();

                }
            }
            catch(Exception err)
            {
                MessageBox.Show(err.Message.ToString());
            }
            conn.Close();

        }

        private void fotografekle_Click(object sender, EventArgs e)
        {
            OpenFileDialog file = new OpenFileDialog();
             file.Filter = "Resim Dosyası |*.jpg;*.nef;*.png| Video|*.avi| Tüm Dosyalar |*.*";
             file.ShowDialog();
             string resimyol1 = file.FileName;
            
             foto.ImageLocation = resimyol1;
             resimyol.Text = resimyol1;
        }

        private void kaydet_Click(object sender, EventArgs e)
        {

            conn.Open();
            try
            {
                if (MessageBox.Show("Tarifi güncellemek istediğinizden emin misiniz?", "Tarifi güncelle?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    OleDbCommand guncelle = new OleDbCommand("update tarifler1 set tarif_isim='"+ tarifismitext.Text + "',tarif_kategori='"+ comboBox1.SelectedItem.ToString()   +"',tarif_kisisayisi='"+ kisisayisitext.Text + "',tarif_hazirlamasuresi='"+ hzrtext.Text + "',tarif_pisirmesuresi='" +psrtext.Text+ "',tarif_malzemeler='"+ malzemetext.Text+ "',tarif_yapim='" +yaptext.Text + "',tarif_resim='"+ resimyol.Text  + "' where tarif_isim='" + tarifismi + "'", conn);
                    guncelle.ExecuteNonQuery();

                    #region diğer sorgu
                    /*  eğer fotoğrafları proje resources'inin içine ekleyip dosya adı ile yaparsan düzelir! @ özel karakterlerden ayrılması sağladığı için kod çalışmıyor
                     *  sql = new OleDbCommand("UPDATE tarifler1 SET tarif_isim=@isim, tarif_kategori=@kategori, tarif_kisisayisi=@ksayi, tarif_hazirlamasuresi=@hsure, tarif_pisirmesuresi=@psure, tarif_malzemeler=@tmalzeme, tarif_yapim=@tyapim, tarif_resim=@tresim WHERE tarif_isim=@eisim", conn);
                      sql.Parameters.AddWithValue("@isim", tarifismitext.Text);
                      sql.Parameters.AddWithValue("@kategori",comboBox1.SelectedItem.ToString());
                      sql.Parameters.AddWithValue("@ksayi", kisisayisitext.Text);
                      sql.Parameters.AddWithValue("@hsure", hzrtext.Text);
                      sql.Parameters.AddWithValue("@psure", psrtext.Text);
                      sql.Parameters.AddWithValue("@tmalzeme", malzemetext.Text);
                      sql.Parameters.AddWithValue("@tyapim", yaptext.Text);
                      sql.Parameters.AddWithValue("@eisim", tarifismi);
                    sql.Parameters.AddWithValue("@tresim", resimyol.Text);
                      sql.ExecuteNonQuery();*/
                    #endregion
                    MessageBox.Show("Kayıt başarıyla güncellendi...");
                    conn.Close();
                    tarifismi = tarifismitext.Text;
                }
            }
            catch(Exception err)
            {
                MessageBox.Show(err.Message.ToString());
            }
            
        }

        private void duzenle_Click(object sender, EventArgs e)
        {

            if (duzenle.Text != "İPTAL ET")
            {
                kaydet.Enabled = true;
                sil.Enabled = true;
                tarifismitext.Enabled = true;
                comboBox1.Enabled = true;
                kisisayisitext.Enabled = true;
                hzrtext.Enabled = true;
                psrtext.Enabled = true;
                malzemetext.Enabled = true;
                yaptext.Enabled = true;
                fotografekle.Enabled = true;
                duzenle.Text = "İPTAL ET";
                kaydet.Cursor = Cursors.Hand;
                fotografekle.Cursor=Cursors.Hand;
                sil.Cursor = Cursors.Hand;
                  
            }
            else
            {
                
                kaydet.Enabled = false;
                sil.Enabled = false;
                tarifismitext.Enabled = false;
                comboBox1.Enabled = false;
                kisisayisitext.Enabled = false;
                hzrtext.Enabled = false;
                psrtext.Enabled = false;
                malzemetext.Enabled = false;
                yaptext.Enabled = false;
                fotografekle.Enabled = false;
                duzenle.Text = "DÜZENLE";
                sil.Cursor = Cursors.No;

            }
        }

        private void sil_Click(object sender, EventArgs e)
        {
            OleDbCommand sql;
            conn.Open();
            try
            {
                if (MessageBox.Show("Tarifi silmek istediğinizden emin misiniz?", "Tarifi Sil?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    sql = new OleDbCommand("DELETE FROM tarifler1 WHERE tarif_isim=@isim", conn);
                    sql.Parameters.AddWithValue("@isim", tarifismi);
                    sql.ExecuteNonQuery();
                    MessageBox.Show("Kayıt başarıyla silindi...");
                    AnaEkran ana = new AnaEkran();
                    ana.Show();
                    Hide();
                    conn.Close();
                }
            }
            catch(Exception err)
            {
                MessageBox.Show(err.Message.ToString());
            }
            
        }

        private void TarifGoruntule_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void foto_DoubleClick(object sender, EventArgs e)
        {
            FotoGoster picshow = new FotoGoster();
            picshow.Show();
        }
    }
}
