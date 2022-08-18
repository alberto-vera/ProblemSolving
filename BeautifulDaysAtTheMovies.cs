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
     * Complete the 'beautifulDays' function below.
     *
     * The function is expected to return an INTEGER.
     * The function accepts following parameters:
     *  1. INTEGER i
     *  2. INTEGER j
     *  3. INTEGER k
     */

    public static int beautifulDays(int i, int j, int k)
    {
        int conteo=0;
        
        for(int x=i;x<=j;x++)
        {
            conteo+= revisaNumero(x,k);
        }
        
        return conteo;

    }
    
        public static int revisaNumero(int i, int k)
    {    
            
        int inver = inversa(i);
        
        int dif = Math.Abs(i-inver);
        //Console.WriteLine(i+", "+inver+", "+dif);
        
        if(dif % k==0)
            return 1;
        else
            return 0;        
        
    }
    
    public static int inversa(int i)
    {
        string inversa = i.ToString();        
        char[] charArray = i.ToString().ToCharArray();
        Array.Reverse( charArray );
        //inversa = (String)(charArray);
        inversa = new string(charArray);
        
        
        int num = Convert.ToInt32(inversa);
        
        return num;
        
    }

}

class Solution
{
    public static void Main(string[] args)
    {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        string[] firstMultipleInput = Console.ReadLine().TrimEnd().Split(' ');

        int i = Convert.ToInt32(firstMultipleInput[0]);

        int j = Convert.ToInt32(firstMultipleInput[1]);

        int k = Convert.ToInt32(firstMultipleInput[2]);

        int result = Result.beautifulDays(i, j, k);

        textWriter.WriteLine(result);

        textWriter.Flush();
        textWriter.Close();
    }
}
