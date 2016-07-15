// Copyright (c) 2016 Tunnelsoft
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using com.tunnelsoft.testapp.view;

[assembly: ExportRenderer(typeof(com.tunnelsoft.testapp.view.DrawView), typeof(TestApp.Droid.DrawViewRenderer))]


namespace TestApp.Droid
{
    class DrawViewRenderer : ViewRenderer<com.tunnelsoft.testapp.view.DrawView, NativeDrawView>
    {
        NativeDrawView view;

        protected override void OnElementChanged(ElementChangedEventArgs<com.tunnelsoft.testapp.view.DrawView> e)
        {
            base.OnElementChanged(e);

            if(Control == null)
            {
                view = new NativeDrawView(Context, Element);
                SetNativeControl(view);
            }
        }
    }
}