﻿using System;
using System.Collections.Generic;

namespace StoreLibrary.Models;

public partial class PickupPoint
{
    public int PickupPointId { get; set; }

    public int PostalCode { get; set; }

    public string City { get; set; } = null!;

    public string Street { get; set; } = null!;

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
}
