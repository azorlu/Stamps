namespace Stamps.Models
{
    public class Country
    {
        public int Id { get; set; } 
        public string Name { get; set; }        

        public int ContinentId { get; set; }
        public Continent Continent { get; set; }
    
    }
}