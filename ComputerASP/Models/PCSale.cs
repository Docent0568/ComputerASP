namespace ComputerASP.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PCSale")]
    public partial class PCSale
    {
        [Display(Name ="номер продажи")]
        [Key]
        public int PCSaleId { get; set; }
        [Display(Name = "Название ПК")]
        [Required(ErrorMessage = "Поле не должно быть пустым")]//Валидация для обработки ошибок
        [StringLength(50, MinimumLength = 10, ErrorMessage = "Длина строки должна быть от 10 до 50 символов")]
        public string PCName { get; set; }
        [Display(Name = "Стоимость ПК")]
        [Required(ErrorMessage = "Поле не должно быть пустым")]//Валидация для обработки ошибок
        [Range(0, 50000.00, ErrorMessage = "Недопустимый значение")]
        [Column(TypeName = "smallmoney")]
        public decimal? PricePC { get; set; }
        [Display(Name = "Дата продажи ПК")]
        [Column(TypeName = "smalldatetime")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? SellDate { get; set; }

        [Display(Name = "Дата гарантии ПК")]
        [Column(TypeName = "smalldatetime")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? GuaranteePeriod { get; set; }
        [Display(Name = "Статус ПК")]
        [Required(ErrorMessage = "Поле не должно быть пустым")]//Валидация для обработки ошибок
        [StringLength(50, MinimumLength = 10, ErrorMessage = "Длина строки должна быть от 10 до 50 символов")]
        public string PCStatus { get; set; }
    }
}
