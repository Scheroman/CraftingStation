namespace CraftingStation.Components.Configurable {
    public class ConfigurationService {
        private Dictionary<string, Configurable.ConfigurableContainer.Configurable> configurables = new Dictionary<string, ConfigurableContainer.Configurable>();

        public ConfigurationService() {

        }

        public ConfigurableContainer.Configurable GetConfigurable(ConfigurableContainer.Configurable defaultConfigurable) {
            if (configurables.ContainsKey(defaultConfigurable.ID)) {
                return configurables[defaultConfigurable.ID];
            }

            configurables.Add(defaultConfigurable.ID, defaultConfigurable);
            return defaultConfigurable;
        }

        public void AddOrUpdateConfigurable(ConfigurableContainer.Configurable configurable) {
            if (configurables.ContainsKey(configurable.ID)) {
                configurables[configurable.ID] = configurable;
            } else {
                configurables.Add(configurable.ID, configurable);
            }
        }
    }
}
