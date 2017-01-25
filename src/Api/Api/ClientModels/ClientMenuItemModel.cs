using System.ComponentModel.DataAnnotations;

namespace Api.ClientModels
{
    public class ClientMenuItemModel
    {
        [Required]
        public int Id { get; set; }

        [Required, StringLength(50)]
        public string Name { get; set; }
        [StringLength(200)]
        public string Description { get; set; }
        [Required]
        public int DisplayOrder { get; set; }
        [Required]
        public int MenuSectionId { get; set; }
        public int? Number { get; set; }
    }
}
