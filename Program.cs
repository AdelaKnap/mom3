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

                WriteLine("\nVälj vad du vill göra: ");

                // Användarens val med ReadKey
                ConsoleKeyInfo keyInfo = ReadKey(true);
                char choice = keyInfo.KeyChar;

                // Switch-sats för de olika valen
                switch (char.ToLower(choice))
                {
                    case '1':
                        Clear();     // Rensa konsolen

                        string? inputName;
                        string? inputMessage;

                        Write("Ange ditt namn: ");

                        // Kör så länge inte användare anger ett "riktigt" namn och inte null/whitespace
                        while (string.IsNullOrWhiteSpace(inputName = ReadLine()))
                        {
                            Clear();
                            WriteLine("Du måste ange ett namn. Testa igen!");
                            Write("Ange ditt namn: ");
                        }

                        Write("Skriv in ditt inlägg: ");

                        // Kör så länge inte användare anger ett "riktigt" inlägg
                        while (string.IsNullOrWhiteSpace(inputMessage = ReadLine()))     
                        {
                            Clear();
                            WriteLine("Du måste skriva ett inlägg. Testa igen!");
                            Write("Skriv in ditt inlägg: ");
                        }

                        // Kör metoden för att skapa och spara 
                        guestbook.AddPost(inputName, inputMessage);

                        break;

                    case '2':
                        Clear();

                        // Skriv ut alla inlägg för användaren ska kunna välja vilket som ska tas bort
                        guestbook.ShowPosts();

                        // Kontroll om inga inlägg finns 
                        if (guestbook.GetPosts().Count == 0)
                        {
                            WriteLine("Tryck på valfri tangent för att återgå till menyn.");
                            ReadKey();
                            break;
                        }

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
                                        break;
                                    }
                                    catch (Exception)
                                    {
                                        WriteLine("Ett fel inträffade. Tryck på valfri knapp för att fortsätta.");
                                        ReadKey();
                                        break;
                                    }
                                }
                                else
                                {
                                    WriteLine("Felaktigt index, testa igen!");
                                }
                            }
                            else
                            {
                                Guestbook.ErrorMessage();
                            }
                        }
                        break;

                    case 'x':
                        Clear();
                        Environment.Exit(0);    // Avsluta programmet
                        break;

                    default:
                        Guestbook.ErrorMessage();
                        break;
                }
            }
        }
    }
}
