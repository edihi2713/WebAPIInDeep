using BusinessEntities;
using BusinessServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebAPI.Controllers
{
    public class CargoController : ApiController
    {

        private readonly ICargoServices _cargoServices;


        public CargoController(ICargoServices cargoServices)
        {
            _cargoServices = cargoServices;
        }

        //public CargoController()
        //{
        //    _cargoServices = new CargosServices();
        //}
        // GET api/cargo
        public HttpResponseMessage Get()
        {
            var cargos = _cargoServices.GetAllCargos();

            if (cargos != null)
            {
                var cargoEntities = cargos as List<CargosEntity> ?? cargos.ToList();

                if (cargoEntities.Any())
                {
                    return Request.CreateResponse(HttpStatusCode.OK, cargoEntities);
                }
            }

            return Request.CreateResponse(HttpStatusCode.NotFound, "No  se encontraron cargos");
        }

        // GET api/cargo/5
        public HttpResponseMessage Get(int id)
        {
            var cargo = _cargoServices.GetCargoById(id);

            if (cargo != null)
            {
                return Request.CreateResponse(HttpStatusCode.OK, cargo);
            }

            return Request.CreateResponse(HttpStatusCode.NotFound, "No se encontró el cargo solicitado");
        }

        // POST api/cargo
        public int Post([FromBody] CargosEntity cargoEntity)
        {
            return _cargoServices.CreateCargo(cargoEntity);
        }

        // PUT api/cargo/5
        public bool Put(int id, [FromBody]CargosEntity cargoEntity)
        {
            if (id > 0)
            {
                return _cargoServices.UpdateCargo(id, cargoEntity);
            }

            return false;
        }

        // DELETE api/cargo/5
        public bool Delete(int id)
        {
            if (id > 0)
            {
                return _cargoServices.DeleteCargo(id);
            }

            return false;
        }
    }
}
