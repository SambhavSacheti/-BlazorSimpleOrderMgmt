using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;

namespace OrderManagement.UI.Components.Base
{
    public partial class TextBoxBase
    {
        [Parameter]
        public string Value { get; set; }

        [Parameter]
        public string Class { get; set; }

        [Parameter]
        public string Id { get; set; }

        public string GetValue() => this.Value;

        public string SetValue(string value) => this.Value = value;
    }
}
