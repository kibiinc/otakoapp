using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace otako.Models.Entity
{
    public enum RolePermission
    {
        ReadMessages = 0,
        SendMessages = 1,
        DeleteMessages = 2,
        PinMessages = 3,
        ViewAuditLog = 4,
        ManageSaba = 5,
        ManageRoles = 6,
        ManageChannels = 7,
        KickMembers = 8,
        BanMembers = 9,
        CreateInvite = 10,
        ChangeNickname = 11,
        ManageNicknames = 12,
        ManageEmotes = 13,
        ManageWebhooks = 14,
        SendTtsMessages = 15,
        EmbedLinks = 16,
        AttachFiles = 17,
        ReadMessageHistory = 18,
        MentionEverone = 19,
        UseExternalEmotes = 20,
        AddHanno = 21,
        Connect = 22,
        Speak = 23,
        MuteMembersVoice = 24,
        DeafenMembers = 25,
        MoveMembers = 26,
        UseAutoVoice = 27,
        MuteMembersChat = 28
    }
}