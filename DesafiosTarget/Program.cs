using DesafiosTarget.desafio_01;
using DesafiosTarget.desafio_02;

Console.OutputEncoding = System.Text.Encoding.UTF8;

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
            desafioUm.Executar();
            AguardarContinuacao();
            break;
        case "2":
            Console.Clear();
            var desafioDois = new DesafioDois();
            desafioDois.Executar();
            break;
        case "3":
            Console.Clear();
            Console.WriteLine("Desafio 3 - Em desenvolvimento...");
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
    Console.WriteLine("║   [3] Desafio 3 - Em desenvolvimento                       ║");
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
