using ConsolePokemon;
using ConsolePokemon.Data;

Apresentacao apresentacao = new();
BuscaPokemonsService buscaPokemons = new();
List<PokemonDTO> listaPokemons = new();

apresentacao.ColetarDadosUsuario();

short opcaoSelecionada;

do
{
    opcaoSelecionada = Apresentacao.OpcoesDeJogo();

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
            Apresentacao.MensagemDeDespedida();
            break;
        default:
            Apresentacao.OpcaoInvalida();
            break;
    }

    Console.WriteLine("");

} while (opcaoSelecionada != 3);