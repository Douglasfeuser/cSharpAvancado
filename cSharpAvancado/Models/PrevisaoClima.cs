namespace cSharpAvancado.Models;

public class PrevisaoClima
{
    public string Name { get; set; }
    public Temperatura Main { get; set; }
    public DadoClima[] Weather { get; set; }
}