using System.Collections.Generic;

namespace SageCS.INI
{
    class ModifierList
    {
        public string Category;
        public Dictionary<string, float> modifiers = new Dictionary<string, float>();
        public int Duration;
        public string FX;
        public string FX2;
        public string FX3;
        public bool MultiLevelFX;
        public string EndFX;
        public string EndFX2;
        public string EndFX3;
        public bool ReplaceInCategoryIfLongest;
        public bool IgnoreIfAnticategoryActive;
        public string ModelCondition;
        public string ClearModelCondition;
        public string Upgrade;

        public void AddModifier(string key, float value)
        {
            if (!modifiers.ContainsKey(key))
                modifiers.Add(key, value);
            else
                modifiers[key] = value;
        }
    }
}
