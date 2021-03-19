namespace ComputerASP.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Employee
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Employee()
        {
            RetailInvoices = new HashSet<RetailInvoice>();
        }
        [Display(Name ="Код сотрудника")]
        [Key]
        public int EmployeeId { get; set; }
        [Display(Name = "ФИО сотрудника")]
        [Required(ErrorMessage = "Поле не должно быть пустым")]//Валидация для обработки ошибок
        [StringLength(30, MinimumLength = 5, ErrorMessage = "Длина строки должна быть от 2 до 30 символов")]
        public string FIO { get; set; }
        [Display(Name = "Город")]
        [Required(ErrorMessage = "Поле не должно быть пустым")]
        [StringLength(20, MinimumLength = 5, ErrorMessage = "Длина строки должна быть от 5 до 20 символов")]
        public string City { get; set; }
        [Display(Name = "Адрес")]
        [Required(ErrorMessage = "Поле не должно быть пустым")]
        [StringLength(50, MinimumLength = 5, ErrorMessage = "Длина строки должна быть от 5 до 50 символов")]
        public string Address { get; set; }
        [Display(Name = "Телефон")]
        [Required(ErrorMessage = "Поле не должно быть пустым")]
        [RegularExpression(@"[0-9]{12}", ErrorMessage = "Формат номера 380ХХХХХХХХХ")]
        public long? Phone { get; set; }
        [Display(Name = "Должность")]
        [Required(ErrorMessage = "Поле не должно быть пустым")]
        [StringLength(50, MinimumLength = 5, ErrorMessage = "Длина строки должна быть от 5 до 50 символов")]

        public string Position { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<RetailInvoice> RetailInvoices { get; set; }
    }
}
