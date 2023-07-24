using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.JSInterop;

namespace bjorkvalle.UI.Utilities
{
    public abstract class InputDateBase<TItem> : InputDate<TItem>
    {
        [Inject] public IJSRuntime JSRuntime { get; set; }

        /// <summary>
        /// Gets or sets the unique id of the element.
        /// </summary>
        /// <remarks>
        /// Note that this ID is not defined for the component but instead for the underlined element that it represents.
        /// eg: for the TextEdit the ID will be set on the input element.
        /// </remarks>
        [Parameter] public string ElementId { get; set; }

        /// <summary>
        /// Toggle component load vs unload
        /// </summary>
        [Parameter] public bool NoRender { get; set; }

        protected readonly IClassBuilder classBuilder;

        public InputDateBase()
        {
            classBuilder = new ClassBuilder();
        }

        protected override void OnInitialized()
        {
            if (ElementId == null)
                ElementId = GetRandomString();

            base.OnInitialized();
        }

        public async Task JSInvokeVoidAsync(string identifier) => await JSRuntime.InvokeVoidAsync(identifier);
        public async Task JSInvokeVoidAsync(string identifier, params object[] args) => await JSRuntime.InvokeVoidAsync(identifier, args);

        /// <summary>
        /// Gets the built class-names based on all the rules set by the component parameters.
        /// </summary>
        public string ClassNames => classBuilder?
            .AddClassFromAttributes(AdditionalAttributes)
            .GetClass();

        private string GetRandomString()
        {
            string path = System.IO.Path.GetRandomFileName();
            path = path.Replace(".", "");
            return path;
        }
    }
}
