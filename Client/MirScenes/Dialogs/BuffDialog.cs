using System;
using System.Collections.Generic;
using Client.MirControls;
using Client.MirGraphics;
using Client.MirSounds;
using System.Drawing;
using System.Windows.Forms;

namespace Client.MirScenes.Dialogs
{
    public class BuffDialog : MirImageControl
    {
        public List<ClientBuff> Buffs = new List<ClientBuff>();

        protected MirButton _expandCollapseButton;
        protected MirLabel _buffCountLabel;
        protected List<MirImageControl> _buffList = new List<MirImageControl>();
        protected bool _fadedOut, _fadedIn;
        protected int _buffCount;
        protected long _nextFadeTime;
        public Func<bool> GetExpandedParameter;
        public Action<bool> SetExpandedParameter;
        private bool ExpandedBuffWindow
        {
            get { return GetExpandedParameter(); }
            set { SetExpandedParameter(value); }
        }

    protected const long FadeDelay = 55;
        protected const float FadeRate = 0.2f;

        public BuffDialog()
        {
            Index = 20;
            Library = Libraries.Prguse2;
            Movable = false;
            Size = new Size(44, 34);
            Location = new Point(Settings.ScreenWidth - 170, 0);
            Sort = true;

            Opacity = 0f;
            _fadedOut = true;

            _expandCollapseButton = new MirButton
            {
                Index = 7,
                HoverIndex = 8,
                Size = new Size(16, 15),
                Library = Libraries.Prguse2,
                Parent = this,
                PressedIndex = 9,
                Sound = SoundList.ButtonA,
                Opacity = 0f
            };
            _expandCollapseButton.Click += (o, e) =>
            {
                if (_buffCount == 1)
                {
                    ExpandedBuffWindow = true;
                }
                else
                {
                    ExpandedBuffWindow = !ExpandedBuffWindow;
                }

                UpdateWindow();
            };

            _buffCountLabel = new MirLabel
            {
                Parent = this,
                AutoSize = true,
                DrawFormat = TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter,
                Font = new Font(Settings.FontName, 10F, FontStyle.Bold),
                NotControl = true,
                Sort = true,
                Visible = false,
                ForeColour = Color.Yellow,
                OutLineColour = Color.Black,
            };
        }

        public void CreateBuff(ClientBuff buff)
        {
            var buffImage = BuffImage(buff.Type);

            var buffLibrary = Libraries.BuffIcon;

            if (buffImage >= 20000)
            {
                buffImage -= 20000;
                buffLibrary = Libraries.MagIcon;
            }

            if (buffImage >= 10000)
            {
                buffImage -= 10000;
                buffLibrary = Libraries.Prguse2;
            }

            var image = new MirImageControl
            {
                Library = buffLibrary,
                Parent = this,
                Visible = true,
                Sort = false,
                Index = buffImage
            };

            _buffList.Insert(0, image);
            UpdateWindow();
        }

        public void RemoveBuff(int buffId)
        {
            _buffList[buffId].Dispose();
            _buffList.RemoveAt(buffId);

            UpdateWindow();
        }

