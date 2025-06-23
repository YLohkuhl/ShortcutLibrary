namespace ShortcutLib.SR;

public static class DefinitionCut
{
    public static VacItemDefinition CreateVacDefinition(Identifiable.Id identifiable, Sprite icon, Color color, string name)
    {
        VacItemDefinition vacItemDefinition = ScriptableObject.CreateInstance<VacItemDefinition>();

        vacItemDefinition.name = name;
        vacItemDefinition.id = identifiable;
        vacItemDefinition.icon = icon;
        vacItemDefinition.color = color;

        return vacItemDefinition;
    }
}