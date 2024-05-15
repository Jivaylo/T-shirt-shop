using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace T_shirtshop.Data.Models
{
    public class Order
    {
        [Key]
        public int Id { get; set; }

        public DateTime DateCreated { get; set; } = DateTime.Now;

        public DateTime? DatePaid { get; set; }

        public DateTime? DateSent { get; set; }

        public ShirtSize ShirtSize { get; set; } = null!;

        public int ShirtSizeId { get; set; }
        
        public ShirtType ShirtType { get; set; } = null!;

        public int ShirtTypeId { get; set; }

        [Required, MaxLength(50), DataType(DataType.EmailAddress)]
        public string EmailAddress { get; set; } = null!;

        [Required, MaxLength(50)]
        public string FullName { get; set; } = null!;

        [Required, MaxLength(50)]
        public string Street { get; set; } = null!;

        [Required, MaxLength(50)]
        public string City { get; set; } = null!;

        [Required, MaxLength(5), DataType(DataType.PostalCode)]
        public string ZipCode { get; set; } = null!;

    }
}
