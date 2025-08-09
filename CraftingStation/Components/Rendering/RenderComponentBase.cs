using Microsoft.AspNetCore.Components;

namespace CraftingStation.Components.Rendering
{
    public abstract class RenderComponentBase : ComponentBase
    {
        public RenderFragment Content => GetContent();


        protected abstract RenderFragment GetContent();
    }
}
