namespace BudgetMoiCa.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Item")]
    public partial class Item
    {
        public int ItemId { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [Required]
        [StringLength(300)]
        public string Description { get; set; }

        public double Amount { get; set; }

        [StringLength(200)]
        public string PictureURL { get; set; }

        public int CategoryId { get; set; }

        public int UserId { get; set; }

        public virtual Category Category { get; set; }

        public virtual User User { get; set; }
    }
}
