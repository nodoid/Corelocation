// WARNING
//
// This file has been generated automatically by Xamarin Studio to store outlets and
// actions made in the UI designer. If it is removed, they will be lost.
// Manual changes to this file may not be handled correctly.
//
using Foundation;
using MapKit;
using UIKit;

namespace Corelocation
{
    [Register("CorelocationViewController")]
    partial class CorelocationViewController
    {
        [Outlet]
        UISegmentedControl mapType { get; set; }

        [Outlet]
        MKMapView mapViewer { get; set; }

        void ReleaseDesignerOutlets()
        {
            if (mapViewer != null)
            {
                mapViewer.Dispose();
                mapViewer = null;
            }

            if (mapType != null)
            {
                mapType.Dispose();
                mapType = null;
            }
        }
    }
}
