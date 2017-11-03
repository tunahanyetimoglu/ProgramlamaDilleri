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
        public static void Main(string[] args)
        {
            Student student = new Student();

            const string Path = "../../okul.csv";

            if (!pathController(Path))
                System.Environment.Exit(-1);

            var studentOrderedList = student.Parse(Path);

            if (!Student.csvUniqueName(studentOrderedList))
                System.Environment.Exit(-1);

            if (args.Length == 0)
            {
                student.printAll(studentOrderedList);
            }
            else if (Student.argumanController(args[0]))
            {
                student.print(student.ListFiltering(studentOrderedList, args[0]));;
            }           
            else
            {
                Student.argumanControllerErrorMessage(args);
            }
        }
    }
}
