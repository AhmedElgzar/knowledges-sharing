using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bitrack.Domain.Experiments
{
    public class ExperimentVariationLog : IEntity
    {
        public int ID { get; set; }
        public DateTime TimeStamp { get; set; }
        public int ExperimentVariationID { get; set; }

        [ForeignKey("ExperimentVariationID")]
        public ExperimentVariation ExperimentVariation { get; set; }
    }
}
