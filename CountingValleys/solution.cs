using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Program
{
    public static int count(int steps, string path)
    {
        int valleys = 0;
        int stepCnt = 0;
        int upSteps = 0;
        int downSteps = 0;
        bool atSeaLvl = true;
        bool inValley = false;

        while(stepCnt < steps)
        {
            if(path[stepCnt] == 'U')            
                upSteps++;
            else            
                downSteps++;
            
            if (atSeaLvl && path[stepCnt] == 'D')
            {
                inValley = true;
                valleys++;
            }                    
            ++stepCnt;
            atSeaLvl = false;
            if(upSteps == downSteps)
            {
                atSeaLvl = true;
                inValley = false;
                upSteps = 0;
                downSteps = 0;
            }
            
        }

        return valleys;
    }
    static void Main(string[] args)
    {
        int n = 8;
        string path = "DDUUUUDD";
        Console.WriteLine("Case 1: "+ count(n, path));
        n = 12;
        path = "DDUUDDUDUUUD";
        Console.WriteLine("Case 2: " + count(n, path));

    }
}