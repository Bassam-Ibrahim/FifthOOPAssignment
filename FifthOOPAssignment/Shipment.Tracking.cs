using System;
using System.Collections.Generic;
using System.Text;

namespace FifthOOPAssignment
{
    public abstract partial class Shipment
    {
        private string trackingStatus = "In Transit";

        public string TrackingStatus
        {
            get { return trackingStatus; }
            private set { trackingStatus = value; }
        }

        public void UpdateTrackingStatus(string newStatus)
        {
            if (string.IsNullOrWhiteSpace(newStatus))
                return;

            trackingStatus = newStatus;
            OnTrackingStatusChanged(newStatus);
        }

        partial void OnTrackingStatusChanged(string newStatus);
    }
}
