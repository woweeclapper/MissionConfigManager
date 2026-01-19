namespace MissionConfigManager.Api.DTOs
{
    public class ModuleDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = "";
        public List<ParameterDto> Parameters { get; set; } = new();
    }
}
