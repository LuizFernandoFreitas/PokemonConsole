using ConsolePokemon.Data.Response;
using ConsolePokemon.Helpers;
using Newtonsoft.Json;
using RestSharp;

string urlPokemon = "https://pokeapi.co/api/v2/pokemon/";
var client = new RestClient();

var listaIdsPokemons = new List<EnumPokemons>()
{
    EnumPokemons.Bulbasaur,
    EnumPokemons.Charmander,
    EnumPokemons.Squirtle
};

Console.WriteLine("Escolha seu parceiro pokemon:");
Console.WriteLine("");

for (int i = 0; listaIdsPokemons.Count > i; i++)
{
    var pokemon = listaIdsPokemons[i];

    var request = new RestRequest($"{urlPokemon}{pokemon.GetHashCode()}", Method.Get);

    var response = await client.GetAsync(request);

    var dadosPokemonsResponse = JsonConvert.DeserializeObject<HabilidadePokemonResponse>(response.Content);

    Console.WriteLine($"{i + 1} - {pokemon}");

    for (int j = 0; dadosPokemonsResponse.Habilidades.Count > j; j++)
    {
        var habilidade = dadosPokemonsResponse.Habilidades[j];

        Console.WriteLine($"Habilidade {j + 1}: {habilidade.HabilidadePokemon.Nome}");
    }

    Console.WriteLine("");
}