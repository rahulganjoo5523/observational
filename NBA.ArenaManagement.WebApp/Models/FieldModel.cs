using System;

namespace NBA.ArenaManagement.WebApp.Models
{
    public class FieldModel
    {
        public string FieldId { get; set; }
        public string FieldText { get; set; }
        public string FieldValue { get; set; }        
        public string NbaNotes { get; set; }
        public string TeamNotes { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime ModifiedDate { get; set; }
    }
}