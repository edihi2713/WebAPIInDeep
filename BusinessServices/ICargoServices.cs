using BusinessEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessServices
{
    public interface ICargoServices
    {
        CargosEntity GetCargoById(int cargoid);
        IEnumerable<CargosEntity> GetAllCargos();
        int CreateCargo(CargosEntity cargoEntity);
        bool UpdateCargo(int cargoid, CargosEntity cargoEntity);
        bool DeleteCargo(int cargoid); 

    }
}
