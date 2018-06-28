using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ConsoleApp2
{
    class Program
    {
        static void Main(string[] args)
        {
            Entities context = new Entities();
            context.Database.Initialize(true);
            XDocument xmlReader =  XDocument.Load(@"E:\ИС 2017-2018\Летен семестър\ASP програмиране - Павлов\Финален проект 71602\MusicCatalogueV3\MusicCatalogData\DataFiles\MusicCatalogue20.xml");
            var root = xmlReader.Root.Elements();
            foreach (var item in root)
            {
                  //  Console.WriteLine(item.Element("singers").Elements());
                //parsing string value to int
                var id = int.Parse(item.Element("ID").Value);
                //Checking if entity already exists in the db
                if (context.Song.Any(x=> x.ID==id))
                {
                    var song = context.Song.First(x=>x.ID == id);
                    song.ID = int.Parse(item.Element("ID").Value);
                    song.Title = item.Element("title").Value;
                    song.Subtitle = item.Element("subtitle").Value;
                    // song.Producer= List<Producer>
                    //song.Producer = ListOTProducenti;
                    song.ReleaseDate = DateTime.Parse(item.Attribute("date_released").Value);
                    song.YearRecorded = int.Parse(item.Attribute("year_recorded").Value);
                    song.LengthInSeconds = int.Parse(item.Attribute("length_in_seconds").Value);
                    song.Label = item.Attribute("label").Value;
                    song.Genre = item.Attribute("genre").Value;
                   
                    song.Language = item.Attribute("language").Value;
                    song.IsInColor = item.Attribute("is_in_color").Value;
                    //Console.WriteLine(item.Element("song_characteristics").Element("rating").Value);
                    song.BeatsPerMinute = int.Parse(item.Element("song_characteristics").Element("beats_per_minute").Value);
                    song.Rating = double.Parse(item.Element("song_characteristics").Element("rating").Value);
                    List<Singer> s = new List<Singer>();
                    foreach (var singer in item.Element("singers").Elements())
                    {
                        // Console.WriteLine(singer);
                        Singer sing = new Singer {
                            FirstName = singer.Element("name").Element("first_name").Value,
                            LastName = singer.Element("name").Element("last_name").Value,
                            Residence = singer.Element("residence").Value,
                            NetworthValue = int.Parse(singer.Element("networth").Attribute("value").Value),
                            OtherPopularSong = singer.Element("other_popular_songs").Element("other_popular_song").Element("title").Value,
                            Gender = singer.Attribute("gender").Value,
                            BirthDate = DateTime.Parse(singer.Attribute("birthdate").Value)

                        };
                        s.Add(sing);
                    }
                    song.Singer = s;

                    List<RecordingStudio> rs = new List<RecordingStudio>();
                    //Console.WriteLine(item.Element("recorded_by_which_studios"));
                    foreach (var recordedByWhichStudios in item.Element("recorded_by_which_studios").Elements())
                    {
                        //Console.WriteLine(recordedByWhichStudios);
                        RecordingStudio rec = new RecordingStudio
                        {
                            Name = recordedByWhichStudios.Element("name").Value,
                            Address = recordedByWhichStudios.Element("address").Value

                        };
                        rs.Add(rec);
                    }
                    song.RecordingStudio = rs;

                    List<Producer> prod = new List<Producer>();
                    //Console.WriteLine(item.Element("recorded_by_which_studios"));
                    foreach (var produce in item.Element("producers").Elements())
                    {
                        //Console.WriteLine(produce);
                        Producer pr = new Producer
                        {
                            Name = produce.Element("name").Value


                        };
                         prod.Add(pr);
                    }
                    song.Producer = prod;

                    List<SongWriter> sw = new List<SongWriter>();
                    //Console.WriteLine(item.Element("recorded_by_which_studios"));
                    foreach (var songwr in item.Element("song_writers").Elements())
                    {
                        //Console.WriteLine(songwr);
                        SongWriter songwrit = new SongWriter
                        {
                            Name = songwr.Element("name").Value


                        };
                        sw.Add(songwrit);
                    }
                    song.SongWriter = sw;


                   // List<Album> a = new List<Album>();
                    //Console.WriteLine(item.Element("recorded_by_which_studios"));
                    //foreach (var alb in item.Element("is_in_album").Elements())
                    //{
                        //Console.WriteLine(songwr);
                      //  Album album1 = new Album
                        //{
                          //  Title = alb.Element("title").Value,
            
                        //};
                        //a.Add(album1);
                    //}
                    //song.Album = a;
                }


                // if not insert new entity
                else
                {
                    Song song = new Song();
                    song.ID = int.Parse(item.Element("ID").Value);
                    song.Title = item.Element("title").Value;
                    song.Subtitle = item.Element("subtitle").Value;
                    song.ReleaseDate = DateTime.Parse(item.Attribute("date_released").Value);
                    song.YearRecorded = int.Parse(item.Attribute("year_recorded").Value);
                    song.LengthInSeconds = int.Parse(item.Attribute("length_in_seconds").Value);
                    song.Label = item.Attribute("label").Value;
                    song.Genre = item.Attribute("genre").Value;
                    song.Language = item.Attribute("language").Value;
                    song.IsInColor = item.Attribute("is_in_color").Value;
                    song.BeatsPerMinute = int.Parse(item.Element("song_characteristics").Element("beats_per_minute").Value);
                  //  song.Rating = double.Parse(item.Element("song_characteristics").Element("rating").Value);
                    List<Singer> s = new List<Singer>();
                    foreach (var singer in item.Element("singers").Elements())
                    {
                        // Console.WriteLine(singer);
                        Singer sing = new Singer
                        {
                            FirstName = singer.Element("name").Element("first_name").Value,
                            LastName = singer.Element("name").Element("last_name").Value,
                            Residence = singer.Element("residence").Value,
                            NetworthValue = int.Parse(singer.Element("networth").Attribute("value").Value),
                            OtherPopularSong = singer.Element("other_popular_songs").Element("other_popular_song").Element("title").Value,
                            Gender = singer.Attribute("gender").Value, 
                            BirthDate = DateTime.Parse(singer.Attribute("birthdate").Value)

                        };
                        s.Add(sing);
                    }
                    song.Singer = s;

                    List<RecordingStudio> rs = new List<RecordingStudio>();
                    //Console.WriteLine(item.Element("recorded_by_which_studios"));
                    foreach (var recordedByWhichStudios in item.Element("recorded_by_which_studios").Elements())
                    {
                        //Console.WriteLine(recordedByWhichStudios);
                        RecordingStudio rec = new RecordingStudio
                        {
                            Name = recordedByWhichStudios.Element("name").Value,
                            Address = recordedByWhichStudios.Element("address").Value

                        };
                        rs.Add(rec);
                    }
                    song.RecordingStudio = rs;

                    List<Producer> prod = new List<Producer>();
                    //Console.WriteLine(item.Element("recorded_by_which_studios"));
                    foreach (var produce in item.Element("producers").Elements())
                    {
                        //Console.WriteLine(produce);
                        Producer pr = new Producer
                        {
                            Name = produce.Element("name").Value


                        };
                        prod.Add(pr);
                    }
                    song.Producer = prod;

                    List<SongWriter> sw = new List<SongWriter>();
                    //Console.WriteLine(item.Element("recorded_by_which_studios"));
                    foreach (var songwr in item.Element("song_writers").Elements())
                    {
                        //Console.WriteLine(songwr);
                        SongWriter songwrit = new SongWriter
                        {
                            Name = songwr.Element("name").Value


                        };
                        sw.Add(songwrit);
                    }
                    song.SongWriter = sw;


                    context.Song.Add(song);
                }
                Console.WriteLine("end");
                context.SaveChanges();
            }


        }
    }
}
