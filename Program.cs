using System;
using System.Collections.Generic;

class Program
{
    
    static List<string> verlauf = new List<string>();
    
    static double speicher = 0;
    static bool speicherGesetzt = false;

    static void Main()
    {
        Console.WriteLine("Willkommen beim Taschenrechner!");
        bool continueCalculating = true;

        while (continueCalculating)
        {
            
            double num1 = GetNumberFromUser("Geben Sie die erste Zahl ein (oder 'm' für den gespeicherten Wert): ");

            
            string op = GetOperatorFromUser();

            double num2 = 0;
            if (op != "Wurzel")
            {
                num2 = GetNumberFromUser("Geben Sie die zweite Zahl ein (oder 'm' für den gespeicherten Wert): ");
            }

            
            double? result = Calculate(num1, op, num2);
            if (result.HasValue)
            {
                Console.WriteLine($"Ergebnis: {result.Value}");
                verlauf.Add($"{num1} {op} {num2} = {result.Value}"); 

                
                if (AskForSaveToMemory())
                {
                    speicher = result.Value;
                    speicherGesetzt = true;
                    Console.WriteLine($"Ergebnis {result.Value} im Speicher gespeichert.");
                }
            }

            
            continueCalculating = AskForAnotherCalculation();
        }

        
        ShowVerlauf();
        Console.WriteLine("Danke fürs Benutzen des Taschenrechners. Auf Wiedersehen!");
    }

    static double GetNumberFromUser(string prompt)
    {
        double number;
        while (true)
        {
            Console.Write(prompt);
            string input = Console.ReadLine();

            
            if (input.ToLower() == "m" && speicherGesetzt)
            {
                return speicher;
            }

           
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
            Console.Write("Möchten Sie eine weitere Berechnung durchführen oder den Verlauf anzeigen? (ja/nein/verlauf): ");
            string response = Console.ReadLine().ToLower();

            if (response == "ja")
            {
                return true;
            }
            else if (response == "nein")
            {
                return false;
            }
            else if (response == "verlauf")
            {
                ShowVerlauf();
                continue; 
            }
            else
            {
                Console.WriteLine("Ungültige Eingabe. Bitte geben Sie 'ja', 'nein' oder 'verlauf' ein.");
            }
        }
    }

    static void ShowVerlauf()
    {
        Console.WriteLine("Verlauf der Berechnungen:");
        if (verlauf.Count == 0)
        {
            Console.WriteLine("Noch keine Berechnungen durchgeführt.");
        }
        else
        {
            foreach (string entry in verlauf)
            {
                Console.WriteLine(entry);
            }
        }
    }

    static bool AskForSaveToMemory()
    {
        while (true)
        {
            Console.Write("Möchten Sie das Ergebnis im Speicher speichern? (ja/nein): ");
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
