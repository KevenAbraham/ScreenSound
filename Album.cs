class Album 
{
    private List<Musica> musicas = new List<Musica>(); //campo privado -> significa que essa propriedade pertence apenas a essa classe.
    public string Nome { get; }
    public int DuracaoTotal => musicas.Sum(m => m.Duracao);

    public Album(string nome)
    {
        Nome = nome;
    }

    public void AdicionarMusica(Musica musica) 
    {
        musicas.Add(musica);
    }

    public void ExibirMusicasDoAlbum() 
    {
        Console.WriteLine($"Listas de músicas do álbum {Nome}:");
        Console.WriteLine();
        foreach ( var musica in musicas)
        {
            Console.WriteLine($"Música: {musica.Nome}");
        }
        Console.WriteLine($"Para ouvir este album inteiro você precisa de {DuracaoTotal}");
    }
}