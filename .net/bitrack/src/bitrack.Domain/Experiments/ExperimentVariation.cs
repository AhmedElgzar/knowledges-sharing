using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bitrack.Domain.Experiments
{
    public class ExperimentVariation : IEntity
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int ExperimentID { get; set; }

        [ForeignKey("ExperimentID")]
        public Experiment Experiment { get; set; }

        public virtual List<ExperimentVariationLog> ExperimentVariationLogs { get; set; }

        public void AddLog(ExperimentVariationLog log)
        {
            ExperimentVariationLogs.Add(log);
        }
    }
}
