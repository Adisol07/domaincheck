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
        "dev",
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
    public static char[] PossibleCharacters = [
        'a',
        'b',
        'c',
        'd',
        'e',
        'f',
        'g',
        'h',
        'i',
        'j',
        'k',
        'l',
        'm',
        'n',
        'o',
        'p',
        'q',
        'r',
        's',
        't',
        'u',
        'v',
        'w',
        'x',
        'y',
        'z',
        '0',
        '1',
        '2',
        '3',
        '4',
        '5',
        '6',
        '7',
        '8',
        '9',
        '-'
    ];

    static void Main(string[] args)
    {
        // For readme
        // foreach (string ending in AllEndings)
        // {
        //     System.Console.WriteLine(" - " + ending);
        // }

        if (args.Length <= 0)
        {
            Console.WriteLine("You must provide at least one argument");
            return;
        }

        foreach (string arg in args)
        {
            string n = arg.Remove(arg.IndexOf("."));
            string[] names = GenerateCombinations(n, PossibleCharacters).ToArray();

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

            foreach (string name in names)
            {
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

            Console.ResetColor();
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

    public static List<string> GenerateCombinations(string input, char[] characters)
    {
        int at_count = input.Count(c => c == '@');

        List<string> combinations = new List<string>();
        GenerateCombinationsRecursive(input, characters, at_count, 0, new char[at_count], combinations);

        return combinations;
    }

    private static void GenerateCombinationsRecursive(
        string input,
        char[] characters,
        int atCount,
        int currentIndex,
        char[] currentCombination,
        List<string> combinations)
    {
        if (currentIndex == atCount)
        {
            string result = ReplaceAtSymbols(input, currentCombination);
            combinations.Add(result);
            return;
        }

        for (int i = 0; i < characters.Length; i++)
        {
            currentCombination[currentIndex] = characters[i];

            GenerateCombinationsRecursive(
                input,
                characters,
                atCount,
                currentIndex + 1,
                currentCombination,
                combinations
            );
        }
    }

    private static string ReplaceAtSymbols(string input, char[] replacementChars)
    {
        char[] result = input.ToCharArray();

        int char_index = 0;

        for (int i = 0; i < result.Length; i++)
        {
            if (result[i] == '@')
            {
                result[i] = replacementChars[char_index];
                char_index++;
            }
        }
        return new string(result);
    }
}
