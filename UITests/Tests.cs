using System;
using System.IO;
using System.Linq;
using NUnit.Framework;
using Xamarin.UITest;
using Xamarin.UITest.Queries;

namespace UITests
{
	[TestFixture(Platform.Android)]
	[TestFixture(Platform.iOS)]
	public class Tests
	{
		IApp app;
		Platform platform;

		public Tests(Platform platform)
		{
			this.platform = platform;
		}

		[SetUp]
		public void BeforeEachTest()
		{
			app = AppInitializer.StartApp(platform);
		}

		[Test]
		public void AppLaunches()
		{
			app.Screenshot("First screen.");
		}

		[Test]
		public void FullTestRun()
		{
			app.Tap(x => x.Class("AppCompatButton").Text("Login"));
			app.Screenshot("Tapped on view with class: AppCompatButton");
			app.Tap(x => x.Id("agentWebView").Css("#cred_userid_inputtext"));
			app.Screenshot("Tapped on view with class: WebView marked: Web View");
			app.EnterText(x => x.Id("agentWebView").Css("#cred_userid_inputtext"), "james@loginappexample.onmicrosoft.com");
			app.Tap(x => x.Id("agentWebView").Css("#cred_password_inputtext"));
			app.Screenshot("Tapped on view with class: WebView marked: Web View");
			app.EnterText(x => x.Id("agentWebView").Css("#cred_password_inputtext"), "Password1");
			app.Tap(x => x.Id("agentWebView").Css("#cred_sign_in_button"));
			app.Screenshot("Tapped on view with class: WebView marked: Web View");
			app.Tap(x => x.Text("Get Data"));
			app.Screenshot("Tapped on view with class: AppCompatButton");
		}

	}
}

