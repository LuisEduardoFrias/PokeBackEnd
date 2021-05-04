using System.Collections.Generic;

namespace Entity.Models
{
    public class Hold_Items
    {
        public Item item { get; set; }
        public ICollection<Version_Details> version_details { get; set; }
    }
}
