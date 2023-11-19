using System;
using System.Collections.Generic;

namespace ShoppingListApp_API.Services.Database;

public partial class ShoppingList
{
    public int ShoppingListId { get; set; }

    public int? ShopperId { get; set; }

    public int? ItemId { get; set; }

    public virtual Item? Item { get; set; }

    public virtual Shopper? Shopper { get; set; }
}
