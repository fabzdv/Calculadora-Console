// See https://aka.ms/new-console-template for more information
using System.Text.RegularExpressions;

class Calculadora
{
    public static double DoOperation(double n1, double n2, string op)
    {
        double result = double.NaN;
        switch(op)
        {
            case "a":
                result = n1 + n2;
                break;
            case "s":
                result = n1 - n2;
                break;
            case "m":
                result = n1 * n2;
                break;
            case "d":
                if(n2 != 0)
                {
                    result = n1 / n2;
                }
                break;
            default:
                break; 
        }
        return result;
    }
}

class Program
{
    static void Main(string[] args)
    {
        bool fecharApp = false;
        Console.WriteLine("Calculadora em C#\r");
        Console.WriteLine("-----------------\n");

        while (!fecharApp)
        {
            string? nInput1 = "";
            string? nInput2 = "";
            double result = 0;

            Console.Write("Insira um número e pressione Enter: ");
            nInput1 = Console.ReadLine();

            double cleanN1 = 0;
            while (!double.TryParse(nInput1, out cleanN1))
            {
                Console.Write("Esse não é um caractere válido. Por favor insira um valor númerico: ");
                nInput1 = Console.ReadLine();
            }

            Console.Write("Insira outro número e pressione Enter: ");
            nInput2 = Console.ReadLine();

            double cleanN2 = 0;
            while (!double.TryParse(nInput2, out cleanN2))
            {
                Console.Write("Esse não é um caractere válido. Por favor insira um valor númerico: ");
                nInput2 = Console.ReadLine();
            }

            Console.WriteLine("Escolha um operador da seguinte lista:");
            Console.WriteLine("\ta - Adição");
            Console.WriteLine("\ts - Subtração");
            Console.WriteLine("\tm - Multiplicação");
            Console.WriteLine("\td - Divisão");
            Console.Write("Sua opção? ");

            string? op = Console.ReadLine();

            if (op == null || ! Regex.IsMatch(op, "[a|s|m|d]"))
            {
                Console.WriteLine("Erro: Entrada desconhecida.");
            }
            else
            {
                try
                {
                    result = Calculadora.DoOperation(cleanN1, cleanN2, op);
                    if (double.IsNaN(result))
                    {
                        Console.WriteLine("Essa operação vai resultar em um erro matemático.\n");
                    }
                    else Console.WriteLine("Seu Resultado: {0:0.##}\n", result);
                }
                catch (Exception e)
                {
                    Console.WriteLine("Oh não! Uma exceção ocorreu enquanto era feito a matemática.\n - Detalhes: " + e.Message);
                }
            }
            Console.WriteLine("------------------------\n");

            Console.Write("Pressione 'n' e Enter para fechar o app, ou pressione qualquer tecla e Enter para continuar: ");
            if (Console.ReadLine() == "n") fecharApp = true;

            Console.WriteLine("\n");
        }
        return;
    }
}