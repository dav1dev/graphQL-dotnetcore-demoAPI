using System.ComponentModel.DataAnnotations;
using GraphQLDemoAPI.Behavior;

namespace GraphQLDemoAPI.Entities
{
    public class Comment : ISearch
    {
        [Key]
        public int Id { get; set; }
        
        public string Body { get; set; }

        public bool IsAppropriate { get; set; }

        public int UserId { get; set; }

        public User User { get; set; }

        public int PostId { get; set; }

        public Post Post { get; set; }
    }
}
