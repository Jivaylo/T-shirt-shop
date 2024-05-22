using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace T_shirtshop.Data.Models
{
    public class Team
    {
            [Key]
            public int Id { get; set; }

            [Required]
            [StringLength(50)]
            public string Name { get; set; } = null!;

            [Required]
            [StringLength(100)]
            public string LogoUrl { get; set; } = null!;

            public virtual ICollection<TShirt> TShirts { get; set; } = null!;
        }
    }
