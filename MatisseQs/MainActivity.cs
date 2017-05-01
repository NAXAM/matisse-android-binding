using System;
using Android.App;
using Android.Content.PM;
using Android.OS;
using Android.Views;
using Android.Widget;
using Plugin.Permissions;
using Plugin.Permissions.Abstractions;
using Com.Zhihu.Matisse;
using Com.Zhihu.Matisse.Engine.Impl;

namespace MatisseQs
{
    [Activity(Label = "Matisse", MainLauncher = true, Icon = "@mipmap/icon")]
    public class MainActivity : Activity, Android.Views.View.IOnClickListener
    {
        int REQUEST_CODE_CHOOSE = 1001;

        public async void OnClick(View v)
        {
            var result = await CrossPermissions.Current.CheckPermissionStatusAsync(Plugin.Permissions.Abstractions.Permission.Storage);

            if (result != PermissionStatus.Granted)
            {
                var results = await CrossPermissions.Current.RequestPermissionsAsync(Plugin.Permissions.Abstractions.Permission.Storage);
                result = results[Plugin.Permissions.Abstractions.Permission.Storage];

                if (result != PermissionStatus.Granted)
                {
                    return;
                }
            }

            switch (v.Id)
            {
                case Resource.Id.zhihu:
                    Matisse.From(this)
                    .Choose(MimeType.OfAll())
                    .Countable(true)
                    .MaxSelectable(9)
                    .AddFilter(new GifSizeFilter(320, 320, 5 * Com.Zhihu.Matisse.Filter.Filter.K* Com.Zhihu.Matisse.Filter.Filter.K))
                    .GridExpectedSize(Resources.GetDimensionPixelSize(Resource.Dimension.grid_expected_size))
                    .RestrictOrientation((int)ScreenOrientation.Portrait)
                    .ThumbnailScale(0.85f)
                    .ImageEngine(new GlideEngine())
                    .ForResult(REQUEST_CODE_CHOOSE);
                    break;

                case Resource.Id.dracula:
                    Matisse.From(this)
                    .Choose(MimeType.Of(MimeType.Jpeg, MimeType.Png))
                    .Theme(Resource.Style.Matisse_Dracula)
                    .Countable(false)
                    .MaxSelectable(9)
                    .ImageEngine(new GlideEngine())
                    .ForResult(REQUEST_CODE_CHOOSE);
                    break;
            }
        }

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);

            FindViewById<Button>(Resource.Id.zhihu).SetOnClickListener(this);
            FindViewById<Button>(Resource.Id.dracula).SetOnClickListener(this);
        }

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, Android.Content.PM.Permission[] grantResults)
        {
            Plugin.Permissions.PermissionsImplementation.Current.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }

        protected override void OnActivityResult(int requestCode, Result resultCode, Android.Content.Intent data)
        {
            base.OnActivityResult(requestCode, resultCode, data);

            if (requestCode == REQUEST_CODE_CHOOSE) {
                if (resultCode == Result.Ok) { 
                
                }
            }
        }
    }
}

