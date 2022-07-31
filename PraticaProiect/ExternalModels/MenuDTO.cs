namespace PraticaProiect.ExternalModels
{
    public class MenuDTO
    {
        public Guid ID { get; set; }
        public CategoryDTO Category { get; set; }
        public string MenuName { get; set; }
        public float Price { get; set; }
    }
}
