namespace CraftingStation.Components.Layout_Editor.Data {
    public class SerializableComponentData {
        public string ID { get; set; }
        public string TypeName { get; set; } 
        public Dictionary<string, object> Parameters { get; set; } = new();
        public List<SerializableComponentData> Children { get; set; } = new();
    }
}
