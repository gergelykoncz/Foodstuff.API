using System;
using System.Collections.Generic;

namespace FoodStuff.Data.Entities;

public partial class BrandOwner
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public virtual ICollection<Food> Foods { get; set; } = new List<Food>();
}
