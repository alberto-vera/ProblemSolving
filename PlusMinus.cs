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

class Result
{

    /*
     * Complete the 'plusMinus' function below.
     *
     * The function accepts INTEGER_ARRAY arr as parameter.
     */

    public static void plusMinus(List<int> arr)
    {
        double pos=0;
        double neg=0;
        double cero=0;
        int total = arr.Count;
        
        foreach(int x in arr)
        {
            if(x>0)
            {
                pos++;
            }
            else
            {
                if(x<0)
                {
                    neg++;
                }
                else
                {
                    cero++;
                }
            }
            
        }
        
        Console.WriteLine((pos/total*1.0).ToString());
        Console.WriteLine((neg/total*1.0).ToString());
        Console.WriteLine((cero/total*1.0).ToString());
        
        
        

    }

}

class Solution
{
    public static void Main(string[] args)
    {
        int n = Convert.ToInt32(Console.ReadLine().Trim());

        List<int> arr = Console.ReadLine().TrimEnd().Split(' ').ToList().Select(arrTemp => Convert.ToInt32(arrTemp)).ToList();

        Result.plusMinus(arr);
    }
}
