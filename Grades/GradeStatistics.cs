namespace Grades
{
    public  class GradeStatistics
    {
        public float AvarageGrade;
        public float HighestGrade;
        public float LowestGrade;

        public char LetterGrade
        {
            get
            {
                char Grade;
                if (AvarageGrade >= 90)
                    Grade = 'A';
                else if (AvarageGrade >= 75)
                    Grade = 'B';
                else if (AvarageGrade >= 60)
                    Grade = 'C';
                else if (AvarageGrade >= 40)
                    Grade = 'D';
                else
                    Grade = 'F';
                return Grade;
            }
        }
        public string  Description
        {
            get
            {
                string result;
                switch (LetterGrade)
                {
                    case 'A':
                        result = "Excelent";
                        break;
                    case 'B':
                        result = "Good";
                        break;
                    case 'C':
                        result = "Average";
                        break;
                    case 'D':
                        result = "Poor";
                        break;
                    default:
                        result = "Fail";
                        break;
                }

                return result;
            }
        }

        public GradeStatistics()
        {
            AvarageGrade = 0f;
            HighestGrade = 0f;
            LowestGrade = float.MaxValue;
        }


    }
}
