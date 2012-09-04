using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Hans.SinglePageApp.Web.Models
{
    public class ProductModel
    {
        [Key]
        public int ProductID { get; set; }

        [Required(ErrorMessage="Product Name is required")]
        [Display(Name="Product Name")]
        public string ProductName { get; set; }

        [Required(ErrorMessage = "Supplier is required")]
        [Display(Name = "Supplier")]
        public int SupplierId { get; set; }

        [Required(ErrorMessage = "Category is required")]
        [Display(Name = "Category")]
        public int CategoryId { get; set; }

        [Required(ErrorMessage = "Quantity per Unit is required")]
        [Display(Name = "Quantity per Unit")]
        [RegularExpression(@"^\d+$", ErrorMessage = "Only numbers allowed")]
        public string QuantityPerUnit { get; set; }

        [Required(ErrorMessage = "Unit Price is required")]
        [Display(Name = "Unit Price")]
        [RegularExpression(@"^\d+$", ErrorMessage = "Only numbers allowed")] //^\d*\.?\d*$
        public double UnitPrice { get; set; }

        [Required(ErrorMessage = "Units in Stock is required")]
        [Display(Name = "Units in Stock")]
        [RegularExpression(@"^\d+$", ErrorMessage = "Only numbers allowed")]
        public int UnitsInStock { get; set; }

        [Required(ErrorMessage = "Units on Order is required")]
        [Display(Name = "Units on Order")]
        [RegularExpression(@"^\d+$", ErrorMessage = "Only numbers allowed")] 
        public int UnitsOnOrder { get; set; }

        [Required(ErrorMessage = "Unit Price is required")]
        [Display(Name = "Reorder Level")]
        [RegularExpression(@"^\d+$", ErrorMessage = "Only numbers allowed")] 
        public int ReorderLevel { get; set; }

        [Display(Name = "Discontinued")]
        public bool Discontinued { get; set; }
    }
}