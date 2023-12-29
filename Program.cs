using ScreenSound.Menus;
using ScreenSound.Modelos;

internal class Program 
{
    private static void Main(string[] args)
    {
        Banda ira = new Banda("Ira!");
        ira.AdicionarNota(new Avaliacao(10));
        ira.AdicionarNota(new Avaliacao(8));
        ira.AdicionarNota(new Avaliacao(6));
        Banda beatles = new("The Beatles!");


        Dictionary<string, Banda> bandasRegistradas = new();
        bandasRegistradas.Add(ira.Nome, ira);
        bandasRegistradas.Add(beatles.Nome, beatles);

        Dictionary<int, Menu> op = new();
        op.Add(1, new MenuRegistrarBanda());
        op.Add(2, new MenuRegistrarAlbum());
        op.Add(3, new MenuMostrarBandasRegistradas());
        op.Add(4, new MenuAvaliarBanda());
        op.Add(5, new MenuExibirDetalhes());
        op.Add(-1, new MenuSair());



        void ExibirLogo()
        {
            Console.WriteLine(@"

        ░██████╗░█████╗░██████╗░███████╗███████╗███╗░░██╗  ░██████╗░█████╗░██╗░░░██╗███╗░░██╗██████╗░
        ██╔════╝██╔══██╗██╔══██╗██╔════╝██╔════╝████╗░██║  ██╔════╝██╔══██╗██║░░░██║████╗░██║██╔══██╗
        ╚█████╗░██║░░╚═╝██████╔╝█████╗░░█████╗░░██╔██╗██║  ╚█████╗░██║░░██║██║░░░██║██╔██╗██║██║░░██║
        ░╚═══██╗██║░░██╗██╔══██╗██╔══╝░░██╔══╝░░██║╚████║  ░╚═══██╗██║░░██║██║░░░██║██║╚████║██║░░██║
        ██████╔╝╚█████╔╝██║░░██║███████╗███████╗██║░╚███║  ██████╔╝╚█████╔╝╚██████╔╝██║░╚███║██████╔╝
        ╚═════╝░░╚════╝░╚═╝░░╚═╝╚══════╝╚══════╝╚═╝░░╚══╝  ╚═════╝░░╚════╝░░╚═════╝░╚═╝░░╚══╝╚═════╝░
        ");
            Console.WriteLine("Boas vindas ao Screen Sound 2.0!");
        }

        void ExibirOpcoesDoMenu()
        {
            ExibirLogo();
            Console.WriteLine("\nDigite 1 para registrar uma banda");
            Console.WriteLine("Digite 2 para registrar o álbum de uma banda");
            Console.WriteLine("Digite 3 para mostrar todas as bandas");
            Console.WriteLine("Digite 4 para avaliar uma banda");
            Console.WriteLine("Digite 5 para exibir os detalhes de uma banda");
            Console.WriteLine("Digite -1 para sair");

            Console.Write("\nDigite a sua opção: ");
            string opcaoEscolhida = Console.ReadLine()!;
            int opcaoEscolhidaNumerica = int.Parse(opcaoEscolhida);

            if (op.ContainsKey(opcaoEscolhidaNumerica))
            {
                Menu menuASerExibido = op[opcaoEscolhidaNumerica];
                menuASerExibido.Executar();
            }
            else
            {
                Console.WriteLine("Opção inválida");
            }

            switch (opcaoEscolhidaNumerica)
            {
                case 1:
                    MenuRegistrarBanda menu1 = new();
                    menu1.Executar(bandasRegistradas);
                    ExibirOpcoesDoMenu();
                    break;
                case 2:
                    MenuRegistrarAlbum menu2 = new();
                    menu2.Executar(bandasRegistradas);
                    ExibirOpcoesDoMenu();
                    break;
                case 3:
                    MenuMostrarBandasRegistradas menu3 = new();
                    menu3.Executar(bandasRegistradas);
                    ExibirOpcoesDoMenu();
                    break;
                case 4:
                    MenuAvaliarBanda menu4 = new();
                    menu4.Executar(bandasRegistradas);
                    ExibirOpcoesDoMenu();
                    break;
                case 5:
                    MenuExibirDetalhes menu5 = new();
                    menu5.Executar(bandasRegistradas);
                    ExibirOpcoesDoMenu();
                    break;
                case -1:
                    Console.WriteLine("Tchau tchau :)");
                    break;
                default:
                    Console.WriteLine("Opção inválida");
                    break;
            }
        }

        void ExibirTituloDaOpcao(string titulo)
        {
            int quantidadeDeLetras = titulo.Length;
            string asteriscos = string.Empty.PadLeft(quantidadeDeLetras, '*');
            Console.WriteLine(asteriscos);
            Console.WriteLine(titulo);
            Console.WriteLine(asteriscos + "\n");
        }
    
        ExibirOpcoesDoMenu();
    }
}