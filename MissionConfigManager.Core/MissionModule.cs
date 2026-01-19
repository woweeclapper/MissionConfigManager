namespace MissionConfigManager.Core
{
    public class MissionModule
    {
        public int Id { get; set; }

        // Module name (e.g., "PowerSystem", "LifeSupport")
        public string Name { get; set; } = string.Empty;

        // Navigation property for parameters
        public List<MissionParameter> Parameters { get; set; } = new();
    }
}

