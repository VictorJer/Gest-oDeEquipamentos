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

                Equipamento novoEquipamento = new Equipamento();

                do
                {
                    System.Console.WriteLine("Digite o nome do equipamento");
                    novoEquipamento.Nome = Console.ReadLine();

                    if (!string.IsNullOrWhiteSpace(novoEquipamento.Nome) &&
                        novoEquipamento.Nome.Length > 3)
                    {
                        break;
                    }

                } while (true);

                do
                {
                    System.Console.WriteLine("Digite o nome do fabricante");
                    novoEquipamento.Fabricante = Console.ReadLine();

                    if (!string.IsNullOrWhiteSpace(novoEquipamento.Fabricante) &&
                        novoEquipamento.Fabricante.Length > 2)
                    {
                        break;
                    }

                } while (true);

                System.Console.WriteLine("Digite o preço do equipamento");
                novoEquipamento.ValorEquipamento = Convert.ToDecimal(Console.ReadLine());

                System.Console.WriteLine("Digite a data de fabricação");
                novoEquipamento.DataFabricacao = Convert.ToDateTime(Console.ReadLine());

                for (int i = 0; i < equipamento.Length; i++)
                {
                    Equipamento? e = equipamento[i];

                    if (e == null)
                    {
                        equipamento[i] = novoEquipamento;
                        break;
                    }
                }

                Console.WriteLine("---------------------------------");
                Console.WriteLine($"O registro {novoEquipamento.Nome} foi cadastrardo");
                Console.WriteLine("---------------------------------");
                Console.WriteLine("ENTER para continuar...");
                Console.ReadLine();

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