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
     * Complete the 'repeatedString' function below.
     *
     * The function is expected to return a LONG_INTEGER.
     * The function accepts following parameters:
     *  1. STRING s
     *  2. LONG_INTEGER n
     */

    public static long repeatedString(string s, long n)
    {
        long letraBloque = 0;
        char letra = 'a';
        
        //cuenta letra a en bloque
        foreach(char x in s)
        {
            if(x=='a')
            {
                letraBloque++;
            }
        }
        
        if(letraBloque==0)
            return 0;
        
        long bloqueEntero = n/s.Length;
        letraBloque=letraBloque*bloqueEntero;
        
        //distribuye el resto
        long resto=n%s.Length;
        if(resto!=0)
        {
            for(int i=0;i<resto;i++)
            {
                if(s[i]==letra)
                {
                    letraBloque++;
                }
                
            }
            
        }
        
        
        return letraBloque;
    }

}

class Solution
{
    public static void Main(string[] args)
    {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        string s = Console.ReadLine();

        long n = Convert.ToInt64(Console.ReadLine().Trim());

        long result = Result.repeatedString(s, n);

        textWriter.WriteLine(result);

        textWriter.Flush();
        textWriter.Close();
    }
}
