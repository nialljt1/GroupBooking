using System.ComponentModel.DataAnnotations;

namespace Api.ClientModels
{
    public class ClientDinerMenuItemModel
    {        
        public int DinerId { get; set; }
        public int MenuItemId { get; set; }

        public int MenuSectionId { get; set; }
        public string MenuSectionName { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int DisplayOrder { get; set; }

        [StringLength(1000)]
        public string DinerMenuItemNote { get; set; }
    }
}
