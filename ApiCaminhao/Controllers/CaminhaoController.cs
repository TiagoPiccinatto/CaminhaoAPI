using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Desafio.Context;
using Desafio.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Desafio.Repositorio;
using System.Globalization;
using System.Net;
using System.Web.WebPages;
using System.Web.Razor.Parser;
using Microsoft.AspNetCore.Server.IIS.Core;

namespace Desafio.Controllers
{
    [Route("api/[controller]")]
    
    public class CaminhaoController : Controller
    {
        private readonly ICaminhaoRepositorio ICaminhaoRepositorio;

        public CaminhaoController(ICaminhaoRepositorio CaminhaoInterface)
        {
            ICaminhaoRepositorio = CaminhaoInterface;
        }

        [HttpGet]
        public async Task<IEnumerable<CaminhaoModel>> BuscarCaminhao()
        {
            return await ICaminhaoRepositorio.Buscar();          
        }


        [HttpPost]
        public async Task<ActionResult<CaminhaoModel>> AdionarCaminhao(CaminhaoModel Caminhao)
        {
            
            try
            {
                var date = DateTime.Now;

                if (Caminhao.anoFabricacao == date.ToString("yyyy") && (Caminhao.anoModelo == date.ToString("yyyy") || Caminhao.anoModelo == date.AddYears(1).ToString("yyyy")))
                {
                    
                    await ICaminhaoRepositorio.Criar(Caminhao);



                    return Ok(Caminhao);
                    

                }
                else
                {
                    if (Caminhao.anoFabricacao != date.ToString("yyyy"))
                    {
                        
                        throw new Exception("Ano Digitado Nao e valido, Ano deve ser o atual");

                    }
                    else if (Caminhao.anoModelo != date.ToString("yyyy") || Caminhao.anoModelo == date.AddYears(1).ToString("yyyy"))
                    {

                        throw new Exception("Ano Digitado Nao e valido, Ano deve ser o atual ou subsequente");

                    }
                    throw new Exception("Digite um valor valido");

                }

            }
            catch (Exception e)
            {

                throw e;
            }

        }

        [HttpDelete("{id}")]

        public async Task<ActionResult> Apagar(int id)
        {
            if (id != 0)
            {
                var ApagarCaminhao = await ICaminhaoRepositorio.Buscar(id);
                await ICaminhaoRepositorio.Apagar(ApagarCaminhao.Id);
                return Content("Caminhao Deletado Com Sucesso");
            }

            throw new Exception("Passar uma Id Valida");
                                            
       
        }
        [HttpPut]
        public async Task<ActionResult> Atualizar(CaminhaoModel caminhao)
        {
            if (caminhao.Id != 0)
            {
                await ICaminhaoRepositorio.Atualizar(caminhao);

                return Content("Caminhao Atualizado Com Sucesso");
            }
            else throw new Exception("Id do Caminhao nao pode ser 0");

  
        }

    }
}