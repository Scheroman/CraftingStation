using Microsoft.AspNetCore.Components;

namespace CraftingStation.Components.Layout_Editor.Data {
    public class ComponentData {
        public string ID { get; private set; }
        public Type Type { get; private set; }
        public Dictionary<string, object> Parameters { get; private set; } = new Dictionary<string, object>();
        public ContainerData Parent { get; set; }
        public DynamicComponent DynamicComponent { get; set; }

        public ComponentData(Type type) {
            this.Type = type;
            this.ID = Guid.NewGuid().ToString();
        }

        public ComponentData(Type type, Dictionary<string, object> parameters) {
            this.Type = type;
            this.ID = Guid.NewGuid().ToString();
            this.AddOrUpdateParameters(parameters);
        }

        public void AddOrUpdateParameter(string name, object value) {
            if (Parameters.ContainsKey(name)) {
                Parameters[name] = value;
            } else {
                Parameters.Add(name, value);
            }
        }

        public void AddOrUpdateParameters(Dictionary<string, object> parameters) {
            foreach (KeyValuePair<string, object> kvp in parameters) {
                this.AddOrUpdateParameter(kvp.Key, kvp.Value);
            }
        }
    }


    public class ContainerData : ComponentData {
        public List<ComponentData> Children { get; set; } = new List<ComponentData>();

        public ContainerData(Type type) : base(type) {
            if (type == null) {
                return;
            }

            if (type.IsSubclassOf(typeof(BaseContainer))) {
                this.AddOrUpdateParameter(nameof(BaseContainer.Container), this);
            }
        }

        public ContainerData(Type type, Dictionary<string, object> parameters) : base(type, parameters) {
            if (type == null) {
                return;
            }

            if (type.IsSubclassOf(typeof(BaseContainer))) {
                this.AddOrUpdateParameter(nameof(BaseContainer.Container), this);
            }
        }
    }

    public class SubContainerData : ContainerData {

        public SubContainerData(Type type) : base(type) {
        }

        public SubContainerData(Type type, Dictionary<string, object> parameters) : base(type, parameters) {
        }
    }
}
