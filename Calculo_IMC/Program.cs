using Calculo_IMC;

internal class Program
{

    public static List<Cliente> Clientes = new List<Cliente>();
    private static void Main(string[] args)
    {


        while (true)
        {
            Menu();

            var option = Console.ReadLine();

            if (option == "1")
            {
                CadastrarCliente();
            }

            if (option == "2")
            {
                ConsultarDadosCliente();
            }

            if(option == "3")
            {
                ListarTodos();
            }
        }

    }




    public static void Menu()
    {
        Console.Clear();

        Console.WriteLine("Escolha uma opção:");

        Console.WriteLine("\n1- Cadastrar novo cliente");

        Console.WriteLine("\n2- Consultar Cliente");

        Console.WriteLine("\n3- Listar todos os clientes");
    }




    public static void CadastrarCliente()
    {
        try
        {
            Cliente cliente = new Cliente();
            Console.Clear();

            Console.WriteLine("\n\n>>> Nome: ");
            cliente.Nome = Console.ReadLine();
            Console.Clear();

            Console.WriteLine("\n\n>>> Idade: ");
            cliente.Idade = int.Parse(Console.ReadLine());
            Console.Clear();

            Console.WriteLine("\n\n>>> Peso em Kg: ");
            cliente.Peso = double.Parse(Console.ReadLine());
            Console.Clear();

            Console.WriteLine("\n\n>>> Altura em metros: ");
            cliente.Altura = double.Parse(Console.ReadLine());
            Console.Clear();


            cliente.Id = Clientes.Count + 1;
            cliente.IMC = cliente.Peso/(cliente.Altura*cliente.Altura);

            Clientes.Add(cliente);

        }

        catch(Exception)
        {
            Console.Clear();
            Console.WriteLine("Valor invalido!");
            Console.ReadKey();
            
        }
    }

    public static void ConsultarDadosCliente()
    {
        int aux = 1;
        Console.Clear();

        try
        {
            if (Clientes.Any())
            {


                Console.WriteLine("Digite o número correspondente para " +
                    "acessar as informações do cliente");

                foreach (Cliente cliente in Clientes)
                {
                    Console.WriteLine($"{aux}- " + cliente.Nome);
                    aux++;
                }

                var option = int.Parse(Console.ReadLine());

                Console.Clear();
                MostrarDados(option - 1);
                Console.ReadKey();
            }

            else
            {
                Console.Clear();
                Console.WriteLine("Não há clientes cadastrados!");
                Console.ReadKey();
            }
        }

        catch(Exception)
        {
            Console.Clear();
            Console.WriteLine("Opção Inválida");
        }
    }



    public static void ListarTodos()
    {
        Console.Clear();

        foreach (Cliente cliente in Clientes)
            MostrarDados(cliente.Id-1);

        Console.ReadKey();
    }


    public static void MostrarDados(int id)
    {

        Cliente cliente = Clientes[id];

        Console.WriteLine("==============================");

        Console.WriteLine("Nome:"+cliente.Nome);

        Console.WriteLine("Idade: "+cliente.Idade);

        Console.WriteLine("Altura: "+cliente.Altura);

        Console.WriteLine("Peso: "+cliente.Peso);

        Console.WriteLine("IMC: "+cliente.IMC);

        Console.WriteLine("Situação Atual: "+ ClassificacaoIMC(cliente.IMC));

        Console.WriteLine("==============================\n\n\n");

    }

    public static string ClassificacaoIMC(double imc)
    {
        string result = "";
        if (imc < 18.5)
            result = "ABAIXO DO PESO";
        if (imc > 18.5 && imc <= 24.9)
            result = "PESO NORMAL";
        else if (imc >= 25.0 && imc <= 29.9)
            result = "SOBREPESO";
        else if (imc > 30.0)
            result = "OBESIDADE";

        return result;
    }
}