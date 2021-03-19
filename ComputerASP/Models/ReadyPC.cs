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
        [Display(Name ="����� ��")]
        [Key]
        public int ReadyPCId { get; set; }
        [Display(Name = "���������")]
        public int? SupplierId { get; set; }
        [Display(Name = "���� ��������")]
        [Column(TypeName = "smalldatetime")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? PurchaseDate { get; set; }
        [Display(Name = "��������� ��")]
        [Column(TypeName = "smallmoney")]
        [Required(ErrorMessage = "���� �� ������ ���� ������")]//��������� ��� ��������� ������
        [Range(0, 50000.00, ErrorMessage = "������������ ��������")]
        public decimal? PurchasePrice { get; set; }
        [Display(Name = "�������� ��")]
        [Required(ErrorMessage = "���� �� ������ ���� ������")]//��������� ��� ��������� ������
        [StringLength(50, MinimumLength = 10, ErrorMessage = "����� ������ ������ ���� �� 10 �� 50 ��������")]

        public string PCName { get; set; }
        [Display(Name = "�������������� ��")]
        [Required(ErrorMessage = "���� �� ������ ���� ������")]//��������� ��� ��������� ������
        [StringLength(150, MinimumLength = 10, ErrorMessage = "����� ������ ������ ���� �� 10 �� 150 ��������")]

        public string CharacteristicPC { get; set; }
        [Display(Name = "���������� ��")]
        [Required(ErrorMessage = "���� �� ������ ���� ������")]//��������� ��� ��������� ������
        [Range(0, 20, ErrorMessage = "������������ ��������")]

        public int? Amount { get; set; }

        public virtual Supplier Supplier { get; set; }
    }
}
