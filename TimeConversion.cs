using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Text;
namespace HackerRank
{
    public class TimeConversion : AbsProblem, IProblem
    {
        public TimeConversion() : base("Time Conversion")
        {
        }

        /// <summary>
        /// Converts Regular time format to 
        /// Military Format 
        /// Example: 07:05:45PM to 19:05:45
        /// </summary>
        public void Begin()
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

        static string[] parseTimeSegements(string time)
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
    }
}
