using CA231126;

static List<Laptop> Feladat7(List<Laptop> laptopok) 
{
    return laptopok
        .Where(l => l.Oprendszer.StartsWith("Windows") == false && l.suly >= 2)
        .ToList();
}
static void Feladat8(List<Laptop> laptopok) 
{
    var gyengeAksi = laptopok
        .Where(l => l.Aksi == laptopok.Min(k => k.Aksi))
        .ToList();

    gyengeAksi.ForEach(x => Console.WriteLine(x));
    Console.WriteLine($"{gyengeAksi.Count} db ilyen laptop van, legkevesebb üzeimdő pontosan: {gyengeAksi[0].Aksi}");
}
static double Feladat9(List<Laptop> laptopok) 
{
    return laptopok.Average(l => l.ProcesszorSeb);
}
static List<string> Feladat10(List<Laptop> laptopok)
{
    var Bluetooth5pont2 = laptopok
    .SelectMany(l => l.VezetékNelkuli, (a, k) => new { Gyarto = a.Gyarto, Kapcsolat = k })
    .Where(k => k.Kapcsolat == " Bluetooth 5.2")
    .DistinctBy(a => a.Gyarto)
    .OrderBy(a => a.Gyarto)
    .Select(a => a.Gyarto)
    .ToList();

    return Bluetooth5pont2;
}
static List<int> Feladat11(List<Laptop> laptopok) 
{
    return laptopok
        .Where(l => l.ProcesszorString.StartsWith("AMD") && l.suly > 1.3)
        .Select(l => l.Azonosito)
        .ToList();
}
static void Kiiras(List<Laptop> laptopok) 
{
    StreamWriter sw = new(@"..\..\..\src\laptopokUj.txt");
    laptopok.ForEach(l => sw.WriteLine($"Processzor típusa és sebessége: {l.ProcesszorString}, Súlya: {l.kgToGramm()} gramm"));
    sw.Close();
}

List<Laptop> laptopok = new();
StreamReader sr = new(@"..\..\..\src\laptopok.txt");

_ = sr.ReadLine();
while (!sr.EndOfStream)
{
    laptopok.Add(new Laptop(sr.ReadLine()));
}

laptopok.ForEach(x => Console.WriteLine(x));

Console.WriteLine("7. feladat:");
List<Laptop> Feladat7List = Feladat7(laptopok);
Console.WriteLine($"\t{Feladat7List.Count} db ilyen van");

Console.WriteLine("\n8. feladat:\n");
Feladat8(laptopok);

Console.WriteLine("\n9. feladat:");
Console.WriteLine($"\t{Feladat9(laptopok)} az átlagos processzor sebesség");

Console.WriteLine("\n10. feladat:");
List<string> feladat10 = Feladat10(laptopok);
try
{
    feladat10.ForEach(x => Console.WriteLine($"\t {x}"));
}
catch
{
    Console.WriteLine("\tNincsen a keresettnek megfelelő laptop!");
}

Console.WriteLine("\n11. feladat:");
Console.Write("\tAzonosítók: ");
Feladat11(laptopok).ForEach(l => Console.Write($"{l}, "));

Console.WriteLine("\n13. feladat:");
try
{
    Kiiras(laptopok);
    Console.WriteLine("\tFájl elkészült!");
}
catch
{
    Console.WriteLine("Hiba a fájlba kiírás során!");
}

Console.ReadKey();