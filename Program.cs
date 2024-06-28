using System.Net;
using System.Net.Sockets;

namespace domaincheck;

class Program
{
    public static string[] AllEndings => StandardEndings.Concat(ShopEndings).Concat(CountryEndings).Concat(Other).ToArray();
    public static string[] StandardEndings = [
        "com",
        "net",
        "org",
        "io",
        "app",
        "ai",
        "online",
        "tech",
        "me",
    ];
    public static string[] ShopEndings = [
        "shop",
        "store",
    ];
    public static string[] CountryEndings = [
        "eu",
        "us",
        "uk",
        "de",
        "ru",
        "ua",
        "au",
        "cz",
        "be",
        "ca",
        "cf",
        "sk",
        "cg",
        "fi",
        "fr",
        "gl",
        "hk",
        "jp",
        "ml",
        "nz",
    ];
    public static string[] Other = [
        "blog",
        "company",
        "cool",
        "country",
        "coupons",
        "dentist",
        "earth",
        "edu",
        "email",
        "energy",
        "gift",
        "life",
        "link",
        "media",
        "menu",
        "movie",
        "network",
        "porn",
        "repair",
        "report",
        "run",
        "sale",
        "school",
        "science",
        "search",
        "secure",
        "security",
        "sex",
        "software",
        "solar",
        "song",
        "space",
        "today",
        "toys",
        "travel",
        "video",
        "vip",
        "watch",
        "website",
        "weather",
        "webcam",
        "wiki",
        "work",
        "xxx",
        "xyz",
        "zip",
    ];

    static void Main(string[] args)
    {
        if (args.Length <= 0)
        {
            Console.WriteLine("You must provide an argument");
            return;
        }

        string arg = args[0];

        string name = arg.Remove(arg.IndexOf("."));

        string[] domainEndings = arg.Remove(0, arg.IndexOf(".") + 1).Split("+.");

        if (arg.EndsWith(".@"))
        {
            domainEndings = AllEndings;
            Console.WriteLine("Using 'ALL' wildcard -> using " + domainEndings.Length + " domain endings");
        }
        else if (arg.EndsWith(".#"))
        {
            domainEndings = StandardEndings;
            Console.WriteLine("Using 'STANDARD' wildcard -> using " + domainEndings.Length + " domain endings");
        }
        else if (arg.EndsWith(".$"))
        {
            domainEndings = ShopEndings;
            Console.WriteLine("Using 'SHOP' wildcard -> using " + domainEndings.Length + " domain endings");
        }
        else if (arg.EndsWith(".!"))
        {
            domainEndings = CountryEndings;
            Console.WriteLine("Using 'COUNTRY' wildcard -> using " + domainEndings.Length + " domain endings");
        }
        else if (arg.EndsWith("._"))
        {
            domainEndings = Other;
            Console.WriteLine("Using 'OTHER' wildcard -> using " + domainEndings.Length + " domain endings");
        }

        foreach (string ending in domainEndings)
        {
            Console.ResetColor();

            if (!AllEndings.Contains(ending))
            {
                Console.Write(name + "." + ending + ": ");
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine("Unsupported ending");
                continue;
            }

            Console.Write(name + "." + ending + ": ");
            if (DomainExists(name + "." + ending))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Exists");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Free");
            }
        }
    }

    public static bool DomainExists(string domain)
    {
        try
        {
            IPHostEntry entry = Dns.GetHostEntry(domain);
            return true;
        }
        catch (SocketException)
        {
            return false;
        }
    }
}