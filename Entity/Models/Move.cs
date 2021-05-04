
using System.Collections.Generic;

namespace Entity.Models
{
    public class Move
    {
        public Move1 move { get; set; }
        public ICollection<Version_Group_Details> version_group_details { get; set; }
    }
}
