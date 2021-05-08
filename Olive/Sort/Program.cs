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

        events = events.OrderBy(e => e.Time).ToList();

        var output = new List<string>();
        foreach (var e in events) {
            output.Add(e.ToString());
        }

        return output;

    }

    private static List<EventData> ParseEvents(string teamName, List<string> events) {
        var output = new List<EventData>();
        var integers = new char[] { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };
        foreach (var e in events) {
            //Again, regex would be faster/better here.
            var beginTimeIndex = e.IndexOfAny(integers);
            var endTimeIndex = e.LastIndexOfAny(integers);
            var additional = e.IndexOf('+');

            if (beginTimeIndex < 0 || endTimeIndex < 0) {
                Console.WriteLine("Missing time");
            }

            var employeeName = e.Substring(0,beginTimeIndex);
            var lastInfo = e.Substring(endTimeIndex +1);

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
                                           EventName = lastInfo
                                       });

        }
        return output;
    }


    public class EventData {
        public string TeamName { get; set; }
        public string EmployeeName { get; set; }
        public int Time { get; set; }
        public string DisplayTime { get; set; }
        public string EventName { get; set; }

        public override string ToString() {
            return $"{TeamName} {EmployeeName} {DisplayTime} {EventName}";
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