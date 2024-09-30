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

            // While-loop för att fortsätta köra applikationen tills den avslutas av användaren
            while (true)
            {
                Clear();                        // Rensa konsolen
                CursorVisible = false;          // Dölj markören
                WriteLine("A D E L A S  G Ä S T B O K\n");
                WriteLine("1. Skapa nytt inlägg");
                WriteLine("2. Ta bort inlägg");
                WriteLine("X. Avsluta\n");

                // Loopa genom alla inlägg som finns med metoden getPosts och skriv ut numrerade
                int i = 0;
                foreach (Post post in guestbook.GetPosts())
                {
                    WriteLine($"[{i++}] {post.Name} - {post.Message}");
                }

                // Variabel för vilket val användaren väljer i integer
                int input = (int)ReadKey(true).Key;

                // Switch-sats för de olika valen
                switch (input)
                {
                    case '1':
                        Clear();                   // Rensa konsolen
                        CursorVisible = true;      // Visa markören för att indikera för användaren att skriva något 

                        string? inputName;
                        string? inputMessage;

                        Write("Ange ditt namn: ");
                        while (string.IsNullOrWhiteSpace(inputName = ReadLine()))       // Kör så länge inte användare anger ett "riktigt" namn
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

                        // Kör metod för att skapa en ny instans av inlägget
                        guestbook.AddPost(inputName, inputMessage);
                        break;


                    case '2':
                        Write("Ange index att radera: ");
                        CursorVisible = true;                    // Visa markören 
                        string? index = ReadLine();

                        // Kontroll om användaren angivit korrekt index och sedan kör metoden delete
                        if (!string.IsNullOrWhiteSpace(index))
                            try
                            {
                                guestbook.DeletePost(Convert.ToInt32(index));
                            }

                            // Catch för att fånga upp felaktiga val av index
                            catch (Exception)
                            {
                                WriteLine("Felaktigt val!\nTryck på valfri knapp för att fortsätta.");
                                ReadKey();
                            }
                        break;

                    case 88:                        // Val för x-tangenten
                        Environment.Exit(0);
                        break;

                    default:
                        WriteLine("Felaktigt val. Tryck på valfri tangent för att testa igen!");
                        break;
                }

            }

        }
    }
}