        public void Process()
        {
            if (!Visible) return;

            if (_buffList.Count != _buffCount)
            {
                UpdateWindow();
            }

            for (var i = 0; i < _buffList.Count; i++)
            {
                var image = _buffList[i];
                var buff = Buffs[i];

                var buffImage = BuffImage(buff.Type);
                var buffLibrary = Libraries.BuffIcon;

                //ArcherSpells - VampireShot,PoisonShot
                if (buffImage >= 20000)
                {
                    buffImage -= 20000;
                    buffLibrary = Libraries.MagIcon;
                }

                if (buffImage >= 10000)
                {
                    buffImage -= 10000;
                    buffLibrary = Libraries.Prguse2;
                }

                var location = new Point(Size.Width - 10 - 23 - (i * 23) + ((10 * 23) * (i / 10)), 6 + ((i / 10) * 24));

                image.Location = new Point(location.X, location.Y);
                image.Hint = ExpandedBuffWindow ? BuffString(buff) : CombinedBuffText();
                image.Index = buffImage;
                image.Library = buffLibrary;

                if (ExpandedBuffWindow || !ExpandedBuffWindow && i == 0)
                {
                    image.Visible = true;
                    image.Opacity = 1f;
                }
                else
                {
                    image.Visible = false;
                    image.Opacity = 0.6f;
                }

                if (buff.Paused || buff.Infinite || !(Math.Round((buff.ExpireTime - CMain.Time) / 1000D) <= 5))
                    continue;

                var time = (buff.ExpireTime - CMain.Time) / 100D;

                if (Math.Round(time) % 10 < 5)
                    image.Index = -1;
            }

            if (IsMouseOver(CMain.MPoint))
            { 
                if (_buffCount == 0 || (!_fadedIn && CMain.Time <= _nextFadeTime))
                    return;

                Opacity += FadeRate;
                _expandCollapseButton.Opacity += FadeRate;

                if (Opacity > 1f)
                {
                    Opacity = 1f;
                    _expandCollapseButton.Opacity = 1f;
                    _fadedIn = true;
                    _fadedOut = false;
                }

                _nextFadeTime = CMain.Time + FadeDelay;
            }
            else
            {
                if (!_fadedOut && CMain.Time <= _nextFadeTime)
                    return;

                Opacity -= FadeRate;
                _expandCollapseButton.Opacity -= FadeRate;

                if (Opacity < 0f)
                {
                    Opacity = 0f;
                    _expandCollapseButton.Opacity = 0f;
                    _fadedOut = true;
                    _fadedIn = false;
                }
                    
                _nextFadeTime = CMain.Time + FadeDelay;
            }
        }

        private void UpdateWindow()
        {
            _buffCount = _buffList.Count;

            var baseImage = 20;
            var heightOffset = Location.Y;

            //foreach (var dialog in GameScene.Scene.BuffDialogs)
            //{
            //    if (dialog.Category == Category) break;

            //    if (dialog.Buffs.Count > 0)
            //    {
            //        heightOffset += dialog.Size.Height;
            //    }
            //}

            if (_buffCount > 0 && ExpandedBuffWindow)
            {
                var oldWidth = Size.Width;

                if (_buffCount <= 10)
                    Index = baseImage + _buffCount - 1;
                else if (_buffCount > 10)
                    Index = baseImage + 10;
                else if (_buffCount > 20)
                    Index = baseImage + 11;
                else if (_buffCount > 30)
                    Index = baseImage + 12;
                else if (_buffCount > 40)
                    Index = baseImage + 13;

                var newX = Location.X - Size.Width + oldWidth;
                var newY = heightOffset;
                Location = new Point(newX, newY);

                _buffCountLabel.Visible = false;

                _expandCollapseButton.Location = new Point(Size.Width - 15, 0);
                Size = new Size((_buffCount > 10 ? 10 : _buffCount) * 23, 24 + (_buffCount / 10) * 24);
            }
            else if (_buffCount > 0 && !ExpandedBuffWindow)
            {
                var oldWidth = Size.Width;

                Index = 20;
            
                var newX = Location.X - Size.Width + oldWidth;
                var newY = heightOffset;
                Location = new Point(newX, newY);

                _buffCountLabel.Visible = true;
                _buffCountLabel.Text = $"{_buffCount}";
                _buffCountLabel.Location = new Point(Size.Width / 2 - _buffCountLabel.Size.Width / 2, Size.Height / 2 - 10);
                _buffCountLabel.BringToFront();

                _expandCollapseButton.Location = new Point(Size.Width - 15, 0);
                Size = new Size(44, 34);
            }
        }

