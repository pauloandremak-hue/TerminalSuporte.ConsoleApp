using System;
using System.Threading;

class Program
{
    static void Main()
    {
        while (true)
        {
            MostrarMenu();
            Console.Write("\nDigite um comando: ");
            string comando = Console.ReadLine().ToLower();

            switch (comando)
            {
                case "ping":
                    ExecutarPing();
                    break;

                case "reset":
                    ReiniciarServidor();
                    break;

                case "help":
                case "?":
                    MostrarAjuda();
                    break;

                case "sair":
                    Console.WriteLine("Encerrando sistema...");
                    return;

                default:
                    Erro("Comando inválido! Digite 'help' para ajuda.");
                    break;
            }
        }
    }

    static void MostrarMenu()
    {
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("STATUS DO SISTEMA: [OPERACIONAL]");
        Console.ResetColor();

        Console.WriteLine("\nCOMANDOS DISPONÍVEIS:");
        Console.WriteLine(" ping  - Testar conexão");
        Console.WriteLine(" reset - Reiniciar servidor (crítico)");
        Console.WriteLine(" help  - Ajuda");
        Console.WriteLine(" sair  - Fechar terminal");
    }

    // Heurística #6 (reconhecimento)
    static void MostrarAjuda()
    {
        Console.WriteLine("\n--- AJUDA ---");
        Console.WriteLine("ping  -> testa conexão com um IP");
        Console.WriteLine("reset -> reinicia o servidor (precisa confirmar)");
        Console.WriteLine("sair  -> fecha o sistema");
    }

    // Heurística #5 (prevenção de erros)
    static void ExecutarPing()
    {
        Console.Write("\nDigite o IP (ex: 192.168.0.1): ");
        string ip = Console.ReadLine();

        if (!ip.Contains("."))
        {
            Erro("IP inválido! Use o formato: xxx.xxx.xxx.xxx");
            return;
        }

        Console.WriteLine("\nEnviando pacotes...");
        Thread.Sleep(1500);

        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("Resposta recebida com sucesso! Latência: 15ms");
        Console.ResetColor();

        Console.ReadKey();
    }

    // Confirmação de ação crítica
    static void ReiniciarServidor()
    {
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.Write("\nTem certeza que deseja reiniciar? (s/n): ");
        Console.ResetColor();

        string resposta = Console.ReadLine().ToLower();

        if (resposta != "s")
        {
            Console.WriteLine("Operação cancelada.");
            return;
        }

        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("\nReiniciando servidor...");
        Console.ResetColor();

        Thread.Sleep(2000);

        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("Servidor reiniciado com sucesso!");
        Console.ResetColor();

        Console.ReadKey();
    }

    static void Erro(string mensagem)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine(mensagem);
        Console.ResetColor();
        Console.ReadKey();
    }
}
