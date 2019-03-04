using System
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using GradeBook.Enums;

namespace GradeBook.GradeBooks
{
    public class RankedGradeBook : BaseGradeBook
    {
        // Determined by peer results, top 20% get A, 20% get b....
        public RankedGradeBook(string name, bool isWeighted) : base(name, isWeighted)
        {
            Type = GradeBookType.Ranked;

        }

         public override char GetLetterGrade(double averageGrade)
         {
             if (Students.Count < 5)
             {
                 throw new InvalidOperationException("Ranked grading requires a minimum of 5 students to work.");
             }

             var threshold =
                 (int) Math.Ceiling(Students.Count *0.2); //20% of Total number of students, Ceiling rounds to nearest whole numbercast to an int as it will need to be indexed
             var grades = Students
                 .OrderByDescending(e => e.AverageGrade)
                 .Select(e => e.AverageGrade)
                 .ToList(); //order by average grade.
           

             if (grades[threshold - 1] <= averageGrade)
             {
                 return 'A';
             }
             else if (grades[(threshold * 2) - 1] <= averageGrade)
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
             else
             {
                 return 'F';

             }
         }

         //base.GetLetterGrade(averageGrade)

            public override void CalculateStatistics()
            {
                if (Students.Count < 5)
                {
                  Console.WriteLine("Ranked grading requires at least 5 students with grades in order to properly calculate a student's overall grade.");
                  return;
                }
                else
                {
                base.CalculateStatistics();
                }
            }

            public override void CalculateStudentStatistics(string name)
            {
                if (Students.Count < 5)
                {
                    Console.WriteLine("Ranked grading requires at least 5 students with grades in order to properly calculate a student's overall grade.");
                    return;
                }
                else
                {
                    base.CalculateStudentStatistics(name);
                }
            }


    }

    }

