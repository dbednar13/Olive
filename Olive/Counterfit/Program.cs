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
     * Complete the 'countCounterfeit' function below.
     *
     * The function is expected to return an INTEGER.
     * The function accepts STRING_ARRAY serialNumber as parameter.
     */

    public static int countCounterfeit(List<string> serialNumber) {

        var validAmount = 0;
        var validDenoms = new int[] { 10,20,50,100, 200,500,1000 };
        foreach (var serial in serialNumber) {
            

            if (serial.Length < 10 || serial.Length > 12) {
                Console.WriteLine($"serial: {serial}, length: {serial.Length}");
                continue;
            }

            //If I knew regex this would be the place to do it instead of all the validation - but I don't and I'm on a time limit.
            // Would Probably be done better that way but such is life in a timed assessment.

            var starting = serial.Substring(0, 3);
            var year = serial.Substring(3, 4);
            var remainder = serial.Substring(7);
            var denom = remainder.Substring(0, remainder.Length - 1);
            var last = serial.Substring(serial.Length - 1).ToCharArray()[0];

            //Checks normally split into separate functions, done inline to save some time for assessment.
            var validStart = true;
            foreach (var c in starting.ToCharArray()) {
                if (!char.IsLetter(c) || !char.IsUpper(c)) {
                    Console.WriteLine($"serial: {serial}, Starting character not valid: {c}");
                    validStart = false;
                    break;
                }
            }

            if (!validStart || starting.Distinct().Count() != 3) {
                Console.WriteLine($"serial: {serial}, Starting All 3 starting not distinct");
                continue;
            }

            if (int.TryParse(year, out int calcyear)) {
                if (calcyear < 1900 || calcyear > 2019) {
                    Console.WriteLine($"serial: {serial}, year {calcyear} out of range");
                    continue;
                }
            } else {
                Console.WriteLine($"serial: {serial},unable to calc year {year}");
                continue;
            }

            if (!char.IsLetter(last) || !char.IsUpper(last)) {
                Console.WriteLine($"serial: {serial}, last character not valid {last}");
                continue;
            }

            if (int.TryParse(denom, out int amount)) {
                if (validDenoms.Contains(amount)) {
                    validAmount += amount;
                } else {
                    Console.WriteLine($"serial: {serial}, invalid denomination {denom}");
                }
            }

        }

        return validAmount;
    }

}

class Solution {
    public static void Main(string[] args) {
        //TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);
        TextWriter textWriter = new StreamWriter("C:\\Users\\DanBednar\\Documents\\GitHub\\Olive\\Olive\\Counterfit\\test.txt", true);

        
        int serialNumberCount = Convert.ToInt32(Console.ReadLine().Trim());

        List<string> serialNumber = new List<string>();

        for (int i = 0; i < serialNumberCount; i++) {
            string serialNumberItem = Console.ReadLine();
            serialNumber.Add(serialNumberItem);
        }

        int result = Result.countCounterfeit(serialNumber);

        textWriter.WriteLine(result);

        textWriter.Flush();
        textWriter.Close();
    }
}