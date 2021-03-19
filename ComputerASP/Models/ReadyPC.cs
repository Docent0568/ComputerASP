namespace ComputerASP.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ReadyPC")]
    public partial class ReadyPC
    {
        [Display(Name ="Номер ПК")]
        [Key]
        public int ReadyPCId { get; set; }
        [Display(Name = "Поставщик")]
        public int? SupplierId { get; set; }
        [Display(Name = "Дата поставки")]
        [Column(TypeName = "smalldatetime")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? PurchaseDate { get; set; }
        [Display(Name = "Стоимость ПК")]
        [Column(TypeName = "smallmoney")]
        [Required(ErrorMessage = "Поле не должно быть пустым")]//Валидация для обработки ошибок
        [Range(0, 50000.00, ErrorMessage = "Недопустимый значение")]
        public decimal? PurchasePrice { get; set; }
        [Display(Name = "Название ПК")]
        [Required(ErrorMessage = "Поле не должно быть пустым")]//Валидация для обработки ошибок
        [StringLength(50, MinimumLength = 10, ErrorMessage = "Длина строки должна быть от 10 до 50 символов")]

        public string PCName { get; set; }
        [Display(Name = "Характеристики ПК")]
        [Required(ErrorMessage = "Поле не должно быть пустым")]//Валидация для обработки ошибок
        [StringLength(150, MinimumLength = 10, ErrorMessage = "Длина строки должна быть от 10 до 150 символов")]

        public string CharacteristicPC { get; set; }
        [Display(Name = "Количество ПК")]
        [Required(ErrorMessage = "Поле не должно быть пустым")]//Валидация для обработки ошибок
        [Range(0, 20, ErrorMessage = "Недопустимый значение")]

        public int? Amount { get; set; }

        public virtual Supplier Supplier { get; set; }
    }
}
