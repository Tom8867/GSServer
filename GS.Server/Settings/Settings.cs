﻿/* Copyright(C) 2019  Rob Morgan (robert.morgan.e@gmail.com)

    This program is free software: you can redistribute it and/or modify
    it under the terms of the GNU General Public License as published
    by the Free Software Foundation, either version 3 of the License, or
    (at your option) any later version.

    This program is distributed in the hope that it will be useful,
    but WITHOUT ANY WARRANTY; without even the implied warranty of
    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
    GNU General Public License for more details.

    You should have received a copy of the GNU General Public License
    along with this program.  If not, see <https://www.gnu.org/licenses/>.
 */
using System.ComponentModel;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Threading;
using GS.Shared;

namespace GS.Server.Settings
{
    public static class Settings
    {
        #region Events

        public static event PropertyChangedEventHandler StaticPropertyChanged;

        #endregion

        #region Settings

        private static bool _charting;
        public static bool Charting
        {
            get => _charting;
            set
            {
                if (_charting == value) return;
                _charting = value;
                Properties.Server.Default.Charting = value;
                LogSetting(MethodBase.GetCurrentMethod().Name, $"{value}");
                OnStaticPropertyChanged();
            }
        }

        private static bool _focuser;
        public static bool Focuser
        {
            get => _focuser;
            set
            {
                if (_focuser == value) return;
                _focuser = value;
                Properties.Server.Default.Focuser = value;
                LogSetting(MethodBase.GetCurrentMethod().Name, $"{value}");
                OnStaticPropertyChanged();
            }
        }

        private static bool _gamepad;
        public static bool Gamepad
        {
            get => _gamepad;
            set
            {
                if (_gamepad == value) return;
                _gamepad = value;
                Properties.Server.Default.Gamepad = value;
                LogSetting(MethodBase.GetCurrentMethod().Name, $"{value}");
                OnStaticPropertyChanged();
            }
        }

        private static bool _notes;
        public static bool Notes
        {
            get => _notes;
            set
            {
                if (_notes == value) return;
                _notes = value;
                Properties.Server.Default.Notes = value;
                LogSetting(MethodBase.GetCurrentMethod().Name, $"{value}");
                OnStaticPropertyChanged();
            }
        }

        private static bool _skyWatcher;
        public static bool SkyWatcher
        {
            get => _skyWatcher;
            set
            {
                if (_skyWatcher == value) return;
                _skyWatcher = value;
                Properties.Server.Default.SkyWatcher = value;
                LogSetting(MethodBase.GetCurrentMethod().Name, $"{value}");
                OnStaticPropertyChanged();
            }
        }

        private static bool _model3d;
        public static bool Model3D
        {
            get => _model3d;
            set
            {
                if (_model3d == value) return;
                _model3d = value;
                Properties.Server.Default.Model3D = value;
                LogSetting(MethodBase.GetCurrentMethod().Name, $"{value}");
                OnStaticPropertyChanged();
            }
        }

        private static bool _sleepMode;
        public static bool SleepMode
        {
            get => _sleepMode;
            set
            {
                if (_sleepMode == value) return;
                _sleepMode = value;
                Properties.Server.Default.SleepMode = value;
                LogSetting(MethodBase.GetCurrentMethod().Name, $"{value}");
                OnStaticPropertyChanged();
            }
        }

        private static bool _startMinimized;
        public static bool StartMinimized
        {
            get => _startMinimized;
            set
            {
                if (_startMinimized == value) return;
                _startMinimized = value;
                Properties.Server.Default.StartMinimized = value;
                LogSetting(MethodBase.GetCurrentMethod().Name, $"{value}");
                OnStaticPropertyChanged();
            }
        }

        private static bool _startOnTop;
        public static bool StartOnTop
        {
            get => _startOnTop;
            set
            {
                if (_startOnTop == value) return;
                _startOnTop = value;
                Properties.Server.Default.StartOnTop = value;
                LogSetting(MethodBase.GetCurrentMethod().Name, $"{value}");
                OnStaticPropertyChanged();
            }
        }

        private static bool _voiceActive;
        public static bool VoiceActive
        {
            get => _voiceActive;
            set
            {
                if (_voiceActive == value) return;
                _voiceActive = value;
                Properties.Server.Default.VoiceActive = value;
                LogSetting(MethodBase.GetCurrentMethod().Name, $"{value}");
                OnStaticPropertyChanged();
            }
        }

        private static string _voiceName;
        public static string VoiceName
        {
            get => _voiceName;
            set
            {
                if (_voiceName == value) return;
                _voiceName = value;
                Properties.Server.Default.VoiceName = value;
                LogSetting(MethodBase.GetCurrentMethod().Name, $"{value}");
                OnStaticPropertyChanged();
            }
        }

