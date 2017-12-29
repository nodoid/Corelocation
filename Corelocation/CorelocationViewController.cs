using System;
using CoreLocation;
using MapKit;
using SystemConfiguration;
using UIKit;

namespace Corelocation
{
    class BasicMapAnnotation : MKAnnotation
    {
        CLLocationCoordinate2D coord;
        string title, subtitle;

        public override CLLocationCoordinate2D Coordinate { get { return coord; } }
        public override void SetCoordinate(CLLocationCoordinate2D value)
        {
            coord = value;
        }
        public override string Title => title;
        public override string Subtitle => subtitle;

        public BasicMapAnnotation(CLLocationCoordinate2D coordinate, string ti, string sub)
        {
            coord = coordinate;
            title = ti;
            subtitle = sub;
        }
    }

    public partial class CorelocationViewController : UIViewController
    {
        static bool UserInterfaceIdiomIsPhone
        {
            get { return UIDevice.CurrentDevice.UserInterfaceIdiom == UIUserInterfaceIdiom.Phone; }
        }

        public CorelocationViewController()
            : base(UserInterfaceIdiomIsPhone ? "CorelocationViewController_iPhone" : "CorelocationViewController_iPad", null)
        {
        }

        public override void DidReceiveMemoryWarning()
        {
            // Releases the view if it doesn't have a superview.
            base.DidReceiveMemoryWarning();

            // Release any cached data, images, etc that aren't in use.
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            NetworkReachability reach = new NetworkReachability("www.bbc.co.uk");
            NetworkReachabilityFlags flags = new NetworkReachabilityFlags();
            reach.TryGetFlags(out flags);
            if ((flags & NetworkReachabilityFlags.IsWWAN) == NetworkReachabilityFlags.IsWWAN)
                Console.WriteLine("Using IsWann");
            else
                Console.WriteLine("Network flag = {0}", flags.ToString());

            mapViewer.MapType = MKMapType.Standard;
            mapViewer.Region = new MKCoordinateRegion(new CLLocationCoordinate2D(53.431, -2.956),
                                                      new MKCoordinateSpan(.01, .01));
            mapViewer.ZoomEnabled = true;
            mapViewer.ScrollEnabled = true;
            mapViewer.ShowsUserLocation = true;
            mapType.ValueChanged += delegate
            {
                switch (mapType.SelectedSegment)
                {
                    case 0:
                        mapViewer.MapType = MKMapType.Standard;
                        break;
                    case 1:
                        mapViewer.MapType = MKMapType.Satellite;
                        break;
                    case 2:
                        mapViewer.MapType = MKMapType.Hybrid;
                        break;
                }
            };

            var annotation = new BasicMapAnnotation(new CLLocationCoordinate2D(53.431, -2.956), "Anfield stadium", "Home of Liverpool FC");

            mapViewer.AddAnnotation(annotation);
        }
    }
}

