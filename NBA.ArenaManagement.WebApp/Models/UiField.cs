using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NBA.ArenaManagement.WebApp.Models
{
    public class UiField
    {
        public int Id { get; set; }
        public string FieldText { get; set; }
        public string FieldType { get; set; }
        public string[] FieldValues { get; set; }
        public string FieldCss { get; set; }
        public int FieldOrder { get; set; }
        public string FieldCategory { get; set; }
        public bool IsExpandable { get; set; }
        public string FieldSubCategory { get; set; }
        public bool IsVisibleToPublic { get; set; }
        public bool IsNbaNoteFieldEnabled { get; set; }
        public string FieldDescription { get; set; }
        public string PlaceHolderText { get; set; }
        public int Max { get; set; }
        public int Min { get; set; }
        public decimal Step { get; set; }
        public bool NbaOnlyField { get; set; }
        public bool ShowDescriptionAsText { get; set; }
        public string InputMask { get; set; }
        public bool IsTeamNoteFieldEnabled { get; set; }
    }
}