using System;
using System.Collections.Generic;

namespace ShoppingListApp_API.Services.Database;

public partial class Shopper
{
    public int ShopperId { get; set; }

    public string? ShopperName { get; set; }

    public virtual ICollection<ShoppingList> ShoppingLists { get; set; } = new List<ShoppingList>();
}
