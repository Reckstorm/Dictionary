using Classwork_29._10._2022;
using System.Collections.Generic;
using System.Diagnostics;

MyDict myDict = new MyDict();

Console.WriteLine(myDict.AddWord("Apple", new List<string>() { "Яблоко" }));
Console.WriteLine(myDict.AddWord("Orange", new List<string>() { "Апельсин", "Оранжевый" }));
Console.WriteLine(myDict.AddWord("Pineapple", new List<string>() { "Ананас" }));
Console.WriteLine(myDict.AddWord("Tomato", new List<string>() { "Помидор", "Томат" }));
Console.WriteLine();

using (myDict)
{
    Print(myDict);

    Console.WriteLine(myDict.AddWord("Beetroot", new List<string>() { "Свекла" }));
    Console.WriteLine(myDict.AddTranslation("Beetroot", "Буряк"));
    Console.WriteLine(myDict.AddTranslation("Beetroot", "Буряк"));
    Console.WriteLine();

    Print(myDict);

    Console.WriteLine();
    Console.WriteLine("Find Translation By Key");
    Console.WriteLine(myDict.FindTranslationByKey("Apple"));
    Console.WriteLine();
    Console.WriteLine("Find Translation By Value");
    Console.WriteLine(myDict.FindTranslationByValue("Яблоко"));
    Console.WriteLine();
    Console.WriteLine("Remove Pair By Key");
    Console.WriteLine(myDict.RemovePairByKey("Apple"));
    Console.WriteLine();
    Console.WriteLine("Remove Translation By Value");
    Console.WriteLine(myDict.RemovePairByValue("Буряк"));

    Console.WriteLine();
    Print(myDict);
}


void Print(MyDict someDict)
{
    foreach (var item in someDict.dict)
    {
        Console.WriteLine($"{item.Key}: ");
        foreach (var innerItem in item.Value)
        {
            Console.WriteLine(innerItem);
        }
        Console.WriteLine();
    }
}