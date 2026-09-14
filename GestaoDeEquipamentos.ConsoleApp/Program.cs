using GestaoDeEquipamentos.ConsoleApp;

internal partial class Program
{
    private static void Main(string[] args)
    {
        Equipamento[] equipamento = new Equipamento[100];

        while (true)
        {
            Console.Clear();
            Console.WriteLine("---------------------------------");
            Console.WriteLine("Gestão de Equipamentos");
            Console.WriteLine("---------------------------------");
            Console.WriteLine("1 - Cadastrar equipamento");
            Console.WriteLine("2 - Editar equipamento");
            Console.WriteLine("3 - Excluir equipamento");
            Console.WriteLine("4 - Visualizar equipamentos");
            Console.WriteLine("S - Sair");
            Console.WriteLine("---------------------------------");
            Console.Write("> ");
            string? opcaoMenu = Console.ReadLine()?.ToUpper();

            if (opcaoMenu == "S")
            {
                Console.Clear();
                break;
            }

            if (opcaoMenu == "1")
            {
                Console.Clear();
                Console.WriteLine("---------------------------------");
                Console.WriteLine("Gestão de equipamentos");
                Console.WriteLine("---------------------------------");
                Console.WriteLine("Cadastro de equipamentos");
                Console.WriteLine("---------------------------------");

            }

            else if (opcaoMenu == "2")
            {

            }

            else if (opcaoMenu == "3")
            {

            }

            else if (opcaoMenu == "4")
            {

            }
        }
    }

}