namespace SageCS.INI
{
    class Upgrade
    {
        public string DisplayName;
        public string Type;         //PLAYER or OBJECT
        public float BuildTime;
        public float BuildCost;
        public string ButtonImage;
        public string ResearchSound;
        public string UnitSpecificSound;
        public string Tooltip;
        public string Cursor;
        public string ReserarchSound;
        public bool PersistsInCampaign;
        public string LocalPlayerGainsUpgradeEvaEvent;
        public string AlliedPlayerGainsUpgradeEvaEvent;
        public string EnemyPlayerGainsUpgradeEvaEvent;
        public string AlliedPlayerLosesUpgradeEvaEvent;
        public string EnemyPlayerLosesUpgradeEvaEvent;
        public string StrategicIcon;
        public bool NoUpgradeDiscount;
        public string UseObjectTemplateForCostDiscount;
        public string ResearchCompleteEvaEvent;
        public string RequiredObjectFilter;
        public string UpgradeFX;
        public string SkirmishAIHeuristic;
        public string SubUpgradeTemplateNames;
    }
}
