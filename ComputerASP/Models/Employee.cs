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
        [Display(Name ="��� ����������")]
        [Key]
        public int EmployeeId { get; set; }
        [Display(Name = "��� ����������")]
        [Required(ErrorMessage = "���� �� ������ ���� ������")]//��������� ��� ��������� ������
        [StringLength(30, MinimumLength = 5, ErrorMessage = "����� ������ ������ ���� �� 2 �� 30 ��������")]
        public string FIO { get; set; }
        [Display(Name = "�����")]
        [Required(ErrorMessage = "���� �� ������ ���� ������")]
        [StringLength(20, MinimumLength = 5, ErrorMessage = "����� ������ ������ ���� �� 5 �� 20 ��������")]
        public string City { get; set; }
        [Display(Name = "�����")]
        [Required(ErrorMessage = "���� �� ������ ���� ������")]
        [StringLength(50, MinimumLength = 5, ErrorMessage = "����� ������ ������ ���� �� 5 �� 50 ��������")]
        public string Address { get; set; }
        [Display(Name = "�������")]
        [Required(ErrorMessage = "���� �� ������ ���� ������")]
        [RegularExpression(@"[0-9]{12}", ErrorMessage = "������ ������ 380���������")]
        public long? Phone { get; set; }
        [Display(Name = "���������")]
        [Required(ErrorMessage = "���� �� ������ ���� ������")]
        [StringLength(50, MinimumLength = 5, ErrorMessage = "����� ������ ������ ���� �� 5 �� 50 ��������")]

        public string Position { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<RetailInvoice> RetailInvoices { get; set; }
    }
}
