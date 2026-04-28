using SRML;

namespace ShortcutLib
{
    internal class EntryPoint : ModEntryPoint
    {
        public override void PreLoad() => 
            HarmonyInstance.PatchAll();
    }
}