// Copyright (c) 2016 Tunnelsoft
using com.tunnelsoft.testapp.model;
using System;
using Xamarin.Forms;

namespace com.tunnelsoft.testapp.view {
    public partial class MainPage: ContentPage {
        private GridList list;
        public MainPage() {
            InitializeComponent();
            Title = "TPC Mainscreen";
        }

        void OnDraw(object sender, EventArgs e) {
            if (drawView.Content == null) {
                drawView.Content = new DrawView();
            } else {
                drawView.Content = null;
            }


        }

        async void OnLoadTableData(object sender, EventArgs e) {
            /*var testList = new ObservableCollection<ListEntry>();
            testList.Add(new ListEntry(0, "Some Value", DateTime.Now));
            testList.Add(new ListEntry(1, "Some other value", DateTime.Now));
            var json = JsonConvert.SerializeObject(testList);
            responseLabel.Text = json;*/
            var watch = System.Diagnostics.Stopwatch.StartNew();
            RestService service = new RestService();
            var newItems = await service.RefreshDataAsync();
            if (list == null) {
                list = new GridList(newItems);
            } else {
                list.Add(newItems);
            }
            watch.Stop();
            loadTimeLabel.Text = "Load Time: " + watch.ElapsedMilliseconds + " ms";
        }

        async void OnShowTable(object sender, EventArgs e) {
            var watch = System.Diagnostics.Stopwatch.StartNew();
            var tablePage = new GridPage();
            tablePage.BindingContext = list;
            watch.Stop();
            tableLoadtimeLabel.Text = "Table Load Time: " + watch.ElapsedMilliseconds + " ms";
            await Navigation.PushAsync(tablePage);
        }

        async void OnShowList(object sender, EventArgs e) {
            var watch = System.Diagnostics.Stopwatch.StartNew();
            var listPage = new ListView();
            listPage.BindingContext = list;
            watch.Stop();
            tableLoadtimeLabel.Text = "List Load Time: " + watch.ElapsedMilliseconds + " ms";
            await Navigation.PushAsync(listPage);
        }
    }
}
