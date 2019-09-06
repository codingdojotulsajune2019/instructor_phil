using System;
using System.Collections.Generic;

namespace Puzzles
{
    class Program
    {
        static void Main(string[] args)
        {
            // RandomArray();
            string Result = TossCoin();
            System.Console.WriteLine($"TossCoin result is: {Result}");
            Console.WriteLine($"The ratio of heads to tails is: {TossMultipleCoins(10)}");
            System.Console.WriteLine($"The result of Name is: {Names()}");
        }
            // ----------------------------------------------------------------------------------------
            // Random Array
            // Create a function called RandomArray() that returns an integer array
            public static int[] RandomArray()
            {
                int[] IntArray = new int[10];
                // Place 10 random integer values between 5-25 into the array

                Random random = new Random();  

                for(int i = 0; i < IntArray.Length; i++)
                {
                    IntArray[i] = random.Next(5, 25);
                }
                // Print the min and max values of the array
                // Print the sum of all the values
                int Max = IntArray[0];
                int Min = IntArray[0];
                int Sum = IntArray[0];
                for(int i = 1; i < IntArray.Length; i++)
                {
                    if(IntArray[i] > Max)
                    {
                        Max = IntArray[i];
                    }
                    if(IntArray[i] < Min)
                    {
                        Min = IntArray[i];
                    }
                    Sum += IntArray[i];
                }
                System.Console.WriteLine($"Max is: {Max}");
                System.Console.WriteLine($"Min is: {Min}");
                System.Console.WriteLine($"Sum is: {Sum}");
                return IntArray;
            }

            // ----------------------------------------------------------------------------------------
            // Coin Flip
            // Create a function called TossCoin() that returns a string
            public static string TossCoin()
            {
                // Have the function print "Tossing a Coin!"
                System.Console.WriteLine("Tossing a Coin!");
                string[] SidesOfACoin = new string[]{"Heads", "Tails"};
                Random random = new Random();
                int idx = random.Next(0,2);
                System.Console.WriteLine($"Server says: {SidesOfACoin[idx]}!");
                return SidesOfACoin[idx];
            }
            // Randomize a coin toss with a result signaling either side of the coin 
            // Have the function print either "Heads" or "Tails"
            // Finally, return the result


            // ----------------------------------------------------------------------------------------
            // Create another function called TossMultipleCoins(int num) that returns a Double
            public static double TossMultipleCoins(int num)
            {
                Dictionary<string,int> Result = new Dictionary<string, int>();
                Result.Add("Heads", 0);
                Result.Add("Tails", 0);

                for(int i = 0; i < num; i++)
                {
                    string CoinTossResult = TossCoin();
                    Result[CoinTossResult]++;
                }
                
                return Result["Heads"]/Result["Tails"];
            }
            // Have the function call the tossCoin function multiple times based on num value
            // Have the function return a Double that reflects the ratio of head toss to total toss
            // Names
            // Build a function Names that returns a list of strings.  In this function:
            public static List<string> Names()
            {
                List<string> NameList = new List<string>(){"Todd", "Tiffany", "Charlie", "Geneva", "Sydney"};
                Random random = new Random();
                for(int i = 0; i < NameList.Count; i++)
                {
                    int Swap1 = random.Next(0, NameList.Count);
                    int Swap2 = random.Next(0, NameList.Count);
                    string StringSwap = NameList[Swap1];
                    NameList[Swap1] = NameList[Swap2];
                    NameList[Swap2] = StringSwap;
                }
                for(int i = 0; i < NameList.Count; i++)
                {
                    if(NameList[i].Length < 5)
                    {
                        NameList.RemoveAt(i);
                    }
                }
                return NameList;
            }
            // Create a list with the values: Todd, Tiffany, Charlie, Geneva, Sydney
            // Shuffle the list and print the values in the new order
            // Return a list that only includes names longer than 5 characters
    }
}
