using System;
using System.Collections.Generic;
using System.Linq;

using Foundation;
using UIKit;

namespace LoginScreen.iOS
{
	[Register("AppDelegate")]
	public partial class AppDelegate : global::Xamarin.Forms.Platform.iOS.FormsApplicationDelegate
	{
		public override bool FinishedLaunching(UIApplication app, NSDictionary options)
		{
			#if ENABLE_TEST_CLOUD
			Xamarin.Calabash.Start();
			#endif

			global::Xamarin.Forms.Forms.Init();

			UINavigationBar.Appearance.BarTintColor = UIColor.FromRGB(25, 118, 210);
			UINavigationBar.Appearance.SetTitleTextAttributes(new UITextAttributes()
			{
				//Font = UIFont.FromName("HelveticaNeue-Light", (nfloat)20f),
				TextColor = UIColor.White
			});

			LoadApplication(new App());

			return base.FinishedLaunching(app, options);
		}
	}
}

