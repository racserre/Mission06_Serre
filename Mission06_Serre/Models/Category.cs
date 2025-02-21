using System.ComponentModel.DataAnnotations;  

namespace Mission06_Serre.Models  
{
    public class Category  
    {
        [Key]  // CategoryId is the primary key in the database
        public int CategoryId { get; set; }  // Property to store the unique identifier for each category

        public string CategoryName { get; set; }  // Property to store the name of the category
    }
}
