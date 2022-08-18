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
     * Complete the 'encryption' function below.
     *
     * The function is expected to return a STRING.
     * The function accepts STRING s as parameter.
     */

    public static string encryption(string s)
    {
        string cad="";
        
        double long1 = Math.Sqrt(s.Length);
        
        double ceil = Math.Ceiling(long1);
        double floor = Math.Floor(long1);
        
        Console.WriteLine(ceil);
        Console.WriteLine(floor);
        
         // floor <= fila <= col <= ceil
        
        int fil = (int) floor;
        int col = (int) ceil;
        
        if(fil*col<s.Length)
        {
            fil++;            
        }
        
        
        for(int idx=0;idx<col;idx++)
        {
            int idx2 = idx;
            
            while(idx2<s.Length)
            {
                cad+= s.Substring(idx2,1);
                idx2+=col;
            }
            
            cad+=" ";    
                
        }   

        
        return cad;
    }

}

class Solution
{
    public static void Main(string[] args)
    {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        string s = Console.ReadLine();

        string result = Result.encryption(s);

        textWriter.WriteLine(result);

        textWriter.Flush();
        textWriter.Close();
    }
}
