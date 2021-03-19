namespace ComputerASP.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class PurchasePCComponent
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public PurchasePCComponent()
        {
            ProfitBills = new HashSet<ProfitBill>();
        }

        [Key]
        [Display(Name ="Номер комплектующего")]
        public int PurchaseComponentId { get; set; }
        [Display(Name = "Наименование компонента")]
        public int? ComponentId { get; set; }
        [Display(Name = "Наименование модели")]
        public int? ModelId { get; set; }
        [Display(Name = "Поставщик")]
        public int? SupplierId { get; set; }
        [Display(Name = "Наличие")]
        [UIHint("IsAvailabity")]
        public bool Availabity { get; set; }
        [Display(Name ="Характеристика комплектующего")]
        [Required(ErrorMessage = "Поле не должно быть пустым")]//Валидация для обработки ошибок
        [StringLength(70, MinimumLength = 10, ErrorMessage = "Длина строки должна быть от 10 до 70 символов")]

        public string Specifications { get; set; }
        [Display(Name ="Цена комплектующего")]
        [Required(ErrorMessage = "Поле не должно быть пустым")]//Валидация для обработки ошибок
        [Range(0, 50000.00, ErrorMessage = "Недопустимый значение")]
        [Column(TypeName = "smallmoney")]
        public decimal? Price { get; set; }
        [Display(Name ="Дата гарантии")]
        [Required(ErrorMessage = "Поле не должно быть пустым")]//Валидация для обработки ошибок
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]

        public DateTime? GuaranteePeriod { get; set; }

        [Display(Name = "Дата выпуска")]
        [Required(ErrorMessage = "Поле не должно быть пустым")]//Валидация для обработки ошибок
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? DateIssue { get; set; }

        public virtual Component Component { get; set; }

        public virtual Model Model { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ProfitBill> ProfitBills { get; set; }

        public virtual Supplier Supplier { get; set; }
    }
}
