using System;
using System.IO;

namespace Grades
{
    class Program
    {
        private static IGradeTracker CreateGradeBook()
        {
            return new ThrowAwayGradeBook("KK Book");
        }

        private static void WriteName(params string[] names)
        {
            foreach (string name in names)
                Console.WriteLine(name);
        }

        static void Main(string[] args)
        {
            IGradeTracker book = CreateGradeBook();
            //book.Add(78.1f);
            //book.Add(94.6f);
            //book.Add(82.3f);            
            try
            {
                using (FileStream stream = File.Open("Grades.txt", FileMode.Open))
                using (StreamReader reader = new StreamReader(stream))
                {
                    string line = reader.ReadLine();
                    while (line != null)
                    {
                        float grade = float.Parse(line);
                        book.Add(grade);
                        line = reader.ReadLine();

                    }
                }
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("Could Not Locate Grades.txt File");
                return;
            }
            catch (UnauthorizedAccessException)
            {
                Console.WriteLine("No Access");
                return;
            }
            finally
            {

            }

            //string[] lines = File.ReadAllLines("Grades.txt");
            //foreach (string line in lines)
            //{
            //    float grade = float.Parse(line);
            //    book.Add(grade);
            //}

            //foreach (var grade in book)
            //{
            //    Console.Write(grade + " ");
            //}

            book.NameChanged += book.OnNameChanged;


            book.Name = "KishorKira Book";
            //book.Name = "KishorKira Book";
            book.Name = "Ks Book";
            WriteName(book.Name);
            book.WriteGrades(Console.Out);
            GradeStatistics statistics = book.ComputeStatistics();

            Console.WriteLine($"Avarage Grade : {statistics.AvarageGrade}");
            Console.WriteLine($"Lowest Grade : {statistics.LowestGrade}");
            Console.WriteLine($"Highest Grade : {statistics.HighestGrade}");
            Console.WriteLine($"Letter Grade : {statistics.LetterGrade}");
            Console.WriteLine($"Description : {statistics.Description}");



        }

       
    }
}
