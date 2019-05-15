using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GraphQLDemoAPI.Entities
{
    public class User
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public string UserName { get; set; }

        public string Email { get; set; }

        public List<Post> Posts { get; set; }

        public List<Comment> Comments { get; set; }
    }
}
