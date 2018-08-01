using DataModel.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper; 
using BusinessEntities;
using DataModel;
using System.Transactions; 



namespace BusinessServices
{
    public class CargosServices :  ICargoServices
    {
        private readonly UnitOfWork _unitOfWork;

        public CargosServices(UnitOfWork unitOfWork )
        {
            _unitOfWork = unitOfWork;
        }

        public CargosServices()
        {

        }
        public CargosEntity GetCargoById(int cargoid)
        {
            var cargo = _unitOfWork.CargosRepository.GetById(cargoid);

            if (cargo != null)
            {
                Mapper.CreateMap<Cargos, CargosEntity>();

                var cargoModel = Mapper.Map<Cargos, CargosEntity>(cargo);

                return cargoModel;

            }

            return null;
        }



        public IEnumerable<CargosEntity> GetAllCargos()
        {
            var cargos = _unitOfWork.CargosRepository.GetAll().ToList();
            if (cargos.Any())
            { 
                Mapper.CreateMap<Cargos, CargosEntity>();
                var cargosModel = Mapper.Map<List<Cargos>, List<CargosEntity>>(cargos);
                return cargosModel;
             }
            return null;
        }

        public int CreateCargo(CargosEntity cargoEntity)
        {
           using (var scope = new TransactionScope ())
           {
            var cargo = new Cargos
            {
                cgoDescripcion = cargoEntity.cgoDescripcion
            };
            _unitOfWork.CargosRepository.Insert(cargo);
            _unitOfWork.Save();
            scope.Complete();
            return cargo.cgoCargoId;
           } 
        }

        public bool UpdateCargo(int cargoid, CargosEntity cargoEntity)
        {
            var success = false;
            if (cargoEntity != null)
            {
                using (var scope = new TransactionScope())
                {
                    var cargo = _unitOfWork.CargosRepository.GetById(cargoid);
                    if (cargo != null)
                    {
                        cargo.cgoDescripcion = cargoEntity.cgoDescripcion;
                        _unitOfWork.CargosRepository.Update(cargo);
                        _unitOfWork.Save();
                        scope.Complete();
                        success = true;
                    }
                }
            }
            return success;
        }

        public bool DeleteCargo(int cargoid)
        {
            var success = false;
            if (cargoid > 0)
            {
                using (var scope = new TransactionScope())
                {
                    var cargo = _unitOfWork.CargosRepository.GetById(cargoid);
                    if (cargo != null)
                    {

                        _unitOfWork.CargosRepository.Delete(cargo);
                        _unitOfWork.Save();
                        scope.Complete();
                        success = true;
                    }
                }
            }
            return success; 
        }
    }
}
