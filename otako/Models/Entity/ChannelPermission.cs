using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace otako.Models.Entity
{
    public enum ChannelPermission
    {
        CreateInvite = 0,
        ManageChannel = 1,
        ManagePermissions = 2,
        ManageWebhooks = 3,
        ReadMessages = 4,
        SendMessages = 5,
        SendTtsMessages = 6,
        DeleteMessages = 7,
        PinMessages = 8,
        AddHanno = 9,
        EmbedLinks = 10,
        AttachFiles = 11,
        ReadMessageHistory = 12,
        MentionEveryone = 13,
        UseExternalEmotes = 14,
    }
}