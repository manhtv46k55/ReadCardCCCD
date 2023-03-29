using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ReadCard.Data.Entities
{
    public class faceImage
    {
        public int mDensity { get; set; }
        public int mHeight { get; set; }
        public bool mIsMutable { get; set; }
        public string mNativePtr { get; set; }
        public bool mRecycled { get; set; }
        public bool mRequestPremultiplied { get; set; }
        public int mWidth { get; set; }
    }
}