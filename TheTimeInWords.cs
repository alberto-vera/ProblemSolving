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
     * Complete the 'timeInWords' function below.
     *
     * The function is expected to return a STRING.
     * The function accepts following parameters:
     *  1. INTEGER h
     *  2. INTEGER m
     */

    private static string[] minuto30 = { "", "one", "two", "three", "four", "five", "six", "seven","eight", "nine", "ten", "eleven", "twelve", "thirteen", "tourteen", "quarter", "sixteen", "seventeen", "eighteen", "nineteen", "twenty","twenty one", "twenty two","twenty three","twenty four","twenty five","twenty six","twenty seven","twenty eight","twenty nine","half" }; 
    
    public static string timeInWords(int h, int m)
    {
        string cad="";
        
        if(m==0)
        {
            cad = hora(h)+" o' clock";
        }
        else
        {
            string plural="";
            
            if(m>=1 && m<30)                
            {                       
                if(m==15)
                {
                   cad= minuto30[m]+" past "+hora(h);
                }
                else
                {
                    if(m>1)
                    plural="s";
                    
                    cad= minuto30[m]+" minute"+plural+" past "+hora(h);
                }
            }
            else
            {   
                int dif = 60-m;
                
                if(dif==15)
                {
                   cad= minuto30[dif]+" to "+ horaSgte(h);
                }
                else
                {
                    if(dif==30)
                    {
                        cad= minuto30[dif]+" past "+hora(h);
                    }
                    else
                    {
                        if(dif>1)
                            plural="s";
                            
                        cad= minuto30[60-m]+" minute"+plural+" to "+ horaSgte(h);
                    }
                }
            }
            
        }

        return cad;
    }
    
    private static string horaSgte(int h)
    {    
        h++;
        
        if(h==12)
            return hora(1);
        else
            return hora(h);
        
    }
    
    
    private static string hora(int h)  
    {          
    
        switch (h)  
        {  
            case 1:  
                return "one";
            case 2:  
                return "two";  
            case 3:  
                return "three";  
            case 4:  
                return "four";  
            case 5:  
                return "five";  
            case 6:  
                return "six";  
            case 7:  
                return "seven";  
            case 8:  
                return "eight";  
            case 9:  
                return "nine";  
            case 10:  
                return "ten";  
            case 11:  
                return "eleven";  
                break; 
            case 12:  
                return "twelve";  
                
        }  
        
        return "";  
    }

}

class Solution
{
    public static void Main(string[] args)
    {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        int h = Convert.ToInt32(Console.ReadLine().Trim());

        int m = Convert.ToInt32(Console.ReadLine().Trim());

        string result = Result.timeInWords(h, m);

        textWriter.WriteLine(result);

        textWriter.Flush();
        textWriter.Close();
    }
}
