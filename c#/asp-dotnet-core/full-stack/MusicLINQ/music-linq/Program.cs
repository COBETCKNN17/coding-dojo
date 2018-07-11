using System;
using System.Collections.Generic;
using System.Linq;
using JsonData;

namespace ConsoleApplication
{
    public class Program
    {
        public static void Main(string[] args)
        {
            {
            List<Artist> Artists = JsonToFile<Artist>.ReadJson();
            List<Group> Groups = JsonToFile<Group>.ReadJson();

            // There is only one artist in this collection from Mount Vernon, what is their name and age?

            var artistMV = from artist in Artists
                        where artist.Hometown == "Mount Vernon"
                        select artist;
            Console.WriteLine("The only artist from Mount Vernon:");
            foreach (var artist in artistMV)
            {
                Console.WriteLine("Name: " + artist.RealName + " - Age: " + artist.Age);
            }
            Console.WriteLine(" ");
            Console.WriteLine("---");
            Console.WriteLine(" ");

            // Who is the youngest artist in our collection of artists?

            var artistYoung = from artist in Artists select artist;
            Artist youngestArtist = Artists.First();
            foreach (var artist in artistYoung)
            {
                if (artist.Age < youngestArtist.Age)
                {
                    youngestArtist = artist;
                }
            }
            Console.WriteLine("The youngest artist is: " + youngestArtist.ArtistName);
            Console.WriteLine(" ");
            Console.WriteLine("---");
            Console.WriteLine(" ");

            // Display all artists with 'William' somewhere in their real name
            var artistWill = from artist in Artists select artist;
            Console.WriteLine("All artists with 'William' somewhere in their real name:");
            foreach (var artist in artistWill)
            {
                if (artist.RealName.Contains("William"))
                {
                    Console.WriteLine(artist.ArtistName + " - Real Name: " + artist.RealName);
                }
            }

            Console.WriteLine(" ");
            Console.WriteLine("---");
            Console.WriteLine(" ");

            // Display all groups with names less than 8 characters in length

            var artistShortName = from artist in Artists select artist;
            Console.WriteLine("Groups with names less than 8 characters in length:");
            foreach (var artist in artistShortName)
            {
                if (artist.ArtistName.Length < 8)
                {
                    Console.WriteLine(artist.ArtistName);
                }
            }

            Console.WriteLine(" ");
            Console.WriteLine("---");
            Console.WriteLine(" ");

            // Display the 3 oldest artists from Atlanta

            var artistOldest = from artist in Artists
                                where artist.Hometown == "Atlanta"
                                orderby artist.Age descending
                                select artist;
            Console.WriteLine("The three oldest artists from Atlanta:");
            int i = 1;
            foreach (var artist in artistOldest)
            {
                if (i <= 3)
                {
                    Console.WriteLine(artist.ArtistName + " - Age: " + artist.Age);
                }
                else{
                    break;
                }
                i++;
            }

            Console.WriteLine(" ");
            Console.WriteLine("---");
            Console.WriteLine(" ");

            }
        }
    }
}

