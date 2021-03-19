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
        [Display(Name ="����� ������")]
        public int AssemblyPCId { get; set; }
        [Display(Name = "�������������� ��")]
        [Required(ErrorMessage ="���� �� ������ ���� ������")]
        [StringLength(150,MinimumLength =20,ErrorMessage = "����� ������ ������ ���� �� 10 �� 70 ��������")]
        public string CharacteristicPC { get; set; }
        [Display(Name = "���� ������")]
        [Column(TypeName = "smalldatetime")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? DateAssemblyPC { get; set; }
        [Display(Name = "���������� ������")]
        [Required(ErrorMessage = "���� �� ������ ���� ������")]//��������� ��� ��������� ������
        [Range(0, 20, ErrorMessage = "������������ ��������")]

        public int? Amount { get; set; }
        [Display(Name ="���� ������")]
        [Column(TypeName = "smallmoney")]
        [Required(ErrorMessage = "���� �� ������ ���� ������")]//��������� ��� ��������� ������
        [Range(0, 10000.00, ErrorMessage = "������������ ��������")]

        public decimal? AssemblyPrice { get; set; }
        [Display(Name ="��������")]
        [Required(ErrorMessage = "���� �� ������ ���� ������")]//��������� ��� ��������� ������
        [StringLength(50, MinimumLength = 10, ErrorMessage = "����� ������ ������ ���� �� 10 �� 50 ��������")]

        public string PCName { get; set; }
    }
}
