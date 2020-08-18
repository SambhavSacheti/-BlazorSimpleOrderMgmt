using System;
using Microsoft.AspNetCore.Components;

namespace OrderManagement.UI.Components.Base
{
    public partial class ImageBase{

        [Parameter]
        public string Path { get; set; }

        [Parameter]
        public string Style { get; set; }
    }
}