internal partial class Program
{
    private static void Main(string[] args)
    {
        string continuar;
        Equipamento[] equipamentos = new Equipamento[100];

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

                do
                {
                    Console.Clear();
                    Console.WriteLine("---------------------------------");
                    Console.WriteLine("Gestão de Equipamentos");
                    Console.WriteLine("---------------------------------");
                    Console.WriteLine("Cadastrar do equipamento");
                    Console.WriteLine("---------------------------------");

                    Equipamento novoEquipamento = new Equipamento();

                    Console.Write("Digite o nome do equipamento: ");
                    novoEquipamento.nome = Console.ReadLine() ?? "";
                    if (string.IsNullOrEmpty(novoEquipamento.nome))
                    {
                        Console.WriteLine("O nome do equipamento é obrigatório.");
                        Console.WriteLine("Pressione qualquer tecla para continuar...");
                        Console.ReadKey();
                        return;
                    }
                    Console.Write("Digite o fabricante do equipamento: ");
                    novoEquipamento.fabricante = Console.ReadLine() ?? "";
                    if (string.IsNullOrEmpty(novoEquipamento.fabricante))
                    {
                        Console.WriteLine("O fabricante do equipamento é obrigatório.");
                        Console.WriteLine("Pressione qualquer tecla para continuar...");
                        Console.ReadKey();
                        return;
                    }
                    Console.Write("Digite o preço de aquisição do equipamento: ");
                    string precoAquisicaoInput = Console.ReadLine() ?? "";
                    if (!decimal.TryParse(precoAquisicaoInput, out novoEquipamento.precoAquisicao))
                    {
                        Console.WriteLine("O preço de aquisição do equipamento é inválido.");
                        Console.WriteLine("Pressione qualquer tecla para continuar...");
                        Console.ReadKey();
                        return;
                    }
                    Console.Write("Digite a data de fabricação do equipamento (dia/mês/ano): ");
                    string dataFabricacaoInput = Console.ReadLine() ?? "";
                    if (!DateTime.TryParse(dataFabricacaoInput, out novoEquipamento.detaFabricacao))
                    {
                        Console.WriteLine("A data de fabricação do equipamento é inválida.");
                        Console.WriteLine("Pressione qualquer tecla para continuar...");
                        Console.ReadKey();
                        return;
                    }

                    for (int i = 0; i < equipamentos.Length; i++)
                    {
                        if (equipamentos[i] == null)
                        {
                            equipamentos[i] = novoEquipamento;
                            break;
                        }
                    }

                    System.Console.WriteLine($"Equipamento cadastrado {novoEquipamento.nome} com sucesso!");
                    System.Console.WriteLine("Cadastrar outro equipamento? (S/N)");
                    continuar = Console.ReadLine()?.ToUpper() ?? "";
                } while (continuar == "S");

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