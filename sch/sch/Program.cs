using System;
using System.IO;

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
                Console.Error.WriteLine("Hata: Dosya bulunamadı!" );
                return false;
            }
            finally
            {
                if(fs != null)
                    fs.Close();
            }
        }           
        static void Main(string[] args)
        {

            const string Path = "../../okul.csv";

            if (!pathController(Path))
                System.Environment.Exit(-1);

            var studentOrderedList = Student.Parse(Path);

            if (!Student.csvUniqueName(studentOrderedList))
                System.Environment.Exit(-1);

            if (args.Length == 0)
            {
                Student.printSorteredList(studentOrderedList);
            }
            else if (args.Length > 1)
            {
                Console.Error.WriteLine("Hatali Arguman sayisi.");
            }
            else if (Student.argumanController(args[0]))
            {
                Student.printFilteredList(Student.ListFiltering(studentOrderedList, args[0])); ;
            }
            else
            {
                Student.argumanControllerErrorMessage(args);
            }
        }
    }
}
