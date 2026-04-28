using System;
using System.Collections.Generic;
using ShortcutLib.Utils.Extensions;
using SRML.SR;
using SRML.Utils.Enum;

namespace ShortcutLib.SR
{
    /// <summary>
    /// Represents a variety of Achievement-related methods operated through <see cref="ShortcutLib"/>.
    /// Methods include, but not limited to; <see cref="RegisterAchievement"/>,
    /// <see cref="AwardAchievement"/>, <see cref="AddToStat(AchievementsDirector.IntStat,int,bool)"/>.
    /// </summary>
    public static class AchievementCut
    {
        private static AchievementsDirector Achievements => SceneContext.Instance.AchievementsDirector;
        
        /// <summary>
        /// Registers, and automatically translates a modded <see cref="AchievementsDirector.Achievement"/>.
        /// </summary>
        /// <param name="id">The custom <see cref="AchievementsDirector.Achievement"/> id, particularly pre-registered with an <see cref="EnumHolderAttribute"/>.</param>
        /// <param name="name">The full name of the achievement, this is automatically translated in-game.</param>
        /// <param name="description">The full description of the achievement, this is automatically translated in-game.</param>
        /// <param name="tracker">A <see cref="AchievementsDirector.Tracker"/> for the achievement, this tracks all of it's progress throughout the game.</param>
        /// <param name="tier">The <see cref="AchievementRegistry.Tier"/> of the achievement. Typically; tier 1, tier 2, tier 3.</param>
        public static void RegisterAchievement(AchievementsDirector.Achievement id, string name, string description,
            AchievementsDirector.Tracker tracker, AchievementRegistry.Tier tier = AchievementRegistry.Tier.TIER1)
        {
            AchievementRegistry.RegisterModdedAchievement(id, tracker, tier);
            TranslationPatcher.AddAchievementTranslation(TranslationCut.CreateKey("t", id.ToLower()), name);
            TranslationPatcher.AddAchievementTranslation(TranslationCut.CreateKey("m.reqmt", id.ToLower()), description);
        }
        
        public static void AwardAchievement(AchievementsDirector.Achievement id) => Achievements.AwardAchievement(id);
        
        public static void HasAchievement(AchievementsDirector.Achievement id) => Achievements.HasAchievement(id);

        #region RESET_STAT
        
        public static void ResetStat(AchievementsDirector.IntStat stat)
        {
            Achievements.ResetStat(stat);
            Achievements.CheckAchievements(stat);
        }
        
        public static void ResetStat(AchievementsDirector.GameIntStat stat)
        {
            Achievements.gameAchievesModel.gameIntStatDict[stat] = 0;
            Achievements.CheckAchievements(stat);
        }
        
        public static void ResetStat(AchievementsDirector.GameFloatStat stat)
        {
            Achievements.gameAchievesModel.gameFloatStatDict[stat] = 0;
            Achievements.CheckAchievements(stat);
        }
        
        public static void ResetStat(AchievementsDirector.GameDoubleStat stat)
        {
            Achievements.gameAchievesModel.gameDoubleStatDict[stat] = 0;
            Achievements.CheckAchievements(stat);
        }
        
        public static void ResetStat(AchievementsDirector.GameIdDictStat stat)
        {
            Achievements.gameAchievesModel.gameIdDictStatDict[stat] = new Dictionary<Identifiable.Id, int>();
            Achievements.CheckAchievements(stat);
        }

        public static void ResetStat(AchievementsDirector.EnumStat stat)
        {
            if (!Achievements.AllowStatUpdate(Achievements.GAME_MODE_ENUM_STATS, stat))
                return;
            Achievements.profileAchievesModel.enumStatDict[stat] = new HashSet<Enum>();
            Achievements.CheckAchievements(stat);
        }
        
        public static void ResetStat(AchievementsDirector.BoolStat stat)
        {
            if (!Achievements.AllowStatUpdate(Achievements.GAME_MODE_BOOL_STATS, stat))
                return;
            Achievements.profileAchievesModel.boolStatDict[stat] = false;
            Achievements.CheckAchievements(stat);
        }
        
        #endregion
        
        #region GET_STAT
        
        public static int? GetStat(AchievementsDirector.IntStat stat) => Achievements.GetStat(stat);
        
        public static int GetStat(AchievementsDirector.GameIntStat stat) => Achievements.GetGameIntStat(stat);
        
