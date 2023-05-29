using System;
using System.Collections.Generic;

namespace DemTrening1.DataBase.Entity
{
    public partial class Ingredient
    {
        public Ingredient()
        {
            IngredientsHasCones = new HashSet<IngredientsHasCone>();
        }

        public int Idingredients { get; set; }
        public string Name { get; set; } = null!;

        public virtual ICollection<IngredientsHasCone> IngredientsHasCones { get; set; }
    }
}
