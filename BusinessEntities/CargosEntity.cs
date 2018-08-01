using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntities
{
    public class CargosEntity
    {
        public int cgoCargoId { get; set; }
        public string cgoDescripcion { get; set; }
        public Nullable<int> tpcTipoCargoId { get; set; }
        public Nullable<bool> cgoEsConfidencial { get; set; }
        public Nullable<bool> cgoPersonalACargo { get; set; }
        public Nullable<bool> cgoAnulado { get; set; }
        public Nullable<int> nvlNivelId { get; set; }
    }
}
