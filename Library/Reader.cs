using System;
using System.Text;

namespace Library;

public class Reader
{
    public Dictionary<string, int> Read(StreamReader streamReader)
    {
        Dictionary<string, int> keyValuePairs = new Dictionary<string, int>();
        WordFinder wordFinder = new WordFinder(keyValuePairs);

        int lenght = 4096;
        char[] buffer = new char[lenght];

        int readCount = 0;
        do
        {
            readCount = streamReader.ReadBlock(buffer, 0, lenght);
            for(int i = 0; i < readCount; i++)
            {
                wordFinder.ReadChar(buffer[i]);
            }
        }
        while(readCount == lenght);
        streamReader.Close();
        
        return keyValuePairs;
    }
}
