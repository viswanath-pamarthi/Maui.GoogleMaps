﻿using Android.Graphics;
using AndroidBitmapDescriptor = Android.Gms.Maps.Model.BitmapDescriptor;
using AndroidBitmapDescriptorFactory = Android.Gms.Maps.Model.BitmapDescriptorFactory;

namespace Maui.GoogleMaps.Android.Factories
{
    public sealed class DefaultBitmapDescriptorFactory : IBitmapDescriptorFactory
    {
        private static readonly Lazy<DefaultBitmapDescriptorFactory> _instance
            = new Lazy<DefaultBitmapDescriptorFactory>(() => new DefaultBitmapDescriptorFactory());

        public static DefaultBitmapDescriptorFactory Instance
        {
            get { return _instance.Value; }
        }
        
        private DefaultBitmapDescriptorFactory()
        {
        }
        
        public AndroidBitmapDescriptor ToNative(BitmapDescriptor descriptor)
        {
            switch (descriptor.Type)
            {
                case BitmapDescriptorType.Default:
                    return AndroidBitmapDescriptorFactory.DefaultMarker((float)((descriptor.Color.GetHue() * 360f) % 360f));
                case BitmapDescriptorType.Bundle:
                    var context = MauiGoogleMaps.Context;
                    var resourceId = context.Resources.GetIdentifier(descriptor.BundleName, "drawable", context.PackageName);
                    return AndroidBitmapDescriptorFactory.FromResource(resourceId);
                case BitmapDescriptorType.Stream:
                    if (descriptor.Stream.CanSeek && descriptor.Stream.Position > 0)
                    {
                        descriptor.Stream.Position = 0;
                    }
                    return AndroidBitmapDescriptorFactory.FromBitmap(BitmapFactory.DecodeStream(descriptor.Stream));
                case BitmapDescriptorType.AbsolutePath:
                    return AndroidBitmapDescriptorFactory.FromPath(descriptor.AbsolutePath);
                default:
                    return AndroidBitmapDescriptorFactory.DefaultMarker();
            }
        }
    }
}
