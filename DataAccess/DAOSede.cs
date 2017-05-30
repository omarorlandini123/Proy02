using Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;
using System.Data.SqlClient;
using Oracle.DataAccess.Client;
namespace DataAccess
{
    public class DAOSede
    {
        private Conexion conector;

        public DAOSede() {

            conector = new Conexion();

        }

        public List<Sede> getSedes() {
            List<Sede> lista = new List<Sede>();
           //DateTable rpta = conector.Ejecutar("select COD_SEDE,DES_SEDE from T_SEDE");

           //while (rpta.Read()) {

            Sede sede = new Sede();
            sede.codSede = 1;
            sede.desSede = "Lima";

            Sede sede2 = new Sede();
            sede2.codSede = 2;
            sede2.desSede = "Chimbote";

            lista.Add(sede);
            lista.Add(sede2);

            //}
            return lista;
        }

        

        public Boolean insertarSede(Sede sede) {
            Console.Write("El método insertarSede no está implementado");
            return true;

        }

        public Boolean EditarSede(Sede sede) {
            Console.Write("El método EditarSede no está implementado");
            return true;
        }

        public Sede buscarSede(Sede sede) {
            Console.Write("El método buscarSede no está implementado");
            Sede rpta = new Sede();
            rpta.codSede = 2;
            rpta.desSede = "Sede de prueba";
            return rpta;
        }





    }
}
