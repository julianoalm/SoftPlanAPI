using Softplan.API2.Domain.Entities;

namespace Softplan.API2.Domain.Interfaces
{
    public interface IServiceCalculaJuros
    {
        CalculaJurosDTO CalculaJuros(CalculaJurosParametro param);
    }
}
