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
     * Complete the 'distinctMoves' function below.
     *
     * The function is expected to return an INTEGER.
     * The function accepts following parameters:
     *  1. STRING s
     *  2. INTEGER n
     *  3. INTEGER x
     *  4. INTEGER y
     */

    public static int distinctMoves(string s, int n, int x, int y) {
        //TODO Magic
    }

}

class Solution {
    public static void Main(string[] args) {
        //TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);
        TextWriter textWriter = new StreamWriter("C:\\Users\\DanBednar\\Documents\\GitHub\\Olive\\Olive\\Paths\\test.txt", true);

        string s = "rrlrlr";
        //string s = Console.ReadLine();

        int n = 6;
        //int n = Convert.ToInt32(Console.ReadLine().Trim());

        int x = 1;
        //int x = Convert.ToInt32(Console.ReadLine().Trim());

        int y = 2;
        //int y = Convert.ToInt32(Console.ReadLine().Trim());

        int result = Result.distinctMoves(s, n, x, y);

        textWriter.WriteLine(result);

        textWriter.Flush();
        textWriter.Close();
    }
}