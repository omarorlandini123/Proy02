using Entidades;
using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicAccess
{
    public class LogicSede
    {
        
        public List<Sede> getSedes() {
            DAOSede dao= new DAOSede();
            return dao.getSedes();
        }

        public Boolean insertarSede(Sede sede) {
            DAOSede dao = new DAOSede();
            return dao.insertarSede(sede);
        }

        public Sede buscarSede(Sede sede) {
            DAOSede dao = new DAOSede();
            return dao.buscarSede(sede);
        }

    }
}
