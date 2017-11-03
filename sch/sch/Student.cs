using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
                : base()
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
        public override string ToString()
        {
            return grade.ToString() + "\t " + name.ToString() + "\t " + surname.ToString() + "\t " + gender.ToString();
        }
    }
}
