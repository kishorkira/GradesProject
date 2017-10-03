using System;

namespace Grades
{
    public class ThrowAwayGradeBook : GradeBook
    {
        public ThrowAwayGradeBook(string name):base(name)
        {

        }

        public override GradeStatistics ComputeStatistics()
        {
            float lowest = float.MaxValue;
            foreach(float grade in _grades)
            {
                lowest = Math.Min(lowest, grade);
            }
            _grades.Remove(lowest);
            return base.ComputeStatistics();
        }
    }

}
