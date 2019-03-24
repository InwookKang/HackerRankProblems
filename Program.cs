using System;

namespace HackerRank
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Choose Problem To Solve: ");
            UserInput userInput = new UserInput();
            int iUserInput = userInput.intUserInput();

            HackerRankProblems hackerRankProblems = new HackerRankProblems();


            hackerRankProblems.BeginProblem(iUserInput);
        }
    }
}
