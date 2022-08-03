using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_Code_Quering.Entities
{
    public class Post
    {

        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public Blog Blog { get; set; }
    }
}
