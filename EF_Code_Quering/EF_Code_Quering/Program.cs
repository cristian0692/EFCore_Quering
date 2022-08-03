using EF_Code_Quering.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Diagnostics;

namespace EF_Code_Quering 
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            //SimpleQuering();
            //cheking the performance
            FasterSelect();
            Console.WriteLine("End");
            Console.ReadLine();
        }

        private static void FasterSelect()
        {
            var timer = new Stopwatch();
            var db = new BlogDbContext();
            timer.Start();
            var post = db.Posts.ToList();
            timer.Stop();
            Console.WriteLine("Simple "+timer.ElapsedTicks);
            timer.Reset();
            timer.Start();
            var post1 = db.Posts
                .AsNoTracking()
                .ToArray();
            timer.Stop(); 
            Console.WriteLine("Fast   " +timer.ElapsedTicks);
            timer.Reset();
            timer.Start();
            var post2 = db.Posts
                .ToArray();
            timer.Stop();
            Console.WriteLine("Fast 2 " + timer.ElapsedTicks);
        }

        private static void SimpleQuering()
        {
            //extract all posts that contains C#
            var db = new BlogDbContext();
            db.Posts.Add(new Post() { Title = "Fresh C#", Content = "Fresh Post", Blog = db.Blogs.FirstOrDefault() });
            db.SaveChanges();
            var posts = db.Posts
                .Include(x=>x.Blog)
                .Where(x => x.Title.Contains("C#") || x.Content.Contains("C#"))
                .ToArray();

            //remove first element from the list 
            db.Posts.Remove(posts[0]);
      //db.SaveChanges();
            foreach (var post in posts)
            {
                Console.WriteLine($"PostID:{post.Id} {post.Title} {post.Content},BlogID: {post.Blog.Id}, PostState:{db.Entry(post).State}");
            }
            var manager = db.Users.SingleOrDefault(x=>x.Name=="manager");
            Console.WriteLine($"MANAGER USER:{manager.Id} {manager.Name} {manager.DisplayName}");

            Console.WriteLine(new string('_',20));
            //Extract all posts that consists EF from EF Blog
            var efBlog = db.Blogs.FirstOrDefault(x => x.Id == 2);
            //var efPosts = db.Entry(efBlog)
            //    .Collection(p =>p.Posts)
            //    .Query()
            //    .Where(x=>x.Title.Contains("EF"))
            //    .ToList();
            var efPosts = db.Posts
                .Where(x => x.Title.Contains("EF"))
                .ToList();
            foreach (var post in efPosts)
            {
                Console.WriteLine($"PostID:{post.Id} {post.Title} {post.Content},BlogID: {post.Blog.Name}");
            }

        }
    }
}