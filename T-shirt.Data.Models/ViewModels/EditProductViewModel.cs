using System.ComponentModel.DataAnnotations;

namespace T_shirt.Data.Models.ViewModels
{
    public class EditProductViewModel
    {
        [Required, Range(1, int.MaxValue)]
        public long ProductId { get; set; }
        [Required]
        public string Name { get; set; } = null!;
        [Required]
        public string Description { get; set; } = null!;
        [Required, Range(0, double.MaxValue)]
        public decimal Price { get; set; }
    }
}
