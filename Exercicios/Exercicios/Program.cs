using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.Linq;

namespace Exercicios
{
    class Program
    {
        static int[] Saque(int[][] cedulasCaixa, int input)
        {
        inicio:

            Dictionary<int, int> cedulas = new Dictionary<int, int>();

            for(int i = 0; i<= 5; i++)
            {
                cedulas.Add(cedulasCaixa[i][0], cedulasCaixa[i][1]);
            }           

            Console.WriteLine("Teste Notas");

            Console.WriteLine();
            Console.WriteLine();

            Console.Write("Digite o valor do saque: ");

            var valorEntrada = input;

            int valor = 0;

            int.TryParse(valorEntrada.ToString(), out valor);




            var validacaoNumerosInvalidos = valorEntrada.ToString()[(valorEntrada.ToString().Length - 1)].ToString();

            if (validacaoNumerosInvalidos.Contains("3") ||
                validacaoNumerosInvalidos.Contains("1") ||
                valor == 0)
            {

                Console.WriteLine("Valor invalido para as notas disponiveis");
                goto inicio;
            }




            int n100 = valor / 100;

            if (cedulas.GetValueOrDefault(100) < n100)
            {
                Console.WriteLine("notas de 100 insuficientes");
                goto inicio;

            }

            int resto = valor - (n100 * 100);

            int n50 = resto / 50;

            if (cedulas.GetValueOrDefault(50) < n50)
            {
                Console.WriteLine("notas de 50 insuficientes");
                goto inicio;
            }
            resto = resto - (n50 * 50);

            int n20 = resto / 20;
            if (cedulas.GetValueOrDefault(20) < n20)
            {
                Console.WriteLine("notas de 20 insuficientes");
                goto inicio;
            }

            resto = resto - (n20 * 20);

            int n10 = resto / 10;
            if (cedulas.GetValueOrDefault(10) < n10)
            {
                Console.WriteLine("notas de 10 insuficientes");
                goto inicio;
            }

            resto = resto - (n10 * 10);

            int n5 = resto / 5;
            if (cedulas.GetValueOrDefault(5) < n5)
            {
                Console.WriteLine("notas de 5 insuficientes");
                goto inicio;
            }

            resto = resto - (n5 * 5);

            int n2 = resto / 2;

            if (cedulas.GetValueOrDefault(2) < n2)
            {
                Console.WriteLine("notas de 2 insuficientes");
                goto inicio;
            }

            resto = resto - (n2 * 2);

            Console.WriteLine();

            Console.WriteLine("Quantidade de notas:");

            Console.WriteLine();

            Console.WriteLine("Notas de 100R$:  " + n100);

            Console.WriteLine();

            Console.WriteLine("Notas de 50R$:  " + n50);

            Console.WriteLine();

            Console.WriteLine("Notas de 20R$:  " + n20);

            Console.WriteLine();

            Console.WriteLine("Notas de 10R$:  " + n10);

            Console.WriteLine();

            Console.WriteLine("Notas de 5R$:  " + n5);

            Console.WriteLine();

            Console.WriteLine("Notas de 2R$:  " + n2);

            Console.ReadKey();
            goto inicio;
            return null;
        }

        static void Exercicio1()
        {
            int[][] cedulas = new int[][]
            {
                new int[] { 2, 10 },
                new int[] { 5, 1 },
                new int[] { 10, 2 },
                new int[] { 20, 3 },
                new int[] { 50, 3 },
                new int[] { 100, 2 }
            };
            var input = Convert.ToInt32(Console.ReadLine());
            Saque(cedulas, input);
          
        }
        static int Fib(int n)
        {
            if(n == 1)
            {
                return n;
            }
            if(n== 0)
            {
                return 0;
            }

            int fib = Fib(n - 1) + Fib(n - 2);
            return fib;
        }

        static int FibEllen(int n)
        {

            int a = 0;
            int b = 1;
            int c = 1;
            for (int i = 0; i < n; i++)
            {
                a = b;
                b = c;
                c = a + b;
            }
            return a;
        }
        static void Exercicio2()
        {
            inicio:
            Console.WriteLine("Execução do algoritmo original");
            Console.WriteLine("");
            Console.WriteLine("Digite o tamanho da sequencia");
            string input = Console.ReadLine();
           // Console.ReadKey();
            int valor = Convert.ToInt32(input);
            var stop = new Stopwatch();
            stop.Start();
            var result = Fib(valor);
            stop.Stop();
            var time = stop.Elapsed;
            Console.WriteLine($"Tempo da execução do algoritmo original: {result} {time}s");
            Console.WriteLine("Execução do algoritmo da Ellen");
            Console.WriteLine("");
         
            var stopEllen = new Stopwatch();
            stopEllen.Start();
            var resultEllen = 0;
             resultEllen = FibEllen(valor);
            stopEllen.Stop();
             var timeEllen = stopEllen.Elapsed;
            Console.WriteLine($"Tempo da execução do algoritmo da Ellen: {resultEllen} {timeEllen}s");
            Console.ReadKey();
            goto inicio;
        }
        static void Main(string[] args)
        {

            // Exercicio1();
            Exercicio2();
        }
    }
}
