using System;
using System.Collections.Generic;
using System.Text;

namespace P01.Stream_Progress
{
    public interface IStreamProggres
    {
        int BytesSent { get; }
        int Lenght { get; }

    }
}
