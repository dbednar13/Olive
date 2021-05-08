using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text.RegularExpressions;
using System.Text;
using System;



class Result {

    /*
     * Complete the 'getEventsOrder' function below.
     *
     * The function is expected to return a STRING_ARRAY.
     * The function accepts following parameters:
     *  1. STRING team1
     *  2. STRING team2
     *  3. STRING_ARRAY events1
     *  4. STRING_ARRAY events2
     */

    public static List<string> getEventsOrder(string team1, string team2, List<string> events1, List<string> events2) {

        var events = ParseEvents(team1, events1);
        events.AddRange(ParseEvents(team2, events2));

        //events = events.OrderBy(e => e.Time).ThenBy(e=> e.SecondTeamName).ThenBy(e=> e.EventName).ToList();

        events.Sort(new EventCompare());

        var output = new List<string>();
        foreach (var e in events) {
            output.Add(e.ToString());
        }

        return output;

    }

    private static List<EventData> ParseEvents(string teamName, List<string> events) {
        var output = new List<EventData>();
        var integers = new char[] { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };

        Console.WriteLine($"Team: {teamName}");

        foreach (var e in events) {
            Console.WriteLine($"{e}");
            //Again, regex would be faster/better here.
            var beginTimeIndex = e.IndexOfAny(integers);
            var endTimeIndex = e.LastIndexOfAny(integers);
            var additional = e.IndexOf('+');

            if (beginTimeIndex < 0 || endTimeIndex < 0) {
                Console.WriteLine("Missing time");
            }

            var employeeName = e.Substring(0,beginTimeIndex);
            //This should work, does locally but exception on the hackerRank side.  sad.
            // hacking way around hackerRank's limit due to time.
            //var lastInfo = e.Substring(endTimeIndex +1).Trim().Split(' ', 1);
            var lastInfo = e.Substring(endTimeIndex + 1).Trim().Split(' ');
            if (lastInfo.Length == 1) {
                lastInfo = new string[] {lastInfo[0], ""};
            }


            if (lastInfo.Length > 2) {
                for (int x = 2; x < lastInfo.Length; x++) {
                    //should use string.Concat.
                    lastInfo[1] = lastInfo[1] + " " + lastInfo[x];
                }
            }


            if (additional > 0 && (additional < beginTimeIndex || additional > endTimeIndex)) {
                Console.WriteLine($"{e}: + is after the last number, it should not be.");
            }

            var displayTime = e.Substring(beginTimeIndex, endTimeIndex - beginTimeIndex + 1);
            var time = -1;
            if (displayTime.Contains('+')) {
                var temp = displayTime.Split('+');
                try {
                    time = int.Parse(temp[0]);
                } catch (Exception) {
                    //Not the cleanest, but it's fast as my time dwindles.  A try parse would be better
                    Console.WriteLine($"{e} unable to calculate time for {displayTime}");
                    continue;
                }
            } else {
                time = int.Parse(displayTime);
            }

            if (time < 0 || time > 90) {
                Console.WriteLine($"{e} invalid amount of time {time}");
            }

            output.Add(new EventData() {
                                           TeamName = teamName,
                                           EmployeeName = employeeName,
                                           Time = time,
                                           DisplayTime = displayTime,
                                           EventName = lastInfo[0],
                                           SecondTeamName = !string.IsNullOrWhiteSpace(lastInfo[1]) ? " " + lastInfo[1] : ""
                                       });

        }
        return output;
    }

    public class EventCompare : IComparer<EventData> {
        public int Compare(EventData x, EventData y) {
            var time = x.Time.CompareTo(y.Time);
            if (time != 0) {
                return time;
            }

            if (!x.DisplayTime.Contains('+') && y.DisplayTime.Contains('+')) {
                return -1;
            }
            if (x.DisplayTime.Contains('+') && !y.DisplayTime.Contains('+')) {
                return +1;
            }
            if (x.DisplayTime.Contains('+') && y.DisplayTime.Contains('+')) {
                var xSplit = x.DisplayTime.Split('+');
                var ySplit = y.DisplayTime.Split('+');
                var comp = String.Compare(xSplit[1], ySplit[1]);
                if (comp != 0) {
                    return comp;
                }
            }

            if (string.IsNullOrWhiteSpace(x.SecondTeamName) && string.IsNullOrWhiteSpace(y.SecondTeamName)) {
                //should sort g/y/r/s
                var values = new Dictionary<string, int>();
                values.Add("G", 0);
                values.Add("Y", 1);
                values.Add("R", 2);
                values.Add("S", 3);

                var xval = values[x.EventName.Trim()];
                var yval = values[y.EventName.Trim()];

                return String.Compare(x.EventName, y.EventName);
            }

            if (string.IsNullOrWhiteSpace(x.SecondTeamName) && !string.IsNullOrWhiteSpace(y.SecondTeamName)) {
                return -1;
            }

            if (!string.IsNullOrWhiteSpace(x.SecondTeamName) && string.IsNullOrWhiteSpace(y.SecondTeamName)) {
                return +1;
            }

            if (!string.IsNullOrWhiteSpace(x.SecondTeamName) && !string.IsNullOrWhiteSpace(y.SecondTeamName)) {
                return String.CompareOrdinal(x.SecondTeamName, y.SecondTeamName);
            }

            return 0;
        }
    }


    public class EventData {
        public string TeamName { get; set; }
        public string EmployeeName { get; set; }
        public int Time { get; set; }
        public string DisplayTime { get; set; }
        public string EventName { get; set; }
        public string SecondTeamName{ get; set; }

        public override string ToString() {
            return $"{TeamName} {EmployeeName}{DisplayTime} {EventName}{SecondTeamName}";
        }

    }
}

class Solution {
    public static void Main(string[] args) {
        TextWriter textWriter = new StreamWriter("C:\\Users\\DanBednar\\Documents\\GitHub\\Olive\\Olive\\Sort\\test.txt", true);

        string team1 = Console.ReadLine();

        string team2 = Console.ReadLine();

        int events1Count = Convert.ToInt32(Console.ReadLine().Trim());

        List<string> events1 = new List<string>();

        for (int i = 0; i < events1Count; i++) {
            string events1Item = Console.ReadLine();
            events1.Add(events1Item);
        }

        int events2Count = Convert.ToInt32(Console.ReadLine().Trim());

        List<string> events2 = new List<string>();

        for (int i = 0; i < events2Count; i++) {
            string events2Item = Console.ReadLine();
            events2.Add(events2Item);
        }

        List<string> result = Result.getEventsOrder(team1, team2, events1, events2);

        textWriter.WriteLine(String.Join("\n", result));

        textWriter.Flush();
        textWriter.Close();
    }
}