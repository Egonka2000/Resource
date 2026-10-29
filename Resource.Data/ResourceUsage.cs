using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Resources.Data
{
    [Table("ResourceUsages")]
    public class ResourceUsage
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public DateTime Usage { get; set; } = DateTime.Now;

        [ForeignKey(nameof(Resource))]
        public string ResourceName { get; set; }

        [NotMapped]
        public virtual Resource Resource { get; set; }
    }
}
