//Solution of https://adventofcode.com/2025/day/2
long password = 0;
void GetNumbers(string input)
{
    var ranges = input.Split(',');
    foreach (var range in ranges)
    {
        var _numbers = range.Split('-');
        long number1 = Convert.ToInt64(_numbers[0]);
        long number2 = Convert.ToInt64(_numbers[1]);

        for (long i = number1; i < number2; i++)
        {
            string iString = i.ToString();
            string halfOfTheNumber = iString.Substring(0, iString.Length / 2);
            if (i < 100 && i > 9 && iString[0] == iString[1])
            {
                //Invalid ID
                password += i;
            }
            else if (i >= 1000)
            {
                string otherHalfOfTheNumber = iString.Substring(iString.Length / 2);
                if (halfOfTheNumber == otherHalfOfTheNumber)
                {
                    //Invalid ID
                    password += i;
                }
            }
        }
    }
    Console.WriteLine("Password: " + password);
}

GetNumbers("874324-1096487,6106748-6273465,1751-4283,294380-348021,5217788-5252660,828815656-828846474,66486-157652,477-1035,20185-55252,17-47,375278481-375470130,141-453,33680490-33821359,88845663-88931344,621298-752726,21764551-21780350,58537958-58673847,9983248-10042949,4457-9048,9292891448-9292952618,4382577-4494092,199525-259728,9934981035-9935011120,6738255458-6738272752,8275916-8338174,1-15,68-128,7366340343-7366538971,82803431-82838224,72410788-72501583");