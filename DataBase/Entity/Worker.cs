using System;
using System.Collections.Generic;

namespace DemTrening1.DataBase.Entity
{
    public partial class Worker
    {
        public Worker()
        {
            IngredientsHasCones = new HashSet<IngredientsHasCone>();
        }

        public int Idworker { get; set; }
        public string SurNameWorker { get; set; } = null!;
        public string NameWorker { get; set; } = null!;
        public string DoubleName { get; set; } = null!;

        public virtual ICollection<IngredientsHasCone> IngredientsHasCones { get; set; }
    }
}
