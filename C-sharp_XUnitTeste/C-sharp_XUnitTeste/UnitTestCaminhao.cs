using Desafio.Controllers;
using Desafio.Models;
using Desafio.Repositorio;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Newtonsoft.Json;

namespace C_sharp_XUnitTeste
{
    public class UnitTestCaminhao
    {
        private Mock<ICaminhaoRepositorio> _CaminhaoRepositorioMock;

        CaminhaoController _caminhaoController;

        CaminhaoModel _caminhao;

        public UnitTestCaminhao()
        {
            _CaminhaoRepositorioMock = new Mock<ICaminhaoRepositorio>();

            _caminhaoController = new CaminhaoController(_CaminhaoRepositorioMock.Object);

            _caminhao = new CaminhaoModel();
        }
        [Fact]
        public void BuscarCaminhao()
        {
            var retorno = _caminhaoController.BuscarCaminhao();
            Assert.NotNull(retorno);
        }

        [Fact]
        public void DeletarCaminhao()
        {
            var retorno = _caminhaoController.Apagar(20);
            Assert.NotNull(retorno);
        }
        [Fact]
        public void DeveDarErroDeletarCaminhao()
        {
            var retorno = _caminhaoController.Apagar(0);
            var retornoException = retorno.Exception.InnerException.Message.ToString();
            Assert.Equal("Passar uma Id Valida", retornoException);
        }
        [Fact]
        public void DeveDarErroAnoCriarUmCaminhao()
        {

            var retorno = _caminhaoController.AdionarCaminhao(_caminhao);
            var retornoException = retorno.Exception.InnerException.Message.ToString();


            Assert.Equal("Ano Digitado Nao e valido, Ano deve ser o atual", retornoException);
        }
        [Fact]
        public void DeveDarErroAnoSubCriarUmCaminhao()
        {
            CaminhaoModel caminhao = new CaminhaoModel();
            caminhao.Id = 1;
            caminhao.anoFabricacao = "2022";
            caminhao.anoModelo = "2024";

            var retorno = _caminhaoController.AdionarCaminhao(caminhao);
            var retornoException = retorno.Exception.InnerException.Message.ToString();


            Assert.Equal("Ano Digitado Nao e valido, Ano deve ser o atual ou subsequente", retornoException);
        }
        [Fact]
        public void DeveDarErroAtualizarCaminhao()
        {
            CaminhaoModel caminhao = new CaminhaoModel();
            caminhao.Id = 0;
            caminhao.anoFabricacao = "2022";
            caminhao.anoModelo = "2023";

            var retorno = _caminhaoController.Atualizar(caminhao);
            var retornoException = retorno.Exception.InnerException.Message.ToString();


            Assert.Equal("Id do Caminhao nao pode ser 0", retornoException);

        }



    }
}