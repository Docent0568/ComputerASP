namespace ComputerASP.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("RetailInvoice")]
    public partial class RetailInvoice
    {
        [Display(Name ="Номер накладной")]
        [Key]
        public int SaleId { get; set; }
        [Display(Name = "Склад")]
        public int? WarehouseComponentId { get; set; }

        [Display(Name = "Цена за ед.")]
        [Column(TypeName = "smallmoney")]
        [Required(ErrorMessage = "Поле не должно быть пустым")]//Валидация для обработки ошибок
        [Range(0, 50000.00, ErrorMessage = "Недопустимый значение")]

        public decimal? UnitPrice { get; set; }
        [Display(Name = "Количество")]
        [Required(ErrorMessage = "Поле не должно быть пустым")]//Валидация для обработки ошибок
        [Range(0, 60, ErrorMessage = "Недопустимый значение")]

        public int? Amount { get; set; }
        [Display(Name ="Сотрудник")]
        public int? EmployeeId { get; set; }

        [Display(Name = "Дата продажи")]
        [Column(TypeName = "smalldatetime")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]

        public DateTime? SaleDate { get; set; }

        [Display(Name = "Сумма")]
        [Column(TypeName = "smallmoney")]
        [Required(ErrorMessage = "Поле не должно быть пустым")]//Валидация для обработки ошибок
        [Range(0, 100000.00, ErrorMessage = "Недопустимый значение")]

        public decimal? SumPrice { get; set; }

        public virtual Employee Employee { get; set; }

        public virtual WarehouseComponent WarehouseComponent { get; set; }
    }
}
