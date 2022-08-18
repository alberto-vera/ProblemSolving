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
     * Complete the 'miniMaxSum' function below.
     *
     * The function accepts INTEGER_ARRAY arr as parameter.
     */

    public static void miniMaxSum(List<int> arr)
    {
        Int64 min=Int64.MaxValue;
        Int64 max=0;
        
        for(int i=0;i<arr.Count;i++)
        {
            Int64 suma=0;
            
            for(int j=0;j<arr.Count;j++)
            {
                if(i!=j)
                {    
                    suma= suma + arr[j];
                }                
            }
            
            if(suma<min)
            {
                min=suma;
            }
            
            if(suma>max)
                {
                    max=suma;
                }
            
        }
        
        Console.WriteLine(min+" "+max);
        

    }

}

class Solution
{
    public static void Main(string[] args)
    {

        List<int> arr = Console.ReadLine().TrimEnd().Split(' ').ToList().Select(arrTemp => Convert.ToInt32(arrTemp)).ToList();

        Result.miniMaxSum(arr);
    }
}
