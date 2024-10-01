/* DT071G Moment 3. En konsolapplikation för en gästbok. Av Adela Knap */
using static System.Console;  // För att slippa skriva Console framför Write/WriteLine

namespace mom3
{
    class Program
    {
        static void Main(string[] args)
        {
            // Skapa nytt objekt av klassen Guestbook
            Guestbook guestbook = new();

            // While-loop för att fortsätta köra applikationen tills den avslutas
            while (true)
            {
                Clear();    // Rensa konsolen
                WriteLine("A D E L A S  G Ä S T B O K\n");
                WriteLine("1. Skapa nytt inlägg");
                WriteLine("2. Ta bort inlägg");
                WriteLine("X. Avsluta\n");
                WriteLine("Aktuella inlägg i gästboken:");

                // Skriv ut inläggen
                guestbook.ShowPosts();

                Write("\nVälj vad du vill göra: ");

                // Användarens val
                string? choice = ReadLine();

                if (string.IsNullOrWhiteSpace(choice))  // Kontroll för null eller tom inmatning
                {
                    WriteLine("Felaktigt val. Tryck på valfri tangent för att testa igen!");
                    ReadKey();
                    continue;      // Fortsätt loopen om det är fel inmatning
                }

                // Switch-sats för de olika valen
                switch (choice.ToLower())
                {
                    case "1":
                        Clear();       // Rensa konsolen

                        string? inputName;
                        string? inputMessage;

                        Write("Ange ditt namn: ");

                        // Kör så länge inte användare anger ett "riktigt" namn
                        while (string.IsNullOrWhiteSpace(inputName = ReadLine()))
                        {
                            WriteLine("Det blev något fel, du måste ange ett namn. Testa igen!");
                            Write("Ange ditt namn: ");
                        }

                        Write("Skriv in ditt inlägg: ");
                        while (string.IsNullOrWhiteSpace(inputMessage = ReadLine()))     // Kör så länge inte användare anger ett "riktigt" inlägg
                        {
                            WriteLine("Det blev något fel, du måste skriva ett inlägg. Testa igen!");
                            Write("Skriv in ditt inlägg: ");
                        }

                        // Kör metoden för att skapa och spara
                        guestbook.AddPost(inputName, inputMessage);
                        break;

                    case "2":
                        Clear();

                        // Skriv ut alla inlägg för användaren ska kunna välja vilket att ta bort
                        guestbook.ShowPosts();

                        while (true) // Fortsätt tills giltig index
                        {
                            Write("\nAnge index att radera: ");

                            if (int.TryParse(ReadLine(), out int index))
                            {
                                // Kontrollera att index är rätt
                                if (index >= 0 && index < guestbook.GetPosts().Count)
                                {
                                    try
                                    {
                                        guestbook.DeletePost(index);  // Ta bort inlägget
                                        WriteLine("Inlägget har tagits bort. Tryck på valfri knapp för att återgå till menyn.");
                                        ReadKey();
                                        break;
                                    }
                                    catch (Exception)
                                    {
                                        WriteLine("Ett fel inträffade. Tryck på valfri knapp för att fortsätta.");
                                        ReadKey();
                                        break; // Avsluta loopen vid fel
                                    }
                                }
                                else
                                {
                                    WriteLine("Felaktigt val av index! Testa igen.");
                                }
                            }
                            else
                            {
                                WriteLine("Felaktigt val av index! Testa igen.");
                            }
                        }
                        break;

                    case "x":
                        Clear();
                        Environment.Exit(0);    // Avsluta programmet
                        break;

                    default:
                        WriteLine("Felaktigt val. Tryck på valfri tangent för att testa igen!");
                        ReadKey();
                        break;
                }
            }
        }
    }
}