        public string BuffString(ClientBuff buff)
        {
            string text = RegexFunctions.SeperateCamelCase(buff.Type.ToString()) + "\n";
            bool overridestats = false;

            switch (buff.Type)
            {
                case BuffType.GameMaster:
                    GMOptions options = (GMOptions)buff.Values[0];
                    text = "游戏管理员\n";
                    if (options.HasFlag(GMOptions.GameMaster)) text += "-隐身\n";
                    if (options.HasFlag(GMOptions.Superman)) text += "-无敌\n";
                    if (options.HasFlag(GMOptions.Observer)) text += "-观察\n";
                    break;
                case BuffType.MentalState:
                    switch (buff.Values[0])
                    {
                        case 0:
                            text += "好战者(高伤害)\n攻击无法穿墙\n";
                            break;
                        case 1:
                            text += "花式射击(低伤害)\n攻击无法穿墙\n";
                            break;
                        case 2:
                            text += "队伍模式(中等伤害)\n攻击无法穿墙\n";
                            break;
                    }
                    break;
                case BuffType.Hiding:
                case BuffType.ClearRing:
                    text += "隐身术\n使大多数怪物看不到你\n";
                    break;
                case BuffType.MoonLight:
                    text += "月影术\n使一定范围外的其他玩家或大多数怪物无法看到你\n";
                    break;
                case BuffType.EnergyShield:
                    overridestats = true;
                    text += string.Format("无极盾\n受到攻击时有{0}%几率恢复{1}HP\n", buff.Stats[Stat.EnergyShieldPercent], buff.Stats[Stat.EnergyShieldHPGain]);
                    break;
                case BuffType.DarkBody:
                    text += "潜行\n遁入暗影中以避开怪物的视线\n";
                    break;
                case BuffType.VampireShot:
                    text += "生命汲取\n使你释放的某些技能附带吸血效果\n";
                    break;
                case BuffType.PoisonShot:
                    text += "毒蛇钉刺\n使你释放的某些技能附带中毒效果\n";
                    break;
                case BuffType.Concentration:
                    text += "专注\n增加元素获取几率\n";
                    break;
                case BuffType.MagicBooster:
                    overridestats = true;
                    text += string.Format("魔法协调\n魔法增加：{0}-{1}\n魔法消耗增加：{2}%.\n", buff.Stats[Stat.MinMC], buff.Stats[Stat.MaxMC], buff.Stats[Stat.ManaPenaltyPercent]);
                    break;
                case BuffType.Transform:
                    text += "变身\n卓越传奇，初心不改\n";
                    break;
                case BuffType.Mentee:
                    text += "灵巧\n技能点增长速度翻倍.\n";
                    break;
                case BuffType.Guild:
                    text += GameScene.Scene.GuildDialog.ActiveStats;
                    break;
                case BuffType.Blindness:
                    text += "致盲\n";
                    break;
            }

            if (!overridestats)
            {
                foreach (var val in buff.Stats.Values)
                {
                    var c = val.Value < 0 ? "降低" : "增加";
                    var key = val.Key.ToString();

                    var strKey = RegexFunctions.SeperateCamelCase(key.Replace("几率", "").Replace("倍", "").Replace("百分之", ""));

                    var sign = "";

                    if (key.Contains("百分之"))
                        sign = "%";
                    else if (key.Contains("倍"))
                        sign = "x";

                    var txt = $"{c} {strKey} 来自于: {val.Value}{sign}.\n";

                    text += txt;
                }
            }

            if (buff.Paused)
            {
                text += "倒计时暂停";
            }
            else if (buff.Infinite)
            {
                text += "永久";
            }
            else
            {
                text += string.Format("剩余时间：{0}", Functions.PrintTimeSpanFromSeconds(Math.Round((buff.ExpireTime - CMain.Time) / 1000D)));
            }

            if (!string.IsNullOrEmpty(buff.Caster)) text += string.Format("\n施法者：{0}", buff.Caster);

            return text;
        }

        private string CombinedBuffText()
        {
            string text = "激活 Buff\n";
            var stats = new Stats();

            for (var i = 0; i < _buffList.Count; i++)
            {
                var buff = Buffs[i];

                stats.Add(buff.Stats);
            }

            foreach (var val in stats.Values)
            {
                var c = val.Value < 0 ? "降低" : "增加";
                var key = val.Key.ToString();

                var strKey = RegexFunctions.SeperateCamelCase(key.Replace("几率", "").Replace("倍", "").Replace("百分之", ""));

                var sign = "";

                if (key.Contains("百分之"))
                    sign = "%";
                else if (key.Contains("倍"))
                    sign = "x";

                var txt = $"{c} {strKey}来自于: {val.Value}{sign}.\n";

                text += txt;
            }

            return text;
        }

