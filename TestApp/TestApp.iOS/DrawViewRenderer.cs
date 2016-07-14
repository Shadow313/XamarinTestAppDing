// Copyright (c) 2016 Tunnelsoft
using System;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(TestApp.DrawView), typeof(TestApp.iOS.DrawViewRenderer))]

namespace TestApp.iOS
{
    class DrawViewRenderer : ViewRenderer<DrawView, NativeDrawView>
    {
        public DrawViewRenderer()
        {
        }

        protected override void OnElementChanged(ElementChangedEventArgs<DrawView> e)
        {
            base.OnElementChanged(e);

            if (Control == null)
                SetNativeControl(new NativeDrawView(Element));
        }
    }
}