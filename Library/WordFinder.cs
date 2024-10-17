using System;
using System.Text;
using System.Transactions;

namespace Library;

public class WordFinder
{
    public WordFinder(Dictionary<string, int> dictionary)
    {
        this.dictionary = dictionary;
    }
    public void ReadChar(char c)
    {
        if(c == ' ' || c == '\n')
        {
            //end of word
            if(isWord == true)  
            {
                isWord = false;

                string str = word.ToString();
                if(dictionary.ContainsKey(str))
                {
                    dictionary[str]++;
                }
                else 
                {
                    dictionary[str] = 1;
                }
            }
        }
        else 
        {
            //start of word
            if(isWord == false)
            {
                isWord = true;
                word.Clear();
            }
            
            word.Append(c);
        }
    }
    private Dictionary<string, int> dictionary;
    private bool isWord = false;
    private StringBuilder word = new StringBuilder();
}
