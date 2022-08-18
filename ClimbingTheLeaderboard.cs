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
     * Complete the 'climbingLeaderboard' function below.
     *
     * The function is expected to return an INTEGER_ARRAY.
     * The function accepts following parameters:
     *  1. INTEGER_ARRAY ranked
     *  2. INTEGER_ARRAY player
     */

    public static List<int> climbingLeaderboard(List<int> ranked, List<int> player)
    {
        List<int> rpta = new List<int>();        
        ranked = resumenRanking(ranked);        
        
        foreach(int x in player)
        {
             rpta.Add(getId(ranked, x));
        }        
        
        return rpta;
    }
    
    public static List<int> resumenRanking(List<int> ranked)
    {        
        return ranked.Select(x => x).Distinct().ToList();            
    }
    
    public static int getId(List<int> ranked,int puntaje)
    {
        
        if(puntaje > ranked[0])
        {
            return 1;
        }
        
        if(puntaje < ranked[ranked.Count-1])
        {
            return ranked.Count+1;
        }
        
        
        
        
        int index = ranked.BinarySearch(puntaje);
        if(index>-1)
        {
            return index+1;
        }
            
        int idR = ranked.FindIndex(a => a  <= puntaje);
        
            

        return idR+1;
        
    
        
    }
    
}

class Solution
{
    public static void Main(string[] args)
    {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        int rankedCount = Convert.ToInt32(Console.ReadLine().Trim());

        List<int> ranked = Console.ReadLine().TrimEnd().Split(' ').ToList().Select(rankedTemp => Convert.ToInt32(rankedTemp)).ToList();

        int playerCount = Convert.ToInt32(Console.ReadLine().Trim());

        List<int> player = Console.ReadLine().TrimEnd().Split(' ').ToList().Select(playerTemp => Convert.ToInt32(playerTemp)).ToList();

        List<int> result = Result.climbingLeaderboard(ranked, player);

        textWriter.WriteLine(String.Join("\n", result));

        textWriter.Flush();
        textWriter.Close();
    }
}
