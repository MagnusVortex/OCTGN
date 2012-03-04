﻿using System;
using System.Collections.Generic;
using Skylabs.Net;

namespace Skylabs.Lobby
{
    [Serializable]
    public class HostedGameData : IEquatable<HostedGameData>, IEqualityComparer<HostedGameData>
    {
        #region EHostedGame enum

        [Serializable]
        public enum EHostedGame
        {
            StartedHosting,
            GameInProgress,
            StoppedHosting
        };

        #endregion

        public HostedGameData(Guid gameguid, Version gameversion, int port, string name, bool passreq, User huser,
                          DateTime startTime)
        {
            GameGuid = gameguid;
            GameVersion = gameversion;
            Port = port;
            Name = name;
            PasswordRequired = passreq;
            UserHosting = huser;
            GameStatus = EHostedGame.StartedHosting;
            TimeStarted = startTime;
        }

        public HostedGameData(SocketMessage sm)
        {
            GameGuid = (Guid) sm["guid"];
            GameVersion = (Version) sm["version"];
            Port = (int) sm["port"];
            Name = (string) sm["name"];
            PasswordRequired = (bool) sm["passrequired"];
            UserHosting = (User) sm["hoster"];
            GameStatus = EHostedGame.StartedHosting;
            TimeStarted = new DateTime(DateTime.Now.ToUniversalTime().Ticks);
        }

        public Guid GameGuid { get; private set; }
        public Version GameVersion { get; private set; }
        public int Port { get; private set; }
        public String Name { get; private set; }
        public bool PasswordRequired { get; private set; }
        public User UserHosting { get; private set; }
        public EHostedGame GameStatus { get; set; }
        public DateTime TimeStarted { get; private set; }

        #region IEqualityComparer<HostedGame> Members

        public bool Equals(HostedGameData x, HostedGameData y)
        {
            return x.Port == y.Port;
        }

        public int GetHashCode(HostedGameData obj)
        {
            return obj.Port;
        }

        #endregion

        #region IEquatable<HostedGame> Members

        public bool Equals(HostedGameData other)
        {
            return other.Port == Port;
        }

        #endregion
    }
}