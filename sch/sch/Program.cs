using System;
using System.IO;

namespace sch
{
    public class Program
    {      
        public static Boolean argsLengthControl(string[] args)
        {
            if (args.Length > 1)
                Console.Error.WriteLine("Hatali Arguman sayisi.");         

            return (args.Length < 2);
        }
        static void Main(string[] args)
        {

            if (!argsLengthControl(args))
                System.Environment.Exit(1);

            const string Path = "../../okul.csv";

            if (!File.Exists(Path))
                System.Environment.Exit(1); 

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
                Student.argumentControllerErrorMessage(args[0]);
            }
        }
    }
}
