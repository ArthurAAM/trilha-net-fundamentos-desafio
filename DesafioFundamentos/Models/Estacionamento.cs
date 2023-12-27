namespace DesafioFundamentos.Models
{
    public class Estacionamento(decimal precoInicial, decimal precoPorHora)
    {
        private readonly decimal precoInicial = precoInicial;
        private readonly decimal precoPorHora = precoPorHora;
        private readonly List<string> veiculos = [];

        public void AdicionarVeiculo()
        {
            Console.WriteLine("Digite a placa do veículo para estacionar:");
            string placa = Console.ReadLine().ToUpper();

            // Verifica se a placa é vazia ou se já está no estacionamento. Se não, adiciona à lista   
            if (placa == "")
            {
                throw new ArgumentException("A placa não pode ser vazia");
            }
            
            if(veiculos.Contains(placa)) 
            {
                throw new InvalidOperationException("Este carro já está no estacionamento");
            }

            veiculos.Add(placa);
        }

        public void RemoverVeiculo()
        {
            Console.WriteLine("Digite a placa do veículo para remover:");
            string placa = Console.ReadLine().ToUpper();
            // Verifica se o veículo existe
            if (veiculos.Any(x => x.Equals(placa, StringComparison.CurrentCultureIgnoreCase)))
            {
                Console.WriteLine("Digite a quantidade de horas que o veículo permaneceu estacionado:");

                string input = Console.ReadLine();


                // Horas trocado para decimal para suportar horas quebradas (por ex: 2,5 horas)
                // Verifica se o input de hora é válido. Se for, remove o veículo
                if (!decimal.TryParse(input, out decimal horas))
                {
                    throw new ArgumentException("Esse não é um número válido de horas.");
                }
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
            if (veiculos.Count != 0)
            {
                // Imprime veículo por veículo que está no estacionamento, junto de seu ID
                Console.WriteLine("Os veículos estacionados são:");
                for (int count = 0; count < veiculos.Count; count++)
                {
                    Console.WriteLine($"N° {count + 1} - {veiculos[count]}");
                }
            }
            else
            {
                Console.WriteLine("Não há veículos estacionados.");
            }
        }
    }
}
