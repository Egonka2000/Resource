using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Resources.Data
{
    [Table("Resources")]
    public class Resource
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string UniqueName { get; set; }

        public int MaximumUsages { get; set; }

        [NotMapped]
        public virtual ICollection<ResourceUsage> ResourceUsages { get; set; }

        public Resource()
        {
                ResourceUsages = new HashSet<ResourceUsage>();
        }
    }
}
