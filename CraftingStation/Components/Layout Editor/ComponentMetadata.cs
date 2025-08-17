//using Microsoft.AspNetCore.Components;
//using Telerik.DataSource.Extensions;

//namespace CraftingStation.Components.Layout_Editor {
//    public class ComponentMetadata {
//        public string ID { get; private set; }
//        public Type Type { get; private set; }
//        public ContainerMetadata Parent { get; set; }
//        public Type EditorType { get; private set; }
//        public DynamicComponent EditorDynamicComponent { get; set; }
//        public Dictionary<string, object> EditorParameters { get; private set; } = new Dictionary<string, object>();
//        public DynamicComponent Component { get; set; }

//        public ComponentMetadata(Type type, Dictionary<string, object> parameters, Type editorType) {
//            ID = Guid.NewGuid().ToString();
//            Type = type;

//            if (parameters != null && parameters.Count > 0) {
//                ParametersInternal.AddRange(parameters);
//            }

//            EditorType = editorType;

//            if (type == null) {
//                return;
//            }

//            var parameterProps = Type.GetProperties(System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Instance)
//                .Where(p => Attribute.IsDefined(p, typeof(ParameterAttribute)));

//            var defaultInstance = Activator.CreateInstance(Type);
//            foreach (var prop in parameterProps) {
//                if (!ParametersInternal.ContainsKey(prop.Name)) {
//                    ParametersInternal[prop.Name] = prop.GetValue(defaultInstance);
//                }
//            }

//        }

//        public Dictionary<string, object> Parameters {
//            get {
//                return ParametersInternal;
//            }
//        }

//        public Dictionary<string, object> ParametersInternal = new Dictionary<string, object>();
//    }

//    public class ContainerMetadata : ComponentMetadata {

//        public ContainerMetadata(Type type, Dictionary<string, object> parameters, Type editorType) : base(type, parameters, editorType) {
//            //ParametersInternal.Add(nameof(BaseContainer.Components), this.Children);

//            if (ParametersInternal.ContainsKey(nameof(BaseContainer.Container))) {
//                ParametersInternal[nameof(BaseContainer.Container)] = this;
//            }
//        }

//        public List<ComponentMetadata> Children { get; set; } = new List<ComponentMetadata>();
//    }
//}
