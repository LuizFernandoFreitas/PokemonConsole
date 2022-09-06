using ConsolePokemon.Data;
using ConsolePokemon.Services;
using ConsolePokemon.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                            Console.WriteLine("");
                            Console.WriteLine("Você não possuí ainda pokemons na sua lista");
                            Console.WriteLine("");

                            break;
                        }

                        Console.WriteLine("Sua lista contêm os seguintes pokemons...");

                        foreach (var pokemonList in listaPokemons)
                        {
                            Console.WriteLine(pokemonList.NomePokemon);
                        }

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
    }
}
