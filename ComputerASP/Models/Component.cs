namespace ComputerASP.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Component
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Component()
        {
            Models = new HashSet<Model>();
            PurchasePCComponents = new HashSet<PurchasePCComponent>();
        }
        [Display(Name ="����� ����������")]
        [Key]
        public int ComponentId { get; set; }
        [Display(Name ="������������ ����������")]
        [Required(ErrorMessage = "���� �� ������ ���� ������")]//��������� ��� ��������� ������
        [StringLength(30, MinimumLength = 4, ErrorMessage = "����� ������ ������ ���� �� 4 �� 30 ��������")]

        public string ComponentName { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Model> Models { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PurchasePCComponent> PurchasePCComponents { get; set; }
    }
}
