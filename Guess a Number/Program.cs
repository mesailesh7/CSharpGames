namespace Guess_a_Number;

class Program
{
    static void Main(string[] args)
    {
        int value = Random.Shared.Next(1, 101);
        while (true)
        {
            Console.WriteLine("Guess a number (1-100)");
            bool valid = int.TryParse((Console.ReadLine() ?? "").Trim(), out int input);
            if(!valid) Console.WriteLine("Invalid input");
            else if (input == value) break;
            else Console.Write($"Incorrect. too {(input < value ? "Low" : "High")}.");
        }
        Console.WriteLine("You guessed it");
        Console.Write("Press any key to exit . . . ");
        Console.ReadKey(true);
    }
}