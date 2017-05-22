using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ClassLibrary;

namespace WebCalcNew.Models
{
    public class OperationViewModel
    {
        public OperationViewModel()
        {
            Operations = new List<SelectListItem>();
        }
        public OperationViewModel(IEnumerable<SelectListItem> operation)
        {
            Operations = operation;
        }
        [Display(Name = "Операция")]
        [Required]
        public string Operation { get; set; }

        [Display(Name = "Параметры")]
        [Required]
        public string InputData { get; set; }

        [Display(Name = "Результат")]
        [ReadOnly(true)]
        public string Result { get; set; }

        public IEnumerable<SelectListItem> Operations { get; set; }
    }
}