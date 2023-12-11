using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text.RegularExpressions;

namespace AlgoritmoCSharp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(DifferentCases("a b c d-e-f%g") == "ABCDEFG");
            Console.WriteLine(DifferentCases("Daniel LikeS-coding") == "DanielLikesCoding");

            Console.ReadLine();
        }

        public static string DifferentCases(string str)
        {
            str = str.ToLower();
            var newString = string.Empty;

            var regex = @"[ \-%]";
            var strSplit = Regex.Split(str, regex);

            foreach (var item in strSplit)
            {
                newString += item.Substring(0,1).ToUpper() + item.Substring(1);
            }

            str = newString;

            return str;
        }

        public static void ConverterJson()
        {
            WebClient client = new WebClient();
            string s = client.DownloadString("https://coderbyte.com/api/challenges/json/age-counting");

            string jsonString = s.Replace("\r\n", "").Replace("\n", "").Replace("\r", "").Replace(" ", "");
            var jsonContent = jsonString.Replace(@"{""data"":""", "").Replace("}", "");
            var contentArr = jsonContent.Split(',');

            var countAge = 0;

            foreach (var item in contentArr)
            {
                int age = int.TryParse(item.Split('=').Last(), out var parseAge) ? parseAge : 0;

                if (age >= 50)
                    countAge++;
            }
            Console.WriteLine($"There are {countAge} people greater 50 years old!");
            Console.ReadLine();

        }

        #region Diferenca

        /// <summary>
        /// Implemente o método que calcule a diferença que o usuário deverá pagar ao fazer 
        //upgrade do plano de assinatura.Com o valor retornado pelo méotodo será feita a
        //cobrança extra da diferença entre os planos no ato do upgrade referente aos dias
        //restantes, sem alterar a data de pagamento do cliente.
        //Por exemplo: Usuário assinou o plano R$ 30,00 no dia 01/01, no dia 09/01 ele fez
        //upgrade para o plano de R$ 60,00, então ele precisa pagar a diferença relativa dos
        //dias restante.
        /// </summary>
        /// 
        public static double ValorDiferenca(double valorPlanoInicial, double valorPlanoUpdate, DateTime dataInicial, DateTime dataUpgrade)
        {
            double valorDiarioInicial = valorPlanoInicial / 30;
            double valorDiarioUpgrade = valorPlanoUpdate / 30;


            if (dataUpgrade < dataInicial)
                return 0;


            int diferencaDias = 30 - (dataUpgrade.Subtract(dataInicial)).Days;

            double valorMensalPlanoUpgrade = valorDiarioUpgrade * (31 - dataUpgrade.Day);
            double valorMensalPlanoInicial = valorDiarioInicial * (31 - diferencaDias);

            return valorMensalPlanoUpgrade + valorMensalPlanoInicial;




        }
        #endregion

        #region Algoritmo simples

        /*
         * Fazer um programa para ler o código de uma peça 1, o número de peças 1,
         * o valor unitário de cada peça 1, o código de uma peça 2, o número de peças 2
         * e o valor unitário de cada peça 2. Calcule e mostre o valor a ser pago.
         */
        static void Ex1()
        {
            Console.WriteLine("Digite o código da primeira peça:");
            int codigoP1 = int.TryParse(Console.ReadLine(), out codigoP1) ? codigoP1 : 0;


            Console.WriteLine("Digite o numero da primeira peça:");
            int qtdeP1 = int.TryParse(Console.ReadLine(), out qtdeP1) ? qtdeP1 : 0;

            Console.WriteLine("Digite o valor unitario da primeira peça:");
            double valorP1 = double.TryParse(Console.ReadLine(), out valorP1) ? valorP1 : 0;

            double valorPagarP1 = 0;

            valorPagarP1 = qtdeP1 * valorP1;

            Console.WriteLine("Digite o código da segunda peça:");
            int codigoP2 = int.TryParse(Console.ReadLine(), out codigoP2) ? codigoP2 : 0;


            Console.WriteLine("Digite o numero da segunda peça:");
            int qtdeP2 = int.TryParse(Console.ReadLine(), out qtdeP2) ? qtdeP2 : 0;

            Console.WriteLine("Digite o valor unitario da segunda peça:");
            double valorP2 = double.TryParse(Console.ReadLine(), out valorP2) ? valorP2 : 0;

            double valorPagarP2 = 0;

            valorPagarP2 = qtdeP2 * valorP2;

            double valorTotal = valorPagarP1 + valorPagarP2;

            Console.WriteLine("Valor a pagar: " + valorTotal);

        }

        /*
         * Faça um programa para ler o valor do raio de um círculo, e depois mostrar o valor 
         * da área deste círculo com quatro casas decimais conforme exemplos.
         */
        static void Ex2()
        {
            Console.WriteLine("Digite o valor da raio:");
            double raio = double.TryParse(Console.ReadLine(), out raio) ? raio : 0;

            double pi = Math.PI;

            double areaCirculo = pi * Math.Pow(raio, 2);

            Console.WriteLine("A área do ciruclo é : " + areaCirculo);
        }

        #endregion

        #region Condições

        /*
         um programa que leia o código de um item e a quantidade deste item.A seguir, calcule e
         mostre o valor da conta a pagar.
        */
        static void Ex21()
        {
            Console.WriteLine("Digite o código do produto: ");
            int codigoP1 = int.TryParse(Console.ReadLine(), out codigoP1) ? codigoP1 : 0;

            Console.WriteLine("Digite a quantidade do produto: ");
            int qtdeP1 = int.TryParse(Console.ReadLine(), out qtdeP1) ? qtdeP1 : 0;

            double valorTotal = 0;

            Produto prd = new Produto();

            List<Produto> lstPRoduto = prd.retornarLista();

            foreach (var item in lstPRoduto)
            {
                if (item.Codigo == codigoP1)
                {
                    valorTotal = item.Preco * qtdeP1;

                    Console.WriteLine("Total: " + valorTotal);
                    return;
                }
            }
            Console.WriteLine("Código do produto invalido!");
        }

        static void Ex22()
        {
            Console.WriteLine("Digite o valor de a: ");
            double a = double.TryParse(Console.ReadLine(), out a) ? a : 0;

            Console.WriteLine("Digite o valor de b: ");
            double b = double.TryParse(Console.ReadLine(), out b) ? b : 0;

            Console.WriteLine("Digite o valor de c: ");
            double c = double.TryParse(Console.ReadLine(), out c) ? c : 0;

            double delta = Math.Pow(b, 2) - 4 * a * c;


            if (a == 0 || delta < 0)
            {
                Console.WriteLine("Impossível calcular");
            }
            else
            {
                double x1 = (-b + Math.Sqrt(delta)) / (2 * a);

                double x2 = (-b - Math.Sqrt(delta)) / (2 * a);

                Console.WriteLine("x1: " + x1);
                Console.WriteLine("x2: " + x2);
            }

        }
        #endregion

        #region Loop


        /*
         * Escreva um programa que repita a leitura de uma senha até que ela seja válida. 
         * Para cada leitura de senha incorreta informada, escrever a mensagem "Senha Invalida".
         * Quando a senha for informada corretamente deve ser impressa a mensagem "Acesso Permitido" 
         * e o algoritmo encerrado. Considere que a senha correta é o valor 2002.
         */
        static void Ex31()
        {
            string senha = ObterSenha();
            while (senha != "2002")
            {
                senha = ObterSenha();

                if (senha == "2002")
                {
                    Console.WriteLine("Acesso Permitido!");
                    break;
                }
            }


        }

        static string ObterSenha()
        {
            Console.WriteLine("Favor inserir a senha !");
            return Console.ReadLine();
        }

        /*
         * Leia um valor inteiro N. Este valor será a quantidade de valores inteiros X que serão lidos em seguida.
           Mostre quantos destes valores X estão dentro do intervalo [10,20] e quantos estão fora do intervalo,
            mostrando essas informações conforme exemplo (use a palavra "in" para dentro do intervalo, 
            e "out" para fora do intervalo).
         */
        static void Ex32()
        {
            Console.WriteLine("Digite o valor de N (quantide de repetições): ");
            int n = int.TryParse(Console.ReadLine(), out n) ? n : 0;

            int valor = 0;

            int[] matriz = new int[n];
            int varIN = 0;
            int varOUT = 0;

            for (int i = 0; i < n; i++)
            {
                Console.WriteLine("Digite um número: ");
                valor = int.TryParse(Console.ReadLine(), out valor) ? valor : 0;

                matriz[i] = valor;
            }

            Console.WriteLine("\n");

            for (int i = 0; i < matriz.Length; i++)
            {
                Console.WriteLine(matriz[i]);

                if (matriz[i] >= 10 && matriz[i] <= 20)
                {
                    varIN++;
                }
                else
                {
                    varOUT++;
                }
            }
            Console.WriteLine(varIN + " in ");
            Console.WriteLine(varOUT + " out ");

        }

        #endregion
    }
}

public class Produto
{
    public int Codigo { get; set; }
    public string Especificacao { get; set; }
    public double Preco { get; set; }

    public Produto()
    {

    }
    public Produto(int _codigo, string _especificacao, double _preco)
    {
        Codigo = _codigo;
        Especificacao = _especificacao;
        Preco = _preco;
    }

    public List<Produto> retornarLista()
    {
        List<Produto> lstProdutos = new List<Produto>();

        Produto prd = new Produto(1, "Cachorro Quente", 4.00);
        lstProdutos.Add(prd);

        prd = new Produto(2, "X salada", 4.50);
        lstProdutos.Add(prd);

        prd = new Produto(3, "X bacon", 5.00);
        lstProdutos.Add(prd);

        prd = new Produto(4, "Torrada Simples", 2.00);
        lstProdutos.Add(prd);

        prd = new Produto(5, "Refrigerante", 1.50);
        lstProdutos.Add(prd);


        return lstProdutos;

    }
}