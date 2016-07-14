// Copyright (c) 2016 Tunnelsoft
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(TestApp.DrawView), typeof(TestApp.Droid.DrawViewRenderer))]


namespace TestApp.Droid
{
    class DrawViewRenderer : ViewRenderer<DrawView, NativeDrawView>
    {
        NativeDrawView view;

        protected override void OnElementChanged(ElementChangedEventArgs<DrawView> e)
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