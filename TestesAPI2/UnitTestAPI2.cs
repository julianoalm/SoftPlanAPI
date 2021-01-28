using Moq;
using Softplan.API2.Domain;
using Softplan.API2.Domain.Entities;
using Softplan.API2.Domain.Interfaces;
using Softplan.API2.Services;
using System;
using System.ComponentModel;
using Xunit;

namespace TestesAPI2
{
    public class UnitTestAPI2
    {
        [Fact]
        [Trait("Teste Unitario CalculaJuros", "API2")]
        [Description("Teste do m�todo CalculaJuros")]
        public void CalculaJuros()
        {
            CalculaJurosParametro taxaJuros = new CalculaJurosParametro()
            {
                ValorInicial = 100,
                Meses = 5
            };

            CalculaJurosDTO retorno = new CalculaJurosDTO()
            {
                ValorFinal = 10510100501
            };

            CalculaJurosServices objCalculaJuros = new CalculaJurosServices();

            Assert.Equal(retorno.ValorFinal, objCalculaJuros.CalculaJuros(taxaJuros).ValorFinal);
        }

        [Fact]
        [Trait("Teste Unitario CalculaJuros", "API2")]
        [Description("Teste do m�todo CalculaJuros com par�metro valorInicial null")]
        public void CalculaJurosParametroValorInicialNulo()
        {
            CalculaJurosParametro taxaJuros = new CalculaJurosParametro()
            {
                Meses = 5
            };

            CalculaJurosServices objCalculaJuros = new CalculaJurosServices();

           Assert.Throws<Exception>(() => objCalculaJuros.CalculaJuros(taxaJuros));
        }

        [Fact]
        [Trait("Teste Unitario CalculaJuros", "API2")]
        [Description("Teste do m�todo CalculaJuros com par�metro Meses null")]
        public void CalculaJurosParametroMesesNulo()
        {
            CalculaJurosParametro taxaJuros = new CalculaJurosParametro()
            {
                ValorInicial = 100                
            };

            CalculaJurosServices objCalculaJuros = new CalculaJurosServices();

            Assert.Throws<Exception>(() => objCalculaJuros.CalculaJuros(taxaJuros));
        }

        [Fact]
        [Trait("Teste Unitario CalculaJuros", "API2")]
        [Description("Teste do m�todo ValidaTipoGetCalculaJuros")]
        public void ValidaTipoGetCalculaJuros()
        {
            CalculaJurosParametro taxaJuros = new CalculaJurosParametro()
            {
                ValorInicial = 100,
                Meses = 5
            };

            CalculaJurosServices objCalculaJuros = new CalculaJurosServices();

            Assert.IsType<CalculaJurosDTO>(objCalculaJuros.CalculaJuros(taxaJuros));
        }

        [Fact]
        [Trait("Teste Unitario GetTaxaJuros, exemplo com Moq", "API2")]
        [Description("Teste utilizando Moq devido ao metodo GetTaxaJuros n�o estar pronto")]
        public void GetTaxaJurosComMoq()
        {
            var calculo = new Mock<IServiceCalculaJuros>(MockBehavior.Strict);

            CalculaJurosParametro taxaJuros = new CalculaJurosParametro()
            {
                ValorInicial = 100,
                Meses = 5
            };

            CalculaJurosDTO retorno = new CalculaJurosDTO()
            {
                ValorFinal = 10510100501
            };

            calculo.Setup(w => w.CalculaJuros(taxaJuros)).Returns(() => retorno);

            Assert.Equal<CalculaJurosDTO>(retorno, calculo.Object.CalculaJuros(taxaJuros));
        }
    }
}
