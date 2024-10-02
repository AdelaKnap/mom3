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
                CursorVisible = false;  // Dölj markör
                WriteLine("A D E L A S  G U E S T B O O K\n");
                WriteLine("1. Create a new entry");
                WriteLine("2. Delete an entry");
                WriteLine("X. Exit\n");
                WriteLine("Current entries:");

                // Skriv ut inläggen
                guestbook.ShowPosts();

                WriteLine("\nChoose what you want to do!");


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

                        Write("Enter your name: ");

                        // Kör så länge inte användare anger ett "riktigt" namn och inte null/whitespace
                        while (string.IsNullOrWhiteSpace(inputName = ReadLine()))
                        {
                            Clear();
                            WriteLine("You must enter a name. Please try again!");
                            Write("Enter your name: ");
                        }

                        Write("Write your entry: ");


                        // Kör så länge inte användare anger ett "riktigt" inlägg
                        while (string.IsNullOrWhiteSpace(inputMessage = ReadLine()))
                        {
                            Clear();
                            WriteLine("You must write an entry. Please try again!");
                            Write("Write your entry: ");

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
                            WriteLine("Press any key to return to the menu.");
                            ReadKey();
                            break;
                        }

                        while (true) // Fortsätt tills giltig index
                        {
                            Write("\nEnter the index to delete: ");

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
                                        WriteLine("An error occurred. Press any key to continue.");
                                        ReadKey();
                                        break;
                                    }
                                }
                                else
                                {
                                    WriteLine("Invalid index, please try again!");
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
