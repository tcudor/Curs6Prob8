
class Jucator
{
    public string Nume { get; set; }
    public string Tara { get; set; }
    public double Punctaj { get; set; }

    public Jucator(string nume, string tara, double punctaj)
    {
        Nume = nume;
        Tara = tara;
        Punctaj = punctaj;
    }
}

class Program
{
    static List<Jucator> jucatori = new List<Jucator>();

    static void Main()
    {
        AdaugaJucatori();

        while (true)
        {
            Console.WriteLine("\nAlege o optiune:");
            Console.WriteLine("1. Lista participantilor in ordine alfabetica a numelor");
            Console.WriteLine("2. Lista participantilor in ordine alfabetica a tarii");
            Console.WriteLine("3. Lista participantilor in ordine descrescatoare a punctajului");
            Console.WriteLine("0. Iesire");

            string optiune = Console.ReadLine();

            switch (optiune)
            {
                case "1":
                    AfiseazaJucatoriAlfabeticNume();
                    break;
                case "2":
                    AfiseazaJucatoriAlfabeticTara();
                    break;
                case "3":
                    AfiseazaJucatoriDescrescatorPunctaj();
                    break;
                case "0":
                    return;
                default:
                    Console.WriteLine("Optiune invalida. Te rog sa alegi din nou.");
                    break;
            }
        }
    }

    static void AdaugaJucatori()
    {
        Console.Write("Introduceti numarul de participanti: ");
        if (int.TryParse(Console.ReadLine(), out int numarParticipanti))
        {
            for (int i = 0; i < numarParticipanti; i++)
            {
                Console.WriteLine($"Participantul #{i + 1}:");
                Console.Write("Nume: ");
                string nume = Console.ReadLine();
                Console.Write("Tara: ");
                string tara = Console.ReadLine();
                Console.Write("Punctaj (de la 1 la 10): ");
                if (double.TryParse(Console.ReadLine(), out double punctaj) && punctaj >= 1 && punctaj <= 10)
                {
                    Jucator jucator = new Jucator(nume, tara, punctaj);
                    jucatori.Add(jucator);
                }
                else
                {
                    Console.WriteLine("Punctajul trebuie sa fie un numar real intre 1 și 10. Incearca din nou.");
                    i--;
                }
            }
        }
        else
        {
            Console.WriteLine("Te rog sa introduci un numar valid.");
        }
    }

    static void AfiseazaJucatoriAlfabeticNume()
    {
        List<Jucator> jucatoriAlfabeticNume = jucatori.OrderBy(j => j.Nume).ToList();
        AfiseazaJucatori(jucatoriAlfabeticNume, "Lista participantilor in ordine alfabetica a numelor:");
    }

    static void AfiseazaJucatoriAlfabeticTara()
    {
        List<Jucator> jucatoriAlfabeticTara = jucatori.OrderBy(j => j.Tara).ToList();
        AfiseazaJucatori(jucatoriAlfabeticTara, "Lista participantilor in ordine alfabetica a tarii:");
    }

    static void AfiseazaJucatoriDescrescatorPunctaj()
    {
        List<Jucator> jucatoriDescrescatorPunctaj = jucatori.OrderByDescending(j => j.Punctaj).ToList();
        AfiseazaJucatori(jucatoriDescrescatorPunctaj, "Lista participantilor in ordine descrescatoare a punctajului:");
    }

    static void AfiseazaJucatori(List<Jucator> jucatori, string titlu)
    {
        Console.WriteLine(titlu);
        Console.WriteLine("---------------------------------------------------");
        Console.WriteLine("Nume\tTara\tPunctaj");
        Console.WriteLine("---------------------------------------------------");

        foreach (var jucator in jucatori)
        {
            Console.WriteLine($"{jucator.Nume}\t{jucator.Tara}\t{jucator.Punctaj}");
        }
    }
}
