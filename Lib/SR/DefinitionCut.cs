using UnityEngine;

namespace ShortcutLib.SR
{
    public static class DefinitionCut
    {
        /// <summary>
        /// Creates a <see cref="VacItemDefinition"/> for an <see cref="Identifiable.Id"/>.
        /// </summary>
        /// <param name="identifiable">The <see cref="Identifiable.Id"/> to register.</param>
        /// <param name="icon">A <see cref="Sprite"/> icon to use for the <see cref="Identifiable"/>.</param>
        /// <param name="color">A <see cref="Color"/> to be displayed while vacced.</param>
        /// <param name="name">The name of the <see cref="VacItemDefinition"/>.</param>
        /// <returns><see cref="VacItemDefinition"/></returns>
        public static VacItemDefinition CreateVacDefinition(Identifiable.Id identifiable, Sprite icon, Color color,
            string name)
        {
            var vacItemDefinition = ScriptableObject.CreateInstance<VacItemDefinition>();

            vacItemDefinition.name = name;
            vacItemDefinition.id = identifiable;
            vacItemDefinition.icon = icon;
            vacItemDefinition.color = color;

            return vacItemDefinition;
        }
    }
}