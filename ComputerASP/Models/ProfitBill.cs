namespace ComputerASP.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ProfitBill")]
    public partial class ProfitBill
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ProfitBill()
        {
            WarehouseComponents = new HashSet<WarehouseComponent>();
        }

        [Key]
        [Display(Name ="����� ���������")]
        public int PurchaseId { get; set; }
        [Display(Name = "����� ��������������")]
        public int? PurchaseComponentId { get; set; }
        [Display(Name = "���������")]
        public int? SupplierId { get; set; }
        [Display(Name ="���� �� ��.")]
        [Column(TypeName = "smallmoney")]
        [Required(ErrorMessage = "���� �� ������ ���� ������")]//��������� ��� ��������� ������
        [Range(0, 50000.00, ErrorMessage = "������������ ��������")]

        public decimal? UnitPrice { get; set; }
        [Display(Name = "����������")]
        [Required(ErrorMessage = "���� �� ������ ���� ������")]//��������� ��� ��������� ������
        [Range(0, 60, ErrorMessage = "������������ ��������")]

        public int? Amount { get; set; }
        [Display(Name ="���� �������")]
        [Column(TypeName = "smalldatetime")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]

        public DateTime? PurchaseDate { get; set; }
        [Display(Name ="�����")]
        [Column(TypeName = "smallmoney")]
        [Required(ErrorMessage = "���� �� ������ ���� ������")]//��������� ��� ��������� ������
        [Range(0, 100000.00, ErrorMessage = "������������ ��������")]

        public decimal? SumPrice { get; set; }

        public virtual PurchasePCComponent PurchasePCComponent { get; set; }

        public virtual Supplier Supplier { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<WarehouseComponent> WarehouseComponents { get; set; }
    }
}
