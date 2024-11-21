using System;

class Program
{
    static async Task Main(string[] args)
    {

        Console.WriteLine("Which script do you want to run?");
        Console.WriteLine("1. Download today's input");
        Console.WriteLine("2. All input of a specific year");
        Console.WriteLine("3. Today's input");
        int input = GetValidIntInput();
        int year;
        int day;
        switch (input){
            case 1:
                Console.WriteLine("Which year?");
                year = GetValidIntInput();
                Console.WriteLine("Which day?");
                day = GetValidIntInput();
                await new DayExtractor(year,day).extract();
                break;
            case 2:
                Console.WriteLine("Which year?");
                year = GetValidIntInput();
                for (int i=1; i<25; i++){
                    await new DayExtractor(year,i).extract();
                }
                break;
            case 3:
                DateTime currentDate = DateTime.Now;
                await new DayExtractor(currentDate.Year, currentDate.Day).extract();
                break;
        }
    }

    private static int GetValidIntInput()
    {
        int result;
        while (true)
        {
            string? input = Console.ReadLine();
             if (!string.IsNullOrEmpty(input) && int.TryParse(input, out result))
            {
                return result;
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a number.");
            }
        }
    }
}