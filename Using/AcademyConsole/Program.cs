using AcademyConsole;


using MathLib matlhib = new MathLib();
/*using MathLib matlhib = GenerateMath();   BURADA TRUE GELİYOR!!!
matlhib.Show();*/


/*void Sum(){
    using MathLib matlhib = new MathLib();
    matlhib.Show();
}*/

using SqlDBConnection conStr = ConnectionDB();
conStr.Show();

Console.WriteLine(conStr.conncetion.State); //KAPANDIĞINDAN ARTIK BÖYLE OBJE OLMADIĞINDAN HATA FIRLATIR

//ConnectionDB();

MathLib GenerateMath()
{
    using MathLib matlhib = new MathLib();
    return matlhib;

    //USING BLOK ÇALIŞMASI BİTTİĞİ İÇİN BURADAYA ÇEVRİLİR !!!
    //BURADA USING BLOK İÇERİSİNDE ÇAIŞTIĞINI GÖZLEMLEDİK.
    // BU ŞEKİLDE ÇAĞIRMAK DOĞRU DEĞİL. AKAN KODDA ARADA USING OLUŞTURMAK HATALIDIR.


    // BURADA USING KISMINI SİLİP SADECE ÖRNEĞİ OLUŞTURUP, YUKARIYA VERİP ORADA NDEVAM EDERSE OKEY
}

SqlDBConnection ConnectionDB()
{
    using SqlDBConnection conn = new SqlDBConnection(tableName:"Users");

    Console.WriteLine(conn.conncetion.State);
    return conn;
}


//Console.WriteLine("Hello, World!");
