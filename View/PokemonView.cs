namespace ConsolePokemon.View
{
    public class PokemonView
    {
        public string NomeTreinadorPokemon { get; set; }

        public List<string>? ListaDePokemons { get; set; }

        public void ColetarDadosUsuario()
        {
            Console.WriteLine("Bem vindo a casa do Professor Carvalho...");
            Console.WriteLine("");

            Console.WriteLine("Aqui você pode encontrar pokemons incríveis para sua jornada...");
            Console.WriteLine("");

            Console.WriteLine("Como você se chama?");
            NomeTreinadorPokemon = Console.ReadLine();
            Console.WriteLine("");

            Console.WriteLine($"Olá {NomeTreinadorPokemon}, venha até a nossa sala para te mostrar os pokemons disponíveis....");
            Console.WriteLine("");
        }

        public static short OpcoesDeJogo()
        {
            Console.WriteLine("----------------------------------MENU----------------------------------");
            Console.WriteLine($"Qual das opções abaixo deseja seguir:");
            Console.WriteLine("1 - Escolher um novo pokemon");
            Console.WriteLine("2 - Ver sua lista de pokemons");
            Console.WriteLine("3 - Sair do jogo");

            var opcao = Console.ReadLine();

            _ = short.TryParse(opcao, out short opcaoSelecionadaShort);

            return opcaoSelecionadaShort;
        }

        public static void MensagemDeDespedida()
        {
            Console.WriteLine("Obrigado pela visita e boa sorte na sua jornada");
        }

        public static void OpcaoInvalida()
        {
            Console.WriteLine("Opção inválida");
        }
    }
}