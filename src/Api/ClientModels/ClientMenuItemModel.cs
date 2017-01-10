namespace Api.ClientModels
{
    public class ClientMenuItemModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int DisplayOrder { get; set; }
        public int MenuSectionId { get; set; }
        public int? Number { get; set; }
    }
}
