using _2013144218_ENT.Entidades;
using _2013144218_ENT.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2013144218_PER.Repositories
{
    public class RetiroRepository : Repository<Retiro>, IRetiroRepository
    {
        public IEnumerable<Retiro> getRetiroxATM(ATM ATM)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Retiro> getRetiroxBasedeDatos(BaseDatos BaseDatos)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Retiro> getRetiroxDispensador(DispensadorEfectivo DispensadorEfectivo)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Retiro> getRetiroxPantalla(Pantalla Pantalla)
        {
            throw new NotImplementedException();
        }
    }
}
