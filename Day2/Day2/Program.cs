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

        for (long i = number1; i <= number2; i++)
        {
            bool isInvalid = false;
            int length = i.ToString().Length;
            for (int j = 1; j <= length; j++)
            {
                string _i = i.ToString();
                if (j != 1 && length % j != 0) continue;

                if (j + 1 > length) break;
                if (j == 1 && length == 2)
                {
                    if (_i[0] != _i[1])
                    {
                        break;
                    }
                    else
                    {
                        password += i;
                        isInvalid = true;
                        Console.WriteLine("Num: " + i);
                    }
                }
                else if (length > 2)
                {
                    bool broke = false;
                    string firstSubStr = _i.Substring(0, j);
                    if (j < 2)
                    {
                        for (int k = 1; k <= length-1; k++)
                        {
                            if (_i[0] != _i[k])
                            {
                                broke = true;
                                break;
                            }
                        }
                    }
                    else
                    {
                        for (int k = j; k <= length-j; k += j)
                        {
                            string subStr = _i.Substring(k, j);
                            if (firstSubStr != subStr)
                            {
                                broke = true;
                                break;
                            }
                        }
                    }
                    if (!broke)
                    {
                        password += i;
                        isInvalid = true;
                        Console.WriteLine("Num: " + i);
                    }
                }
                if (isInvalid) break;
            }
        }
    }
    Console.WriteLine("Password: " + password);
}

GetNumbers("874324-1096487,6106748-6273465,1751-4283,294380-348021,5217788-5252660,828815656-828846474,66486-157652,477-1035,20185-55252,17-47,375278481-375470130,141-453,33680490-33821359,88845663-88931344,621298-752726,21764551-21780350,58537958-58673847,9983248-10042949,4457-9048,9292891448-9292952618,4382577-4494092,199525-259728,9934981035-9935011120,6738255458-6738272752,8275916-8338174,1-15,68-128,7366340343-7366538971,82803431-82838224,72410788-72501583");