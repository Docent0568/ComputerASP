namespace ComputerASP.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("AssemblyPc")]
    public partial class AssemblyPc
    {
        [Display(Name ="Номер сборки")]
        public int AssemblyPCId { get; set; }
        [Display(Name = "Характеристика ПК")]
        [Required(ErrorMessage ="Поле не должно быть пустым")]
        [StringLength(150,MinimumLength =20,ErrorMessage = "Длина строки должна быть от 10 до 70 символов")]
        public string CharacteristicPC { get; set; }
        [Display(Name = "Дата сборки")]
        [Column(TypeName = "smalldatetime")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? DateAssemblyPC { get; set; }
        [Display(Name = "Количество сборок")]
        [Required(ErrorMessage = "Поле не должно быть пустым")]//Валидация для обработки ошибок
        [Range(0, 20, ErrorMessage = "Недопустимый значение")]

        public int? Amount { get; set; }
        [Display(Name ="Цена сборки")]
        [Column(TypeName = "smallmoney")]
        [Required(ErrorMessage = "Поле не должно быть пустым")]//Валидация для обработки ошибок
        [Range(0, 10000.00, ErrorMessage = "Недопустимый значение")]

        public decimal? AssemblyPrice { get; set; }
        [Display(Name ="Название")]
        [Required(ErrorMessage = "Поле не должно быть пустым")]//Валидация для обработки ошибок
        [StringLength(50, MinimumLength = 10, ErrorMessage = "Длина строки должна быть от 10 до 50 символов")]

        public string PCName { get; set; }
    }
}
