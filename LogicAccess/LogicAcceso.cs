using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;
using DataAccess;
namespace LogicAccess
{
    public class LogicAcceso
    {
        public Usuario Login(string usuario,string password)
        {
            DAOAcceso dao = new DAOAcceso();
            return dao.Login(usuario,password);
        }

        public List<Perfil> getPerfiles() {
            DAOAcceso dao = new DAOAcceso();
            return dao.getPerfiles();
        }

        public List<Acceso> getAccesosDePerfil(int idPerfil) {
            DAOAcceso dao = new DAOAcceso();
            return dao.getAccesos(idPerfil);
        }

        public List<Acceso> getAccesos()
        {
            DAOAcceso dao = new DAOAcceso();
            return dao.getAccesos();
        }

        public int crearPrefil(string nombre, string codPerfil)
        {
            DAOAcceso dao = new DAOAcceso();
            return dao.crearPrefil(nombre,codPerfil);
        }

        public int EliminarPerfil(string codPerfil)
        {
            DAOAcceso dao = new DAOAcceso();
            return dao.EliminarPerfil( codPerfil);
        }

        public int GuardarAccesos(string codPerfil, string accesos)
        {
            DAOAcceso dao = new DAOAcceso();
            return dao.GuardarAccesos(codPerfil, accesos);
        }
    }
}
