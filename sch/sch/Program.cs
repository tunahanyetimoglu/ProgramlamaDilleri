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
        public static Boolean argsLengthControl(string[] args)
        {
            if (args.Length > 1)
            {
                Console.Error.WriteLine("Hatali Arguman sayisi.");
                return false;
            }
            else
                return true;
        }
        static void Main(string[] args)
        {

            if (!argsLengthControl(args))
                System.Environment.Exit(-1);

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
