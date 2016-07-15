// Copyright (c) 2016 Tunnelsoft
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace com.tunnelsoft.testapp.view
{
    public partial class ListView : ContentPage
    {
        public ListView()
        {
            InitializeComponent();
            ItemView.SeparatorColor = Color.FromRgb(30, 139, 91);
        }
    }
}
