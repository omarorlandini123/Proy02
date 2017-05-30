using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;
using Data;
using System.Data;
using Oracle.DataAccess.Client;

namespace DataAccess
{
    public class DAOAcceso
    {

        public Usuario Login(string usuario, string password)
        {
            Usuario userRpta = null;

            try
            {
                AutenticarService.Autenticar aut = new AutenticarService.Autenticar();

                AutenticarService.RespuestaBE rpta = aut.LogOn(usuario, password, false);
                if (rpta.IdUsuario > 0)
                {
                    DataTable st = aut.GetOptionsByProfile(1, rpta.IdUsuario);
                }
                else {
                   rpta = aut.LogOn(usuario, password, true);

                }
                if (rpta != null)
                {
                    DataTable rptaperfil = rpta.MiPerfil;

                    userRpta = new Usuario();
                    userRpta.perfiles = new List<Perfil>();
                    foreach (DataRow fila in rptaperfil.Rows)
                    {
                        userRpta.idUsuario = fila["IdUsuario"].ToString();
                        userRpta.usuario = fila["Login"].ToString();
                        userRpta.Nombres = fila["ApellidosyNombres"].ToString();
                        userRpta.numeroPersonal = fila["NroPersonal"].ToString();
                        userRpta.area = new Area();
                        userRpta.area.codArea = fila["idArea"].ToString();
                        userRpta.area.desArea = fila["NombreArea"].ToString();
                        userRpta.area.sede = new Sede();
                        userRpta.area.sede.codSede = int.Parse(fila["idCentroOperativo"].ToString());
                        userRpta.area.sede.desSede = fila["NombreCentroOperativo"].ToString();
                        userRpta.centroCosto = new CentroCosto();
                        userRpta.centroCosto.idCentro = int.Parse(fila["idCentroCosto"].ToString());
                        userRpta.centroCosto.nroCentro = fila["NroCentroCosto"].ToString();
                        userRpta.centroCosto.nombre = fila["NombreCentroCosto"].ToString();
                        userRpta.grupoCentroCosto = new GrupoCentroCosto();
                        userRpta.grupoCentroCosto.idGrupoCentro = int.Parse(fila["idGrupoCentroCosto"].ToString());
                        userRpta.grupoCentroCosto.nombre = fila["NombreGrupoCentroCosto"].ToString();
                        Perfil perfil = new Perfil();
                        perfil.idPerfil = int.Parse(fila["IdPerfil"].ToString());
                        perfil.nombre = fila["Perfil"].ToString();
                        perfil.accesos = getAccesos(perfil.idPerfil);
                        userRpta.perfiles.Add(perfil);


                    }
                }
            }
            catch (Exception s) {

            }
            //userRpta.nivelesAprobacion;

            //*************************************

            return userRpta;
        }

        public int GuardarAccesos(string codPerfil, string accesos)
        {
            try
            {
                int t = int.Parse(codPerfil);
            }
            catch (Exception s)
            {
                return 18;
            }

            Conexion con = new Conexion();
            Procedimiento proc = new Procedimiento() { nombre = "INS_ACCESO_PERFIL" };
            proc.parametros.Add(new Parametro("VAR_ID_PERFIL", codPerfil, OracleDbType.Int32, Parametro.tipoIN));
            proc.parametros.Add(new Parametro("VAR_ACCESOS", accesos, OracleDbType.Varchar2, Parametro.tipoIN));

            DataTable dt = con.EjecutarProcedimiento(proc);


            if (dt != null)
            {
                if (dt.Rows.Count > 0)
                {

                    foreach (DataRow fila in dt.Rows)
                    {

                        if (int.Parse(fila["RPTA"].ToString()) > 0)
                        {

                            return 1;
                        }
                        else
                        {

                            return 2;
                        }
                    }
                }
            }
            else
            {
                return 3;
            }

            return 4;
        }

        public int EliminarPerfil(string codPerfil)
        {
            try
            {
                int t = int.Parse(codPerfil);
            }
            catch (Exception s)
            {
                return 18;
            }

            Conexion con = new Conexion();
            Procedimiento proc = new Procedimiento() { nombre = "DEL_PERFIL" };
            proc.parametros.Add(new Parametro("VAR_ID_PERFIL", codPerfil, OracleDbType.Int32, Parametro.tipoIN));

            DataTable dt = con.EjecutarProcedimiento(proc);


            if (dt != null)
            {
                if (dt.Rows.Count > 0)
                {

                    foreach (DataRow fila in dt.Rows)
                    {

                        if (int.Parse(fila["RPTA"].ToString()) > 0)
                        {

                            return 1;
                        }
                        else
                        {

                            return 2;
                        }
                    }
                }
            }
            else
            {
                return 3;
            }

            return 4;
        }

