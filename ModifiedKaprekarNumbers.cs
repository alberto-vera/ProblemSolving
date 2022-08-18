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
     * Complete the 'kaprekarNumbers' function below.
     *
     * The function accepts following parameters:
     *  1. INTEGER p
     *  2. INTEGER q
     */

    public static void kaprekarNumbers(int p, int q)
    {
        string cad="";
        string mensajeVacio = "INVALID RANGE";
        
        for(int i=p;i<=q;i++)
        {
            
            if(esKaprekar(i))
            {
                cad+=i+" ";
            }
                        
        }
        
        if(cad!="")
        {
            Console.WriteLine(cad);
        }
        else
        {
            Console.WriteLine(mensajeVacio);
        }
    }
    
    public static bool esKaprekar(int num) {
        
        int longit = num.ToString().Length;
        string raiz = Math.Pow(num,2).ToString();
        
        if(raiz.Length == 1) 
        {
            return num == 1;
        }
        
        int idx = raiz.Length - longit;
        int primera = Int32. Parse(raiz.Substring(0, idx));        
        int segunda = Int32. Parse(raiz.Substring(idx));
        
        bool cond = (primera + segunda == num);
        
        return cond;
    }

}

class Solution
{
    public static void Main(string[] args)
    {
        int p = Convert.ToInt32(Console.ReadLine().Trim());

        int q = Convert.ToInt32(Console.ReadLine().Trim());

        Result.kaprekarNumbers(p, q);
    }
}
