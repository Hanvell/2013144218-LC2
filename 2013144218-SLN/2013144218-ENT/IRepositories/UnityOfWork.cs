using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2013144218_ENT.IRepositories
{
    public interface UnityOfWork : IDisposable
    {

        IATMRepository ATM { get; }
        IBaseDatosRepository BaseDatos { get; }
        ICuentaRepository Cuenta { get; }
        IPantallaRepository Pantalla { get; }
        IRanuraDepositoRepository RanuraDeposito { get; }
        IRetiroRepository Retiro { get; }
        ITecladoRepository Teclado { get; }

        int SaveChanges();
    }
}
