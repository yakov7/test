using System.IO.Enumeration;
using System.Runtime.InteropServices;
using System.Text;
using Library;
using Xunit;
namespace Testing;

public class UnitTest1
{
    [Theory]
    [MemberData("FileDictionary")]
    public void FileToDictionary(string fileName, Dictionary<string, int> dictionary)
    {
        Dictionary<string, int> dic = ReadDictionary(fileName);
        Assert.True(CompareDictionaries(dic, dictionary));
    }

    public static IEnumerable<object[]> FileDictionary()
    {
        yield return new object[] { "input.txt", new Dictionary<string, int>()
            {
                {"gg",5},
                {"da",3},
                {"www",3},
                {"ii",3},
                {"sad",2},
                {"hh",2},
                {"nana",2},
                {"dd",1},
                {"net",1},
                {"og",1},   
            }};
    }

    [Theory]
    [MemberData("FileFile")]
    public void FileToText(string fileName, string fileName2)
    {
        string text = ReadText(fileName);
        string text2 = File.ReadAllText(fileName2);
        Assert.True(text == text2);
    }

    public static IEnumerable<object[]> FileFile()
    {
        yield return new object[] { "input.txt", "output.txt"};
    }

    
    private static Dictionary<string, int> ReadDictionary(string fileName)
    {
        Encoding encoding = Encoding.Default;
        if(RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
        {
            encoding = Encoding.GetEncoding("Windows-1251");
        }

        using (StreamReader streamReader = new StreamReader(fileName, encoding))
        {
            Reader reader = new Reader();
            return reader.Read(streamReader);
        }
    }

    private static string ReadText(string fileName)
    {
        Dictionary<string, int> dictionary = ReadDictionary(fileName);
        string result = string.Empty;
        foreach(KeyValuePair<string, int> kvp in 
            dictionary.OrderByDescending(kvp => kvp.Value))
        {
            result += "{" + kvp.Key + "},{" + kvp.Value +"}\n";
        }
        return result;
    }
    private static bool CompareDictionaries(Dictionary<string, int> dic, Dictionary<string, int> dic2)
    {
        foreach(var k in dic.Keys)
        {
            if(!dic2.ContainsKey(k)) return false;
            if(dic[k] != dic2[k]) return false;
        }
        return true;
    }
}