        public static float GetStat(AchievementsDirector.GameFloatStat stat) => 
            Achievements.gameAchievesModel.gameFloatStatDict.Get(stat);
        
        public static double GetStat(AchievementsDirector.GameDoubleStat stat) => 
            Achievements.gameAchievesModel.gameDoubleStatDict.Get(stat);
        
        public static bool GetStat(AchievementsDirector.BoolStat stat) => 
            Achievements.profileAchievesModel.boolStatDict.Get(stat);
        
        public static HashSet<Enum> GetStat(AchievementsDirector.EnumStat stat) => 
            Achievements.profileAchievesModel.enumStatDict.Get(stat);
        
        public static Dictionary<Identifiable.Id, int> GetStat(AchievementsDirector.GameIdDictStat stat) =>
            Achievements.GetGameIdDictStat(stat);
        
        #endregion
        
        #region SET_STAT
        
        public static void SetStat(AchievementsDirector.GameFloatStat stat, float val) => Achievements.SetStat(stat, val);

        public static void SetStat(AchievementsDirector.GameDoubleStat stat, double val) => Achievements.SetStat(stat, val);
        
        public static void SetStat(AchievementsDirector.GameIntStat stat, int val)
        {
            Achievements.gameAchievesModel.gameIntStatDict[stat] = val;
            Achievements.CheckAchievements(stat);
        }
        
        public static void SetStat(AchievementsDirector.GameIdDictStat stat, Dictionary<Identifiable.Id, int> val)
        {
            Achievements.gameAchievesModel.gameIdDictStatDict[stat] = val;
            Achievements.CheckAchievements(stat);
        }
        
        public static void SetStat(AchievementsDirector.IntStat stat, int val)
        {
            if (!Achievements.AllowStatUpdate(Achievements.GAME_MODE_INT_STATS, stat))
                return;
            Achievements.profileAchievesModel.intStatDict[stat] = val;
            Achievements.CheckAchievements(stat);
        }
        
        public static void SetStat(AchievementsDirector.BoolStat stat, bool val)
        {
            if (!Achievements.AllowStatUpdate(Achievements.GAME_MODE_BOOL_STATS, stat))
                return;
            Achievements.profileAchievesModel.boolStatDict[stat] = val;
            Achievements.CheckAchievements(stat);
        }
        
        public static void SetStat(AchievementsDirector.EnumStat stat, HashSet<Enum> val)
        {
            if (!Achievements.AllowStatUpdate(Achievements.GAME_MODE_ENUM_STATS, stat))
                return;
            Achievements.profileAchievesModel.enumStatDict[stat] = val;
            Achievements.CheckAchievements(stat);
        }
        
        #endregion
        
        #region ADD_TO_STAT
        
        public static void AddToStat(AchievementsDirector.EnumStat stat, Enum val) => Achievements.AddToStat(stat, val);
        
        public static void AddToStat(AchievementsDirector.GameIntStat stat, int amt) => Achievements.AddToStat(stat, amt);

        public static void AddToStat(AchievementsDirector.GameIdDictStat stat, Identifiable.Id id, int amt) =>
            Achievements.AddToStat(stat, id, amt);

        public static void AddToStat(AchievementsDirector.IntStat stat, int amt, bool maybeUpdateMaxStat = false)
        {
            if (maybeUpdateMaxStat)
            {
                Achievements.MaybeUpdateMaxStat(stat, amt);
                return;
            }
            Achievements.AddToStat(stat, amt);
        }
        
        public static void AddToStat(AchievementsDirector.GameFloatStat stat, float amt)
        {
            var num = Achievements.gameAchievesModel.gameFloatStatDict.ContainsKey(stat)
                ? Achievements.gameAchievesModel.gameFloatStatDict[stat]
                : 0;
            Achievements.gameAchievesModel.gameFloatStatDict[stat] = num + amt;
            Achievements.CheckAchievements(stat);
        }
        
        public static void AddToStat(AchievementsDirector.GameDoubleStat stat, double amt)
        {
            var num = Achievements.gameAchievesModel.gameDoubleStatDict.ContainsKey(stat)
                ? Achievements.gameAchievesModel.gameDoubleStatDict[stat]
                : 0;
            Achievements.gameAchievesModel.gameDoubleStatDict[stat] = num + amt;
            Achievements.CheckAchievements(stat);
        }
        
        #endregion
    }
}