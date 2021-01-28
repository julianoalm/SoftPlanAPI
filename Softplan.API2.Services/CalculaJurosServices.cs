using Newtonsoft.Json;
using Softplan.API2.Domain;
using Softplan.API2.Domain.Entities;
using Softplan.API2.Domain.Interfaces;
using System;
using System.Collections;
using System.Net.Http;

namespace Softplan.API2.Services
{
    public class CalculaJurosServices : IServiceCalculaJuros
    {
        //public readonly IRepositoryTaxaJuros _repo;
        HttpResponseMessage requisicao;
        string resposta;
        Juros taxaJuros;
        
        #region Construtor

        //public TaxaJurosServices(IRepositoryTaxaJuros repo)
        public CalculaJurosServices()
        {
            //this._repo = repo;
        }

        #endregion

        #region Metodos

        public CalculaJurosDTO CalculaJuros(CalculaJurosParametro param)
        {
            CalculaJurosDTO calculo;

            try
            {
                TaxaJuros();

                if (param.ValorInicial > 0 && param.Meses > 0)
                {
                    decimal valorCalculado = Pow(param.ValorInicial * (1 + Convert.ToDecimal(taxaJuros.TaxaJuros)), (uint)param.Meses);
                    calculo = new CalculaJurosDTO()
                    {
                        ValorFinal = Math.Truncate(100 * valorCalculado) / 100
                    };
                }
                else
                    throw new Exception("Os parâmetros ValorInicial e Meses são obrigatórios!");

                return calculo;
            }
            catch (Exception ex)
            {                
                throw new Exception(ex.Message);
            }
        }

        private async void TaxaJuros()
        {
            using var client = new HttpClient
            {
                BaseAddress = new System.Uri("http://localhost:65460")
            };

            requisicao = client.GetAsync($"/api/taxajuros/").Result;
            resposta = await requisicao.Content.ReadAsStringAsync();

            taxaJuros = JsonConvert.DeserializeObject<Juros>(resposta);
        }

        public static decimal Pow(decimal x, uint y)
        {
            decimal A = 1m;
            BitArray e = new BitArray(BitConverter.GetBytes(y));
            int t = e.Count;

            for (int i = t - 1; i >= 0; --i)
            {
                A *= A;
                if (e[i] == true)
                {
                    A *= x;
                }
            }
            return A;
        }

        #endregion
    }
}
