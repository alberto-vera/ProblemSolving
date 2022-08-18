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
     * Complete the 'migratoryBirds' function below.
     *
     * The function is expected to return an INTEGER.
     * The function accepts INTEGER_ARRAY arr as parameter.
     */

    public static int migratoryBirds(List<int> arr)
    {

        int valor=0;
        
        Hashtable hTotal = new Hashtable();
        List<int> lista =  new List<int>();
        
        //agrupa
        foreach(int ls_delta in arr)
        {
        C_Delta_Total o_dtotal = (C_Delta_Total) hTotal[ls_delta];
        
        if (o_dtotal == null)
                    {
                        hTotal[ls_delta] = new C_Delta_Total(ls_delta);
                    }
                    else
                    {
                        o_dtotal.li_total++;
                    }
        }
        
        //conocer el maximo
        //filtro
        int maximo=0;
        
        foreach(DictionaryEntry elem in hTotal)
        {           
            
            C_Delta_Total o_dtotal = (C_Delta_Total) hTotal[elem.Key];
            
            if(o_dtotal.li_total > maximo)
            {
                lista =  new List<int>();
                maximo = o_dtotal.li_total;
                
            }
            
            if(o_dtotal.li_total==maximo)
            {
                lista.Add(o_dtotal.ls_caso);
            }
            
        }
        
        //resultado
        if(lista.Count==1)
        {
            valor=lista[0];
        }
        else
        {
            valor=lista.AsQueryable().Min();
        }

        
        return valor;
    }

}

class Solution
{
    public static void Main(string[] args)
    {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        int arrCount = Convert.ToInt32(Console.ReadLine().Trim());

        List<int> arr = Console.ReadLine().TrimEnd().Split(' ').ToList().Select(arrTemp => Convert.ToInt32(arrTemp)).ToList();

        int result = Result.migratoryBirds(arr);

        textWriter.WriteLine(result);

        textWriter.Flush();
        textWriter.Close();
    }
}

    public class C_Delta_Total
    {        
        public int ls_caso;
        public int li_total;

        public C_Delta_Total(int ps_caso)
        {
            ls_caso = ps_caso;
            li_total = 1;
        }        

    }
