namespace Projectrecipe
{
    partial class FotoGoster
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.resimyol = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.kapat = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.kapat)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // resimyol
            // 
            this.resimyol.Depth = 0;
            this.resimyol.Enabled = false;
            this.resimyol.Hint = "";
            this.resimyol.Location = new System.Drawing.Point(166, 0);
            this.resimyol.MouseState = MaterialSkin.MouseState.HOVER;
            this.resimyol.Name = "resimyol";
            this.resimyol.PasswordChar = '\0';
            this.resimyol.SelectedText = "";
            this.resimyol.SelectionLength = 0;
            this.resimyol.SelectionStart = 0;
            this.resimyol.Size = new System.Drawing.Size(294, 23);
            this.resimyol.TabIndex = 78;
            this.resimyol.UseSystemPasswordChar = false;
            // 
            // kapat
            // 
            this.kapat.Image = global::Projectrecipe.Properties.Resources.close;
            this.kapat.Location = new System.Drawing.Point(596, 0);
            this.kapat.Name = "kapat";
            this.kapat.Size = new System.Drawing.Size(54, 47);
            this.kapat.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.kapat.TabIndex = 79;
            this.kapat.TabStop = false;
            this.kapat.Click += new System.EventHandler(this.kapat_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(650, 450);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // FotoGoster
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(650, 450);
            this.Controls.Add(this.kapat);
            this.Controls.Add(this.resimyol);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MinimizeBox = false;
            this.Name = "FotoGoster";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Zeytin Dalı";
            this.Load += new System.EventHandler(this.FotoGoster_Load);
            ((System.ComponentModel.ISupportInitialize)(this.kapat)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private MaterialSkin.Controls.MaterialSingleLineTextField resimyol;
        private System.Windows.Forms.PictureBox kapat;
    }
}