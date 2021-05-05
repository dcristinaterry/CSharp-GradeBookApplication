using System;
using System.Collections.Generic;
using System.Text;

namespace GradeBook.GradeBooks
{
    public class RankedGradeBook : BaseGradeBook
    {
        public RankedGradeBook(String name) : base(name) {

            Type = Enums.GradeBookType.Ranked;

        }



        public override char GetLetterGrade(double averageGrade)
        {
            int numStudents = base.Students.Count;
           
            if (numStudents < 5) {

                throw new InvalidOperationException("Ranked-grading requires a minimum of 5 students to work");
              
            }

            int counter = 0;
            foreach (var student in base.Students) {

                var studentAverageGrade = student.AverageGrade;

                if (averageGrade > studentAverageGrade) {
                    counter++;
                }

            }

            int percentageGrade = (counter * 100) / numStudents;


            if (percentageGrade > 80)
                return 'F';
            else if (percentageGrade > 60)
                return 'D';
            else if (percentageGrade > 40)
                return 'C';
            else if (percentageGrade > 20)
                return 'B';
            else
                return 'A';

          
        }

    }



}
