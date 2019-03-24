using System;
using System.Text;
using System.Collections.Generic;

namespace HackerRank
{
    public class GradingStudents : AbsProblem, IProblem
    {
        public GradingStudents() : base("Grading Students Problem")
        {
        }

        /// <summary>
        /// Rounds up Grades when grade is within 2 range
        /// Will not round up numbers if it is 40
        /// 
        /// Input:
        /// 4 - Number Count
        /// 73
        /// 67
        /// 38
        /// 33
        /// 
        /// Output:
        /// 75
        /// 67
        /// 40
        /// 33
        /// 
        /// </summary>
        public void Begin()
        {
            Console.WriteLine("Enter Grade Count:");
            int n = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Enter Grades:");
            int[] grades = new int[n];

            for (int gradesItr = 0; gradesItr < n; gradesItr++)
            {
                int gradesItem = Convert.ToInt32(Console.ReadLine());
                grades[gradesItr] = gradesItem;
            }

            int[] result = gradingStudents(grades);

            Console.WriteLine("\nCurved Up Grade:");
            foreach (var num in result)
            {
                Console.WriteLine(num);
            }
        }

        static void bestSolution(int[] arry)
        {
            int finalGrade = 0;

            foreach (int grade in arry)
            {
                if (grade >= 38)
                {
                    if (grade % 5 == 3)
                    {
                        finalGrade += 2;
                    }
                    else if (grade % 5 == 4)
                    {
                        finalGrade += 1;
                    }
                }
                Console.WriteLine(finalGrade);
            }
        }


        static int[] gradingStudents(int[] grades)
        {
            List<int> gradeList = new List<int>();
            int baseNum = 0;
            int roundedGrade = 0;

            foreach (int grade in grades)
            {
                baseNum = grade % 10;

                //Next Multiple base will include 5
                if (baseNum < 5)
                {

                    //Round Up
                    if (5 - baseNum < 3)
                    {
                        int nextDigit = grade / 10;
                        roundedGrade = (nextDigit * 10) + 5;
                    }
                    else
                    {
                        roundedGrade = grade;
                    }

                }
                //Next Multiple base will be 0
                else if (baseNum >= 5)
                {
                    if (10 - baseNum < 3)
                    {
                        int nextDigit = grade / 10;
                        nextDigit++;
                        roundedGrade = (nextDigit * 10);
                    }
                    else
                    {
                        roundedGrade = grade;
                    }

                }

                if (roundedGrade < 40)
                {
                    gradeList.Add(grade);
                }
                else
                {
                    gradeList.Add(roundedGrade);
                }
            }

            return gradeList.ToArray();
        }
    }
}
