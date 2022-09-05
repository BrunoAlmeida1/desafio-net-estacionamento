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

        public void AdicionarVeiculo()
        {
            Console.WriteLine("\nDigite a placa do veículo para estacionar: ");
            string placa = Console.ReadLine();

            //Esse trecho verifica se a placa é válida, usando, além do método Contains, os métodos ContemLetras e ContemNumeros para isso.
            if (placa.Contains("-") && ContemNumeros(placa) && ContemLetras(placa))
            {
                veiculos.Add(placa);
            }
            else
            {
                Console.WriteLine("Placa Inválida!\n");
                AdicionarVeiculo();
            }

            bool ContemLetras(string placa)
            {
                if (placa.Where(c => char.IsLetter(c)).Count() > 0)
                    return true;
                else
                    return false;
            }

            bool ContemNumeros(string placa)
            {
                if (placa.Where(c => char.IsNumber(c)).Count() > 0)
                    return true;
                else
                    return false;
            }
        }

        public void RemoverVeiculo()
        {
            Console.WriteLine("\nDigite a placa do veículo para remover:");
            string placa = Console.ReadLine();

            // Verifica se o veículo existe
            if (veiculos.Any(x => x.ToUpper() == placa.ToUpper()))
            {
                Console.WriteLine("Digite a quantidade de horas que o veículo permaneceu estacionado:");
                int horas = int.Parse(Console.ReadLine());
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
                Console.WriteLine("\nOs veículos estacionados são:");

                foreach (string placa in veiculos)
                {
                    Console.WriteLine(placa);
                }
            }
            else
            {
                Console.WriteLine("Não há veículos estacionados.");
            }
        }
    }
}
