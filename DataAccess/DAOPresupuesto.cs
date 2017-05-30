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
    public class DAOPresupuesto
    {
        public List<DetalleAprobacion> getDetallesAprobacion(int idAprobacion) {
            List<DetalleAprobacion> detalles = null;

            Conexion con = new Conexion();
            Procedimiento proc = new Procedimiento() { nombre = "GET_APROB_DET" };
            proc.parametros.Add(new Parametro("VAR_ID_APROB_PRESUP", idAprobacion, OracleDbType.Int32, Parametro.tipoIN));
            DataTable dt = con.EjecutarProcedimiento(proc);

            if (dt != null)
            {
                if (dt.Rows.Count > 0)
                {
                    detalles = new List<DetalleAprobacion>();
                    foreach (DataRow fila in dt.Rows)
                    {
                        try
                        {

                            DetalleAprobacion detalle = new DetalleAprobacion();
                            detalle.idDetalleAprobacion = int.Parse(fila["ID_DET_APROB_PRESUP"].ToString());
                            detalle.estado = (Aprobacion.estados)int.Parse(fila["ESTADO"].ToString());
                            detalle.fecReg = (DateTime)fila["FEC_REG"];
                            detalles.Add(detalle);
                                                    
                        }
                        catch (Exception s)
                        {
                            Console.WriteLine("Error En getAprobacionesVersion ==> " + s.Message);
                        }
                    }

                }
            }

            return detalles;
        }

        public DetalleVersion getAprobacionesDetalleVersion(int idDetalleVersion)
        {
            DetalleVersion presup = null;
            presup = new DetalleVersion();
            presup.idDetalle = idDetalleVersion;
            Conexion con = new Conexion();
            Procedimiento proc = new Procedimiento() { nombre = "GET_APROBACION_DTLL" };
            proc.parametros.Add(new Parametro("VAR_ID_DTLL", idDetalleVersion, OracleDbType.Int32, Parametro.tipoIN));
            DataTable dt = con.EjecutarProcedimiento(proc);

            if (dt != null)
            {
                if (dt.Rows.Count > 0)
                {
                    
                    presup.aprobaciones = new List<Aprobacion>();
                    foreach (DataRow fila in dt.Rows)
                    {
                        try
                        {
                            Aprobacion apro = new Aprobacion();
                            apro.idAprobacion = int.Parse(fila["ID_APROB_PRESUP"].ToString());
                            apro.orden = int.Parse(fila["ORDEN"].ToString());
                            apro.usuarioApro = new Usuario();
                            apro.usuarioApro.usuario = fila["USR_APROB"].ToString();
                            apro.estado = (Aprobacion.estados)int.Parse(fila["ESTADO"].ToString());
                            apro.usuarioReg = new Usuario();
                            apro.usuarioReg.usuario = fila["USR_REG"].ToString();
                            apro.FechaReg = (DateTime)fila["FEC_REG"];
                            apro.detalles = getDetallesAprobacion(apro.idAprobacion);
                        }
                        catch (Exception s)
                        {
                            Console.WriteLine("Error En getAprobacionesVersion ==> " + s.Message);
                        }
                    }

                }
            }
            return presup;
        }

        public Entidades.Version getAprobacionesVersion(int idVersion)
        {
            Entidades.Version presup = null;
            presup = new Entidades.Version();
            presup.idVersion = idVersion;
            Conexion con = new Conexion();
            Procedimiento proc = new Procedimiento() { nombre = "GET_APROBACION_VSN" };
            proc.parametros.Add(new Parametro("VAR_ID_VSN", idVersion, OracleDbType.Int32, Parametro.tipoIN));
            DataTable dt = con.EjecutarProcedimiento(proc);

            if (dt != null)
            {
                if (dt.Rows.Count > 0)
                {
                   
                    presup.aprobaciones = new List<Aprobacion>();
                    foreach (DataRow fila in dt.Rows)
                    {
                        try
                        {
                            Aprobacion apro = new Aprobacion();
                            apro.idAprobacion = int.Parse(fila["ID_APROB_PRESUP"].ToString());
                            apro.orden = int.Parse(fila["ORDEN"].ToString());
                            apro.usuarioApro = new Usuario();
                            apro.usuarioApro.usuario = fila["USR_APROB"].ToString();
                            apro.estado = (Aprobacion.estados)int.Parse(fila["ESTADO"].ToString());
                            apro.usuarioReg = new Usuario();
                            apro.usuarioReg.usuario = fila["USR_REG"].ToString();
                            apro.FechaReg = (DateTime)fila["FEC_REG"];
                            apro.detalles = getDetallesAprobacion(apro.idAprobacion);
                            presup.aprobaciones.Add(apro);
                        }
                        catch (Exception s)
                        {
                            Console.WriteLine("Error En getAprobacionesVersion ==> " + s.Message);
                        }
                    }

                }
            }
            return presup;
        }

        public Archivo getPresupFuncionamiento(int codSede, string codArea)
        {
            throw new NotImplementedException();
        }

        public Archivo getPresupCapital(int codSede, string codArea)
        {
            throw new NotImplementedException();
        }

        public Archivo getPresupFuncionamiento(int codSede)
        {
            throw new NotImplementedException();
        }

        public Archivo getPresupCapital(int codSede)
        {
            throw new NotImplementedException();
        }

      

        public List<DetalleVersion> getDetallesDeUltimaVersion(int idPresupuestoTipo)
        {
            Conexion con = new Conexion();
            Procedimiento proc = new Procedimiento() { nombre = "GET_DETALLE_VERSION_TIPO" };
            proc.parametros.Add(new Parametro("VAR_ID_DET_PRESUP", idPresupuestoTipo, OracleDbType.Int32, Parametro.tipoIN));

            DataTable dt = con.EjecutarProcedimiento(proc);

            List<DetalleVersion> listaRpta = null;

            if (dt != null)
            {
                if (dt.Rows.Count > 0)
                {
                    listaRpta = new List<DetalleVersion>();

                    foreach (DataRow fila in dt.Rows)
                    {
                        try
                        {
                            DetalleVersion det = new DetalleVersion();

                            DAOArea daoArea = new DAOArea();
                            DAOAcceso daoUsuario = new DAOAcceso();
                            DAOMaterial daoMaterial = new DAOMaterial();

                            det.idDetalle = int.Parse(fila["ID_DETALLE"].ToString());
                            det.tipo = int.Parse(fila["TIPO"].ToString());
                            if (det.tipo == 1)
                            {
                                det.mat = daoMaterial.getMaterial(fila["COD_MATERIAL"].ToString());
                            }
                            if (det.tipo == 2)
                            {
                                det.mat = daoMaterial.getServicio(fila["COD_MATERIAL"].ToString());
                            }
                            det.prioridad = new Prioridad();
                            det.prioridad.idPrioridad = int.Parse(fila["ID_PRIORIDAD"].ToString());
                            det.prioridad.nombre = fila["NOMBRE_PRIO"].ToString();
                            det.NombreMaterialSoli = fila["NOMB_MATERIAL"].ToString();
                            det.cantidadSoli = double.Parse(fila["CANT_SOLIC"].ToString());
                            det.precioSoli = double.Parse(fila["PRECIO_UNI_SOLIC"].ToString());
                            det.criticidad = int.Parse(fila["CRITICIDAD"].ToString());
                            det.totalSoli = double.Parse(fila["TOTAL_SOLIC"].ToString());
                            det.tipo = int.Parse(fila["TIPO"].ToString());
                            det.largo = double.Parse(fila["LARGO"].ToString());
                            det.ancho = double.Parse(fila["ANCHO"].ToString());
                            det.alto = double.Parse(fila["ALTO"].ToString());
                            det.sustento = fila["SUSTENTO"].ToString();
                            det.uniSoli = (fila["UNID_SOLI"].ToString());
                            det.FechaReg = (DateTime)fila["DET_V_FEC_REG"];
                            det.FechaUltModif = (DateTime)fila["DET_V_ULT_FEC"];
                            det.UsuarioReg = daoUsuario.getUsuario(fila["DET_V_USR_REG"].ToString());
                            det.UsuarioUltModif = daoUsuario.getUsuario(fila["DET_V_ULT_USR"].ToString());
                            det.mesesEnt = getMesesEnt_Sal(det.idDetalle, MesEntSoli.Tipos.Entrega);
                            det.mesesSoli = getMesesEnt_Sal(det.idDetalle, MesEntSoli.Tipos.Solicitud);
                            listaRpta.Add(det);
                        }
                        catch (Exception s)
                        {
                            Console.WriteLine("Error En DetallesDeVersion ==> " + s.Message);
                        }
                    }
                }
            }

            return listaRpta;
        }

        public DetallePresupuesto getAprobacionesDetallePresupuesto(int idDetallePresupuesto)
        {
            DetallePresupuesto presup = null;
            presup = new DetallePresupuesto();
            presup.idPresupuestoTipo = idDetallePresupuesto;
            Conexion con = new Conexion();
            Procedimiento proc = new Procedimiento() { nombre = "GET_APROBACION_DET_PRESUP" };
            proc.parametros.Add(new Parametro("VAR_ID_DET_PRESUP", idDetallePresupuesto, OracleDbType.Int32, Parametro.tipoIN));
            DataTable dt = con.EjecutarProcedimiento(proc);

            if (dt != null)
            {
                if (dt.Rows.Count > 0)
                {
                   
                    presup.aprobaciones = new List<Aprobacion>();
                    foreach (DataRow fila in dt.Rows)
                    {
                        try
                        {
                            Aprobacion apro = new Aprobacion();
                            apro.idAprobacion = int.Parse(fila["ID_APROB_PRESUP"].ToString());
                            apro.orden = int.Parse(fila["ORDEN"].ToString());
                            apro.usuarioApro = new Usuario();
                            apro.usuarioApro.usuario = fila["USR_APROB"].ToString();
                            apro.estado = (Aprobacion.estados)int.Parse(fila["ESTADO"].ToString());
                            apro.usuarioReg = new Usuario();
                            apro.usuarioReg.usuario = fila["USR_REG"].ToString();
                            apro.FechaReg = (DateTime)fila["FEC_REG"];
                            apro.detalles = getDetallesAprobacion(apro.idAprobacion);
                        }
                        catch (Exception s)
                        {
                            Console.WriteLine("Error En getAprobacionesDetallePresupuesto ==> " + s.Message);
                        }
                    }

                }
            }
            return presup;
        }
       
        public Presupuesto getAprobacionesPresupuesto(int idPresupuesto)
        {
            Presupuesto presup = null;
            presup = new Presupuesto();
            presup.idPresupuesto = idPresupuesto;
            Conexion con = new Conexion();
            Procedimiento proc = new Procedimiento() { nombre = "GET_APROBACION_PRESUP" };
            proc.parametros.Add(new Parametro("VAR_ID_PRESUP", idPresupuesto, OracleDbType.Int32, Parametro.tipoIN));
            DataTable dt = con.EjecutarProcedimiento(proc);

            if (dt != null)
            {
                if (dt.Rows.Count > 0)
                {
                    
                    presup.aprobaciones = new List<Aprobacion>();
                    foreach (DataRow fila in dt.Rows)
                    {
                        try
                        {
                            Aprobacion apro = new Aprobacion();
                            apro.idAprobacion = int.Parse(fila["ID_APROB_PRESUP"].ToString());
                            apro.orden = int.Parse(fila["ORDEN"].ToString());
                            apro.usuarioApro = new Usuario();
                            apro.usuarioApro.usuario = fila["USR_APROB"].ToString();
                            apro.estado = (Aprobacion.estados)int.Parse(fila["ESTADO"].ToString());
                            apro.usuarioReg = new Usuario();
                            apro.usuarioReg.usuario = fila["USR_REG"].ToString();
                            apro.FechaReg = (DateTime) fila["FEC_REG"];
                            apro.detalles = getDetallesAprobacion(apro.idAprobacion);
                            presup.aprobaciones.Add(apro);
                        }
                        catch (Exception s)
                        {
                            Console.WriteLine("Error En getAprobacionesPresupuesto ==> " + s.Message);
                        }
                    }

                }
            }
            return presup;
        }

        public int RechazarVersion(int id, string usuario)
        {
            Conexion con = new Conexion();
            Procedimiento proc = new Procedimiento() { nombre = "RECHAZAR_VERSION" };
            proc.parametros.Add(new Parametro("VAR_ID_VERSION", id, OracleDbType.Int32, Parametro.tipoIN));
            proc.parametros.Add(new Parametro("VAR_USR", usuario, OracleDbType.Varchar2, Parametro.tipoIN));

            DataTable dt = con.EjecutarProcedimiento(proc);


            if (dt != null)
            {
                if (dt.Rows.Count > 0)
                {

                    foreach (DataRow fila in dt.Rows)
                    {

                        if (int.Parse(fila["RPTA"].ToString()) > 0)
                        {

                            return int.Parse(fila["RPTA"].ToString());
                        }
                        else
                        {

                            return -2;
                        }
                    }
                }
            }
            else
            {
                return -3;
            }

            return -4;
        }

        public int AprobarVersion(int id, string usuario)
        {
            Conexion con = new Conexion();
            Procedimiento proc = new Procedimiento() { nombre = "APROBAR_VERSION" };
            proc.parametros.Add(new Parametro("VAR_ID_VERSION", id, OracleDbType.Int32, Parametro.tipoIN));
            proc.parametros.Add(new Parametro("VAR_USR", usuario, OracleDbType.Varchar2, Parametro.tipoIN));

            DataTable dt = con.EjecutarProcedimiento(proc);


            if (dt != null)
            {
                if (dt.Rows.Count > 0)
                {

                    foreach (DataRow fila in dt.Rows)
                    {

                        if (int.Parse(fila["RPTA"].ToString()) > 0)
                        {

                            return int.Parse(fila["RPTA"].ToString());
                        }
                        else
                        {

                            return -2;
                        }
                    }
                }
            }
            else
            {
                return -3;
            }

            return -4;
        }

        public int nuevaVersion(int id, int idArea,string usuario)
        {
            Conexion con = new Conexion();
            Procedimiento proc = new Procedimiento() { nombre = "NEW_VERSION" };
            proc.parametros.Add(new Parametro("VAR_ID_DET_PRESUP", id, OracleDbType.Int32, Parametro.tipoIN));
            proc.parametros.Add(new Parametro("VAR_ID_AREA", idArea, OracleDbType.Int32, Parametro.tipoIN));
            proc.parametros.Add(new Parametro("VAR_USR", usuario, OracleDbType.Varchar2, Parametro.tipoIN));

            DataTable dt = con.EjecutarProcedimiento(proc);


            if (dt != null)
            {
                if (dt.Rows.Count > 0)
                {

                    foreach (DataRow fila in dt.Rows)
                    {

                        if (int.Parse(fila["RPTA"].ToString()) > 0)
                        {

                            return int.Parse(fila["RPTA"].ToString());
                        }
                        else
                        {

                            return -2;
                        }
                    }
                }
            }
            else
            {
                return -3;
            }

            return -4;
        }

        public int AgregarAprobVersion(int id, int idOrden, string idUsuario, string usuario)
        {
            Conexion con = new Conexion();
            Procedimiento proc = new Procedimiento() { nombre = "SET_APROBADOR_VSN_PRESUP" };
            proc.parametros.Add(new Parametro("VAR_ID_VSN_PRESUP", id, OracleDbType.Int32, Parametro.tipoIN));
            proc.parametros.Add(new Parametro("VAR_ORDEN", idOrden, OracleDbType.Int32, Parametro.tipoIN));
            proc.parametros.Add(new Parametro("VAR_USR_APROB", idUsuario, OracleDbType.Varchar2, Parametro.tipoIN));
            proc.parametros.Add(new Parametro("VAR_USR_REG", usuario, OracleDbType.Varchar2, Parametro.tipoIN));

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

        public int EnviarAprobacion(int id, string usuario)
        {
            Conexion con = new Conexion();
            Procedimiento proc = new Procedimiento() { nombre = "ENVIAR_VERSION" };
            proc.parametros.Add(new Parametro("VAR_ID_VERSION", id, OracleDbType.Int32, Parametro.tipoIN));
            proc.parametros.Add(new Parametro("VAR_USR", usuario, OracleDbType.Varchar2, Parametro.tipoIN));

            DataTable dt = con.EjecutarProcedimiento(proc);


            if (dt != null)
            {
                if (dt.Rows.Count > 0)
                {

                    foreach (DataRow fila in dt.Rows)
                    {

                        if (int.Parse(fila["RPTA"].ToString()) > 0)
                        {

                            return int.Parse(fila["RPTA"].ToString());
                        }
                        else
                        {

                            return -2;
                        }
                    }
                }
            }
            else
            {
                return -3;
            }

            return -4;
        }

        public int AprobarDetalle(int idDetalle, Aprobacion.estados aprobado, string usuario)
        {
            Conexion con = new Conexion();
            Procedimiento proc = new Procedimiento() { nombre = "INS_APROBACION_DTLL" };
            proc.parametros.Add(new Parametro("VAR_ID_DTLL", idDetalle, OracleDbType.Int32, Parametro.tipoIN));
            proc.parametros.Add(new Parametro("VAR_ESTADO", (int)aprobado, OracleDbType.Int32, Parametro.tipoIN));
            proc.parametros.Add(new Parametro("VAR_USR", usuario, OracleDbType.Varchar2, Parametro.tipoIN));

            DataTable dt = con.EjecutarProcedimiento(proc);


            if (dt != null)
            {
                if (dt.Rows.Count > 0)
                {

                    foreach (DataRow fila in dt.Rows)
                    {

                        if (int.Parse(fila["RPTA"].ToString()) > 0)
                        {

                            return int.Parse(fila["RPTA"].ToString());
                        }
                        else
                        {

                            return -2;
                        }
                    }
                }
            }
            else
            {
                return -3;
            }

            return -4;
        }

        public int AgregarAprobPresup(int id, int idOrden, string idUsuario, string usuario)
        {
            Conexion con = new Conexion();
            Procedimiento proc = new Procedimiento() { nombre = "SET_APROBADOR_PRESUP" };
            proc.parametros.Add(new Parametro("VAR_ID_PRESUP", id, OracleDbType.Int32, Parametro.tipoIN));
            proc.parametros.Add(new Parametro("VAR_ORDEN", idOrden, OracleDbType.Int32, Parametro.tipoIN));
            proc.parametros.Add(new Parametro("VAR_USR_APROB", idUsuario, OracleDbType.Varchar2, Parametro.tipoIN));
            proc.parametros.Add(new Parametro("VAR_USR_REG", usuario, OracleDbType.Varchar2, Parametro.tipoIN));

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

        public int DesAprobarPresupuesto(int id, string usuario)
        {
            Conexion con = new Conexion();
            Procedimiento proc = new Procedimiento() { nombre = "INS_APROBACION_PRESUP" };
            proc.parametros.Add(new Parametro("VAR_ID_PRESUP", id, OracleDbType.Int32, Parametro.tipoIN));
            proc.parametros.Add(new Parametro("VAR_ESTADO", 0, OracleDbType.Int32, Parametro.tipoIN));
            proc.parametros.Add(new Parametro("VAR_USR", usuario, OracleDbType.Varchar2, Parametro.tipoIN));

            DataTable dt = con.EjecutarProcedimiento(proc);


            if (dt != null)
            {
                if (dt.Rows.Count > 0)
                {

                    foreach (DataRow fila in dt.Rows)
                    {

                        if (int.Parse(fila["RPTA"].ToString()) > 0)
                        {

                            return int.Parse(fila["RPTA"].ToString());
                        }
                        else
                        {

                            return -2;
                        }
                    }
                }
            }
            else
            {
                return -3;
            }

            return -4;
        }

        public int AprobarPresupuesto(int id, string usuario)
        {
            Conexion con = new Conexion();
            Procedimiento proc = new Procedimiento() { nombre = "INS_APROBACION_PRESUP" };
            proc.parametros.Add(new Parametro("VAR_ID_PRESUP", id, OracleDbType.Int32, Parametro.tipoIN));
            proc.parametros.Add(new Parametro("VAR_ESTADO", 1, OracleDbType.Int32, Parametro.tipoIN));
            proc.parametros.Add(new Parametro("VAR_USR", usuario, OracleDbType.Varchar2, Parametro.tipoIN));

            DataTable dt = con.EjecutarProcedimiento(proc);


            if (dt != null)
            {
                if (dt.Rows.Count > 0)
                {

                    foreach (DataRow fila in dt.Rows)
                    {

                        if (int.Parse(fila["RPTA"].ToString()) > 0)
                        {

                            return int.Parse(fila["RPTA"].ToString());
                        }
                        else
                        {

                            return -2;
                        }
                    }
                }
            }
            else
            {
                return -3;
            }

            return  -4;
        }

        public Presupuesto nuevoPresupuestoCompleto(string nombre,int idSede,string usuarioReg,int mesDesde, int anioDesde, int mesHasta, int anioHasta)
        {
            Presupuesto presup = null;
            Conexion con = new Conexion();
            Procedimiento proc = new Procedimiento() { nombre = "NEW_PRESUP" };
            proc.parametros.Add(new Parametro("VAR_NOMBRE", nombre, OracleDbType.Varchar2, Parametro.tipoIN));
            proc.parametros.Add(new Parametro("VAR_ID_SEDE", idSede, OracleDbType.Int32, Parametro.tipoIN));
            proc.parametros.Add(new Parametro("VAR_USUARIO_REG", usuarioReg, OracleDbType.Varchar2, Parametro.tipoIN));
            proc.parametros.Add(new Parametro("MES_DESDE", mesDesde, OracleDbType.Int32, Parametro.tipoIN));
            proc.parametros.Add(new Parametro("ANIO_DESDE", anioDesde, OracleDbType.Int32, Parametro.tipoIN));
            proc.parametros.Add(new Parametro("MES_HASTA", mesHasta, OracleDbType.Int32, Parametro.tipoIN));
            proc.parametros.Add(new Parametro("ANIO_HASTA", anioHasta, OracleDbType.Int32, Parametro.tipoIN));
            DataTable dt = con.EjecutarProcedimiento(proc);

            if (dt != null)
            {
                if (dt.Rows.Count > 0)
                {
                    presup = new Presupuesto();
                    foreach (DataRow fila in dt.Rows)
                    {
                        try
                        {
                            DAOAcceso daoAcceso = new DAOAcceso();

                            presup.idPresupuesto=int.Parse(fila["ID_PRESUPUESTO"].ToString());
                            presup.nombrePresupuesto = fila["NOMB_PRESUP"].ToString();
                            presup.sede = new Sede();
                            presup.sede.codSede = int.Parse(fila["ID_SEDE"].ToString());
                            presup.sede.desSede = fila["NOMB_SEDE"].ToString();
                            presup.fechaReg = (DateTime)fila["FECHA_REG"];
                            presup.usuarioReg = daoAcceso.getUsuario(fila["USUARIO_REG"].ToString());
                            presup.UltModifFec = (DateTime)fila["ULT_MODIF_FEC"];
                            presup.UltModifUser = daoAcceso.getUsuario(fila["ULT_MODIF_USER"].ToString());
                            presup.fechaValIni = (DateTime)fila["FECHA_VAL_INI"];
                            presup.fechaValFin = (DateTime)fila["FECHA_VAL_FIN"];
                            presup.estadoActual = (Aprobacion.estados)int.Parse(fila["EST_ACTUAL"].ToString());
                        }
                        catch (Exception s)
                        {
                            Console.WriteLine("Error En getPresupuestosPorSede ==> " + s.Message);
                        }
                    }
                   
                }
            }
            return presup;
        }

        public Archivo getArchivo(int idArchivo)
        {
            Conexion con = new Conexion();
            Procedimiento proc = new Procedimiento() { nombre = "GET_ARCHIVO" };
            proc.parametros.Add(new Parametro("VAR_ID_ARCHIVO", idArchivo, OracleDbType.Int32, Parametro.tipoIN));

            DataTable dt = con.EjecutarProcedimiento(proc);


            if (dt != null)
            {
                if (dt.Rows.Count > 0)
                {
                    DAOAcceso daoAcceso = new DAOAcceso();
                    foreach (DataRow fila in dt.Rows)
                    {

                        Archivo ar = new Archivo();
                        ar.idArchivo = int.Parse(fila["ID_ARCHIVO"].ToString());
                        ar.nombre = fila["NOMB_ARCHIVO"].ToString();
                        ar.tipo = fila["TIPO_ARCHIVO"].ToString();
                        ar.ruta = fila["RUTA_ARCHIVO"].ToString();
                        ar.fechaReg = (DateTime)fila["ARCH_FEC_REG"];
                        ar.UsuarioReg = daoAcceso.getUsuario(fila["ARCH_USR_REG"].ToString());

                        return ar;
                    }
                }
            }
            return null;
        }

        public int EliminarArchivo(int idArchivo)
        {
            Conexion con = new Conexion();
            Procedimiento proc = new Procedimiento() { nombre = "DEL_ARCHIVO" };
            proc.parametros.Add(new Parametro("VAR_ID_ARCHIVO", idArchivo, OracleDbType.Int32, Parametro.tipoIN));

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

        public int subirArchivoaDetalle(int idDetalle,string nombre,string tipo, string ruta, string usuario)
        {
            Conexion con = new Conexion();
            Procedimiento proc = new Procedimiento() { nombre = "INS_ARCHIVO" };
            proc.parametros.Add(new Parametro("VAR_ID_DET_VERSION", idDetalle, OracleDbType.Int32, Parametro.tipoIN));
            proc.parametros.Add(new Parametro("VAR_NOMB_ARCHIVO", nombre, OracleDbType.Varchar2, Parametro.tipoIN));
            proc.parametros.Add(new Parametro("VAR_TIPO_ARCHIVO", tipo, OracleDbType.Varchar2, Parametro.tipoIN));
            proc.parametros.Add(new Parametro("VAR_RUTA_ARCHIVO", ruta, OracleDbType.Varchar2, Parametro.tipoIN));
            proc.parametros.Add(new Parametro("VAR_ARCH_USR_REG", usuario, OracleDbType.Varchar2, Parametro.tipoIN));

            DataTable dt = con.EjecutarProcedimiento(proc);


            if (dt != null)
            {
                if (dt.Rows.Count > 0)
                {

                    foreach (DataRow fila in dt.Rows)
                    {

                        if (int.Parse(fila["ID_ARCHIVO"].ToString()) > 0)
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

        public Presupuesto getPresupuestosPorTipo(int idPresupuesto)
        {
            Presupuesto presup = null;
            
            Conexion con = new Conexion();
            Procedimiento proc = new Procedimiento() { nombre = "GET_DETALLES_PRESUP_POR_TIPO" };
            proc.parametros.Add(new Parametro("VAR_ID_PRESUP", idPresupuesto, OracleDbType.Int32, Parametro.tipoIN));
            DataTable dt = con.EjecutarProcedimiento(proc);

            presup = getPresupuesto(idPresupuesto);

            if (dt != null)
            {
                if (dt.Rows.Count > 0)
                {
                    DAOAcceso daoAcceso = new DAOAcceso();
                    presup.TiposPresupuestos = new List<DetallePresupuesto>();
                    foreach (DataRow fila in dt.Rows)
                    {
                        
                        DetallePresupuesto det = new DetallePresupuesto();
                        det.estadoActual = (Aprobacion.estados)int.Parse(fila["DET_P_EST_ACTUAL"].ToString());
                        det.FechaReg = (DateTime)fila["DET_P_FECHA_REG"];
                        det.usuarioReg = daoAcceso.getUsuario(fila["DET_P_USR_REG"].ToString());
                        det.UltModifReg = (DateTime)fila["DET_P_ULT_MODIF_FEC"];
                        det.UltModifUser = daoAcceso.getUsuario(fila["DET_P_MODIF_USR"].ToString());
                        det.fechaValIni = (DateTime)fila["DET_P_FECHA_VAL_INI"];
                        det.fechaValFin = (DateTime)fila["DET_P_FECHA_VAL_FIN"];
                        det.monto = double.Parse(fila["MONTO"].ToString());
                        det.tipoPresupuesto = new TipoPresupuesto();
                        det.tipoPresupuesto.idTipoPresupuesto = int.Parse(fila["ID_TIPO_PRESUP"].ToString());
                        det.tipoPresupuesto.nombrePresupuesto = fila["NOMBRE"].ToString();
                        presup.TiposPresupuestos.Add(det);
                    }
                }
            }
            return presup;
        }

        public List<Sede> getSedes() {

            Conexion con = new Conexion();
            Procedimiento proc = new Procedimiento() { nombre = "GET_SEDE" };

            DataTable dt = con.EjecutarProcedimiento(proc);

            List<Sede> lista= new List<Sede>();
            if (dt != null)
            {
                if (dt.Rows.Count > 0)
                {

                    foreach (DataRow fila in dt.Rows)
                    {

                        Sede se = new Sede();
                        se.codSede = int.Parse(fila["ID_SEDE"].ToString());
                        se.desSede = fila["NOMB_SEDE"].ToString();
                        lista.Add(se);
                    }
                }
            }

            return lista;
        }

        public int CrearPresup(string nombre, int idSede, string usuario, int mesDesde, int anioDesde, int mesHasta, int anioHasta)
        {
            Conexion con = new Conexion();
            Procedimiento proc = new Procedimiento() { nombre = "NEW_PRESUP" };
            proc.parametros.Add(new Parametro("VAR_NOMBRE", nombre, OracleDbType.Varchar2, Parametro.tipoIN));
            proc.parametros.Add(new Parametro("VAR_ID_SEDE", idSede, OracleDbType.Int32, Parametro.tipoIN));
            proc.parametros.Add(new Parametro("VAR_USUARIO_REG", usuario, OracleDbType.Varchar2, Parametro.tipoIN));
            proc.parametros.Add(new Parametro("MES_DESDE", mesDesde, OracleDbType.Int32, Parametro.tipoIN));
            proc.parametros.Add(new Parametro("ANIO_DESDE", anioDesde, OracleDbType.Int32, Parametro.tipoIN));
            proc.parametros.Add(new Parametro("MES_HASTA", mesHasta, OracleDbType.Int32, Parametro.tipoIN));
            proc.parametros.Add(new Parametro("ANIO_HASTA", anioHasta, OracleDbType.Int32, Parametro.tipoIN));

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

        public int EliminarDetalle(int idDetalle)
        {
            Conexion con = new Conexion();
            Procedimiento proc = new Procedimiento() { nombre = "DEL_DET_VERSION" };
            proc.parametros.Add(new Parametro("VAR_ID_DET_VERSION", idDetalle, OracleDbType.Int32, Parametro.tipoIN));
        
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

        public Observacion getObservacion(int idObservacion)
        {
            Observacion obs = new Observacion();

            Conexion con = new Conexion();
            Procedimiento proc = new Procedimiento() { nombre = "GET_OBSERVACION" };
            proc.parametros.Add(new Parametro("VAR_ID_OBSERVACION", idObservacion, OracleDbType.Int32, Parametro.tipoIN));
            DataTable dt = con.EjecutarProcedimiento(proc);
            

            if (dt != null)
            {
                if (dt.Rows.Count > 0)
                {
                    DAOAcceso daoAcceso = new DAOAcceso();
                    
                    foreach (DataRow fila in dt.Rows)
                    {

                        obs.detalle = new DetalleVersion();
                        obs.detalle.idDetalle = int.Parse(fila["ID_DET"].ToString());
                        obs.idObservacion = int.Parse(fila["ID_OBSERVACIONES"].ToString());
                        obs.observacion = fila["OBSERVACION"].ToString();
                        obs.usuarioReg = daoAcceso.getUsuario(fila["OBS_USR_REG"].ToString());
                        obs.fechaReg = (DateTime)fila["OSB_FEC_REG"];
                        if (string.IsNullOrEmpty(fila["OBS_USR_RES"].ToString()))
                        {

                            obs.usuarioRes = null;
                            obs.fechaRes = new DateTime();

                        }
                        else
                        {
                            obs.usuarioRes = daoAcceso.getUsuario(fila["OBS_USR_RES"].ToString());
                            obs.fechaRes = (DateTime)fila["OBS_FEC_RES"];
                        }

                        obs.observacionRes = fila["OBS_RES"].ToString();
                        return obs;
                    }
                }
            }
            return null;
        }

        public int actualizarDetalleVersion(DetalleVersion detVersion)
        {
            Conexion con = new Conexion();
            Procedimiento proc = new Procedimiento() { nombre = "UPD_DETALLE_VERSION" };
            proc.parametros.Add(new Parametro("VAR_ID_DET_VERSION", detVersion.idDetalle, OracleDbType.Int32, Parametro.tipoIN));
            proc.parametros.Add(new Parametro("VAR_COD_MATERIAL", detVersion.mat.codProducto, OracleDbType.Varchar2, Parametro.tipoIN));
            proc.parametros.Add(new Parametro("VAR_NOMB_MATERIAL", detVersion.mat.desc, OracleDbType.Varchar2, Parametro.tipoIN));
            proc.parametros.Add(new Parametro("VAR_CANT_SOLIC", detVersion.cantidadSoli, OracleDbType.Double, Parametro.tipoIN));
            proc.parametros.Add(new Parametro("VAR_PRECIO_UNIT", detVersion.precioSoli, OracleDbType.Varchar2, Parametro.tipoIN));
            proc.parametros.Add(new Parametro("VAR_CRITICIDAD", detVersion.criticidad, OracleDbType.Int32, Parametro.tipoIN));
            proc.parametros.Add(new Parametro("VAR_TIPO", detVersion.tipo, OracleDbType.Int32, Parametro.tipoIN));
            proc.parametros.Add(new Parametro("VAR_LARGO", detVersion.largo, OracleDbType.Double, Parametro.tipoIN));
            proc.parametros.Add(new Parametro("VAR_ANCHO", detVersion.ancho, OracleDbType.Double, Parametro.tipoIN));
            proc.parametros.Add(new Parametro("VAR_ALTO", detVersion.alto, OracleDbType.Double, Parametro.tipoIN));
            proc.parametros.Add(new Parametro("VAR_SUSTENTO", detVersion.sustento, OracleDbType.Varchar2, Parametro.tipoIN));
            proc.parametros.Add(new Parametro("VAR_UNID_SOLI", detVersion.uniSoli, OracleDbType.Varchar2, Parametro.tipoIN));
            proc.parametros.Add(new Parametro("VAR_USUARIO_REG", detVersion.UsuarioReg.usuario, OracleDbType.Varchar2, Parametro.tipoIN));
            proc.parametros.Add(new Parametro("VAR_ID_MESES_SOL", detVersion.messoli, OracleDbType.Varchar2, Parametro.tipoIN));
            proc.parametros.Add(new Parametro("VAR_ID_MESES_ENT", detVersion.mesent, OracleDbType.Varchar2, Parametro.tipoIN));
            proc.parametros.Add(new Parametro("VAR_ID_PRIORIDAD", detVersion.prioridad.idPrioridad, OracleDbType.Int32, Parametro.tipoIN));
            proc.parametros.Add(new Parametro("VAR_ID_VERSION", detVersion.version.idVersion, OracleDbType.Int32, Parametro.tipoIN));
       
            DataTable dt = con.EjecutarProcedimiento(proc);


            if (dt != null)
            {
                if (dt.Rows.Count > 0)
                {

                    foreach (DataRow fila in dt.Rows)
                    {

                        if (int.Parse(fila["ID_DETALLE"].ToString()) > 0)
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

        public List<Prioridad> getPrioridades()
        {
            List<Prioridad> lista=null;

            Conexion con = new Conexion();
            Procedimiento proc = new Procedimiento() { nombre = "GET_PRIORIDADES" };
            DataTable dt = con.EjecutarProcedimiento(proc);

            
            if (dt != null)
            {
                if (dt.Rows.Count > 0)
                {
                    lista=new List<Prioridad>();
                    foreach (DataRow fila in dt.Rows)
                    {

                        Prioridad prio = new Prioridad();
                        prio.idPrioridad = int.Parse(fila["ID_PRIORIDAD"].ToString());
                        prio.nombre = fila["NOMBRE_PRIO"].ToString();
                        lista.Add(prio);
                        
                    }
                }
            }
            return lista;
        }

        public DetalleVersion getArchivosDetalle(int idDetalle)
        {

            DetalleVersion detalleVer = new DetalleVersion();
            detalleVer.idDetalle = idDetalle;
            Conexion con = new Conexion();
            Procedimiento proc = new Procedimiento() { nombre = "GET_ARCHIVOS_DETALLE" };
            proc.parametros.Add(new Parametro("VAR_ID_DET_VERSION", idDetalle, OracleDbType.Varchar2, Parametro.tipoIN));
           
            DataTable dt = con.EjecutarProcedimiento(proc);


            if (dt != null)
            {
                if (dt.Rows.Count > 0)
                {
                    detalleVer.archivosSustento = new List<Archivo>();
                    DAOAcceso daoAcceso = new DAOAcceso();
                    foreach (DataRow fila in dt.Rows)
                    {
                        Archivo arc = new Archivo();
                        arc.idArchivo = int.Parse(fila["ID_ARCHIVO"].ToString());
                        arc.nombre = fila["NOMB_ARCHIVO"].ToString();
                        arc.tipo = fila["TIPO_ARCHIVO"].ToString();
                        arc.ruta = fila["RUTA_ARCHIVO"].ToString();
                        arc.fechaReg = (DateTime)fila["ARCH_FEC_REG"];
                        arc.UsuarioReg = daoAcceso.getUsuario(fila["ARCH_USR_REG"].ToString());
                        detalleVer.archivosSustento.Add(arc);
                    }
                }
            }
            

            return detalleVer;
        }

        public int agregarDetalleVersion(DetalleVersion detVersion)
        {
            Conexion con = new Conexion();
            Procedimiento proc = new Procedimiento() { nombre = "INS_DETALLE_VERSION" };
            proc.parametros.Add(new Parametro("VAR_COD_MATERIAL", detVersion.mat.codProducto, OracleDbType.Varchar2, Parametro.tipoIN));
            proc.parametros.Add(new Parametro("VAR_NOMB_MATERIAL", detVersion.mat.desc, OracleDbType.Varchar2, Parametro.tipoIN));
            proc.parametros.Add(new Parametro("VAR_CANT_SOLIC", detVersion.cantidadSoli, OracleDbType.Double, Parametro.tipoIN));
            proc.parametros.Add(new Parametro("VAR_PRECIO_UNIT", detVersion.precioSoli, OracleDbType.Varchar2, Parametro.tipoIN));
            proc.parametros.Add(new Parametro("VAR_CRITICIDAD", detVersion.criticidad, OracleDbType.Int32, Parametro.tipoIN));
            proc.parametros.Add(new Parametro("VAR_TIPO", detVersion.tipo, OracleDbType.Int32, Parametro.tipoIN));
            proc.parametros.Add(new Parametro("VAR_LARGO", detVersion.largo, OracleDbType.Double, Parametro.tipoIN));
            proc.parametros.Add(new Parametro("VAR_ANCHO", detVersion.ancho, OracleDbType.Double, Parametro.tipoIN));
            proc.parametros.Add(new Parametro("VAR_ALTO", detVersion.alto, OracleDbType.Double, Parametro.tipoIN));
            proc.parametros.Add(new Parametro("VAR_SUSTENTO", detVersion.sustento, OracleDbType.Varchar2, Parametro.tipoIN));
            proc.parametros.Add(new Parametro("VAR_UNID_SOLI", detVersion.uniSoli, OracleDbType.Varchar2, Parametro.tipoIN));
            proc.parametros.Add(new Parametro("VAR_USUARIO_REG", detVersion.UsuarioReg.usuario, OracleDbType.Varchar2, Parametro.tipoIN));
            proc.parametros.Add(new Parametro("VAR_ID_MESES_SOL", detVersion.messoli, OracleDbType.Varchar2, Parametro.tipoIN));
            proc.parametros.Add(new Parametro("VAR_ID_MESES_ENT", detVersion.mesent, OracleDbType.Varchar2, Parametro.tipoIN));
            proc.parametros.Add(new Parametro("VAR_ID_PRIORIDAD", detVersion.prioridad.idPrioridad, OracleDbType.Int32, Parametro.tipoIN));
            proc.parametros.Add(new Parametro("VAR_ID_VERSION", detVersion.version.idVersion, OracleDbType.Int32, Parametro.tipoIN));
            proc.parametros.Add(new Parametro("VAR_NOMB_ARCHIVO", detVersion.archivosSustento[0].nombre, OracleDbType.Varchar2, Parametro.tipoIN));
            proc.parametros.Add(new Parametro("VAR_TIPO_ARCHIVO", detVersion.archivosSustento[0].tipo, OracleDbType.Varchar2, Parametro.tipoIN));
            proc.parametros.Add(new Parametro("VAR_RUTA_ARCHIVO", detVersion.archivosSustento[0].ruta, OracleDbType.Varchar2, Parametro.tipoIN));
           
            DataTable dt = con.EjecutarProcedimiento(proc);


            if (dt != null)
            {
                if (dt.Rows.Count > 0)
                {

                    foreach (DataRow fila in dt.Rows)
                    {

                        if (int.Parse(fila["ID_DETALLE"].ToString()) > 0)
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
            else {
                return 3;
            }

            return 4;
        }

        public List<Presupuesto> getPresupuestosPorSede(Sede sede) {
            List<Presupuesto> listaRpta = new List<Presupuesto>();

            return listaRpta;
        }

        

        public Presupuesto getPresupuestosPorArea(int idPresupuesto, string usuario) {

            Presupuesto rpta = new Presupuesto();
            rpta.presupuestosArea = new List<PresupuestoArea>();
            rpta = getPresupuesto(idPresupuesto);
            rpta.TiposPresupuestos = getPresupuestosTipos(idPresupuesto);
            //if (rpta.TiposPresupuestos != null)
            //{
            //    foreach (DetallePresupuesto presup in rpta.TiposPresupuestos)
            //    {
            //        presup.versiones = getVersiones(presup.idPresupuestoTipo);
            //    }
            //}

            rpta.presupuestosArea = getPresupuestosArea(idPresupuesto,usuario);
            return rpta;
        }

        public DetallePresupuesto getPresupuestoTipo(int idPresupuestoTipo) {

            List<DetallePresupuesto> listaRpta = null;

            Conexion con = new Conexion();
            Procedimiento proc = new Procedimiento() { nombre = "GET_DETALLE_PRESUP" };
            proc.parametros.Add(new Parametro("VAR_DET_PRESUP", idPresupuestoTipo, OracleDbType.Int32, Parametro.tipoIN));
            DataTable dt = con.EjecutarProcedimiento(proc);

            if (dt != null)
            {
                if (dt.Rows.Count > 0)
                {
                    listaRpta = new List<DetallePresupuesto>();
                    foreach (DataRow fila in dt.Rows)
                    {
                        try
                        {
                            DAOAcceso daoAcceso = new DAOAcceso();

                            DetallePresupuesto detallePresup = new DetallePresupuesto();
                            detallePresup.idPresupuestoTipo = int.Parse(fila["ID_DET_PRESUP"].ToString());
                            detallePresup.FechaReg = (DateTime)fila["DET_P_fecha_reg"];
                            detallePresup.UltModifReg = (DateTime)fila["DET_P_ult_modif_fec"];                            
                            detallePresup.fechaValIni = (DateTime)fila["DET_P_fecha_val_ini"];
                            detallePresup.fechaValFin = (DateTime)fila["DET_P_fecha_val_fin"];
                            detallePresup.estadoActual = (Aprobacion.estados)int.Parse(fila["DET_P_est_actual"].ToString());
                            detallePresup.tipoPresupuesto = new TipoPresupuesto();
                            detallePresup.tipoPresupuesto.idTipoPresupuesto = int.Parse(fila["ID_TIPO_PRESUP"].ToString());
                            detallePresup.tipoPresupuesto.nombrePresupuesto = fila["NOMBRE"].ToString();
                            detallePresup.monto = double.Parse(fila["monto"].ToString());                            
                            detallePresup.UltModifUser = daoAcceso.getUsuario(fila["DET_P_modif_usr"].ToString());
                            detallePresup.usuarioReg = daoAcceso.getUsuario(fila["DET_P_USR_REG"].ToString());
                            detallePresup.presupuesto = getPresupuesto(int.Parse(fila["id_presupuesto"].ToString()));

                            listaRpta.Add(detallePresup);


                        }
                        catch (Exception s)
                        {
                            Console.WriteLine("Error En getPresupuestosPorSede ==> " + s.Message);
                        }
                    }
                    return listaRpta.FirstOrDefault();
                }
            }
            return null;

        }

       

        public Entidades.Version getVersionDetallada(int id,int idTipo)
        {
            Entidades.Version ver = null;
            Conexion con = new Conexion();
            Procedimiento proc = new Procedimiento() { nombre = "GET_VERSION" };
            proc.parametros.Add(new Parametro("VAR_ID_VERSION", id, OracleDbType.Int32, Parametro.tipoIN));
            DataTable dt = con.EjecutarProcedimiento(proc);

            if (dt != null)
            {
                if (dt.Rows.Count > 0)
                {
                    ver = new Entidades.Version();
                    foreach (DataRow fila in dt.Rows)
                    {
                        try
                        {
                            DAOArea daoArea = new DAOArea();
                            DAOAcceso daoUsuario = new DAOAcceso();

                            ver.idVersion = int.Parse(fila["id_version"].ToString());
                            ver.numeroVersion = int.Parse(fila["nro"].ToString());
                            ver.presupuestoTipo = getPresupuestoTipo(int.Parse(fila["id_det_presup"].ToString()));                            
                            ver.area = daoArea.getArea(int.Parse(fila["id_area"].ToString()));
                            ver.fechaReg = (DateTime)fila["v_fecha_reg"];                           
                            ver.usuarioReg = daoUsuario.getUsuario(fila["v_usuario_reg"].ToString());
                            ver.UltModifFec = (DateTime)fila["v_ult_modif_fec"];
                            ver.fechaValIni = (DateTime)fila["v_fecha_val_ini"];
                            ver.fechaValFin = (DateTime)fila["v_fecha_val_fin"];
                            ver.estadoActual = (Aprobacion.estados)int.Parse(fila["est_actual"].ToString());
                            ver.detalles = DetallesDeVersion("",ver.idVersion, idTipo);

                        }
                        catch (Exception s)
                        {
                            Console.WriteLine("Error En getPresupuestosPorSede ==> " + s.Message);
                        }
                    }
                }
            }
            
            return ver;
        }

        public DetalleVersion DetalleDeVersion(int idDetalleVersion,int idTipo)
        {

            Conexion con = new Conexion();
            Procedimiento proc = new Procedimiento() { nombre = "GET_DETALLE_VERSION" };
            proc.parametros.Add(new Parametro("VAR_ID_DETALLE", idDetalleVersion, OracleDbType.Int32, Parametro.tipoIN));
            
            DataTable dt = con.EjecutarProcedimiento(proc);

            List<DetalleVersion> listaRpta = null;

            if (dt != null)
            {
                if (dt.Rows.Count > 0)
                {
                    listaRpta = new List<DetalleVersion>();

                    foreach (DataRow fila in dt.Rows)
                    {
                        try
                        {
                            DetalleVersion det = new DetalleVersion();

                            DAOArea daoArea = new DAOArea();
                            DAOAcceso daoUsuario = new DAOAcceso();
                            DAOMaterial daoMaterial = new DAOMaterial();

                            det.idDetalle = int.Parse(fila["ID_DETALLE"].ToString());
                            if (idTipo == 1)
                            {
                                det.mat = daoMaterial.getMaterial(fila["COD_MATERIAL"].ToString());
                            }
                            if (idTipo == 2)
                            {
                                det.mat = daoMaterial.getServicio(fila["COD_MATERIAL"].ToString());
                            }
                            det.prioridad = new Prioridad();
                            det.prioridad.idPrioridad = int.Parse(fila["ID_PRIORIDAD"].ToString());
                            det.prioridad.nombre = fila["NOMBRE_PRIO"].ToString();
                            det.NombreMaterialSoli = fila["NOMB_MATERIAL"].ToString();
                            det.cantidadSoli = double.Parse(fila["CANT_SOLIC"].ToString());
                            det.precioSoli = double.Parse(fila["PRECIO_UNI_SOLIC"].ToString());
                            det.criticidad = int.Parse(fila["CRITICIDAD"].ToString());
                            det.totalSoli = double.Parse(fila["TOTAL_SOLIC"].ToString());
                            det.tipo = int.Parse(fila["TIPO"].ToString());
                            det.largo = double.Parse(fila["LARGO"].ToString());
                            det.ancho = double.Parse(fila["ANCHO"].ToString());
                            det.alto = double.Parse(fila["ALTO"].ToString());
                            det.sustento = fila["SUSTENTO"].ToString();
                            det.uniSoli = (fila["UNID_SOLI"].ToString());
                            det.FechaReg = (DateTime)fila["DET_V_FEC_REG"];
                            det.FechaUltModif = (DateTime)fila["DET_V_ULT_FEC"];
                            det.UsuarioReg = daoUsuario.getUsuario(fila["DET_V_USR_REG"].ToString());
                            det.UsuarioUltModif = daoUsuario.getUsuario(fila["DET_V_ULT_USR"].ToString());
                            det.mesesEnt = getMesesEnt_Sal(idDetalleVersion,MesEntSoli.Tipos.Entrega);
                            det.mesesSoli = getMesesEnt_Sal(idDetalleVersion, MesEntSoli.Tipos.Solicitud);
                            listaRpta.Add(det);
                        }
                        catch (Exception s)
                        {
                            Console.WriteLine("Error En DetallesDeVersion ==> " + s.Message);
                        }
                    }
                }
            }

            return listaRpta.FirstOrDefault();

        }

        public List<MesEntSoli> getMesesEnt_Sal(int idDetalleVersion,MesEntSoli.Tipos idTipo)
        {
            Conexion con = new Conexion();
            Procedimiento proc = new Procedimiento() { nombre = "GET_MESES_E_S_DETALLE" };
            proc.parametros.Add(new Parametro("VAR_ID_DETALLE", idDetalleVersion, OracleDbType.Int32, Parametro.tipoIN));
            proc.parametros.Add(new Parametro("VAR_ID_TIPO", (int)idTipo, OracleDbType.Int32, Parametro.tipoIN));
            DataTable dt = con.EjecutarProcedimiento(proc);

            List<MesEntSoli> RPTA=null;
            if (dt != null)
            {
                if (dt.Rows.Count > 0)
                {
                    RPTA = new List<MesEntSoli>();
                    DAOAcceso daoUsuario = new DAOAcceso();
                    foreach (DataRow fila in dt.Rows)
                    {
                        try
                        {
                            MesEntSoli det = new MesEntSoli();

                            det.idMesEntSoli = int.Parse(fila["ID_MES_ENTREGA"].ToString());
                            det.usuarioReg = daoUsuario.getUsuario(fila["MES_ENT_USR_REG"].ToString());
                            det.fechaReg = (DateTime)fila["MES_ENT_FEC_REG"];
                            det.Mes = (MesEntSoli.Meses)int.Parse(fila["MES"].ToString());
                            det.tipo = idTipo;

                            RPTA.Add(det);
                        }
                        catch (Exception s)
                        {
                            Console.WriteLine("Error En DetallesDeVersion ==> " + s.Message);
                        }
                    }
                }
            }
            return RPTA;
        }

        public List<DetalleVersion> DetallesDeVersion(string cond , int idVersion,int idTipo) {

            Conexion con = new Conexion();
            Procedimiento proc = new Procedimiento() { nombre = "GET_DETALLES_VERSION" };
            proc.parametros.Add(new Parametro("VAR_COND", cond, OracleDbType.Varchar2, Parametro.tipoIN));
            proc.parametros.Add(new Parametro("VAR_ID_VERSION", idVersion, OracleDbType.Int32, Parametro.tipoIN));
            proc.parametros.Add(new Parametro("VAR_ID_TIPO", idTipo, OracleDbType.Int32, Parametro.tipoIN));

            DataTable dt = con.EjecutarProcedimiento(proc);

            List<DetalleVersion> listaRpta = null;

            if (dt != null)
            {
                if (dt.Rows.Count > 0)
                {
                    listaRpta = new List<DetalleVersion>();
                   
                    foreach (DataRow fila in dt.Rows)
                    {
                        try
                        {
                            DetalleVersion det = new DetalleVersion();

                            DAOArea daoArea = new DAOArea();
                            DAOAcceso daoUsuario = new DAOAcceso();
                            DAOMaterial daoMaterial = new DAOMaterial();

                            det.idDetalle = int.Parse(fila["ID_DETALLE"].ToString());
                            if (idTipo == 1)
                            {
                                det.mat = daoMaterial.getMaterial(fila["COD_MATERIAL"].ToString());
                            }
                            if (idTipo == 2)
                            {
                                det.mat = daoMaterial.getServicio(fila["COD_MATERIAL"].ToString());
                            }
                            det.prioridad = new Prioridad();
                            det.prioridad.idPrioridad = int.Parse(fila["ID_PRIORIDAD"].ToString());
                            det.prioridad.nombre = fila["NOMBRE_PRIO"].ToString();
                            det.NombreMaterialSoli = fila["NOMB_MATERIAL"].ToString();
                            det.cantidadSoli = double.Parse(fila["CANT_SOLIC"].ToString());
                            det.precioSoli = double.Parse(fila["PRECIO_UNI_SOLIC"].ToString());
                            det.criticidad = int.Parse(fila["CRITICIDAD"].ToString());
                            det.totalSoli = double.Parse(fila["TOTAL_SOLIC"].ToString());
                            det.tipo = int.Parse(fila["TIPO"].ToString());
                            det.largo = double.Parse(fila["LARGO"].ToString());
                            det.ancho = double.Parse(fila["ANCHO"].ToString());
                            det.alto = double.Parse(fila["ALTO"].ToString());
                            det.sustento = fila["SUSTENTO"].ToString();
                            det.uniSoli = (fila["UNID_SOLI"].ToString());
                            det.FechaReg = (DateTime)fila["DET_V_FEC_REG"];
                            det.FechaUltModif = (DateTime)fila["DET_V_ULT_FEC"];
                            det.estado = (Aprobacion.estados)int.Parse(fila["ESTADO"].ToString());
                            det.UsuarioReg = daoUsuario.getUsuario(fila["DET_V_USR_REG"].ToString());
                            det.UsuarioUltModif = daoUsuario.getUsuario(fila["DET_V_ULT_USR"].ToString());
                            listaRpta.Add(det);
                        }
                        catch (Exception s)
                        {
                            Console.WriteLine("Error En DetallesDeVersion ==> " + s.Message);
                        }
                    }
                }
            }

            return listaRpta;

        }

        public List<PresupuestoArea> getPresupuestosArea(int idPresupuesto,string usuario)
        {
            List<PresupuestoArea> listaRpta = null;

            Conexion con = new Conexion();
            Procedimiento proc = new Procedimiento() { nombre = "GET_PRESUPUESTO_AREAS" };
            proc.parametros.Add(new Parametro("VAR_ID_PRESUP", idPresupuesto, OracleDbType.Int32, Parametro.tipoIN));
            DataTable dt = con.EjecutarProcedimiento(proc);

            if (dt != null)
            {
                if (dt.Rows.Count > 0)
                {
                    listaRpta = new List<PresupuestoArea>();
                    foreach (DataRow fila in dt.Rows)
                    {
                        try
                        {
                            PresupuestoArea presup = new PresupuestoArea();
                            presup.monto = double.Parse(fila["MONTO"].ToString());
                            presup.UltModifFec =(DateTime) fila["ULTMODIF"];
                            presup.fechaValIni = (DateTime)fila["FECHAVALINI"];
                            presup.fechaValFin = (DateTime)fila["FECHAVALFIN"];
                            DAOArea daoarea = new DAOArea();
                            presup.area = daoarea.getArea(int.Parse(fila["ID_AREA"].ToString()));

                            listaRpta.Add(presup);
                        }
                        catch (Exception s)
                        {
                            Console.WriteLine("Error En getPresupuestosPorSede ==> " + s.Message);
                        }
                    }
                }
            }
            return listaRpta;

        }

        public DetallePresupuesto getVersiones(int idPresupTipo, int idArea)
        {
            DetallePresupuesto presupTipo = new DetallePresupuesto();
            presupTipo.versiones = new List<Entidades.Version>();

            Conexion con = new Conexion();
            Procedimiento proc = new Procedimiento() { nombre = "GET_VERSIONES" };
            proc.parametros.Add(new Parametro("VAR_ID_PRESUPUESTO_TIPO", idPresupTipo, OracleDbType.Int32, Parametro.tipoIN));
            proc.parametros.Add(new Parametro("VAR_ID_AREA", idArea, OracleDbType.Int32, Parametro.tipoIN));
            DataTable dt = con.EjecutarProcedimiento(proc);

            if (dt != null)
            {
                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow fila in dt.Rows)
                    {
                        try
                        {
                            
                            presupTipo.idPresupuestoTipo = int.Parse(fila["ID_DET_PRESUP"].ToString());
                            presupTipo.FechaReg = (DateTime)fila["DET_P_fecha_reg"];
                            presupTipo.UltModifReg = (DateTime)fila["DET_P_ult_modif_fec"];
                            presupTipo.fechaValIni = (DateTime)fila["DET_P_fecha_val_ini"];
                            presupTipo.fechaValFin = (DateTime)fila["DET_P_fecha_val_fin"];
                            presupTipo.estadoActual = (Aprobacion.estados)int.Parse(fila["DET_P_est_actual"].ToString());                            

                            DAOAcceso daoAcceso = new DAOAcceso();
                            presupTipo.UltModifUser = daoAcceso.getUsuario(fila["DET_P_modif_usr"].ToString());
                            presupTipo.usuarioReg = daoAcceso.getUsuario(fila["DET_P_USR_REG"].ToString());
                            Entidades.Version vers = new Entidades.Version();
                            vers.idVersion = int.Parse(fila["id_version"].ToString());
                            vers.numeroVersion = int.Parse(fila["nro"].ToString());

                            DAOArea daoArea = new DAOArea();
                            vers.area = daoArea.getArea(int.Parse(fila["id_area"].ToString()));

                            vers.fechaReg = (DateTime)fila["v_fecha_reg"];
                            vers.usuarioReg = daoAcceso.getUsuario(fila["v_usuario_reg"].ToString());
                            vers.UltModifFec = (DateTime)fila["v_ult_modif_fec"];
                            vers.fechaValIni = (DateTime) fila["v_fecha_val_ini"];
                            vers.fechaValFin= (DateTime)fila["v_fecha_val_fin"];
                            vers.estadoActual = (Aprobacion.estados)int.Parse(fila["ESTADO"].ToString());
                            vers.monto = double.Parse(fila["MONTO"].ToString());
                            presupTipo.versiones.Add(vers);


                        }
                        catch (Exception s)
                        {
                            Console.WriteLine("Error En getPresupuestosPorSede ==> " + s.Message);
                        }
                    }
                }
            }

            return presupTipo;
        }

    

        public List<DetallePresupuesto> getPresupuestosTipos(int idPresupuesto) {
            List<DetallePresupuesto> listaRpta = null;

            Conexion con = new Conexion();
            Procedimiento proc = new Procedimiento() { nombre = "GET_DETALLES_PRESUP" };
            proc.parametros.Add(new Parametro("VAR_ID_PRESUPUESTO", idPresupuesto, OracleDbType.Int32, Parametro.tipoIN));
            DataTable dt = con.EjecutarProcedimiento(proc);

            if (dt != null)
            {
                if (dt.Rows.Count > 0)
                {
                    listaRpta = new List<DetallePresupuesto>();
                    foreach (DataRow fila in dt.Rows)
                    {
                        try
                        {
                            DetallePresupuesto presupTipo = new DetallePresupuesto();
                            presupTipo.idPresupuestoTipo = int.Parse(fila["ID_DET_PRESUP"].ToString());
                            presupTipo.FechaReg = (DateTime)fila["DET_P_fecha_reg"];
                            presupTipo.UltModifReg = (DateTime)fila["DET_P_ult_modif_fec"];

                            presupTipo.fechaValIni = (DateTime)fila["DET_P_fecha_val_ini"];
                            presupTipo.fechaValFin = (DateTime)fila["DET_P_fecha_val_fin"];
                            presupTipo.estadoActual = (Aprobacion.estados)int.Parse(fila["DET_P_est_actual"].ToString());
                            presupTipo.tipoPresupuesto = new TipoPresupuesto();
                            presupTipo.tipoPresupuesto.idTipoPresupuesto = int.Parse(fila["ID_TIPO_PRESUP"].ToString());
                            presupTipo.tipoPresupuesto.nombrePresupuesto = fila["NOMBRE"].ToString();
                            presupTipo.monto = double.Parse(fila["monto"].ToString());
                            DAOAcceso daoAcceso = new DAOAcceso();
                            presupTipo.UltModifUser = daoAcceso.getUsuario(fila["DET_P_modif_usr"].ToString());
                            presupTipo.usuarioReg = daoAcceso.getUsuario(fila["DET_P_usr_reg"].ToString());
                            listaRpta.Add(presupTipo);


                        }
                        catch (Exception s)
                        {
                            Console.WriteLine("Error En getPresupuestosPorSede ==> " + s.Message);
                        }
                    }
                }
            }
            return listaRpta;
        }
        public List<DetallePresupuesto> getPresupuestosTiposArea(int idPresupuesto,int idArea)
        {
            List<DetallePresupuesto> listaRpta = null;

            Conexion con = new Conexion();
            Procedimiento proc = new Procedimiento() { nombre = "GET_DETALLES_PRESUP_AREA" };
            proc.parametros.Add(new Parametro("VAR_ID_PRESUPUESTO", idPresupuesto, OracleDbType.Int32, Parametro.tipoIN));
            proc.parametros.Add(new Parametro("VAR_ID_AREA", idArea, OracleDbType.Int32, Parametro.tipoIN));
            DataTable dt = con.EjecutarProcedimiento(proc);

            if (dt != null)
            {
                if (dt.Rows.Count > 0)
                {
                    listaRpta = new List<DetallePresupuesto>();
                    foreach (DataRow fila in dt.Rows)
                    {
                        try
                        {
                            DetallePresupuesto presupTipo = new DetallePresupuesto();
                            presupTipo.idPresupuestoTipo = int.Parse(fila["ID_DET_PRESUP"].ToString());
                            presupTipo.FechaReg = (DateTime)fila["DET_P_fecha_reg"];
                            presupTipo.UltModifReg = (DateTime)fila["DET_P_ult_modif_fec"];
                            presupTipo.nroActual = int.Parse(fila["NRO"].ToString());
                            presupTipo.fechaValIni = (DateTime)fila["DET_P_fecha_val_ini"];
                            presupTipo.fechaValFin = (DateTime)fila["DET_P_fecha_val_fin"];
                            presupTipo.estadoActual = (Aprobacion.estados)int.Parse(fila["ESTADO"].ToString());
                            presupTipo.tipoPresupuesto = new TipoPresupuesto();
                            presupTipo.tipoPresupuesto.idTipoPresupuesto = int.Parse(fila["ID_TIPO_PRESUP"].ToString());
                            presupTipo.tipoPresupuesto.nombrePresupuesto = fila["NOMBRE"].ToString();
                            presupTipo.monto = double.Parse(fila["monto"].ToString());
                            DAOAcceso daoAcceso = new DAOAcceso();
                            presupTipo.UltModifUser = daoAcceso.getUsuario(fila["DET_P_modif_usr"].ToString());
                            presupTipo.usuarioReg = daoAcceso.getUsuario(fila["DET_P_usr_reg"].ToString());
                            listaRpta.Add(presupTipo);


                        }
                        catch (Exception s)
                        {
                            Console.WriteLine("Error En getPresupuestosPorSede ==> " + s.Message);
                        }
                    }
                }
            }
            return listaRpta;
        }

        public List<Entidades.Version> getVersiones(int idPresupuestoTipo)
        {
            List<Entidades.Version> listaRpta = null;

            Conexion con = new Conexion();
            Procedimiento proc = new Procedimiento() { nombre = "GET_VERSIONES_PRESUPUESTO_TIPO" };
            proc.parametros.Add(new Parametro("VAR_ID_PRESUP_TIPO", idPresupuestoTipo, OracleDbType.Int32, Parametro.tipoIN));
            DataTable dt = con.EjecutarProcedimiento(proc);

            if (dt != null)
            {
                if (dt.Rows.Count > 0)
                {
                    listaRpta = new List<Entidades.Version>();
                    foreach (DataRow fila in dt.Rows)
                    {
                        try
                        {
                            Entidades.Version vers = new Entidades.Version();
                            vers.idVersion = int.Parse(fila["ID_VERSION"].ToString());
                            vers.numeroVersion = int.Parse(fila["NRO"].ToString());
                            vers.fechaReg = (DateTime)fila["v_fecha_reg"];
                            vers.fechaValIni = (DateTime)fila["v_fecha_val_ini"];
                            vers.fechaValFin = (DateTime)fila["v_fecha_val_fin"];
                            vers.UltModifFec = (DateTime)fila["v_ult_modif_fec"];
                            vers.estadoActual = (Aprobacion.estados)int.Parse(fila["est_actual"].ToString());
                            
                            DAOAcceso daoAcceso = new DAOAcceso();
                            vers.usuarioReg = daoAcceso.getUsuario(fila["v_usuario_reg"].ToString());
                           
                            DAOArea daoArea = new DAOArea();
                            vers.area=daoArea.getArea(int.Parse(fila["id_area"].ToString()));

                            listaRpta.Add(vers);
                        }
                        catch (Exception s)
                        {
                            Console.WriteLine("Error En getPresupuestosPorSede ==> " + s.Message);
                        }
                    }
                }
            }
            return listaRpta;
        }



        public bool AprobarPresupuesto(int id, string observacion, int estado, Usuario user)
        {
            return true;
        }

        /// <summary>
        /// Obtiene las versiones de los presupuestos del área 
        /// </summary>
        /// <param name="sede">Sede de la cual se pide las versiones </param>
        /// <param name="anio">Año de las versiones</param>
        /// <param name="area">El área del cual se requieren las versiones</param>
        /// <returns></returns>
        public List<Presupuesto> getPresupuestosPorVersion(Sede sede, int anio, Area area) {
            List<Presupuesto> listaRpta = new List<Presupuesto>();

            return listaRpta;
        }


        /// <summary>
        /// Obtiene un presupuesto por código en específico
        /// </summary>
        /// <param name="codPresupuesto">El código del presupuesto</param>
        /// <returns></returns>
        public Presupuesto getPresupuesto(int codPresupuesto) {
            Presupuesto presup = null;
          
            Conexion con = new Conexion();
            Procedimiento proc = new Procedimiento() { nombre = "GET_PRESUPUESTO" };
            proc.parametros.Add(new Parametro("VAR_ID_PRESUPUESTO", codPresupuesto, OracleDbType.Int32, Parametro.tipoIN));
            DataTable dt = con.EjecutarProcedimiento(proc);

            if (dt != null)
            {
                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow fila in dt.Rows)
                    {
                        try
                        {
                            presup = new Presupuesto();
                            presup.estadoActual = (Aprobacion.estados)int.Parse(fila["EST_ACTUAL"].ToString());
                            presup.nombrePresupuesto = fila["NOMB_PRESUP"].ToString();
                            presup.idPresupuesto = int.Parse(fila["ID_PRESUPUESTO"].ToString());
                            presup.fechaReg = (DateTime)fila["FECHA_REG"];
                            presup.fechaValIni = (DateTime)fila["FECHA_VAL_INI"];
                            presup.fechaValFin = (DateTime)fila["FECHA_VAL_FIN"];
                            presup.UltModifFec = (DateTime)fila["ULT_MODIF_FEC"];
                            try
                            {
                                DAOAcceso daoacceso = new DAOAcceso();
                                presup.UltModifUser = daoacceso.getUsuario(fila["ULT_MODIF_USER"].ToString());
                            }
                            catch (Exception ex) {
                                Console.WriteLine("Error En consiguiendo usuario para getPresupuestosPorSede  ==> " + ex.Message);
                            }
                        }
                        catch (Exception s)
                        {
                            Console.WriteLine("Error En getPresupuestosPorSede ==> " + s.Message);
                        }
                    }
                }
            }
            return presup;
        }

  

        /// <summary>
        /// Permite enviar el borrador de presupuesto al siguiente Nivel 
        /// </summary>
        /// <param name="presup">Presupuesto que se quiere llevar al siguiente nivel</param>
        /// <returns></returns>
        public Boolean enviarPresupuestoAprobacion(Presupuesto presup) {
            return true;
        }

        /// <summary>
        /// Rechaza el presupuesto en el nivel Actual y genera una nueva version del mismo
        /// </summary>
        /// <param name="presup">presupuesto a Rechazar</param>
        /// <returns></returns>
        public Boolean rechazarPresupuesto(Presupuesto presup) {
            return true;
        }

        public DetalleVersion getObservacionesDetalle(int idDetalle) {

            Conexion con = new Conexion();
            Procedimiento proc = new Procedimiento() { nombre = "GET_OBSERVACIONES_DETALLE" };
            proc.parametros.Add(new Parametro("VAR_ID_DET_VERSION", idDetalle, OracleDbType.Int32, Parametro.tipoIN));
            DataTable dt =con.EjecutarProcedimiento(proc);
            DetalleVersion detalle=new DetalleVersion() { idDetalle=idDetalle};
            

            if (dt != null)
            {
                detalle.observaciones = new List<Observacion>();
                DAOAcceso daoAcceso = new DAOAcceso();
                foreach (DataRow fila in dt.Rows)
                {

                    try
                    {
                        detalle.idDetalle = int.Parse(fila["ID_DET"].ToString());
                    }
                    catch (Exception s)
                    {
                        Console.WriteLine("Error en getObservacionesDetalle ==> " + s.Message);
                        detalle.idDetalle = idDetalle;
                    }


                    Observacion obs = new Observacion();
                    obs.detalle = detalle;
                    obs.idObservacion = int.Parse(fila["ID_OBSERVACIONES"].ToString());
                    obs.observacion = fila["OBSERVACION"].ToString();
                    obs.usuarioReg = new Usuario();
                    obs.usuarioReg.usuario=fila["OBS_USR_REG"].ToString();
                    obs.fechaReg = (DateTime)fila["OSB_FEC_REG"];
                    if (string.IsNullOrEmpty(fila["OBS_USR_RES"].ToString()))
                    {

                        obs.usuarioRes = null;
                        obs.fechaRes = new DateTime();

                    }
                    else {
                        obs.usuarioRes = new Usuario();
                        obs.usuarioRes.usuario= fila["OBS_USR_RES"].ToString();
                        obs.fechaRes = (DateTime)fila["OBS_FEC_RES"];
                    }
                    
                    obs.observacionRes = fila["OBS_RES"].ToString();

                    detalle.observaciones.Add(obs);
                }
                
            }
            return detalle;
        }

        public List<Aprobacion> AprobacionesPresupuesto(int idPresupuesto)
        {
            Conexion con = new Conexion();
            Procedimiento proc = new Procedimiento() { nombre = "APROB_PRESUP" };
            proc.parametros.Add(new Parametro("VAR_ID_PRESUP", idPresupuesto, OracleDbType.Int32, Parametro.tipoIN));
            DataTable dt = con.EjecutarProcedimiento(proc);
            List<Aprobacion> listaRpta = new List<Aprobacion>();
            if (dt != null)
            {
                foreach (DataRow fila in dt.Rows)
                {
                    Aprobacion aprob = new Aprobacion();
                    try
                    {
                        aprob.idAprobacion = int.Parse(fila["ID_APROB_PRESUP"].ToString());
                    }
                    catch (Exception s)
                    {
                        Console.WriteLine("Error en AprobacionesPresupuesto campo idAprobacion ==> " + s.Message);
                    }

                    try
                    {
                        aprob.orden = int.Parse(fila["ORDEN"].ToString());
                    }
                    catch (Exception s)
                    {
                        Console.WriteLine("Error en AprobacionesPresupuesto campo orden ==> " + s.Message);
                    }

                    try
                    {
                        aprob.usuarioApro = new Usuario();
                        aprob.usuarioApro.usuario = fila["USR_APROB"].ToString();
                    }
                    catch (Exception s)
                    {
                        Console.WriteLine("Error en AprobacionesPresupuesto campo usuarioApro ==> " + s.Message);
                    }

                    try
                    {
                        aprob.estado = (Aprobacion.estados)int.Parse(fila["ESTADO"].ToString());
                    }
                    catch (Exception s)
                    {
                        Console.WriteLine("Error en AprobacionesPresupuesto campo estado ==> " + s.Message);
                    }

                    try
                    {
                        aprob.FechaApro = DateTime.Parse(fila["FEC_APROB"].ToString());
                    }
                    catch (Exception s)
                    {
                        Console.WriteLine("Error en AprobacionesPresupuesto campo estado ==> " + s.Message);
                        aprob.FechaApro = new DateTime(01, 01, 01);
                    }

                    try
                    {
                        aprob.Observacion = fila["OBS"].ToString();
                    }
                    catch (Exception s)
                    {
                        Console.WriteLine("Error en AprobacionesPresupuesto campo estado ==> " + s.Message);
                    }



                }
            }

           
            return listaRpta;
        }





        /// <summary>
        /// Registra una observación acerca del producto agregado en el presupuesto
        /// </summary>
        /// <param name="idDetalle"></param>
        /// <param name="observacion"></param>
        /// <param name="usuario"></param>
        /// <returns></returns>
        public bool ObservarDetalle(int idDetalle, string observacion, string usuario)
        {
            /*
             Falta agregar el VAR_USUREG en el procedimiento OBSERVAR_DETALLE
            */
            Conexion con = new Conexion();
            Procedimiento proc = new Procedimiento() { nombre = "INS_OBS_DETALLE" };
            proc.parametros.Add(new Parametro("VAR_ID_DETALLE", idDetalle, OracleDbType.Int32, Parametro.tipoIN));
            proc.parametros.Add(new Parametro("VAR_OBSERVACION", observacion, OracleDbType.Varchar2, Parametro.tipoIN));
            proc.parametros.Add(new Parametro("VAR_USEREG", usuario, OracleDbType.Varchar2, Parametro.tipoIN));
            DataTable dt = con.EjecutarProcedimiento(proc);

            bool rpta = false; 
            if (dt != null)
            {                
                foreach (DataRow fila in dt.Rows)
                {
                    try
                    {
                        rpta = fila["RPTA"].ToString().Contains("1");
                    }
                    catch (Exception s)
                    {
                        Console.WriteLine("Error En ObservarDetalle ==> " + s.Message);
                        rpta = false;
                    }                                       
                }
            }
            return rpta;
        }

        /// <summary>
        /// Registra el comentario de la resolución de observación
        /// </summary>
        /// <param name="idObservacion"></param>
        /// <param name="observacion"></param>
        /// <returns>True, si se ha registrado la resolución </returns>
        public bool ResolverObservacion(int idObservacion, string observacion,string usuario)
        {
            /*
              Falta agregar el VAR_USUREG en el procedimiento RESOLVER_OBS_DET
             */
            Conexion con = new Conexion();
            Procedimiento proc = new Procedimiento() { nombre = "RESOLVER_OBS_DET" };
            proc.parametros.Add(new Parametro("VAR_ID_OBS", idObservacion, OracleDbType.Int32, Parametro.tipoIN));
            proc.parametros.Add(new Parametro("VAR_OBSERVACION", observacion, OracleDbType.Varchar2, Parametro.tipoIN));
            proc.parametros.Add(new Parametro("VAR_USUREG", usuario, OracleDbType.Varchar2, Parametro.tipoIN));
            DataTable dt = con.EjecutarProcedimiento(proc);

            bool rpta = false;
            if (dt != null)
            {
                foreach (DataRow fila in dt.Rows)
                {
                    try
                    {
                        rpta = fila["RPTA"].ToString().Contains("1");
                    }
                    catch (Exception s)
                    {
                        Console.WriteLine("Error En Resolver Observacion ==> " + s.Message);
                        rpta = false;
                    }
                }
            }
            return rpta;
        }


        public Sede getPresupuestosPorSede(int idSede) {

            Sede sede = null;
            sede = new Sede();
            sede.codSede = 1;
            sede.desSede = "Lima";
            Conexion con = new Conexion();
            Procedimiento proc = new Procedimiento() { nombre = "GET_PRESUP_POR_SEDE" };
            proc.parametros.Add(new Parametro("VAR_ID_SEDE", idSede, OracleDbType.Int32, Parametro.tipoIN));
            DataTable dt = con.EjecutarProcedimiento(proc);
            
            if (dt != null)
            {
                if (dt.Rows.Count > 0)
                {
                    sede = new Sede();
                    sede.codSede = 1;
                    sede.desSede = "Lima";
                    sede.presupuestos = new List<Presupuesto>();
                    foreach (DataRow fila in dt.Rows)
                    {
                        try
                        {
                            Presupuesto presup = new Presupuesto();
                            presup.estadoActual = (Aprobacion.estados)int.Parse(fila["EST_ACTUAL"].ToString());
                            presup.nombrePresupuesto = fila["NOMB_PRESUP"].ToString();
                            presup.idPresupuesto = int.Parse(fila["ID_PRESUPUESTO"].ToString());
                            presup.monto = double.Parse(fila["MONTO"].ToString());
                            presup.fechaReg = (DateTime)fila["FECHA_REG"];
                            presup.fechaValIni = (DateTime)fila["FECHA_VAL_INI"];
                            presup.fechaValFin = (DateTime)fila["FECHA_VAL_FIN"];
                            presup.UltModifFec = (DateTime)fila["ULT_MODIF_FEC"];
                            Usuario userUltModif = new Usuario();
                            userUltModif.usuario = fila["ULT_MODIF_USER"].ToString();
                            presup.UltModifUser = userUltModif;
                            presup.aprobaciones = getAprobacionesPresupuesto(presup.idPresupuesto).aprobaciones;
                            sede.presupuestos.Add(presup);
                        }
                        catch (Exception s) {
                            Console.WriteLine("Error En getPresupuestosPorSede ==> " + s.Message);
                        }
                    }
                }
            }
            return sede;

        }
        public List<Presupuesto> getPresupuestosPorSedeLista(int idSede,int idArea)
        {

            List<Presupuesto>  listaRpta= new List<Presupuesto> ();
            Conexion con = new Conexion();
            Procedimiento proc = new Procedimiento() { nombre = "GET_PRESUP_POR_SEDE_AREA" };
            proc.parametros.Add(new Parametro("VAR_ID_SEDE", idSede, OracleDbType.Int32, Parametro.tipoIN));
            proc.parametros.Add(new Parametro("VAR_ID_AREA", idArea, OracleDbType.Int32, Parametro.tipoIN));
            DataTable dt = con.EjecutarProcedimiento(proc);

            if (dt != null)
            {
                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow fila in dt.Rows)
                    {
                        try
                        {
                            Presupuesto presup = new Presupuesto();
                            presup.estadoActual = (Aprobacion.estados)int.Parse(fila["EST_ACTUAL"].ToString());
                            presup.nombrePresupuesto = fila["NOMB_PRESUP"].ToString();
                            presup.idPresupuesto = int.Parse(fila["ID_PRESUPUESTO"].ToString());
                            presup.monto = double.Parse(fila["MONTO"].ToString());
                            presup.fechaReg = (DateTime)fila["FECHA_REG"];
                            presup.fechaValIni = (DateTime)fila["FECHA_VAL_INI"];
                            presup.fechaValFin = (DateTime)fila["FECHA_VAL_FIN"];
                            presup.UltModifFec = (DateTime)fila["ULT_MODIF_FEC"];
                            Usuario userUltModif = new Usuario();
                            userUltModif.usuario = fila["ULT_MODIF_USER"].ToString();
                            presup.UltModifUser = userUltModif;
                            listaRpta.Add(presup);
                        }
                        catch (Exception s)
                        {
                            Console.WriteLine("Error En getPresupuestosPorSedeLista ==> " + s.Message);
                        }
                    }
                }
            }
            return listaRpta;

        }

    }
}
