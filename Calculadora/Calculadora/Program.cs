using System;

namespace Calculadora
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] operacoesRealizadas = new string[100];
            int contadorParaOperacoesRealizadas = 0;

            while (true)
            {
                Console.Clear();

                Console.WriteLine("Calculadora!\n");

                MostrarMenu();

                Console.WriteLine();
                Console.Write("Digite o que deseja fazer: ");

                string opcao = Console.ReadLine();

                if (!EhOpcaoValida(opcao))
                {
                    Console.Clear();
                    MostrarMensagemErro("Opcao Invalida");
                    PausarConsole();
                    continue;
                }

                if (EhOpcaoSair(opcao))
                {
                    break;
                }

                if (EhOpcaoMostrarOperacoes(opcao))
                {
                    if (TemOperacaoRealizada(contadorParaOperacoesRealizadas))
                    {
                        Console.Clear();
                        MostrarMensagemErro("Não tem nenhuma operacao realizada, realize alguma");
                        PausarConsole();
                        continue;
                    }

                    Console.Clear();
                    ImprimirOperacoesRealizadas(operacoesRealizadas, contadorParaOperacoesRealizadas);

                    PausarConsole();
                    continue;
                }

                Console.Clear();
                double n1 = LerDouble("primeiro");

                double n2;

                do
                {
                    Console.Clear();
                    n2 = LerDouble("segundo");

                    if (EhDivisaoValida(opcao, n2))
                    {
                        Console.Clear();
                        MostrarMensagemErro("Voce nao pode dividir um numero por 0");
                        PausarConsole();
                    }

                } while (EhDivisaoValida(opcao, n2));

                string operacao = PegarOperacao(opcao);
                double resultado = RealizarOperacao(operacao, n1, n2);
                string resultadoParaMostrar = $"{n1} {operacao} {n2} = {resultado}";

                if (TemEspaçoParaInserir(contadorParaOperacoesRealizadas))
                {
                    operacoesRealizadas[contadorParaOperacoesRealizadas] = resultadoParaMostrar;
                    contadorParaOperacoesRealizadas++;
                }

                Console.Clear();
                Console.WriteLine(resultadoParaMostrar);
                PausarConsole();
            }
        }

        private static void ImprimirOperacoesRealizadas(string[] operacoesRealizadas, int contadorParaOperacoesRealizadas)
        {
            for (int i = 0; i < contadorParaOperacoesRealizadas; i++)
            {
                Console.WriteLine(operacoesRealizadas[i]);
            }
        }

        private static bool TemOperacaoRealizada(int contadorParaOperacoesRealizadas)
        {
            return contadorParaOperacoesRealizadas == 0;
        }

        private static bool EhOpcaoMostrarOperacoes(string opcao)
        {
            return opcao == "5";
        }

        private static bool TemEspaçoParaInserir(int contadorParaOperacoesRealizadas)
        {
            return contadorParaOperacoesRealizadas < 100;
        }

        private static double RealizarOperacao(string operacao, double n1, double n2)
        {
            switch (operacao)
            {
                case "+": return n1 + n2;
                case "-": return n1 - n2;
                case "*": return n1 * n2;
                case "/": return n1 / n2;
                default: return 0;
            }
        }

        private static string PegarOperacao(string opcao)
        {
            switch (opcao)
            {
                case "1": return "+";
                case "2": return "-";
                case "3": return "*";
                case "4": return "/";
                default: return null;
            }
        }

        private static bool EhDivisaoValida(string opcao, double n2)
        {
            return opcao == "4" && n2 == 0;
        }

        private static bool EhOpcaoSair(string opcao)
        {
            return opcao.Equals("s", StringComparison.OrdinalIgnoreCase);
        }

        private static void MostrarMenu()
        {
            Console.WriteLine("1. Somar");
            Console.WriteLine("2. Substrair");
            Console.WriteLine("3. Multiplicar");
            Console.WriteLine("4. Dividir");
            Console.WriteLine("5. Ver Operações");
            Console.WriteLine("S. Sair");
        }

        private static bool EhOpcaoValida(string opcao)
        {
            return opcao == "1" || opcao == "2" ||
                opcao == "3" || opcao == "4" ||
                opcao == "5" || opcao.Equals("s", StringComparison.OrdinalIgnoreCase);
        }

        private static void MostrarMensagemErro(string mensagem)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(mensagem);
            Console.ResetColor();
        }

        private static void PausarConsole()
        {
            Console.Write("Digite qualquer coisa para continuar: ");
            Console.ReadLine();
        }

        private static double LerDouble(string ordem)
        {
            bool numeroLidoEhNumero = false;
            double numero = 0.0;

            do
            {
                Console.Write($"Digite o {ordem} numero: ");
                string numeroString = Console.ReadLine();
                numeroLidoEhNumero = double.TryParse(numeroString, out numero);

                if (!numeroLidoEhNumero) 
                {
                    MostrarMensagemErro("Por Favor, Digite um numero!");
                }

            } while (!numeroLidoEhNumero);

            return numero;
        }
       
    }
}

