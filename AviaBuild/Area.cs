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
    
    public partial class Area
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Area()
        {
            this.Brigades = new ObservableCollection<Brigade>();
            this.EngTehWorkers = new ObservableCollection<EngTehWorker>();
        }
    
        public int IdArea { get; set; }
        public int CehId { get; set; }
    
        public virtual Ceh Ceh { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ObservableCollection<Brigade> Brigades { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ObservableCollection<EngTehWorker> EngTehWorkers { get; set; }
    }
}
