using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OkulKitapligiADONET
{
    public partial class FormYazarlar : Form
    {
        public FormYazarlar()
        {
            InitializeComponent();
        }

        //Global alan

        //SQLCONNECTION Nesnesi: SQL veritabanına bağlantı kurmak için kullanacağımız classtır. System.Data.Client namespace'i içerisinde yer alır.

        SqlConnection baglanti = new SqlConnection();
        string SQLBaglantiCumlesi = @"Server=DESKTOP-TUMHS1A;Database=OKULKITAPLIGI;Trusted_Connection=True;";


        private void FormYazarlar_Load(object sender, EventArgs e)
        {
            baglanti.ConnectionString = SQLBaglantiCumlesi;

            dataGridYazarlar.MultiSelect = false; //çoklu satır seçimi engellendi
            dataGridYazarlar.SelectionMode = DataGridViewSelectionMode.FullRowSelect; // fare ile datagrid üzerinde bir hücreye tıkladığında bulunduğu satırı tamamen seçecek

            //datagridview'e sağ tıklanınca gelecek olan contextmenustrip ataması yapıldı
            dataGridYazarlar.ContextMenuStrip = contextMenuStrip1;
            //grid'in içine bilgileri getireceğiz
            TumYazarlariGetir();

        }

        private void TumYazarlariGetir()
        {
            try
            {
                //SQLConnection'a bağlanacağı adresi verdik.

                //SQLCOMMAND nesnesi: Sorgularımızı ve prosedürlerimize ait komutları alan nesnedir.
                SqlCommand komut = new SqlCommand();
                komut.Connection = baglanti;
                komut.CommandType = CommandType.Text;
                string sorgu = "Select * from Yazarlar where SilindiMi=0 order by YazarId desc";
                komut.CommandText = sorgu;
                BaglantiyiAc();
                //DataSQLADAPTER nesnesi, sorgu çalşınca oluşan dataların aktarılması işlemini yapar. Adaptore hangi komut işleyeceğini ctor'da verebiliriz ya da daha sonradan verebiliriz.
                SqlDataAdapter adaptor = new SqlDataAdapter(komut);
                //adaptor.SelectCommand = komut;

                //Adaptorun içindeki verileri sanalTabloya alıyoruz.
                DataTable sanalTablo = new DataTable();
                adaptor.Fill(sanalTablo);

                dataGridYazarlar.DataSource = sanalTablo;
                dataGridYazarlar.Columns["SilindiMi"].Visible = false;
                dataGridYazarlar.Columns["YazarAdSoyad"].Width = 220;
                dataGridYazarlar.Columns["KayitTarihi"].Width = 150;
                BaglantiyiKapat();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Beklenmedik bir hata oluştu! HATA: {ex.Message}", "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonEkle_Click(object sender, EventArgs e)
        {
            switch (buttonEkle.Text)
            {
                case "EKLE":
                    try
                    {
                        if (string.IsNullOrEmpty(txtYazar.Text))
                        {
                            MessageBox.Show("Lütfen yazar bilgisini giriniz!", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        }
                        else
                        {
                            string insertCumlesi = $"insert into Yazarlar (KayitTarihi, YazarAdSoyad, SilindiMi) values ('{TarihiDuzenle(DateTime.Now)}','{txtYazar.Text.Trim()}',0)";
                            SqlCommand insertkomut = new SqlCommand(insertCumlesi, baglanti);
                            //bağlantı açılacak metot çağıralım
                            BaglantiyiAc();
                            int sonucum = insertkomut.ExecuteNonQuery();
                            if (sonucum > 0)//effected rows var
                            {
                                MessageBox.Show("Yeni yazar sisteme eklendi.");
                            }
                            else
                            {
                                MessageBox.Show("Bir hata oluştu. Yeni yazar eklenemedi!");
                            }
                            //bağlantı kapanacak metot çağılarım
                            BaglantiyiKapat();
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Ekleme işleminde beklenmedik bir hata oluştu" + ex.Message);
                    }
                    break;

                case "Güncelle":
                    try
                    {
                        if (!string.IsNullOrEmpty(txtYazar.Text))
                        {
                            using (baglanti)
                            {
                                DataGridViewRow satir = dataGridYazarlar.SelectedRows[0];
                                int YazarId = Convert.ToInt32(satir.Cells["YazarId"].Value);
                                
                                string updateSorgucumlesi = $"Update Yazarlar Set YazarAdSoyad='{txtYazar.Text.Trim()}' where YazarId={YazarId} ";
                                SqlCommand updateCommand = new SqlCommand(updateSorgucumlesi, baglanti);
                                BaglantiyiAc();

                                int sonuc = updateCommand.ExecuteNonQuery();
                                if (sonuc > 0)
                                {
                                    MessageBox.Show($"Yazar güncellendi");
                                    TumYazarlariGetir();
                                }
                                else
                                {
                                    MessageBox.Show("Yazar güncellenemedi");
                                }
                                BaglantiyiKapat();
                            }                       

                        }
                    }
                    catch (Exception ex)
                    {

                        MessageBox.Show("Güncelleme işleminde beklenmedik hata oldu!");
                    }
                    Temizle();

                    break;

                default:
                    break;
            }
        }

        private void Temizle()
        {
            buttonEkle.Text = "EKLE";
            txtYazar.Clear();
        }

        private void BaglantiyiKapat()
        {
            try
            {
                if (baglanti.State != ConnectionState.Closed)
                {
                    baglanti.Close();
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show("Bağlantıyı kapatırken bir hata oluştu" + ex.Message);
            }
        }

        private void BaglantiyiAc()
        {
            try
            {
                //bağlantı açık değilse açalım
                if (baglanti.State != ConnectionState.Open)
                {
                    baglanti.Open();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Bağlantı açılırken bir hata oluştu!" + ex.Message);
            }
        }

        private string TarihiDuzenle(DateTime tarih)
        {
            string tarihString = string.Empty;
            if (tarih != null)
            {
                tarihString = tarih.Year + "-" + tarih.Month + "-" + tarih.Day + " " + tarih.Hour + ":" + tarih.Minute + ":" + tarih.Second;
            }

            return tarihString;
        }

        private void guncelleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dataGridYazarlar.SelectedRows.Count > 0)
            {
                DataGridViewRow satir = dataGridYazarlar.SelectedRows[0];
                string yazarAdSoyad = Convert.ToString(satir.Cells["YazarAdSoyad"].Value);
                buttonEkle.Text = "Güncelle";
                txtYazar.Text = yazarAdSoyad;
            }
            else
            {
                MessageBox.Show("Güncelleme işlemi için tablodan bir yazar seçmeniz gerekiyor", "UYARI");
            }
        }

        public void dataGridYazarlar_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void buttonTemizle_Click(object sender, EventArgs e)
        {
            Temizle();
        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {

        }

        private void silToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DataGridViewRow secilenSatir = dataGridYazarlar.SelectedRows[0];
            int yazarId = (int)secilenSatir.Cells["YazarId"].Value;
            string yazar = Convert.ToString(secilenSatir.Cells["YazarAdSoyad"].Value);

            SqlCommand komut = new SqlCommand($"select * from Kitaplar where YazarId={yazarId}", baglanti);

            komut.Connection = baglanti;
            SqlDataAdapter adaptor = new SqlDataAdapter(komut);

            DataTable sanalTablo = new DataTable();
            BaglantiyiAc();
            adaptor.Fill(sanalTablo);
            if (sanalTablo.Rows.Count>0)
            {
                MessageBox.Show($"{yazar} adlı yazarın Kitaplar tablosunda verileri bulunmaktadır. Bu yazarı silmek için öncelikle sistemdeki ona tanımlı kitapları silmeni gerektirmektedir. Lütfen kitap işlemlerisayfasına gidiniz.");
            }
            else
            {
                // Kitabı yok. Foreign key patlaması olmaz. Silebiliriz.

                DialogResult cevap= MessageBox.Show($"{yazar} adlı yazarı silmek istediğinize emin misiniz?","ONAY",MessageBoxButtons.YesNoCancel,MessageBoxIcon.Question);
                if (cevap ==DialogResult.Yes)
                {
                    //silecek
                    //komut.CommandText = $"Delete from Yazarlar where YazarId={yazarId}";
                    komut.CommandText = $"Delete from Yazarlar where YazarId=@yzrid";
                    komut.Parameters.Clear();

                    komut.Parameters.AddWithValue("@yzrid", yazarId);

                    BaglantiyiAc();
                    int sonuc = komut.ExecuteNonQuery();
                    if (sonuc>0)
                    {
                        MessageBox.Show("Silindi");
                        TumYazarlariGetir();
                    }
                    else
                    {
                        MessageBox.Show("HATA:Silinemedi!");
                    }
                    BaglantiyiKapat();
                }
            }
        }

        private void silPasifeCekToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // kullancı silindi zannedecek ama biz aslında pasif yapacağız
            // Bu yöntem yukarıdakiler gibi kullanışlı değildir.
            try
            {

                DataGridViewRow secilenSatir = dataGridYazarlar.SelectedRows[0];
                int yazarId = (int)secilenSatir.Cells["YazarId"].Value;
                string yazar = Convert.ToString(secilenSatir.Cells["YazarAdSoyad"].Value);
                SqlCommand komut = new SqlCommand();
                komut.Connection = baglanti;

                DialogResult cevap = MessageBox.Show($"{yazar} adlı yazarı silmek istediğinize emin misiniz?", "ONAY", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                if (cevap == DialogResult.Yes)
                {
                    //silecek
                    //komut.CommandText = $"Delete from Yazarlar where YazarId={yazarId}";
                    //@yzrid diyerek bir parametre oluşturmuş olduk.
                    komut.CommandText = $"Delete from Yazarlar where YazarId=@yzrid";
                    komut.Parameters.Clear();
                    //AddWithValue metodu @yzrid yerine yazarId değerini sqlcommand nesnesinin commendText'inde bulunan sorgu cümlesine entegre eder.
                    komut.Parameters.AddWithValue("@yzrid", yazarId);

                    BaglantiyiAc();
                    int sonuc = komut.ExecuteNonQuery();
                    if (sonuc > 0)
                    {
                        MessageBox.Show("Silindi");
                        TumYazarlariGetir();
                    }
                    else
                    {
                        MessageBox.Show("HATA:Silinemedi!");
                    }
                    BaglantiyiKapat();
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show("HATA: " + ex.Message);
            }
        }

        private void silBaskaBirYontemToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //bu yöntem diğerleri kadar kullanışlı değil
            try
            {

            }
            catch (Exception ex)
            {

                MessageBox.Show("HATA: "+ ex.Message);
            }
        }
    }
}
