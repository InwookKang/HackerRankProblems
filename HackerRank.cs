using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace TestConsoleApp
{
    class HackerRank : Problem
    {
        private Dictionary<int, Action> _problems = new Dictionary<int, Action>();
        public HackerRank()
        {
            Description = "HackerRank Problems";
        }

        private void DisplayProblem()
        {
            Console.WriteLine("-------------------------");
            Console.WriteLine($"1. Diagonal Sum Problem");
            Console.WriteLine($"2. Plus Minus Problem");
            Console.WriteLine($"3. Stair Case Problem");
            Console.WriteLine($"4. Mini Min-Max Problem");
            Console.WriteLine($"5. Time Conversion Problem");
            Console.WriteLine($"6. Grade Round up Problem");
            Console.WriteLine($"7. Kangaroo Problem");
            Console.WriteLine($"8. Break The Record Problem");
            Console.WriteLine($"9. Birthday Chocoloate Cake Problem");
            Console.WriteLine($"10. Climbing Leader Board Problem");
            Console.WriteLine($"11. Divisible Sum Pairs Problem");
            Console.WriteLine($"12. Time to Words");
            Console.WriteLine("13. Chocolate Feast");
            Console.WriteLine("14. BonAppetit");
            Console.WriteLine("15. Drawing Book");
            Console.WriteLine("16. Counting Valleys");
            Console.WriteLine("17. Electronics Shop");
            Console.WriteLine("18. Cat and Mouse");
            Console.WriteLine("19. Encryption");
            Console.WriteLine("20. Bigger Is Greater");
            Console.WriteLine("-------------------------");
        }

        private void InitializeProblems()
        {
            if (_problems.Count() <= 0)
            {
                _problems.Add(1, DiagonalSumProblem);
                _problems.Add(2, PlusMinus);
                _problems.Add(3, StairCase);
                _problems.Add(4, miniMinMax);
                _problems.Add(5, TimeConversion);
                _problems.Add(6, GradeRoundUp);
                _problems.Add(7, Kangaroo);
                _problems.Add(8, BreakTheRecord);
                _problems.Add(9, BirthdayChocolate);
                _problems.Add(10, ClimbingLeaderBoard);
                _problems.Add(11, DivisibleSumPairs);
                _problems.Add(12, TimeToWords);
                _problems.Add(13, ChocolateFeast);
                _problems.Add(14, BonAppetitInit);
                _problems.Add(15, DrawingBookInit);
                _problems.Add(16, CountingValleysInit);
                _problems.Add(17, ElectronicsShopInit);
                _problems.Add(18, CatAndMouseInit);
                _problems.Add(19, EncryptionInit);
                _problems.Add(20, BiggerIsGreaterInit);
            }
        }

        public override void Run()
        {
            InitializeProblems();
            Console.WriteLine("Enter Problem To Run: ");
            DisplayProblem();

            int problem;
            Int32.TryParse(Console.ReadLine(), out problem);

            Action methodRun;
            if (!_problems.TryGetValue(problem, out methodRun))
            {
                Console.WriteLine("Not a Valid Problem");
            }
            else
            {
                methodRun.Invoke();
            }
        }

        /// <summary>
        /// Problem: Print out the number of pairs that two 
        /// number pairs are also divisible by another number
        /// </summary>
        private void DivisibleSumPairs()
        {
            string[] nk = Console.ReadLine().Split(' ');

            int n = Convert.ToInt32(nk[0]);

            int k = Convert.ToInt32(nk[1]);

            int[] ar = Array.ConvertAll(Console.ReadLine().Split(' '), arTemp => Convert.ToInt32(arTemp));

            divisibleSumPairs(n, k, ar);
        }

        private void divisibleSumPairs(int n, int k, int[] ar)
        {
            int sum = 0;
            int answer = 0;

            for (int i = 0; i < ar.Count(); i++)
            {
                for (int j = i + 1; j < ar.Count(); j++)
                {
                    sum = ar[i] + ar[j];
                    if (sum % k == 0)
                    {
                        answer++;
                    }
                }
            }
        }

        /// <summary>
        /// Given Set of numbers, output which position the newly 
        /// inserted number will reside. 
        /// Starting with Index 0. 
        /// </summary>
        private void ClimbingLeaderBoard()
        {
            int scoresCount = Convert.ToInt32(Console.ReadLine());

            int[] scores = Array.ConvertAll(Console.ReadLine().Split(' '), scoresTemp => Convert.ToInt32(scoresTemp))
            ;
            int aliceCount = Convert.ToInt32(Console.ReadLine());

            int[] alice = Array.ConvertAll(Console.ReadLine().Split(' '), aliceTemp => Convert.ToInt32(aliceTemp))
            ;
            int[] result = climbingLeaderboard(scores, alice);
        }

        private int[] climbingLeaderboard(int[] scores, int[] inputScores)
        {
            var indexedNumbers = scoreNumbers(scores);
            List<int> answer = new List<int>();

            for (int i = 0; i < inputScores.Length; i++)
            {
                if (indexedNumbers.ContainsValue(inputScores[i]))
                {
                    answer.Add(indexedNumbers.FirstOrDefault(x => x.Value == inputScores[i]).Key);
                }
                else
                {
                    //Need to Optimize for huge input values
                    int index = 1;
                    foreach (var rankedNumbers in indexedNumbers)
                    {
                        if (rankedNumbers.Value < inputScores[i])
                        {
                            answer.Add(index);
                            index = 0;
                            break;
                        }
                        else if (rankedNumbers.Value > inputScores[i])
                        {
                            index++;
                            continue;
                        }
                    }
                    if (index != 0)
                    {
                        answer.Add(index);
                    }
                }
            }

            return answer.ToArray();
        }

        private Dictionary<int, int> scoreNumbers(int[] scores)
        {
            Dictionary<int, int> leaderBoard = new Dictionary<int, int>();
            int rank = 1;
            foreach (int score in scores)
            {
                if (leaderBoard.Keys.Count() == 0)
                {
                    leaderBoard.Add(1, score);
                }
                else if (!leaderBoard.ContainsValue(score))
                {
                    leaderBoard.Add(++rank, score);
                }
            }

            return leaderBoard;
        }

        /// <summary>
        /// Problem: Given an array of numbers Print out the count of highest number 
        /// </summary>
        private void BirthdayChocolate()
        {
            int arCount = Convert.ToInt32(Console.ReadLine());

            int[] ar = Array.ConvertAll(Console.ReadLine().Split(' '), arTemp => Convert.ToInt32(arTemp));

            int result = birthdayCakeCandles(ar);
        }

        private int birthdayCakeCandles(int[] ar)
        {
            int answer = 0;

            int highestNumber = ar.Max();
            answer = ar.Where(x => x == highestNumber).Count();

            return answer;
        }

        /// <summary>
        /// Problem: Output integer array that contains the number of times she broke her record for 
        /// minimum socred and maximum scored
        /// </summary>
        private void BreakTheRecord()
        {
            Console.WriteLine("Enter Number of scores:");
            int n = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Enter scores:");
            int[] scores = Array.ConvertAll(Console.ReadLine().Split(' '), scoresTemp => Convert.ToInt32(scoresTemp));

            int[] result = breakingRecords(scores);

            Console.WriteLine($"{result[0]} {result[1]}");
        }

        private int[] breakingRecords(int[] scores)
        {
            List<int> answer = new List<int>();
            int countMin = 0;
            int countMax = 0;
            int minNum = scores[0];
            int maxNum = scores[0];

            for (int i = 1; i < scores.Count(); i++)
            {
                if (scores[i] < minNum)
                {
                    countMin++;
                    minNum = scores[i];
                }
                else if (scores[i] > maxNum)
                {
                    countMax++;
                    maxNum = scores[i];
                }
            }

            answer.Add(countMax);
            answer.Add(countMin);

            return answer.ToArray();
        }

        /// <summary>
        /// PROBLEM: Fingure out a way to get both kangaroos at the 
        /// same location at the same time as parts of the show.
        /// 
        /// EXAMPLE: 
        /// param1: starting position of Kang1
        /// param1: jump distance of Kang1
        /// param2: starting position of Kang2
        /// param2: jump distance of Kang2
        /// 
        /// INPUT: 0 3 4 2
        /// OUTPUT: YES
        /// 
        /// </summary>
        void Kangaroo()
        {
            string[] x1V1X2V2 = Console.ReadLine().Split(' ');

            int x1 = Convert.ToInt32(x1V1X2V2[0]);

            int v1 = Convert.ToInt32(x1V1X2V2[1]);

            int x2 = Convert.ToInt32(x1V1X2V2[2]);

            int v2 = Convert.ToInt32(x1V1X2V2[3]);

            Console.WriteLine(CalculateJumps(x1, v1, x2, v2));
        }

        string CalculateJumps(int x1, int v1, int x2, int v2)
        {
            string caughtup = "NO";

            if (((x2 - x1) % (v2 - v1)) == 0)
            {
                caughtup = "YES";
            }

            return caughtup;
        }

        /// <summary>
        /// Rounds up Grades when grade is within 2 range
        /// Will not round up numbers if it is 38
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
        void GradeRoundUp()
        {
            int n = Convert.ToInt32(Console.ReadLine());

            int[] grades = new int[n];

            for (int gradesItr = 0; gradesItr < n; gradesItr++)
            {
                int gradesItem = Convert.ToInt32(Console.ReadLine());
                grades[gradesItr] = gradesItem;
            }

            int[] result = gradingStudents(grades);
        }

        int[] gradingStudents(int[] grades)
        {
            List<int> gradeList = new List<int>();

            foreach (int grade in grades)
            {
                if (grade <= 38)
                {
                    gradeList.Add(grade);
                }
                //Don't round up
                if ((grade % 5) < 3)
                {

                }
            }

            return gradeList.ToArray();
        }

        /// <summary>
        /// Converts Regular time format to 
        /// Military Format 
        /// Example: 07:05:45PM to 19:05:45
        /// </summary>
        void TimeConversion()
        {
            Console.WriteLine("Enter Time:");
            StringBuilder strBuilder = new StringBuilder();

            string s = Console.ReadLine();

            string[] times = parseTimeSegements(s);

            int hour, minute, second;

            bool hourResult = Int32.TryParse(times[0], out hour);
            bool minuteResult = Int32.TryParse(times[1], out minute);
            bool secondResult = Int32.TryParse(times[2], out second);

            bool timePeriod = times[3] == "AM" ? true : false;

            if (hourResult && minuteResult && secondResult)
            {
                //Add 12 if its PM
                if (!timePeriod)
                {
                    if (hour != 12)
                    {
                        //Convert hour to military time
                        hour += 12;
                    }
                }
                else
                {
                    if (hour == 12)
                    {
                        hour = 0;
                    }
                }
            }

            strBuilder.Append((hour <= 9 ? "0" + hour.ToString() : hour.ToString()) + ":");
            strBuilder.Append((minute <= 9 ? "0" + minute.ToString() : minute.ToString()) + ":");
            strBuilder.Append((second <= 9 ? "0" + second.ToString() : second.ToString()));

            Console.WriteLine(strBuilder.ToString());
        }

        string[] parseTimeSegements(string time)
        {
            List<string> timeList = new List<string>();
            Regex reg = new Regex(@"([0-2][0-9]):([0-5][0-9]):([0-5][0-9])([PA][M])");
            Match match = reg.Match(time);

            if (match.Success)
            {
                for (int i = 1; i < match.Length; i++)
                {
                    timeList.Add(match.Groups[i].ToString());
                }
            }
            return timeList.ToArray();
        }

        /*
         * With Given set of integers, get Min and Max 
         * Sum of 4 numbers 
         */

        void miniMinMax()
        {
            Console.WriteLine("Enter 5 Numbers");
            int[] arr = Array.ConvertAll(Console.ReadLine().Split(' '), arrTemp => Convert.ToInt32(arrTemp));

            getMinMax(arr);
        }

        void getMinMax(int[] arr)
        {
            int max = arr.Max();
            int min = arr.Min();
            int sum = 0;

            for (int i = 0; i < arr.Length; i++)
            {
                sum += arr[i];
            }

            Console.WriteLine($"{sum - max} {sum - min}");
        }
        /*
         * With Given integer, create a Staircase 
         * using Hash symbol and space
         * It needs to be right-aligned
         * 
         * Example: 
         *       #
                ##
               ###
              ####
             #####
            ######
         * 
         */
        void StairCase()
        {
            Console.WriteLine("Enter Number if Stair Level:");
            int n = Convert.ToInt32(Console.ReadLine());

            createHashStaircase(n);
        }

        void createHashStaircase(int count)
        {
            StringBuilder build = new StringBuilder();

            for (int lineCount = 1; lineCount <= count; lineCount++)
            {
                for (int spaceCount = (count - lineCount); spaceCount < count && spaceCount != 0; spaceCount--)
                {
                    build.Append(" ");
                }
                for (int hashCount = 1; hashCount <= lineCount; hashCount++)
                {
                    build.Append("#");
                }
                if (lineCount != count)
                {
                    build.Append("\n");
                }
            }

            Console.WriteLine(build.ToString());
        }

        /*
         * With Given Array and total element count,
         * get the ratio of positive, negative and zero 
         * within the array. 
         * 
         */
        void PlusMinus()
        {
            Console.WriteLine("Plus Minus Problem");
            Console.WriteLine("Enter Total Number Count");
            int n = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Enter Numbers:");
            int[] arr = Array.ConvertAll(Console.ReadLine().Split(' '), arrTemp => Convert.ToInt32(arrTemp));

            getNumberRatio(arr);
        }

        void getNumberRatio(int[] arr)
        {
            double positiveCount = 0;
            double negativeCount = 0;
            double zeroCount = 0;

            foreach (int num in arr)
            {
                if (num < 0)
                {
                    negativeCount++;
                }
                if (num > 0)
                {
                    positiveCount++;
                }
                if (num == 0)
                {
                    zeroCount++;
                }
            }

            double posRatio = positiveCount / (double)arr.Length;
            double negRatio = negativeCount / (double)arr.Length;
            double zeroRatio = zeroCount / (double)arr.Length;

            Console.WriteLine($"{posRatio.ToString("N6")}");
            Console.WriteLine($"{negRatio.ToString("N6")}");
            Console.WriteLine($"{zeroRatio.ToString("N6")}");
        }

        void DiagonalSumProblem()
        {
            DisplayQuestionToUser("Enter Number for Dimemsion:");

            int n = Convert.ToInt32(Console.ReadLine());

            int[][] arr = new int[n][];

            DisplayQuestionToUser("Enter Numbers:");
            for (int i = 0; i < n; i++)
            {
                arr[i] = Array.ConvertAll(Console.ReadLine().Split(' '), arrTemp => Convert.ToInt32(arrTemp));
            }

            int result = diagonalDifference(arr, n);

            Console.WriteLine($"Answer: {result}");
        }

        // Complete the diagonalDifference function below.
        int diagonalDifference(int[][] arr, int count)
        {
            int LRSum = GetLRSum(arr, count);
            int RLSum = GetRLSum(arr, count);

            return Math.Abs(LRSum - RLSum);
        }

        int GetDiagonalSum(bool leftToRight, int[][] arr, int dimensions)
        {
            int rowCount = dimensions;
            int colCount = dimensions;
            int rowSelector = rowCount;
            int colSelector = 0;
            int sum = 0;

            if (leftToRight)
            {
                for (rowSelector -= rowCount; rowSelector < rowCount; rowSelector++)
                {
                    sum += arr[rowSelector][rowSelector];
                }
            }
            else
            {
                for (rowSelector = rowCount - 1; rowSelector < rowCount && rowSelector >= 0; rowSelector--)
                {
                    sum += arr[rowSelector][colSelector];
                    colSelector++;
                }
            }

            return sum;
        }

        int GetLRSum(int[][] arr, int count)
        {
            return GetDiagonalSum(true, arr, count);
        }

        int GetRLSum(int[][] arr, int count)
        {
            return GetDiagonalSum(false, arr, count);
        }

        Dictionary<int, string> hourToString = new Dictionary<int, string>();
        Dictionary<int, string> minutesToString = new Dictionary<int, string>();

        private void TimeToWords()
        {
            StringBuilder stringBuilder = new StringBuilder();
            InitializeHourString();
            InitializeMinuteString();

            DisplayQuestionToUser("Enter Hour");
            int hour = UserInputControl.UserInputControl.ReadInt();

            DisplayQuestionToUser("Enter Minutes");
            int minutes = UserInputControl.UserInputControl.ReadInt();

            //Entered Minutes greater than 60
            minutes = minutes >= 60 ? minutes % 60 : minutes;

            /*
            *  For minutes 0 = o'clock
            *  For minutes between 1 and 30 use past
            *  For minutes greater than 30 use to (Subtract from 60)
            * 
            *  Key minutes 
            *  30 = half
            *  15 and 45 = quarter
            *  
            */

            //Convert Minutes
            if (minutes <= 0)
            {
                stringBuilder.Append(GetHourToString(hour) + " " + GetMinutesToString(minutes));
            }
            else if (minutes >= 1 && minutes < 15)
            {
                stringBuilder.Append(GetMinutesToString(minutes) + " past " + GetHourToString(hour));
            }
            else if (minutes == 15)
            {
                stringBuilder.Append(GetMinutesToString(minutes) + " past " + GetHourToString(hour));
            }
            else if (minutes > 15 && minutes < 30)
            {
                stringBuilder.Append(GetMinutesToString(minutes) + " past " + GetHourToString(hour));
            }
            else if (minutes == 30)
            {
                stringBuilder.Append(GetMinutesToString(minutes) + " past " + GetHourToString(hour));
            }
            else if (minutes > 30 && minutes < 45)
            {
                stringBuilder.Append(GetMinutesToString(60 - minutes) + " to " + GetHourToString(hour + 1));
            }
            else if (minutes == 45)
            {
                stringBuilder.Append(GetMinutesToString(minutes) + " to " + GetHourToString(hour + 1));
            }
            else if (minutes > 45)
            {
                stringBuilder.Append(GetMinutesToString(60 - minutes) + " to " + GetHourToString(hour + 1));
            }

            Console.WriteLine(stringBuilder.ToString());
        }

        private void InitializeHourString()
        {
            hourToString.Add(1, "one");
            hourToString.Add(2, "two");
            hourToString.Add(3, "three");
            hourToString.Add(4, "four");
            hourToString.Add(5, "five");
            hourToString.Add(6, "six");
            hourToString.Add(7, "seven");
            hourToString.Add(8, "eight");
            hourToString.Add(9, "nine");
            hourToString.Add(10, "ten");
            hourToString.Add(11, "eleven");
            hourToString.Add(12, "twevle");
        }

        private void InitializeMinuteString()
        {
            minutesToString.Add(0, "o'clock");
            minutesToString.Add(1, "one minute");
            minutesToString.Add(2, "two minutes");
            minutesToString.Add(3, "three minutes");
            minutesToString.Add(4, "four minutes");
            minutesToString.Add(5, "five minutes");
            minutesToString.Add(6, "six minutes");
            minutesToString.Add(7, "seven minutes");
            minutesToString.Add(8, "eight minutes");
            minutesToString.Add(9, "nine minutes");
            minutesToString.Add(10, "ten minutes");
            minutesToString.Add(11, "elven minutes");
            minutesToString.Add(12, "twelve minutes");
            minutesToString.Add(13, "thirteen minutes");
            minutesToString.Add(14, "fourteen minutes");
            minutesToString.Add(15, "quarter");
            minutesToString.Add(16, "sixteen minutes");
            minutesToString.Add(17, "seventeen minutes");
            minutesToString.Add(18, "eighteen minutes");
            minutesToString.Add(19, "ninteen minutes");
            minutesToString.Add(20, "twenty minutes");
            minutesToString.Add(21, "twenty " + minutesToString[1]);
            minutesToString.Add(22, "twenty " + minutesToString[2]);
            minutesToString.Add(23, "twenty " + minutesToString[3]);
            minutesToString.Add(24, "twenty " + minutesToString[4]);
            minutesToString.Add(25, "twenty " + minutesToString[5]);
            minutesToString.Add(26, "twenty " + minutesToString[6]);
            minutesToString.Add(27, "twenty " + minutesToString[7]);
            minutesToString.Add(28, "twenty " + minutesToString[8]);
            minutesToString.Add(29, "twenty " + minutesToString[9]);
            minutesToString.Add(30, "half");
            minutesToString.Add(45, "quarter");
        }

        private string GetHourToString(int hour)
        {
            string hourString;
            hourToString.TryGetValue(hour, out hourString);

            return hourString;
        }

        private string GetMinutesToString(int minutes)
        {
            string minutesString;
            minutesToString.TryGetValue(minutes, out minutesString);

            return minutesString;
        }

        private void ChocolateFeast()
        {
            /*
             *   n: an integer representing Bobby's initial amount of money
             *   c: an integer representing the cost of a chocolate bar
             *   m: an integer representing the number of wrappers he can turn in for a free bar
             *
             *   Input:  The first line contains an integer, t, denoting the number of test cases to analyze. 
             *   Each of the next t lines contains three space-separated integers: n, c, and m. 
             *   They represent money to spend, cost of a chocolate, 
             *   and the number of wrappers he can turn in for a free chocolate.
             * 
             */
            DisplayQuestionToUser("Enter Number of Store Visits:");    
            int t = Convert.ToInt32(Console.ReadLine());

            for (int tItr = 0; tItr < t; tItr++)
            {
                DisplayQuestionToUser("Enter money, cost and wrappers:");
                string[] ncm = Console.ReadLine().Split(' ');

                int n = Convert.ToInt32(ncm[0]);

                int c = Convert.ToInt32(ncm[1]);

                int m = Convert.ToInt32(ncm[2]);

                int result = calculateFeasts(n, c, m);

                Console.WriteLine(result);
            }
        }

        private int calculateFeasts(int money, int cost, int wrapperCost)
        {
            int answer = 0;
            int candy = money / cost;
            int wrappers = 0;

            //
            if (wrappers > wrapperCost)
            {
                wrappers = candy / wrapperCost;
            }
            answer = candy;

            //answer +=

            return answer;
        }

        private void BonAppetitInit()
        {
            DisplayQuestionToUser("Enter Number of Items Ordered and Item that was not eaten. ");
            string[] nk = Console.ReadLine().TrimEnd().Split(' ');
            int n = Convert.ToInt32(nk[0]);
            int k = Convert.ToInt32(nk[1]);

            DisplayQuestionToUser("Enter costs of each item");
            List<int> bill = Console.ReadLine().TrimEnd().Split(' ').ToList().
                             Select(billTemp => Convert.ToInt32(billTemp)).ToList();

            DisplayQuestionToUser("Enter Amount that was charged");
            int b = Convert.ToInt32(Console.ReadLine().Trim());

            string answer = BonAppetit(bill, k, b);

            Console.WriteLine($"{answer}");
        }

        private string BonAppetit(List<int> bill, int k, int b)
        {
            int answer = 0;

            int itemCost = bill[k];
            int sum = 0;

            foreach (var item in bill)
            {
                sum += item;
            }

            answer = (sum - itemCost) / 2;

            answer = b - answer;

            if(answer <= 0)
            {
                return "Bon Appetit";
            }

            return answer.ToString();
        }

        private void DrawingBookInit()
        {
            /*
             * Find the Minimum number of pages that 
             * need to be turned to reach the Page Number
             * 
             * It can start from the end of book or at the beginning
             * 
             * */
            DisplayQuestionToUser("Enter Number of Pages in the Book:");
            int n = Convert.ToInt32(Console.ReadLine());

            DisplayQuestionToUser("Enter Page Number To Turn To");
            int p = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine($"Minimum Number of pages to Turn to get to page {p}: {getPageCount(n, p)}");
        }

        private int getPageCount(int n, int p)
        {
            //Example input
            //n = 2
            //p = 1
            //output = 0
            
            //Base Case
            if(n-p == 1)
            {
                if (n % 2 == 0)
                {
                    if(p == 1)
                    {
                        return p / 2;
                    }
                    else
                    {
                        return 1;
                    }
                }
                else
                {
                    return 0;
                }
            }

            int pagesTurnedFromEnd = (n - p) / 2;
            int pagesTurnedFromBeginning = p / 2;

            if(pagesTurnedFromBeginning > pagesTurnedFromEnd)
            {
                return pagesTurnedFromEnd;
            }
            else
            {
                return pagesTurnedFromBeginning;
            }
        }

        private void CountingValleysInit()
        {
            /*
             * Count the number of valleys 
             * that was walked acrossed
             * 
             * Valleys are step down from sea
             * level and then back to sea level
             * 
             */ 
            DisplayQuestionToUser("Enter number of Seteps to Take");
            int n = Convert.ToInt32(Console.ReadLine());

            DisplayQuestionToUser("Enter String of Path");
            string s = Console.ReadLine();

            Display($"{CountingValleys(n, s)}");
        }

        private int CountingValleys(int n, string s)
        {
            bool sealevel = true;
            int mountain = 0;
            int valley = 0;
            int valleyCount = 0;

           /*
            *           /\
            * _/\      /  \_
                 \    /
                  \/\/
            * 
            */

            for (int i = 0; i < n; i++)
            {
                if(s[i] == 'U')
                {
                    if(sealevel)
                    {
                        mountain++;
                        sealevel = false;
                    }
                    else
                    {
                        if (valley > 0)
                        {
                            valley--;
                        }
                        else
                        {
                            mountain++;
                        }
                    }
                }
                else if (s[i] == 'D')
                {
                    if (sealevel)
                    {
                        valley++;
                        sealevel = false;
                    }
                    else
                    {
                        if(mountain > 0)
                        {
                            mountain--;
                        }
                        else
                        {
                            valley++;
                        }                        
                    }
                }

                if (mountain == 0 &&
                    valley == 0)
                {
                    if (s[i] == 'U')
                    {
                        valleyCount++;
                    }

                    sealevel = true;
                }
            }

            return valleyCount;
        }

        private void ElectronicsShopInit()
        {
            /*
             * Given the price lists for the store's keyboards and USB drives, 
             * and Monica's budget, find and print the amount of money Monica will spend. 
             * If she doesn't have enough money to both a keyboard and a USB drive, print -1 instead. 
             * She will buy only the two required items. 
             * 
             */
            DisplayQuestionToUser("Enter Money To Spend, Number Of Keyboards and Number of USB drive Models");
            string[] bnm = Console.ReadLine().Split(' ');
                       
            int b = Convert.ToInt32(bnm[0]);
            
            int n = Convert.ToInt32(bnm[1]);

            int m = Convert.ToInt32(bnm[2]);

            DisplayQuestionToUser("Enter Cost of each Keyboard");
            int[] keyboards = Array.ConvertAll(Console.ReadLine().Split(' '), keyboardsTemp => Convert.ToInt32(keyboardsTemp));

            DisplayQuestionToUser("Enter Cost Of Each USB drive");
            int[] drives = Array.ConvertAll(Console.ReadLine().Split(' '), drivesTemp => Convert.ToInt32(drivesTemp));

            int moneySpent = getMoneySpent(keyboards, drives, b);

            Display($"{moneySpent}");
        }

        private int getMoneySpent(int[] keyboards, int[] drives, int b)
        {
            int answer = 0;
            int max = 0;
            int maxLength = 0;
            int minLength = 0;
            

            int keyLength = keyboards.Length;
            int drivesLength = drives.Length;

            if(keyLength >= drivesLength)
            {
                maxLength = keyLength;
                minLength = drivesLength;

                for (int i = 0; i < maxLength; i++)
                {
                    for (int j = 0; j < minLength; j++)
                    {
                        answer = keyboards[i] + drives[j];
                        if (answer < b)
                        {
                            if (max < answer)
                            {
                                max = answer;
                            }
                        }
                    }
                }
            }
            else
            {
                maxLength = drivesLength;
                minLength = keyLength;

                for (int i = 0; i < maxLength; i++)
                {
                    for (int j = 0; j < minLength; j++)
                    {
                        answer = keyboards[j] + drives[i];
                        if (answer < b)
                        {
                            if (max < answer)
                            {
                                max = answer;
                            }
                        }
                    }
                }
            }

            return max == 0 ? -1 : max;
        }

        private void CatAndMouseInit()
        {

        }

        private void EncryptionInit()
        {
            /*
             * Example Input: 
             *  if man was meant to stay on the ground god would have given us roots
             *  feedthedog
             *  chillout
             * After removing spaces, the length of characters will be 54. 
             * Taking the square root of that would be between 7 and 8
             * so the characters will be within 7 by 8 grid
             * 
             * if(rows * columns >= L (length of sentence))
             * then we use the rows and columns number to get grid parameters
             * else
             * we add one to the row 
             * 
             * Output: 
                imtgdvs fearwer mayoogo anouuio ntnnlvt wttddes aohghn sseoau
             * Instructions: 
             *  Print out left column followed by space and the next column
             * 
             */
            DisplayQuestionToUser("Enter Sentence To Be Encrypted");
            string inputSentence = Console.ReadLine();

            string longString = RemoveSpaces(inputSentence);

            string output = Encrypt(longString);

            Display(output);
        }

        private string RemoveSpaces(string sentence)
        {
            StringBuilder str = new StringBuilder();
            foreach(var letter in sentence)
            {
                if(!char.IsWhiteSpace(letter))
                {
                    str.Append(letter);
                }
            }

            return str.ToString();
        }

        private string Encrypt(string sentence)
        {
            StringBuilder str = new StringBuilder();
            double rowCount = Math.Floor(Math.Sqrt(sentence.Length));
            double columnCount = Math.Ceiling(Math.Sqrt(sentence.Length));
            int sentenceIndex = 0;
            char[,] charGrid;

            if (rowCount * columnCount >= sentence.Length)
            {
                charGrid = new char[(int)rowCount, (int)columnCount];
            }
            else
            {
                rowCount++;
                charGrid = new char[(int)rowCount, (int)columnCount];
            }

            for (int i = 0; i < rowCount; i++)
            {
                for (int j = 0; j < columnCount; j++)
                {
                    if (sentenceIndex < sentence.Length)
                    {
                        charGrid[i, j] = sentence[sentenceIndex];
                        sentenceIndex++;
                    }
                    else
                    {
                        break;
                    }
                }
            }

            Display2DArray(charGrid);

            for (int i = 0; i < columnCount; i++)
            {
                for (int j = 0; j < rowCount; j++)
                {
                    if (charGrid[j, i] != '\0')
                    {
                        str.Append(charGrid[j, i]);
                    }                   
                }

                if(i != columnCount-1)
                {
                    str.Append(" ");
                }
            }

            return str.ToString().TrimEnd();
        }

        private void BiggerIsGreaterInit()
        {

        }
    }
}
