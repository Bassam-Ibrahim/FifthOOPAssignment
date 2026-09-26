using System;
using System.Collections.Generic;
using System.Text;

namespace FifthOOPAssignment
{
    public abstract partial class Shipment
    {
        partial void OnTrackingStatusChanged(string newStatus)
        {
            Console.WriteLine($"Tracking status changed to: {newStatus}");
        }
    }
}
