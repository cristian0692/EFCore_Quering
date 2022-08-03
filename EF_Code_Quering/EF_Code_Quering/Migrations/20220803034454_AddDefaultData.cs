using EF_Code_Quering.Entities;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EF_Code_Quering.Migrations
{
    public partial class AddDefaultData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var admin = new User()
            {
                Name = "admin",
                DisplayName = "Administrator"
            };
            var manager = new User()
            {
                Name = "manager",
                DisplayName = "Manager"
            };
            

            var blog = new Blog
            {

                Name = "C# Starter",
                Url = "ww.csharp-starter.com"
            };
            var blog2 = new Blog
            {

                Name = "EF Core Starter",
                Url = "ww.efCore-starter.com"
            };
            var db = new BlogDbContext();
            db.Users.AddRange(admin, manager);
            db.Blogs.AddRange(blog,blog2);
            db.SaveChanges();
            var firstBlog = db.Blogs.FirstOrDefault(x=>x.Name =="C# Starter");
            var efBlog = db.Blogs.FirstOrDefault(x=>x.Name == "EF Core Starter");
            var post = new Post
            {
                Title = "Intro C#",
                Content = "<h1>Introduction to C# World </h1><p>First program<p>",
                Blog = firstBlog
            };
            var post1 = new Post
            {
                Title = "Data Types in C#",
                Content = "<h1>Types </h1><p>Ref and Value<p>",
                Blog = firstBlog
            };
            var post2 = new Post
            {
                Title = "Collections C#",
                Content = "<h1>Collections in C# World </h1><p>LinkedList,IEnumerable,Stack,Queue,Dictionary etc.<p>",
                Blog = firstBlog
            };
            var post3 = new Post
            {
                Title = "ORM C#",
                Content = "<h1>Ado.Net Origin </h1><p>EFCore1.0<p>",
                Blog = efBlog
            };
            var post4 = new Post
            {
                Title = "Architecture of Ef",
                Content = "<h1>Tables,Mappers </h1><p>Data Annotations<p>",
                Blog = efBlog
            };
            var post5 = new Post
            {
                Title = "Fluent API",
                Content = "<h1>Fluent API </h1><p>Fluent API adn Conventions<p>",
                Blog = efBlog
            };
            db.Posts.AddRange(post1,post2,post3,post4,post5);
            db.SaveChanges();

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            var db = new BlogDbContext();
            var admin = db.Users.FirstOrDefault(x => x.Name == "admin");
            var manager = db.Users.FirstOrDefault(x => x.Name == "manager");

            db.Users.Remove(admin);
            db.Users.Remove(manager);

            var post = db.Posts.FirstOrDefault(x => x.Title == "Intro C#");
            var post1 = db.Posts.FirstOrDefault(x => x.Title == "Data Types in C#");
            var post2 = db.Posts.FirstOrDefault(x => x.Title == "Collections C#");
            var post3 = db.Posts.FirstOrDefault(x => x.Title == "ORM C#");
            var post4 = db.Posts.FirstOrDefault(x => x.Title == "Architecture of Ef");
            var post5 = db.Posts.FirstOrDefault(x => x.Title == "Fluent API");

            db.Posts.Remove(post);
            db.Posts.Remove(post1);
            db.Posts.Remove(post2);
            db.Posts.Remove(post3);
            db.Posts.Remove(post4);
            db.Posts.Remove(post5);

            var BlogCS = db.Blogs.FirstOrDefault(x => x.Name == "C# Starter");
            var BlogEF = db.Blogs.FirstOrDefault(x => x.Name == "EF Core Starter");
            db.Blogs.Remove(BlogCS);
            db.Blogs.Remove(BlogEF);


            db.SaveChanges();
        }
    }
}
