// Copyright (c) 2016 Tunnelsoft
using System;
using Android.Views;
using Android.Graphics;
using SkiaSharp;

namespace TestApp.Droid
{
    internal class NativeDrawView : View
    {
        private Bitmap bitmap;
        readonly DrawView drawView;

        public NativeDrawView(Android.Content.Context context, DrawView drawView) : base(context)
        {
            this.drawView = drawView;
        }

        protected override void OnDraw(Android.Graphics.Canvas canvas)
        {
            base.OnDraw(canvas);

            if (bitmap == null || bitmap.Width != canvas.Width || bitmap.Height != canvas.Height)
            {
                if (bitmap != null)
                    bitmap.Dispose();

                bitmap = Bitmap.CreateBitmap(canvas.Width, canvas.Height, Bitmap.Config.Argb8888);
            }

            try
            {
                using (var surface = SKSurface.Create(canvas.Width, canvas.Height, SKColorType.Rgba_8888, SKAlphaType.Premul, bitmap.LockPixels(), canvas.Width * 4))
                {
                    var skcanvas = surface.Canvas;
                    skcanvas.Scale(((float)canvas.Width) / (float)drawView.Width, ((float)canvas.Height) / (float)drawView.Height);
                    drawView.SendDraw(skcanvas);
                }
            }
            finally
            {
                bitmap.UnlockPixels();
            }

            canvas.DrawBitmap(bitmap, 0, 0, null);
        }
    }
}