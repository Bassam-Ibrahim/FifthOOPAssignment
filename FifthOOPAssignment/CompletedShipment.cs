using System;
using System.Collections.Generic;
using System.Text;

namespace FifthOOPAssignment
{
    public sealed class CompletedShipment : Shipment
    {
        public CompletedShipment(string trackingCode, string description,
                                 decimal weight, decimal deliveryFee,
                                 DeliveryAddress destination)
            : base(trackingCode, description, weight, deliveryFee, destination)
        {
        }

        public override decimal EstimatedCost
        {
            get { return DeliveryFee + (Weight * 5); }
        }

        public override void PrintShipment()
        {
            Console.WriteLine("Completed Shipment");
            Console.WriteLine($"Tracking Code : {TrackingCode}");
            Console.WriteLine($"Description   : {Description}");
            Console.WriteLine($"Estimated Cost: {EstimatedCost} EGP");
        }
        public override string GetTrackingStatus()
        {
            return $"Shipment {TrackingCode} is Completed.";
        }

        public override decimal CalculateInsurance()
        {
            return EstimatedCost * 0.03m; // m4 faker kanet kam %
        }
    }
}