        private int BuffImage(BuffType type)
        {
            switch (type)
            {
                //Skills
                case BuffType.Fury:
                    return 76;
                case BuffType.Rage:
                    return 49;
                case BuffType.ImmortalSkin:
                    return 80;
                case BuffType.CounterAttack:
                    return 7;

                case BuffType.MagicBooster:
                    return 73;
                case BuffType.MagicShield:
                    return 30;

                case BuffType.Hiding:
                case BuffType.ClearRing:
                    return 17;
                case BuffType.Haste:
                    return 60;
                case BuffType.SoulShield:
                    return 13;
                case BuffType.BlessedArmour:
                    return 14;
                case BuffType.ProtectionField:
                    return 50;
                case BuffType.UltimateEnhancer:
                    return 35;
                case BuffType.Curse:
                    return 45;
                case BuffType.EnergyShield:
                    return 57;

                case BuffType.SwiftFeet:
                    return 67;
                case BuffType.LightBody:
                    return 68;
                case BuffType.MoonLight:
                    return 65;
                case BuffType.DarkBody:
                    return 70;

                case BuffType.Concentration:
                    return 96;
                case BuffType.VampireShot:
                    return 100;
                case BuffType.PoisonShot:
                    return 102;
                case BuffType.MentalState:
                    return 199;

                //Monster
                case BuffType.RhinoPriestDebuff:
                    return 217;
                case BuffType.Blindness:
                    return 226;

                //Special
                case BuffType.GameMaster:
                    return 173;
                case BuffType.General:
                    return 182;
                case BuffType.Exp:
                    return 260;
                case BuffType.Drop:
                    return 162;
                case BuffType.Gold:
                    return 168;
                case BuffType.Knapsack:
                case BuffType.BagWeight:
                    return 235;
                case BuffType.Transform:
                    return 241;
                case BuffType.Mentor:
                case BuffType.Mentee:
                    return 248;
                case BuffType.Lover:
                    return 201;
                case BuffType.Guild:
                    return 203;
                case BuffType.Rested:
                    return 240;
                case BuffType.TemporalFlux:
                    return 261;
                case BuffType.Skill:
                    return 200;

                //Stats
                case BuffType.Impact:
                    return 249;
                case BuffType.Magic:
                    return 165;
                case BuffType.道士:
                    return 250;
                case BuffType.Storm:
                    return 170;
                case BuffType.HealthAid:
                    return 161;
                case BuffType.ManaAid:
                    return 169;
                case BuffType.Defence:
                    return 166;
                case BuffType.MagicDefence:
                    return 158;
                case BuffType.WonderDrug:
                    return 252;
                default:
                    return 0;
            }
        }
    }


    //UNFINISHED
    public class ClientPoisonBuff
    {
        public PoisonType Type;
        public string Caster;
        public int Value;
        public int TickSpeed;
        public long ExpireTime;
    }

    public sealed class PoisonBuffDialog : MirImageControl
    {
        public List<ClientPoisonBuff> Buffs = new List<ClientPoisonBuff>();

        protected MirButton _expandCollapseButton;
        protected MirLabel _buffCountLabel;
        protected List<MirImageControl> _buffList = new List<MirImageControl>();
        protected bool _fadedOut, _fadedIn;
        protected int _buffCount;
        protected long _nextFadeTime;

        protected const long FadeDelay = 55;
        protected const float FadeRate = 0.2f;

        public PoisonBuffDialog()
        {
            Index = 40;
            Library = Libraries.Prguse2;
            Movable = false;
            Size = new Size(44, 34);
            Location = new Point(Settings.ScreenWidth - 170, 0);
            Sort = true;

            Opacity = 0f;
            _fadedOut = true;

            _expandCollapseButton = new MirButton
            {
                Index = 7,
                HoverIndex = 8,
                Size = new Size(16, 15),
                Library = Libraries.Prguse2,
                Parent = this,
                PressedIndex = 9,
                Sound = SoundList.ButtonA,
                Opacity = 0f
            };
            _expandCollapseButton.Click += (o, e) =>
            {
                if (_buffCount == 1)
                {
                    Settings.ExpandedBuffWindow = true;
                }
                else
                {
                    Settings.ExpandedBuffWindow = !Settings.ExpandedBuffWindow;
                }

                UpdateWindow();
            };

            _buffCountLabel = new MirLabel
            {
                Parent = this,
                AutoSize = true,
                DrawFormat = TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter,
                Font = new Font(Settings.FontName, 10F, FontStyle.Bold),
                NotControl = true,
                Sort = true,
                Visible = false,
                ForeColour = Color.Yellow,
                OutLineColour = Color.Black,
            };
        }

