using System;
using System.Collections.Generic;

#nullable disable

namespace YalaJeye.DAL.Models
{
    public partial class ItemIngredient
    {
        public int Id { get; set; }
        public string ItemIngredientName { get; set; }
        public int ItemId { get; set; }

        public virtual Item Item { get; set; }
    }
}
