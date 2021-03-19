namespace ComputerASP.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class WarehouseComponent
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public WarehouseComponent()
        {
            RetailInvoices = new HashSet<RetailInvoice>();
        }
        [Display(Name ="номер склада")]
        [Key]
        public int WarehouseComponentId { get; set; }
        [Display(Name = "номер приходной накладной")]
        public int? PurchaseId { get; set; }
        [Display(Name ="Дата прибытия на склад")]
        [Column(TypeName = "smalldatetime")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]

        public DateTime? ArrivalDate { get; set; }
        [Display(Name ="Количество на складе")]
        [Required(ErrorMessage = "Поле не должно быть пустым")]//Валидация для обработки ошибок
        [Range(0, 60, ErrorMessage = "Недопустимый значение")]

        public int? Amount { get; set; }

        public virtual ProfitBill ProfitBill { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<RetailInvoice> RetailInvoices { get; set; }
    }
}
