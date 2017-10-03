using System;
using System.Collections;
using System.IO;

namespace Grades
{
    public abstract class GradeTracker: IGradeTracker
    {       
        string _name;
        public string Name
        {
            get => _name;
            set
            {
                if (!String.IsNullOrEmpty(value) && _name != value)
                {
                    var oldValue = _name;
                    _name = value.Trim();
                    if (NameChanged != null)
                    {
                        NameChangedEventArgs args = new NameChangedEventArgs();
                        args.OldValue = oldValue;
                        args.NewValue = _name;
                        NameChanged(this, args);
                    }


                }

            }
        }
        public event NameChangedDelegate NameChanged;

        public virtual void OnNameChanged(object sender, NameChangedEventArgs args)
        {
            Console.WriteLine($"GradeBook Name Changed from '{args.OldValue}' to '{args.NewValue}'");
        }

        public abstract void Add(float grade);
        public abstract GradeStatistics ComputeStatistics();
        public abstract void WriteGrades(TextWriter textWriter);
        public abstract IEnumerator GetEnumerator();
       

    }
}
