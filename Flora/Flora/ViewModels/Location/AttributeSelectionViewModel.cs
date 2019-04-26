using System;
using System.Collections.Generic;
using System.Text;

namespace Flora.ViewModels.Location
{
    public class AttributeSelectionViewModel
    {
        public List<Models.Attribute> Attributes { get; set; }

        public string FirstHeading { get; set; }
        public string SecondHeading { get; set; }

        public AttributeSelectionViewModel(List<Models.Attribute> attributes)
        {
            Attributes = attributes;
        }
    }
}
