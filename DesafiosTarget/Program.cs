using DesafiosTarget.desafio_01;
using DesafiosTarget.desafio_02;
using DesafiosTarget.desafio_03;

Console.OutputEncoding = System.Text.Encoding.UTF8;

await ExecutarMenuPrincipalAsync();

async Task ExecutarMenuPrincipalAsync()
{
    bool executando = true;

    while (executando)
    {
        ExibirMenu();
        var opcao = Console.ReadLine();

        switch (opcao)
        {
            case "1":
                Console.Clear();
                var desafioUm = new DesafioUm();
                await desafioUm.ExecutarAsync();
                AguardarContinuacao();
                break;
            case "2":
                Console.Clear();
                var desafioDois = new DesafioDois();
                await desafioDois.ExecutarAsync();
                break;
            case "3":
                Console.Clear();
                var desafioTres = new DesafioTres();
                desafioTres.Executar();
                AguardarContinuacao();
                break;
            case "0":
                executando = false;
                Console.WriteLine("\nObrigado por usar o sistema! Até mais.");
                break;
            default:
                Console.WriteLine("\nOpção inválida. Tente novamente.");
                Thread.Sleep(1500);
                break;
        }
    }
}

void ExibirMenu()
{
    Console.Clear();
    Console.WriteLine("╔════════════════════════════════════════════════════════════╗");
    Console.WriteLine("║                                                            ║");
    Console.WriteLine("║              DESAFIOS TARGET SISTEMAS                      ║");
    Console.WriteLine("║                                                            ║");
    Console.WriteLine("╠════════════════════════════════════════════════════════════╣");
    Console.WriteLine("║                                                            ║");
    Console.WriteLine("║   [1] Desafio 1 - Calculadora de Comissões                 ║");
    Console.WriteLine("║   [2] Desafio 2 - Controle de Estoque                      ║");
    Console.WriteLine("║   [3] Desafio 3 - Calculadora de Juros                     ║");
    Console.WriteLine("║                                                            ║");
    Console.WriteLine("║   [0] Sair                                                 ║");
    Console.WriteLine("║                                                            ║");
    Console.WriteLine("╚════════════════════════════════════════════════════════════╝");
    Console.WriteLine();
    Console.Write("Escolha uma opção: ");
}

void AguardarContinuacao()
{
    Console.WriteLine();
    Console.WriteLine("Pressione qualquer tecla para voltar ao menu...");
    Console.ReadKey();
}
