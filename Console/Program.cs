using System.Runtime.InteropServices;
using System.Runtime.Versioning;
using System.Text;
using Library;

if(args.Length != 2) 
{
    Console.WriteLine("Need two params: input file and output file");
    return;
}
string inputFileName = args[0];
string outputFileName = args[1];

//string inputFileName = "/home/yasha/work/charp/test/Console/Data/input.txt";
//string outputFileName = "/home/yasha/work/charp/test/Console/Data/output.txt";

FileInfo inputFileInfo = new FileInfo(inputFileName);
if(!inputFileInfo.Exists)
{ 
    Console.WriteLine($"Input file {inputFileName} not found");
    return;   
}

FileInfo outputFileInfo = new FileInfo(outputFileName);
if(outputFileInfo.Name == string.Empty)
{
    Console.WriteLine("Ouput file has empty file name");
    return;
}

if(outputFileInfo.Directory != null && outputFileInfo.Directory.Exists == false)
{
    Console.WriteLine($"Output file {outputFileName} " + 
        $"has directory {outputFileInfo.DirectoryName} which not exists");
    return;
}

Dictionary<string, int> dictionary;

Encoding encoding = Encoding.Default;
if(RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
{
    encoding = Encoding.GetEncoding("Windows-1251");
}

try 
{
    using (StreamReader streamReader = new StreamReader(inputFileName, encoding))
    {
        Reader reader = new Reader();
        dictionary = reader.Read(streamReader);
    }
}
catch(Exception e) 
{
    Console.WriteLine($"Error during reading: {e.Message}");
    return;
}

try 
{
    using (StreamWriter streamWriter = new StreamWriter(outputFileName, false, encoding))
    {
        Generator generator = new Generator(dictionary);
        generator.Generate(streamWriter);
    }   
}
catch(Exception e)
{
    Console.WriteLine($"Error during writing: {e.Message}");
    return;
}
    
Console.WriteLine($"Dictionary file {outputFileName} was successfully created");