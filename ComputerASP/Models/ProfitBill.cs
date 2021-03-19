namespace ComputerASP.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ProfitBill")]
    public partial class ProfitBill
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ProfitBill()
        {
            WarehouseComponents = new HashSet<WarehouseComponent>();
        }

        [Key]
        [Display(Name ="Номер накладной")]
        public int PurchaseId { get; set; }
        [Display(Name = "Номер комплектующего")]
        public int? PurchaseComponentId { get; set; }
        [Display(Name = "Поставщик")]
        public int? SupplierId { get; set; }
        [Display(Name ="Цена за ед.")]
        [Column(TypeName = "smallmoney")]
        [Required(ErrorMessage = "Поле не должно быть пустым")]//Валидация для обработки ошибок
        [Range(0, 50000.00, ErrorMessage = "Недопустимый значение")]

        public decimal? UnitPrice { get; set; }
        [Display(Name = "Количество")]
        [Required(ErrorMessage = "Поле не должно быть пустым")]//Валидация для обработки ошибок
        [Range(0, 60, ErrorMessage = "Недопустимый значение")]

        public int? Amount { get; set; }
        [Display(Name ="Дата покупки")]
        [Column(TypeName = "smalldatetime")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]

        public DateTime? PurchaseDate { get; set; }
        [Display(Name ="Сумма")]
        [Column(TypeName = "smallmoney")]
        [Required(ErrorMessage = "Поле не должно быть пустым")]//Валидация для обработки ошибок
        [Range(0, 100000.00, ErrorMessage = "Недопустимый значение")]

        public decimal? SumPrice { get; set; }

        public virtual PurchasePCComponent PurchasePCComponent { get; set; }

        public virtual Supplier Supplier { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<WarehouseComponent> WarehouseComponents { get; set; }
    }
}
