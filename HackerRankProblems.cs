using System.Collections.Generic;

namespace HackerRank
{
    public class HackerRankProblems
    {
        //Collection of all HackerRank Problems
        private Dictionary<int, AbsProblem> hrProblems = new Dictionary<int, AbsProblem>();

        public HackerRankProblems()
        {
            InitializeHRProblems();
        }

        private void InitializeHRProblems()
        {
            hrProblems.Add(1, new RotateArray());
            hrProblems.Add(2, new Anagrams());
            hrProblems.Add(3, new RansomNoteGenerator());
            hrProblems.Add(4, new DoubleyLinkedList());
            hrProblems.Add(5, new BubbleSort());
            hrProblems.Add(6, new TriesContactsApplication());
            hrProblems.Add(7, new IceCreamParlor());
            hrProblems.Add(8, new StackImp());
            hrProblems.Add(9, new CommonChar());
            hrProblems.Add(10, new SumOfDiagonalArray());
            hrProblems.Add(11, new PlusMinus());
            hrProblems.Add(12, new sumMinMax());
            hrProblems.Add(13, new BirthdayCakeCandles());
            hrProblems.Add(14, new TimeConversion());
            hrProblems.Add(15, new GradingStudents());
            hrProblems.Add(16, new ApplesAndOranges());
            hrProblems.Add(17, new SaveThePrisioner());
            hrProblems.Add(18, new ClimbingLeaderBoard());
        }

        public void BeginProblem(int iUserInput)
        {
            AbsProblem problem;

            if (hrProblems.TryGetValue(iUserInput, out problem))
            {
                problem.Begin();
            }
            else
            {

            }
        }
    }
}
