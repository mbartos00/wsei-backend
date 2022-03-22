using System;
using System.IO;
using System.Text.Json;

namespace ConsoleApp1
{
    class Program
    {
        public static object binarySearch(int[] array, int value)
        {
            int index = 0;
            int limit = array.Length - 1;

            while (index <= limit)
            {
                
                int point = index + (limit - index) / 2;
                var entry = array[point];
                return value == entry ? point : entry < value ? index = point + 1 : limit = point - 1;

            }
            return -1;
        }
 
        public static void readText(string path)
        {
            
            //read text from path
            string text = File.ReadAllText(path);
            //write to console
            Console.WriteLine($"Your text: {text}");
        }

        public static void addText(string text, string path)
        {
            //check if file exists
            if (!File.Exists(path))
            {
                // Create a file to write to.
                using (StreamWriter sw = File.CreateText(path))
                {
                    sw.WriteLine(text);

                }
            }

            //add text to file
            using (StreamWriter sw = File.AppendText(path))
            {
                sw.WriteLine(text);

            }


        }

        public class Department
        {
            public int DeptId { get; set; }
            public string DepartmentName { get; set; }
        }

        public static string convertToJson()
        {
            Department dept = new Department() { DeptId = 101, DepartmentName = "IT" };
            string strJson = JsonSerializer.Serialize<Department>(dept);
            return strJson;
        }


        public static string convertJsonToObject()
        {
            string fileName = "E:/backend/wsei-backend/123.json"; //{"DeptId":101,"DepartmentName":"IT"}
            string jsonString = File.ReadAllText(fileName);
            Department department  = JsonSerializer.Deserialize<Department>(jsonString);
            string fullString = $"{department.DeptId}\n {department.DepartmentName } ";
            return fullString;


        }


        static void Main(string[] args)
        {
            Console.Write("Ex.1\nEx.2\nEx.3\nEx.5\nEx.7\nEx.8\n");
            var choose = Console.ReadLine();
            switch (choose)
            {
                case "1":
                    {
                        Console.WriteLine("Exercise 1.");
                        Console.WriteLine("Enter path to your text file");
                        string path = Console.ReadLine();
                        readText(path);
                        break;
                    }
                case "2":
                    {
                        Console.WriteLine("Exercise 2.");
                        Console.WriteLine("Enter path to your text file");
                        string path = Console.ReadLine();
                        Console.WriteLine("Enter text");
                        string text = Console.ReadLine();
                        addText(text, path);
                        break;
                    }
                case "3":
                    {
                        Console.WriteLine("Exercise 3.");
                        int[] arr = { 4, 5, 7, 11, 12, 15, 15, 21, 40, 45 };
                        Console.WriteLine(binarySearch(arr, 11));
                        break;
                    }
                case "5":
                    {
                        Console.WriteLine("Exercise 5.");
                        DateTime localDate = DateTime.Now;
                        DateTime utcDate = DateTime.UtcNow;
                        Console.WriteLine($"local: {localDate}");
                        Console.WriteLine($"global: {utcDate} ");
                        break;
                    }
                case "7":
                    {
                        Console.WriteLine("Exercise 7.");
                        Console.WriteLine(convertToJson());
                        break;
                    }
                case "8":
                    {
                        Console.WriteLine("Exercise 8.");
                        Console.WriteLine(convertJsonToObject());
                        break;
                    }

            }
        }
    }
}
