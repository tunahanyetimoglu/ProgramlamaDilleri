using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using TinyCsvParser;
using TinyCsvParser.Mapping;

namespace sch
{
    public class Student
    {
        public string name { get; set; }
        public string surname { get; set; }
        public int grade { get; set; }
        public string gender { get; set; }
        private class CsvPersonMapping : CsvMapping<Student>
        {
            public CsvPersonMapping()
                : base() // This constructor will call CsvMapping.CsvMapping()
            {
                MapProperty(0, student => student.name);
                MapProperty(1, student => student.surname);
                MapProperty(2, student => student.gender);
                MapProperty(3, student => student.grade);
            }
        }
        public  IOrderedEnumerable<CsvMappingResult<Student>> Parse(string path)
        {
                CsvParserOptions csvParserOptions = new CsvParserOptions(false, ',');
                CsvPersonMapping csvMapper = new CsvPersonMapping();
                CsvParser<Student> csvParser = new CsvParser<Student>(csvParserOptions, csvMapper);

                var result = csvParser.ReadFromFile(@path, Encoding.UTF8).ToList();
                var studentOrderedList = result.OrderBy(p => p.Result.grade);

                return studentOrderedList;
        }
        public static Boolean csvUniqueName(IOrderedEnumerable<CsvMappingResult<Student>> studentOrderedlist)
        {
            List<string> nameList = new List<string>();
           
            foreach (var student in studentOrderedlist)
            {
                
                nameList.Add(student.Result.name);  
                nameList.Add(student.Result.surname);
            }
            List<string> uniqueList = nameList.Distinct().ToList();

            return nameList.Count() == uniqueList.Count() ? true : false;                   
         }
        public void printAll(IOrderedEnumerable<CsvMappingResult<Student>> studentOrderedList)
        {
            foreach (var student in studentOrderedList)
                Console.WriteLine(student.Result);
        }
        public void print(IEnumerable<CsvMappingResult<Student>> studentFilteredList)
        {
            foreach (var student in studentFilteredList)
                Console.WriteLine(student.Result);
        }
        public IEnumerable<CsvMappingResult<Student>> ListFiltering(IOrderedEnumerable<CsvMappingResult<Student>> studentList, string args)
        {
            String[] genders = new String[] { "K", "k", "E", "e" };

            if (Array.Exists(genders, element => element == args))
                return studentList.Where(student => (student.Result.gender == args.ToUpper()));

            else
                return studentList.Where(student => (student.Result.grade == Convert.ToInt32(args)));
        }

        public static Boolean argumanController(string arg)
        {
            string[] validArgumans = new String[] { "1", "2", "3", "4", "E", "K", "e", "k" };

            return Array.Exists(validArgumans, element => element == arg);

        }

        public static Boolean argumanControllerErrorMessage(string[] args)
        {
            if (args.Length > 1)
            {
                Console.Error.WriteLine("Hatali Arguman sayisi.");
            }
            else if (Regex.IsMatch(args[0], @"^[0-9]+$"))
            {
                Console.Error.WriteLine("devre numarası 1 - 4 arasında olmalıdır");
            }
            else
            {
                Console.Error.WriteLine("Hatalı arguman girisi : {0}", args[0]);
            }
            return false;
        }
        public override string ToString()
        {
            return grade.ToString() + "\t " + name.ToString() + "\t " + surname.ToString() + "\t " + gender.ToString();
        }
    }
}
