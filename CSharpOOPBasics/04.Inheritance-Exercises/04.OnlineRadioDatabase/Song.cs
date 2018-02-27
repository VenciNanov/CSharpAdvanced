using System;
using System.Collections.Generic;
using System.Text;

public class Song
{
    private string artistName;
    private string songName;
    private int songSeconds;
    private int songMinutes;

    

    public int SongMinutes
    {
        get { return this.songMinutes; }
        set {
            if (value<0||value>14)
            {
                throw new InvalidSongMinutesException();
            }
            this.songMinutes = value; }
    }


    public int SongSeconds
    {
        get { return this.songSeconds; }
        set {
            if (value<0||value>59)
            {
                throw new InvalidSongSecondsException();
            }
            this.songSeconds = value; }
    }


    public string SongName
    {
        get { return this.songName; }
        set {
            if (value.Length < 3 || value.Length > 20 || value == null)
            {
                throw new InvalidSongNameException();
            }
            this.songName = value; }
    }

    public string ArtistName
    {
        get { return this.artistName; }
        set
        {
            if (value.Length < 3 || value.Length > 20 || value == null)
            {
                throw new InvalidArtistNameException();
            }
            this.artistName = value;
        }
    }

    public Song(string artistName, string songName, int songSeconds, int songMinutes)
    {
        ArtistName = artistName;
        SongName = songName;
        SongMinutes = songMinutes;
        SongSeconds = songSeconds;
    }

}
