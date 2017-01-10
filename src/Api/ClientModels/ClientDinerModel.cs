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

        public int Id { get; set; }
        public int BookingId { get; set; }
        public string Forename { get; set; }
        public string Surname { get; set; }
        [StringLength(50)]
        public string AddedByForename { get; set; }
        [StringLength(50)]
        public string AddedBySurname { get; set; }
        [StringLength(256)]
        public string AddedByEmailAddress { get; set; }
        public string UserId { get; set; }
        public IList<ClientDinerMenuItemModel> MenuItems { get; set; }
    }
}