        public void CreateBuff(ClientPoisonBuff buff)
        {
            var buffImage = BuffImage(buff.Type);

            var buffLibrary = Libraries.BuffIcon;

            if (buffImage >= 20000)
            {
                buffImage -= 20000;
                buffLibrary = Libraries.MagIcon;
            }

            if (buffImage >= 10000)
            {
                buffImage -= 10000;
                buffLibrary = Libraries.Prguse2;
            }

            var image = new MirImageControl
            {
                Library = buffLibrary,
                Parent = this,
                Visible = true,
                Sort = false,
                Index = buffImage
            };

            _buffList.Insert(0, image);
            UpdateWindow();
        }

        public string BuffString(ClientPoisonBuff buff)
        {
            string text = RegexFunctions.SeperateCamelCase(buff.Type.ToString()) + "\n";
            bool overridestats = false;

            switch (buff.Type)
            {
                case PoisonType.Green:
                    {
                        var tick = buff.TickSpeed / 1000;
                        var tickName = tick > 1 ? "秒" : "秒";

                        text += $"受到{buff.Value}伤害每{tick} {tickName}.\n";
                    }
                    break;
                case PoisonType.Red:
                    {
                        var tick = buff.TickSpeed / 1000;
                        var tickName = tick > 1 ? "秒" : "秒";

                        text += $"防御降低10%，持续{tick} {tickName}.\n";
                    }
                    break;
                case PoisonType.Slow:
                    text += "移动速度降低\n";
                    break;
                case PoisonType.Frozen:
                    text += "冰冻\n";
                    break;
                case PoisonType.Stun:
                    {
                        var tick = buff.TickSpeed / 1000;
                        var tickName = tick > 1 ? "秒" : "秒";

                        text += $"伤害增加20%，持续{tick} {tickName}.\n";
                    }
                    break;
                case PoisonType.Paralysis:
                    text += "麻痹\n";
                    break;
                case PoisonType.DelayedExplosion:
                    text += "爆炸\n";
                    break;
                case PoisonType.Bleeding:
                    {
                        var tick = buff.TickSpeed / 1000;
                        var tickName = tick > 1 ? "秒" : "秒";

                        text += $"受到{buff.Value}伤害每{tick} {tickName}.\n";
                    }
                    break;
                case PoisonType.LRParalysis:
                    text += "瘫痪\n";
                    break;
                case PoisonType.Blindness:
                    text += "致盲\n";
                    break;
                case PoisonType.Dazed:
                    text += "眩晕\n";
                    break;
            }

            text += string.Format("持续：{0}", Functions.PrintTimeSpanFromSeconds(Math.Round((buff.ExpireTime - CMain.Time) / 1000D)));

            if (!string.IsNullOrEmpty(buff.Caster)) text += string.Format("\n施法者: {0}", buff.Caster);

            return text;
        }

        private int BuffImage(PoisonType type)
        {
            switch (type)
            {
                case PoisonType.Green:
                    return 221;
                case PoisonType.Red:
                    return 222;
                case PoisonType.Slow:
                    return 225;
                case PoisonType.Frozen:
                    return 223;
                case PoisonType.Stun:
                    return 224;
                case PoisonType.Paralysis:
                    return 233;
                case PoisonType.DelayedExplosion:
                    return 229;
                case PoisonType.Bleeding:
                    return 231;
                case PoisonType.LRParalysis:
                    return 233;
                case PoisonType.Blindness:
                    return 226;
                case PoisonType.Dazed:
                    return 230;
                default:
                    return 0;
            }
        }

