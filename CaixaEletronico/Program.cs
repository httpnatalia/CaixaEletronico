using System;
using System.Threading;
class HelloWorld
{
    static void Main()
    {
        double saldo = 0;
        int escolha = 0;
        string[] opcaoinicial = new string[4] { "Verificar saldo dispónivel", "Depositar valor", "Sacar valor", "Sair" };
        while (true)
        {
            Console.Clear();
            escolha = mostrarMenu("Caixa Eletrônico", opcaoinicial);
            switch (escolha)
            {
                case 1:
                    Console.Clear();
                    Console.WriteLine("•*•*•*•*•*•*•*•*•*•*•*•*•*•*•*•*•*•*•*•*••*•*•*•*•*•*•*•*•*•*•*•*");
                    Console.WriteLine($"Seu saldo disponível no momento é de: {saldo.ToString("C")}");
                    Console.WriteLine("•*•*•*•*•*•*•*•*•*•*•*•*•*•*•*•*•*•*•*•*•*•*•*•*•*•*•*•*•*•*•*•*•*");
                   Thread.Sleep(5000);
                    break;
                case 2:
                    Console.Clear();
                    saldo += depositar();
                    Thread.Sleep(5000);
                    break;
                case 3:
                    Console.Clear();
                    saldo = saque(saldo);
                    Thread.Sleep(5000);
                    break;
                case 4:
                    Console.Clear();
                    escrevaTitulo("Aguarde um momento enquanto finalizamos...");
                    Thread.Sleep(5000);
                    break;
                default:
                    Console.WriteLine("INVÁLIDO. Escolha outra opção para continuar");
                    Thread.Sleep(3000);
                    break;
            }
            if (escolha == 4)
            {
                break;
            }
        }
        static int mostrarMenu(string titulo, string[] opcoes)
        {
            escrevaTitulo(titulo);
            for (int opcao = 0; opcao < opcoes.Length; opcao++)
            {
                Console.WriteLine($"[ {opcao + 1} ] {opcoes[opcao]}");
            }
            Console.WriteLine("•*•*•*•*•*•*•*•*•*•*•*•*•*•*•*•*•*•*•*•*••*•*•*•*•*•*•*•*•*•*•*•*");
            Console.Write("Sua escolha: ");
            int resposta = int.Parse(Console.ReadLine());
            return resposta;
        }
        static void escrevaTitulo(string mensagem)
        {
            Console.WriteLine("•*•*•*•*•*•*•*•*•*•*•*•*•*•*•*•*•*•*•*•*••*•*•*•*•*•*•*•*•*•*•*•*");
            Console.WriteLine(mensagem);
            Console.WriteLine("•*•*•*•*•*•*•*•*•*•*•*•*•*•*•*•*•*•*•*•*••*•*•*•*•*•*•*•*•*•*•*•*");
        }
        static double depositar()
        {
            double valorDeposito = 0;
            Console.WriteLine("•*•*•*•*•*•*•*•*•*•*•*•*•*•*•*•*•*•*•*•*••*•*•*•*•*•*•*•*•*•*•*•*");
            Console.Write("Por favor digite o valor que deseja depositar: ");
            valorDeposito = double.Parse(Console.ReadLine());
            escrevaTitulo("Depósito efetuado! Aguarde seu comprovante.");
            return valorDeposito;
            Thread.Sleep(5000);
        }
        static double saque(double saldoAtual)
        {
            escrevaTitulo("Por favor informe o valor que deseja sacar: ");
            Console.Write("VALOR: ");
            double valorSaque = double.Parse(Console.ReadLine());
            if (valorSaque > saldoAtual)
            {
                escrevaTitulo("Saldo Indisponível.Tente novamente.");
                return saldoAtual;
            }
            else
                if (valorSaque <= saldoAtual)
            {
                double cedulaAtual = 100;
                int totalCedulas = 0;
                double valorSacado = 0;
                while (true)
                {
                    if (valorSaque >= cedulaAtual)
                    {
                        valorSaque -= cedulaAtual;
                        totalCedulas += 1;
                        valorSacado += cedulaAtual;
                    }
                    else
                    {
                        if (totalCedulas == 1)
                        {
                            if (cedulaAtual == 1)
                            {
                                Console.WriteLine($"{totalCedulas} moeda de {cedulaAtual.ToString("C")} liberada...");
                            }
                            else
                            {
                                Console.WriteLine($"{totalCedulas} nota de {cedulaAtual.ToString("C")} liberada...");
                            }
                            totalCedulas = 0;
                            Thread.Sleep(3000);
                        }
                        if (totalCedulas > 1)
                        {
                            if (cedulaAtual == 1)
                            {
                                Console.WriteLine($"{totalCedulas} moedas de {cedulaAtual.ToString("C")} liberadas...");
                            }
                            else
                            {
                                Console.WriteLine($"{totalCedulas} notas de {cedulaAtual.ToString("C")} liberadas...");
                            }
                            totalCedulas = 0;
                            Thread.Sleep(3000);
                        }
                        if (cedulaAtual == 100)
                        {
                            cedulaAtual = 50;
                        }
                        else
                            if (cedulaAtual == 50)
                        {
                            cedulaAtual = 20;
                        }
                        else
                            if (cedulaAtual == 20)
                        {
                            cedulaAtual = 10;
                        }
                        else
                            if (cedulaAtual == 10)
                        {
                            cedulaAtual = 5;
                        }
                        else
                            if (cedulaAtual == 5)
                        {
                            cedulaAtual = 1;
                        }
                        else
                            if (valorSaque < 1)
                        {
                            break;
                        }
                    }
                }
                escrevaTitulo($"Valor {valorSacado.ToString("C")} foi sacado com sucesso!");
                return saldoAtual - valorSacado;
                Thread.Sleep(5000);
            }
            else
            {
                return saldoAtual;
            }
        }
    }
}