using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using GradeBook.Enums;

namespace GradeBook.GradeBooks
{
    public class StandardGradeBook : BaseGradeBook
    {
        public StandardGradeBook(string name, bool isWeighted) : base(name, isWeighted) //Must invoke a constructor from BaseGrade book as it has inherited from it
        {//MUST set the inherited parameter on the left side too!!
            Type = GradeBookType.Standard;
        }
    }
}
