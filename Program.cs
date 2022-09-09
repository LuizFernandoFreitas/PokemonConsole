using ConsolePokemon.Controller;

try
{
    ControleDeJogoController controleJogo = new();

    await controleJogo.IniciarJornadaPokemon();
}
catch (Exception erro)
{
    throw;
}