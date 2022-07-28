using System;
using System.Linq;
public class Solution {
    public static int[] RunningSum(int[] nums) {
        List<int> output = new ();
        
        for(int i = 0; i < nums.Length; i++)
        {
            if(output.Count == 0)
            {
                output.Add(nums[i]);
            }else
            {
                output.Add(output.Last() + nums[i]);
            }
        }
        return output.ToArray();
    }


    static void Main(String[] args)
    {
        int[] nums = new int[] {1,2,3,4};
        int[] output = RunningSum(nums);        
        Console.WriteLine(output[output.Count() - 1]);
    }

}