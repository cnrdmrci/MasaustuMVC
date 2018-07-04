using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ENTITYLAYER;
using BUSSINESLOGICLAYER;
using System.IO;

namespace BUMBSS.com
{
    public partial class Form1 : Form
    {
        private static int UserIDNo;
        private static int tempPicID;
        private static int tempPicNo=0;
        private static int CategoryID;
        private static int SubCategoryID1;
        private static string SubCategoryName1;
        private static int SubCategoryID2;
        private static string SubCategoryName2;
        private static int gecerli_sayfa=1;
        private static int sol1sag2 = 0;
        private static int temp_sayfa_sayisi;
        private static int temp_UrunID;
        private static int temp_UrunID2;
        private static bool onay=false;
        public Form1()
        {
            InitializeComponent();
            sifirla();
            kategori_cek();
            
        }
        //yukaridan giris butonuna tiklandiginda
        private void TopLoginButton_Click(object sender, EventArgs e)
        {
            TabloUst.SelectedIndex = 1;
        }

        //Form surukleme islemi
        bool dragging;
        Point offset;
        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            dragging = true;
            offset = e.Location;
        }
        private void panel1_MouseUp(object sender, MouseEventArgs e)
        {
            dragging = false;
        }
        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (dragging)
            {
                Point currentScreenPos = PointToScreen(e.Location);
                Location = new
                Point(currentScreenPos.X - offset.X,
                currentScreenPos.Y - offset.Y);
            }
        }

        //ust panel cikis yap
        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        //Form yuklenirken
        private void sifirla()
        {
            //loginPanel.Visible = false;
            //panel3.Visible = true;
        }

        private void kayitol_Click(object sender, EventArgs e)
        {
            if (string.Compare(sifre.Text, sifre2.Text) == 0)
            {
                EUSERS item = new EUSERS();
                item.Username = username.Text;
                item.Pass = sifre.Text;
                item.Name = name.Text;
                item.Surname = surname.Text;
                item.Email = email.Text;
                item.SecurityAnswer = gizlisoru.Text;

                


                if (BLLUSERS.Insert(item) > 0)
                {
                    int temp_user_ID = BLLUSERS.get_user_ID(item);

                    EADDRESS item2 = new EADDRESS();
                    item2.Cadde = Cadde.Text;
                    item2.Street = Sokak.Text;
                    item2.City = il.Text;
                    item2.Town = ilce.Text;
                    item2.Num = Convert.ToInt32(no.Text);
                    item2.UsersID = temp_user_ID;
                    BLLADDRESS.insert_Address(item2);
                    MessageBox.Show("Basariyla kayit oldunuz.");
                }
                else
                    MessageBox.Show("Kayit hatasi");
            }
            else
            {
                MessageBox.Show("Sifreler uyusmuyor!");
            }
            TabloUst.SelectedIndex = 1;
        }

        private void girisYap_Click(object sender, EventArgs e)
        {
            EUSERS item = new EUSERS();
            item.Username = email_giris.Text;
            item.Email = email_giris.Text;
            item.Pass = sifre_giris.Text;
            if (BLLUSERS.Login(item,ref UserIDNo) == 1)
                MessageBox.Show("Basariyla giris yaptiniz.");
            else
                MessageBox.Show("Giris hatasi");
            TabloUst.SelectedIndex = 0;
        }
        private void Uruneklebuton_Click(object sender, EventArgs e)
        {
            if (tempPicNo != 0)
            {
                EPRODUCT item = new EPRODUCT();
                item.Name = urunadi.Text;
                item.Price = Convert.ToInt32(urunfiyati.Text);
                //tam buraya
                item.SubCategoryID = Convert.ToInt32(altkategorilist.SelectedValue);
                item.UsersID = UserIDNo;
                if (BLLPRODUCT.AddItem(item, ref tempPicID) > 1)
                    MessageBox.Show("Urun eklendi.");
                else
                    MessageBox.Show("Ekleme hatasi");

                string UsersID = UserIDNo.ToString();

                string resimAdi1 = UsersID + "." + tempPicID.ToString() + "." + "1";
                string resimAdi2 = UsersID + "." + tempPicID.ToString() + "." + "2";
                string resimAdi3 = UsersID + "." + tempPicID.ToString() + "." + "3";

                string filePath1 = Application.StartupPath + "\\scan\\" + resimAdi1 + ".jpg";
                string filePath2 = Application.StartupPath + "\\scan\\" + resimAdi2 + ".jpg";
                string filePath3 = Application.StartupPath + "\\scan\\" + resimAdi3 + ".jpg";

                if (UrunEkleResim.Image != null)
                {
                    EPICTURE item2 = new EPICTURE();
                    item2.ProductID = tempPicID;
                    item2.PicDirectory = filePath1;
                    BLLPICTURE.AddPicture(item2);

                }
                if (UrunEkleResim2.Image != null)
                {
                    EPICTURE item2 = new EPICTURE();
                    item2.ProductID = tempPicID;
                    item2.PicDirectory = filePath2;
                    BLLPICTURE.AddPicture(item2);
                }
                if (UrunEkleResim3.Image != null)
                {
                    EPICTURE item2 = new EPICTURE();
                    item2.ProductID = tempPicID;
                    item2.PicDirectory = filePath3;
                    BLLPICTURE.AddPicture(item2);
                }

                MessageBox.Show("1");
                if (UrunEkleResim.Image != null)
                {
                    UrunEkleResim.Image.Save(filePath1);

                }
                if (UrunEkleResim2.Image != null)
                {
                    UrunEkleResim.Image.Save(filePath2);
                }
                if (UrunEkleResim3.Image != null)
                {
                    UrunEkleResim.Image.Save(filePath3);
                }
            }
            TabloUst.SelectedIndex = 0;
        }

        private void ResimEkleButon_Click(object sender, EventArgs e)
        {
            if (tempPicNo == 0)
            {
                int UsersIDNoTemp;
                UsersIDNoTemp = UserIDNo;
                OpenFileDialog dosya = new OpenFileDialog();
                dosya.Filter = "Resim Dosyası |*.jpg;*.nef;*.png |  Tüm Dosyalar |*.*";
                dosya.ShowDialog();
                string dosyayolu = dosya.FileName;
                aciklama.Text = dosyayolu;
                UrunEkleResim.ImageLocation = dosyayolu;
                tempPicNo++;
            }
            else if (tempPicNo == 1)
            {
                int UsersIDNoTemp;
                UsersIDNoTemp = UserIDNo;
                OpenFileDialog dosya = new OpenFileDialog();
                dosya.Filter = "Resim Dosyası |*.jpg;*.nef;*.png |  Tüm Dosyalar |*.*";
                dosya.ShowDialog();
                string dosyayolu = dosya.FileName;
                aciklama.Text = dosyayolu;
                UrunEkleResim2.ImageLocation = dosyayolu;
                UrunEkleResim2.Visible = true;
                tempPicNo++;
            }
            else if (tempPicNo == 2)
            {
                int UsersIDNoTemp;
                UsersIDNoTemp = UserIDNo;
                OpenFileDialog dosya = new OpenFileDialog();
                dosya.Filter = "Resim Dosyası |*.jpg;*.nef;*.png |  Tüm Dosyalar |*.*";
                dosya.ShowDialog();
                string dosyayolu = dosya.FileName;
                aciklama.Text = dosyayolu;
                UrunEkleResim3.ImageLocation = dosyayolu;
                UrunEkleResim3.Visible = true;
                tempPicNo++;
            }
            else
            {
                MessageBox.Show("Daha fazla fotograf ekleyemezsiniz!");
            }
        }

        private void kategori_cek()
        {
            
        }

        private void tabPage11_Click(object sender, EventArgs e)
        {

        }

        private void cat1_Click(object sender, EventArgs e)
        {
            UrunListele.Visible = false;
            AltKategoriSec.Visible = true;

            TABLO.SelectedIndex = 0;

            CategoryID = 1;
            atama(CategoryID);
            SolTus.Text = SubCategoryName1;
            SagTus.Text = SubCategoryName2;
            onay = false;
            onay_butt.Visible = false;
            sil_butt.Visible = false;
        }

        private void cat2_Click(object sender, EventArgs e)
        {
            UrunListele.Visible = false;
            AltKategoriSec.Visible = true;
            TABLO.SelectedIndex = 0;
            CategoryID = 2;
            atama(CategoryID);
            SolTus.Text = SubCategoryName1;
            SagTus.Text = SubCategoryName2;
            onay = false;
            onay_butt.Visible = false;
            sil_butt.Visible = false;
        }

        private void cat3_Click(object sender, EventArgs e)
        {
            UrunListele.Visible = false;
            AltKategoriSec.Visible = true;
            TABLO.SelectedIndex = 0;
            CategoryID = 3;
            atama(CategoryID);
            SolTus.Text = SubCategoryName1;
            SagTus.Text = SubCategoryName2;
            onay = false;
            onay_butt.Visible = false;
            sil_butt.Visible = false;
        }

        private void cat4_Click(object sender, EventArgs e)
        {
            UrunListele.Visible = false;
            AltKategoriSec.Visible = true;
            TABLO.SelectedIndex = 0;
            CategoryID = 4;
            atama(CategoryID);
            SolTus.Text = SubCategoryName1;
            SagTus.Text = SubCategoryName2;
            onay = false;
            onay_butt.Visible = false;
            sil_butt.Visible = false;
        }

        private void cat5_Click(object sender, EventArgs e)
        {
            UrunListele.Visible = false;
            AltKategoriSec.Visible = true;
            TABLO.SelectedIndex = 0;
            CategoryID = 5;
            atama(CategoryID);
            SolTus.Text = SubCategoryName1;
            SagTus.Text = SubCategoryName2;
            onay = false;
            onay_butt.Visible = false;
            sil_butt.Visible = false;
        }

        private void cat6_Click(object sender, EventArgs e)
        {
            UrunListele.Visible = false;
            AltKategoriSec.Visible = true;
            TABLO.SelectedIndex = 0;
            CategoryID = 6;
            atama(CategoryID);
            SolTus.Text = SubCategoryName1;
            SagTus.Text = SubCategoryName2;
            onay = false;
            onay_butt.Visible = false;
            sil_butt.Visible = false;
        }

        private void cat7_Click(object sender, EventArgs e)
        {
            UrunListele.Visible = false;
            AltKategoriSec.Visible = true;
            TABLO.SelectedIndex = 0;
            CategoryID = 7;
            atama(CategoryID);
            SolTus.Text = SubCategoryName1;
            SagTus.Text = SubCategoryName2;
            onay = false;
            onay_butt.Visible = false;
            sil_butt.Visible = false;
        }

        private void cat8_Click(object sender, EventArgs e)
        {
            UrunListele.Visible = false;
            AltKategoriSec.Visible = true;
            TABLO.SelectedIndex = 0;
            CategoryID = 8;
            atama(CategoryID);
            SolTus.Text = SubCategoryName1;
            SagTus.Text = SubCategoryName2;
            onay = false;
            onay_butt.Visible = false;
            sil_butt.Visible = false;
        }

        private EPRODUCT urun_yazdir(int a,int b)
        {
            return BLLPRODUCT.urun_yazdir(a,b);
        }

        private EPICTURE resim_yolu(int a)
        {
            return BLLPICTURE.resim_yolu(a);
        }
        private void atama(int CatID)
        {
            EKATEGORI get_SubCatId = new EKATEGORI();
            List<EKATEGORI> get_SubCatId2 = BLLKATEGORI.get_SubCatIdFonk(get_SubCatId, CatID);

            SubCategoryID1 = get_SubCatId2[0].ID;
            SubCategoryName1 = get_SubCatId2[0].Name;

            SubCategoryID2 = get_SubCatId2[1].ID;
            SubCategoryName2 = get_SubCatId2[1].Name;
        }
        private void sayfalandirma(int sayfano,int solSag)
        {
            
            int sayfanum = sayfano;
            if (solSag == 1)
                solSag = 2 * CategoryID - 1;
            else
                solSag = 2 * CategoryID;
            sayfanum =sayfanum + (sayfanum - 1) * 2;
            EPRODUCT deger = urun_yazdir(sayfanum,solSag);//sayfa no
            UrunAdiArabalar1.Text = deger.Name;
            UrunFiyatiArabalar1.Text = deger.Price.ToString();
            int UrunId = Convert.ToInt32(deger.ID);
            temp_UrunID = Convert.ToInt32(deger.ID);
            TempUsersID.Text = deger.UsersID.ToString();

            EPICTURE resim1 = resim_yolu(UrunId);
            picAraba1.ImageLocation = resim1.PicDirectory;

            EPRODUCT deger2 = urun_yazdir(sayfanum+1,solSag);
            UrunAdiArabalar2.Text = deger2.Name;
            UrunFiyatiArabalar2.Text = deger2.Price.ToString();
            int UrunId2 = Convert.ToInt32(deger2.ID);
            temp_UrunID2 = Convert.ToInt32(deger2.ID);
            TempUsersID2.Text = deger2.UsersID.ToString();

            EPICTURE resim2 = resim_yolu(UrunId2);
            picAraba2.ImageLocation = resim2.PicDirectory;

        }

        private void panel11_Paint(object sender, PaintEventArgs e)
        {

        }

        private void SolTus_Click(object sender, EventArgs e)
        {
            AltKategoriSec.Visible = false;
            UrunListele.Visible = true;
            sayfalandirma(1,SubCategoryID1);

            int satir_sayisi = BLLKATEGORI.sayfa_sayisi(SubCategoryID1);
            satir_sayisi = satir_sayisi / 2;
            temp_sayfa_sayisi = satir_sayisi;
            sayfa_numara_bilgisi(satir_sayisi);
            sol1sag2 = 1;

        }

        private void SagTus_Click(object sender, EventArgs e)
        {
            AltKategoriSec.Visible = false;
            UrunListele.Visible = true;
            sayfalandirma(1, SubCategoryID2);
            int satir_sayisi = BLLKATEGORI.sayfa_sayisi(SubCategoryID2);

            sol1sag2 = 2;
        }

        private void sayfa_numara_bilgisi(int sayfa_sayisi)
        {
            if (sayfa_sayisi == 1)
            {
                ikinci.Visible = false;
                ucuncu.Visible = false;
            }
            else if (sayfa_sayisi == 2)
            {
                ikinci.Visible = true;
                ucuncu.Visible = false;
            }
            else if (sayfa_sayisi  > 3)
            {
                ikinci.Visible = true;
                ucuncu.Visible = true;
            }

            enson.Text = ">>(" + sayfa_sayisi+")";
        }

        private void enbas_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if(sol1sag2 == 1)
                sayfalandirma(1,SubCategoryID1);
            else
                sayfalandirma(1, SubCategoryID2);
        }

        private void enson_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (sol1sag2 == 1)
                sayfalandirma(temp_sayfa_sayisi, SubCategoryID1);
            else
                sayfalandirma(temp_sayfa_sayisi, SubCategoryID2);
        }

        private void birinci_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            int temp = Convert.ToInt32(birinci.Text);
            if (sol1sag2 == 1)
                sayfalandirma(temp, SubCategoryID1);
            else
                sayfalandirma(temp, SubCategoryID2);
            if (temp != 1)
            {
                birinci.Text = (temp - 1).ToString();
                ikinci.Text = (temp).ToString();
                ucuncu.Text = (temp + 1).ToString();
            }
        }

        private void ikinci_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            int temp = Convert.ToInt32(ikinci.Text);
            if (sol1sag2 == 1)
                sayfalandirma(temp, SubCategoryID1);
            else
                sayfalandirma(temp, SubCategoryID2);
        }

        private void ucuncu_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            int temp = Convert.ToInt32(ucuncu.Text);
            if (sol1sag2 == 1)
                sayfalandirma(temp, SubCategoryID1);
            else
                sayfalandirma(temp, SubCategoryID2);

            if (temp_sayfa_sayisi > temp)
            {
                birinci.Text = (temp - 1).ToString();
                ikinci.Text = (temp).ToString();
                ucuncu.Text = (temp + 1).ToString();
            }
        }

        private void solkay_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            int temp = Convert.ToInt32(birinci.Text);
            if (sol1sag2 == 1)
                sayfalandirma(temp, SubCategoryID1);
            else
                sayfalandirma(temp, SubCategoryID2);
            if (temp != 1)
            {
                birinci.Text = (temp - 1).ToString();
                ikinci.Text = (temp).ToString();
                ucuncu.Text = (temp + 1).ToString();
            }
        }

        private void sagkay_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            int temp = Convert.ToInt32(ucuncu.Text);
            if (sol1sag2 == 1)
                sayfalandirma(temp, SubCategoryID1);
            else
                sayfalandirma(temp, SubCategoryID2);
            if (temp_sayfa_sayisi > 3)
            {
                if (temp_sayfa_sayisi > temp)
                {
                    birinci.Text = (temp - 1).ToString();
                    ikinci.Text = (temp).ToString();
                    ucuncu.Text = (temp + 1).ToString();
                }
            }
            if (temp != temp_sayfa_sayisi && sol1sag2==1)
            {
                sayfalandirma(temp, SubCategoryID1);
            }
            if (temp != temp_sayfa_sayisi && sol1sag2 == 2)
            {
                sayfalandirma(temp, SubCategoryID2);
            }
        }

        private void label14_Click(object sender, EventArgs e)
        {

        }

        private void incele1_Click(object sender, EventArgs e)
        {
            TABLO.SelectedIndex = 1;
            //if(sol1sag2==1)
            EPICTURE resim1 = resim_yolu(temp_UrunID);
            UrunAlPic.ImageLocation = resim1.PicDirectory;

            urunID.Text = temp_UrunID.ToString();
            UsersID.Text = TempUsersID.Text;
            tempurunID1.Text = temp_UrunID.ToString();

            EPRODUCT deger = BLLPRODUCT.urun_listele(temp_UrunID);//sayfa no
            urun_ad.Text = deger.Name;
            urun_fiyat.Text = deger.Price.ToString();

            EUSERS deger2 = BLLUSERS.kullanici_ismi(Convert.ToInt32(UsersID.Text));
            urun_sahibi.Text = "(" + deger2.Username + ") " + deger2.Name + " " + deger2.Surname;
        }

        private void urunincele_Paint(object sender, PaintEventArgs e)
        {

        }

        private void satin_al_button_Click(object sender, EventArgs e)
        {

        }

        private void Ayarlar_Click(object sender, EventArgs e)
        {
            TabloUst.SelectedIndex = 4;
            arayuzayar.SelectedIndex = 0;
            kullanici_arayuz_bilgi();

        }
        private void kullanici_arayuz_bilgi()
        {
            EUSERS item = BLLUSERS.kullanici_ismi(UserIDNo);
            Akullaniciadi.Text = item.Username;
            Aadi.Text = item.Name;
            Asoyadi.Text = item.Surname;
            Aemail.Text = item.Email;
            int temp = item.Mode;
            if (temp == 0)
            {
                Apozisyon.Text = "Normal kullanici";
            }
            else if (temp == 1)
            {
                Apozisyon.Text = "Calisan uye";
            }
            else if (temp == 2)
            {
                Apozisyon.Text = "Admin";
            }
            ECARD item2 = BLLCARD.show_Card_item(UserIDNo);
            Abakiye.Text = item2.FakeBalance.ToString();

            EADDRESS item3 = BLLADDRESS.show_Address_item(UserIDNo);
            Acadde.Text = item3.Cadde;
            Asokak.Text = item3.Street;
            Ail.Text = item3.City;
            Ailce.Text = item3.Town;
            Ano.Text = item3.Num.ToString();

        }

        private void CardEkle_Click(object sender, EventArgs e)
        {
            int var1_yok0 = BLLCARD.Card_kontrol(UserIDNo);

            if(var1_yok0 == 1)
            {
                ECARD item = new ECARD();
                item.CardNo = Convert.ToInt32(Card_No.Text);
                item.SKT = Convert.ToInt32(SKT.Text);
                item.CCV = Convert.ToInt32(CCV.Text);
                item.FakeBalance = Convert.ToInt32(Fake_Balance.Text);
                item.UsersID = UserIDNo;

                if(BLLCARD.update_Card(item)== -1)
                {
                    MessageBox.Show("Ekleme hatasi");
                }
                    //update
            }
            else if(var1_yok0 == 0)
            {
                ECARD item = new ECARD();
                item.CardNo = Convert.ToInt32(Card_No.Text);
                item.SKT = Convert.ToInt32(SKT.Text);
                item.CCV = Convert.ToInt32(CCV.Text);
                item.FakeBalance = Convert.ToInt32(Fake_Balance.Text);
                item.UsersID = UserIDNo;

                if (BLLCARD.insert_Card(item) == -1)
                {
                    MessageBox.Show("Ekleme hatasi");
                }
                //insert
            }
            arayuzayar.SelectedIndex = 0;
            kullanici_arayuz_bilgi();
        }

        private void kart_ekle_buton_Click(object sender, EventArgs e)
        {
            arayuzayar.SelectedIndex = 1;
            ECARD item = BLLCARD.show_Card_item(UserIDNo);
            Card_No.Text = item.CardNo.ToString();
            SKT.Text = item.SKT.ToString();
            CCV.Text = item.CCV.ToString();
            Fake_Balance.Text = item.FakeBalance.ToString();


        }

        private void tabPage2_Click(object sender, EventArgs e)
        {

        }

        private void arayuzBilgiDuzenle_Click(object sender, EventArgs e)
        {
            arayuzayar.SelectedIndex = 2;
            EUSERS item = BLLUSERS.kullanici_ismi(UserIDNo);
            ARkullaniciadi.Text = item.Username;
            ARadi.Text = item.Name;
            ARsoyadi.Text = item.Surname;
            ARemail.Text = item.Email;
            int temp = item.Mode;
            if (temp == 0)
            {
                ARpozisyon.Text = "Normal kullanici";
            }
            else if (temp == 1)
            {
                ARpozisyon.Text = "Calisan uye";
            }
            else if (temp == 2)
            {
                ARpozisyon.Text = "Admin";
            }
            ECARD item2 = BLLCARD.show_Card_item(UserIDNo);
            ARbakiye.Text = item2.FakeBalance.ToString();

            EADDRESS item3 = BLLADDRESS.show_Address_item(UserIDNo);
            ARcadde.Text = item3.Cadde;
            ARsokak.Text = item3.Street;
            ARil.Text = item3.City;
            ARilce.Text = item3.Town;
            ARno.Text = item3.Num.ToString();
        }

        private void arayuz_bilgi_duzenle_Click(object sender, EventArgs e)
        {
            EUSERS item = new EUSERS();
            item.ID = UserIDNo;
            item.Username = ARkullaniciadi.Text;
            item.Name = ARadi.Text;
            item.Surname = ARsoyadi.Text;
            item.Email = ARemail.Text;

            BLLUSERS.update_user(item);

            EADDRESS item2 = new EADDRESS();
            item2.Cadde = ARcadde.Text;
            item2.Street = ARsokak.Text;
            item2.City = ARil.Text;
            item2.Town = ARilce.Text;
            item2.Num = Convert.ToInt32(ARno.Text);
            item2.UsersID = UserIDNo;

            BLLADDRESS.update_address(item2);
            arayuzayar.SelectedIndex = 0;
            kullanici_arayuz_bilgi();
        }

        private void ucretsiz_kayit_ol_Click(object sender, EventArgs e)
        {
            TabloUst.SelectedIndex = 2;
        }

        private void calisan_atama_Click(object sender, EventArgs e)
        {
            arayuzayar.SelectedIndex = 0;
            EUSERS item = new EUSERS();
            item.Username = secilen_kisi.Text;
            int kullanici_ID = BLLUSERS.User_ID_al(item.Username);

            if (atanacak_poz_combobox.Text == "Normal")
            {
                BLLUSERS.set_user_mode(kullanici_ID,0);
                //Employee tablosundan sil
            }
            else if(atanacak_poz_combobox.Text == "Calisan")
            {
                BLLUSERS.set_user_mode(kullanici_ID, 1);
                //Employee tablosuna ekle ID
            }
            else if (atanacak_poz_combobox.Text == "Yonetici")
            {
                BLLUSERS.set_user_mode(kullanici_ID, 2);
                //Employe tablosundan sil
            }
            



        }

        private void calisan_ata_button_Click(object sender, EventArgs e)
        {
            DataTable dt = BLLUSERS.calisan_ata_fonk();
            kisi_sec_combobox.DataSource = dt;
            kisi_sec_combobox.DisplayMember = "Username";
            kisi_sec_combobox.ValueMember = "Username";
            kisi_sec_combobox.Refresh();
            kisi_sec_combobox.Text = null;
            
    
            DataTable dt2 = BLLSUBCATEGORY.kategori_ata_fonk();
            kategori_sec_combobox.DataSource = dt2;
            kategori_sec_combobox.DisplayMember = "Name";
            kategori_sec_combobox.ValueMember = "ID";
            kategori_sec_combobox.Refresh();
            kategori_sec_combobox.Text = null;

            kategori_sec_label.Visible = false;
            kategori_sec_combobox.Visible = false;
            calis_kategori_label.Visible = false;
            kategorisi.Visible = false;
            

    
            arayuzayar.SelectedIndex = 3;
        }

        private void kisi_sec_combobox_SelectedIndexChanged(object sender, EventArgs e)
        {
            secilen_kisi.Text = kisi_sec_combobox.Text.ToString();
            string kullanici_adi = kisi_sec_combobox.Text.ToString();
            int mode = BLLUSERS.get_user_mode(kullanici_adi);
            if (mode == 0)
            {
                mevcut_pozisyon.Text = "Normal";
            }
            else if (mode == 1)
            {
                mevcut_pozisyon.Text = "Calisan";
            }
            else if (mode == 2)
            {
                mevcut_pozisyon.Text = "Yonetici";
            }
        }

        private void kategori_sec_combobox_SelectedIndexChanged(object sender, EventArgs e)
        {
            kategorisi.Text = kategori_sec_combobox.Text.ToString();
        }

        private void atanacak_poz_combobox_SelectedIndexChanged(object sender, EventArgs e)
        {
            atama_pozisyonu.Text = atanacak_poz_combobox.Text.ToString();
            if (atanacak_poz_combobox.Text == "Normal" || atanacak_poz_combobox.Text == "Yonetici") {
                kategori_sec_label.Visible = false;
                kategori_sec_combobox.Visible = false;
                calis_kategori_label.Visible = false;
                kategorisi.Visible = false;
            }
            else
            {
                kategori_sec_label.Visible = true;
                kategori_sec_combobox.Visible = true;
                calis_kategori_label.Visible = true;
                kategorisi.Visible = true;
            }

        }

        private void kategori_altkategori_listele_SelectedIndexChanged(object sender, EventArgs e)
        {
            int indis = kategori_altkategori_listele.SelectedIndex+1;
            List<ESUBCATEGORY> alt_kategorisi = BLLSUBCATEGORY.SubCategory_Listele(indis);

            altkategorilist.DataSource = alt_kategorisi;
            altkategorilist.ValueMember = "ID";
            altkategorilist.DisplayMember = "Name";
            altkategorilist.Text = null;


        }

        private void Onay_button_Click(object sender, EventArgs e)
        {
            UrunListele.Visible = true;
            AltKategoriSec.Visible = false;
            TABLO.SelectedIndex = 0;
            onay = true;

            int calisan_kategori_ID = BLLUSERS.get_calisan_kategori_ID(UserIDNo);

            sayfalandirma_onay(1, calisan_kategori_ID);

            onay_butt.Visible = true;
            sil_butt.Visible = true;
            //Bakilacak!!
            /*int satir_sayisi = BLLKATEGORI.sayfa_sayisi(calisan_kategori_ID);
            satir_sayisi = satir_sayisi / 2;
            temp_sayfa_sayisi = satir_sayisi;
            sayfa_numara_bilgisi_onay(satir_sayisi);//will edit
            //sol1sag2 = 1;*/
        }
        /*private EPRODUCT urun_yazdir_onay(int a,int calisan_kategori_ID)
        {
            return BLLPRODUCT.urun_yazdir_onay(a,calisan_kategori_ID);
        }*/
        private void sayfalandirma_onay(int sayfano, int calisan_kategori_ID)
        {/*
            int sayfanum1 = 2*sayfano-1;
            int sayfanum2 = 2 * sayfano;
            EPRODUCT deger = urun_yazdir_onay(sayfanum1,calisan_kategori_ID);//sayfa no
            UrunAdiArabalar1.Text = deger.Name;
            UrunFiyatiArabalar1.Text = deger.Price.ToString();
            int UrunId = Convert.ToInt32(deger.ID);
            temp_UrunID = Convert.ToInt32(deger.ID);
            tempurunID1.Text = deger.ID.ToString();
            TempUsersID.Text = deger.UsersID.ToString();

            EPICTURE resim1 = resim_yolu(UrunId);
            picAraba1.ImageLocation = resim1.PicDirectory;

            EPRODUCT deger2 = urun_yazdir_onay(sayfanum2,calisan_kategori_ID);
            UrunAdiArabalar2.Text = deger2.Name;
            UrunFiyatiArabalar2.Text = deger2.Price.ToString();
            int UrunId2 = Convert.ToInt32(deger2.ID);
            temp_UrunID2 = Convert.ToInt32(deger2.ID);
            tempurunID2.Text = deger2.ID.ToString(); 
            TempUsersID2.Text = deger2.UsersID.ToString();

            EPICTURE resim2 = resim_yolu(UrunId2);
            picAraba2.ImageLocation = resim2.PicDirectory;
            */
        }

        private void onay_butt_Click(object sender, EventArgs e)
        {/*
            int urunun_ID = Convert.ToInt32(tempurunID1.Text);
            BLLPRODUCT.urun_onayla(urunun_ID);
            Onay_button_Click(Onay_button, new EventArgs());
            */
        }

        private void sil_butt_Click(object sender, EventArgs e)
        {/*
            int urunun_ID = Convert.ToInt32(tempurunID2.Text);
            BLLPRODUCT.urun_sil(urunun_ID);
            Onay_button_Click(Onay_button, new EventArgs());
            */
        }

        private void button3_Click(object sender, EventArgs e)
        {
            TabloUst.SelectedIndex = 2;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            TabloUst.SelectedIndex = 3;
        }
    }
}
