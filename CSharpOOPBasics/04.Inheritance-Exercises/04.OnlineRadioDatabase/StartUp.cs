using System;

public class StartUp
{
    static void Main(string[] args)
    {
        var n = int.Parse(Console.ReadLine());

        RadioDatabase radio = new RadioDatabase();

        for (int i = 0; i < n; i++)
        {
            Song song = null;
            try
            {
                GetSong(out song);
            }
            catch (InvalidSongException ex)
            {
                Console.WriteLine(ex.Message);
                continue;
            }

            radio.AddSong(song);
            Console.WriteLine("Song added.");
        }
        Console.WriteLine(radio);
    }

    private static void GetSong(out Song song)
    {
        song=null;
        var data = Console.ReadLine().Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries);
        if (data.Length != 3)
        {
            throw new InvalidSongException();
        }
        var artist = data[0];
        var songName = data[1];
        var songLength = data[2].Split(new char[] { ':' }, StringSplitOptions.RemoveEmptyEntries);
        var songMinutes = 0;
        var songSeconds = 0;

        if (songLength.Length != 2)
        {
            throw new InvalidSongLengthException();
        }
        try
        {
            songMinutes = int.Parse(songLength[0]);
            songSeconds = int.Parse(songLength[1]);
        }
        catch (Exception)
        {

            throw new InvalidSongLengthException();
        }
        song = new Song(artist, songName, songSeconds, songMinutes);
       
    }
}

