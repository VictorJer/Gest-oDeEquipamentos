using System.Security.Cryptography;
using GestaoDeEquipamentos.ConsoleApp.Dominio;

namespace GestaoDeEquipamentos.ConsoleApp.Infraestrutura;

public class RepositorioChamado
{
    public Chamado[] chamados = new Chamado[100];

    public void Cadastra(Chamado novoChamado)
    {
        novoChamado.Id = Convert.ToHexString(RandomNumberGenerator.GetBytes(20)).ToLower().Substring(0, 7);

        for (int i = 0; i < chamados.Length; i++)
        {
            Chamado? e = chamados[i];

            if (e == null)
            {
                chamados[i] = novoChamado;
                break;
            }
        }
    }

    internal bool Editar(string idSelecionado, Chamado novoChamado)
    {
        Chamado chamado = SelecionarPorId(idSelecionado);

        if (chamado == null)
        {
            return false;
        }

        chamado.Titulo = novoChamado.Titulo;
        chamado.Descricao = novoChamado.Descricao;
        chamado.DataAbertura = novoChamado.DataAbertura;
        chamado.equipamento = novoChamado.equipamento;

        return true;
    }

    public bool Excluir(string? idSelecionado)
    {
        for (int i = 0; i < chamados.Length; i++)
        {
            Chamado? c = chamados[i];

            if (c.Id == idSelecionado)
            {
                chamados[i] = null;
                return true;
            }
        }

        return false;
    }

    public Chamado SelecionarPorId(string idSelecionado)
    {
        Chamado? chamadoSelecionado = null;

        for (int i = 0; i < chamados.Length; i++)
        {
            Chamado c = chamados[i];

            if (c == null)
            {
                continue;
            }

            if (c.Id == idSelecionado)
            {
                chamadoSelecionado = c;
                break;
            }
        }

        return chamadoSelecionado;
    }

    public Chamado[] SelecionarTodos()
    {
        return chamados;
    }


}