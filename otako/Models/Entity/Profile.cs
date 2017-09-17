namespace otako.Models.Entity
{
    public enum OtakoFeature
    {
        Boost = 0,
        Fusion = 1,
        WeebSquad = 2,
        Partner = 3,
        Mod = 4,
        Admin = 5,
        Staff = 6,
        Developer = 7
    }

    public enum OtakoFlag
    {
        Boost = 0,
        Fusion = 1,
        WeebSquad = 2,
        Partner = 3,
        Helper = 4,
        Mod = 5,
        Admin = 6,
        Staff = 7,
        Developer = 8
    }

    public enum SabaFeature
    {
        VanityUrl = 0,
        InviteSplash = 1,
        VipRegions = 2,
        GlobalEmotes = 3
    }

    public enum VerificationLevel
    {
        Unclaimed = 0,
        Claimed = 1,
        EmailVerified = 2,
        PhoneVerified = 3,
        Trusted = 4
    }

    public enum WarningLevel
    {
        None = 0,
        Low = 1,
        Meduim = 2,
        High = 3,
        Rekt = 4
    }
}