using System;
using System.Collections.Generic;
using System.Threading;
class Program
{
    static void Main(string[] args)
    {
        // Console.WriteLine("Hello World! This is the YouTubeVideos Project.");
        Console.Clear(); //works

        var videos = new List<Video>();

        var video1 = new Video("Learning How to Single Crochet", "Galaci Styles", 6);
        video1.AddComment(new Comment("GalaxyStudios", "THANK YOU SO MUCH!!!!!"));
        video1.AddComment(new Comment("CarolPlays", "Very helpful, thanks!"));
        video1.AddComment(new Comment("Dave", "I learned a lot."));

        var video2 = new Video("Homemade Baked Rigatoni", "Sir Chef Tony", 68);
        video2.AddComment(new Comment("Eve", "Yummy!"));
        video2.AddComment(new Comment("Frank", "Can't wait to try this."));
        video2.AddComment(new Comment("Grace", "Looks delicious!"));
        video2.AddComment(new Comment("ChefMia", "Thank you for sharing this recipe! I tried it and it was a favorite among my family."));

        var video3 = new Video("Places to go in Japan", "Wanderer", 120);
        video3.AddComment(new Comment("PurpleDia", "Beautiful scenery! I love the Sakura trees."));
        video3.AddComment(new Comment("PlantWhisperer", "I want to visit Japan now."));
        video3.AddComment(new Comment("GalaxyStormRider", "That looks so fun, it's now on my bucket list!"));

        videos.Add(video1);
        videos.Add(video2);
        videos.Add(video3);

        foreach (var video in videos)
        {
            Console.WriteLine($" * * * {video.Title} * * * ");
            Console.WriteLine($"By: {video.Author}");
            Console.WriteLine($"Minutes: {video.LengthSeconds}");
            Console.WriteLine($"Number of comments: {video.GetNumberOfComments()}");
            Console.WriteLine();
            Console.WriteLine("Comments:");
            Thread.Sleep(2000);
            foreach (var comment in video.GetComments())
            {
                Console.WriteLine($"  {comment.Name}: {comment.Text}");
                Console.WriteLine("");
                Thread.Sleep(2000);
            }
            Console.WriteLine();
        }


    }
}