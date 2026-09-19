using System.Security.Cryptography;
using GestaoDeEquipamentos.ConsoleApp.Dominio;

namespace GestaoDeEquipamentos.ConsoleApp.Apresentacao;

public class TelaEquipamento
{
    public string TelaEquipamentoMenu()
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

        return opcaoMenu!;
    }

    public void Cadastrar(Equipamento?[] equipamentos)
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

        novoEquipamento.Id = Convert.ToHexString(RandomNumberGenerator.GetBytes(20)).ToLower().Substring(0, 7);

        for (int i = 0; i < equipamentos.Length; i++)
        {
            Equipamento? e = equipamentos[i];

            if (e == null)
            {
                equipamentos[i] = novoEquipamento;
                break;
            }
        }

        Console.WriteLine("---------------------------------");
        Console.WriteLine($"O registro {novoEquipamento.Nome} foi cadastrardo");
        Console.WriteLine("---------------------------------");
        Console.WriteLine("ENTER para continuar...");
        Console.ReadLine();
    }

    public void Editar(Equipamento[] equipamentos)
    {
        Console.WriteLine("---------------------------------");
        Console.WriteLine("Gestão de equipamentos");
        Console.WriteLine("---------------------------------");
        Console.WriteLine("Editar equipamento");
        Console.WriteLine("---------------------------------");


        Console.WriteLine("{0, -7} | {1, -15} | {2, -15} | {3, -22} | {4, -10}",
                            "Id", "Nome", "Fabricanrte", "Preço Equipamento", "Data de fabricação");

        for (int i = 0; i < equipamentos.Length; i++)
        {
            Equipamento e = equipamentos[i];

            if (e == null)
                continue;

            Console.WriteLine("{0, -7} | {1, -15} | {2, -15} | {3, -22} | {4, -10}",
                                e.Id, e.Nome, e.Fabricante, e.ValorEquipamento.ToString("C2"), e.DataFabricacao.ToShortDateString());
        }



        // Selecaõ do Equipamento
        string? idSelecionado;

        do
        {
            System.Console.WriteLine("Qual o \"Id\" do equipamento:");
            idSelecionado = Convert.ToString(Console.ReadLine());

            if (!string.IsNullOrWhiteSpace(idSelecionado) && idSelecionado.Length == 7)
                break;

        } while (true);

        Console.WriteLine("---------------------------------");
        Console.WriteLine($"O Id selecionado {idSelecionado}");
        Console.WriteLine("---------------------------------");
        Console.WriteLine("ENTER para continuar...");
        Console.ReadLine();


        Equipamento? equipamentoSelecionado = null;

        for (int i = 0; i < equipamentos.Length; i++)
        {
            Equipamento e = equipamentos[i];

            if (e == null)
                continue;

            if (e.Id == idSelecionado)
            {
                equipamentoSelecionado = e;
                break;
            }
        }


        if (equipamentoSelecionado == null)
        {
            Console.WriteLine("---------------------------------");
            Console.WriteLine($"O Id selecionado {idSelecionado} não foi encontrado");
            Console.WriteLine("---------------------------------");
            Console.WriteLine("ENTER para continuar...");
            Console.ReadLine();
            return;
        }


        // Edição do equipamento
        Equipamento EditarEquipamento = new Equipamento();

        do
        {
            System.Console.WriteLine("Digite o nome do equipamento");
            EditarEquipamento.Nome = Console.ReadLine();

            if (!string.IsNullOrWhiteSpace(EditarEquipamento.Nome) &&
                EditarEquipamento.Nome.Length > 3)
            {
                break;
            }

        } while (true);

        do
        {
            System.Console.WriteLine("Digite o nome do fabricante");
            EditarEquipamento.Fabricante = Console.ReadLine();

            if (!string.IsNullOrWhiteSpace(EditarEquipamento.Fabricante) &&
                EditarEquipamento.Fabricante.Length > 2)
            {
                break;
            }

        } while (true);

        System.Console.WriteLine("Digite o preço do equipamento");
        EditarEquipamento.ValorEquipamento = Convert.ToDecimal(Console.ReadLine());

        System.Console.WriteLine("Digite a data de fabricação");
        EditarEquipamento.DataFabricacao = Convert.ToDateTime(Console.ReadLine());


        equipamentoSelecionado.Nome = EditarEquipamento.Nome;
        equipamentoSelecionado.Fabricante = EditarEquipamento.Fabricante;
        equipamentoSelecionado.ValorEquipamento = EditarEquipamento.ValorEquipamento;
        equipamentoSelecionado.DataFabricacao = EditarEquipamento.DataFabricacao;
    }

    internal void Excluir(Equipamento[] equipamentos)
    {
        // Exibçãod e equipamentos
        Console.WriteLine("---------------------------------");
        Console.WriteLine("Gestão de equipamentos");
        Console.WriteLine("---------------------------------");
        Console.WriteLine("Exclusao de equipamento");
        Console.WriteLine("---------------------------------");


        Console.WriteLine("{0, -7} | {1, -15} | {2, -15} | {3, -22} | {4, -10}",
                            "Id", "Nome", "Fabricanrte", "Preço Equipamento", "Data de fabricação");

        for (int i = 0; i < equipamentos.Length; i++)
        {
            Equipamento e = equipamentos[i];

            if (e == null)
                continue;

            Console.WriteLine("{0, -7} | {1, -15} | {2, -15} | {3, -22} | {4, -10}",
                                e.Id, e.Nome, e.Fabricante, e.ValorEquipamento.ToString("C2"), e.DataFabricacao.ToShortDateString());
        }


        // Selecao de Id
        string? idSelecionado;

        do
        {
            System.Console.WriteLine("Qual o \"Id\" do equipamento:");
            idSelecionado = Convert.ToString(Console.ReadLine());

            if (!string.IsNullOrWhiteSpace(idSelecionado) && idSelecionado.Length == 7)
                break;

        } while (true);

        Console.WriteLine("---------------------------------");
        Console.WriteLine($"O Id selecionado {idSelecionado}");
        Console.WriteLine("---------------------------------");
        Console.WriteLine("ENTER para continuar...");
        Console.ReadLine();


        var result = false;

        for (int i = 0; i < equipamentos.Length; i++)
        {
            Equipamento e = equipamentos[i];

            if (e == null)
                continue;

            if (e.Id == idSelecionado)
            {
                equipamentos[i] = null;
                result = true;
                break;
            }
        }

        if (result == true)
        {
            System.Console.WriteLine("Equipamento Excluido");
            System.Console.WriteLine("ENTER para continuar...");
            Console.ReadLine();
        }
        else if (result == false)
        {
            System.Console.WriteLine("Id não encontrado");
            System.Console.WriteLine("ENTER para continuar...");
            Console.ReadLine();
        }
    }

    internal void Visualizar(Equipamento[] equipamentos)
    {
        Console.WriteLine("---------------------------------");
        Console.WriteLine("Gestão de equipamentos");
        Console.WriteLine("---------------------------------");
        Console.WriteLine("Visualisar equipamentos");
        Console.WriteLine("---------------------------------");


        Console.WriteLine("{0, -7} | {1, -15} | {2, -15} | {3, -22} | {4, -10}",
                            "Id", "Nome", "Fabricanrte", "Preço Equipamento", "Data de fabricação");

        for (int i = 0; i < equipamentos.Length; i++)
        {
            Equipamento e = equipamentos[i];

            if (e == null)
                continue;

            Console.WriteLine("{0, -7} | {1, -15} | {2, -15} | {3, -22} | {4, -10}",
                                e.Id, e.Nome, e.Fabricante, e.ValorEquipamento.ToString("C2"), e.DataFabricacao.ToShortDateString());
        }

        System.Console.WriteLine("ENTER para continuar...");
        Console.ReadLine();
    }
}