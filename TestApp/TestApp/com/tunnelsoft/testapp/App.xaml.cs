// Copyright (c) 2016 Tunnelsoft
using com.tunnelsoft.testapp.view;

using Xamarin.Forms;

namespace com.tunnelsoft.testapp {
    public partial class App: Application {
        public App() {
            InitializeComponent();

            MainPage = new NavigationPage(GetMainPage()) {
                BarBackgroundColor = Color.FromRgb(30, 139, 93)
            };
        }

        protected override void OnStart() {
            // Handle when your app starts
        }

        protected override void OnSleep() {
            // Handle when your app sleeps
        }

        protected override void OnResume() {
            // Handle when your app resumes
        }

        public static Page GetMainPage() {
            return new MainPage();
        }
    }
}
