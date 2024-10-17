using System;
using System.CodeDom.Compiler;

namespace Library;

public class Generator
{
    public Generator(Dictionary <string, int> dictionary)
    {
        this.dictionary = dictionary;
    }
    private Dictionary<string, int> dictionary;

    public void Generate(StreamWriter writer)
    {
        foreach(KeyValuePair<string, int> kvp in 
            dictionary.OrderByDescending(kvp => kvp.Value))
        {
            writer.WriteLine("{" + kvp.Key + "},{" + kvp.Value +"}");
        }
    }
}
