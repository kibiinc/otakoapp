namespace otako.WebSocket
{
    public enum DispatchType
    {
        MessageCreate = 0,
        MessageUpdate = 1,
        MessageDelete = 2,
        ChannelCreate = 3,
        ChannelUpdate = 4,
        ChannelDelete = 5,
        SabaCreate = 6,
        SabaUpdate = 7,
        SabaDelete = 8,
        SabaMemberAdd = 9,
        SabaMemberRemove = 10,
        SabaMemberKicked = 11,
        SabaBanAdd = 12,
        SabaBanRemove = 13,
        SabaMemberUpdate = 14,
        RoleCreate = 15,
        RoleUpdate = 16,
        RoleDelete = 17,
        UserSenseUpdate = 18,
        UserUpdate = 19,
        WebhookUpdate = 20,
        MessageBulkDelete = 21,
        MessageHannoAdd = 22,
        MessageHannoRemove = 23,
        MessageHannoRemoveAll = 24,
        AccountDisable = 25,
        AccountDelete = 26,
        UpdateAvaliable = 27,
        ServiceDown = 28,
        ServiceUpdate = 29,
        Execution = 30,
        RelationshipAdd = 31,
        RelationshipRemove = 32
    }
}