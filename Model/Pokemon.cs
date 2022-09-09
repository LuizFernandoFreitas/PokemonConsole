using ConsolePokemon.Model.Response;
using System.Drawing;

namespace ConsolePokemon.Model
{
    public class Pokemon
    {
        public Pokemon()
        {
            IndiceFome = GerarNumeroAleatorioDe0a10();

            IndiceHumor = GerarNumeroAleatorioDe0a10();
        }

        public string NomePokemon { get; set; }
        public List<Habilidade> Habilidades { get; set; }
        public string StatusHumor { get; set; }
        public string StatusFome { get; set; }
        public int PokemonCode { get; set; }
        public int Peso { get; set; }
        public int Altura { get; set; }

        private int IndiceFome { get; set; }

        private int IndiceHumor { get; set; }

        public string ValidarFome()
        {
            return IndiceFome switch
            {
                0 or 1 or 2 or 3 or 4 => $"{NomePokemon} está com fome",
                5 or 6 => $"{NomePokemon} não está com fome e nem cheio",
                7 or 8 or 9 or 10 => $"{NomePokemon} esta bem satisfeito",
                _ => "",
            };
        }

        public string ValidarHumor()
        {
            return IndiceHumor switch
            {
                0 or 1 => $"{NomePokemon} muito triste",
                2 or 3 => $"{NomePokemon} está triste",
                4 or 5 => $"{NomePokemon} está normal",
                6 or 7 => $"{NomePokemon} está feliz",
                8 or 9 or 10 => $"{NomePokemon} está extremamente feliz",
                _ => ""
            };
        }

        private static int GerarNumeroAleatorioDe0a10() =>
            new Random().Next(0, 10);

        public void BrincarComOPokemon()
        {
            IndiceFome--;
            IndiceHumor++;
        }

        public void AlimentarOPokemon()
        {
            IndiceFome++;
        }
    }
}