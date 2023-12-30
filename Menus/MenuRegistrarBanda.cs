using ScreenSound.Modelos;
using OpenAI_API;

namespace ScreenSound.Menus;

internal class MenuRegistrarBanda : Menu
{
    public override void Executar(Dictionary<string, Banda> bandasRegistradas)
    {
        base.Executar(bandasRegistradas);
        ExibirTituloDaOpcao("Registro das bandas");
        Console.Write("Digite o nome da banda que deseja registrar: ");
        string nomeDaBanda = Console.ReadLine()!;
        Banda banda = new Banda(nomeDaBanda);
        bandasRegistradas.Add(nomeDaBanda, banda);

        var client = new OpenAIAPI("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");

        var chat = client.Chat.CreateConversation();
        chat.AppendSystemMessage($"Resuma a banda {nomeDaBanda} em 1 parágrafo. Afote um estilo informal.");

        string resposta = chat.GetResponseFromChatbotAsyn().GetAwaiter().GetResult();
        banda.Resumo = resposta;
        Console.WriteLine(resposta);

        Console.WriteLine($"A banda {nomeDaBanda} foi registrada com sucesso!");
        Console.WriteLine("\nDigite uma tecla para votar ao menu principal");
            Console.ReadKey();
            Console.Clear();
    }
}