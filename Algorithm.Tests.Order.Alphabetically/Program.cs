// See https://aka.ms/new-console-template for more information
//Console.WriteLine("Hello, World!");
var userInput = Console.ReadLine();

if (userInput == null) return;

var wordsArray = userInput.Split(new[] { ' ' });
var charactersList = userInput.Replace(" ", "").ToList<char>().Order();

var startPosition = 0;
var response = string.Empty;

foreach (var word in wordsArray)
{
    if (!string.IsNullOrEmpty(response)) { response += " "; }

    var endPosition = word.Length;
    var wordToAdd = charactersList.Take(new Range(startPosition, startPosition + endPosition));
    startPosition += endPosition;
    response += new string(wordToAdd.ToArray());
}
Console.WriteLine(response);