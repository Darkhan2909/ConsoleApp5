using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp5
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            ////Exmpl01();
            //Exmpl03();
            //Exmpl05();
            //Exmpl07();
            Console.WriteLine("Enter Examples: ");

            int e = Convert.ToInt32(Console.ReadLine());
            if (e == 1)
            {

                string path = @"C:\Users\лукманхакимд\Desktop\Test";
                int k = 0;
                foreach (var item in GetAllFiles(path))
                {
                    Console.WriteLine((k++) + ": " + item);
                }

                int ch = 0;
                Console.WriteLine("Enter format: ");
                ch = Convert.ToInt32(Console.ReadLine());

                DirectoryInfo dir = new DirectoryInfo(path);
                int count = dir.GetFiles("*" + GetAllFiles(path)[ch]).Count();
                Console.WriteLine(count);
            }
            else if (e==2)
            {
                string path = @"C:\Users\лукманхакимд\Desktop\Test";
                GetName(path);
            }
            else if(e == 3)
            {
                string path = @"C:\Users\лукманхакимд\Desktop\Test";
                PrintDirName(path);
                Console.WriteLine();
            }
        }
        public static void GetName(string path)
        {
            DirectoryInfo dir = new DirectoryInfo(path);
            List<string> names = new List<string>() { "-","_"};
            foreach (FileInfo f in dir.GetFiles())
            {
                if(f.Name.Contains("-"))
                    f.MoveTo(dir.FullName+@"\"+f.Name.Replace("-","*"));

            }
        }

        public static List<string> GetAllFiles(string path)
        {

            List<string> filesExt = new List<string>();

            DirectoryInfo directoryInfo = new DirectoryInfo(path);

            if (string.IsNullOrWhiteSpace(path))
            {
                Console.WriteLine("Ukazhite put!");
            }
            else
            {

                DirectoryInfo dir = new DirectoryInfo(path);
                if (!dir.Exists)
                    Console.WriteLine("Ukazannyi put ne korrektnyi");
                else
                {
                    foreach (FileInfo file in dir.GetFiles())
                    {
                        if (!filesExt.Contains(file.Extension))
                            filesExt.Add(file.Extension);
                    }

                    //Dictionary<string, string> dic = new Dictionary<string, string>();
                    //foreach (FileInfo file in dir.GetFiles())
                    //{
                    //    if (!dic.ContainsKey(file.Extension))
                    //        dic.Add(file.Extension);
                    //}
                }
            }
            return filesExt;
        }












        public static void PrintFileName(string path)
        {
            DirectoryInfo dir = new DirectoryInfo(path);
            foreach (FileInfo item in dir.GetFiles())
            {

            }
        }

        public static void PrintDirName(string path)
        {
            DirectoryInfo directory = new DirectoryInfo(path);
            foreach (DirectoryInfo item in directory.GetDirectories())
            {
                Console.WriteLine($"{directory.FullName}");
                PrintDirName(item.FullName);
            }
        }

        public static void Exmpl01()
        {
            FileStream fs = new FileStream(@"C:\Users\лукманхакимд\Desktop\TextA.txt", FileMode.Create);

            FileStream fs2 = new FileStream(@"C:\Users\лукманхакимд\Desktop\TextB.txt", FileMode.Create, FileAccess.Write);

            FileStream fs3 = new FileStream(@"C:\Users\лукманхакимд\Desktop\TextC.txt", FileMode.Create, FileAccess.Write, FileShare.None);

            fs3.Close();
        }
        public static void Exmpl02()
        {

            FileInfo fs = new FileInfo(@"C:\Users\лукманхакимд\Desktop\TextAI.txt");

            if (!fs.Exists)
            {
                FileStream fsn = fs.Create();
                fsn.Close();
            }
            using (FileStream fsn = fs.Open(FileMode.Open, FileAccess.ReadWrite, FileShare.None))
            {

            }
        }
        public static void Exmpl03()
        {
            DirectoryInfo dir = new DirectoryInfo(".");
            DirectoryInfo dir2 = new DirectoryInfo(@"C:\Users\лукманхакимд\Desktop\Test");
            dir2.Create();
        }
        public static void Exmpl04()
        {
            DirectoryInfo dir = new DirectoryInfo(@"C:\Users\лукманхакимд\Desktop\");
            Console.WriteLine("Information of catalogs");
            Console.WriteLine("Polnyi put: {0}" + "\n Directory Name:{1}" + "\n Parent Catalogs: {2}", dir.FullName, dir.Name, dir.Parent);
            foreach (FileInfo file in dir.GetFiles())
            {
                Console.WriteLine("->>" + file.Name);
            }
            FileInfo[] fileHtml = dir.GetFiles("*.html", SearchOption.AllDirectories);
        }
        public static void Exmpl05()
        {
            string path = @"C:\Users\лукманхакимд\Desktop\TextA.txt";
            try
            {
                using (StreamReader sr = new StreamReader(path))
                {
                    Console.WriteLine(sr.ReadToEnd());
                }
                using (StreamReader sr = new StreamReader(path))
                {
                    string line;
                    while ((line = sr.ReadLine()) != null)
                    {
                        Console.WriteLine(line);
                    }
                }

                using (StreamReader sr = new StreamReader(path))
                {
                    char[] array = new char[4];
                }
            }
            catch (Exception ex)
            {

            }
        }
        public static void Exmpl06()
        {

            string path = @"C:\Users\лукманхакимд\Desktop\TextA.txt";

            using (StreamWriter sr = new StreamWriter(path, true, Encoding.Default))
            {
                //Console.WriteLine(sr);
                sr.Write("\n---> " + DateTime.Now.ToLongTimeString());
                sr.Write("\n---> " + DateTime.Now.ToLongTimeString());
            }

        }
        public static void Exmpl07()
        {
            DriveInfo[] disk = DriveInfo.GetDrives();
            foreach (var item in disk)
            {
                Console.WriteLine(item.Name);

            }
            DriveInfo c = new DriveInfo("C");
            Console.WriteLine(c.TotalSize);
            Console.WriteLine(c.AvailableFreeSpace);
            Console.WriteLine(c.DriveFormat);
            Console.WriteLine(c.DriveType);
            Console.WriteLine(c.Name);
            //Console.WriteLine(c.TotalSize);

        }
    }
}
