using System.Runtime.ConstrainedExecution;
using System.Security.Cryptography;
using GestaoDeEquipamentos.ConsoleApp.Apresentacao;
using GestaoDeEquipamentos.ConsoleApp.Dominio;

internal partial class Program
{
    private static void Main(string[] args)
    {
        TelaEquipamento telaEquipamento = new TelaEquipamento();
        TelaChamado telaChamado = new TelaChamado();


        while (true)
        {
            Console.Clear();
            Console.WriteLine("---------------------------------");
            Console.WriteLine("Gestão de Chamados");
            Console.WriteLine("---------------------------------");
            Console.WriteLine("1 - Gerenciar equipamentos");
            Console.WriteLine("2 - Gerenciar Chamados");
            Console.WriteLine("S - Sair");
            Console.WriteLine("---------------------------------");
            Console.Write("> ");
            string? opcaoMenuPrincipal = Console.ReadLine()?.ToUpper();

            if (opcaoMenuPrincipal == "1")
            {
                var opcaoMenuEquipamento = telaEquipamento.TelaEquipamentoMenu();

                if (opcaoMenuEquipamento == "S")
                {
                    Console.Clear();
                    break;
                }

                if (opcaoMenuEquipamento == "1")
                {
                    telaEquipamento.Cadastrar();
                }

                else if (opcaoMenuEquipamento == "2")
                {
                    telaEquipamento.Editar();
                }

                else if (opcaoMenuEquipamento == "3")
                {
                    telaEquipamento.Excluir();
                }

                else if (opcaoMenuEquipamento == "4")
                {
                    telaEquipamento.Visualizar();
                }
            }

            else if (opcaoMenuPrincipal == "2")
            {
                var opcaoMenuChamado = telaChamado.TelaEquipamentoMenu();


                if (opcaoMenuChamado == "S")
                {
                    Console.Clear();
                    break;
                }

                if (opcaoMenuChamado == "1")
                {
                    telaChamado.Cadastrar();
                }

                else if (opcaoMenuChamado == "2")
                {
                    telaChamado.Editar();
                }

                else if (opcaoMenuChamado == "3")
                {
                    telaChamado.Excluir();
                }

                else if (opcaoMenuChamado == "4")
                {
                    telaChamado.VisualizarTodos();
                }

            }
        }
    }

}