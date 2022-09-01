﻿using Newtonsoft.Json;

namespace ConsolePokemon.Data.Response
{
    public class HabilidadePokemonResponse
    {
        [JsonProperty(PropertyName = "abilities")]
        public List<Habilidade> Habilidades { get; set; }
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
