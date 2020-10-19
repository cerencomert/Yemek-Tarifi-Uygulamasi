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
    public partial class TarifEkle : MaterialForm
    {
        OleDbConnection conn = new OleDbConnection("Provider=Microsoft.ACE.OleDb.12.0;Data Source=tarif.accdb");
        OleDbCommand sql;
        OleDbDataReader result;

        public TarifEkle()
        {
            InitializeComponent();
            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            materialSkinManager.ColorScheme = new ColorScheme(Primary.Lime900, Primary.Brown500, Primary.Indigo800, Accent.LightBlue200, TextShade.WHITE);
            materialDivider1.BackColor = System.Drawing.Color.BurlyWood;
            materialDivider2.BackColor = System.Drawing.Color.Olive;
            materialDivider3.BackColor = System.Drawing.Color.Olive;
            materialDivider4.BackColor = System.Drawing.Color.Olive;
        }

        private void TarifEkle_Load(object sender, EventArgs e)
        {
            comboBox1.Items.Add("Kahvaltılıklar");
            comboBox1.Items.Add("Aperatifler/ Atıştırmalıklar");
            comboBox1.Items.Add("Hamur İşleri");
            comboBox1.Items.Add("Tatlılar");
            comboBox1.Items.Add("Ana Yemekler");
            comboBox1.Items.Add("İçecekler");

        }

        private void yenitarifekle_Click(object sender, EventArgs e)
        {
            AnaEkran mainmenu = new AnaEkran();
            mainmenu.Show();
            Hide();
        }

        private void kaydet_Click(object sender, EventArgs e)
        {
            conn.Open();
            try
            {
            string tarifisim = tarifismitext.Text;
            string kategori = comboBox1.SelectedItem.ToString();
            string kisisayisi = kisisayisitext.Text;
            string pisir = psrtext.Text;
            string hazirla = hzrtext.Text;
            string malzeme = malzemetext.Text;
            string tarif = yaptext.Text;
           string yol = resimyol.Text;

            
                sql = new OleDbCommand("select * from tarifler1 where tarif_isim='" + tarifismitext.Text + "'", conn);
                result = sql.ExecuteReader();
                result.Read();
                if (result.HasRows)
                {
                    MessageBox.Show("Bu adla başka bir tarif bulunmakta. Lütfen kayıtlı olan tarife bakınız.\n Eğer tarifinizin kayıtlarda bulunan tariften farklı olduğunu düşünüyorsanız, tarif isminize ayırt edici kelimeler ekleyiniz.");
                }
                else
                {
                    sql = new OleDbCommand("insert into tarifler1 (tarif_isim,tarif_kategori,tarif_kisisayisi,tarif_hazirlamasuresi,tarif_pisirmesuresi,tarif_malzemeler,tarif_yapim,tarif_resim) values ('" + tarifisim + "','" + kategori + "','" + kisisayisi + "','" + pisir + "','" + hazirla + "','" + malzeme + "','" + tarif + "','"+yol  +    "')", conn);
                    sql.ExecuteNonQuery();
                    MessageBox.Show("Kayıt başarıyla eklendi...");
                   
                }

            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message.ToString());
            }
            conn.Close();
        }

        private void iptal_Click(object sender, EventArgs e)
        {
            conn.Open();
            if (MessageBox.Show("İşlemi devam ettirmek istiyor musunuz? Yapılan işlemin geri dönüşü olmayacaktır. ", "Tarifi iptal et", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                AnaEkran mainmenu = new AnaEkran();
                mainmenu.Show();
                Hide();
            }
    }

        private void fotografekle_Click(object sender, EventArgs e)
        {
            OpenFileDialog file = new OpenFileDialog();
            file.Filter = "Resim Dosyası |*.jpg;*.nef;*.png| Video|*.avi| Tüm Dosyalar |*.*";
            file.ShowDialog();
            string yol = file.FileName;
            pictureBox2.ImageLocation = yol;
            resimyol.Text = yol;
            
        }

        private void TarifEkle_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

    }
    }