        private static int _voiceVolume;
        public static int VoiceVolume
        {
            get => _voiceVolume;
            set
            {
                if (_voiceVolume == value) return;
                _voiceVolume = value;
                Properties.Server.Default.VoiceVolume = value;
                LogSetting(MethodBase.GetCurrentMethod().Name, $"{value}");
                OnStaticPropertyChanged();
            }
        }

        private static string _darkSkyKey;
        public static string DarkSkyKey
        {
            get => _darkSkyKey;
            set
            {
                if (_darkSkyKey == value) return;
                _darkSkyKey = value;
                Properties.Server.Default.DarkSkyKey = value;
                LogSetting(MethodBase.GetCurrentMethod().Name, $"{value}");
                OnStaticPropertyChanged();
            }
        }

        private static bool _darkTheme;
        public static bool DarkTheme
        {
            get => _darkTheme;
            set
            {
                if (_darkTheme == value) return;
                _darkTheme = value;
                Properties.Server.Default.DarkTheme = value;
                LogSetting(MethodBase.GetCurrentMethod().Name, $"{value}");
                OnStaticPropertyChanged();
            }
        }

        private static string _primaryColor;
        public static string PrimaryColor
        {
            get => _primaryColor;
            set
            {
                if (_primaryColor == value) return;
                _primaryColor = value;
                Properties.Server.Default.PrimaryColor = value;
                LogSetting(MethodBase.GetCurrentMethod().Name, $"{value}");
                OnStaticPropertyChanged();
            }
        }

        private static string _accentColor;
        public static string AccentColor
        {
            get => _accentColor;
            set
            {
                if (_accentColor == value) return;
                _accentColor = value;
                Properties.Server.Default.AccentColor = value;
                LogSetting(MethodBase.GetCurrentMethod().Name, $"{value}");
                OnStaticPropertyChanged();
            }
        }

        #endregion

        #region Methods      

        /// <summary>
        /// will upgrade if necessary
        /// </summary>
        public static void Load()
        {
            Upgrade();

            Charting = Properties.Server.Default.Charting;
            Focuser = Properties.Server.Default.Focuser;
            Gamepad = Properties.Server.Default.Gamepad;
            Notes = Properties.Server.Default.Notes;
            SkyWatcher = Properties.Server.Default.SkyWatcher;
            Model3D = Properties.Server.Default.Model3D;
            SleepMode = Properties.Server.Default.SleepMode;
            StartMinimized = Properties.Server.Default.StartMinimized;
            StartOnTop = Properties.Server.Default.StartOnTop;
            VoiceActive = Properties.Server.Default.VoiceActive;
            VoiceName = Properties.Server.Default.VoiceName;
            VoiceVolume = Properties.Server.Default.VoiceVolume;
            DarkSkyKey = Properties.Server.Default.DarkSkyKey;
            DarkTheme = Properties.Server.Default.DarkTheme;
            PrimaryColor = Properties.Server.Default.PrimaryColor;
            AccentColor = Properties.Server.Default.AccentColor;

        }

        /// <summary>
        /// upgrade and set new version
        /// </summary>
        public static void Upgrade()
        {
            var assembly = Assembly.GetExecutingAssembly().GetName().Version;
            var version = Properties.Server.Default.Version;

            if (version == assembly.ToString()) return;
            Properties.Server.Default.Upgrade();
            Properties.Server.Default.Version = assembly.ToString();
            Save();
        }

        /// <summary>
        /// save and reload
        /// </summary>
        public static void Save()
        {
            Properties.Server.Default.Save();
            Properties.Server.Default.Reload();
        }

        /// <summary>
        /// output to session log
        /// </summary>
        /// <param name="method"></param>
        /// <param name="value"></param>
        private static void LogSetting(string method, string value)
        {
            var monitorItem = new MonitorEntry
                { Datetime = Principles.HiResDateTime.UtcNow, Device = MonitorDevice.Server, Category = MonitorCategory.Server, Type = MonitorType.Information, Method = $"{method}", Thread = Thread.CurrentThread.ManagedThreadId, Message = $"{value}" };
            MonitorLog.LogToMonitor(monitorItem);
        }

        /// <summary>
        /// property event notification
        /// </summary>
        /// <param name="propertyName"></param>
        private static void OnStaticPropertyChanged([CallerMemberName] string propertyName = null)
        {
            StaticPropertyChanged?.Invoke(null, new PropertyChangedEventArgs(propertyName));
        }

        #endregion
    }
}
