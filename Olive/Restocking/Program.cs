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
     * Complete the 'restock' function below.
     *
     * The function is expected to return an INTEGER.
     * The function accepts following parameters:
     *  1. INTEGER_ARRAY itemCount
     *  2. INTEGER target
     */

    public static int restock(List<int> itemCount, int target) {
        var total = 0;


        foreach (var item in itemCount) {
            total += item;
            if (total > target) {
                break;
            } 
            
            if (total == target) {
                return 0;
            }
        }

        if (total == target) {
            return 0;
        } 
        
        if (total < target) {
            return target - total;
        }
        return total - target;

    }

}

class Solution {
    public static void Main(string[] args) {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        int itemCountCount = Convert.ToInt32(Console.ReadLine().Trim());

        List<int> itemCount = new List<int>();

        for (int i = 0; i < itemCountCount; i++) {
            int itemCountItem = Convert.ToInt32(Console.ReadLine().Trim());
            itemCount.Add(itemCountItem);
        }

        int target = Convert.ToInt32(Console.ReadLine().Trim());

        int result = Result.restock(itemCount, target);

        textWriter.WriteLine(result);

        textWriter.Flush();
        textWriter.Close();
    }
}