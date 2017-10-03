using System.Collections;
using System.IO;

namespace Grades
{
    public interface IGradeTracker : IEnumerable
    {
        string Name{get;set;}
        event NameChangedDelegate NameChanged;

        void OnNameChanged(object sender, NameChangedEventArgs args);  
        void Add(float grade);
        GradeStatistics ComputeStatistics();
        void WriteGrades(TextWriter textWriter);
    }
}
