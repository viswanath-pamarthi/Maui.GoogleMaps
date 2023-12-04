﻿using Android.Gms.Maps.Model;
using Com.Google.Maps.Android.Clustering;
using NativeBitmapDescriptor = Android.Gms.Maps.Model.BitmapDescriptor;

namespace Maui.GoogleMaps.Platforms.Logics.Android
{
    public class ClusteredMarker : Java.Lang.Object, IClusterItem
    {
        public LatLng Position { get; set; }

        public float Alpha { get; set; }

        public bool Draggable { get; set; }

        public bool Flat { get; set; }

        public string Id { get; set; }

        public bool IsInfoWindowShown { get; set; }

        public float Rotation { get; set; }

        public string Snippet { get; set; }

        public string Title { get; set; }

        public bool Visible { get; set; }

        public float AnchorX { get; set; }

        public float AnchorY { get; set; }

        public float InfoWindowAnchorX { get; set; }

        public float InfoWindowAnchorY { get; set; }

        public NativeBitmapDescriptor Icon { get; set; }

        public int ZIndex { get; set; }

        public ClusteredMarker(Pin outerItem)
        {
            Id = Guid.NewGuid().ToString();
            Position = new LatLng(outerItem.Position.Latitude, outerItem.Position.Longitude);
            Title = outerItem.Label;
            Snippet = outerItem.Address;
            Draggable = outerItem.IsDraggable;
            Rotation = outerItem.Rotation;
            AnchorX = (float)outerItem.Anchor.X;
            AnchorY = (float)outerItem.Anchor.Y;
            InfoWindowAnchorX = (float)outerItem.InfoWindowAnchor.X;
            InfoWindowAnchorY = (float)outerItem.InfoWindowAnchor.Y;
            Flat = outerItem.Flat;
            Alpha = 1f - outerItem.Transparency;
            Visible = outerItem.IsVisible;
            ZIndex = outerItem.ZIndex;
        }
    }
}
