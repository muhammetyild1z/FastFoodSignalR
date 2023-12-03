using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace FastFoodSignalR.Entity.Entities
{
    public class Feature
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int FeauteID { get; set; }
        public string FeauteTitle { get; set; }
        public string FeauteDescription { get; set; }
    }
}


