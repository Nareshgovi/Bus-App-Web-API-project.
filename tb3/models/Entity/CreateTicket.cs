using System;
using System.Collections.Generic;

namespace tb3.models.Entity;

public partial class CreateTicket
{
    public int BusNo { get; set; }

    public string Name { get; set; } = null!;

    public int Age { get; set; }

    public DateOnly DateOfJourney { get; set; }

    public decimal Price { get; set; }

    public string Email { get; set; } = null!;
}
