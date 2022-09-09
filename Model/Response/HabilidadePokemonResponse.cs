using Newtonsoft.Json;

namespace ConsolePokemon.Model.Response
{
    public class HabilidadePokemonResponse
    {
        [JsonProperty(PropertyName = "abilities")]
        public List<Habilidade> Habilidades { get; set; }

        [JsonProperty(PropertyName = "height")]
        public int Altura { get; set; }

        [JsonProperty(PropertyName = "weight")]
        public int Peso { get; set; }
    }

    public class Habilidade
    {
        [JsonProperty(PropertyName = "ability")]
        public DadoNomeUrl HabilidadePokemon { get; set; }
    }

    public class DadoNomeUrl
    {
        [JsonProperty(PropertyName = "name")]
        public string Nome { get; set; }

        [JsonProperty(PropertyName = "url")]
        public string Url { get; set; }
    }
}
