
namespace CraftingStation.Components.Layout_Editor.Data {
    public class EditorData {
        public bool Edit = false;
        public ComponentData HoveredComponent = null;
        public ComponentData SelectedComponent {
            get {
                return selectedComponent;
            }
            set {
                selectedComponent = value;
                EditorDataChanged.Invoke(null, this);
            }
        }

        public event EventHandler<EditorData> EditorDataChanged;

        private ComponentData selectedComponent;

        public void InvokeChange() {
            EditorDataChanged.Invoke(null, this);
        }
    }
}
