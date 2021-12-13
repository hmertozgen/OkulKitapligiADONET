
namespace OkulKitapligiADONET
{
    partial class FormYazarlar
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
            this.components = new System.ComponentModel.Container();
            this.label1 = new System.Windows.Forms.Label();
            this.txtYazar = new System.Windows.Forms.TextBox();
            this.buttonEkle = new System.Windows.Forms.Button();
            this.buttonTemizle = new System.Windows.Forms.Button();
            this.dataGridYazarlar = new System.Windows.Forms.DataGridView();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.guncelleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.silToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.silBaskaBirYontemToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.silPasifeCekToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridYazarlar)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 102);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(115, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Yazar Ad-Soyad:";
            // 
            // txtYazar
            // 
            this.txtYazar.Location = new System.Drawing.Point(175, 98);
            this.txtYazar.Margin = new System.Windows.Forms.Padding(4);
            this.txtYazar.Name = "txtYazar";
            this.txtYazar.Size = new System.Drawing.Size(440, 22);
            this.txtYazar.TabIndex = 1;
            // 
            // buttonEkle
            // 
            this.buttonEkle.Location = new System.Drawing.Point(657, 87);
            this.buttonEkle.Margin = new System.Windows.Forms.Padding(4);
            this.buttonEkle.Name = "buttonEkle";
            this.buttonEkle.Size = new System.Drawing.Size(128, 46);
            this.buttonEkle.TabIndex = 2;
            this.buttonEkle.Text = "EKLE";
            this.buttonEkle.UseVisualStyleBackColor = true;
            this.buttonEkle.Click += new System.EventHandler(this.buttonEkle_Click);
            // 
            // buttonTemizle
            // 
            this.buttonTemizle.Location = new System.Drawing.Point(832, 87);
            this.buttonTemizle.Margin = new System.Windows.Forms.Padding(4);
            this.buttonTemizle.Name = "buttonTemizle";
            this.buttonTemizle.Size = new System.Drawing.Size(128, 46);
            this.buttonTemizle.TabIndex = 3;
            this.buttonTemizle.Text = "TEMİZLE";
            this.buttonTemizle.UseVisualStyleBackColor = true;
            this.buttonTemizle.Click += new System.EventHandler(this.buttonTemizle_Click);
            // 
            // dataGridYazarlar
            // 
            this.dataGridYazarlar.AllowUserToAddRows = false;
            this.dataGridYazarlar.AllowUserToDeleteRows = false;
            this.dataGridYazarlar.AllowUserToOrderColumns = true;
            this.dataGridYazarlar.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridYazarlar.Location = new System.Drawing.Point(20, 150);
            this.dataGridYazarlar.Margin = new System.Windows.Forms.Padding(4);
            this.dataGridYazarlar.Name = "dataGridYazarlar";
            this.dataGridYazarlar.ReadOnly = true;
            this.dataGridYazarlar.RowHeadersWidth = 51;
            this.dataGridYazarlar.Size = new System.Drawing.Size(1043, 325);
            this.dataGridYazarlar.TabIndex = 4;
            this.dataGridYazarlar.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridYazarlar_CellContentClick);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.guncelleToolStripMenuItem,
            this.silToolStripMenuItem,
            this.silBaskaBirYontemToolStripMenuItem,
            this.silPasifeCekToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(213, 128);
            this.contextMenuStrip1.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenuStrip1_Opening);
            // 
            // guncelleToolStripMenuItem
            // 
            this.guncelleToolStripMenuItem.Name = "guncelleToolStripMenuItem";
            this.guncelleToolStripMenuItem.Size = new System.Drawing.Size(212, 24);
            this.guncelleToolStripMenuItem.Text = "Güncelle";
            this.guncelleToolStripMenuItem.Click += new System.EventHandler(this.guncelleToolStripMenuItem_Click);
            // 
            // silToolStripMenuItem
            // 
            this.silToolStripMenuItem.Name = "silToolStripMenuItem";
            this.silToolStripMenuItem.Size = new System.Drawing.Size(212, 24);
            this.silToolStripMenuItem.Text = "Sil";
            this.silToolStripMenuItem.Click += new System.EventHandler(this.silToolStripMenuItem_Click);
            // 
            // silBaskaBirYontemToolStripMenuItem
            // 
            this.silBaskaBirYontemToolStripMenuItem.Name = "silBaskaBirYontemToolStripMenuItem";
            this.silBaskaBirYontemToolStripMenuItem.Size = new System.Drawing.Size(212, 24);
            this.silBaskaBirYontemToolStripMenuItem.Text = "Sil Başka bir yöntem";
            this.silBaskaBirYontemToolStripMenuItem.Click += new System.EventHandler(this.silBaskaBirYontemToolStripMenuItem_Click);
            // 
            // silPasifeCekToolStripMenuItem
            // 
            this.silPasifeCekToolStripMenuItem.Name = "silPasifeCekToolStripMenuItem";
            this.silPasifeCekToolStripMenuItem.Size = new System.Drawing.Size(212, 24);
            this.silPasifeCekToolStripMenuItem.Text = "Sil Pasife Çek";
            this.silPasifeCekToolStripMenuItem.Click += new System.EventHandler(this.silPasifeCekToolStripMenuItem_Click);
            // 
            // FormYazarlar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.PapayaWhip;
            this.ClientSize = new System.Drawing.Size(1095, 490);
            this.Controls.Add(this.dataGridYazarlar);
            this.Controls.Add(this.buttonTemizle);
            this.Controls.Add(this.buttonEkle);
            this.Controls.Add(this.txtYazar);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FormYazarlar";
            this.Text = "Yazar İşlemleri";
            this.Load += new System.EventHandler(this.FormYazarlar_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridYazarlar)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtYazar;
        private System.Windows.Forms.Button buttonEkle;
        private System.Windows.Forms.Button buttonTemizle;
        private System.Windows.Forms.DataGridView dataGridYazarlar;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem guncelleToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem silToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem silBaskaBirYontemToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem silPasifeCekToolStripMenuItem;
    }
}

