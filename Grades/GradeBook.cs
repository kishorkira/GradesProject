using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;

namespace Grades
{
    public class GradeBook : GradeTracker
    {
       
        protected List<float> _grades;     

        
        
        public GradeBook(string name)
        {
            Name = name;
            _grades = new List<float>();
        }

        public override void Add(float grade)
        {
            if (grade >= 0 && grade <= 100)
                _grades.Add(grade);
        }

        public override  GradeStatistics ComputeStatistics()
        {
            var stats = new GradeStatistics();
            float sum = 0;
            foreach(float grade in _grades)
            {
                stats.HighestGrade = Math.Max(grade, stats.HighestGrade);
                stats.LowestGrade = Math.Min(grade, stats.LowestGrade);
                sum += grade;
            }
            stats.AvarageGrade = sum / _grades.Count;
            return stats;
        }

        public override IEnumerator GetEnumerator()
        {
            return _grades.GetEnumerator();
        }

        public override void WriteGrades(TextWriter textWriter)
        {
            textWriter.WriteLine("Grades : ");
            int i = 0;
            do
            {
                textWriter.WriteLine(_grades[i]);
                i++;
            } while (i < _grades.Count);
        }
    }
}
