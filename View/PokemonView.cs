using ConsolePokemon.Helpers;
using ConsolePokemon.Model;
using ConsolePokemon.Model.Response;

namespace ConsolePokemon.View
{
    public class PokemonView
    {
        public string NomeTreinadorPokemon { get; set; }

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

        public static void ListaDePokemonsVazia()
        {
            Console.WriteLine("");
            Console.WriteLine("Você não possuí ainda pokemons na sua lista");
            Console.WriteLine("");
        }

        public static void ListarPokemons(List<Pokemon> pokemons)
        {
            Console.WriteLine("Sua lista contêm os seguintes pokemons...");

            foreach (var pokemon in pokemons)
            {
                Console.WriteLine($"Nome: {pokemon.NomePokemon}");
                Console.WriteLine($"{pokemon.ValidarFome()}");
                Console.WriteLine($"{pokemon.ValidarHumor()}");
                Console.WriteLine($"Peso: {pokemon.Peso}");
                Console.WriteLine($"Altura: {pokemon.Altura}");

                Console.WriteLine("Habilidades:");
                foreach (var habilidade in pokemon.Habilidades)
                {
                    Console.Write($"{habilidade.HabilidadePokemon.Nome} ");
                }

                Console.WriteLine("");
            }

            Console.WriteLine("");
        }

        public static void ExibirListaHabilidadeECaracteristicas(
            List<Habilidade> habilidades,
            int altura,
            int peso)
        {
            for (int j = 0; habilidades.Count > j; j++)
            {
                var habilidade = habilidades[j];

                Console.WriteLine($"Habilidade {j + 1}: {habilidade.HabilidadePokemon.Nome}");
                Console.WriteLine($"Altura: {altura}");
                Console.WriteLine($"Peso: {peso}");
            }
        }

        public static Pokemon EscolhaDoPokemon(List<Pokemon> pokemons)
        {
            Console.WriteLine("");
            Console.WriteLine("Escolha qual eles você gostaria de adicionar ao seu time");

            var pokemon = BuscarPokemon(pokemons);

            if (pokemon != null)
            {
                Console.WriteLine($"Parabéns agora o {pokemon.NomePokemon} é seu novo companheiro de jornada.");
            }

            return pokemon;
        }

        public static void InicioMenuEscolhaPokemon()
        {
            Console.WriteLine("---------------------------ESCOLHA SEU POKEMON---------------------------");
        }

        public static void ExibePokemonsEncontrados(
            int indice,
            EnumPokemons pokemon)
        {
            Console.WriteLine($"{indice} - {pokemon}");
        }

        public static Pokemon ExibirPokemonsParaInteracao(List<Pokemon> pokemons)
        {
            Console.WriteLine("---------------------------COM QUAL POKEMON INTERAGIR---------------------------");

            var indiceFinal = 1;
            for (int i = 0; i < pokemons.Count; i++)
            {
                Console.WriteLine($"{i + 1} - {pokemons[i].NomePokemon}");

                indiceFinal += i + 1;
            }

            Console.WriteLine($"{indiceFinal} - Voltar");

            Console.WriteLine("");

            return BuscarPokemon(pokemons);
        }

        public static void InteracaoComoPokemon(Pokemon pokemon)
        {
            if (pokemon != null)
            {
                var finalizarInteracao = "0";

                while (finalizarInteracao != "4")
                {
                    Console.WriteLine("Você desseja");
                    Console.WriteLine("1 - Alimentar o pokemon");
                    Console.WriteLine("2 - Brincar com o pokemon");
                    Console.WriteLine("3 - Saber como ele está");
                    Console.WriteLine("4 - Finalizar interação");

                    finalizarInteracao = Console.ReadLine();

                    if (finalizarInteracao != "4")
                    {
                        switch (finalizarInteracao)
                        {
                            case "1":
                                pokemon.AlimentarOPokemon();

                                Console.WriteLine("Olha a carinha de alegria de quem acabou de comer (^.^) ");
                                break;
                            case "2":
                                pokemon.BrincarComOPokemon();

                                Console.WriteLine(@"Veja como ele fica depois de brincar com você \o/. ");
                                break;
                            case "3":
                                Console.WriteLine(pokemon.ValidarFome());
                                Console.WriteLine(pokemon.ValidarHumor());
                                break;
                            default:
                                Console.WriteLine("Opção inválida");
                                break;
                        }
                    }

                    Console.WriteLine("");
                }

                Console.WriteLine("");
            }
        }

        private static short GetValor(string valor)
        {
            _ = short.TryParse(valor, out short valorConvertido);

            return valorConvertido;
        }

        private static Pokemon BuscarPokemon(List<Pokemon> pokemons)
        {
            var pokemonSelecionado = GetValor(Console.ReadLine());

            return pokemons.FirstOrDefault(pkm => pkm.PokemonCode.Equals(pokemonSelecionado));
        }
    }
}