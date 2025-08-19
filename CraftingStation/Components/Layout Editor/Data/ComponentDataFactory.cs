using System.Text.Json;

namespace CraftingStation.Components.Layout_Editor.Data {
    public static class ComponentDataFactory {
        public static ComponentData ToComponentData(this SerializableComponentData dto, ContainerData parent = null) {
            // Restore the Type
            var type = dto.TypeName == null ? null : Type.GetType(dto.TypeName);

            ComponentData component;

            // If it has children → it's a ContainerData
            if (dto.Children != null && dto.Children.Any()) {
                var container = new ContainerData(type, dto.Parameters
                .ToDictionary(
                    kvp => kvp.Key,
                    kvp => NormalizeParameterValue(kvp.Value)
                ));
                container.Children = dto.Children
                    .Select(childDto => childDto.ToComponentData(container))
                    .ToList();
                component = container;
            } else {
                component = new ComponentData(type, dto.Parameters
                .ToDictionary(
                    kvp => kvp.Key,
                    kvp => NormalizeParameterValue(kvp.Value)
                ));
            }

            // Set Parent reference
            component.Parent = parent;

            return component;
        }

        private static Dictionary<string, object> getParameters(SerializableComponentData component) {
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

        private static object NormalizeParameterValue(object value) {
            if (value is JsonElement jsonElement) {
                switch (jsonElement.ValueKind) {
                    case JsonValueKind.String:
                        return jsonElement.GetString();
                    case JsonValueKind.Number:
                        if (jsonElement.TryGetInt32(out var i))
                            return i;
                        if (jsonElement.TryGetDouble(out var d))
                            return d;
                        return jsonElement.GetRawText();
                    case JsonValueKind.True:
                    case JsonValueKind.False:
                        return jsonElement.GetBoolean();
                    case JsonValueKind.Null:
                        return null;
                    default:
                        return jsonElement.GetRawText(); // fallback for objects/arrays
                }
            }

            return value;
        }
    }
}
