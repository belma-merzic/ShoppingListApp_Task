using System;
using System.Collections.Generic;

namespace ShoppingListApp_API.Services.Database;

public partial class Item
{
    public int ItemId { get; set; }

    public string? ItemName { get; set; }


    public virtual ICollection<ShoppingList> ShoppingLists { get; set; } = new List<ShoppingList>();
}