        public int crearPrefil(string nombre, string codPerfil)
        {

            try
            {
                int t = int.Parse(codPerfil);
            }
            catch (Exception s) {
                return 18;
            }

            Conexion con = new Conexion();
            Procedimiento proc = new Procedimiento() { nombre = "NEW_PERFIL" };
            proc.parametros.Add(new Parametro("VAR_NOMBRE", nombre, OracleDbType.Varchar2, Parametro.tipoIN));
            proc.parametros.Add(new Parametro("VAR_ID_PERFIL", codPerfil, OracleDbType.Int32, Parametro.tipoIN));

            DataTable dt = con.EjecutarProcedimiento(proc);


            if (dt != null)
            {
                if (dt.Rows.Count > 0)
                {

                    foreach (DataRow fila in dt.Rows)
                    {

                        if (int.Parse(fila["RPTA"].ToString()) > 0)
                        {

                            return 1;
                        }
                        else
                        {

                            return 2;
                        }
                    }
                }
            }
            else
            {
                return 3;
            }

            return 4;
        }

        public List<Acceso> getAccesos()
        {
            Conexion con = new Conexion();
            Procedimiento proc = new Procedimiento() { nombre = "GET_ACCESOS" };

            DataTable dt = con.EjecutarProcedimiento(proc);

            List<Acceso> listaRpta = null;

            if (dt != null)
            {
                if (dt.Rows.Count > 0)
                {
                    listaRpta = new List<Acceso>();

                    foreach (DataRow fila in dt.Rows)
                    {
                        try
                        {
                            Acceso acc = new Acceso();
                            acc.codigo = (Accesos)int.Parse(fila["ACCESO"].ToString());
                            acc.descripcion = fila["DESC"].ToString();
                            listaRpta.Add(acc);
                        }
                        catch (Exception s)
                        {
                            Console.WriteLine("Error En getAccesos ==> " + s.Message);
                        }
                    }
                }
            }

            return listaRpta;
        }

        public List<Perfil> getPerfiles()
        {
            Conexion con = new Conexion();
            Procedimiento proc = new Procedimiento() { nombre = "GET_PERFILES" };

            DataTable dt = con.EjecutarProcedimiento(proc);

            List<Perfil> listaRpta = null;

            if (dt != null)
            {
                if (dt.Rows.Count > 0)
                {
                    listaRpta = new List<Perfil>();

                    foreach (DataRow fila in dt.Rows)
                    {
                        try
                        {
                            Perfil acc = new Perfil();
                            acc.idPerfil = int.Parse(fila["ID_PERFIL"].ToString());
                            acc.nombre = fila["NOMBRE"].ToString();
                            listaRpta.Add(acc);
                        }
                        catch (Exception s)
                        {
                            Console.WriteLine("Error En getAccesos ==> " + s.Message);
                        }
                    }
                }
            }

            return listaRpta;
        }

        public List<Acceso> getAccesos(int idPerfil) {
            Conexion con = new Conexion();
            Procedimiento proc = new Procedimiento() { nombre = "GET_ACCESO_PERFIL" };
            proc.parametros.Add(new Parametro("VAR_ID_PERFIL", idPerfil, OracleDbType.Int32, Parametro.tipoIN));

            DataTable dt = con.EjecutarProcedimiento(proc);

            List<Acceso> listaRpta = null;

            if (dt != null)
            {
                if (dt.Rows.Count > 0)
                {
                    listaRpta = new List<Acceso>();

                    foreach (DataRow fila in dt.Rows)
                    {
                        try
                        {
                            Acceso acc = new Acceso();
                            acc.codigo = (Accesos)int.Parse(fila["acceso"].ToString());
                            acc.descripcion = Enum.GetName(typeof(Accesos),acc.codigo);
                            listaRpta.Add(acc);
                        }
                        catch (Exception s)
                        {
                            Console.WriteLine("Error En getAccesos ==> " + s.Message);
                        }
                    }
                }
            }

            return listaRpta;
        }

        public Usuario getUsuario(string usuario)
        {
            Usuario userRpta = new Usuario();
            userRpta.usuario = usuario;

            //*********** DATA DE PRUEBA **********

            //userRpta = new Usuario();
            //userRpta.idUsuario = "420";
            //userRpta.usuario = "consultor3";
            //userRpta.password = "1234";
            //userRpta.area = new Area();
            //userRpta.area.codArea = "4";
            //userRpta.area.desArea = "Sistemas";
            //userRpta.area.sede = new Sede();
            //userRpta.area.sede.codSede = 1;
            //userRpta.area.sede.desSede = "Lima";
            //userRpta.Nombres = "Juan Miguel";
            //userRpta.ApellidoMaterno = "Paredes";
            //userRpta.ApellidoPaterno = "Diaz";
            //userRpta.nivelesAprobacion;

            //*************************************

            return userRpta;
        }
    }
}
