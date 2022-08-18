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
     * Complete the 'queensAttack' function below.
     *
     * The function is expected to return an INTEGER.
     * The function accepts following parameters:
     *  1. INTEGER n
     *  2. INTEGER k
     *  3. INTEGER r_q
     *  4. INTEGER c_q
     *  5. 2D_INTEGER_ARRAY obstacles
     */

    public static int queensAttack(int n, int k, int r_q, int c_q, List<List<int>> obstacles)
    {
        
        //carga datos
        Hashtable hObstaculo = new Hashtable();
        //agrupa
        foreach(List<int> ls_delta in obstacles)
        {
            string key=(ls_delta[0]-1)+"*"+(ls_delta[1]-1);
            
               C_Delta_Total o_dtotal = (C_Delta_Total) hObstaculo[key];
        
            if (o_dtotal == null)
                    {
                        hObstaculo[key] = new C_Delta_Total(key);
                    }
                    else
                    {
                        o_dtotal.li_total++;
                    }
        }

        
        //
        
        //  1 2 3
        //  4 5 6
        //  7 8 9
        int total=0;
        
        //int i= 0;
        //int j= -1;
        
        for(int i=-1;i<=1;i++)
        {
            for(int j=-1;j<=1;j++)
            {
                if(i!=0 || j!=0)
                {
                    //Console.WriteLine("=======ij: "+i+" "+j);
                    total+=cuentaPasos(n,r_q, c_q, hObstaculo,i,j);
                }
            }
            
        }
        
        return total;

    }
    
    
    
    public static int cuentaPasos(int n, int r_q, int c_q, Hashtable hObstaculo,int i,int j)
    {
        int total=0;
        
        int p = r_q-1;
        int q = c_q-1;
        
        //Console.WriteLine("inicio ij: "+i+" "+j);
        
        while(0<=p && p<n && 0<=q && q<n)
        {
            p+=i;
            q+=j;
            
            //Console.WriteLine("->->->->->->->-> pq: "+p+" "+q);
            
            if(0<=p && p<n && 0<=q && q<n)
            {
                //Console.WriteLine("in pqn: "+p+" "+q+" "+n);
                
                bool encontrado = encuentraObstaculo(p, q, hObstaculo);
                
                if(encontrado)
                {
                    return total;
                }
                
                total++;
            }
            else
            {
                return total;
            }
            
            
            
            
        }
        
        
        
        return total;
        
    }
    
    
    public static bool encuentraObstaculo(int p, int q, Hashtable obstacles)
    {
        
        if(obstacles.Count==0)
        {
            return false;
        }
        
        string key=p+"*"+q;
            
        C_Delta_Total o_dtotal = (C_Delta_Total) obstacles[key];
        
        if (o_dtotal == null)
                    {
                        return false;
                    }
                    else
                    {
                        obstacles.Remove(o_dtotal);
                        return true;
                    }
         

    }

    

}

class Solution
{
    public static void Main(string[] args)
    {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        string[] firstMultipleInput = Console.ReadLine().TrimEnd().Split(' ');

        int n = Convert.ToInt32(firstMultipleInput[0]);

        int k = Convert.ToInt32(firstMultipleInput[1]);

        string[] secondMultipleInput = Console.ReadLine().TrimEnd().Split(' ');

        int r_q = Convert.ToInt32(secondMultipleInput[0]);

        int c_q = Convert.ToInt32(secondMultipleInput[1]);

        List<List<int>> obstacles = new List<List<int>>();

        for (int i = 0; i < k; i++)
        {
            obstacles.Add(Console.ReadLine().TrimEnd().Split(' ').ToList().Select(obstaclesTemp => Convert.ToInt32(obstaclesTemp)).ToList());
        }

        int result = Result.queensAttack(n, k, r_q, c_q, obstacles);

        textWriter.WriteLine(result);

        textWriter.Flush();
        textWriter.Close();
    }
}

    public class C_Delta_Total
    {        
        public string ls_caso;
        public int li_total;
        
        public C_Delta_Total(string ps_caso)
        {
            ls_caso = ps_caso;
            li_total = 1;
        }        

    }
