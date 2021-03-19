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
        [Display(Name ="����� ���������")]
        [Key]
        public int SaleId { get; set; }
        [Display(Name = "�����")]
        public int? WarehouseComponentId { get; set; }

        [Display(Name = "���� �� ��.")]
        [Column(TypeName = "smallmoney")]
        [Required(ErrorMessage = "���� �� ������ ���� ������")]//��������� ��� ��������� ������
        [Range(0, 50000.00, ErrorMessage = "������������ ��������")]

        public decimal? UnitPrice { get; set; }
        [Display(Name = "����������")]
        [Required(ErrorMessage = "���� �� ������ ���� ������")]//��������� ��� ��������� ������
        [Range(0, 60, ErrorMessage = "������������ ��������")]

        public int? Amount { get; set; }
        [Display(Name ="���������")]
        public int? EmployeeId { get; set; }

        [Display(Name = "���� �������")]
        [Column(TypeName = "smalldatetime")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]

        public DateTime? SaleDate { get; set; }

        [Display(Name = "�����")]
        [Column(TypeName = "smallmoney")]
        [Required(ErrorMessage = "���� �� ������ ���� ������")]//��������� ��� ��������� ������
        [Range(0, 100000.00, ErrorMessage = "������������ ��������")]

        public decimal? SumPrice { get; set; }

        public virtual Employee Employee { get; set; }

        public virtual WarehouseComponent WarehouseComponent { get; set; }
    }
}
