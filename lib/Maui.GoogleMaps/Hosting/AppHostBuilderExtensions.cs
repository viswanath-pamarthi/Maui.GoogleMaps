using Maui.GoogleMaps.Handlers;
using Microsoft.Maui.LifecycleEvents;

namespace Maui.GoogleMaps.Hosting
{
    public static class AppHostBuilderExtensions
    {
        /// <summary>
        /// Configure MAUI maps for iOS and Android platforms from MauiProgram
        /// </summary>
        /// <param name="appBuilder">MauiAppBuilder</param>
        /// <param name="config">platform config</param>
#if ANDROID
        /// <param name="configureMapsInit">Android only, pass false if you want to configure manually in the Activity in platorms folder, MauiGoogleMaps.Init(activity, bundle, config). It is all based on the project set up. </param>
#endif
        /// <returns></returns>
        public static MauiAppBuilder UseGoogleMaps(this MauiAppBuilder appBuilder,
#if ANDROID
            Android.PlatformConfig config = null, bool configureMapsInit = true)
#elif IOS
            string iosApiKey, iOS.PlatformConfig config = null)
#endif
        {
            appBuilder.ConfigureMauiHandlers(handlers => handlers.AddTransient(typeof(Map), h => new MapHandler()))
            .ConfigureLifecycleEvents(events =>
            {
#if ANDROID
                if (configureMapsInit)
                {
                    events.AddAndroid(android => android
                    .OnCreate((activity, bundle) => MauiGoogleMaps.Init(activity, bundle, config)));
                }
#elif IOS
                events.AddiOS(ios => ios
                .WillFinishLaunching((app, options) =>
                { 
                    MauiGoogleMaps.Init(iosApiKey, config);
                    return true;
                }));
#endif
            });
            return appBuilder;
        }
    }
}
