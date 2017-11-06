using System;
using System.IO;

namespace sch
{
    public class Program
    {      
        public static Boolean argsLengthControl(string[] args)
        {
<<<<<<< HEAD
            if (args.Length > 1)
                Console.Error.WriteLine("Hatali Arguman sayisi.");         

            return (args.Length < 2);
=======
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
>>>>>>> 360178fa9959b9500e4cd514a96bb53b5aa7c360
        }
        static void Main(string[] args)
        {

            if (!argsLengthControl(args))
<<<<<<< HEAD
                System.Environment.Exit(1);

            const string Path = "../../okul.csv";

            if (!File.Exists(Path))
                System.Environment.Exit(1); 
=======
                System.Environment.Exit(-1);

            const string Path = "../../okul.csv";

            if (!pathController(Path))
                System.Environment.Exit(-1); 
>>>>>>> 360178fa9959b9500e4cd514a96bb53b5aa7c360

            var studentOrderedList = Student.Parse(Path);

            if (!Student.csvUniqueName(studentOrderedList))
                System.Environment.Exit(1);

            if (args.Length == 0)
            {
                Student.printSorteredList(studentOrderedList);
            }
            else if (Student.argumentController(args[0]))
            {
                Student.printFilteredList(Student.ListFiltering(studentOrderedList, args[0]));
            }
            else
            {
<<<<<<< HEAD
                Student.argumentControllerErrorMessage(args[0]);
=======
                Student.argumanControllerErrorMessage(args[0]);
>>>>>>> 360178fa9959b9500e4cd514a96bb53b5aa7c360
            }
        }
    }
}
