//Solution of https://adventofcode.com/2025/day/1
using System.Diagnostics;

public class Program
{
    public static void Main()
    {
        Stopwatch stopwatch = new Stopwatch();
        stopwatch.Start();

        int CaseNum = 50;
        int Password = 0;
        void TakeString(string input)
        {
            string[] lines = input.Split(new[] { "\r\n", "\r", "\n" }, StringSplitOptions.None);
            foreach (var line in lines)
            {
                bool isLeft = (line.Substring(0, 1)) == "L";
                int number = Convert.ToInt32((line.Substring(1, line.Length - 1)));
                Dial(number, isLeft);
            }
        }
        TakeString("L68\r\nL30\r\nR48\r\nL5\r\nR60\r\nL55\r\nL1\r\nL99\r\nR14\r\nL82");

        void Dial(int Number, bool isLeft)
        {
            if (Number > 100) Number = Number % 100;
            if (isLeft) CaseNum -= Number;
            else CaseNum += Number;
            if (CaseNum < 0){
                int _CaseNum = Math.Abs(CaseNum);
                if (_CaseNum > 100) _CaseNum %= 100;
                CaseNum = 100 - _CaseNum;
            }
            else if (CaseNum > 100) CaseNum %= 100;

            if (CaseNum == 100 || CaseNum == 0) Password++;
        }
        stopwatch.Stop();
        Console.WriteLine("Password: " + Password + "  -  Time Elapsed: " + stopwatch.Elapsed.TotalMilliseconds.ToString());
    }
}