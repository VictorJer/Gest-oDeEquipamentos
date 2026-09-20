using System.Reflection.Metadata;
using GestaoDeEquipamentos.ConsoleApp.Dominio;
using GestaoDeEquipamentos.ConsoleApp.Infraestrutura;

namespace GestaoDeEquipamentos.ConsoleApp.Apresentacao
{
    public class TelaChamado
    {
        public RepositorioChamado? repositorioChamado;
        public RepositorioEquipamento? repositorioEquipamento;
        public string? TelaEquipamentoMenu()
        {
            Console.Clear();
            Console.WriteLine("---------------------------------");
            Console.WriteLine("Gestão de Chamados");
            Console.WriteLine("---------------------------------");
            Console.WriteLine("1 - Cadastrar chamado");
            Console.WriteLine("2 - Editar chamado");
            Console.WriteLine("3 - Excluir chamado");
            Console.WriteLine("4 - Visualizar chamados");
            Console.WriteLine("S - Sair");
            Console.WriteLine("---------------------------------");
            Console.Write("> ");
            string? opcaoMenu = Console.ReadLine()?.ToUpper();

            return opcaoMenu!;
        }

        public void Cadastrar()
        {
            Equipamento?[] equipamentos = repositorioEquipamento.SelecionarTodos();

            Console.WriteLine("---------------------------------");
            Console.WriteLine("Gestão de Chamados");
            Console.WriteLine("---------------------------------");
            Console.WriteLine("Cadastrar chamado");
            Console.WriteLine("---------------------------------");

            Chamado novoChamado = new Chamado();

            while (true)
            {
                System.Console.WriteLine("Titulo do chamado:");
                novoChamado.Titulo = Console.ReadLine()!;

                if (!string.IsNullOrWhiteSpace(novoChamado.Titulo) && novoChamado.Titulo.Length is < 100 and > 2)
                {
                    break;
                }
            }

            while (true)
            {
                System.Console.WriteLine("Descrição do chamado:");
                novoChamado.Descricao = Console.ReadLine()!;

                if (!string.IsNullOrWhiteSpace(novoChamado.Descricao) && novoChamado.Descricao.Length is < 100 and > 2)
                {
                    break;
                }
            }


            Console.WriteLine("{0, -7} | {1, -15} | {2, -15} | {3, -22} | {4, -10}",
                                "Id", "Nome", "Fabricanrte", "Preço Equipamento", "Data de fabricação");

            for (int i = 0; i < equipamentos.Length; i++)
            {
                Equipamento? e = equipamentos[i];

                if (e == null)
                    continue;

                Console.WriteLine("{0, -7} | {1, -15} | {2, -15} | {3, -22} | {4, -10}",
                                    e.Id, e.Nome, e.Fabricante, e.ValorEquipamento.ToString("C2"), e.DataFabricacao.ToShortDateString());
            }

            string? idSelecionado;
            do
            {
                System.Console.WriteLine("Qual o \"Id\" do equipamento:");
                idSelecionado = Convert.ToString(Console.ReadLine());

                if (!string.IsNullOrWhiteSpace(idSelecionado) && idSelecionado.Length == 7)
                    break;

            } while (true);

            Equipamento equipamentoSelecionado = repositorioEquipamento
                                                    .SelecionarEquipamentoPorId(idSelecionado);

            if (equipamentoSelecionado == null)
            {
                System.Console.WriteLine("equipamento não encontrado");
                System.Console.WriteLine("ENTER para continuar...");
                Console.ReadLine();
                return;
            }

            novoChamado.DataAbertura = DateTime.Now;
            novoChamado.equipamento = equipamentoSelecionado;

            repositorioChamado.Cadastra(novoChamado);

            System.Console.WriteLine("chamado cadastrado");
            Console.ReadLine();

        }

