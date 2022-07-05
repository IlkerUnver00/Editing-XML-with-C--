// See https://aka.ms/new-console-template for more information

using System.Xml.Linq;

void XMLRead()
{
    XDocument xDoc = XDocument.Load(@"C:\..\XMLFile1.xml"); 
    //Xml dosyası ila bağlantı kuruluyor.

    XElement rootElement = xDoc.Root;
    //Oluşturduğumuz Root elementine XML dökümanında ki root elementini seçmesini sağlıyoruz.

    String AD, Email, Tel, ID;

    foreach (XElement rehberimiz in rootElement.Elements())
    //Foreach ile okudumuz root tagları arasındaki Rehber Elementi içinde dönüyoruz ver verileri okumaya başlıyoruz.
    {
        ID = rehberimiz.Attribute("id").Value;
        AD = rehberimiz.Element("kisi_Adı").Value;
        Email = rehberimiz.Element("kisi_EMail").Value;
        Tel = rehberimiz.Element("kisi_Tel").Value;
        
        Console.Write("ID: " + ID + " AD: " + AD + " Email: " + Email + " Tel: " + Tel);
        Console.WriteLine("\n");
    }
}

void XMLInsert()
{
    XDocument xDoc = XDocument.Load(@"C:\..\XMLFile1.xml");
    //Xml dosyası ila bağlantı kuruluyor.

    XElement rootElement = xDoc.Root;
    //Oluşturduğumuz Root elementine XML dökümanında ki root elementini seçmesini sağlıyoruz.

    XElement newElement = new XElement("rehber");

    XAttribute idAttribute = new XAttribute("id", "4");
    

    XElement adiElement = new XElement("kisi_Adı", "Ömer&nbsp;Şakir");
    XElement telefonElement = new XElement("kisi_Tel", "0555*******");
    XElement emailElement = new XElement("kisi_EMail", "omer@hotmail.com");

    newElement.Add(idAttribute, adiElement, telefonElement, emailElement);

    rootElement.Add(newElement);

    xDoc.Save(@"C:\..\XMLFile1.xml");
}

void XMLUpdate()
{
    XDocument xDoc = XDocument.Load(@"C:\..\XMLFile1.xml");
    //Xml dosyası ila bağlantı kuruluyor.

    XElement rootElement = xDoc.Root;

    foreach (XElement rehberimiz in rootElement.Elements())
    {

        if (rehberimiz.Attribute("id").Value == "1")
        {
            rehberimiz.Element("kisi_Adı").Value = "Selim";
            break;
        }
    }
    xDoc.Save(@"C:\..\XMLFile1.xml");
}

void XMLDelete()
{
    XDocument xDoc = XDocument.Load(@"C:\..\XMLFile1.xml");
    //Xml dosyası ila bağlantı kuruluyor.

    XElement rootElement = xDoc.Root;

    foreach (XElement rehberimiz in rootElement.Elements())
    {
        if (rehberimiz.Attribute("id").Value == "2");
        {
            rehberimiz.Remove();
        }
    }
    xDoc.Save(@"C:\..\XMLFile1.xml");
}

int cho;

while (true)
{
    Console.WriteLine("Dokuman islemleri:\n");
    Console.WriteLine("Dokuman Okuma = 1\n");
    Console.WriteLine("Dokuman Ekleme = 2\n");
    Console.WriteLine("Dokuman Silme = 3\n");
    Console.WriteLine("Dokuman Guncelleme = 4\n");
    Console.WriteLine("Cikis = 0");
    cho = Convert.ToInt32(Console.ReadLine());

    switch (cho)
    {
        case 1:
            XMLRead();
            break;
        case 2:
            XMLInsert();
            break;
        case 3:
            XMLDelete();
            break;
        case 4:
            XMLUpdate();
            break;
    }
    if (cho == 0)
        break;

}