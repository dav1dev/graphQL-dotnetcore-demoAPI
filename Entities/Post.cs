using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using GraphQLDemoAPI.Behavior;

namespace GraphQLDemoAPI.Entities
{
    public class Post : ISearch
    {
        [Key]
        public int Id { get; set; }

        public string Title { get; set; }

        public string Body { get; set; }

        public int UserId { get; set; }

        public User User { get; set; }

        public List<Comment> Comments { get; set; }
    }
}
