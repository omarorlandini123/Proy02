using System.Data;
using System.Web;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Data;
using System.Configuration;
namespace AppV2.Tests
{
    [TestClass]
    public class PruebasData
    {
        [TestMethod]
        public void TestConexionBasica()
        {
            Conexion con = new Conexion(Conexion.TipoConexion.principal);
            Assert.IsNotNull(con);
            DataTable reader = con.Ejecutar("SELECT * FROM ALL_OBJECTS WHERE OBJECT_TYPE IN ('FUNCTION','PROCEDURE','PACKAGE')");
            Assert.IsNotNull(reader);
        }

        
    }
}
