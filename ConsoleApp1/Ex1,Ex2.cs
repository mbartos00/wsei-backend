using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Class1
    {
        public void addText()
        {
 // ex. 1 ex. 2
            string path = @"D:\Users\maciej.bartos\source\repos\myTxt.txt";

        Console.WriteLine("podaj tekst");
            string text = Console.ReadLine();
            using (FileStream fs = File.Create(path))
            {
                AddText(fs, text);

}

//Open the stream and read it back.
using (FileStream fs = File.OpenRead(path))
{
    byte[] b = new byte[1024];
    UTF8Encoding temp = new UTF8Encoding(true);
    while (fs.Read(b, 0, b.Length) > 0)
    {
        Console.WriteLine(temp.GetString(b));
    }
}
        }
 

        private static void AddText(FileStream fs, string value)
{
    byte[] info = new UTF8Encoding(true).GetBytes(value);
    fs.Write(info, 0, info.Length);
}        
}
    }

