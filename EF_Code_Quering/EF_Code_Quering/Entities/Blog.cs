using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_Code_Quering.Entities
{
    public class Blog
    {

        public int Id { get; set; }


        public string Name { get; set; }

        public string Url { get; set; }

        public virtual List<Post> Posts { get; set; } = new();

    }
}
