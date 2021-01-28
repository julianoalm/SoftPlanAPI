using Softplan.API1.Domain;
using Softplan.API1.Domain.Interfaces;

namespace Softplan.API1.Services
{
    public class TaxaJurosServices : IServiceTaxaJuros
    {
        //public readonly IRepositoryTaxaJuros _repo;

        #region Construtor

        //public TaxaJurosServices(IRepositoryTaxaJuros repo)
        public TaxaJurosServices()
        {
            //this._repo = repo;
        }

        #endregion

        #region Metodos

        public Juros GetTaxaJuros()
        {
            var padroes = new System.Globalization.CultureInfo("pt-BR");

            Juros taxaJuros = new Juros()
            {
                TaxaJuros =  "0,01"
            };

            return taxaJuros;
        }

        #endregion
    }
}
