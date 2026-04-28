namespace ShortcutLib.SR
{
    public static class TranslationCut
    {
        public static string CreateKey(string prefix, string suffix) => $"{prefix}.{suffix}";
        
        // public static void CreateSlimepedia(Identifiable.Id id, PediaDirector.Id entry, Sprite icon, string pediaTitle, string pediaIntro, string pediaDiet, string pediaFavorite, string pediaSlimeology, string pediaRisks, string pediaPlortonomics)
        // {
        //     PediaRegistry.RegisterIdEntry(entry, icon);
        //     PediaRegistry.RegisterIdentifiableMapping((PediaDirector.Id)1, id);
        //     PediaRegistry.RegisterIdentifiableMapping(entry, id);
        //     PediaRegistry.SetPediaCategory(entry, (PediaRegistry.PediaCategory)1);
        //     new SlimePediaEntryTranslation(entry)
        //         .SetTitleTranslation(pediaTitle)
        //         .SetIntroTranslation(pediaIntro)
        //         .SetDietTranslation(pediaDiet)
        //         .SetFavoriteTranslation(pediaFavorite)
        //         .SetSlimeologyTranslation(pediaSlimeology)
        //         .SetRisksTranslation(pediaRisks)
        //         .SetPlortonomicsTranslation(pediaPlortonomics);
        // }
    }
}