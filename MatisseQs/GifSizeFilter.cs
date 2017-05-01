using System.Collections.Generic;
using Android.Content;
using Com.Zhihu.Matisse;
using Com.Zhihu.Matisse.Filter;
using Com.Zhihu.Matisse.Internal.Entity;
using Com.Zhihu.Matisse.Internal.Utils;

namespace MatisseQs
{
    public class GifSizeFilter : Filter
    {
        private int mMinWidth;
        private int mMinHeight;
        private int mMaxSize;



        public GifSizeFilter(int minWidth, int minHeight, int maxSizeInBytes)
        {
            mMinWidth = minWidth;
            mMinHeight = minHeight;
            mMaxSize = maxSizeInBytes;
        }

        protected override ICollection<MimeType> ConstraintTypes() {
            return new List<MimeType> { 
                MimeType.Gif
            };
        }

        public override IncapableCause InvokeFilter(Context p0, Item p1) {
            if (!NeedFiltering(p0, p1)) {
                return null;
            }

            var size = PhotoMetadataUtils.GetBitmapBound(p0.ContentResolver, p1.ContentUri);

            if (size.X < mMinWidth || size.Y < mMinHeight || p1.Size > mMaxSize) {
                //var msg = p0.GetString(Resource.String.error_gif, mMinWidth, PhotoMetadataUtils.GetSizeInMB(mMaxSize));
                //return new IncapableCause(IncapableCause.Dialog, msg);
            }

            return null;
        }


        //public Set<MimeType> constraintTypes()
        //{
        //    //        return new HashSet<MimeType>() {{
        //    //        add(MimeType.GIF);
        //    //    }
        //    //};
        //}

        //public IncapableCause filter(Context context, Item item)
        //{
        //    //    if (!needFiltering(context, item))
        //    //        return null;

        //    //    Point size = PhotoMetadataUtils.getBitmapBound(context.getContentResolver(), item.getContentUri());
        //    //    if (size.x < mMinWidth || size.y < mMinHeight || item.size > mMaxSize)
        //    //    {
        //    //        return new IncapableCause(IncapableCause.DIALOG, context.getString(R.string.error_gif, mMinWidth,
        //    //                String.valueOf(PhotoMetadataUtils.getSizeInMB(mMaxSize))));
        //    //    }
        //    //    return nu    }

        //}
    }
}
