// Lab 7 - Madlibs #1
// Ileana Gonzalez, 06/17

using System.ComponentModel;

Console.Clear();

Console.WriteLine("- Welcome to Mad Libs! -\n");
Console.WriteLine("After you are done providing the words requested, I will build them into a funny story for you.\n");
Console.WriteLine();

string originalStory = "A vacation is when you take a trip to some (adjective) place with your (adjective) family. Usually, you go to some place that is near a/an (noun) or up on a/an (noun). A good vacation place is one where you can ride (plural_noun) or play (game) or go hunting for (plural_noun). I like to spend my time (verb_ending_in_“ing”) or (verb_ending_in_“ing”). When parents go on a vacation, they spend their time eating three (plural_noun) a day, and fathers play golf, and mothers sit around (verb_ending_in_“ing”). Last summer, my little brother fell in a/an (noun) and got poison (plant) all over his (part_of_the_body). My family is going to go to (place) and I will practice (verb_ending_in_“ing”). Parents need vacations more than kids because parents are always very (adjective) and because they have to work (number) hours every day all year making enough (plural_noun) to pay for the vacation.";

string[] storyWords = originalStory.Split(' ');
string newStory = "";
string[] vowels = { "a", "e", "i", "o", "u" };
string article = "";
bool newArticle = false;

foreach (string word in storyWords)
{
    if (word == "a/an")
    {
        newArticle = true;
    }
    else if (word.StartsWith("("))
    {
        string punctuation = "";

        if (word.EndsWith("."))
        {
            punctuation = ".";
        }
        string wordType = word.Trim('(', ')', '.');
        wordType = wordType.Replace("_", " ");

        article = "a";

        foreach (string vowel in vowels)
        {
            if (wordType.StartsWith(vowel))
            {
                article = "an";
            }
        }
        Console.Write($"Please give {article} {wordType}: ");
        string userWord = Console.ReadLine()!;

        if (newArticle == true)
        {
            article = "a";

            foreach (string vowel in vowels)
            {
                if (userWord.StartsWith(vowel))
                {
                    article = "an";
                }
            }
            newStory += article + " ";
            newArticle = false;
        }

        newStory += userWord + punctuation + " ";
    }
    else
    {
        newStory += word + " ";
    }
}

Console.WriteLine("\n\t- Your story:\n");
Console.WriteLine(newStory);