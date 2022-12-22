using System.Text.RegularExpressions;


namespace DesafioFundamentos.Models
{
  public class Estacionamento
  {
    private decimal precoInicial = 0;
    private decimal precoPorHora = 0;
    private List<string> veiculos = new List<string>();

    

    public Estacionamento(decimal precoInicial, decimal precoPorHora)
    {
      this.precoInicial = precoInicial;
      this.precoPorHora = precoPorHora;
    }

    
    
    public static bool ValidarPlaca(string placa)
    
    {
      if (string.IsNullOrEmpty(placa))
        return false;

      if (placa.Length != 7)
        return false;

      placa = placa.Replace("-", "").Trim();

      if (char.IsLetter(placa, 4))
      {
        var padraoMercosul = new Regex(@"^[A-Z]{3}[0-9][0-9A-Z][0-9]{2}$");
        return padraoMercosul.IsMatch(placa);
      }
      else
      {
        var padraoBrasil = new Regex(@"^[A-Z]{3}[0-9]{4}$");
        return padraoBrasil.IsMatch(placa);
      }
    }


    public void AdicionarVeiculo()
    {
      // TODO: Pedir para o usuário digitar uma placa (ReadLine) e adicionar na lista "veiculos"
      string placa = Console.ReadLine();
      var resultado = ValidarPlaca(placa);
      var mensagem = resultado? "Válida" : "Inválida";

      Console.WriteLine("Digite a placa do veículo para estacionar:");
      if (ValidarPlaca(placa))
      {
        veiculos.Add(placa);
        Console.WriteLine($"O veículo {placa} foi adicionado com sucesso!");
      }
      else
      {
        Console.WriteLine("Placa inválida!");
      }
    }

    

    public void RemoverVeiculo()
    {
      Console.WriteLine("Digite a placa do veículo para remover:");

      // Pedir para o usuário digitar a placa e armazenar na variável placa
      // *IMPLEMENTE AQUI*
      string placa = Console.ReadLine();

      // Verifica se o veículo existe
      if (veiculos.Any(x => x.ToUpper() == placa.ToUpper()))
      {
        Console.WriteLine("Digite a quantidade de horas que o veículo permaneceu estacionado:");
        string result = Console.ReadLine();
        int horas = Convert.ToInt32(result);
        decimal valorTotal = precoInicial + precoPorHora * horas;
        veiculos.Remove(placa);
        Console.WriteLine($"O veículo {placa} foi removido e o preço total foi de: R$ {valorTotal}");
      }
      else
      {
        Console.WriteLine("Desculpe, esse veículo não está estacionado aqui. Confira se digitou a placa corretamente");
      }
    }

    public void ListarVeiculos()
    {
      // Verifica se há veículos no estacionamento
      if (veiculos.Any())
      {
        Console.WriteLine("Os veículos estacionados são:");
        // TODO: Realizar um laço de repetição, exibindo os veículos estacionados
        

        int contadorForeach = 0;  
        foreach (string item in veiculos)
        {
          Console.WriteLine($"Veículo {contadorForeach}: {item}");
          contadorForeach++;
        }
      }
      else
      {
        Console.WriteLine("Não há veículos estacionados no momento");
      }
    }

  
  }
}
                              