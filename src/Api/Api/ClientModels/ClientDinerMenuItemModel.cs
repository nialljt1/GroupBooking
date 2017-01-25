using System.ComponentModel.DataAnnotations;

namespace Api.ClientModels
{
    public class ClientDinerMenuItemModel
    {
        [Required]
        public int DinerId { get; set; }
        [Required]
        public int MenuItemId { get; set; }

        [Required]
        public int MenuSectionId { get; set; }

        [Required, StringLength(50)]
        public string MenuSectionName { get; set; }

        [Required, StringLength(50)]
        public string Name { get; set; }

        [StringLength(200)]
        public string Description { get; set; }
        [Required]
        public int DisplayOrder { get; set; }

        [StringLength(1000)]
        public string DinerMenuItemNote { get; set; }
    }
}
