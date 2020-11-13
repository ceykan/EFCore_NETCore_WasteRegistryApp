using System;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace WasteRegistry.UI.Models
{
    public class WasteRegistryViewModel
    {
        public int Id { get; set; }
        [Required(AllowEmptyStrings = false)]
        public string Store { get; set; }
        [Required(AllowEmptyStrings = false)]
        public string WasteType { get; set; }
        [Required(AllowEmptyStrings = false)]
        public int Month { get; set; }
        [Required(AllowEmptyStrings = false)]
        public string WasteKind { get; set; }
        [Range(1, int.MaxValue, ErrorMessage = "Quantity must be higher than 0")]
        public int Quantity { get; set; }
        [Required(AllowEmptyStrings = false)]
        public string QuantityUnit { get; set; }
        [Required(AllowEmptyStrings = false)]
        public string RecipientCompany { get; set; }
        [Required(AllowEmptyStrings = false)]
        public DateTime WasteDate { get; set; }
        [Required(AllowEmptyStrings = false)]
        public string Content { get; set; }

    }
}
