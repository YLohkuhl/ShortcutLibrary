using ShortcutLib.SR;
using SRML.SR;

namespace ShortcutLib.Utils.Extensions;

public static class IdentifiableExtensions
{
    public static void AddToDrone(this Identifiable.Id identifiable) => DroneRegistry.RegisterBasicTarget(identifiable);

    public static void AddToRefinery(this Identifiable.Id identifiable) => AmmoRegistry.RegisterRefineryResource(identifiable);
    
    public static void AddToSilo(this Identifiable.Id identifiable, SiloStorage.StorageType type) =>
        AmmoRegistry.RegisterSiloAmmo(type, identifiable);
    
    public static void AddToAmmo(this Identifiable.Id identifiable, PlayerState.AmmoMode ammoMode = PlayerState.AmmoMode.DEFAULT) => 
        AmmoRegistry.RegisterPlayerAmmo(ammoMode, identifiable);
    
    public static VacItemDefinition RegisterVac(this Identifiable.Id identifiable, Sprite icon, Color color, string name)
    {
        var vacDefinition = DefinitionCut.CreateVacDefinition(identifiable, icon, color, name);
        LookupRegistry.RegisterVacEntry(vacDefinition);
        return vacDefinition;
    }
}