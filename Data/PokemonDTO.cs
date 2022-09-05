using ConsolePokemon.Data.Response;
using ConsolePokemon.Helpers;

namespace ConsolePokemon.Data
{
    public class PokemonDTO
    {
        public string NomePokemon { get; set; }
        public List<Habilidade> Habilidades { get; set; }
        public int PokemonCode { get; set; }
    }
}