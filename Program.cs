using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace _1.AdoNetGiris
{
     class Program
    {
        static SqlConnection conWindows = new SqlConnection(@"Data Source=DESKTOP-3EG2MU0\SQLEXPRESS;Initial Catalog=adonet;Integrated Security=True");
        static void Main(string[] args)
        {

            
            Console.WriteLine();

            //kayitlariGetir();
            kayitGuncelle(5, "ertan");
        
        }
        public static void kayitlariGetir()
        {
            List<musteri> musteriList = new List<musteri>();
             
            conWindows.Open();
            SqlCommand cmd = new SqlCommand("select * from logintable", conWindows);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                musteri musteri = new musteri();
                musteri.id = int.Parse(dr["id"].ToString());
                musteri.kullaniciAdi = dr["kullaniciAdi"].ToString();
                musteri.sifre = dr["sifre"].ToString();
                musteri.yetki = dr["yetki"].ToString();
                musteriList.Add(musteri);
            }

            foreach (musteri musteri in musteriList)
            {
                Console.WriteLine("Id:" + musteri.id + " Kullanıcı Adı:" + musteri.kullaniciAdi + " Şifre:" + musteri.sifre + " Yetki:" + musteri.yetki);
            }
            conWindows.Close();
            Console.ReadLine();
        }
    
        public static void kayitEkle(string kullaniciAdi,string sifre,string yetki)
        {
            conWindows.Open();
            SqlCommand cmd = new SqlCommand("insert into logintable(kullaniciAdi,sifre,yetki) values(@kulad,@sifre,@yetki)",conWindows);
            cmd.Parameters.AddWithValue("@kulad", kullaniciAdi);
            cmd.Parameters.AddWithValue("@sifre", sifre);
            cmd.Parameters.AddWithValue("@yetki", yetki);

            int donenDeger= cmd.ExecuteNonQuery();

            if(donenDeger==1)
            {
                Console.WriteLine("Kayıt Eklenmiştir");
            }
            else
            {
                Console.WriteLine("Kayıt eklenirken bir sorun oluştu");
            }
            conWindows.Close();
        }

        public static  void kayitGuncelle(int id,string kullaniciAdi)
        {
            conWindows.Open();
            SqlCommand cmd = new SqlCommand("update logintable set kullaniciAdi=@kulad where id=@id", conWindows);

            cmd.Parameters.AddWithValue("@kulad", kullaniciAdi);
            cmd.Parameters.AddWithValue("@id", id);
            int donenDeger=cmd.ExecuteNonQuery();

            if(donenDeger==1)
            {
                Console.WriteLine("Kayıt Güncellendi.");
            }
            else 
            {
                Console.WriteLine("Kayıt güncellenirken bir hata oluştu.");
            }
            conWindows.Close();
            Console.ReadLine();



        }
    
    
    
    
    
    
    
    
    }
}
