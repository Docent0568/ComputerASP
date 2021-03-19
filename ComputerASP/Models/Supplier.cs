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
        [Display(Name ="����� ����������")]
        [Key]
        public int SupplierId { get; set; }
        [Display(Name ="������������ ����������")]
        [Required(ErrorMessage = "���� �� ������ ���� ������")]//��������� ��� ��������� ������
        [StringLength(30, MinimumLength = 2, ErrorMessage = "����� ������ ������ ���� �� 2 �� 30 ��������")]

        public string SupplierFirm { get; set; }
        [Display(Name="���� ��������")]
        [Required(ErrorMessage = "���� �� ������ ���� ������")]//��������� ��� ��������� ������
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]

        public DateTime? DateDelivery { get; set; }
        [Display(Name ="�����")]
        [Required(ErrorMessage = "���� �� ������ ���� ������")]
        [StringLength(20, MinimumLength = 5, ErrorMessage = "����� ������ ������ ���� �� 5 �� 20 ��������")]

        public string CityDelivery { get; set; }
        [Display(Name ="�����")]
        [Required(ErrorMessage = "���� �� ������ ���� ������")]
        [StringLength(50, MinimumLength = 5, ErrorMessage = "����� ������ ������ ���� �� 5 �� 50 ��������")]

        public string AddressDelivery { get; set; }
        [Display(Name ="�������")]
        [Required(ErrorMessage = "���� �� ������ ���� ������")]
        [RegularExpression(@"[0-9]{12}", ErrorMessage = "������ ������ 380���������")]

        public long? PhoneDelivery { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ProfitBill> ProfitBills { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PurchasePCComponent> PurchasePCComponents { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ReadyPC> ReadyPCs { get; set; }
    }
}
