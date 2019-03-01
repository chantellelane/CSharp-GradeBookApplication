using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using GradeBook.Enums;

namespace GradeBook.GradeBooks
{
    public class RankedGradeBook : BaseGradeBook
    { // Determined by peer results, top 20% get A, 20% get b....
         public RankedGradeBook(string name) : base(name)
        {
           Type = GradeBookType.Ranked;
        }

         public override char GetLetterGrade(double averageGrade)
         {
             if (Students.Count < 5)
             {
                 throw new InvalidOperationException("Ranked grading requires a minimum of 5 students to work.");
             }
             //
             var threshold =(int)Math.Ceiling(Students.Count * 0.2); //20% of Total number of students, Ceiling rounds to nearest whole numbercast to an int as it wikl need to be indexed
            var grades = Students.OrderByDescending(e => e.AverageGrade).Select(e => e.AverageGrade).ToList(); //oder by average grade

            if (grades[threshold-1] <= averageGrade)
             {
                 return 'A';
             }
             else if(grades[(threshold * 2) -1] <= averageGrade)
             {
                 return 'B';
             }
             else if (grades[(threshold * 3) - 1] <= averageGrade)
             {
                 return 'C';
             }
             else if (grades[(threshold * 4) - 1] <= averageGrade)
             {
                 return 'D';
             }
             else return 'F';
            //base.GetLetterGrade(averageGrade)
            
        }

    }
}
