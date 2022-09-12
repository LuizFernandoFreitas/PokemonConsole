using ConsolePokemon.Model;
using ConsolePokemon.Services;
using ConsolePokemon.View;

namespace ConsolePokemon.Controller
{
    public class ControleDeJogoController
    {
        readonly PokemonView apresentacao = new();
        readonly BuscaPokemonsService buscaPokemons = new();
        readonly List<Pokemon> listaPokemons = new();

        public async Task IniciarJornadaPokemon()
        {
            apresentacao.ColetarDadosUsuario();

            short opcaoSelecionada;

            try
            {
                do
                {
                    opcaoSelecionada = PokemonView.OpcoesDeJogo();

                    switch (opcaoSelecionada)
                    {
                        case 1:
                            var pokemon = await buscaPokemons.BuscarPokemons();
                            listaPokemons.Add(pokemon);
                            break;
                        case 2:

                            if (listaPokemons?.Count == 0)
                            {
                                PokemonView.ListaDePokemonsVazia();

                                break;
                            }

                            PokemonView.ListarPokemons(listaPokemons);

                            var pokemonInteracao = PokemonView.ExibirPokemonsParaInteracao(listaPokemons);

                            PokemonView.InteracaoComoPokemon(pokemonInteracao);

                            break;
                        case 3:
                            PokemonView.MensagemDeDespedida();
                            break;
                        default:
                            PokemonView.OpcaoInvalida();
                            break;
                    }

                    Console.WriteLine("");

                } while (opcaoSelecionada != 3);
            }
            catch (Exception erro)
            {
                Console.WriteLine(erro.ToString());
            }
        }
    }
}