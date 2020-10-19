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
    public partial class FotoGoster : Form
    {
        string tarifismi;
        OleDbConnection conn = new OleDbConnection("Provider=Microsoft.ACE.OleDb.12.0;Data Source=tarif.accdb");
        public FotoGoster()
        {
            InitializeComponent();
            
        }

        private void FotoGoster_Load(object sender, EventArgs e)
        {
            conn.Open();

            try
            {
                OleDbCommand komut = new OleDbCommand();
                komut.Connection = conn;
                komut.CommandText = ("SELECT  * FROM tarifler1 WHERE tarif_isim = '" + tarifismi + "'");
                OleDbDataReader oku = komut.ExecuteReader();
                while (oku.Read())
                {
                    resimyol.Text = oku["tarif_resim"].ToString();
                }
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message.ToString());
            }
            conn.Close();
            
        }

        private void kapat_Click(object sender, EventArgs e)
        {
            Hide();
        }
    }
}
