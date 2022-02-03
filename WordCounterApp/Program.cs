
/*  ta emot en text
 *  iterera igenom texten
 *  reurnera de 10 mest frekventa orden och dess frekvenser
 */


Console.WriteLine("Enter text to analyse:");
string text = Console.ReadLine();
text = text.ToLower();  
// konverterar till små bokstäver för att kunna jämnföra alla ord likvärdigt

var value = text.Split(new[] {' ', ',', '.'}, StringSplitOptions.RemoveEmptyEntries); 
// splittar strängen 'mellanslag', ',' och '.' samt tar bort alla tomma entries ( mellanslag )
// detta sparas i en array av substrängar

Dictionary<string, int> RepeatedWordCount = new Dictionary<string, int>();

for (int i = 0; i < value.Length; i++)
{
    if (RepeatedWordCount.ContainsKey(value[i]))
    //  kontroll ifall ordet existerar i ordlistan, uppdaterar itterationen
    {
        RepeatedWordCount[value[i]]++;
    }
    else
    //  om ordet inte finns i ordlistan, lägger vi till det här
    {
        RepeatedWordCount.Add(value[i], 1);
    }
}


// Dictionary går inte att sortera som tex. en List, som har en .sort() metod
// Så jag konverterar till List och gör en enkel sortering genom jämnförelse av KeyValuePair 

List<KeyValuePair<string, int>> SortedWordCount = RepeatedWordCount.ToList();

SortedWordCount.Sort(
    delegate (KeyValuePair<string, int> pair1,
    KeyValuePair<string, int> pair2)
    {
        return pair2.Value - pair1.Value;
    }
);

var itemsHighestTen = SortedWordCount.Take(10);
Console.WriteLine();

foreach (KeyValuePair<string, int> kvp in itemsHighestTen)
//  Visar alla keys (ordet) plus dess värde (frekvens)
{
    Console.WriteLine($"{kvp.Key}: {kvp.Value}");
}
