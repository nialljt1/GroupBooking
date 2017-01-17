using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Api.ClientModels
{
    public class ClientDinerModel
    {
        public ClientDinerModel()
        {
            MenuItems = new List<ClientDinerMenuItemModel>();
        }

        [Required]
        public int Id { get; set; }

        [Required]
        public int BookingId { get; set; }

        [Required, StringLength(50)]
        public string Forename { get; set; }

        [Required, StringLength(50)]
        public string Surname { get; set; }
        [StringLength(50)]
        public string AddedByEmailAddress { get; set; }
        public string UpdatedByUserId { get; set; }
        public IList<ClientDinerMenuItemModel> MenuItems { get; set; }
    }
}
