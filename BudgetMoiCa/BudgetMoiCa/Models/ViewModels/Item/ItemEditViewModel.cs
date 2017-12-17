using System.ComponentModel.DataAnnotations;

namespace BudgetMoiCa.Models.ViewModels.Item
{
    public class ItemEditViewModel
    {
        [Required]
        public int ItemId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public float Amount { get; set; }
        [Required]
        public string CategoryName { get; set; }
    }
}