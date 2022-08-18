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
     * Complete the 'breakingRecords' function below.
     *
     * The function is expected to return an INTEGER_ARRAY.
     * The function accepts INTEGER_ARRAY scores as parameter.
     */

    public static List<int> breakingRecords(List<int> scores)
    {
        
                List<int> lista= new List<int>();
        int min=Int32.MaxValue;
        int max=0;
        
        int ctaMin=0;
        int ctaMax=0;
        
        int rec=0;
        
        foreach(int x in scores)
        {
            
            if(rec==0)
            {
                min=x;
                max=x;
                rec++;
            }
            else
            {
                if(x<min)
                {
                    min=x;
                    ctaMin++;
                    Console.WriteLine("nuevo min: "+min);
                }
                
                if(x>max)
                {
                    max=x;
                    ctaMax++;
                    Console.WriteLine("nuevo max: "+max);
                }
                
            }
            
            
        }
        
        lista.Add(ctaMax);
        lista.Add(ctaMin);
        
        

        
        return lista;

    }

}

class Solution
{
    public static void Main(string[] args)
    {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        int n = Convert.ToInt32(Console.ReadLine().Trim());

        List<int> scores = Console.ReadLine().TrimEnd().Split(' ').ToList().Select(scoresTemp => Convert.ToInt32(scoresTemp)).ToList();

        List<int> result = Result.breakingRecords(scores);

        textWriter.WriteLine(String.Join(" ", result));

        textWriter.Flush();
        textWriter.Close();
    }
}
