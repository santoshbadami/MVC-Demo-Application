using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FluentValidation;
using FluentValidation.Attributes;
using System.Web.Mvc;



namespace MvcDemoApplication.web.Models
{
    public class Enums
    {
        public enum ApplicationStatus
        {
            Pending = 0,
            Submitted = 1,
            Disapproved = 2,
            Approved = 3
        }
    }

    [FluentValidation.Attributes.Validator(typeof(FluentDataModelValidator))]
    public class FluentDataModel
    {
        public int ValInt1 { get; set; }

        public int? ValInt2 { get; set; }

        public string ValString1 { get; set; }

        public string ValString2 { get; set; }

        public double ValDouble1 { get; set; }

        public double? ValDouble2 { get; set; }

        public DateTime ValDateTime1 { get; set; }

        public DateTime? ValDateTime2 { get; set; }

        public SelectList ApplicationStatus { get; set; }

        public int SelectedApplicationStatus { get; set; }

        public DateTime? ApplicationSubmitted { get; set; } 
    }
}