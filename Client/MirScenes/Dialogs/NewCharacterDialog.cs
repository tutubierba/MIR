﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using Client.MirControls;
using Client.MirGraphics;
using Client.MirNetwork;
using Client.MirObjects;
using Client.MirSounds;
using Font = System.Drawing.Font;
using C = ClientPackets;
using Effect = Client.MirObjects.Effect;
namespace Client.MirScenes.Dialogs
{
    public sealed class NewCharacterDialog : MirImageControl
    {
        private static readonly Regex Reg = new Regex(@"^([a-z]|[A-Z]|[\u4e00-\u9fa5])([a-z]|[A-Z]|[0-9]|[\u4e00-\u9fa5])+$");

        public MirImageControl TitleLabel;
        public MirAnimatedControl CharacterDisplay;

        public MirButton OKButton,
                         CancelButton,
                         WarriorButton,
                         WizardButton,
                         TaoistButton,
                         AssassinButton,
                         ArcherButton,
                         MaleButton,
                         FemaleButton;

        public MirTextBox NameTextBox;

        public MirLabel Description;

        public MirClass Class;
        public MirGender Gender;

        #region Descriptions
        public const string WarriorDescription =
            "战士 是一个充满力量和活力的阶层。它们不容易在战斗中被杀死，并且具有能够使用的优势" +
            " 各种重型武器和盔甲。因此，战士喜欢基于近战物理伤害的攻击。他们的能力很弱" +
            " 然而，攻击是专门为战士开发的各种设备，补充了他们在远程作战中的弱点.";

        public const string WizardDescription =
            "法师 是一个体力和耐力都很低的职业，但他们有使用强大法术的能力。他们的攻击法术非常有效，但是" +
            " 法术需要时间，它们很可能会让自己处于敌人攻击的开放状态。因此，身体虚弱的巫师" +
            " 必须瞄准从安全距离攻击敌人.";

        public const string TaoistDescription =
            "道师 在天文学、医学和其他方面都有很好的建树，除了普攻。而不是直接攻击敌人" +
            " 他们的 特长在于为盟友提供支持。道家可以召唤强大的生物，对魔法有很高的抵抗力，是一个职业" +
            " 具有良好的进攻和防守能力.";

        public const string AssassinDescription =
            "刺客 是一个秘密组织的成员，他们的历史相对未知。他们能够隐藏自己，进行攻击" +
            " 在别人看不见的情况下，这自然使他们擅长快速杀戮。他们有必要避免与" +
            " 敌人交战 由于生命力和力量较弱，有多个敌人.";

        public const string ArcherDescription =
            "弓箭手 是一个非常精确和强大的职业，他们使用强大的弓箭技能在射程中造成非凡的伤害。很像" +
            " 巫师，他们依靠敏锐的直觉来躲避迎面而来的攻击，因为他们倾向于让自己面对正面攻击。然而，他们的" +
            " 身体的力量和致命的目标使他们能够向任何被他们击中的人灌输恐惧.";

        #endregion

        public NewCharacterDialog()
        {
            Index = 73;
            Library = Libraries.Prguse;
            Location = new Point((Settings.ScreenWidth - Size.Width) / 2, (Settings.ScreenHeight - Size.Height) / 2);
            Modal = true;

            TitleLabel = new MirImageControl
            {
                Index = 20,
                Library = Libraries.Title,
                Location = new Point(206, 11),
                Parent = this,
            };

            CancelButton = new MirButton
            {
                HoverIndex = 281,
                Index = 280,
                Library = Libraries.Title,
                Location = new Point(425, 425),
                Parent = this,
                PressedIndex = 282
            };
            CancelButton.Click += (o, e) => Hide();

            OKButton = new MirButton
            {
                Enabled = false,
                HoverIndex = 361,
                Index = 360,
                Library = Libraries.Title,
                Location = new Point(160, 425),
                Parent = this,
                PressedIndex = 362,
            };
            OKButton.Click += (o, e) => CreateCharacter();

            NameTextBox = new MirTextBox
            {
                Location = new Point(325, 268),
                Parent = this,
                Size = new Size(240, 20),
                MaxLength = Globals.MaxCharacterNameLength
            };
            NameTextBox.TextBox.KeyPress += TextBox_KeyPress;
            NameTextBox.TextBox.TextChanged += CharacterNameTextBox_TextChanged;
            NameTextBox.SetFocus();

            CharacterDisplay = new MirAnimatedControl
            {
                Animated = true,
                AnimationCount = 16,
                AnimationDelay = 250,
                Index = 20,
                Library = Libraries.ChrSel,
                Location = new Point(120, 250),
                Parent = this,
                UseOffSet = true,
            };
            CharacterDisplay.AfterDraw += (o, e) =>
            {
                if (Class == MirClass.法师)
                    Libraries.ChrSel.DrawBlend(CharacterDisplay.Index + 560, CharacterDisplay.DisplayLocationWithoutOffSet, Color.White, true);
            };


            WarriorButton = new MirButton
            {
                HoverIndex = 2427,
                Index = 2427,
                Library = Libraries.Prguse,
                Location = new Point(323, 296),
                Parent = this,
                PressedIndex = 2428,
                Sound = SoundList.ButtonA,
            };
            WarriorButton.Click += (o, e) =>
            {
                Class = MirClass.战士;
                UpdateInterface();
            };


            WizardButton = new MirButton
            {
                HoverIndex = 2430,
                Index = 2429,
                Library = Libraries.Prguse,
                Location = new Point(373, 296),
                Parent = this,
                PressedIndex = 2431,
                Sound = SoundList.ButtonA,
            };
            WizardButton.Click += (o, e) =>
            {
                Class = MirClass.法师;
                UpdateInterface();
            };


            TaoistButton = new MirButton
            {
                HoverIndex = 2433,
                Index = 2432,
                Library = Libraries.Prguse,
                Location = new Point(423, 296),
                Parent = this,
                PressedIndex = 2434,
                Sound = SoundList.ButtonA,
            };
            TaoistButton.Click += (o, e) =>
            {
                Class = MirClass.道士;
                UpdateInterface();
            };

            AssassinButton = new MirButton
            {
                HoverIndex = 2436,
                Index = 2435,
                Library = Libraries.Prguse,
                Location = new Point(473, 296),
                Parent = this,
                PressedIndex = 2437,
                Sound = SoundList.ButtonA,
            };
            AssassinButton.Click += (o, e) =>
            {
                Class = MirClass.刺客;
                UpdateInterface();
            };

            ArcherButton = new MirButton
            {
                HoverIndex = 2439,
                Index = 2438,
                Library = Libraries.Prguse,
                Location = new Point(523, 296),
                Parent = this,
                PressedIndex = 2440,
                Sound = SoundList.ButtonA,
            };
            ArcherButton.Click += (o, e) =>
            {
                Class = MirClass.弓箭手;
                UpdateInterface();
            };


            MaleButton = new MirButton
            {
                HoverIndex = 2421,
                Index = 2421,
                Library = Libraries.Prguse,
                Location = new Point(323, 343),
                Parent = this,
                PressedIndex = 2422,
                Sound = SoundList.ButtonA,
            };
            MaleButton.Click += (o, e) =>
            {
                Gender = MirGender.男;
                UpdateInterface();
            };

            FemaleButton = new MirButton
            {
                HoverIndex = 2424,
                Index = 2423,
                Library = Libraries.Prguse,
                Location = new Point(373, 343),
                Parent = this,
                PressedIndex = 2425,
                Sound = SoundList.ButtonA,
            };
            FemaleButton.Click += (o, e) =>
            {
                Gender = MirGender.女;
                UpdateInterface();
            };

            Description = new MirLabel
            {
                Border = true,
                Location = new Point(279, 70),
                Parent = this,
                Size = new Size(278, 170),
                Text = WarriorDescription,
            };
        }

