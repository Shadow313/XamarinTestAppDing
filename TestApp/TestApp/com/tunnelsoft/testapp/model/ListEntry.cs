// Copyright (c) 2016 Tunnelsoft
using System;
using System.ComponentModel;

namespace com.tunnelsoft.testapp.model {
    public class ListEntry: INotifyPropertyChanged {
        private DateTime date;
        private String value;
        private int id;
        public event PropertyChangedEventHandler PropertyChanged;

        public ListEntry(int id, String value, DateTime date) {
            this.date = date;
            this.id = id;
            this.value = value;
            if (date == null) {
                date = DateTime.Now;
            }
        }
        protected void RaisePropertyChanged(string name) {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(name));
        }

        public DateTime Date {
            get { return date; }
            set {
                if (value != null && date != value) {
                    date = value;
                    RaisePropertyChanged("Date");
                }
            }
        }

        public String Value {
            get { return value; }
            set {
                if (value != null && value != this.value) {
                    this.value = value;
                    RaisePropertyChanged("Value");
                }
            }
        }

        public int Id {
            get { return id; }
            set {
                if (value != id) {
                    id = value;
                    RaisePropertyChanged("Id");
                }
            }
        }

    }
}
