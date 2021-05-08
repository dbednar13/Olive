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