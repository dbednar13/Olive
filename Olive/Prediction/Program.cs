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
     * Complete the 'predictAnswer' function below.
     *
     * The function is expected to return an INTEGER_ARRAY.
     * The function accepts following parameters:
     *  1. INTEGER_ARRAY stockData
     *  2. INTEGER_ARRAY queries
     */

    public static List<int> predictAnswer(List<int> stockData, List<int> queries) {

    }

}

class Solution {
    public static void Main(string[] args) {
        TextWriter textWriter = new StreamWriter("C:\\Users\\DanBednar\\Documents\\GitHub\\Olive\\Olive\\Prediction\\test.txt", true);

        int stockDataCount = Convert.ToInt32(Console.ReadLine().Trim());

        List<int> stockData = new List<int>();

        for (int i = 0; i < stockDataCount; i++) {
            int stockDataItem = Convert.ToInt32(Console.ReadLine().Trim());
            stockData.Add(stockDataItem);
        }

        int queriesCount = Convert.ToInt32(Console.ReadLine().Trim());

        List<int> queries = new List<int>();

        for (int i = 0; i < queriesCount; i++) {
            int queriesItem = Convert.ToInt32(Console.ReadLine().Trim());
            queries.Add(queriesItem);
        }

        List<int> result = Result.predictAnswer(stockData, queries);

        textWriter.WriteLine(String.Join("\n", result));

        textWriter.Flush();
        textWriter.Close();
    }
}