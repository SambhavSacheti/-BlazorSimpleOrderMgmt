using System;
using Microsoft.AspNetCore.Components;

namespace OrderManagement.UI.Components.Base
{
    public partial class ButtonBase
    {
        [Parameter]
        public string Text { get; set; }

        [Parameter]
        public EventCallback Click { get; set; }

       [Parameter]
        public string Style { get; set; }
        
        [Parameter]
        public string Class { get; set; }

    }
}
