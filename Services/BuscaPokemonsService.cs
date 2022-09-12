using ConsolePokemon.Helpers;
using ConsolePokemon.Model;
using ConsolePokemon.Model.Response;
using ConsolePokemon.View;
using Newtonsoft.Json;
using RestSharp;

namespace ConsolePokemon.Services
{
    public class BuscaPokemonsService
    {
        private readonly string urlPokemon = "https://pokeapi.co/api/v2/pokemon/";
        private readonly RestClient client = new();

        private readonly List<EnumPokemons> listaIdsPokemons = new()
        {
            EnumPokemons.Bulbasaur,
            EnumPokemons.Charmander,
            EnumPokemons.Squirtle
        };

        public async Task<Pokemon> BuscarPokemons()
        {
            try
            {
                List<Pokemon> pokemons = new();

                PokemonView.InicioMenuEscolhaPokemon();

                for (int i = 0; listaIdsPokemons.Count > i; i++)
                {
                    var pokemon = listaIdsPokemons[i];

                    var indiceReal = i + 1;

                    var request = new RestRequest($"{urlPokemon}{pokemon.GetHashCode()}", Method.Get);

                    var response = await client.GetAsync(request);

                    if (response.IsSuccessful)
                    {
                        var dadosPokemonsResponse = JsonConvert.DeserializeObject<HabilidadePokemonResponse>(response.Content);

                        PokemonView.ExibePokemonsEncontrados(
                            indiceReal,
                            pokemon);

                        PokemonView.ExibirListaHabilidadeECaracteristicas(
                            dadosPokemonsResponse.Habilidades,
                            dadosPokemonsResponse.Altura,
                            dadosPokemonsResponse.Peso);

                        pokemons.Add(new Pokemon
                        {
                            Habilidades = dadosPokemonsResponse.Habilidades,
                            NomePokemon = pokemon.ToString(),
                            PokemonCode = indiceReal,
                            Altura = dadosPokemonsResponse.Altura,
                            Peso = dadosPokemonsResponse.Peso
                        });

                        Console.WriteLine("");
                    }
                    else
                    {
                        Console.WriteLine($"Ocorreu um erro ao tentar selecionar seu pokemon. Erro {response.Content}");
                    }
                }

                return PokemonView.EscolhaDoPokemon(pokemons);
            }
            catch (Exception erro)
            {
                var mesnagemErro = $"Ocorreu um erro inesperado ao buscar o pokemon. Erro: {erro}";

                throw new Exception(mesnagemErro);
            }
        }
    }
}