using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Desafio.Models;
using Desafio.Context;
using Microsoft.EntityFrameworkCore;

namespace Desafio.Repositorio
{
    public class CaminhaoRepositorio : ICaminhaoRepositorio
    {
        private readonly CaminhaoContext _CaminhaoContext;

        public CaminhaoRepositorio (CaminhaoContext caminhaoContext)
        {
           _CaminhaoContext = caminhaoContext;
        }

        public CaminhaoRepositorio()
        {
        }

        public async Task<CaminhaoModel> Criar(CaminhaoModel Caminhao)
        {
            _CaminhaoContext.Caminhoes.Add(Caminhao);

            await _CaminhaoContext.SaveChangesAsync();

            return Caminhao;
        }


        public async Task<IEnumerable<CaminhaoModel>> Buscar()
        {

            var retorno = await _CaminhaoContext.Caminhoes.ToListAsync();

            if (retorno.Any())
            {
                return retorno;
            }
            else throw new Exception("Nao Existe Caminhoes Cadastrados");
                
            
        }
        public async Task Atualizar(CaminhaoModel Caminhao)
        {
            _CaminhaoContext.Entry(Caminhao).State = EntityState.Modified;
            await _CaminhaoContext.SaveChangesAsync();
        }
        public async Task Apagar(int id)
        {
            var apagarcaminhao = await _CaminhaoContext.Caminhoes.FindAsync(id);
            _CaminhaoContext.Caminhoes.Remove(apagarcaminhao);
            await _CaminhaoContext.SaveChangesAsync();
        }

        public async Task<CaminhaoModel> Buscar(int id)
        {
            return await _CaminhaoContext.Caminhoes.FindAsync(id);
        }

    }
}