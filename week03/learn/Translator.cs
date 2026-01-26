public class Translator
{
    public static void Run()
    {
        var englishToGerman = new Translator();

        // Build the dictionary
        englishToGerman.AddWord("House", "Haus");
        englishToGerman.AddWord("Car", "Auto");
        englishToGerman.AddWord("Plane", "Flugzeug");

        // Test translations
        Console.WriteLine(englishToGerman.Translate("Car"));    // Auto
        Console.WriteLine(englishToGerman.Translate("Plane"));  // Flugzeug
        Console.WriteLine(englishToGerman.Translate("Train"));  // ???
    }

    private Dictionary<string, string> _words = new();

    /// <summary>
    /// Add the translation from 'fromWord' to 'toWord'
    /// </summary>
    public void AddWord(string fromWord, string toWord)
    {
        // Add or replace the translation
        _words[fromWord] = toWord;
    }

    /// <summary>
    /// Translate the word or return "???" if not found
    /// </summary>
    public string Translate(string fromWord)
    {
        if (_words.TryGetValue(fromWord, out var translation))
        {
            return translation;
        }

        return "???";
    }
}
