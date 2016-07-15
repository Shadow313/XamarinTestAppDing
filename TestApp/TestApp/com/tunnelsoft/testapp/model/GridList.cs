// Copyright (c) 2016 Tunnelsoft
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace com.tunnelsoft.testapp.model {
    public class GridList {
        readonly ObservableCollection<ListEntry> entrys;
        const int entryCount = 1000;

        public GridList() {
            this.entrys = new ObservableCollection<ListEntry>();
            GenerateEntrys();
        }

        public GridList(ListEntry newItem) {
            this.entrys = new ObservableCollection<ListEntry>();
            entrys.Add(newItem);
        }

        public GridList(List<ListEntry> newItems) {
            this.entrys = new ObservableCollection<ListEntry>();
            foreach (ListEntry curEntry in newItems) {
                entrys.Add(curEntry);
            }
        }

        public ObservableCollection<ListEntry> Entrys {
            get { return entrys; }
        }

        void GenerateEntrys() {
            DateTime baseDate = DateTime.Now;
            for (int i = 0; i < entryCount; i++) {
                ListEntry newEntry = new ListEntry(i, "Item " + i, baseDate.AddDays(i));
                entrys.Add(newEntry);
            }
        }

        internal void Add(ListEntry newItem) {
            entrys.Add(newItem);
        }

        internal void Add(List<ListEntry> newItems) {
            foreach (ListEntry curEntry in newItems) {
                entrys.Add(curEntry);
            }
        }
    }
}
