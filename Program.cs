using System;

class Program
{
    static void Main()
    {
        Console.WriteLine("Willkommen beim Taschenrechner!");
        bool continueCalculating = true;

        while (continueCalculating)
        {
            
            double num1 = GetNumberFromUser("Geben Sie die erste Zahl ein: ");

            
            string op = GetOperatorFromUser();

            double num2 = 0;
            if (op != "Wurzel") 
            {
              
                num2 = GetNumberFromUser("Geben Sie die zweite Zahl ein: ");
            }

           
            double? result = Calculate(num1, op, num2);
            if (result.HasValue)
            {
                Console.WriteLine($"Ergebnis: {result.Value}");
            }

            continueCalculating = AskForAnotherCalculation();
        }

        Console.WriteLine("Danke fürs Benutzen des Taschenrechners. Auf Wiedersehen!");
    }

    static double GetNumberFromUser(string prompt)
    {
        double number;
        while (true)
        {
            Console.Write(prompt);
            string input = Console.ReadLine();

            
            if (double.TryParse(input, out number))
            {
                return number;
            }
            else
            {
                Console.WriteLine("Ungültige Eingabe. Bitte geben Sie eine gültige Zahl ein.");
            }
        }
    }

    static string GetOperatorFromUser()
    {
        while (true)
        {
            Console.Write("Geben Sie den Operator ein (+, -, *, /, ^ für Potenz, Wurzel): ");
            string op = Console.ReadLine();

            
            if (op == "+" || op == "-" || op == "*" || op == "/" || op == "^" || op == "Wurzel")
            {
                return op;
            }
            else
            {
                Console.WriteLine("Ungültiger Operator. Bitte geben Sie +, -, *, /, ^ oder Wurzel ein.");
            }
        }
    }

    static double? Calculate(double num1, string op, double num2 = 0)
    {
        switch (op)
        {
            case "+":
                return num1 + num2;
            case "-":
                return num1 - num2;
            case "*":
                return num1 * num2;
            case "/":
                if (num2 != 0)
                    return num1 / num2;
                else
                {
                    Console.WriteLine("Fehler: Division durch Null.");
                    return null;
                }
            case "^":
                return Math.Pow(num1, num2);
            case "Wurzel":
                if (num1 >= 0)
                    return Math.Sqrt(num1);
                else
                {
                    Console.WriteLine("Fehler: Wurzel aus einer negativen Zahl ist nicht definiert.");
                    return null;
                }
            default:
                Console.WriteLine("Ungültiger Operator.");
                return null;
        }
    }

    static bool AskForAnotherCalculation()
    {
        while (true)
        {
            Console.Write("Möchten Sie eine weitere Berechnung durchführen? (ja/nein): ");
            string response = Console.ReadLine().ToLower();

            if (response == "ja")
            {
                return true;
            }
            else if (response == "nein")
            {
                return false;
            }
            else
            {
                Console.WriteLine("Ungültige Eingabe. Bitte geben Sie 'ja' oder 'nein' ein.");
            }
        }
    }
}