        public void Process()
        {
            if (!Visible) return;

            if (_buffList.Count != _buffCount)
            {
                UpdateWindow();
            }

            for (var i = 0; i < _buffList.Count; i++)
            {
                var image = _buffList[i];
                var buff = Buffs[i];

                var buffImage = BuffImage(buff.Type);
                var buffLibrary = Libraries.BuffIcon;

                //弓箭技能 - VampireShot,PoisonShot（生命汲取，毒蛇钉刺）
                if (buffImage >= 20000)
                {
                    buffImage -= 20000;
                    buffLibrary = Libraries.MagIcon;
                }

                if (buffImage >= 10000)
                {
                    buffImage -= 10000;
                    buffLibrary = Libraries.Prguse2;
                }

                var location = new Point(Size.Width - 10 - 23 - (i * 23) + ((10 * 23) * (i / 10)), 6 + ((i / 10) * 24));

                image.Location = new Point(location.X, location.Y);
                image.Hint = Settings.ExpandedBuffWindow ? BuffString(buff) : CombinedBuffText();
                image.Index = buffImage;
                image.Library = buffLibrary;

                if (Settings.ExpandedBuffWindow || !Settings.ExpandedBuffWindow && i == 0)
                {
                    image.Visible = true;
                    image.Opacity = 1f;
                }
                else
                {
                    image.Visible = false;
                    image.Opacity = 0.6f;
                }

                if (!(Math.Round((buff.ExpireTime - CMain.Time) / 1000D) <= 5))
                    continue;

                var time = (buff.ExpireTime - CMain.Time) / 100D;

                if (Math.Round(time) % 10 < 5)
                    image.Index = -1;
            }

            if (IsMouseOver(CMain.MPoint))
            {
                if (_buffCount == 0 || (!_fadedIn && CMain.Time <= _nextFadeTime))
                    return;

                Opacity += FadeRate;
                _expandCollapseButton.Opacity += FadeRate;

                if (Opacity > 1f)
                {
                    Opacity = 1f;
                    _expandCollapseButton.Opacity = 1f;
                    _fadedIn = true;
                    _fadedOut = false;
                }

                _nextFadeTime = CMain.Time + FadeDelay;
            }
            else
            {
                if (!_fadedOut && CMain.Time <= _nextFadeTime)
                    return;

                Opacity -= FadeRate;
                _expandCollapseButton.Opacity -= FadeRate;

                if (Opacity < 0f)
                {
                    Opacity = 0f;
                    _expandCollapseButton.Opacity = 0f;
                    _fadedOut = true;
                    _fadedIn = false;
                }

                _nextFadeTime = CMain.Time + FadeDelay;
            }
        }

        private void UpdateWindow()
        {
            _buffCount = _buffList.Count;

            var baseImage = 20;
            var heightOffset = 36;

            if (_buffCount > 0 && Settings.ExpandedBuffWindow)
            {
                var oldWidth = Size.Width;

                if (_buffCount <= 10)
                    Index = baseImage + _buffCount - 1;
                else if (_buffCount > 10)
                    Index = baseImage + 10;
                else if (_buffCount > 20)
                    Index = baseImage + 11;
                else if (_buffCount > 30)
                    Index = baseImage + 12;
                else if (_buffCount > 40)
                    Index = baseImage + 13;

                var newX = Location.X - Size.Width + oldWidth;
                var newY = heightOffset;
                Location = new Point(newX, newY);

                _buffCountLabel.Visible = false;

                _expandCollapseButton.Location = new Point(Size.Width - 15, 0);
                Size = new Size((_buffCount > 10 ? 10 : _buffCount) * 23, 24 + (_buffCount / 10) * 24);
            }
            else if (_buffCount > 0 && !Settings.ExpandedBuffWindow)
            {
                var oldWidth = Size.Width;

                Index = 20;

                var newX = Location.X - Size.Width + oldWidth;
                var newY = heightOffset;
                Location = new Point(newX, newY);

                _buffCountLabel.Visible = true;
                _buffCountLabel.Text = $"{_buffCount}";
                _buffCountLabel.Location = new Point(Size.Width / 2 - _buffCountLabel.Size.Width / 2, Size.Height / 2 - 10);
                _buffCountLabel.BringToFront();

                _expandCollapseButton.Location = new Point(Size.Width - 15, 0);
                Size = new Size(44, 34);
            }
        }

        private string CombinedBuffText()
        {
            string text = "激活毒药\n";

            return text;
        }
    }

}

