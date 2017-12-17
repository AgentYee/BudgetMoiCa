using System.ComponentModel.DataAnnotations;

namespace BudgetMoiCa.Models.ViewModels.Item
{
    public class ItemCreateViewModel
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public float Amount { get; set; }
        [Required]
        public string CategoryName { get; set; }
        [Required]
        public string Username { get; set; }
    }
}