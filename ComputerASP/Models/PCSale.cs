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
        [Display(Name ="����� �������")]
        [Key]
        public int PCSaleId { get; set; }
        [Display(Name = "�������� ��")]
        [Required(ErrorMessage = "���� �� ������ ���� ������")]//��������� ��� ��������� ������
        [StringLength(50, MinimumLength = 10, ErrorMessage = "����� ������ ������ ���� �� 10 �� 50 ��������")]
        public string PCName { get; set; }
        [Display(Name = "��������� ��")]
        [Required(ErrorMessage = "���� �� ������ ���� ������")]//��������� ��� ��������� ������
        [Range(0, 50000.00, ErrorMessage = "������������ ��������")]
        [Column(TypeName = "smallmoney")]
        public decimal? PricePC { get; set; }
        [Display(Name = "���� ������� ��")]
        [Column(TypeName = "smalldatetime")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? SellDate { get; set; }

        [Display(Name = "���� �������� ��")]
        [Column(TypeName = "smalldatetime")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? GuaranteePeriod { get; set; }
        [Display(Name = "������ ��")]
        [Required(ErrorMessage = "���� �� ������ ���� ������")]//��������� ��� ��������� ������
        [StringLength(50, MinimumLength = 10, ErrorMessage = "����� ������ ������ ���� �� 10 �� 50 ��������")]
        public string PCStatus { get; set; }
    }
}
