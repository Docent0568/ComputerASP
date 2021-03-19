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
        [Display(Name ="����� ��������������")]
        public int PurchaseComponentId { get; set; }
        [Display(Name = "������������ ����������")]
        public int? ComponentId { get; set; }
        [Display(Name = "������������ ������")]
        public int? ModelId { get; set; }
        [Display(Name = "���������")]
        public int? SupplierId { get; set; }
        [Display(Name = "�������")]
        [UIHint("IsAvailabity")]
        public bool Availabity { get; set; }
        [Display(Name ="�������������� ��������������")]
        [Required(ErrorMessage = "���� �� ������ ���� ������")]//��������� ��� ��������� ������
        [StringLength(70, MinimumLength = 10, ErrorMessage = "����� ������ ������ ���� �� 10 �� 70 ��������")]

        public string Specifications { get; set; }
        [Display(Name ="���� ��������������")]
        [Required(ErrorMessage = "���� �� ������ ���� ������")]//��������� ��� ��������� ������
        [Range(0, 50000.00, ErrorMessage = "������������ ��������")]
        [Column(TypeName = "smallmoney")]
        public decimal? Price { get; set; }
        [Display(Name ="���� ��������")]
        [Required(ErrorMessage = "���� �� ������ ���� ������")]//��������� ��� ��������� ������
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]

        public DateTime? GuaranteePeriod { get; set; }

        [Display(Name = "���� �������")]
        [Required(ErrorMessage = "���� �� ������ ���� ������")]//��������� ��� ��������� ������
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
