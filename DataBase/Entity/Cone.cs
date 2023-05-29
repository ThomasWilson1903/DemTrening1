using System;
using System.Collections.Generic;

namespace DemTrening1.DataBase.Entity
{
    public partial class Cone
    {
        public Cone()
        {
            IngredientsHasCones = new HashSet<IngredientsHasCone>();
        }

        public int IdCones { get; set; }
        public string NumberCones { get; set; } = null!;

        public virtual ICollection<IngredientsHasCone> IngredientsHasCones { get; set; }
    }
}
