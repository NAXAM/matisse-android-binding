using Android.Support.V4.App;

namespace Com.Zhihu.Matisse.Internal
{
    namespace Model
    {
        public partial class AlbumPhotoCollection
        {
            public void OnLoadFinished(Android.Support.V4.Content.Loader loader, Java.Lang.Object data)
            {
                OnLoadFinished(loader, data as Android.Database.ICursor);
            }
        }
        public partial class DevicePhotoAlbumCollection
        {
            public void OnLoadFinished(Android.Support.V4.Content.Loader loader, Java.Lang.Object data)
            {
                OnLoadFinished(loader, data as Android.Database.ICursor);
            }
        }
    }
}