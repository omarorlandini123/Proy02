using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;
namespace DataAccess
{
    public class DAOArea
    {

        public Area getArea(int idArea)
        {
            List<Area> areas = new List<Area>();
            Area area = new Area();
            area.codArea = "1";
            area.desArea = "Sistemas";
            areas.Add(area);
            Area area1 = new Area();
            area1.codArea = "2";
            area1.desArea = "Contabilidad";
            areas.Add(area1);

            foreach (Area a in areas)
            {
                if (int.Parse(a.codArea) == idArea) {
                    return a;
                }
            }
            return null;
        }

        public List<Area> getAreas(int idSede) {
            List<Area> listaRpta = new List<Area>();
            return listaRpta;
        }


    }
}
