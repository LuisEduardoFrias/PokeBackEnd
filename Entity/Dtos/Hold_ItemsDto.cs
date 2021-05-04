using System.Collections.Generic;

namespace Entity.Dtos
{
    public class Hold_ItemsDto
    {
        public ItemDto Item { get; set; }
        public ICollection<Version_DetailsDto> Version_details { get; set; }
    }
}
