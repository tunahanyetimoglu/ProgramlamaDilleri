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
        public static Boolean argumanController(string arg)
        {
            string[] validArgumans = new String[]{ "1", "2", "3", "4", "E", "K", "e", "k" };

            return Array.Exists(validArgumans,element => element == arg);
        }

        void run()
        {

        }
        
        static void Main(string[] args)
        {
            Student student = new Student();

            const string Path = "../../okul.csv";

            if (!pathController(Path))
                System.Environment.Exit(1);

            var studentOrderedList = student.Parse(Path);

            if (!Student.csvUniqueName(studentOrderedList))
                System.Environment.Exit(1);


            if (args.Length == 0)
            {
                student.printAll(studentOrderedList);
            }
            else if (args.Length > 1)
            {
                Console.WriteLine("Hatali Arguman sayisi.");
            }
            else if (argumanController(args[0]))
            {
                student.print(student.ListFiltering(studentOrderedList, args[0]));
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
