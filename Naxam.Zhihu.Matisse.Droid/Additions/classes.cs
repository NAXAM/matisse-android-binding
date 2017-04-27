namespace Com.Zhihu.Matisse.Internal.Model
{
    public partial class AlbumCollection
    {
        public void OnLoadFinished(Android.Support.V4.Content.Loader loader, Java.Lang.Object data)
        {
            OnLoadFinished(loader, data as Android.Database.ICursor);
        }
    }

    public partial class AlbumMediaCollection
    {
        public void OnLoadFinished(Android.Support.V4.Content.Loader loader, Java.Lang.Object data)
        {
            OnLoadFinished(loader, data as Android.Database.ICursor);
        }
    }
}