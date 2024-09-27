using System.Text.Json;

// Metoder och klass för gästboken

namespace mom3
{
    // Klass för gästboken
    public class Guestbook
    {
        private string filename = @"guestbook.json";
        private List<Post> posts = new();       // Lista för inläggen

        // Konstruktor
        public Guestbook()
        {
            if (File.Exists(filename))       // Kontroll om json.filen finns
            {
                string jsonString = File.ReadAllText(filename);                     // Läs in all text 
                posts = JsonSerializer.Deserialize<List<Post>>(jsonString)!;        // Deserialiserar JSON till listan av inläggen
            }
        }

        // Metod för att skapa ett nytt objekt
        public Post AddPost(string name, string message)
        {
            Post obj = new()
            {
                Name = name,
                Message = message
            };
            posts.Add(obj);         // Lägg till i listan posts
            SaveToFileAsJson();     // Spara till json-filen
            return obj;
        }

        // Metod för att rader inlägg
        public int DeletePost(int index)
        {
            posts.RemoveAt(index);
            SaveToFileAsJson();         // Spara på nytt till json-filen
            return index;
        }

        // Metod för att kunna hämta listan publikt
        public List<Post> GetPosts()
        {
            return posts;
        }

        // Metod för att spara inlägg med serialize
        private void SaveToFileAsJson()
        {
            var jsonString = JsonSerializer.Serialize(posts);
            File.WriteAllText(filename, jsonString);
        }
    }

}