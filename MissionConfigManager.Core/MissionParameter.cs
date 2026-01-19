namespace MissionConfigManager.Core
{
using System.Text.Json.Serialization;

public class MissionParameter
{
    public int Id { get; set; }
    public string Key { get; set; } = "";
    public string Value { get; set; } = "";

    public int MissionModuleId { get; set; }

    [JsonIgnore]   // ← prevents infinite loop
    public MissionModule? Module { get; set; }
}

}

