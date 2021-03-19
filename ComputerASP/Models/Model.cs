namespace ComputerASP.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Model
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Model()
        {
            PurchasePCComponents = new HashSet<PurchasePCComponent>();
        }
        [Display(Name ="����� ������")]
        [Key]
        public int ModelId { get; set; }
        [Display(Name ="������������ ����������")]
        public int? ComponentId { get; set; }
        [Display(Name = "������������ ������")]
        [Required(ErrorMessage = "���� �� ������ ���� ������")]//��������� ��� ��������� ������
        [StringLength(30, MinimumLength = 4, ErrorMessage = "����� ������ ������ ���� �� 4 �� 30 ��������")]

        public string ModelName { get; set; }

        public virtual Component Component { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PurchasePCComponent> PurchasePCComponents { get; set; }
    }
}
