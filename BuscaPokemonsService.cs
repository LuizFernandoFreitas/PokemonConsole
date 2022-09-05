using ConsolePokemon.Data;
using ConsolePokemon.Data.Response;
using ConsolePokemon.Helpers;
using Newtonsoft.Json;
using RestSharp;

namespace ConsolePokemon
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

        public async Task<PokemonDTO> BuscarPokemons()
        {
            List<PokemonDTO> pokemonDTOs = new();

            Console.WriteLine("---------------------------ESCOLHA SEU POKEMON---------------------------");
                
            for (int i = 0; listaIdsPokemons.Count > i; i++)
            {
                var pokemon = listaIdsPokemons[i];

                var indiceReal = i + 1;

                var request = new RestRequest($"{urlPokemon}{pokemon.GetHashCode()}", Method.Get);

                var response = await client.GetAsync(request);

                var dadosPokemonsResponse = JsonConvert.DeserializeObject<HabilidadePokemonResponse>(response.Content);

                Console.WriteLine($"{indiceReal} - {pokemon}");

                List<Habilidade> habilidades = new();

                for (int j = 0; dadosPokemonsResponse.Habilidades.Count > j; j++)
                {
                    var habilidade = dadosPokemonsResponse.Habilidades[j];

                    Console.WriteLine($"Habilidade {j + 1}: {habilidade.HabilidadePokemon.Nome}");
                    Console.WriteLine($"Altura: {dadosPokemonsResponse.Altura}");
                    Console.WriteLine($"Peso: {dadosPokemonsResponse.Peso}");

                    habilidades.Add(habilidade);
                }

                pokemonDTOs.Add(new PokemonDTO
                {
                    Habilidades = habilidades,
                    NomePokemon = pokemon.ToString(),
                    PokemonCode = indiceReal
                });

                Console.WriteLine("");
            }

            Console.WriteLine("");
            Console.WriteLine("Escolha qual eles você gostaria de adicionar ao seu time");
            var pokemonSelecionado = GetValor(Console.ReadLine());

            var pokemonEncontrado = pokemonDTOs.FirstOrDefault(pkm => pkm.PokemonCode.Equals(pokemonSelecionado));

            if (pokemonEncontrado != null)
            {
                Console.WriteLine($"Parabéns agora o {pokemonEncontrado.NomePokemon} é seu novo companheiro de jornada.");
            }

            return pokemonEncontrado;
        }

        private short GetValor(string valor)
        {
            short.TryParse(valor, out short valorConvertido);

            return valorConvertido;
        }
    }
}