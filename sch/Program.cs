using System;
using System.IO;
using System.Text.RegularExpressions;

namespace sch
{
    public class Program
    {
        public static Boolean pathController(string path)
        {
            FileStream fs = null;
            try
            {
                fs = new FileStream(@path, FileMode.Open);
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine("Hata: Dosya bulunamadı!" );
                return false;
            }
            finally
            {
                if(fs != null)
                    fs.Close();
            }
        }
        public static Boolean argumanController(string[] args)
        {
            string[] validArgumans = new String[]{ "1", "2", "3", "4", "E", "K", "e", "k" };

            string arg = args[0];

            return Array.Exists(validArgumans,element => element == arg);
        }
        static void Main(string[] args)
        {
            Student student = new Student();

            const string Path = "../../okul.csv";

            if (!pathController(Path))
                System.Environment.Exit(1);

            var query = student.Parse(Path);

            if (!Student.csvUniqueName(query))
                System.Environment.Exit(1);


            if (args.Length == 0)
            {
                student.printAll(query);
            }
            else if (args.Length > 1)
            {
                Console.WriteLine("Hatali Arguman sayisi.");
            }
            else if (argumanController(args))
            {
                student.print(student.ListFiltering(query, args[0]));
            }
            else if (Regex.IsMatch(args[0], @"^[0-9]+$"))
            {
                Console.WriteLine("devre numarası 1 - 4 arasında olmalıdır");
            }
            else
            {
                Console.WriteLine("Hatalı arguman girisi : {0}", args[0]);
            }
        }
    }
}
