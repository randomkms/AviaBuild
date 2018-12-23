//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace AviaBuild
{
    using System;
    using System.Collections.ObjectModel;
    
    public partial class Product
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Product()
        {
            this.Planes = new ObservableCollection<Plane>();
            this.Rockets = new ObservableCollection<Rocket>();
            this.Works = new ObservableCollection<Work>();
        }
    
        public int IdProduct { get; set; }
        public int CehId { get; set; }
        public int TestEquipmentId { get; set; }
        public Nullable<System.DateTime> StartBuild { get; set; }
        public Nullable<System.DateTime> EndBuild { get; set; }
        public Nullable<System.DateTime> StartTest { get; set; }
        public Nullable<System.DateTime> EndTest { get; set; }
        public string Category { get; set; }
    
        public virtual Ceh Ceh { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ObservableCollection<Plane> Planes { get; set; }
        public virtual TestEquipment TestEquipment { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ObservableCollection<Rocket> Rockets { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ObservableCollection<Work> Works { get; set; }
    }
}