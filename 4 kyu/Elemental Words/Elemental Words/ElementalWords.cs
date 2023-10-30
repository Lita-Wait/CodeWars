
namespace Elemental_Words
{
    public class ElementalWords
    {
        public static string[][] ElementalForms(string word)
        {
            if (string.IsNullOrEmpty(word))
            {
                return new string[0][];
            }
            else
            {
                List<string[]> result = new List<string[]>();
                GetCombinations(word, new List<string>(), result);
                return result.ToArray();
            }
        }

        private static void GetCombinations(string word, List<string> current, List<string[]> result)
        {
            foreach (KeyValuePair<string, string> kvp in Preloaded.ELEMENTS)
            {
                if (word.StartsWith(kvp.Key, StringComparison.OrdinalIgnoreCase))
                {
                    string nextWord = word.Substring(kvp.Key.Length);
                    List<string> next = new List<string>(current);
                    next.Add($"{kvp.Value} ({kvp.Key})");
                    GetCombinations(nextWord, next, result);
                }
            }

            if (string.IsNullOrEmpty(word))
            {
                result.Add(current.ToArray());
            }
        }
    }
}