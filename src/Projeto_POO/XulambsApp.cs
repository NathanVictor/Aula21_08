

namespace XulambsFoods {
    public class XulambsApp
    {
        static LinkedList<Pizza> pizzas;
        
        static void Cabecalho() {
            Console.Clear();
            Console.WriteLine("XULAMBS PIZZA v0.11");
            Console.WriteLine("==================");
            Console.WriteLine($"Pizzas vendidas hoje: {Pizza.GetQuantidadeVendida():D2}");
        }

        static void Pausa() {
            Console.WriteLine("Digite <ENTER> para continuar.");
            Console.ReadLine();
        }

        static int MenuPrincipal() {
            Cabecalho();
            Console.WriteLine("1 - Comprar uma pizza");
            Console.WriteLine("2 - Mostrar pizzas vendidas");
            Console.WriteLine("0 - Sair");
            Console.Write("Sua opção: ");
            return int.Parse(Console.ReadLine());
        }

        static void ImprimirDadosPizza(Pizza pizza) {
            Console.WriteLine();
            Console.WriteLine("Pizza comprada:\n ");
            Console.WriteLine(pizza.GerarCupom());
        }

        static void ComprarPizza() {
            Cabecalho();
            Console.WriteLine("Comprando uma pizza:");
            Console.Write("Quantos ingredientes você deseja (0-8)? ");
            int quantos = int.Parse(Console.ReadLine());
            Pizza novaPizza = new Pizza();
            novaPizza.AdicionarIngredientes(quantos);
            ImprimirDadosPizza(novaPizza);
            pizzas.AddLast(novaPizza);

        }

        private static void MostrarPizzas() {
            Cabecalho();
            Console.WriteLine($"Pizzas vendidas até agora ({pizzas.Count}) pizzas:");
            foreach (Pizza pizza in pizzas) {
                ImprimirDadosPizza(pizza);
            }
        }

        static void Main(string[] args) {
            int opcao;
            pizzas = new LinkedList<Pizza>();
            
            do {
                opcao = MenuPrincipal();
                Action metodo = 
                opcao switch {
                    1 => () => ComprarPizza(),
                    2 => () => MostrarPizzas(),
                    0 => () => Console.WriteLine("Encerrando!!"),
                    _ => () => Console.WriteLine("Opção inválida."),
                };
                metodo.Invoke();
                Pausa();

            } while (opcao != 0);
        }

       
    }
}
