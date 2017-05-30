using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;
using Data;
using System.Data;

namespace DataAccess
{
    public class DAOMaterial
    {

        public List<Material> getPrueba() {

            List<Material> materiales = new List<Material>();
            Material mat1 = new Material();
            mat1.codProducto = "0102451234";
            mat1.desc = "Producto numero 1";
            mat1.precioUnit = 15.7;
            mat1.unidad = "Unid";
            mat1.subClase = new SubClase() { codSubClase = "02", desSubClase = "SubClase1" };
            mat1.subClase.clase = new Clase() { codClase = "01", desClase = "Clase 1" };

            Material mat2 = new Material();
            mat2.codProducto = "0102455002";
            mat2.desc = "Producto numero 2";
            mat2.precioUnit = 30.0;
            mat2.unidad = "Kg";
            mat2.subClase = new SubClase() { codSubClase = "02", desSubClase = "SubClase1" };
            mat2.subClase.clase = new Clase() { codClase = "01", desClase = "Clase 1" };

            Material mat3 = new Material();
            mat3.codProducto = "0102456778";
            mat3.desc = "Producto numero 3";
            mat3.precioUnit = 30.0;
            mat3.unidad = "Litros";
            mat3.subClase = new SubClase() { codSubClase = "03", desSubClase = "SubClase2" };
            mat3.subClase.clase = new Clase() { codClase = "02", desClase = "Clase 2" };

            materiales.Add(mat1);
            materiales.Add(mat2);
            materiales.Add(mat3);
            return materiales;
        }

        public List<Material> getMateriales(string cond) {
            List<Material> listaRpta = new List<Material>();
            try
            {
                ServicioMateriales.Material cli = new ServicioMateriales.Material();
                ServicioMateriales.material[] materiales = cli.getMaterial(cond, "0");
                
                foreach (ServicioMateriales.material mat in materiales)
                {

                    Material ma = new Material();
                    ma.codProducto = mat.codigoMaterial;
                    ma.desc = mat.descMaterial;
                    ma.precioUnit = mat.precioMaterial;
                    ma.unidad = mat.unidad;
                    ma.subClase = new SubClase();
                    ma.subClase.clase = new Clase();
                    ma.subClase.codSubClase = mat.subclase.codSubClase.ToString();
                    ma.subClase.desSubClase = mat.subclase.desSubClase;
                    ma.subClase.clase.codClase = mat.subclase.clase.codClase.ToString();
                    ma.subClase.clase.desClase = mat.subclase.clase.desClase;
                    listaRpta.Add(ma);
                }
            }
            catch (Exception s) {

            }
            
            return listaRpta;
        }

        public Material getMaterial(string codMaterial)
        {
            try
            {
                ServicioMateriales.Material cli = new ServicioMateriales.Material();
                ServicioMateriales.material[] materiales = cli.getMaterial(codMaterial, "1");
                List<Material> listaRpta = new List<Material>();
                foreach (ServicioMateriales.material mat in materiales)
                {

                    Material ma = new Material();
                    ma.codProducto = mat.codigoMaterial;
                    ma.desc = mat.descMaterial;
                    ma.precioUnit = mat.precioMaterial;
                    ma.unidad = mat.unidad;
                    ma.subClase = new SubClase();
                    ma.subClase.clase = new Clase();
                    ma.subClase.codSubClase = mat.subclase.codSubClase.ToString();
                    ma.subClase.desSubClase = mat.subclase.desSubClase;
                    ma.subClase.clase.codClase = mat.subclase.clase.codClase.ToString();
                    ma.subClase.clase.desClase = mat.subclase.clase.desClase;
                    return ma;
                }
            }
            catch (Exception s) {
            }

            return null;

            }

        public List<Material> getServicios(string cond)
        {
            List<Material> listaRpta = new List<Material>();
            try
            {
                ServicioMateriales.Material cli = new ServicioMateriales.Material();
                ServicioMateriales.material[] materiales = cli.getServicio(cond, "0");

                foreach (ServicioMateriales.material mat in materiales)
                {

                    Material ma = new Material();
                    ma.codProducto = mat.codigoMaterial;
                    ma.desc = mat.descMaterial;
                    ma.precioUnit = mat.precioMaterial;
                    ma.unidad = mat.unidad;
                    ma.subClase = new SubClase();
                    ma.subClase.clase = new Clase();
                    ma.subClase.codSubClase = mat.subclase.codSubClase.ToString();
                    ma.subClase.desSubClase = mat.subclase.desSubClase;
                    ma.subClase.clase.codClase = mat.subclase.clase.codClase.ToString();
                    ma.subClase.clase.desClase = mat.subclase.clase.desClase;
                    listaRpta.Add(ma);
                }
            }
            catch (Exception s)
            {

            }

            return listaRpta;
        }

        public Material getServicio(string codMaterial)
        {
            try
            {
                ServicioMateriales.Material cli = new ServicioMateriales.Material();
                ServicioMateriales.material[] materiales = cli.getServicio(codMaterial, "1");
                List<Material> listaRpta = new List<Material>();
                foreach (ServicioMateriales.material mat in materiales)
                {

                    Material ma = new Material();
                    ma.codProducto = mat.codigoMaterial;
                    ma.desc = mat.descMaterial;
                    ma.precioUnit = mat.precioMaterial;
                    ma.unidad = mat.unidad;
                    ma.subClase = new SubClase();
                    ma.subClase.clase = new Clase();
                    ma.subClase.codSubClase = mat.subclase.codSubClase.ToString();
                    ma.subClase.desSubClase = mat.subclase.desSubClase;
                    ma.subClase.clase.codClase = mat.subclase.clase.codClase.ToString();
                    ma.subClase.clase.desClase = mat.subclase.clase.desClase;
                    return ma;
                }
            }
            catch (Exception s)
            {
            }

            return null;

        }

    }
}
