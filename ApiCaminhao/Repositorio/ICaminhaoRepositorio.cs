using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Desafio.Models;

namespace Desafio.Repositorio
{
    public interface ICaminhaoRepositorio
    {
        Task<IEnumerable<CaminhaoModel>> Buscar();

        Task<CaminhaoModel> Buscar(int id);

        Task<CaminhaoModel> Criar(CaminhaoModel Caminhao);

        Task Atualizar(CaminhaoModel Caminhao);

        Task Apagar(int id);
    }
}