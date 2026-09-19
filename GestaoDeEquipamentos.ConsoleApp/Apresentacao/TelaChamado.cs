namespace GestaoDeEquipamentos.ConsoleApp.Apresentacao
{
    public class TelaChamado
    {

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

        }

        public void Editar()
        {

        }

        public void Excluir()
        {

        }

        public void VisualizarTodos()
        {

        }
    }
}