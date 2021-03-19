namespace ComputerASP.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Supplier
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Supplier()
        {
            ProfitBills = new HashSet<ProfitBill>();
            PurchasePCComponents = new HashSet<PurchasePCComponent>();
            ReadyPCs = new HashSet<ReadyPC>();
        }
        [Display(Name ="Номер поставщика")]
        [Key]
        public int SupplierId { get; set; }
        [Display(Name ="Наименование поставщика")]
        [Required(ErrorMessage = "Поле не должно быть пустым")]//Валидация для обработки ошибок
        [StringLength(30, MinimumLength = 2, ErrorMessage = "Длина строки должна быть от 2 до 30 символов")]

        public string SupplierFirm { get; set; }
        [Display(Name="Дата поставки")]
        [Required(ErrorMessage = "Поле не должно быть пустым")]//Валидация для обработки ошибок
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]

        public DateTime? DateDelivery { get; set; }
        [Display(Name ="Город")]
        [Required(ErrorMessage = "Поле не должно быть пустым")]
        [StringLength(20, MinimumLength = 5, ErrorMessage = "Длина строки должна быть от 5 до 20 символов")]

        public string CityDelivery { get; set; }
        [Display(Name ="Адрес")]
        [Required(ErrorMessage = "Поле не должно быть пустым")]
        [StringLength(50, MinimumLength = 5, ErrorMessage = "Длина строки должна быть от 5 до 50 символов")]

        public string AddressDelivery { get; set; }
        [Display(Name ="Телефон")]
        [Required(ErrorMessage = "Поле не должно быть пустым")]
        [RegularExpression(@"[0-9]{12}", ErrorMessage = "Формат номера 380ХХХХХХХХХ")]

        public long? PhoneDelivery { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ProfitBill> ProfitBills { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PurchasePCComponent> PurchasePCComponents { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ReadyPC> ReadyPCs { get; set; }
    }
}
