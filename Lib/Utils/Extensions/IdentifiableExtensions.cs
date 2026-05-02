using ShortcutLib.SR;
using SRML.SR;
using UnityEngine;

namespace ShortcutLib.Utils.Extensions
{
    /// <summary>
    /// <see cref="Identifiable"/>-oriented extensions for <see cref="ShortcutLib"/>.
    /// </summary>
    public static class IdentifiableExtensions
    {
        // /// <summary>
        // /// Utilizes a gordo <see cref="Identifiable.Id"/> to search for a linked prefab using <see cref="LookupDirector"/>.
        // /// </summary>
        // /// <param name="identifiable">The gordo <see cref="Identifiable.Id"/> to search for.</param>
        // /// <returns><see cref="GameObject"/></returns>
        // public static GameObject GetGordo(this Identifiable.Id identifiable) => 
        //     !Identifiable.GORDO_CLASS.Contains(identifiable) ? null : GameContext.Instance.LookupDirector.GetGordo(identifiable);
        
        /// <summary>
        /// Registers an <see cref="Identifiable.Id"/> to be a valid target for drones.
        /// </summary>
        /// <param name="identifiable">The <see cref="Identifiable.Id"/> to register.</param>
        public static void AddToDrone(this Identifiable.Id identifiable) =>
            DroneRegistry.RegisterBasicTarget(identifiable);

        /// <summary>
        /// Registers an <see cref="Identifiable.Id"/> to be a refinery resource.
        /// </summary>
        /// <param name="identifiable">The <see cref="Identifiable.Id"/> to register.</param>
        public static void AddToRefinery(this Identifiable.Id identifiable) =>
            AmmoRegistry.RegisterRefineryResource(identifiable);

        /// <summary>
        /// Registers an <see cref="Identifiable.Id"/> into an <see cref="SiloStorage.StorageType"/>.
        /// </summary>
        /// <param name="identifiable">The <see cref="Identifiable.Id"/> to register.</param>
        /// <param name="type">A <see cref="SiloStorage.StorageType"/> to register for.</param>
        public static void AddToSilo(this Identifiable.Id identifiable, SiloStorage.StorageType type) =>
            AmmoRegistry.RegisterSiloAmmo(type, identifiable);

        /// <summary>
        /// Registers an <see cref="Identifiable.Id"/> into an <see cref="PlayerState.AmmoMode"/>.
        /// </summary>
        /// <param name="identifiable">The <see cref="Identifiable.Id"/> to register.</param>
        /// <param name="ammoMode">An <see cref="PlayerState.AmmoMode"/> to register for.</param>
        public static void AddToAmmo(this Identifiable.Id identifiable,
            PlayerState.AmmoMode ammoMode = PlayerState.AmmoMode.DEFAULT) =>
            AmmoRegistry.RegisterPlayerAmmo(ammoMode, identifiable);

        /// <summary>
        /// Registers a <see cref="VacItemDefinition"/> for an <see cref="Identifiable.Id"/>.
        /// </summary>
        /// <param name="identifiable">The <see cref="Identifiable.Id"/> to register.</param>
        /// <param name="icon">A <see cref="Sprite"/> icon to use for the <see cref="Identifiable"/>.</param>
        /// <param name="color">A <see cref="Color"/> to be displayed while vacced.</param>
        /// <param name="name">The name of the <see cref="VacItemDefinition"/>.</param>
        /// <returns><see cref="VacItemDefinition"/></returns>
        public static VacItemDefinition RegisterVacDefinition(this Identifiable.Id identifiable, Sprite icon,
            Color color, string name)
        {
            var vacDefinition = DefinitionCut.CreateVacDefinition(identifiable, icon, color, name);
            LookupRegistry.RegisterVacEntry(vacDefinition);
            return vacDefinition;
        }
    }
}