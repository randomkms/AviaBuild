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
    
    public partial class Worker
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Worker()
        {
            this.WorkerProfs = new ObservableCollection<WorkerProf>();
        }
    
        public int IdWorker { get; set; }
        public int BrigadeId { get; set; }
        public bool IsBrigadier { get; set; }
        public string WorkerName { get; set; }
    
        public virtual Brigade Brigade { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ObservableCollection<WorkerProf> WorkerProfs { get; set; }
    }
}
