using Moq;
using Softplan.API1.Domain;
using Softplan.API1.Domain.Interfaces;
using Softplan.API1.Services;
using System;
using System.ComponentModel;
using Xunit;

namespace TestesAPI1
{
    public class UnitTestAPI1
    {
        [Fact]
        [Trait("Teste Unitario GetTaxaJuros", "API1")]
        [Description("Teste do método GetTaxaJuros")]
        public void RetornarGetTaxaJuros()
        {
            Juros taxaJuros = new Juros()
            {
                TaxaJuros = "0,01"
            };

            TaxaJurosServices objGetTaxaJuros = new TaxaJurosServices();

            Assert.Equal(taxaJuros.TaxaJuros, objGetTaxaJuros.GetTaxaJuros().TaxaJuros);
        }

        [Fact]
        [Trait("Teste Unitario GetTaxaJuros", "API1")]
        [Description("Teste do método GetTaxaJuros")]
        public void ValidaTipoGetTaxaJuros()
        {
            Juros taxaJuros = new Juros()
            {
                TaxaJuros = "0,01"
            };

            TaxaJurosServices objGetTaxaJuros = new TaxaJurosServices();

            Assert.IsType<Juros>(objGetTaxaJuros.GetTaxaJuros());
        }

        [Fact]
        [Trait("Teste Unitario GetTaxaJuros, exemplo com Moq", "API1")]
        [Description("Teste utilizando Moq devido ao metodo GetTaxaJuros não estar pronto")]
        public void GetTaxaJurosComMoq()
        {
            var juros = new Mock<IServiceTaxaJuros>(MockBehavior.Strict);

            Juros taxaJuros = new Juros()
            {
                TaxaJuros = "0,01"
            };

            juros.Setup(w => w.GetTaxaJuros()).Returns(() => taxaJuros);

            Assert.Equal<Juros>(taxaJuros, juros.Object.GetTaxaJuros());
        }
    }
}
