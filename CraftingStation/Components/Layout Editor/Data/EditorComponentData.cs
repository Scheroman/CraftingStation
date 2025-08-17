namespace CraftingStation.Components.Layout_Editor.Data {
    public class EditorComponentData {
        public ComponentData Component { get; set; }  
        public ComponentData EditorExtensionComponent { get; private set; }
        public ComponentData ChildComponent { get; private set; }

        public EditorComponentData(ComponentData component, Type editorType, ComponentData childComponent) {
            this.Component = component;
            this.EditorExtensionComponent = new ComponentData(editorType);

            if (this.Component is ContainerData container) {
                container.AddOrUpdateParameter(nameof(BaseContainer.Container), this);
            }

            ChildComponent = childComponent;
        }

        public EditorComponentData(ComponentData component) {
            this.Component = component;

            if (this.Component is ContainerData container) {
                container.AddOrUpdateParameter(nameof(BaseContainer.Container), this);
            }
        }
    }
}
