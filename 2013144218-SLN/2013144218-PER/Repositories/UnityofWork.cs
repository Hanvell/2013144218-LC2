using _2013144218_ENT.IRepositories;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2013144218_PER.Repositories
{
    class UnityOfWork:IUnityOfWork
    {
        public  IATMRepository ATM { get; private set; }
        public IBaseDatosRepository BaseDatos { get; private set; }
        public ICuentaRepository Cuenta { get; private set; }
        public IPantallaRepository Pantalla { get; private set; }
        public IRanuraDepositoRepository RanuraDeposito { get; private set; }
        public IRetiroRepository Retiro { get; private set; }
        public ITecladoRepository Teclado { get; private set; }

        private _2013144218_SLNDbContext _Context;
        private static  UnityOfWork _Instance;
        private static readonly object _Lock = new object();
        private UnityOfWork() {

            // SE CRA UN UNICO CONTESTO DE BD
            // PARA APUNTAR A LOS REPOSITORIOS ALA MISMA BASE DE DATOS
            _Context = new _2013144218_SLNDbContext();

            ATM = new ATMRepository(_Context);
            BaseDatos = new BaseDatosRepository(_Context);
            Cuenta = new CuentaRepository(_Context);
            Pantalla = new PantallaRepository(_Context);
            RanuraDeposito = new RanuraDepositoRepository(_Context);
            Retiro = new RetiroRepository(_Context);
            Teclado = new TecladoRepository(_Context);
           

        }


        public static UnityOfWork Instance
        {

            get {
                lock (_Lock)
                {
                    if (_Instance == null)
                        _Instance = new UnityOfWork();
                }
                return _Instance;
                }
        }

        public int SaveChanges()
        {
            return _Context.SaveChanges();
        }

        public void Dispose()
        {
            _Context.Dispose();
        }
    }
}
