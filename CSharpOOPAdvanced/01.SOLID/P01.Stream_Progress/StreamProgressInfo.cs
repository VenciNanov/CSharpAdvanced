using System;
using System.Collections.Generic;
using System.Text;

namespace P01.Stream_Progress
{
    public class StreamProgressInfo
    {
        private IStreamProggres iStreamProggres;

        // If we want to stream a music file, we can't
        public StreamProgressInfo(IStreamProggres iStreamProggres)
        {
            this.iStreamProggres = iStreamProggres;
        }

        public int CalculateCurrentPercent()
        {
            return (this.iStreamProggres.BytesSent * 100) / this.iStreamProggres.Length;
        }
    }
}