        public void Editar()
        {
            Equipamento?[] equipamentos = repositorioEquipamento.SelecionarTodos();

            Console.WriteLine("---------------------------------");
            Console.WriteLine("Gestão de equipamentos");
            Console.WriteLine("---------------------------------");
            Console.WriteLine("Editar Chamados");
            Console.WriteLine("---------------------------------");

            VisualizarTodos(false);
            System.Console.WriteLine("qual o Id do chamado;");
            var idSelecionado = Console.ReadLine();

            Chamado novoChamado = new Chamado();

            while (true)
            {
                System.Console.WriteLine("Titulo do chamado:");
                novoChamado.Titulo = Console.ReadLine()!;

                if (!string.IsNullOrWhiteSpace(novoChamado.Titulo) && novoChamado.Titulo.Length is < 100 and > 2)
                {
                    break;
                }
            }

            while (true)
            {
                System.Console.WriteLine("Descrição do chamado:");
                novoChamado.Descricao = Console.ReadLine()!;

                if (!string.IsNullOrWhiteSpace(novoChamado.Descricao) && novoChamado.Descricao.Length is < 100 and > 2)
                {
                    break;
                }
            }

            Console.WriteLine("{0, -7} | {1, -15} | {2, -15} | {3, -22} | {4, -10}",
                    "Id", "Nome", "Fabricanrte", "Preço Equipamento", "Data de fabricação");

            for (int i = 0; i < equipamentos.Length; i++)
            {
                Equipamento? e = equipamentos[i];

                if (e == null)
                    continue;

                Console.WriteLine("{0, -7} | {1, -15} | {2, -15} | {3, -22} | {4, -10}",
                                    e.Id, e.Nome, e.Fabricante, e.ValorEquipamento.ToString("C2"), e.DataFabricacao.ToShortDateString());
            }

            string? idEquipamentoSelecionado;
            do
            {
                System.Console.WriteLine("Qual o \"Id\" do equipamento:");
                idEquipamentoSelecionado = Convert.ToString(Console.ReadLine());

                if (!string.IsNullOrWhiteSpace(idSelecionado) && idSelecionado.Length == 7)
                    break;

            } while (true);

            Equipamento equipamentoSelecionado = repositorioEquipamento
                                                    .SelecionarEquipamentoPorId(idEquipamentoSelecionado);

            novoChamado.equipamento = equipamentoSelecionado;

            var result = repositorioChamado.Editar(idSelecionado, novoChamado);

            if (result)
            {
                System.Console.WriteLine("chamado editado");
                System.Console.WriteLine("ENTER para continuar");
                Console.ReadLine();
                return;
            }

            if (result)
            {
                System.Console.WriteLine("não foi editado");
                System.Console.WriteLine("ENTER para continuar");
                Console.ReadLine();
                return;
            }

        }

        public void Excluir()
        {
            Console.WriteLine("---------------------------------");
            Console.WriteLine("Gestão de equipamentos");
            Console.WriteLine("---------------------------------");
            Console.WriteLine("Excluir Chamados");
            Console.WriteLine("---------------------------------");

            VisualizarTodos(false);
            System.Console.WriteLine("qual o Id do chamado;");
            var idSelecionado = Console.ReadLine();

            var result = repositorioChamado.Excluir(idSelecionado);

            if (result)
            {
                System.Console.WriteLine("chamado excluido");
                System.Console.WriteLine("ENTER para continuar");
                Console.ReadLine();
                return;
            }
            else
            {
                System.Console.WriteLine("não foi excluido");
                System.Console.WriteLine("ENTER para continuar");
                Console.ReadLine();
                return;
            }
        }

        public void VisualizarTodos(bool mostrarTela)
        {
            Chamado?[] chamados = repositorioChamado.SelecionarTodos();


            if (mostrarTela)
            {
                Console.WriteLine("---------------------------------");
                Console.WriteLine("Gestão de equipamentos");
                Console.WriteLine("---------------------------------");
                Console.WriteLine("Visualisar Chamados");
                Console.WriteLine("---------------------------------");
            }

            Console.WriteLine("{0, -7} | {1, -15} | {2, -15} | {3, -22} | {4, -10}",
                           "Id", "titulo", "Descrição", "Data Abertura", "Nome equipamento");

            for (int i = 0; i < chamados.Length; i++)
            {
                Chamado? e = chamados[i];

                if (e == null)
                    continue;

                Console.WriteLine("{0, -7} | {1, -15} | {2, -15} | {3, -22} | {4, -10}",
                                    e.Id, e.Titulo, e.Descricao, e.DataAbertura.ToShortDateString(), e.equipamento.Nome);
            }

            System.Console.WriteLine("ENTER para continuar...");
            Console.ReadLine();
        }
    }
}