        public override void Show()
        {
            base.Show();

            Class = MirClass.战士;
            Gender = MirGender.男;
            NameTextBox.Text = string.Empty;

            UpdateInterface();
        }

        private void TextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (sender == null) return;
            if (e.KeyChar != (char)Keys.Enter) return;
            e.Handled = true;

            if (OKButton.Enabled)
                OKButton.InvokeMouseClick(null);
        }
        private void CharacterNameTextBox_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(NameTextBox.Text))
            {
                OKButton.Enabled = false;
                NameTextBox.Border = false;
            }
            else if (!Reg.IsMatch(NameTextBox.Text))
            {
                OKButton.Enabled = false;
                NameTextBox.Border = true;
                NameTextBox.BorderColour = Color.Red;
            }
            else
            {
                OKButton.Enabled = true;
                NameTextBox.Border = true;
                NameTextBox.BorderColour = Color.Green;
            }
        }

        public event EventHandler OnCreateCharacter;
        private void CreateCharacter()
        {
            OKButton.Enabled = false;

            if (OnCreateCharacter != null)
                OnCreateCharacter.Invoke(this, EventArgs.Empty);            
        }

        private void UpdateInterface()
        {
            MaleButton.Index = 2420;
            FemaleButton.Index = 2423;

            WarriorButton.Index = 2426;
            WizardButton.Index = 2429;
            TaoistButton.Index = 2432;
            AssassinButton.Index = 2435;
            ArcherButton.Index = 2438;

            switch (Gender)
            {
                case MirGender.男:
                    MaleButton.Index = 2421;
                    break;
                case MirGender.女:
                    FemaleButton.Index = 2424;
                    break;
            }

            switch (Class)
            {
                case MirClass.战士:
                    WarriorButton.Index = 2427;
                    Description.Text = WarriorDescription;
                    CharacterDisplay.Index = (byte)Gender == 0 ? 20 : 300; //220 : 500;
                    break;
                case MirClass.法师:
                    WizardButton.Index = 2430;
                    Description.Text = WizardDescription;
                    CharacterDisplay.Index = (byte)Gender == 0 ? 40 : 320; //240 : 520;
                    break;
                case MirClass.道士:
                    TaoistButton.Index = 2433;
                    Description.Text = TaoistDescription;
                    CharacterDisplay.Index = (byte)Gender == 0 ? 60 : 340; //260 : 540;
                    break;
                case MirClass.刺客:
                    AssassinButton.Index = 2436;
                    Description.Text = AssassinDescription;
                    CharacterDisplay.Index = (byte)Gender == 0 ? 80 : 360; //280 : 560;
                    break;
                case MirClass.弓箭手:
                    ArcherButton.Index = 2439;
                    Description.Text = ArcherDescription;
                    CharacterDisplay.Index = (byte)Gender == 0 ? 100 : 140; //160 : 180;
                    break;
            }

            //CharacterDisplay.Index = ((byte)_class + 1) * 20 + (byte)_gender * 280;
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);

            OnCreateCharacter = null;
        }
    }
}
