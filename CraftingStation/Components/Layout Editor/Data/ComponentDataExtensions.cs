using System.ComponentModel;
using System.Linq;

namespace CraftingStation.Components.Layout_Editor.Data {
    public static class ComponentDataExtensions {
        public static SerializableComponentData ToSerializable(this ComponentData component) {
            var dto = new SerializableComponentData {
                ID = component.ID,
                TypeName = component.Type?.AssemblyQualifiedName, // can be restored with Type.GetType()
                Parameters = getParameters(component)
            };

            if (component is ContainerData container) {
                dto.Children = container.Children
                    .Select(child => child.ToSerializable())
                    .ToList();
            }

            return dto;
        }

        private static Dictionary<string, object> getParameters(ComponentData component) {
            Dictionary<string, object> parameters = new Dictionary<string, object>();

            foreach (var kvp in component.Parameters) {
                if (kvp.Value == null || kvp.Value.GetType().IsPrimitive || kvp.Value is string || kvp.Value is Guid) {
                    parameters.Add(kvp.Key, kvp.Value);
                }

                if (kvp.Value is SubContainerData subComponent) {
                    parameters.Add(kvp.Key, subComponent.ToSerializable());
                }
            }

            return parameters;
            //return component.Parameters
            //        .Where(kvp => kvp.Value == null
            //                   || kvp.Value.GetType().IsPrimitive
            //                   || kvp.Value is string
            //                   || kvp.Value is Guid).Join(component.Parameters.Where(p => p is ComponentData))
            //        .ToDictionary(kvp => kvp.Key, kvp => kvp.Value);
        }
    }
}
