using System;

class Program
{
    static async Task Main(string[] args)
    {

        Console.WriteLine("Quale script vuoi eseguire?");
        Console.WriteLine("1. Scarica l'input del giorno");
        Console.WriteLine("2. Tutti di un deterinato anno");
        Console.WriteLine("3. L'input di oggi");
        int input = GetValidIntInput();
        int year;
        int day;
        switch (input){
            case 1:
                Console.WriteLine("A che anno vuoi connetterti?");
                year = GetValidIntInput();
                Console.WriteLine("Che giorno?");
                day = GetValidIntInput();
                await new DayExtractor(year,day).extract();
                break;
            case 2:
                Console.WriteLine("A che anno vuoi connetterti?");
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
                Console.WriteLine("Input non valido. Per favore inserisci un numero.");
            }
        }
    }
}