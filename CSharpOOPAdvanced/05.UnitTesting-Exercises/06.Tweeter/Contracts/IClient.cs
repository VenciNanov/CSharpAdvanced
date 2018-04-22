using System;
using System.Collections.Generic;
using System.Text;

public interface IClient
{
    IList<ITweet> Tweets { get; set; }

    string ShowLastTweet();
    string Tweet(ITweet tweet);
}
