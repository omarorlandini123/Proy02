using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess;
using Entidades;
namespace LogicAccess
{
    public class LogicArea
    {

        public Area getArea(int codArea)
        {

            DAOArea area = new DAOArea();
            return area.getArea(codArea);
        }

        public List<Area> getAreas(int idSede)
        {
            DAOArea area = new DAOArea();
            return area.getAreas(idSede);
        }

    }
}
