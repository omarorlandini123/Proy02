using Entidades;
using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicAccess
{
    public class LogicPresupuesto
    {
        /// <summary>
        /// Lista los presupuestos generales de cada sede
        /// </summary>
        /// <param name="sede">La sede de la cual se quiere obtener el presupuesto (Solo es necesario el código de Sede)</param>
        /// <returns></returns>
        public List<Presupuesto> getPresupuestosPorSede(Sede sede)
        {
            DAOPresupuesto dao = new DAOPresupuesto();
            return  dao.getPresupuestosPorSede(sede);
        }

        public Entidades.Version getVersionDetallada(int id,int idTipo)
        {
            DAOPresupuesto dao = new DAOPresupuesto();
            return dao.getVersionDetallada(id,idTipo);
        }

        public DetalleVersion getArchivosDetalle(int idDetalle) {
            DAOPresupuesto dao = new DAOPresupuesto();
            return dao.getArchivosDetalle(idDetalle);
        }

        public DetalleVersion DetalleDeVersion(int idDetalleVersion, int idTipo) {
            DAOPresupuesto dao = new DAOPresupuesto();
            return dao.DetalleDeVersion(idDetalleVersion, idTipo);
        }

        public List<DetalleVersion> DetallesDeVersion(string cond,int idVersion, int idTipo) {
            DAOPresupuesto dao = new DAOPresupuesto();
            return dao.DetallesDeVersion(cond,idVersion, idTipo);
        }

        /// <summary>
        /// Obtiene los presupuestos generales de las áreas
        /// </summary>
        /// <param name="sede">Sede de la cual se necesita el área</param>
        /// <param name="anio">Año del cual se quieren los presupuestos</param>
        /// <returns></returns>
        public Presupuesto getPresupuestosPorArea(int idPresupuesto,string usuario)
        {
            DAOPresupuesto dao = new DAOPresupuesto();
            Presupuesto pre=dao.getPresupuestosPorArea(idPresupuesto,usuario);          
           
            return pre;
        }

        public int EliminarArchivo(int idArchivo)
        {
            DAOPresupuesto dao = new DAOPresupuesto();
            return dao.EliminarArchivo(idArchivo);
        }

        public int subirArchivoaDetalle(int idDetalle,string nombre, string tipo, string ruta, string usuario)
        {
            DAOPresupuesto dao = new DAOPresupuesto();
            return dao.subirArchivoaDetalle(idDetalle,nombre,tipo,ruta,usuario);
        }

        public Archivo getArchivo(int idArchivo)
        {
            DAOPresupuesto dao = new DAOPresupuesto();
            return dao.getArchivo(idArchivo);
        }

        public Presupuesto getPresupuestosPorTipo(int idPresupuesto)
        {

            DAOPresupuesto dao = new DAOPresupuesto();
            Presupuesto pre = dao.getPresupuestosPorTipo(idPresupuesto);
            return pre;
        }



        public bool AprobarPresupuesto(int id, string observacion, int estado, Usuario user)
        {
            DAOPresupuesto dao = new DAOPresupuesto();
            return dao.AprobarPresupuesto(id,observacion,estado,user);
        }

        public Presupuesto getPresupuestoReporteGeneral(int codPresupuesto)
        {
            Presupuesto presup = getPresupuesto(codPresupuesto);

            presup.TiposPresupuestos = getPresupuestosTipos(presup.idPresupuesto);
            foreach (DetallePresupuesto detPresup in presup.TiposPresupuestos)
            {
                detPresup.detalleDeVersiones = getDetallesDeUltimaVersion(detPresup.idPresupuestoTipo);

            }

            return presup;
        }







        /// <summary>
        /// Obtiene las versiones de los presupuestos del área 
        /// </summary>
        /// <param name="sede">Sede de la cual se pide las versiones </param>
        /// <param name="anio">Año de las versiones</param>
        /// <param name="area">El área del cual se requieren las versiones</param>
        /// <returns></returns>
        public List<Presupuesto> getPresupuestosPorVersion(Sede sede, int anio, Area area)
        {
            DAOPresupuesto dao = new DAOPresupuesto();
            return dao.getPresupuestosPorVersion(sede,anio,area);
        }

        /// <summary>
        /// Obtiene un presupuesto por código en específico
        /// </summary>
        /// <param name="codPresupuesto">El código del presupuesto</param>
        /// <returns></returns>
        public Presupuesto getPresupuesto(int codPresupuesto)
        {
            DAOPresupuesto dao = new DAOPresupuesto();
            return dao.getPresupuesto(codPresupuesto);
        }

        

        public DetallePresupuesto getVersiones(int idPresupTipo, int idArea)
        {
            DAOPresupuesto dao = new DAOPresupuesto();
            return dao.getVersiones(idPresupTipo,idArea);
        }

        public int agregarDetalleVersion(DetalleVersion detVersion)
        {
            DAOPresupuesto dao = new DAOPresupuesto();
            return dao.agregarDetalleVersion(detVersion);
        }


        public int actualizarDetalleVersion(DetalleVersion detVersion)
        {
            DAOPresupuesto dao = new DAOPresupuesto();
            return dao.actualizarDetalleVersion(detVersion);
        }

        /// <summary>
        /// Permite enviar el borrador de presupuesto al siguiente Nivel 
        /// </summary>
        /// <param name="presup">Presupuesto que se quiere llevar al siguiente nivel</param>
        /// <returns></returns>
        public Boolean enviarPresupuestoAprobacion(Presupuesto presup)
        {
            DAOPresupuesto dao = new DAOPresupuesto();
            return dao.enviarPresupuestoAprobacion(presup);
        }

        /// <summary>
        /// Rechaza el presupuesto en el nivel Actual y genera una nueva version del mismo
        /// </summary>
        /// <param name="presup">presupuesto a Rechazar</param>
        /// <returns></returns>
        public Boolean rechazarPresupuesto(Presupuesto presup)
        {
            DAOPresupuesto dao = new DAOPresupuesto();
            return dao.rechazarPresupuesto(presup);
        }

        public DetalleVersion getObservacionesDetalle(int idDetalle)
        {
            DAOPresupuesto dao = new DAOPresupuesto();
            return dao.getObservacionesDetalle(idDetalle);
        }

        public List<Prioridad> getPrioridades()
        {
            DAOPresupuesto dao = new DAOPresupuesto();
            return dao.getPrioridades();
        }

        public bool ObservarDetalle(int idDetalle, string observacion,string usuario) {
            DAOPresupuesto dao = new DAOPresupuesto();
            return dao.ObservarDetalle(idDetalle,observacion, usuario);
        }

        public List<DetallePresupuesto> getPresupuestoTipos(int id)
        {
            DAOPresupuesto dao = new DAOPresupuesto();
            return dao.getPresupuestosTipos(id);
        }
        public List<DetallePresupuesto> getPresupuestoTiposArea(int id,int idArea)
        {
            DAOPresupuesto dao = new DAOPresupuesto();
            return dao.getPresupuestosTiposArea(id,idArea);
        }
        public bool ResolverObservacion(int idObservacion, string observacion,string usuario) {
            DAOPresupuesto dao = new DAOPresupuesto();
            return dao.ResolverObservacion(idObservacion, observacion, usuario);
        }

        public Sede getPresupuestosPorSede(int idSede) {

            DAOPresupuesto dao = new DAOPresupuesto();
            return dao.getPresupuestosPorSede(idSede);
        }

        public List<DetalleVersion> getDetallesDeUltimaVersion(int DetallePresup) {

            DAOPresupuesto dao = new DAOPresupuesto();
            return dao.getDetallesDeUltimaVersion(DetallePresup);
        }

        public List<DetallePresupuesto> getPresupuestosTipos(int idPresupuesto)
        {
            DAOPresupuesto dao = new DAOPresupuesto();
            return dao.getPresupuestosTipos(idPresupuesto);

        }

        public List<Presupuesto> getPresupuestosPorSedeLista(int idSede,int idArea) {

            DAOPresupuesto dao = new DAOPresupuesto();
            return dao.getPresupuestosPorSedeLista(idSede,idArea);
        }

        public Presupuesto AprobacionesPresupuesto(int idPresupuesto) {
            DAOPresupuesto dao = new DAOPresupuesto();
            Presupuesto presup = dao.getPresupuesto(idPresupuesto);
            presup.aprobaciones=dao.AprobacionesPresupuesto(idPresupuesto);
            return presup;

        }

        public Observacion getObservacion(int idObservacion)
        {
            DAOPresupuesto dao = new DAOPresupuesto();
            return dao.getObservacion(idObservacion);
        }

        public int EliminarDetalle(int idDetalle)
        {
            DAOPresupuesto dao = new DAOPresupuesto();
            return dao.EliminarDetalle(idDetalle);
        }

        public int CrearPresup(string nombre, int idSede, string usuario, int mesDesde, int anioDesde, int mesHasta, int anioHasta)
        {
            DAOPresupuesto dao = new DAOPresupuesto();
            return dao.CrearPresup(nombre,idSede,usuario,mesDesde,anioDesde,mesHasta,anioHasta);
        }

        public List<Sede> getSedes()
        {
            DAOPresupuesto dao = new DAOPresupuesto();
            return dao.getSedes();
        }

        public int AprobarDetalle(int idDetalle, Aprobacion.estados aprobado, string usuario)
        {
            DAOPresupuesto dao = new DAOPresupuesto();
            return dao.AprobarDetalle(idDetalle,aprobado,usuario);
        }

        public List<DetalleAprobacion> getDetallesAprobacion(int idAprobacion)
        {
            DAOPresupuesto dao = new DAOPresupuesto();
            return dao.getDetallesAprobacion(idAprobacion);

        }

        public int EnviarAprobacion(int id, string usuario)
        {
            DAOPresupuesto dao = new DAOPresupuesto();
            return dao.EnviarAprobacion(id,  usuario);
        }

        public int AprobarVersion(int id, string usuario)
        {
            DAOPresupuesto dao = new DAOPresupuesto();
            return dao.AprobarVersion(id, usuario);
        }

        public int RechazarVersion(int id, string usuario)
        {
            DAOPresupuesto dao = new DAOPresupuesto();
            return dao.RechazarVersion(id, usuario);
        }

        public DetalleVersion getAprobacionesDetalleVersion(int idDetalleVersion)
        {
            DAOPresupuesto dao = new DAOPresupuesto();
            return dao.getAprobacionesDetalleVersion(idDetalleVersion);
        }

        public Entidades.Version getAprobacionesVersion(int idVersion)
        {
            DAOPresupuesto dao = new DAOPresupuesto();
            return dao.getAprobacionesVersion(idVersion);
        }

        public DetallePresupuesto getAprobacionesDetallePresupuesto(int idDetallePresupuesto)
        {
            DAOPresupuesto dao = new DAOPresupuesto();
            return dao.getAprobacionesDetallePresupuesto(idDetallePresupuesto);

        }
        public Presupuesto getAprobacionesPresupuesto(int idPresupuesto)
        {
            DAOPresupuesto dao = new DAOPresupuesto();
            return dao.getAprobacionesPresupuesto(idPresupuesto);
        }

        public int AgregarAprobPresup(int id, int idOrden, string idUsuario, string usuario)
        {
            DAOPresupuesto dao = new DAOPresupuesto();
            return dao.AgregarAprobPresup(id,idOrden,idUsuario,usuario);
        }

        public int AprobarPresupuesto(int id,  string usuario)
        {
            DAOPresupuesto dao = new DAOPresupuesto();
            return dao.AprobarPresupuesto(id,  usuario);
        }

        public int DesAprobarPresupuesto(int id, string usuario)
        {
            DAOPresupuesto dao = new DAOPresupuesto();
            return dao.DesAprobarPresupuesto(id, usuario);
        }

        public int AgregarAprobVersion(int id, int idOrden, string idUsuario, string usuario)
        {
            DAOPresupuesto dao = new DAOPresupuesto();
            return dao.AgregarAprobVersion(id, idOrden, idUsuario, usuario);
        }

        public int nuevaVersion(int id, int idArea,string usuario)
        {
            DAOPresupuesto dao = new DAOPresupuesto();
            return dao.nuevaVersion(id, idArea,usuario);
        }
    }
    }

