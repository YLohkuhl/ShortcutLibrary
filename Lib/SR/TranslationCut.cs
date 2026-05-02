using ShortcutLib.Utils.Extensions;
using SRML.SR;
using SRML.SR.Translation;
using UnityEngine;

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

        public static void SetSlimeTranslations(PediaDirector.Id pedia, Identifiable.Id id, Sprite icon, string intro, string diet,
            string favorite, string slimeology, string risks, string plortonomics, bool setTitle = false, string title = "")
        {
            pedia.CreateEntry(icon);
            pedia.LinkEntry(id);
            
            PediaRegistry.RegisterIdentifiableMapping(PediaDirector.Id.SLIMES, id);
            PediaRegistry.SetPediaCategory(pedia, PediaRegistry.PediaCategory.SLIMES);

            var translation = new SlimePediaEntryTranslation(pedia)
                .SetIntroTranslation(intro)
                .SetDietTranslation(diet)
                .SetFavoriteTranslation(favorite)
                .SetSlimeologyTranslation(slimeology)
                .SetRisksTranslation(risks)
                .SetPlortonomicsTranslation(plortonomics);
            
            if (setTitle)
                translation.SetTitleTranslation(title);
        }

        public static void SetResourceTranslations(PediaDirector.Id pedia, Identifiable.Id id, Sprite icon, string intro,
            string description, string resourceType, string favoredBy, string howToUse, bool setTitle = false, string title = "")
        {
            pedia.CreateEntry(icon);
            pedia.LinkEntry(id);

            PediaRegistry.RegisterIdentifiableMapping(PediaDirector.Id.RESOURCES, id);
            PediaRegistry.SetPediaCategory(pedia, PediaRegistry.PediaCategory.RESOURCES);

            // srml needs to have `.SetDescription` or whatever it was for the pedia translation fixed cause there's a typo
            // that makes descriptions not work

            TranslationPatcher.AddPediaTranslation(CreateKey("m.intro", id.ToLower()), intro);
            TranslationPatcher.AddPediaTranslation(CreateKey("m.desc", id.ToLower()), description);
            TranslationPatcher.AddPediaTranslation(CreateKey("m.resource_type", id.ToLower()),  resourceType);
            TranslationPatcher.AddPediaTranslation(CreateKey("m.favored_by",  id.ToLower()), favoredBy);
            TranslationPatcher.AddPediaTranslation(CreateKey("m.how_to_use", id.ToLower()), howToUse);

            if (setTitle)
                TranslationPatcher.AddPediaTranslation(CreateKey("t", id.ToLower()), title);
        }
    }
}