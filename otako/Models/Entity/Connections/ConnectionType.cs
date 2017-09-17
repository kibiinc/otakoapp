using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace otako.Models.Entity
{
    public enum ConnectionType
    {
        Steam = 0,
        Twitch = 1,
        Osu = 2,
        Discord = 3,
        Skype = 4,
        GitHub = 5,
        Keybase = 6,
        BattleNet = 7,
        ClubPenguin = 8,
        Spotify = 9,
        SoundCloud = 10,
        Reddit = 11,
        HentaiHaven = 12,
        Crunchyroll = 13,
        Kibii = 14,
        Uplay = 15,
        MyAnimeList = 16,
        WaifuHell = 17,
        Website = 18,
        Twitter = 19,
        LeagueOfLegends = 20,
        Youtube = 21,
        Picarto = 22,
        DeviantArt = 23,
        Pixiv = 24,
        Facebook = 25,
        Instagram = 26,
        XboxLive = 27, 
        GooglePlayGames = 28,
        Nintendo = 29,
        PSN = 30
    }
}
