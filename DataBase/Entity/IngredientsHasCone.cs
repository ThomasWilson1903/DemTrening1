using System;
using System.Collections.Generic;

namespace DemTrening1.DataBase.Entity
{
    public partial class IngredientsHasCone
    {
        public int IngredientsIdingredients { get; set; }
        public int ConesIdCones { get; set; }
        public DateOnly Date { get; set; }
        public TimeOnly Time { get; set; }
        public int Worker { get; set; }
        public int Id { get; set; }

        public virtual Cone ConesIdConesNavigation { get; set; } = null!;
        public virtual Ingredient IngredientsIdingredientsNavigation { get; set; } = null!;
        public virtual Worker WorkerNavigation { get; set; } = null!;
    }
}
