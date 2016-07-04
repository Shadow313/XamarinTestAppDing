using SkiaSharp;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace TestApp
{
    public partial class MainPage : ContentPage
    {
        private GridList list;
        public MainPage()
        {
            InitializeComponent();
            Title = "TPC Mainscreen";           
        }

        void OnDraw(object sender, EventArgs e)
        {
            if (drawView.Content == null)
            {

                drawView.Content = new DrawView();
            }
            else
            {
                drawView.Content = null;
            }


        }

        void OnLoadTableData(object sender, EventArgs e)
        {
            var watch = System.Diagnostics.Stopwatch.StartNew();
            list = new GridList();
            watch.Stop();
            loadTimeLabel.Text = "Load Time: " + watch.ElapsedMilliseconds + " ms";
        }

        async void OnShowTable(object sender, EventArgs e)
        {
            var watch = System.Diagnostics.Stopwatch.StartNew();
            var tablePage = new GridPage();
            tablePage.BindingContext = list;
            watch.Stop();
            tableLoadtimeLabel.Text = "Table Load Time: " + watch.ElapsedMilliseconds + " ms";
            await Navigation.PushAsync(tablePage);
        }
    }

    public class ListEntry: INotifyPropertyChanged
    {
        private DateTime date;
        private String value;
        private int id;
        public event PropertyChangedEventHandler PropertyChanged;

        public ListEntry(int id, String value, DateTime date)
        {
            this.date = date;
            this.id = id;
            this.value = value;
            if(date == null)
            {
                date = DateTime.Now;
            }
        }
        protected void RaisePropertyChanged(string name)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(name));
        }

        public DateTime Date
        {
            get { return date; }
            set {if(value != null && date != value)
                {
                    date = value;
                    RaisePropertyChanged("Date");
                } }
        }

        public String Value
        {
            get { return value; }
            set { if (value != null && value != this.value)
                {
                    this.value = value;
                    RaisePropertyChanged("Value");
                } }
        }

        public int Id
        {
            get { return id; }
            set { if(value != id)
                {
                    id = value;
                    RaisePropertyChanged("Id");
                } }
        }
    
   }

    public class GridList
    {
        readonly ObservableCollection<ListEntry> entrys;
        const int entryCount = 1000;
        private List<ListEntry> items;

        public GridList()
        {
            this.entrys = new ObservableCollection<ListEntry>();
            GenerateEntrys();
        }

        public GridList(List<ListEntry> items)
        {
            this.items = items;
        }

        public ObservableCollection<ListEntry> Entrys
        {
            get { return entrys; }
        }

        void GenerateEntrys()
        {
            DateTime baseDate = DateTime.Now;
            for(int i = 0; i < entryCount; i++)
            {
                ListEntry newEntry = new ListEntry(i, "Item " + i, baseDate.AddDays(i));
                entrys.Add(newEntry);
            }
        }
    }

}
