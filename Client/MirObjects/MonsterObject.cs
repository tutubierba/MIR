using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using Client.MirGraphics;
using Client.MirScenes;
using Client.MirSounds;
using S = ServerPackets;
using Client.MirControls;

namespace Client.MirObjects
{
    class MonsterObject : MapObject
    {
        public override ObjectType Race
        {
            get { return ObjectType.Monster; }
        }

        public override bool Blocking
        {
            get { return AI == 64 || (AI == 81 && Direction == (MirDirection)6) ? false : !Dead; }
        }

        public Point ManualLocationOffset
        {
            get
            {
                switch (BaseImage)
                {
                    case Monster.EvilMir:
                        return new Point(-21, -15);
                    case Monster.PalaceWall2:
                    case Monster.PalaceWallLeft:
                    case Monster.PalaceWall1:
                    case Monster.GiGateSouth:
                    case Monster.GiGateWest:
                    case Monster.SSabukWall1:
                    case Monster.SSabukWall2:
                    case Monster.SSabukWall3:
                        return new Point(-10, 0);
                    case Monster.GiGateEast:
                        return new Point(-45, 7);
                    default:
                        return new Point(0, 0);
                }
            }
        }

        public Monster BaseImage;
        public byte Effect;
        public bool Skeleton;

        public FrameSet Frames = new FrameSet();
        public Frame Frame;
        public int FrameIndex, FrameInterval, EffectFrameIndex, EffectFrameInterval;

        public uint TargetID;
        public Point TargetPoint;

        public bool Stoned;
        public byte Stage;
        public int BaseSound;

        public long ShockTime;
        public bool BindingShotCenter;

        public Color OldNameColor;

        public SpellEffect CurrentEffect;

        public MonsterObject(uint objectID) : base(objectID) { }

        public void Load(S.ObjectMonster info, bool update = false)
        {
            Name = info.Name;
            NameColour = info.NameColour;
            BaseImage = info.Image;

            OldNameColor = NameColour;

            CurrentLocation = info.Location;
            MapLocation = info.Location;
            if (!update) GameScene.Scene.MapControl.AddObject(this);

            Effect = info.Effect;
            AI = info.AI;
            Light = info.Light;

            Direction = info.Direction;
            Dead = info.Dead;
            Poison = info.Poison;
            Skeleton = info.Skeleton;
            Hidden = info.Hidden;
            ShockTime = CMain.Time + info.ShockTime;
            BindingShotCenter = info.BindingShotCenter;

            Buffs = info.Buffs;

            if (Stage != info.ExtraByte)
            {
                switch (BaseImage)
                {
                    case Monster.GreatFoxSpirit:
                        if (update)
                        {
                            Effects.Add(new Effect(Libraries.Monsters[(ushort)Monster.GreatFoxSpirit], 335, 20, 3000, this));
                            SoundManager.PlaySound(BaseSound + 8);
                        }
                        break;
                    case Monster.HellLord:
                        {
                            Effects.Clear();

                            var effects = MapControl.Effects.Where(x => x.Library == Libraries.Monsters[(ushort)Monster.HellLord]);

                            foreach (var effect in effects)
                                effect.Repeat = false;

                            if (info.ExtraByte > 3)
                                Effects.Add(new Effect(Libraries.Monsters[(ushort)Monster.HellLord], 21, 6, 600, this) { Repeat = true });
                            else
                            {
                                if (info.ExtraByte > 2)
                                    MapControl.Effects.Add(new Effect(Libraries.Monsters[(ushort)Monster.HellLord], 105, 6, 600, new Point(100, 84)) { Repeat = true });
                                if (info.ExtraByte > 1)
                                    MapControl.Effects.Add(new Effect(Libraries.Monsters[(ushort)Monster.HellLord], 111, 6, 600, new Point(96, 81)) { Repeat = true });
                                if (info.ExtraByte > 0)
                                    MapControl.Effects.Add(new Effect(Libraries.Monsters[(ushort)Monster.HellLord], 123, 6, 600, new Point(93, 84)) { Repeat = true });
                            }

                            SoundManager.PlaySound(BaseSound + 9);
                        }
                        break;
                }
            }

            Stage = info.ExtraByte;

            //Library
            switch (BaseImage)
            {
                case Monster.EvilMir:
                case Monster.DragonStatue:
                    BodyLibrary = Libraries.Dragon;
                    break;
                case Monster.EvilMirBody:
                    break;
                case Monster.Catapult:
                case Monster.ChariotBallista:
                case Monster.Ballista:
                case Monster.Trebuchet:
                case Monster.CanonTrebuchet:
                    BodyLibrary = Libraries.Siege[((ushort)BaseImage) - 940];
                    break;
                case Monster.SabukGate:
                case Monster.PalaceWallLeft:
                case Monster.PalaceWall1:
                case Monster.PalaceWall2:
                case Monster.GiGateSouth:
                case Monster.GiGateEast:
                case Monster.GiGateWest:
                case Monster.SSabukWall1:
                case Monster.SSabukWall2:
                case Monster.SSabukWall3:
                case Monster.NammandGate1:
                case Monster.NammandGate2:
                case Monster.SabukWallSection:
                case Monster.NammandWallSection:
                case Monster.FrozenDoor:
                    BodyLibrary = Libraries.Gates[((ushort)BaseImage) - 950];
                    break;
                case Monster.BabyPig:
                case Monster.Chick:
                case Monster.Kitten:
                case Monster.BabySkeleton:
                case Monster.Baekdon:
                case Monster.Wimaen:
                case Monster.BlackKitten:
                case Monster.BabyDragon:
                case Monster.OlympicFlame:
                case Monster.BabySnowMan:
                case Monster.Frog:
                case Monster.BabyMonkey:
                case Monster.AngryBird:
                case Monster.Foxey:
                case Monster.MedicalRat:
                    BodyLibrary = Libraries.Pets[((ushort)BaseImage) - 10000];
                    break;
                case Monster.HellBomb1:
                case Monster.HellBomb2:
                case Monster.HellBomb3:
                    BodyLibrary = Libraries.Monsters[(ushort)Monster.HellLord];
                    break;
                case Monster.CaveStatue:
                    BodyLibrary = Libraries.Monsters[(ushort)Monster.CaveStatue];
                    break;
                default:
                    BodyLibrary = Libraries.Monsters[(ushort)BaseImage];
                    break;
            }

            if (Skeleton)
                ActionFeed.Add(new QueuedAction { Action = MirAction.Skeleton, Direction = Direction, Location = CurrentLocation });
            else if (Dead)
                ActionFeed.Add(new QueuedAction { Action = MirAction.Dead, Direction = Direction, Location = CurrentLocation });

            BaseSound = (ushort)BaseImage * 10;

            //Special Actions
            switch (BaseImage)
            {
                case Monster.BoneFamiliar:
                case Monster.Shinsu:
                case Monster.HolyDeva:
                case Monster.HellKnight1:
                case Monster.HellKnight2:
                case Monster.HellKnight3:
                case Monster.HellKnight4:
                case Monster.LightningBead:
                case Monster.HealingBead:
                case Monster.PowerUpBead:
                    if (!info.Extra) ActionFeed.Add(new QueuedAction { Action = MirAction.Appear, Direction = Direction, Location = CurrentLocation });
                    break;
                case Monster.FrostTiger:
                case Monster.FlameTiger:
                    SitDown = info.Extra;
                    break;
                case Monster.ZumaStatue:
                case Monster.ZumaGuardian:
                case Monster.FrozenZumaStatue:
                case Monster.FrozenZumaGuardian:
                case Monster.ZumaTaurus:
                case Monster.DemonGuard:
                case Monster.Turtlegrass:
                case Monster.ManTree:
                case Monster.EarthGolem:
                case Monster.AssassinScroll:
                case Monster.WarriorScroll:
                case Monster.TaoistScroll:
                case Monster.WizardScroll:
                case Monster.PurpleFaeFlower:
                    Stoned = info.Extra;
                    break;
            }

            //Frames
            switch (BaseImage)
            {
                case Monster.GreatFoxSpirit:
                    Frames = FrameSet.GreatFoxSpirit[Stage];
                    break;
                case Monster.DragonStatue:
                    Frames = FrameSet.DragonStatue[(byte)Direction];
                    break;
                case Monster.HellBomb1:
                case Monster.HellBomb2:
                case Monster.HellBomb3:
                    Frames = FrameSet.HellBomb[((ushort)BaseImage) - 903];
                    break;
                case Monster.CaveStatue:
                    Frames = FrameSet.CaveStatue[(byte)Direction];
                    break;
                case Monster.RedFaeFlower:
                    Frames = FrameSet.RedFaeFlower;
                    break; 
                case Monster.Sqmoth:
                    Frames = FrameSet.Sqmoth;
                    break;
                case Monster.SqAlizard:
                    Frames = FrameSet.SqAlizard;
                    break;
                case Monster.Sqmouse:
                    Frames = FrameSet.Sqmouse;
                    break;
                case Monster.Manticore:
                    Frames = FrameSet.Manticore;
                    break;
                case Monster.SqTombMonster:
                    Frames = FrameSet.SqTombMonster;
                    break;
                case Monster.SqBalrog:
                    Frames = FrameSet.SqBalrog;
                    break;
                case Monster.SqWoodenbox:
                    Frames = FrameSet.SqWoodenbox;
                    break;
                case Monster.Sq0rgan:
                    Frames = FrameSet.Sq0rgan;
                    break;
                case Monster.SqTerraWarrior:
                    Frames = FrameSet.SqTerraWarrior;
                    break;
                case Monster.SqTerraArcher:
                    Frames = FrameSet.SqTerraArcher;
                    break;
                case Monster.SqWarrior:
                    Frames = FrameSet.SqWarrior;
                    break;
                case Monster.SqAssassin:
                    Frames = FrameSet.SqAssassin;
                    break;
                case Monster.SqSkeletonsoldier:
                    Frames = FrameSet.SqSkeletonsoldier;
                    break; 
                case Monster.SqChampion:
                    Frames = FrameSet.SqChampion;
                    break;
                case Monster.SqWarlock:
                    Frames = FrameSet.SqWarlock;
                    break;
                case Monster.SqSacrifice:
                    Frames = FrameSet.SqSacrifice;
                    break;
                case Monster.SqWarriorSoul:
                    Frames = FrameSet.SqWarriorSoul;
                    break;
                case Monster.SqArcherSoul:
                    Frames = FrameSet.SqArcherSoul;
                    break;
                case Monster.SqTaoistSoul:
                    Frames = FrameSet.SqTaoistSoul;
                    break;
                case Monster.SqAssassinSoul:
                    Frames = FrameSet.SqAssassinSoul;
                    break;
                case Monster.SqWizardSoul:
                    Frames = FrameSet.SqWizardSoul;
                    break;
                case Monster.SqGuru0verLord:
                    Frames = FrameSet.SqGuru0verLord;
                    break;
                case Monster.SqGuruBloodWizard:
                    Frames = FrameSet.SqGuruBloodWizard;
                    break;
                case Monster.SqBuddhaSoul:
                    Frames = FrameSet.SqBuddhaSoul;
                    break;
                case Monster.GlacierWarrior:
                    Frames = FrameSet.GlacierWarrior;
                    break;
                case Monster.ManEatingPlant:
                    Frames = FrameSet.ManEatingPlant;
                    break;
                case Monster.LivingVines:
                    Frames = FrameSet.LivingVines;
                    break;
                case Monster.FeatheredWolf:
                    Frames = FrameSet.FeatheredWolf;
                    break;
                case Monster.WarBear:
                    Frames = FrameSet.WarBear;
                    break;
                case Monster.MysteriousMonk:
                    Frames = FrameSet.MysteriousMonk;
                    break; 
                case Monster.MysteriousMage:
                    Frames = FrameSet.MysteriousMage;
                    break;
                case Monster.BlueMonk:
                    Frames = FrameSet.BlueMonk;
                    break;
                case Monster.MysteriousAssassin:
                    Frames = FrameSet.MysteriousAssassin;
                    break;
                case Monster.ReaperAssassin:
                    Frames = FrameSet.ReaperAssassin;
                    break;
                case Monster.ReaperWizard:
                    Frames = FrameSet.ReaperWizard;
                    break;
                case Monster.ReaperPriest:
                    Frames = FrameSet.ReaperPriest;
                    break;
                case Monster.MutantHighPriest:
                    Frames = FrameSet.MutantHighPriest;
                    break;
                case Monster.MutantBeserker:
                    Frames = FrameSet.MutantBeserker;
                    break;
                case Monster.MutantGuardian:
                    Frames = FrameSet.MutantGuardian;
                    break;
                case Monster.HammerDwarf:
                    Frames = FrameSet.HammerDwarf;
                    break;
                case Monster.ArcherDwarf:
                    Frames = FrameSet.ArcherDwarf;
                    break;
                case Monster.NobleWarrior:
                    Frames = FrameSet.NobleWarrior;
                    break;
                case Monster.NobleArcher:
                    Frames = FrameSet.NobleArcher;
                    break;
                case Monster.NoblePriest:
                    Frames = FrameSet.NoblePriest;
                    break;
                case Monster.NobleAssassin:
                    Frames = FrameSet.NobleAssassin;
                    break;
                case Monster.Swain:
                    Frames = FrameSet.Swain;
                    break;
                case Monster.RedMutantPlant:
                    Frames = FrameSet.RedMutantPlant;
                    break;
                case Monster.BlueMutantPlant:
                    Frames = FrameSet.BlueMutantPlant;
                    break;
                case Monster.UndeadHammerDwarf:
                    Frames = FrameSet.UndeadHammerDwarf;
                    break;
                case Monster.UndeadDwarfArcher:
                    Frames = FrameSet.UndeadDwarfArcher;
                    break;
                case Monster.AncientStoneGolem:
                    Frames = FrameSet.AncientStoneGolem;
                    break;
                case Monster.Serpentirian:
                    Frames = FrameSet.Serpentirian;
                    break;
                case Monster.Butcher:
                    Frames = FrameSet.Butcher;
                    break;
                case Monster.Riklebites:
                    Frames = FrameSet.Riklebites;
                    break;
                case Monster.Windblade:
                    Frames = FrameSet.Windblade;
                    break;
                case Monster.FrozenGolem:
                    Frames = FrameSet.FrozenGolem;
                    break;
                case Monster.BestKing:
                    Frames = FrameSet.BestKing;
                    break;
                case Monster.ShardGuardian:
                    Frames = FrameSet.ShardGuardian;
                    break;
                case Monster.HoodedSummoner:
                    Frames = FrameSet.HoodedSummoner;
                    break;
                case Monster.HoodedIceMage:
                    Frames = FrameSet.HoodedIceMage;
                    break;
                case Monster.HoodedPriest:
                    Frames = FrameSet.HoodedPriest;
                    break;
                case Monster.ShardMaiden:
                    Frames = FrameSet.ShardMaiden;
                    break;
                case Monster.Furball:
                    Frames = FrameSet.Furball;
                    break;
                case Monster.PeacockSpider:
                    Frames = FrameSet.PeacockSpider;
                    break;
                case Monster.YangDevilNode:
                    Frames = FrameSet.YangDevilNode;
                    break;
                case Monster.YinDevilNode:
                    Frames = FrameSet.YinDevilNode;
                    break;
                case Monster.DarkCaptain:
                    Frames = FrameSet.DarkCaptain;
                    break;
                case Monster.BlueSoul:
                    Frames = FrameSet.BlueSoul;
                    break;
                case Monster.WoodBox:
                    Frames = FrameSet.WoodBox;
                    break;
                case Monster.ClawBeast:
                    Frames = FrameSet.ClawBeast;
                    break;
                case Monster.AxePlant:
                    Frames = FrameSet.AxePlant;
                    break;
                case Monster.AvengingWarrior:
                    Frames = FrameSet.AvengingWarrior;
                    break;
                case Monster.AvengingSpirit:
                    Frames = FrameSet.AvengingSpirit;
                    break;
                case Monster.Nadz:
                    Frames = FrameSet.Nadz;
                    break;
                case Monster.AvengerPlant:
                    Frames = FrameSet.AvengerPlant;
                    break;
                case Monster.ArmedPlant:
                    Frames = FrameSet.ArmedPlant;
                    break;
                case Monster.FloatingWraith:
                    Frames = FrameSet.FloatingWraith;
                    break;
                case Monster.CreeperPlant:
                    Frames = FrameSet.CreeperPlant;
                    break;
                case Monster.PlagueCrab:
                    Frames = FrameSet.PlagueCrab;
                    break;
                case Monster.Mandrill:
                    Frames = FrameSet.Mandrill;
                    break;
                case Monster.HornedCommander:
                    Frames = FrameSet.HornedCommander;
                    break;
                case Monster.HornedSorceror:
                    Frames = FrameSet.HornedSorceror;
                    break;
                case Monster.BoulderSpirit:
                    Frames = FrameSet.BoulderSpirit;
                    break;
                case Monster.ScalyBeast:
                    Frames = FrameSet.ScalyBeast;
                    break;
                case Monster.FloatingRock:
                    Frames = FrameSet.FloatingRock;
                    break;
                case Monster.HornedWarrior:
                    Frames = FrameSet.HornedWarrior;
                    break;
                case Monster.ColdArcher:
                    Frames = FrameSet.ColdArcher;
                    break;
                case Monster.HornedArcher:
                    Frames = FrameSet.HornedArcher;
                    break;
                case Monster.HornedMage:
                    Frames = FrameSet.HornedMage;
                    break;
                case Monster.KingHydrax:
                    Frames = FrameSet.KingHydrax;
                    break;
                case Monster.Hydrax:
                    Frames = FrameSet.Hydrax;
                    break;
                case Monster.SackWarrior:
                    Frames = FrameSet.SackWarrior;
                    break;
                case Monster.WereTiger:
                    Frames = FrameSet.WereTiger;
                    break;
                case Monster.GlacierBeast:
                    Frames = FrameSet.GlacierBeast;
                    break;
                case Monster.FurbolgCommander:
                    Frames = FrameSet.FurbolgCommander;
                    break;
                case Monster.FurbolgGuard:
                    Frames = FrameSet.FurbolgGuard;
                    break;
                case Monster.FurbolgArcher:
                    Frames = FrameSet.FurbolgArcher;
                    break;
                case Monster.FurbolgWarrior:
                    Frames = FrameSet.FurbolgWarrior;
                    break;
                case Monster.GlacierSnail:
                    Frames = FrameSet.GlacierSnail;
                    break;
                case Monster.PurpleFaeFlower:
                    Frames = FrameSet.PurpleFaeFlower;
                    break;
                case Monster.DarkDevil:
                    Frames = FrameSet.DarkDevil;
                    break;
                case Monster.ZumaTaurus:
                    Frames = FrameSet.ZumaTaurus;
                    break;
                case Monster.WoomaTaurus:
                    Frames = FrameSet.WoomaTaurus;
                    break;
                case Monster.KingHog:
                    Frames = FrameSet.KingHog;
                    break;
                case Monster.KingScorpion:
                    Frames = FrameSet.KingScorpion;
                    break;
                case Monster.WoomaGuardian:
                    Frames = FrameSet.WoomaGuardian;
                    break;
                case Monster.WhiteBoar:
                    Frames = FrameSet.WhiteBoar;
                    break;
                case Monster.ZumaGuardian:
                    Frames = FrameSet.ZumaGuardian;
                    break;
                case Monster.ZumaStatue:
                    Frames = FrameSet.ZumaStatue;
                    break;
                case Monster.ZumaArcher:
                    Frames = FrameSet.ZumaArcher;
                    break;
                case Monster.Ghoul:
                    Frames = FrameSet.Ghoul;
                    break;
                case Monster.EvilSnake:
                    Frames = FrameSet.EvilSnake;
                    break;
                case Monster.EvilTongs:
                    Frames = FrameSet.EvilTongs;
                    break;
                case Monster.TreeQueen:
                    Frames = FrameSet.TreeQueen;
                    break;
                case Monster.TreeGuardian:
                    Frames = FrameSet.TreeGuardian;
                    break;
                case Monster.EarthGolem:
                    Frames = FrameSet.EarthGolem;
                    break;
                case Monster.StoneGolem:
                    Frames = FrameSet.StoneGolem;
                    break;
                case Monster.ElephantMan:
                    Frames = FrameSet.ElephantMan;
                    break;
                case Monster.RhinoPriest:
                    Frames = FrameSet.RhinoPriest;
                    break;
                case Monster.RhinoWarrior:
                    Frames = FrameSet.RhinoWarrior;
                    break;
                case Monster.AssassinBird:
                    Frames = FrameSet.AssassinBird;
                    break;
                case Monster.SwampWarrior:
                    Frames = FrameSet.SwampWarrior;
                    break;
                case Monster.Mantis:
                    Frames = FrameSet.Mantis;
                    break;
                case Monster.GasToad:
                    Frames = FrameSet.GasToad;
                    break;
                case Monster.DarkOmaKing:
                    Frames = FrameSet.DarkOmaKing;
                    break;
                case Monster.PowerUpBead:
                    Frames = FrameSet.PowerUpBead;
                    break;
                case Monster.HealingBead:
                    Frames = FrameSet.HealingBead;
                    break;
                case Monster.LightningBead:
                    Frames = FrameSet.LightningBead;
                    break;
                case Monster.OmaWitchDoctor:
                    Frames = FrameSet.OmaWitchDoctor;
                    break;
                case Monster.OmaMage:
                    Frames = FrameSet.OmaMage;
                    break;
                case Monster.OmaAssassin:
                    Frames = FrameSet.OmaAssassin;
                    break;
                case Monster.OmaSlasher:
                    Frames = FrameSet.OmaSlasher;
                    break;
                case Monster.OmaBlest:
                    Frames = FrameSet.OmaBlest;
                    break;
                case Monster.OmaCannibal:
                    Frames = FrameSet.OmaCannibal;
                    break;
                case Monster.TwinHeadBeast:
                    Frames = FrameSet.TwinHeadBeast;
                    break;
                case Monster.DarkBaboon:
                    Frames = FrameSet.DarkBaboon;
                    break;
                case Monster.DarkWingedOma:
                    Frames = FrameSet.DarkWingedOma;
                    break;
                case Monster.ChieftainSword:
                    Frames = FrameSet.ChieftainSword;
                    break;
                case Monster.ChieftainArcher:
                    Frames = FrameSet.ChieftainArcher;
                    break;
                case Monster.Leopard:
                    Frames = FrameSet.Leopard;
                    break;
                case Monster.Turtlegrass:
                    Frames = FrameSet.Turtlegrass;
                    break;
                case Monster.Bear:
                    Frames = FrameSet.Bear;
                    break;
                case Monster.ManTree:
                    Frames = FrameSet.ManTree;
                    break;
                case Monster.FrostTiger:
                    Frames = FrameSet.FrostTiger;
                    break;
                case Monster.Kirin:
                    Frames = FrameSet.Kirin;
                    break;
                case Monster.Tornado:
                    Frames = FrameSet.Tornado;
                    break;
                case Monster.DragonArcher:
                    Frames = FrameSet.DragonArcher;
                    break;
                case Monster.DragonWarrior:
                    Frames = FrameSet.DragonWarrior;
                    break;
                case Monster.BlackTortoise:
                    Frames = FrameSet.BlackTortoise;
                    break;
                case Monster.WaterDragon:
                    Frames = FrameSet.WaterDragon;
                    break;
                case Monster.AncientBringer:
                    Frames = FrameSet.AncientBringer;
                    break;
                case Monster.BurningZombie:
                    Frames = FrameSet.BurningZombie;
                    break;
                case Monster.DeathCrawler:
                    Frames = FrameSet.DeathCrawler;
                    break;
                case Monster.HardenRhino:
                    Frames = FrameSet.HardenRhino;
                    break;
                case Monster.BloodBaboon:
                    Frames = FrameSet.BloodBaboon;
                    break;
                case Monster.LightBeast:
                    Frames = FrameSet.LightBeast;
                    break;
                case Monster.DarkBeast:
                    Frames = FrameSet.DarkBeast;
                    break;
                case Monster.WhiteMammoth:
                    Frames = FrameSet.WhiteMammoth;
                    break;
                case Monster.UndeadWolf:
                    Frames = FrameSet.UndeadWolf;
                    break;
                case Monster.DemonWolf:
                    Frames = FrameSet.DemonWolf;
                    break;
                case Monster.FrozenZombie:
                    Frames = FrameSet.FrozenZombie;
                    break;
                case Monster.MudZombie:
                    Frames = FrameSet.MudZombie;
                    break;
                case Monster.TucsonGeneral:
                    Frames = FrameSet.TucsonGeneral;
                    break;
                case Monster.TucsonWarrior:
                    Frames = FrameSet.TucsonWarrior;
                    break;
                case Monster.TucsonMage:
                    Frames = FrameSet.TucsonMage;
                    break;
                case Monster.TucsonFighter:
                    Frames = FrameSet.TucsonFighter;
                    break;
                case Monster.Tucson:
                    Frames = FrameSet.Tucson;
                    break;
                case Monster.CannibalTentacles:
                    Frames = FrameSet.CannibalTentacles;
                    break;
                case Monster.SandSnail:
                    Frames = FrameSet.SandSnail;
                    break;
                case Monster.VisceralWorm:
                    Frames = FrameSet.VisceralWorm;
                    break;
                case Monster.ArmadilloElder:
                    Frames = FrameSet.ArmadilloElder;
                    break;
                case Monster.Armadillo:
                    Frames = FrameSet.Armadillo;
                    break;
                case Monster.PlaguedTucson:
                    Frames = FrameSet.PlaguedTucson;
                    break;
                case Monster.GeneralMeowMeow:
                    Frames = FrameSet.GeneralMeowMeow;
                    break;
                case Monster.RestlessJar:
                    Frames = FrameSet.RestlessJar;
                    break;
                case Monster.SeedingsGeneral:
                    Frames = FrameSet.SeedingsGeneral;
                    break;
                case Monster.CatShaman:
                    Frames = FrameSet.CatShaman;
                    break;
                case Monster.StrayCat:
                    Frames = FrameSet.StrayCat;
                    break;
                case Monster.BlackHammerCat:
                    Frames = FrameSet.BlackHammerCat;
                    break;
                case Monster.StainHammerCat:
                    Frames = FrameSet.StainHammerCat;
                    break;
                case Monster.CatWidow:
                    Frames = FrameSet.CatWidow;
                    break;
                case Monster.FireCat:
                    Frames = FrameSet.FireCat;
                    break;
                case Monster.FightingCat:
                    Frames = FrameSet.FightingCat;
                    break;
                case Monster.Jar2:
                    Frames = FrameSet.Jar2;
                    break;
                case Monster.Jar1:
                    Frames = FrameSet.Jar1;
                    break;
                case Monster.HellKeeper:
                    Frames = FrameSet.HellKeeper;
                    break;
                case Monster.WitchDoctor:
                    Frames = FrameSet.WitchDoctor;
                    break;
                case Monster.HellBolt:
                    Frames = FrameSet.HellBolt;
                    break;
                case Monster.HellCannibal:
                    Frames = FrameSet.HellCannibal;
                    break;
                case Monster.HellPirate:
                    Frames = FrameSet.HellPirate;
                    break;
                case Monster.HellSlasher:
                    Frames = FrameSet.HellSlasher;
                    break;
                case Monster.DarkDevourer:
                    Frames = FrameSet.DarkDevourer;
                    break;
                case Monster.DreamDevourer:
                    Frames = FrameSet.DreamDevourer;
                    break;
                case Monster.CyanoGhast:
                    Frames = FrameSet.CyanoGhast;
                    break;
                case Monster.CrazyManworm:
                    Frames = FrameSet.CrazyManworm;
                    break;
                case Monster.MutatedManworm:
                    Frames = FrameSet.MutatedManworm;
                    break;
                case Monster.GhastlyLeecher:
                    Frames = FrameSet.GhastlyLeecher;
                    break;
                case Monster.IcePillar:
                    Frames = FrameSet.IcePillar;
                    break;
                case Monster.Blank2:
                    Frames = FrameSet.Blank2;
                    break;
                case Monster.ManectricKing:
                    Frames = FrameSet.ManectricKing;
                    break;
                case Monster.ManectricBlest:
                    Frames = FrameSet.ManectricBlest;
                    break;
                case Monster.ManectricStaff:
                    Frames = FrameSet.ManectricStaff;
                    break;
                case Monster.ManectricClaw:
                    Frames = FrameSet.ManectricClaw;
                    break;
                case Monster.ManectricClub:
                    Frames = FrameSet.ManectricClub;
                    break;
                case Monster.ManectricHammer:
                    Frames = FrameSet.ManectricHammer;
                    break;
                case Monster.OmaKing:
                    Frames = FrameSet.OmaKing;
                    break;
                case Monster.OmaGuard:
                    Frames = FrameSet.OmaGuard;
                    break;
                case Monster.FlailOma:
                    Frames = FrameSet.FlailOma;
                    break;
                case Monster.WingedOma:
                    Frames = FrameSet.WingedOma;
                    break;
                case Monster.CrossbowOma:
                    Frames = FrameSet.CrossbowOma;
                    break;
                case Monster.SwordOma:
                    Frames = FrameSet.SwordOma;
                    break;
                case Monster.AxeOma:
                    Frames = FrameSet.AxeOma;
                    break;
                case Monster.MinotaurKing:
                    Frames = FrameSet.MinotaurKing;
                    break;
                case Monster.LeftGuard:
                    Frames = FrameSet.LeftGuard;
                    break;
                case Monster.RightGuard:
                    Frames = FrameSet.RightGuard;
                    break;
                case Monster.FireMinotaur:
                    Frames = FrameSet.FireMinotaur;
                    break;
                case Monster.WindMinotaur:
                    Frames = FrameSet.WindMinotaur;
                    break;
                case Monster.ElectricMinotaur:
                    Frames = FrameSet.ElectricMinotaur;
                    break;
                case Monster.IceMinotaur:
                    Frames = FrameSet.IceMinotaur;
                    break;
                case Monster.Minotaur:
                    Frames = FrameSet.Minotaur;
                    break;
                case Monster.BoneLord:
                    Frames = FrameSet.BoneLord;
                    break;
                case Monster.BoneCaptain:
                    Frames = FrameSet.BoneCaptain;
                    break;
                case Monster.BoneSpearman:
                    Frames = FrameSet.BoneSpearman;
                    break;
                case Monster.BoneBlademan:
                    Frames = FrameSet.BoneBlademan;
                    break;
                case Monster.BoneArcher:
                    Frames = FrameSet.BoneArcher;
                    break;
                case Monster.RoninGhoul:
                    Frames = FrameSet.RoninGhoul;
                    break;
                case Monster.ToxicGhoul:
                    Frames = FrameSet.ToxicGhoul;
                    break;
                case Monster.StoningStatue:
                    Frames = FrameSet.StoningStatue;
                    break;
                case Monster.FlyingStatue:
                    Frames = FrameSet.FlyingStatue;
                    break;
                case Monster.FrozenZumaStatue:
                    Frames = FrameSet.FrozenZumaStatue;
                    break;
                case Monster.FrozenZumaGuardian:
                    Frames = FrameSet.FrozenZumaGuardian;
                    break;
                case Monster.SpiderWarrior:
                    Frames = FrameSet.SpiderWarrior;
                    break;
                case Monster.GreaterWeaver:
                    Frames = FrameSet.GreaterWeaver;
                    break;
                case Monster.CrystalWeaver:
                    Frames = FrameSet.CrystalWeaver;
                    break;
                case Monster.ArmingWeaver:
                    Frames = FrameSet.ArmingWeaver;
                    break;
                case Monster.CrackingWeaver:
                    Frames = FrameSet.CrackingWeaver;
                    break;
                case Monster.Weaver:
                    Frames = FrameSet.Weaver;
                    break;
                case Monster.ValeBat:
                    Frames = FrameSet.ValeBat;
                    break;
                case Monster.EvilApe:
                    Frames = FrameSet.EvilApe;
                    break;
                case Monster.RedMoonEvil:
                    Frames = FrameSet.RedMoonEvil;
                    break;
                case Monster.CrystalSpider:
                    Frames = FrameSet.CrystalSpider;
                    break;
                case Monster.RedEvilApe:
                    Frames = FrameSet.RedEvilApe;
                    break;
                case Monster.GrayEvilApe:
                    Frames = FrameSet.GrayEvilApe;
                    break;
                case Monster.BigApe:
                    Frames = FrameSet.BigApe;
                    break;
                case Monster.LureSpider:
                    Frames = FrameSet.LureSpider;
                    break;
                case Monster.GreatSpider:
                    Frames = FrameSet.GreatSpider;
                    break;
                case Monster.GangSpider:
                    Frames = FrameSet.GangSpider;
                    break;
                case Monster.VenomSpider:
                    Frames = FrameSet.VenomSpider;
                    break;
                case Monster.SpiderBat:
                    Frames = FrameSet.SpiderBat;
                    break;
                case Monster.RootSpider:
                    Frames = FrameSet.RootSpider;
                    break;
                case Monster.BombSpider:
                    Frames = FrameSet.BombSpider;
                    break;
                case Monster.NdZombie:
                    Frames = FrameSet.NdZombie;
                    break;
                case Monster.ClZombie:
                    Frames = FrameSet.ClZombie;
                    break;
                case Monster.DigOutZombie:
                    Frames = FrameSet.DigOutZombie;
                    break;
                case Monster.ShamanZombie:
                    Frames = FrameSet.ShamanZombie;
                    break; 
                case Monster.FlamingWooma:
                    Frames = FrameSet.FlamingWooma;
                    break;
                case Monster.WoomaWarrior:
                    Frames = FrameSet.WoomaWarrior;
                    break;
                case Monster.WoomaFighter:
                    Frames = FrameSet.WoomaFighter;
                    break;
                case Monster.WoomaSoldier:
                    Frames = FrameSet.WoomaSoldier;
                    break;
                case Monster.Dung:
                    Frames = FrameSet.Dung;
                    break;
                case Monster.Dark:
                    Frames = FrameSet.Dark;
                    break;
                case Monster.Khazard:
                    Frames = FrameSet.Khazard;
                    break;
                case Monster.VioletKekTal:
                    Frames = FrameSet.VioletKekTal;
                    break;
                case Monster.KekTal:
                    Frames = FrameSet.KekTal;
                    break;
                case Monster.BlueHoroBlaster:
                    Frames = FrameSet.BlueHoroBlaster;
                    break;
                case Monster.HoroBlaster:
                    Frames = FrameSet.HoroBlaster;
                    break;
                case Monster.SpiderFrog:
                    Frames = FrameSet.SpiderFrog;
                    break;
                case Monster.RedFrogSpider:
                    Frames = FrameSet.RedFrogSpider;
                    break;
                case Monster.BrownFrogSpider:
                    Frames = FrameSet.BrownFrogSpider;
                    break;
                case Monster.BigHedgeKekTal:
                    Frames = FrameSet.BigHedgeKekTal;
                    break;
                case Monster.HedgeKekTal:
                    Frames = FrameSet.HedgeKekTal;
                    break;
                case Monster.CloudElement:
                    Frames = FrameSet.CloudElement;
                    break;
                case Monster.ThunderElement:
                    Frames = FrameSet.ThunderElement;
                    break;
                case Monster.GuardianRock:
                    Frames = FrameSet.GuardianRock;
                    break;
                case Monster.TrapRock:
                    Frames = FrameSet.TrapRock;
                    break;
                case Monster.WhiteFoxman:
                    Frames = FrameSet.WhiteFoxman;
                    break;
                case Monster.BlackFoxman:
                    Frames = FrameSet.BlackFoxman;
                    break;
                case Monster.RedFoxman:
                    Frames = FrameSet.RedFoxman;
                    break;
                case Monster.RedThunderZuma:
                    Frames = FrameSet.RedThunderZuma;
                    break;
                case Monster.BigRat:
                    Frames = FrameSet.BigRat;
                    break;
                case Monster.BlackBoar:
                    Frames = FrameSet.BlackBoar;
                    break;
                case Monster.RedBoar:
                    Frames = FrameSet.RedBoar;
                    break;
                case Monster.SnakeScorpion:
                    Frames = FrameSet.SnakeScorpion;
                    break;
                case Monster.BlackMaggot:
                    Frames = FrameSet.BlackMaggot;
                    break;
                case Monster.BugBatMaggot:
                    Frames = FrameSet.BugBatMaggot;
                    break;
                case Monster.BugBat:
                    Frames = FrameSet.BugBat;
                    break;
                case Monster.WedgeMoth:
                    Frames = FrameSet.WedgeMoth;
                    break;
                case Monster.EvilCentipede:
                    Frames = FrameSet.EvilCentipede;
                    break;
                case Monster.Tongs:
                    Frames = FrameSet.Tongs;
                    break;
                case Monster.WhimperingBee:
                    Frames = FrameSet.WhimperingBee;
                    break;
                case Monster.GiantWorm:
                    Frames = FrameSet.GiantWorm;
                    break;
                case Monster.Centipede:
                    Frames = FrameSet.Centipede;
                    break;
                case Monster.Treasurebox:
                    Frames = FrameSet.Treasurebox;
                    break;
                case Monster.Yimoogi:
                    Frames = FrameSet.Yimoogi;
                    break;
                case Monster.GiantWhiteSnake:
                    Frames = FrameSet.GiantWhiteSnake;
                    break;
                case Monster.YellowSnake:
                    Frames = FrameSet.YellowSnake;
                    break;
                case Monster.BlueSnake:
                    Frames = FrameSet.BlueSnake;
                    break;
                case Monster.CrawlerZombie:
                    Frames = FrameSet.CrawlerZombie;
                    break;
                case Monster.BoneWhoo:
                    Frames = FrameSet.BoneWhoo;
                    break;
                case Monster.BoneElite:
                    Frames = FrameSet.BoneElite;
                    break;
                case Monster.BoneWarrior:
                    Frames = FrameSet.BoneWarrior;
                    break;
                case Monster.BoneFighter:
                    Frames = FrameSet.BoneFighter;
                    break;
                case Monster.Skeleton:
                    Frames = FrameSet.Skeleton;
                    break;
                case Monster.AxeSkeleton:
                    Frames = FrameSet.AxeSkeleton;
                    break;
                case Monster.Scorpion:
                    Frames = FrameSet.Scorpion;
                    break;
                case Monster.CaveMaggot:
                    Frames = FrameSet.CaveMaggot;
                    break;
                case Monster.CaveBat:
                    Frames = FrameSet.CaveBat;
                    break;
                case Monster.GiantKeratoid:
                    Frames = FrameSet.GiantKeratoid;
                    break;
                case Monster.SandWorm:
                    Frames = FrameSet.SandWorm;
                    break;
                case Monster.SkyStinger:
                    Frames = FrameSet.SkyStinger;
                    break;
                case Monster.ShellNipper:
                    Frames = FrameSet.ShellNipper;
                    break;
                case Monster.Keratoid:
                    Frames = FrameSet.Keratoid;
                    break;
                case Monster.TigerSnake:
                    Frames = FrameSet.TigerSnake;
                    break;
                case Monster.RedSnake:
                    Frames = FrameSet.RedSnake;
                    break;
                case Monster.LargeMushroom:
                    Frames = FrameSet.LargeMushroom;
                    break;
                case Monster.CherryTree:
                    Frames = FrameSet.CherryTree;
                    break;
                case Monster.EbonyTree:
                    Frames = FrameSet.EbonyTree;
                    break;
                case Monster.ChestnutTree:
                    Frames = FrameSet.ChestnutTree;
                    break;
                case Monster.ForestYeti:
                    Frames = FrameSet.ForestYeti;
                    break;
                case Monster.OmaWarrior:
                    Frames = FrameSet.OmaWarrior;
                    break;
                case Monster.OmaFighter:
                    Frames = FrameSet.OmaFighter;
                    break;
                case Monster.Oma:
                    Frames = FrameSet.Oma;
                    break;
                case Monster.CannibalPlant:
                    Frames = FrameSet.CannibalPlant;
                    break;
                case Monster.SpittingSpider:
                    Frames = FrameSet.SpittingSpider;
                    break;
                case Monster.RakingCat:
                    Frames = FrameSet.RakingCat;
                    break;
                case Monster.HookingCat:
                    Frames = FrameSet.HookingCat;
                    break;
                case Monster.Scarecrow:
                    Frames = FrameSet.Scarecrow;
                    break;
                case Monster.Yob:
                    Frames = FrameSet.Yob;
                    break;
                case Monster.Wolf:
                    Frames = FrameSet.Wolf;
                    break;
                case Monster.Sheep:
                    Frames = FrameSet.Sheep;
                    break;
                case Monster.Bull:
                    Frames = FrameSet.Bull;
                    break;
                case Monster.Pig:
                    Frames = FrameSet.Pig;
                    break;
                case Monster.Deer:
                    Frames = FrameSet.Deer;
                    break;
                case Monster.Hen:
                    Frames = FrameSet.Hen;
                    break;
                case Monster.IcePhantom:
                    Frames = FrameSet.IcePhantom;
                    break;
                case Monster.SnakeTotem:
                    Frames = FrameSet.SnakeTotem;
                    break;
                case Monster.SpittingToad:
                    Frames = FrameSet.SpittingToad;
                    break;
                case Monster.VampireSpider:
                    Frames = FrameSet.VampireSpider;
                    break;
                case Monster.HolyDeva:
                    Frames = FrameSet.HolyDeva;
                    break;
                case Monster.Shinsu:
                    Frames = FrameSet.Shinsu;
                    break;
                case Monster.BoneFamiliar:
                    Frames = FrameSet.BoneFamiliar;
                    break;
                case Monster.KatanaGuard:
                    Frames = FrameSet.KatanaGuard;
                    break;
                case Monster.Guard2:
                    Frames = FrameSet.Guard2;
                    break;
                case Monster.TaoistGuard:
                    Frames = FrameSet.TaoistGuard;
                    break;
                case Monster.Guard:
                    Frames = FrameSet.Guard;
                    break;
                case Monster.ArcherGuard:
                    Frames = FrameSet.ArcherGuard;
                    break;
                case Monster.CharmedSnake:
                    Frames = FrameSet.CharmedSnake;
                    break;
                case Monster.FrozenSoldier:
                    Frames = FrameSet.FrozenSoldier;
                    break;
                case Monster.FrozenFighter:
                    Frames = FrameSet.FrozenFighter;
                    break;
                case Monster.FrozenArcher:
                    Frames = FrameSet.FrozenArcher;
                    break;
                case Monster.FrozenKnight:
                    Frames = FrameSet.FrozenKnight;
                    break;
                case Monster.SnowWolf:
                    Frames = FrameSet.SnowWolf;
                    break;
                case Monster.SnowWolfKing:
                    Frames = FrameSet.SnowWolfKing;
                    break;
                case Monster.FrozenMiner:
                    Frames = FrameSet.FrozenMiner;
                    break;
                case Monster.FrozenAxeman:
                    Frames = FrameSet.FrozenAxeman;
                    break;
                case Monster.FrozenMagician:
                    Frames = FrameSet.FrozenMagician;
                    break;
                case Monster.SnowYeti:
                    Frames = FrameSet.SnowYeti;
                    break;
                case Monster.IceCrystalSoldier:
                    Frames = FrameSet.IceCrystalSoldier;
                    break;
                case Monster.DarkWraith:
                    Frames = FrameSet.DarkWraith;
                    break;
                case Monster.DarkSpirit:
                    Frames = FrameSet.DarkSpirit;
                    break;
                case Monster.CrystalBeast:
                    Frames = FrameSet.CrystalBeast;
                    break;
                case Monster.Guard3:
                    Frames = FrameSet.Guard3;
                    break;
                case Monster.ArcherGuard3:
                    Frames = FrameSet.ArcherGuard3;
                    break;
                case Monster.Football:
                    Frames = FrameSet.Football;
                    break;
                case Monster.DarkGhost:
                    Frames = FrameSet.DarkGhost;
                    break;
                case Monster.RedTurtle:
                    Frames = FrameSet.RedTurtle;
                    break;
                case Monster.GreenTurtle:
                    Frames = FrameSet.GreenTurtle;
                    break;
                case Monster.BlueTurtle:
                    Frames = FrameSet.BlueTurtle;
                    break;
                case Monster.TowerTurtle:
                    Frames = FrameSet.TowerTurtle;
                    break;
                case Monster.FinialTurtle:
                    Frames = FrameSet.FinialTurtle;
                    break;
                case Monster.DarkTurtle:
                    Frames = FrameSet.DarkTurtle;
                    break;
                case Monster.LightTurtle:
                    Frames = FrameSet.LightTurtle;
                    break;
                case Monster.TurtleKing:
                    Frames = FrameSet.TurtleKing;
                    break;
                case Monster.ManectricSlave:
                    Frames = FrameSet.ManectricSlave;
                    break;
                case Monster.TrollHammer:
                    Frames = FrameSet.TrollHammer;
                    break;
                case Monster.TrollBomber:
                    Frames = FrameSet.TrollBomber;
                    break;
                case Monster.TrollStoner:
                    Frames = FrameSet.TrollStoner;
                    break;
                case Monster.FlameMage:
                    Frames = FrameSet.FlameMage;
                    break;
                case Monster.FlameSpear:
                    Frames = FrameSet.FlameSpear;
                    break;
                case Monster.FlameScythe:
                    Frames = FrameSet.FlameScythe;
                    break;
                case Monster.FlameAssassin:
                    Frames = FrameSet.FlameAssassin;
                    break;
                case Monster.TrollKing:
                    Frames = FrameSet.TrollKing;
                    break;
                case Monster.FlameQueen:
                    Frames = FrameSet.FlameQueen;
                    break;
                case Monster.HellKnight1:
                    Frames = FrameSet.HellKnight1;
                    break;
                case Monster.HellKnight2:
                    Frames = FrameSet.HellKnight2;
                    break;
                case Monster.HellKnight3:
                    Frames = FrameSet.HellKnight3;
                    break;
                case Monster.HellKnight4:
                    Frames = FrameSet.HellKnight4;
                    break;
                case Monster.HellLord:
                    Frames = FrameSet.HellLord;
                    break;
                case Monster.Behemoth:
                    Frames = FrameSet.Behemoth;
                    break;
                case Monster.Snake14:
                    Frames = FrameSet.Snake14;
                    break;
                case Monster.WarriorScroll:
                    Frames = FrameSet.WarriorScroll;
                    break;
                case Monster.TaoistScroll:
                    Frames = FrameSet.TaoistScroll;
                    break;
                case Monster.WizardScroll:
                    Frames = FrameSet.WizardScroll;
                    break;
                case Monster.AssassinScroll:
                    Frames = FrameSet.AssassinScroll;
                    break;
                case Monster.WingedTigerLord:
                    Frames = FrameSet.WingedTigerLord;
                    break;
                case Monster.FlameTiger:
                    Frames = FrameSet.FlameTiger;
                    break;
                case Monster.RedYimoogi:
                    Frames = FrameSet.RedYimoogi;
                    break;
                case Monster.BlueSanta:
                    Frames = FrameSet.BlueSanta;
                    break;
                case Monster.OldSpittingSpider:
                    Frames = FrameSet.OldSpittingSpider;
                    break;
                case Monster.Catapult2:
                    Frames = FrameSet.Catapult2;
                    break;
                case Monster.GiantEgg:
                    Frames = FrameSet.GiantEgg;
                    break;
                case Monster.SnowTree:
                    Frames = FrameSet.SnowTree;
                    break;
                case Monster.Snowman:
                    Frames = FrameSet.Snowman;
                    break;
                case Monster.SnowPile:
                    Frames = FrameSet.SnowPile;
                    break;
                case Monster.TailedLion:
                    Frames = FrameSet.TailedLion;
                    break;
                case Monster.MudPile:
                    Frames = FrameSet.MudPile;
                    break;
                case Monster.HalloweenScythe:
                    Frames = FrameSet.HalloweenScythe;
                    break;
                case Monster.GingerBreadman:
                    Frames = FrameSet.GingerBreadman;
                    break;
                case Monster.DarkBrownWolf:
                    Frames = FrameSet.DarkBrownWolf;
                    break;
                case Monster.DarkDustPile:
                    Frames = FrameSet.DarkDustPile;
                    break;
                case Monster.HighAssassin:
                    Frames = FrameSet.HighAssassin;
                    break;
                case Monster.ChristmasTree:
                    Frames = FrameSet.ChristmasTree;
                    break;
                case Monster.Bush:
                    Frames = FrameSet.Bush;
                    break;
                case Monster.ArcherGuard2:
                    Frames = FrameSet.ArcherGuard2;
                    break;
                case Monster.Shinsu1:
                    Frames = FrameSet.Shinsu1;
                    break; 
                case Monster.SiegeRepairman:
                    Frames = FrameSet.SiegeRepairman;
                    break;
                case Monster.BattleStandard:
                    Frames = FrameSet.BattleStandard;
                    break;
                case Monster.LionRiderMale:
                    Frames = FrameSet.LionRiderMale;
                    break;
                case Monster.LionRiderFemale:
                    Frames = FrameSet.LionRiderFemale;
                    break;
                case Monster.NamelessGhost:
                    Frames = FrameSet.NamelessGhost;
                    break;
                case Monster.ChaosGhost:
                    Frames = FrameSet.ChaosGhost;
                    break;
                case Monster.FrostYeti:
                    Frames = FrameSet.FrostYeti;
                    break; 
                case Monster.IceGuard:
                    Frames = FrameSet.IceGuard;
                    break; 
                case Monster.WaterGuard:
                    Frames = FrameSet.WaterGuard;
                    break; 
                case Monster.ElementGuard:
                    Frames = FrameSet.ElementGuard;
                    break;
                case Monster.DemonGuard:
                    Frames = FrameSet.DemonGuard;
                    break; 
                case Monster.PoisonHugger:
                    Frames = FrameSet.PoisonHugger;
                    break;
                case Monster.MutatedHugger:
                    Frames = FrameSet.MutatedHugger;
                    break;
                case Monster.Snake10:
                    Frames = FrameSet.Snake10;
                    break;
                case Monster.Snake11:
                    Frames = FrameSet.Snake11;
                    break;
                case Monster.Snake12:
                    Frames = FrameSet.Snake12;
                    break;
                case Monster.Snake13:
                    Frames = FrameSet.Snake13;
                    break;
                case Monster.Snake15:
                    Frames = FrameSet.Snake15;
                    break;
                case Monster.Snake16:
                    Frames = FrameSet.Snake16;
                    break;
                case Monster.Snake17:
                    Frames = FrameSet.Snake17;
                    break;
                case Monster.Bunny:
                    Frames = FrameSet.Bunny;
                    break;
                case Monster.TucsonEgg:
                    Frames = FrameSet.TucsonEgg;
                    break; 
                case Monster.RedOrb:
                    Frames = FrameSet.RedOrb;
                    break; 
                case Monster.BlueOrb:
                    Frames = FrameSet.BlueOrb;
                    break;
                case Monster.YellowOrb:
                    Frames = FrameSet.YellowOrb;
                    break;
                case Monster.GreenOrb:
                    Frames = FrameSet.GreenOrb;
                    break;
                case Monster.WhiteOrb:
                    Frames = FrameSet.WhiteOrb;
                    break;
                case Monster.FatalLotus:
                    Frames = FrameSet.FatalLotus;
                    break;
                case Monster.AntCommander:
                    Frames = FrameSet.AntCommander;
                    break;
                case Monster.CargoBoxwithlogo:
                    Frames = FrameSet.CargoBoxwithlogo;
                    break;
                case Monster.Doe:
                    Frames = FrameSet.Doe;
                    break;
                case Monster.AngryReindeer:
                    Frames = FrameSet.AngryReindeer;
                    break;
                case Monster.Ram1:
                    Frames = FrameSet.Ram1;
                    break;
                case Monster.Ram2:
                    Frames = FrameSet.Ram2;
                    break;
                case Monster.Kite:
                    Frames = FrameSet.Kite;
                    break;
                case Monster.KingKong:
                    Frames = FrameSet.KingKong;
                    break;

                default:
                    if (BodyLibrary != null)
                    {
                        Frames = BodyLibrary.Frames ?? FrameSet.DefaultMonster;
                    }
                    break;
            }

            SetAction();
            SetCurrentEffects();

            if (CurrentAction == MirAction.Standing)
            {
                PlayAppearSound();

                if (Frame != null)
                {
                    FrameIndex = CMain.Random.Next(Frame.Count);
                }
            }
            else if (CurrentAction == MirAction.SitDown)
            {
                PlayAppearSound();
            }

            NextMotion -= NextMotion % 100;

            if (Settings.Effect)
            {
                switch (BaseImage)
                {
                    case Monster.Weaver:
                    case Monster.VenomWeaver:
                    case Monster.ArmingWeaver:
                    case Monster.ValeBat:
                    case Monster.CrackingWeaver:
                    case Monster.GreaterWeaver:
                        Effects.Add(new Effect(Libraries.Effect, 601, 1, 1 * Frame.Interval, this) { DrawBehind = true, Repeat = true }); // Blue effect                        
                        break;
                    case Monster.CrystalWeaver:
                    case Monster.FrozenZumaGuardian:
                    case Monster.FrozenRedZuma:
                    case Monster.FrozenZumaStatue:
                        Effects.Add(new Effect(Libraries.Effect, 600, 1, 1 * Frame.Interval, this) { DrawBehind = true, Repeat = true }); // Blue effect
                        break;
                    case Monster.CaveStatue:
                        Effects.Add(new Effect(Libraries.Monsters[(ushort)Monster.CaveStatue], 10, 8, 2400, this) { Blend = true, Repeat = true });
                        break;
                }
            }

            ProcessBuffs();
        }

        public void ProcessBuffs()
        {
            for (int i = 0; i < Buffs.Count; i++)
            {
                AddBuffEffect(Buffs[i]);
            }
        }

        public virtual bool ShouldDrawHealth()
        {
            string name = string.Empty;
            if (Name.Contains("(")) name = Name.Substring(Name.IndexOf("(") + 1, Name.Length - Name.IndexOf("(") - 2);

            return Name.EndsWith(string.Format("({0})", User.Name)) || MirScenes.Dialogs.GroupDialog.GroupList.Contains(name);
        }

        public override void Process()
        {
            bool update = CMain.Time >= NextMotion || GameScene.CanMove;
            SkipFrames = ActionFeed.Count > 1;

            ProcessFrames();

            if (Frame == null)
            {
                DrawFrame = 0;
                DrawWingFrame = 0;
            }
            else
            {
                DrawFrame = Frame.Start + (Frame.OffSet * (byte)Direction) + FrameIndex;
                DrawWingFrame = Frame.EffectStart + (Frame.EffectOffSet * (byte)Direction) + EffectFrameIndex;
            }


            #region Moving OffSet

            switch (CurrentAction)
            {
                case MirAction.Walking:
                case MirAction.Running:
                case MirAction.Pushed:
                case MirAction.Jump:
                case MirAction.DashL:
                case MirAction.DashR:
                case MirAction.DashAttack:
                    if (Frame == null)
                    {
                        OffSetMove = Point.Empty;
                        Movement = CurrentLocation;
                        break;
                    }
                    int i = CurrentAction == MirAction.Running ? 2 : 1;

                    if (CurrentAction == MirAction.Jump) i = -JumpDistance;
                    if (CurrentAction == MirAction.DashAttack) i = JumpDistance;

                    Movement = Functions.PointMove(CurrentLocation, Direction, CurrentAction == MirAction.Pushed ? 0 : -i);

                    int count = Frame.Count;
                    int index = FrameIndex;

                    if (CurrentAction == MirAction.DashR || CurrentAction == MirAction.DashL)
                    {
                        count = 3;
                        index %= 3;
                    }

                    switch (Direction)
                    {
                        case MirDirection.Up:
                            OffSetMove = new Point(0, (int)((MapControl.CellHeight * i / (float)(count)) * (index + 1)));
                            break;
                        case MirDirection.UpRight:
                            OffSetMove = new Point((int)((-MapControl.CellWidth * i / (float)(count)) * (index + 1)), (int)((MapControl.CellHeight * i / (float)(count)) * (index + 1)));
                            break;
                        case MirDirection.Right:
                            OffSetMove = new Point((int)((-MapControl.CellWidth * i / (float)(count)) * (index + 1)), 0);
                            break;
                        case MirDirection.DownRight:
                            OffSetMove = new Point((int)((-MapControl.CellWidth * i / (float)(count)) * (index + 1)), (int)((-MapControl.CellHeight * i / (float)(count)) * (index + 1)));
                            break;
                        case MirDirection.Down:
                            OffSetMove = new Point(0, (int)((-MapControl.CellHeight * i / (float)(count)) * (index + 1)));
                            break;
                        case MirDirection.DownLeft:
                            OffSetMove = new Point((int)((MapControl.CellWidth * i / (float)(count)) * (index + 1)), (int)((-MapControl.CellHeight * i / (float)(count)) * (index + 1)));
                            break;
                        case MirDirection.Left:
                            OffSetMove = new Point((int)((MapControl.CellWidth * i / (float)(count)) * (index + 1)), 0);
                            break;
                        case MirDirection.UpLeft:
                            OffSetMove = new Point((int)((MapControl.CellWidth * i / (float)(count)) * (index + 1)), (int)((MapControl.CellHeight * i / (float)(count)) * (index + 1)));
                            break;
                    }

                    OffSetMove = new Point(OffSetMove.X % 2 + OffSetMove.X, OffSetMove.Y % 2 + OffSetMove.Y);
                    break;
                default:
                    OffSetMove = Point.Empty;
                    Movement = CurrentLocation;
                    break;
            }

            #endregion

            DrawY = Movement.Y > CurrentLocation.Y ? Movement.Y : CurrentLocation.Y;

            DrawLocation = new Point((Movement.X - User.Movement.X + MapControl.OffSetX) * MapControl.CellWidth, (Movement.Y - User.Movement.Y + MapControl.OffSetY) * MapControl.CellHeight);
            DrawLocation.Offset(-OffSetMove.X, -OffSetMove.Y);
            DrawLocation.Offset(User.OffSetMove);
            DrawLocation = DrawLocation.Add(ManualLocationOffset);
            DrawLocation.Offset(GlobalDisplayLocationOffset);

            if (BodyLibrary != null && update)
            {
                FinalDrawLocation = DrawLocation.Add(BodyLibrary.GetOffSet(DrawFrame));
                DisplayRectangle = new Rectangle(DrawLocation, BodyLibrary.GetTrueSize(DrawFrame));
            }

            for (int i = 0; i < Effects.Count; i++)
                Effects[i].Process();

            Color colour = DrawColour;
            if (Poison == PoisonType.None)
                DrawColour = Color.White;
            if (Poison.HasFlag(PoisonType.Green))
                DrawColour = Color.Green;
            if (Poison.HasFlag(PoisonType.Red))
                DrawColour = Color.Red;
            if (Poison.HasFlag(PoisonType.Bleeding))
                DrawColour = Color.DarkRed;
            if (Poison.HasFlag(PoisonType.Slow))
                DrawColour = Color.Purple;
            if (Poison.HasFlag(PoisonType.Stun) || Poison.HasFlag(PoisonType.Dazed))
                DrawColour = Color.Yellow;
            if (Poison.HasFlag(PoisonType.Blindness))
                DrawColour = Color.MediumVioletRed;
            if (Poison.HasFlag(PoisonType.Frozen))
                DrawColour = Color.Blue;
            if (Poison.HasFlag(PoisonType.Paralysis) || Poison.HasFlag(PoisonType.LRParalysis))
                DrawColour = Color.Gray;
            if (Poison.HasFlag(PoisonType.DelayedExplosion))
                DrawColour = Color.Orange;
            if (colour != DrawColour) GameScene.Scene.MapControl.TextureValid = false;
        }

        public bool SetAction()
        {
            if (NextAction != null && !GameScene.CanMove)
            {
                switch (NextAction.Action)
                {
                    case MirAction.Walking:
                    case MirAction.Running:
                    case MirAction.Pushed:
                        return false;
                }
            }

            //IntelligentCreature
            switch (BaseImage)
            {
                case Monster.BabyPig:
                case Monster.Chick:
                case Monster.Kitten:
                case Monster.BabySkeleton:
                case Monster.Baekdon:
                case Monster.Wimaen:
                case Monster.BlackKitten:
                case Monster.BabyDragon:
                case Monster.OlympicFlame:
                case Monster.BabySnowMan:
                case Monster.Frog:
                case Monster.BabyMonkey:
                case Monster.AngryBird:
                case Monster.Foxey:
                case Monster.MedicalRat:
                    BodyLibrary = Libraries.Pets[((ushort)BaseImage) - 10000];
                    break;
            }

            if (ActionFeed.Count == 0)
            {
                CurrentAction = Stoned ? MirAction.Stoned : MirAction.Standing;
                if (CurrentAction == MirAction.Standing) CurrentAction = SitDown ? MirAction.SitDown : MirAction.Standing;

                Frames.TryGetValue(CurrentAction, out Frame);

                if (MapLocation != CurrentLocation)
                {
                    GameScene.Scene.MapControl.RemoveObject(this);
                    MapLocation = CurrentLocation;
                    GameScene.Scene.MapControl.AddObject(this);
                }

                FrameIndex = 0;

                if (Frame == null) return false;

                FrameInterval = Frame.Interval;
            }
            else
            {
                QueuedAction action = ActionFeed[0];
                ActionFeed.RemoveAt(0);

                CurrentActionLevel = 0;
                CurrentAction = action.Action;
                CurrentLocation = action.Location;
                Direction = action.Direction;

                Point temp;
                switch (CurrentAction)
                {
                    case MirAction.Walking:
                    case MirAction.Running:
                    case MirAction.Pushed:
                        int i = CurrentAction == MirAction.Running ? 2 : 1;
                        temp = Functions.PointMove(CurrentLocation, Direction, CurrentAction == MirAction.Pushed ? 0 : -i);
                        break;
                    case MirAction.Jump:
                    case MirAction.DashAttack:
                        temp = Functions.PointMove(CurrentLocation, Direction, JumpDistance);
                        break;
                    default:
                        temp = CurrentLocation;
                        break;
                }

                temp = new Point(action.Location.X, temp.Y > CurrentLocation.Y ? temp.Y : CurrentLocation.Y);

                if (MapLocation != temp)
                {
                    GameScene.Scene.MapControl.RemoveObject(this);
                    MapLocation = temp;
                    GameScene.Scene.MapControl.AddObject(this);
                }


                switch (CurrentAction)
                {
                    case MirAction.Pushed:
                        Frames.TryGetValue(MirAction.Walking, out Frame);
                        break;
                    case MirAction.Jump:
                        Frames.TryGetValue(MirAction.Jump, out Frame);
                        break;
                    case MirAction.DashAttack:
                        Frames.TryGetValue(MirAction.DashAttack, out Frame);
                        break;
                    case MirAction.AttackRange1:
                        if (!Frames.TryGetValue(CurrentAction, out Frame))
                            Frames.TryGetValue(MirAction.Attack1, out Frame);
                        break;
                    case MirAction.AttackRange2:
                        if (!Frames.TryGetValue(CurrentAction, out Frame))
                            Frames.TryGetValue(MirAction.Attack2, out Frame);
                        break;
                    case MirAction.AttackRange3:
                        if (!Frames.TryGetValue(CurrentAction, out Frame))
                            Frames.TryGetValue(MirAction.Attack3, out Frame);
                        break;
                    case MirAction.Special:
                        if (!Frames.TryGetValue(CurrentAction, out Frame))
                            Frames.TryGetValue(MirAction.Attack1, out Frame);
                        break;
                    case MirAction.Skeleton:
                        if (!Frames.TryGetValue(CurrentAction, out Frame))
                            Frames.TryGetValue(MirAction.Dead, out Frame);
                        break;
                    case MirAction.Hide:
                        switch (BaseImage)
                        {
                            case Monster.Shinsu1:
                                BodyLibrary = Libraries.Monsters[(ushort)Monster.Shinsu];
                                BaseImage = Monster.Shinsu;
                                BaseSound = (ushort)BaseImage * 10;
                                Frames = BodyLibrary.Frames ?? FrameSet.DefaultMonster;
                                Frames.TryGetValue(CurrentAction, out Frame);
                                break;
                            default:
                                Frames.TryGetValue(CurrentAction, out Frame);
                                break;
                        }
                        break;
                    case MirAction.Dead:
                        switch (BaseImage)
                        {
                            case Monster.Shinsu:
                            case Monster.Shinsu1:
                            case Monster.HolyDeva:
                            case Monster.GuardianRock:
                            case Monster.CharmedSnake://SummonSnakes
                            case Monster.HellKnight1:
                            case Monster.HellKnight2:
                            case Monster.HellKnight3:
                            case Monster.HellKnight4:
                            case Monster.HellBomb1:
                            case Monster.HellBomb2:
                            case Monster.HellBomb3:
                                Remove();
                                return false;
                            default:
                                Frames.TryGetValue(CurrentAction, out Frame);
                                break;
                        }
                        break;
                    default:
                        Frames.TryGetValue(CurrentAction, out Frame);
                        break;

                }

                FrameIndex = 0;

                if (Frame == null) return false;

                FrameInterval = Frame.Interval;

                Point front = Functions.PointMove(CurrentLocation, Direction, 1);

                switch (CurrentAction)
                {
                    case MirAction.Appear:
                        PlaySummonSound();
                        switch (BaseImage)
                        {
                            case Monster.HellKnight1:
                            case Monster.HellKnight2:
                            case Monster.HellKnight3:
                            case Monster.HellKnight4:
                                Effects.Add(new Effect(Libraries.Monsters[(ushort)BaseImage], 448, 10, 600, this));
                                break;
                        }
                        break;
                    case MirAction.Show:
                        PlayPopupSound();
                        break;
                    case MirAction.Pushed:
                        FrameIndex = Frame.Count - 1;
                        GameScene.Scene.Redraw();
                        break;
                    case MirAction.Jump:
                        PlayJumpSound();
                        switch (BaseImage)
                        {
                            // Sanjian
                            case Monster.FurbolgGuard:
                                Effects.Add(new Effect(Libraries.Monsters[(ushort)Monster.FurbolgGuard], 414 + (int)Direction * 6, 6, Frame.Count * Frame.Interval, this));
                                break;




                            case Monster.Armadillo:
                                MapControl.Effects.Add(new Effect(Libraries.Monsters[(ushort)BaseImage], 592, 12, 800, CurrentLocation, CMain.Time + 500));
                                break;
                        }
                        break;
                    case MirAction.DashAttack:
                        PlayDashSound();
                        break;
                    case MirAction.Walking:
                        GameScene.Scene.Redraw();
                        break;
                    case MirAction.Running:
                        PlayRunSound();
                        GameScene.Scene.Redraw();
                        break;
                    case MirAction.Attack1:
                        PlayAttackSound();
                        CurrentActionLevel = (byte)action.Params[1];
                        switch (BaseImage)
                        {
                            case Monster.FlamingWooma:
                                Effects.Add(new Effect(Libraries.Monsters[(ushort)Monster.FlamingWooma], 224 + (int)Direction * 7, 7, Frame.Count * Frame.Interval, this));
                                break;
                            case Monster.ZumaTaurus:
                                Effects.Add(new Effect(Libraries.Monsters[(ushort)Monster.ZumaTaurus], 244 + (int)Direction * 8, 8, 8 * FrameInterval, this));
                                break;
                            case Monster.MinotaurKing:
                                Effects.Add(new Effect(Libraries.Monsters[(ushort)Monster.MinotaurKing], 272 + (int)Direction * 6, 6, Frame.Count * Frame.Interval, this));
                                break;
                            case Monster.FlamingMutant:
                                MapControl.Effects.Add(new Effect(Libraries.Monsters[(ushort)Monster.FlamingMutant], 314, 6, 600, front));
                                break;
                            case Monster.DemonWolf:
                                Effects.Add(new Effect(Libraries.Monsters[(ushort)Monster.DemonWolf], 336 + (int)Direction * 9, 6, Frame.Count * Frame.Interval, this));
                                break;
                            case Monster.AncientBringer:
                                Effects.Add(new Effect(Libraries.Monsters[(ushort)Monster.AncientBringer], 512 + (int)Direction * 6, 6, Frame.Count * Frame.Interval, this));
                                break;
                            case Monster.Manticore:
                                Effects.Add(new Effect(Libraries.Monsters[(ushort)Monster.Manticore], 505 + (int)Direction * 3, 3, Frame.Count * Frame.Interval, this));
                                break;
                            case Monster.YinDevilNode:
                                Effects.Add(new Effect(Libraries.Monsters[(ushort)Monster.YinDevilNode], 26, 26, Frame.Count * Frame.Interval, this));
                                break;
                            case Monster.YangDevilNode:
                                Effects.Add(new Effect(Libraries.Monsters[(ushort)Monster.YangDevilNode], 26, 26, Frame.Count * Frame.Interval, this));
                                break;
                            case Monster.GreatFoxSpirit:
                                Effects.Add(new Effect(Libraries.Monsters[(ushort)Monster.GreatFoxSpirit], 355, 20, Frame.Count * Frame.Interval, this));
                                break;
                            case Monster.EvilMir:
                                Effects.Add(new Effect(Libraries.Dragon, 60, 8, 8 * Frame.Interval, this));
                                Effects.Add(new Effect(Libraries.Dragon, 68, 14, 14 * Frame.Interval, this));
                                byte random = (byte)CMain.Random.Next(7);
                                for (int i = 0; i <= 7 + random; i++)
                                {
                                    Point source = new Point(User.CurrentLocation.X + CMain.Random.Next(-7, 7), User.CurrentLocation.Y + CMain.Random.Next(-7, 7));

                                    MapControl.Effects.Add(new Effect(Libraries.Dragon, 230 + (CMain.Random.Next(5) * 10), 5, 400, source, CMain.Time + CMain.Random.Next(1000)));
                                }
                                break;
                            case Monster.CrawlerLave:
                                Effects.Add(new Effect(Libraries.Monsters[(ushort)Monster.CrawlerLave], 224 + (int)Direction * 6, 6, Frame.Count * Frame.Interval, this));
                                break;
                            case Monster.HellKeeper:
                                Effects.Add(new Effect(Libraries.Monsters[(ushort)Monster.HellKeeper], 32, 8, 8 * Frame.Interval, this));
                                break;
                            case Monster.IcePillar:
                                Effects.Add(new Effect(Libraries.Monsters[(ushort)Monster.IcePillar], 12, 6, 6 * 100, this));
                                break;
                            case Monster.TrollKing:
                                Effects.Add(new Effect(Libraries.Monsters[(ushort)Monster.TrollKing], 288, 6, 6 * Frame.Interval, this));
                                break;
                            case Monster.HellBomb1:
                                Effects.Add(new Effect(Libraries.Monsters[(ushort)Monster.HellLord], 61, 7, 7 * Frame.Interval, this));
                                break;
                            case Monster.HellBomb2:
                                Effects.Add(new Effect(Libraries.Monsters[(ushort)Monster.HellLord], 79, 9, 9 * Frame.Interval, this));
                                break;
                            case Monster.HellBomb3:
                                Effects.Add(new Effect(Libraries.Monsters[(ushort)Monster.HellLord], 97, 8, 8 * Frame.Interval, this));
                                break;
                            case Monster.WitchDoctor:
                                Effects.Add(new Effect(Libraries.Monsters[(ushort)Monster.WitchDoctor], 328, 20, 20 * Frame.Interval, this));
                                break;
                            case Monster.SeedingsGeneral:
                                MapControl.Effects.Add(new Effect(Libraries.Monsters[(ushort)Monster.SeedingsGeneral], 1064 + (int)Direction * 9, 9, 9 * Frame.Interval, front, CMain.Time));
                                break;
                            case Monster.RestlessJar:
                                Effects.Add(new Effect(Libraries.Monsters[(ushort)Monster.RestlessJar], 384, 7, 7 * Frame.Interval, this));
                                break;
                            case Monster.AssassinBird:
                                Effects.Add(new Effect(Libraries.Monsters[(ushort)Monster.AssassinBird], 392, 9, 9 * Frame.Interval, this));
                                break;
                            case Monster.Nadz:
                                Effects.Add(new Effect(Libraries.Monsters[(ushort)Monster.Nadz], 280 + (int)Direction * 5, 5, 5 * Frame.Interval, this));
                                break;
                            case Monster.AvengingWarrior:
                                Effects.Add(new Effect(Libraries.Monsters[(ushort)Monster.AvengingWarrior], 272 + (int)Direction * 5, 5, 7 * Frame.Interval, this));
                                break;
                            case Monster.FlyingStatue:
                                Effects.Add(new Effect(Libraries.Monsters[(ushort)Monster.FlyingStatue], 334, 10, 10 * 100, this));
                                break;
                            case Monster.HoodedSummoner:
                                Effects.Add(new Effect(Libraries.Monsters[(ushort)Monster.HoodedSummoner], 352, 12, 12 * Frame.Interval, this));
                                break;
                        }
                        break;
                    case MirAction.Attack2:
                        PlaySecondAttackSound();
                        CurrentActionLevel = (byte)action.Params[1];
                        switch (BaseImage)
                        {
                            case Monster.CrystalSpider:
                                Effects.Add(new Effect(Libraries.Monsters[(ushort)Monster.CrystalSpider], 272 + (int)Direction * 10, 10, Frame.Count * Frame.Interval, this));
                                break;
                            case Monster.Yimoogi:
                            case Monster.RedYimoogi:
                            case Monster.Snake10:
                            case Monster.Snake11:
                            case Monster.Snake12:
                            case Monster.Snake13:
                            case Monster.Snake14:
                            case Monster.Snake15:
                            case Monster.Snake16:
                            case Monster.Snake17:
                                Effects.Add(new Effect(Libraries.Monsters[(ushort)BaseImage], 304, 6, Frame.Count * Frame.Interval, this));
                                Effects.Add(new Effect(Libraries.Magic2, 1280, 10, Frame.Count * Frame.Interval, this));
                                break;
                            case Monster.HellCannibal:
                                Effects.Add(new Effect(Libraries.Monsters[(ushort)Monster.HellCannibal], 310 + (int)Direction * 12, 12, 12 * Frame.Interval, this));
                                break;
                            case Monster.ManectricKing:
                                Effects.Add(new Effect(Libraries.Monsters[(ushort)Monster.ManectricKing], 640 + (int)Direction * 10, 10, 10 * 100, this));
                                break;
                            case Monster.AncientBringer:
                                Effects.Add(new Effect(Libraries.Monsters[(ushort)Monster.AncientBringer], 568 + (int)Direction * 10, 10, 13 * Frame.Interval, this));
                                break;
                            case Monster.DarkBeast:
                                Effects.Add(new Effect(Libraries.Monsters[(ushort)Monster.DarkBeast], 296 + (int)Direction * 4, 4, Frame.Count * Frame.Interval, this));
                                break;
                            case Monster.LightBeast:
                                Effects.Add(new Effect(Libraries.Monsters[(ushort)Monster.LightBeast], 296 + (int)Direction * 4, 4, Frame.Count * Frame.Interval, this));
                                break;
                            case Monster.FireCat:
                                Effects.Add(new Effect(Libraries.Monsters[(ushort)Monster.FireCat], 248 + (int)Direction * 10, 10, 10 * Frame.Interval, this));
                                break;
                            case Monster.BloodBaboon:
                                Effects.Add(new Effect(Libraries.Monsters[(ushort)Monster.BloodBaboon], 312 + (int)Direction * 7, 7, 7 * Frame.Interval, this));
                                break;
                            case Monster.TwinHeadBeast:
                                Effects.Add(new Effect(Libraries.Monsters[(ushort)Monster.TwinHeadBeast], 352 + (int)Direction * 7, 7, Frame.Count * Frame.Interval, this));
                                break;
                            case Monster.Nadz:
                                Effects.Add(new Effect(Libraries.Monsters[(ushort)Monster.Nadz], 320 + (int)Direction * 7, 7, 7 * Frame.Interval, this));
                                break;
                            case Monster.DarkCaptain:
                                Effects.Add(new Effect(Libraries.Monsters[(ushort)Monster.DarkCaptain], 1214, 10, 10 * Frame.Interval, this));
                                break;
                            case Monster.DragonWarrior:
                                Effects.Add(new Effect(Libraries.Monsters[(ushort)Monster.DragonWarrior], 576, 7, Frame.Count * Frame.Interval, this));
                                break;
                            case Monster.FlyingStatue:
                                Effects.Add(new Effect(Libraries.Monsters[(ushort)Monster.FlyingStatue], 352, 10, 10 * 100, this));
                                break;
                            case Monster.HornedSorceror:
                                Effects.Add(new Effect(Libraries.Monsters[(ushort)Monster.HornedSorceror], 552 + (int)Direction * 9, 9, 900, this));
                                break;
                            case Monster.HoodedSummoner:
                                Effects.Add(new Effect(Libraries.Monsters[(ushort)Monster.HoodedSummoner], 364, 10, 10 * Frame.Interval, this));
                                break;
                        }

                        if ((ushort)BaseImage >= 10000)
                        {
                            PlayPetSound();
                        }
                        break;
                    case MirAction.Attack3:
                        PlayThirdAttackSound();
                        CurrentActionLevel = (byte)action.Params[1];
                        switch (BaseImage)
                        {
                            case Monster.Yimoogi:
                            case Monster.RedYimoogi:
                            case Monster.Snake10:
                            case Monster.Snake11:
                            case Monster.Snake12:
                            case Monster.Snake13:
                            case Monster.Snake14:
                            case Monster.Snake15:
                            case Monster.Snake16:
                            case Monster.Snake17:
                                SoundManager.PlaySound(BaseSound + 9);
                                Effects.Add(new Effect(Libraries.Magic2, 1330, 10, Frame.Count * Frame.Interval, this));
                                break;
                            case Monster.Behemoth:
                                Effects.Add(new Effect(Libraries.Monsters[(ushort)Monster.Behemoth], 697 + (int)Direction * 7, 7, Frame.Count * Frame.Interval, this));
                                break;
                            case Monster.SandSnail:
                                Effects.Add(new Effect(Libraries.Monsters[(ushort)Monster.SandSnail], 448, 9, 900, this) { Blend = true });
                                break;
                            case Monster.PeacockSpider:
                                Effects.Add(new Effect(Libraries.Monsters[(ushort)Monster.PeacockSpider], 755, 21, 21 * Frame.Interval, this));
                                break;
                            case Monster.DragonWarrior:
                                Effects.Add(new Effect(Libraries.Monsters[(ushort)Monster.DragonWarrior], 632 + (int)Direction * 4, 4, 8 * Frame.Interval, this));
                                break;
                        }
                        break;
                    case MirAction.Attack4:
                        PlayFourthAttackSound();
                        CurrentActionLevel = (byte)action.Params[1];
                        switch (BaseImage)
                        {
                            case Monster.DarkOmaKing:
                                Effects.Add(new Effect(Libraries.Monsters[(ushort)Monster.DarkOmaKing], 1702, 13, 13 * Frame.Interval, this));
                                break;
                        }
                        break;
                    case MirAction.Attack5:
                        PlayFithAttackSound();
                        CurrentActionLevel = (byte)action.Params[1];
                        break;
                    case MirAction.AttackRange1:
                        PlayRangeSound();
                        TargetID = (uint)action.Params[0];
                        CurrentActionLevel = (byte)action.Params[4];
                        switch (BaseImage)
                        {
                            case Monster.KingScorpion:
                                Effects.Add(new Effect(Libraries.Monsters[(ushort)Monster.KingScorpion], 272 + (int)Direction * 8, 8, Frame.Count * Frame.Interval, this));
                                break;
                            case Monster.DarkDevil:
                                Effects.Add(new Effect(Libraries.Monsters[(ushort)Monster.DarkDevil], 272 + (int)Direction * 8, 8, Frame.Count * Frame.Interval, this));
                                break;
                            case Monster.ShamanZombie:
                                Effects.Add(new Effect(Libraries.Monsters[(ushort)Monster.ShamanZombie], 232 + (int)Direction * 12, 6, Frame.Count * Frame.Interval, this));
                                Effects.Add(new Effect(Libraries.Monsters[(ushort)Monster.ShamanZombie], 328, 12, Frame.Count * Frame.Interval, this));
                                break;
                            case Monster.GuardianRock:
                                Effects.Add(new Effect(Libraries.Monsters[(ushort)Monster.GuardianRock], 12, 10, Frame.Count * Frame.Interval, this));
                                break;
                            case Monster.GreatFoxSpirit:
                                byte random = (byte)CMain.Random.Next(4);
                                for (int i = 0; i <= 4 + random; i++)
                                {
                                    Point source = new Point(User.CurrentLocation.X + CMain.Random.Next(-7, 7), User.CurrentLocation.Y + CMain.Random.Next(-7, 7));

                                    MapControl.Effects.Add(new Effect(Libraries.Monsters[(ushort)Monster.GreatFoxSpirit], 375 + (CMain.Random.Next(3) * 20), 20, 1400, source, CMain.Time + CMain.Random.Next(600)));
                                }
                                break;
                            case Monster.EvilMir:
                                Effects.Add(new Effect(Libraries.Dragon, 90 + (int)Direction * 10, 10, 10 * Frame.Interval, this));
                                break;
                            case Monster.DragonStatue:
                                Effects.Add(new Effect(Libraries.Dragon, 310 + ((int)Direction / 3) * 20, 10, 10 * Frame.Interval, this));
                                break;
                            case Monster.TurtleKing:
                                Effects.Add(new Effect(Libraries.Monsters[(ushort)Monster.TurtleKing], 946, 10, Frame.Count * Frame.Interval, User));
                                break;
                            case Monster.HellBolt:
                                Effects.Add(new Effect(Libraries.Monsters[(ushort)Monster.HellBolt], 304, 11, 11 * 100, this));
                                break;
                            case Monster.WitchDoctor:
                                Effects.Add(new Effect(Libraries.Monsters[(ushort)Monster.WitchDoctor], 304, 9, 9 * 100, this));
                                break;
                            case Monster.FlyingStatue:
                                Effects.Add(new Effect(Libraries.Monsters[(ushort)Monster.FlyingStatue], 304, 10, 10 * Frame.Interval, this));
                                break;
                            case Monster.ManectricKing:
                                Effects.Add(new Effect(Libraries.Monsters[(ushort)Monster.ManectricKing], 720, 12, 12 * 100, this));
                                break;
                            case Monster.IcePillar:
                                Effects.Add(new Effect(Libraries.Monsters[(ushort)Monster.IcePillar], 26, 6, 8 * 100, this) { Start = CMain.Time + 750 });
                                break;
                            case Monster.ElementGuard:
                                Effects.Add(new Effect(Libraries.Monsters[(ushort)Monster.ElementGuard], 320 + (int)Direction * 5, 5, 5 * Frame.Interval, this));
                                break;
                            case Monster.KingGuard:
                                Effects.Add(new Effect(Libraries.Monsters[(ushort)Monster.KingGuard], 737, 9, 9 * Frame.Interval, this));
                                break;
                            case Monster.CatShaman:
                                Effects.Add(new Effect(Libraries.Monsters[(ushort)Monster.CatShaman], 738, 8, Frame.Count * Frame.Interval, this));
                                break;
                            case Monster.SeedingsGeneral:
                                Effects.Add(new Effect(Libraries.Monsters[(ushort)Monster.SeedingsGeneral], 1184 + (int)Direction * 9, 9, Frame.Count * Frame.Interval, this));
                                break;
                            case Monster.RestlessJar:
                                Effects.Add(new Effect(Libraries.Monsters[(ushort)Monster.RestlessJar], 471, 5, 500, this));
                                break;
                            case Monster.AvengingSpirit:
                                Effects.Add(new Effect(Libraries.Monsters[(ushort)Monster.AvengingSpirit], 344 + (int)Direction * 3, 3, 3 * Frame.Interval, this));
                                break;
                            case Monster.ClawBeast:
                                Effects.Add(new Effect(Libraries.Monsters[(ushort)Monster.ClawBeast], 504 + (int)Direction * 8, 8, 8 * Frame.Interval, this));
                                break;
                            case Monster.DarkCaptain:
                                Effects.Add(new Effect(Libraries.Monsters[(ushort)Monster.DarkCaptain], 1200, 13, 13 * Frame.Interval, this));
                                break;
                            case Monster.FloatingRock:
                                Effects.Add(new Effect(Libraries.Monsters[(ushort)Monster.FloatingRock], 216, 10, 10 * Frame.Interval, this));
                                break;
                            case Monster.FrozenKnight:
                                Effects.Add(new Effect(Libraries.Monsters[(ushort)Monster.FrozenKnight], 384 + (int)Direction * 9, 9, 9 * Frame.Interval, this));
                                break;
                            case Monster.IcePhantom:
                                Effects.Add(new Effect(Libraries.Monsters[(ushort)Monster.IcePhantom], 672, 10, 10 * Frame.Interval, this));
                                break;
                            case Monster.BlackTortoise:
                                Effects.Add(new Effect(Libraries.Monsters[(ushort)Monster.BlackTortoise], 404 + (int)Direction * 5, 5, 5 * Frame.Interval, this));
                                break;
                            case Monster.AssassinScroll:
                                Effects.Add(new Effect(Libraries.Monsters[(ushort)Monster.AssassinScroll], 296, 3, 3 * Frame.Interval, this));
                                break;
                            case Monster.PurpleFaeFlower:
                                Effects.Add(new Effect(Libraries.Monsters[(ushort)Monster.PurpleFaeFlower], 328, 3, 3 * Frame.Interval, this));
                                break;
                            case Monster.WarriorScroll:
                                Effects.Add(new Effect(Libraries.Monsters[(ushort)Monster.WarriorScroll], 296, 8, 8 * Frame.Interval, this));
                                break;
                            case Monster.WizardScroll:
                                Effects.Add(new Effect(Libraries.Monsters[(ushort)Monster.WizardScroll], 296, 4, 4 * Frame.Interval, this));
                                break;
                        }
                        break;
                    case MirAction.AttackRange2:
                        PlaySecondRangeSound();
                        TargetID = (uint)action.Params[0];
                        CurrentActionLevel = (byte)action.Params[4];
                        switch (BaseImage)
                        {
                            case Monster.TurtleKing:
                                byte random = (byte)CMain.Random.Next(4);
                                for (int i = 0; i <= 4 + random; i++)
                                {
                                    Point source = new Point(User.CurrentLocation.X + CMain.Random.Next(-7, 7), User.CurrentLocation.Y + CMain.Random.Next(-7, 7));

                                    Effect ef = new Effect(Libraries.Monsters[(ushort)Monster.TurtleKing], CMain.Random.Next(2) == 0 ? 922 : 934, 12, 1200, source, CMain.Time + CMain.Random.Next(600));
                                    ef.Played += (o, e) => SoundManager.PlaySound(20000 + (ushort)Spell.HellFire * 10 + 1);
                                    MapControl.Effects.Add(ef);
                                }
                                break;
                            case Monster.SeedingsGeneral:
                                Effects.Add(new Effect(Libraries.Monsters[(ushort)Monster.SeedingsGeneral], 1256, 9, 900, this));
                                break;
                            case Monster.PeacockSpider: //BROKEN
                                Effects.Add(new Effect(Libraries.Monsters[(ushort)Monster.PeacockSpider], 776, 30, 30 * Frame.Interval, this));
                                break;
                            case Monster.DarkCaptain:
                                Effects.Add(new Effect(Libraries.Monsters[(ushort)Monster.DarkCaptain], 1234, 13, 13 * Frame.Interval, this));
                                break;
                            case Monster.IcePhantom:
                                Effects.Add(new Effect(Libraries.Monsters[(ushort)Monster.IcePhantom], 672, 10, 10 * Frame.Interval, this));
                                break;
                        }
                        break;
                    case MirAction.AttackRange3:
                        PlayThirdRangeSound();
                        TargetID = (uint)action.Params[0];
                        CurrentActionLevel = (byte)action.Params[4];
                        switch (BaseImage)
                        {
                            case Monster.TurtleKing:
                                Effects.Add(new Effect(Libraries.Monsters[(ushort)Monster.TurtleKing], 946, 10, Frame.Count * Frame.Interval, User));
                                break;
                        }
                        break;
                    case MirAction.Struck:
                        uint attackerID = (uint)action.Params[0];
                        StruckWeapon = -2;
                        for (int i = 0; i < MapControl.Objects.Count; i++)
                        {
                            MapObject ob = MapControl.Objects[i];
                            if (ob.ObjectID != attackerID) continue;
                            if (ob.Race != ObjectType.Player) break;
                            PlayerObject player = ((PlayerObject)ob);
                            StruckWeapon = player.Weapon;
                            if (player.Class != MirClass.刺客 || StruckWeapon == -1) break; //弓箭手?
                            StruckWeapon = 1;
                            break;
                        }
                        PlayFlinchSound();
                        PlayStruckSound();


                        // Sanjian
                        switch (BaseImage)
                        {
                            case Monster.GlacierBeast:
                                Effects.Add(new Effect(Libraries.Monsters[(ushort)Monster.GlacierBeast], 304, 6, 400, this));
                                break;
                        }



                        break;
                    case MirAction.Die:
                        switch (BaseImage)
                        {
                            case Monster.ManectricKing:
                                Effects.Add(new Effect(Libraries.Monsters[(ushort)Monster.ManectricKing], 504 + (int)Direction * 9, 9, Frame.Count * Frame.Interval, this));
                                break;
                            case Monster.DarkDevil:
                                Effects.Add(new Effect(Libraries.Monsters[(ushort)Monster.DarkDevil], 336, 6, Frame.Count * Frame.Interval, this));
                                break;
                            case Monster.ShamanZombie:
                                Effects.Add(new Effect(Libraries.Monsters[(ushort)Monster.ShamanZombie], 224, 8, Frame.Count * Frame.Interval, this));
                                break;
                            case Monster.RoninGhoul:
                                Effects.Add(new Effect(Libraries.Monsters[(ushort)Monster.RoninGhoul], 224, 10, Frame.Count * FrameInterval, this));
                                break;
                            case Monster.BoneCaptain:
                                Effects.Add(new Effect(Libraries.Monsters[(ushort)Monster.BoneCaptain], 224 + (int)Direction * 10, 10, Frame.Count * FrameInterval, this));
                                break;
                            case Monster.RightGuard:
                                Effects.Add(new Effect(Libraries.Monsters[(ushort)Monster.RightGuard], 296, 5, Frame.Count * Frame.Interval, this));
                                break;
                            case Monster.LeftGuard:
                                Effects.Add(new Effect(Libraries.Monsters[(ushort)Monster.LeftGuard], 296 + (int)Direction * 5, 5, 5 * Frame.Interval, this));
                                break;
                            case Monster.FrostTiger:
                                Effects.Add(new Effect(Libraries.Monsters[(ushort)Monster.FrostTiger], 304, 10, Frame.Count * Frame.Interval, this));
                                break;
                            case Monster.Yimoogi:
                            case Monster.RedYimoogi:
                            case Monster.Snake10:
                            case Monster.Snake11:
                            case Monster.Snake12:
                            case Monster.Snake13:
                            case Monster.Snake14:
                            case Monster.Snake15:
                            case Monster.Snake16:
                            case Monster.Snake17:
                                Effects.Add(new Effect(Libraries.Monsters[(ushort)Monster.Yimoogi], 352, 10, Frame.Count * Frame.Interval, this));
                                break;
                            case Monster.YinDevilNode:
                                Effects.Add(new Effect(Libraries.Monsters[(ushort)Monster.YinDevilNode], 52, 20, Frame.Count * Frame.Interval, this));
                                break;
                            case Monster.YangDevilNode:
                                Effects.Add(new Effect(Libraries.Monsters[(ushort)Monster.YangDevilNode], 52, 20, Frame.Count * Frame.Interval, this));
                                break;
                            case Monster.BlackFoxman:
                                Effects.Add(new Effect(Libraries.Monsters[(ushort)Monster.BlackFoxman], 224, 10, Frame.Count * Frame.Interval, this));
                                break;
                            case Monster.VampireSpider:
                                Effects.Add(new Effect(Libraries.Monsters[(ushort)Monster.VampireSpider], 296, 5, Frame.Count * Frame.Interval, this));
                                break;
                            case Monster.CharmedSnake:
                                Effects.Add(new Effect(Libraries.Monsters[(ushort)Monster.CharmedSnake], 40, 8, Frame.Count * Frame.Interval, this));
                                break;
                            case Monster.Manticore:
                                Effects.Add(new Effect(Libraries.Monsters[(ushort)Monster.Manticore], 592, 9, Frame.Count * Frame.Interval, this));
                                break;
                            case Monster.ValeBat:
                                Effects.Add(new Effect(Libraries.Monsters[(ushort)Monster.ValeBat], 224, 20, Frame.Count * Frame.Interval, this));
                                break;
                            case Monster.SpiderBat:
                                Effects.Add(new Effect(Libraries.Monsters[(ushort)Monster.SpiderBat], 224, 20, Frame.Count * Frame.Interval, this));
                                break;
                            case Monster.VenomWeaver:
                                Effects.Add(new Effect(Libraries.Monsters[(ushort)Monster.VenomWeaver], 224, 6, Frame.Count * Frame.Interval, this));
                                break;
                            case Monster.HellBolt:
                                Effects.Add(new Effect(Libraries.Monsters[(ushort)Monster.HellBolt], 325, 10, Frame.Count * Frame.Interval, this));
                                break;
                            case Monster.SabukGate:
                                Effects.Add(new Effect(Libraries.Gates[(ushort)Monster.SabukGate - 950], 24, 10, Frame.Count * Frame.Interval, this) { Light = -1 });
                                break;
                            case Monster.WingedTigerLord:
                                Effects.Add(new Effect(Libraries.Monsters[(ushort)Monster.WingedTigerLord], 650 + (int)Direction * 5, 5, Frame.Count * FrameInterval, this));
                                break;
                            case Monster.HellKnight1:
                            case Monster.HellKnight2:
                            case Monster.HellKnight3:
                            case Monster.HellKnight4:
                                Effects.Add(new Effect(Libraries.Monsters[(ushort)BaseImage], 448, 10, 600, this));
                                break;
                            case Monster.IceGuard:
                                Effects.Add(new Effect(Libraries.Monsters[(ushort)Monster.IceGuard], 256, 6, Frame.Count * Frame.Interval, this));
                                break;
                            case Monster.DeathCrawler:
                                Effects.Add(new Effect(Libraries.Monsters[(ushort)Monster.DeathCrawler], 313, 11, Frame.Count * Frame.Interval, this));
                                MapControl.Effects.Add(new Effect(Libraries.Monsters[(ushort)Monster.DeathCrawler], 304, 9, 900, CurrentLocation, CMain.Time + 900));
                                break;
                            case Monster.BurningZombie:
                                Effects.Add(new Effect(Libraries.Monsters[(ushort)Monster.BurningZombie], 373, 10, Frame.Count * Frame.Interval, this));
                                break;
                            case Monster.FrozenZombie:
                                Effects.Add(new Effect(Libraries.Monsters[(ushort)Monster.FrozenZombie], 360, 10, Frame.Count * Frame.Interval, this));
                                break;
                            case Monster.EarthGolem:
                                Effects.Add(new Effect(Libraries.Monsters[(ushort)Monster.EarthGolem], 432, 9, 9 * Frame.Interval, this));
                                break;
                            case Monster.CreeperPlant:
                                Effects.Add(new Effect(Libraries.Monsters[(ushort)Monster.CreeperPlant], 266, 6, Frame.Count * Frame.Interval, this));
                                break;
                            case Monster.SackWarrior:
                                Effects.Add(new Effect(Libraries.Monsters[(ushort)Monster.SackWarrior], 384, 9, Frame.Count * Frame.Interval, this));
                                Effects.Add(new Effect(Libraries.Monsters[(ushort)Monster.SackWarrior], 393, 10, Frame.Count * Frame.Interval, this));
                                break;
                            case Monster.FrozenSoldier:
                                Effects.Add(new Effect(Libraries.Monsters[(ushort)Monster.FrozenSoldier], 256, 10, Frame.Count * Frame.Interval, this));
                                break;
                            case Monster.FrozenGolem:
                                Effects.Add(new Effect(Libraries.Monsters[(ushort)Monster.FrozenGolem], 456, 7, Frame.Count * Frame.Interval, this));
                                Effects.Add(new Effect(Libraries.Monsters[(ushort)Monster.FrozenGolem], 463, 10, Frame.Count * Frame.Interval, this));
                                break;
                            case Monster.DragonWarrior:
                                Effects.Add(new Effect(Libraries.Monsters[(ushort)Monster.DragonWarrior], 504 + (int)Direction * 6, 6, 6 * Frame.Interval, this));
                                break;
                            case Monster.FloatingRock:
                                Effects.Add(new Effect(Libraries.Monsters[(ushort)Monster.FloatingRock], 152, 8, Frame.Count * Frame.Interval, this));
                                break;
                            case Monster.AvengingSpirit:
                                Effects.Add(new Effect(Libraries.Monsters[(ushort)Monster.AvengingSpirit], 442 + (int)Direction * 10, 10, 10 * Frame.Interval, this));
                                break;
                            case Monster.TaoistScroll:
                                Effects.Add(new Effect(Libraries.Monsters[(ushort)Monster.TaoistScroll], 282, 11, 11 * Frame.Interval, this));
                                break;
                        }
                        PlayDieSound();
                        break;
                    case MirAction.Dead:
                        GameScene.Scene.Redraw();
                        GameScene.Scene.MapControl.SortObject(this);
                        if (MouseObject == this) MouseObjectID = 0;
                        if (TargetObject == this) TargetObjectID = 0;
                        if (MagicObject == this) MagicObjectID = 0;

                        for (int i = 0; i < Effects.Count; i++)
                            Effects[i].Remove();

                        DeadTime = CMain.Time;

                        break;
                }

            }

            GameScene.Scene.MapControl.TextureValid = false;

            NextMotion = CMain.Time + FrameInterval;

            return true;
        }

        public void SetCurrentEffects()
        {
            //BindingShot
            if (BindingShotCenter && ShockTime > CMain.Time)
            {
                int effectid = TrackableEffect.GetOwnerEffectID(ObjectID);
                if (effectid >= 0)
                    TrackableEffect.effectlist[effectid].RemoveNoComplete();

                TrackableEffect NetDropped = new TrackableEffect(new Effect(Libraries.MagicC, 7, 1, 1000, this) { Repeat = true, RepeatUntil = (ShockTime - 1500) });
                NetDropped.Complete += (o1, e1) =>
                {
                    SoundManager.PlaySound(20000 + 130 * 10 + 6);//sound M130-6
                    Effects.Add(new TrackableEffect(new Effect(Libraries.MagicC, 8, 8, 700, this)));
                };
                Effects.Add(NetDropped);
            }
            else if (BindingShotCenter && ShockTime <= CMain.Time)
            {
                int effectid = TrackableEffect.GetOwnerEffectID(ObjectID);
                if (effectid >= 0)
                    TrackableEffect.effectlist[effectid].Remove();

                //SoundManager.PlaySound(20000 + 130 * 10 + 6);//sound M130-6
                //Effects.Add(new TrackableEffect(new Effect(Libraries.ArcherMagic, 8, 8, 700, this)));

                ShockTime = 0;
                BindingShotCenter = false;
            }

        }


        private void ProcessFrames()
        {
            if (Frame == null) return;

            switch (CurrentAction)
            {
                case MirAction.Walking:
                    if (!GameScene.CanMove) return;

                    GameScene.Scene.MapControl.TextureValid = false;

                    if (SkipFrames) UpdateFrame();

                    if (UpdateFrame() >= Frame.Count)
                    {
                        FrameIndex = Frame.Count - 1;
                        SetAction();
                    }
                    else
                    {
                        switch (FrameIndex)
                        {
                            case 1:
                                PlayWalkSound(true);
                                break;
                            case 4:
                                PlayWalkSound(false);
                                break;
                        }
                    }
                    break;
                case MirAction.Running:
                    if (!GameScene.CanMove) return;

                    GameScene.Scene.MapControl.TextureValid = false;

                    if (SkipFrames) UpdateFrame();

                    if (UpdateFrame() >= Frame.Count)
                    {
                        FrameIndex = Frame.Count - 1;
                        SetAction();
                    }
                    break;
                case MirAction.Pushed:
                    if (!GameScene.CanMove) return;

                    GameScene.Scene.MapControl.TextureValid = false;

                    FrameIndex -= 2;

                    if (FrameIndex < 0)
                    {
                        FrameIndex = 0;
                        SetAction();
                    }
                    break;
                case MirAction.Jump:
                    if (CMain.Time >= NextMotion)
                    {
                        GameScene.Scene.MapControl.TextureValid = false;

                        if (SkipFrames) UpdateFrame();

                        if (UpdateFrame() >= Frame.Count)
                        {
                            FrameIndex = Frame.Count - 1;
                            SetAction();
                        }
                        else
                        {
                            NextMotion += FrameInterval;
                        }
                    }
                    break;
                case MirAction.DashAttack:
                    if (CMain.Time >= NextMotion)
                    {
                        GameScene.Scene.MapControl.TextureValid = false;

                        if (SkipFrames) UpdateFrame();

                        if (UpdateFrame() >= Frame.Count)
                        {
                            FrameIndex = Frame.Count - 1;
                            SetAction();
                        }
                        else
                        {
                            switch (FrameIndex)
                            {
                                case 4:
                                    {
                                        switch (BaseImage)
                                        {
                                            case Monster.HornedSorceror:
                                                MapControl.Effects.Add(new Effect(Libraries.Monsters[(ushort)Monster.HornedSorceror], 644 + (int)Direction * 5, 5, 500, CurrentLocation));
                                                break;
                                        }
                                    }
                                    break;
                            }
                            NextMotion += FrameInterval;
                        }
                    }
                    break;
                case MirAction.Show:
                    if (CMain.Time >= NextMotion)
                    {
                        GameScene.Scene.MapControl.TextureValid = false;

                        if (SkipFrames) UpdateFrame();

                        if (UpdateFrame() >= Frame.Count)
                        {
                            switch (BaseImage)
                            {
                                case Monster.ZumaStatue:
                                case Monster.ZumaGuardian:
                                case Monster.RedThunderZuma:
                                case Monster.FrozenRedZuma:
                                case Monster.FrozenZumaStatue:
                                case Monster.FrozenZumaGuardian:
                                case Monster.ZumaTaurus:
                                case Monster.DemonGuard:
                                case Monster.EarthGolem:
                                case Monster.Turtlegrass:
                                case Monster.ManTree:
                                case Monster.AssassinScroll:
                                case Monster.WarriorScroll:
                                case Monster.TaoistScroll:
                                case Monster.WizardScroll:
                                case Monster.PurpleFaeFlower:
                                    Stoned = false;
                                    break;
                                case Monster.Shinsu:
                                    BodyLibrary = Libraries.Monsters[(ushort)Monster.Shinsu1];
                                    BaseImage = Monster.Shinsu1;
                                    BaseSound = (ushort)BaseImage * 10;
                                    Frames = BodyLibrary.Frames ?? FrameSet.DefaultMonster;
                                    break;
                            }

                            FrameIndex = Frame.Count - 1;
                            SetAction();
                        }
                        else
                        {
                            switch (FrameIndex)
                            {
                                case 1:
                                    {
                                        switch (BaseImage)
                                        {
                                            case Monster.CreeperPlant:
                                                Effects.Add(new Effect(Libraries.Monsters[(ushort)Monster.CreeperPlant], 250, 6, 6 * 100, this));
                                                break;
                                        }
                                        break;
                                    }
                            }

                            NextMotion += FrameInterval;
                        }
                    }
                    break;
                case MirAction.Hide:
                    if (CMain.Time >= NextMotion)
                    {
                        GameScene.Scene.MapControl.TextureValid = false;

                        if (SkipFrames) UpdateFrame();

                        if (UpdateFrame() >= Frame.Count)
                        {
                            switch (BaseImage)
                            {
                                case Monster.CannibalPlant:
                                case Monster.WaterDragon:
                                case Monster.CreeperPlant:
                                case Monster.EvilCentipede:
                                case Monster.DigOutZombie:
                                case Monster.Armadillo:
                                case Monster.ArmadilloElder:
                                    Remove();
                                    return;
                                case Monster.ZumaStatue:
                                case Monster.ZumaGuardian:
                                case Monster.RedThunderZuma:
                                case Monster.FrozenRedZuma:
                                case Monster.FrozenZumaStatue:
                                case Monster.FrozenZumaGuardian:
                                case Monster.ZumaTaurus:
                                case Monster.DemonGuard:
                                case Monster.EarthGolem:
                                case Monster.Turtlegrass:
                                case Monster.ManTree:
                                case Monster.AssassinScroll:
                                case Monster.WarriorScroll:
                                case Monster.TaoistScroll:
                                case Monster.WizardScroll:
                                case Monster.PurpleFaeFlower:
                                    Stoned = true;
                                    return;
                            }


                            FrameIndex = Frame.Count - 1;
                            SetAction();
                        }
                        else
                        {
                            NextMotion += FrameInterval;
                        }
                    }
                    break;
                case MirAction.Appear:
                case MirAction.Standing:
                case MirAction.Stoned:
                    if (CMain.Time >= NextMotion)
                    {
                        GameScene.Scene.MapControl.TextureValid = false;

                        if (SkipFrames) UpdateFrame();

                        if (UpdateFrame() >= Frame.Count)
                        {
                            if (CurrentAction == MirAction.Standing)
                            {
                                switch (BaseImage)
                                {
                                    case Monster.SnakeTotem://SummonSnakes Totem
                                        if (TrackableEffect.GetOwnerEffectID(this.ObjectID, "SnakeTotem") < 0)
                                            Effects.Add(new TrackableEffect(new Effect(Libraries.Monsters[(ushort)Monster.SnakeTotem], 2, 10, 1500, this) { Repeat = true }, "SnakeTotem"));
                                        break;
                                    case Monster.PalaceWall1:
                                        //Effects.Add(new Effect(Libraries.Effect, 196, 1, 1000, this) { DrawBehind = true, d });
                                        //Libraries.Effect.Draw(196, DrawLocation, Color.White, true);
                                        //Libraries.Effect.DrawBlend(196, DrawLocation, Color.White, true);
                                        break;
                                }
                            }

                            FrameIndex = Frame.Count - 1;
                            SetAction();
                        }
                        else
                        {
                            NextMotion += FrameInterval;
                        }
                    }
                    break;
                case MirAction.Attack1:
                    if (CMain.Time >= NextMotion)
                    {
                        GameScene.Scene.MapControl.TextureValid = false;

                        Point front = Functions.PointMove(CurrentLocation, Direction, 1);

                        if (SkipFrames) UpdateFrame();

                        if (UpdateFrame() >= Frame.Count)
                        {
                            FrameIndex = Frame.Count - 1;
                            if (SetAction())
                            {
                                switch (BaseImage)
                                {
                                    case Monster.EvilCentipede:
                                        Effects.Add(new Effect(Libraries.Monsters[(ushort)Monster.EvilCentipede], 42, 10, 600, this));
                                        break;
                                    case Monster.ToxicGhoul:
                                        SoundManager.PlaySound(BaseSound + 4);
                                        Effects.Add(new Effect(Libraries.Monsters[(ushort)Monster.ToxicGhoul], 224 + (int)Direction * 6, 6, 600, this));
                                        break;
                                }
                            }
                        }
                        else
                        {
                            switch (FrameIndex)
                            {                                
                                case 1:
                                    {
                                        switch (BaseImage)
                                        {
                                            case Monster.Kirin:
                                                Effects.Add(new Effect(Libraries.Monsters[(ushort)Monster.Kirin], 776 + (int)Direction * 5, 5, 500, this));
                                                break;
                                            case Monster.Bear:
                                                Effects.Add(new Effect(Libraries.Monsters[(ushort)Monster.Bear], 321 + (int)Direction * 4, 4, Frame.Count * Frame.Interval, this));
                                                break;
                                            case Monster.Jar1:
                                                Effects.Add(new Effect(Libraries.Monsters[(ushort)Monster.Jar1], 128 + (int)Direction * 3, 3, 300, this));
                                                break;
                                            case Monster.Jar2:
                                                Effects.Add(new Effect(Libraries.Monsters[(ushort)Monster.Jar2], 624 + (int)Direction * 8, 8, 800, this));
                                                break;
                                            case Monster.AntCommander:
                                                Effects.Add(new Effect(Libraries.Monsters[(ushort)Monster.AntCommander], 368 + (int)Direction * 8, 8, 8 * Frame.Interval, this));
                                                break;
                                        }
                                        break;
                                    }
                                case 2:
                                    {
                                        switch (BaseImage)
                                        {
                                            // Sanjian
                                            case Monster.FurbolgCommander:
                                                Effects.Add(new Effect(Libraries.Monsters[(ushort)Monster.FurbolgCommander], 325 + (int)Direction * 4, 4, 4 * Frame.Interval, this));
                                                break;



                                            case Monster.StainHammerCat:
                                                Effects.Add(new Effect(Libraries.Monsters[(ushort)Monster.StainHammerCat], 240 + (int)Direction * 4, 4, Frame.Count * Frame.Interval, this));
                                                break;
                                            case Monster.HornedWarrior:
                                                Effects.Add(new Effect(Libraries.Monsters[(ushort)Monster.HornedWarrior], 752 + (int)Direction * 2, 2, 2 * Frame.Interval, this));
                                                break;
                                            case Monster.FrozenFighter:
                                                Effects.Add(new Effect(Libraries.Monsters[(ushort)Monster.FrozenFighter], 336 + (int)Direction * 6, 6, 6 * Frame.Interval, this));
                                                break;
                                            case Monster.PurpleFaeFlower: // Slash effect on mob
                                                Effects.Add(new Effect(Libraries.Monsters[(ushort)Monster.PurpleFaeFlower], 436 + (int)Direction * 6, 6, 6 * Frame.Interval, this));
                                                break;
                                        }
                                    }
                                    break;
                                case 3:
                                    {
                                        PlaySwingSound();
                                        switch (BaseImage)
                                        {
                                            // Sanjian
                                            case Monster.Furball:
                                                Effects.Add(new Effect(Libraries.Monsters[(ushort)Monster.Furball], 256 + (int)Direction * 4, 4, 4 * Frame.Interval, this));
                                                break;

                                            case Monster.FurbolgWarrior:
                                                Effects.Add(new Effect(Libraries.Monsters[(ushort)Monster.FurbolgWarrior], 320 + (int)Direction * 5, 5, 5 * Frame.Interval, this));
                                                break;



                                            case Monster.RedFaeFlower:
                                                Effects.Add(new Effect(Libraries.Monsters[(ushort)Monster.RedFaeFlower], 272 + (int)Direction * 3, 3, 3 * Frame.Interval, this));
                                                break;
                                            case Monster.RightGuard:
                                                Effects.Add(new Effect(Libraries.Monsters[(ushort)Monster.RightGuard], 272 + (int)Direction * 3, 3, 3 * Frame.Interval, this));
                                                break;
                                            case Monster.LeftGuard:
                                                Effects.Add(new Effect(Libraries.Monsters[(ushort)Monster.LeftGuard], 272 + (int)Direction * 3, 3, 3 * Frame.Interval, this));
                                                break;
                                            case Monster.Shinsu1:
                                                Effects.Add(new Effect(Libraries.Monsters[(ushort)Monster.Shinsu1], 224 + (int)Direction * 6, 6, 6 * Frame.Interval, this));
                                                break;
                                            case Monster.DeathCrawler:
                                                Effects.Add(new Effect(Libraries.Monsters[(ushort)Monster.DeathCrawler], 248 + (int)Direction * 3, 3, 3 * Frame.Interval, this));
                                                break;
                                            case Monster.FrozenZombie:
                                                Effects.Add(new Effect(Libraries.Monsters[(ushort)Monster.FrozenZombie], 312 + (int)Direction * 5, 5, 2 * Frame.Interval, this));
                                                break;
                                            case Monster.TucsonWarrior:
                                                Effects.Add(new Effect(Libraries.Monsters[(ushort)Monster.TucsonWarrior], 296 + (int)Direction * 6, 6, 6 * Frame.Interval, this));
                                                break;
                                            case Monster.ArmadilloElder:
                                                Effects.Add(new Effect(Libraries.Monsters[(ushort)Monster.ArmadilloElder], 488 + (int)Direction * 3, 3, 3 * Frame.Interval, this));
                                                break;
                                            case Monster.Mandrill:
                                                Effects.Add(new Effect(Libraries.Monsters[(ushort)Monster.Mandrill], 264 + (int)Direction * 2, 2, 2 * Frame.Interval, this));
                                                break;
                                            case Monster.ArmedPlant:
                                                Effects.Add(new Effect(Libraries.Monsters[(ushort)Monster.ArmedPlant], 256 + (int)Direction * 2, 2, 2 * Frame.Interval, this));
                                                break;
                                            case Monster.AvengerPlant:
                                                Effects.Add(new Effect(Libraries.Monsters[(ushort)Monster.AvengerPlant], 224 + (int)Direction * 3, 3, 3 * Frame.Interval, this));
                                                break;
                                            case Monster.AvengingSpirit:
                                                Effects.Add(new Effect(Libraries.Monsters[(ushort)Monster.AvengingSpirit], 280 + (int)Direction * 8, 8, 8 * Frame.Interval, this));
                                                break;
                                            case Monster.SackWarrior:
                                                Effects.Add(new Effect(Libraries.Monsters[(ushort)Monster.SackWarrior], 344 + (int)Direction * 3, 3, 3 * Frame.Interval, this));
                                                break;
                                            case Monster.Bear:
                                                Effects.Add(new Effect(Libraries.Monsters[(ushort)Monster.Bear], 321 + (int)Direction * 4, 4, 4 * Frame.Interval, this));
                                                break;
                                            case Monster.FrozenKnight:
                                                Effects.Add(new Effect(Libraries.Monsters[(ushort)Monster.FrozenKnight], 360 + (int)Direction * 3, 3, 6 * Frame.Interval, this));
                                                break;
                                            case Monster.IcePhantom:
                                                Effects.Add(new Effect(Libraries.Monsters[(ushort)Monster.IcePhantom], 640 + (int)Direction * 4, 4, 4 * Frame.Interval, this));
                                                break;
                                            case Monster.DragonWarrior:
                                                Effects.Add(new Effect(Libraries.Monsters[(ushort)Monster.DragonWarrior], 552 + (int)Direction * 3, 3, 3 * Frame.Interval, this));
                                                break;
                                            case Monster.BurningZombie:
                                                Effects.Add(new Effect(Libraries.Monsters[(ushort)Monster.BurningZombie], 312 + (int)Direction * 5, 5, 2 * Frame.Interval, this));
                                                break;
                                            case Monster.DarkCaptain:
                                                Effects.Add(new Effect(Libraries.Monsters[(ushort)Monster.DarkCaptain], 1168 + (int)Direction * 3, 3, 3 * Frame.Interval, this));
                                                break;
                                            case Monster.BlackTortoise:
                                                MapControl.Effects.Add(new Effect(Libraries.Monsters[(ushort)Monster.BlackTortoise], 360, 6, 6 * Frame.Interval, front, CMain.Time));
                                                break;
                                        }
                                        break;
                                    }
                                case 4:
                                    {
                                        switch (BaseImage)
                                        {
                                            case Monster.GeneralMeowMeow:
                                                Effects.Add(new Effect(Libraries.Monsters[(ushort)Monster.GeneralMeowMeow], 416 + (int)Direction * 5, 5, 5 * Frame.Interval, this));
                                                break;
                                            case Monster.Armadillo:
                                                Effects.Add(new Effect(Libraries.Monsters[(ushort)Monster.Armadillo], 480 + (int)Direction * 2, 2, 2 * Frame.Interval, this));
                                                break;
                                            case Monster.StainHammerCat:
                                                Effects.Add(new Effect(Libraries.Monsters[(ushort)Monster.StainHammerCat], 272 + (int)Direction * 6, 6, 6 * Frame.Interval, this));
                                                break;
                                            case Monster.StrayCat:
                                                Effects.Add(new Effect(Libraries.Monsters[(ushort)Monster.StrayCat], 528 + (int)Direction * 5, 5, 5 * Frame.Interval, this));
                                                break;
                                            case Monster.OmaSlasher:
                                                Effects.Add(new Effect(Libraries.Monsters[(ushort)Monster.OmaSlasher], 304 + (int)Direction * 4, 4, 4 * Frame.Interval, this));
                                                break;
                                            case Monster.AvengerPlant:
                                                MapControl.Effects.Add(new Effect(Libraries.Monsters[(ushort)Monster.AvengerPlant], 248, 6, 600, front, CMain.Time));
                                                break;
                                            case Monster.ManTree:
                                                Effects.Add(new Effect(Libraries.Monsters[(ushort)Monster.ManTree], 472 + (int)Direction * 2, 2, 2 * Frame.Interval, this));
                                                break;
                                            case Monster.HornedMage:
                                                Effects.Add(new Effect(Libraries.Monsters[(ushort)Monster.HornedMage], 783, 9, 800, this));
                                                break;
                                            case Monster.DarkWraith:
                                                Effects.Add(new Effect(Libraries.Monsters[(ushort)Monster.DarkWraith], 720 + (int)Direction * 3, 3, 300, this));                                                
                                                Effect darkWraithEffect = new Effect(Libraries.Monsters[(ushort)Monster.DarkWraith], 744, 6, 600, front, CMain.Time);
                                                MapControl.Effects.Add(darkWraithEffect);
                                                break;
                                            case Monster.FightingCat:
                                                Effects.Add(new Effect(Libraries.Monsters[(ushort)Monster.FightingCat], 208 + (int)Direction * 3, 3, 4 * Frame.Interval, this) { Blend = true });
                                                break;
                                            case Monster.FlamingMutant:
                                                Effects.Add(new Effect(Libraries.Monsters[(ushort)Monster.FlamingMutant], 304, 6, 6 * Frame.Interval, this));
                                                break;
                                            case Monster.DarkOmaKing:
                                                Effects.Add(new Effect(Libraries.Monsters[(ushort)Monster.DarkOmaKing], 1568 + (int)Direction * 4, 4, 4 * Frame.Interval, this));
                                                break;
                                            case Monster.WaterDragon:
                                                Effect waterDragonEffect = new Effect(Libraries.Monsters[(ushort)Monster.WaterDragon], 905, 9, 900, front, CMain.Time + 300);
                                                MapControl.Effects.Add(waterDragonEffect); 
                                                break;
                                            case Monster.PurpleFaeFlower: // Animation on the target.
                                                Effect purpleFaeFlowerEffect = new Effect(Libraries.Monsters[(ushort)Monster.PurpleFaeFlower], 483, 7, 700, front, CMain.Time + 300);
                                                MapControl.Effects.Add(purpleFaeFlowerEffect);
                                                break;
                                        }
                                    }
                                    break;
                                case 5:
                                    {
                                        switch (BaseImage)
                                        {
                                            // Sanjian
                                            case Monster.FurbolgGuard:
                                                MapObject ob = MapControl.GetObject(TargetID);
                                                if (ob != null)
                                                    ob.Effects.Add(new Effect(Libraries.Monsters[(ushort)Monster.FurbolgGuard], 384, 7, 600, ob));
                                                break;



                                            case Monster.FlyingStatue:
                                                MapControl.Effects.Add(new Effect(Libraries.Monsters[(ushort)Monster.FlyingStatue], 344, 8, 800, front, CMain.Time));
                                                break;
                                            case Monster.OmaAssassin:
                                                Effects.Add(new Effect(Libraries.Monsters[(ushort)Monster.OmaAssassin], 312 + (int)Direction * 5, 5, 5 * Frame.Interval, this));
                                                break;
                                            case Monster.PlagueCrab:
                                                Effects.Add(new Effect(Libraries.Monsters[(ushort)Monster.PlagueCrab], 488 + (int)Direction * 7, 7, 7 * Frame.Interval, this));
                                                break;
                                            case Monster.ScalyBeast:
                                                Effects.Add(new Effect(Libraries.Monsters[(ushort)Monster.ScalyBeast], 344 + (int)Direction * 3, 3, 3 * Frame.Interval, this));
                                                break;
                                            case Monster.HornedSorceror:
                                                Effects.Add(new Effect(Libraries.Monsters[(ushort)Monster.HornedSorceror], 536 + (int)Direction * 2, 2, 2 * Frame.Interval, this));
                                                break;
                                            case Monster.SnowWolfKing:
                                                Effects.Add(new Effect(Libraries.Monsters[(ushort)Monster.SnowWolfKing], 456 + (int)Direction * 3, 3, 3 * Frame.Interval, this));
                                                break;
                                            case Monster.FrozenAxeman:
                                                Effects.Add(new Effect(Libraries.Monsters[(ushort)Monster.FrozenAxeman], 528 + (int)Direction * 3, 3, 300, this));
                                                break;
                                            case Monster.FrozenMagician:
                                                Effects.Add(new Effect(Libraries.Monsters[(ushort)Monster.FrozenMagician], 840 + (int)Direction * 4, 4, 400, this));
                                                Effect frozenMagicianEffect = new Effect(Libraries.Monsters[(ushort)Monster.FrozenMagician], 872, 6, 600, front, CMain.Time + 300);
                                                MapControl.Effects.Add(frozenMagicianEffect);
                                                break;
                                        }
                                        break;
                                    }
                                case 6:
                                    {
                                        switch (BaseImage)
                                        {
                                            case Monster.FrozenMiner:
                                                Effects.Add(new Effect(Libraries.Monsters[(ushort)Monster.FrozenMiner], 432 + (int)Direction * 3, 3, 300, this));
                                                Point source = Functions.PointMove(CurrentLocation, Direction, 1);
                                                Effect ef = new Effect(Libraries.Monsters[(ushort)Monster.FrozenMiner], 456, 6, 600, source, CMain.Time + 300);
                                                MapControl.Effects.Add(ef);
                                                break;
                                            case Monster.SnowYeti:
                                                Effects.Add(new Effect(Libraries.Monsters[(ushort)Monster.SnowYeti], 504 + (int)Direction * 4, 4, 400, this));
                                                break;
                                            case Monster.IceCrystalSoldier:
                                                source = Functions.PointMove(CurrentLocation, Direction, 1);
                                                ef = new Effect(Libraries.Monsters[(ushort)Monster.IceCrystalSoldier], 464, 6, 600, source, CMain.Time);
                                                MapControl.Effects.Add(ef);
                                                break;
                                        }
                                        break;
                                    }
                                case 7:
                                    {
                                        switch (BaseImage)
                                        {
                                            case Monster.AxePlant:
                                                Effects.Add(new Effect(Libraries.Monsters[(ushort)Monster.AxePlant], 256 + (int)Direction * 10, 10, 10 * Frame.Interval, this));
                                                break;
                                            case Monster.TreeQueen://Fire Bombardment
                                                Effects.Add(new Effect(Libraries.Monsters[(ushort)Monster.TreeQueen], 35, 13, 1300, this) { Blend = true });
                                                break;
                                            case Monster.HornedCommander:
                                                Effects.Add(new Effect(Libraries.Monsters[(ushort)Monster.HornedCommander], 784 + (int)Direction * 3, 3, 300, this) { Blend = true });
                                                break;
                                        }
                                        break;
                                    }
                                case 8:
                                    {
                                        MapObject ob = MapControl.GetObject(TargetID);

                                        switch (BaseImage)
                                        {
                                            case Monster.FurbolgCommander:
                                                if (ob != null)
                                                    ob.Effects.Add(new Effect(Libraries.Monsters[(ushort)Monster.FurbolgCommander], 320, 5, 500, ob));
                                                break;
                                               case Monster.Manticore:
                                                Effects.Add(new Effect(Libraries.Monsters[(ushort)Monster.Manticore], 505 + (int)Direction * 3, 3, 3 * Frame.Interval, this));
                                                break;
                                        }
                                        break;
                                    }
                                case 9:
                                    {
                                        switch (BaseImage)
                                        {
                                            case Monster.SeedingsGeneral:
                                                Effects.Add(new Effect(Libraries.Monsters[(ushort)Monster.SeedingsGeneral], 736 + (int)Direction * 9, 9, 900, this));
                                                break;
                                        }
                                        break;
                                    }
                            }
                            NextMotion += FrameInterval;
                        }
                    }
                    break;
                case MirAction.SitDown:
                    if (CMain.Time >= NextMotion)
                    {
                        GameScene.Scene.MapControl.TextureValid = false;

                        if (SkipFrames) UpdateFrame();

                        if (UpdateFrame() >= Frame.Count)
                        {
                            FrameIndex = Frame.Count - 1;
                            SetAction();
                        }
                        else
                        {
                            NextMotion += FrameInterval;
                        }
                    }
                    break;
                case MirAction.Attack2:
                    if (CMain.Time >= NextMotion)
                    {
                        GameScene.Scene.MapControl.TextureValid = false;

                        if (SkipFrames) UpdateFrame();

                        MapObject ob = null;

                        Point front = Functions.PointMove(CurrentLocation, Direction, 1);

                        if (UpdateFrame() >= Frame.Count)
                        {
                            FrameIndex = Frame.Count - 1;
                            SetAction();
                        }
                        else
                        {
                            switch (FrameIndex)
                            {
                                case 1:
                                    {                                        
                                        switch (BaseImage)
                                        {
                                            case Monster.BabySnowMan:
                                                if (FrameIndex == 1)
                                                {
                                                    if (TrackableEffect.GetOwnerEffectID(this.ObjectID, "SnowmanSnow") < 0)
                                                        Effects.Add(new TrackableEffect(new Effect(Libraries.Pets[((ushort)BaseImage) - 10000], 208, 11, 1500, this), "SnowmanSnow"));
                                                }
                                                break;
                                            case Monster.CannibalTentacles:
                                                Effects.Add(new Effect(Libraries.Monsters[(ushort)Monster.CannibalTentacles], 400 + (int)Direction * 9, 9, 9 * Frame.Interval, this));
                                                break;
                                            case Monster.DarkOmaKing:
                                                SoundManager.PlaySound(BaseSound + 6, false, 800);
                                                SoundManager.PlaySound(BaseSound + 6, false, 1500);
                                                Effects.Add(new Effect(Libraries.Monsters[(ushort)Monster.DarkOmaKing], 1600, 30, 30 * Frame.Interval, this));
                                                break;
                                        }
                                    }
                                    break;
                                case 2:
                                    {
                                        switch (BaseImage)
                                        {
                                            // Sanjian
                                            case Monster.FurbolgWarrior:
                                                Effects.Add(new Effect(Libraries.Monsters[(ushort)Monster.FurbolgWarrior], 360 + (int)Direction * 5, 5, 5 * Frame.Interval, this));
                                                break;


                                            case Monster.BlackHammerCat:
                                                Effects.Add(new Effect(Libraries.Monsters[(ushort)Monster.BlackHammerCat], 648 + (int)Direction * 11, 11, 11 * Frame.Interval, this));
                                                break;
                                            case Monster.HornedCommander:
                                                Effects.Add(new Effect(Libraries.Monsters[(ushort)Monster.HornedCommander], 1142 + (int)Direction * 2, 2, 2 * Frame.Interval, this));
                                                break;
                                            case Monster.SnowWolfKing:
                                                Effects.Add(new Effect(Libraries.Monsters[(ushort)Monster.SnowWolfKing], 480, 9, 9 * Frame.Interval, this));
                                                break;
                                        }
                                    }
                                    break;
                                case 3:
                                    {
                                        switch (BaseImage)
                                        {
                                            // Sanjian
                                            case Monster.GlacierBeast:
                                                Effects.Add(new Effect(Libraries.Monsters[(ushort)Monster.GlacierBeast], 310 + (int)Direction * 4, 4, 4 * Frame.Interval, this));
                                                break;



                                            case Monster.KingGuard:
                                                Effects.Add(new Effect(Libraries.Monsters[(ushort)Monster.KingGuard], 773, 10, 1000, this) { Blend = true });
                                                break;
                                            case Monster.Behemoth:
                                                Effects.Add(new Effect(Libraries.Monsters[(ushort)Monster.Behemoth], 768, 10, Frame.Count * Frame.Interval, this));
                                                break;
                                            case Monster.FlameQueen:
                                                Effects.Add(new Effect(Libraries.Monsters[(ushort)Monster.FlameQueen], 720, 9, Frame.Count * Frame.Interval, this));
                                                break;
                                            case Monster.DemonGuard:
                                                Effects.Add(new Effect(Libraries.Monsters[(ushort)Monster.DemonGuard], 288 + (int)Direction * 2, 2, 2 * Frame.Interval, this));
                                                break;
                                            case Monster.TucsonMage:
                                                Effects.Add(new Effect(Libraries.Monsters[(ushort)Monster.TucsonMage], 296 + (int)Direction * 10, 10, 10 * Frame.Interval, this));
                                                break;
                                            case Monster.Armadillo:
                                                Effects.Add(new Effect(Libraries.Monsters[(ushort)Monster.Armadillo], 496 + (int)Direction * 12, 12, 6 * Frame.Interval, this));
                                                break;
                                            case Monster.CatWidow:
                                                Effects.Add(new Effect(Libraries.Monsters[(ushort)Monster.CatWidow], 256 + (int)Direction * 3, 3, 3 * Frame.Interval, this));
                                                break;
                                            case Monster.SnowWolf:                                                
                                                Effects.Add(new Effect(Libraries.Monsters[(ushort)Monster.SnowWolf], 328, 9, Frame.Count * Frame.Interval, this));
                                                break;
                                            case Monster.BlackTortoise:                                                
                                                Effects.Add(new Effect(Libraries.Monsters[(ushort)Monster.BlackTortoise], 366 + (int)Direction * 4, 4, 4 * Frame.Interval, this));
                                                MapControl.Effects.Add(new Effect(Libraries.Monsters[(ushort)Monster.BlackTortoise], 398, 7, 7 * Frame.Interval, front, CMain.Time));
                                                break;
                                            case Monster.TreeQueen:
                                                Effects.Add(new Effect(Libraries.Monsters[(ushort)Monster.TreeQueen], 66, 16, 16 * Frame.Interval, this));
                                                break;
                                            case Monster.RhinoWarrior:
                                                MapControl.Effects.Add(new Effect(Libraries.Monsters[(ushort)Monster.RhinoWarrior], 376, 8, 800, front, CMain.Time));
                                                break;
                                            case Monster.FrozenFighter:
                                                Effects.Add(new Effect(Libraries.Monsters[(ushort)Monster.FrozenFighter], 384 + (int)Direction * 5, 5, 5 * Frame.Interval, this));
                                                break;
                                        }
                                    }
                                    break;
                                case 4:
                                    {
                                        switch (BaseImage)
                                        {
                                            // Sanjian
                                            case Monster.GlacierSnail:
                                                Effects.Add(new Effect(Libraries.Monsters[(ushort)Monster.GlacierSnail], 344 + (int)Direction * 5, 5, 5 * Frame.Interval, this));
                                                break;






                                            case Monster.DemonWolf:
                                                Effects.Add(new Effect(Libraries.Monsters[(ushort)Monster.DemonWolf], 312 + (int)Direction * 3, 3, 300, this));
                                                break;
                                            case Monster.TucsonWarrior:
                                                Effects.Add(new Effect(Libraries.Monsters[(ushort)Monster.TucsonWarrior], 344 + (int)Direction * 9, 9, 9 * Frame.Interval, this));
                                                break;
                                            case Monster.PeacockSpider:
                                                Effects.Add(new Effect(Libraries.Monsters[(ushort)Monster.PeacockSpider], 592 + (int)Direction * 9, 9, 9 * Frame.Interval, this));
                                                break;
                                            case Monster.SackWarrior:                                                
                                                Effects.Add(new Effect(Libraries.Monsters[(ushort)Monster.SackWarrior], 368 + (int)Direction * 2, 2, 2 * Frame.Interval, this));
                                                break;
                                            case Monster.ManTree:
                                                Effects.Add(new Effect(Libraries.Monsters[(ushort)Monster.ManTree], 488 + (int)Direction * 2, 2, 2 * Frame.Interval, this));
                                                break;
                                            case Monster.DarkWraith:
                                                Effects.Add(new Effect(Libraries.Monsters[(ushort)Monster.DarkWraith], 750 + (int)Direction * 5, 5, 500, this));                                                
                                                Effect ef = new Effect(Libraries.Monsters[(ushort)Monster.DarkWraith], 790, 6, 600, front, CMain.Time);
                                                MapControl.Effects.Add(ef);
                                                break;
                                            case Monster.HornedWarrior:
                                                Effects.Add(new Effect(Libraries.Monsters[(ushort)Monster.HornedWarrior], 832 + (int)Direction * 10, 10, 10 * Frame.Interval, this));
                                                break;
                                            case Monster.Turtlegrass:
                                                Effects.Add(new Effect(Libraries.Monsters[(ushort)Monster.Turtlegrass], 360 + (int)Direction * 6, 6, 6 * Frame.Interval, this));
                                                break;
                                            case Monster.AntCommander:
                                                Effect ef1 = new Effect(Libraries.Monsters[(ushort)Monster.AntCommander], 484, 6, 600, front, CMain.Time);
                                                MapControl.Effects.Add(ef1);
                                                break;
                                        }
                                        break;
                                    }
                                    break;
                                case 5:
                                    {   
                                        switch (BaseImage)
                                        {
                                            case Monster.GeneralMeowMeow:
                                                Effects.Add(new Effect(Libraries.Monsters[(ushort)Monster.GeneralMeowMeow], 456 + (int)Direction * 7, 7, 7 * Frame.Interval, this) { Blend = true });
                                                break;
                                            case Monster.TucsonGeneral:
                                                Effects.Add(new Effect(Libraries.Monsters[(ushort)Monster.TucsonGeneral], 544, 8, 8 * Frame.Interval, this));
                                                break;
                                            case Monster.FrozenMiner:
                                                Effects.Add(new Effect(Libraries.Monsters[(ushort)Monster.FrozenMiner], 462 + (int)Direction * 5, 5, 500, this));
                                                break;
                                            case Monster.IceCrystalSoldier:                                                
                                                Effect ef = new Effect(Libraries.Monsters[(ushort)Monster.IceCrystalSoldier], 470, 6, 600, front, CMain.Time);
                                                MapControl.Effects.Add(ef);
                                                break;
                                            case Monster.Bear:
                                                Effect bleedEffect = new Effect(Libraries.Monsters[(ushort)Monster.Bear], 312, 9, 900, front, CMain.Time);
                                                MapControl.Effects.Add(bleedEffect);
                                                break;
                                            case Monster.FlyingStatue:
                                                Effect flyingStatueEffect1 = new Effect(Libraries.Monsters[(ushort)Monster.FlyingStatue], 362, 8, 800, front, CMain.Time);
                                                MapControl.Effects.Add(flyingStatueEffect1);
                                                break;
                                            case Monster.HornedCommander:
                                                Effects.Add(new Effect(Libraries.Monsters[(ushort)Monster.HornedCommander], 784 + (int)Direction * 3, 3, 300, this) { Blend = true });
                                                break;
                                        }
                                        break;

                                    }
                                    break;
                                case 6:
                                    {
                                        switch (BaseImage)
                                        {
                                            case Monster.SeedingsGeneral:
                                                Effects.Add(new Effect(Libraries.Monsters[(ushort)Monster.SeedingsGeneral], 1136 + (int)Direction * 6, 6, 600, this));
                                                break;
                                            case Monster.OmaBlest:
                                                Effects.Add(new Effect(Libraries.Monsters[(ushort)Monster.OmaBlest], 392 + (int)Direction * 5, 5, 500, this));
                                                break;
                                            case Monster.WereTiger:
                                                Effects.Add(new Effect(Libraries.Monsters[(ushort)Monster.WereTiger], 344 + (int)Direction * 6, 6, 600, this));
                                                break;
                                            case Monster.Kirin:
                                                Point source2 = Functions.PointMove(CurrentLocation, Direction, 2);
                                                Effect ef = new Effect(Libraries.Monsters[(ushort)Monster.Kirin], 816, 8, 800, source2, CMain.Time);
                                                MapControl.Effects.Add(ef);
                                                break;
                                            case Monster.FrozenAxeman:
                                                Effects.Add(new Effect(Libraries.Monsters[(ushort)Monster.FrozenAxeman], 558 + (int)Direction * 3, 3, 300, this));
                                                break;
                                            case Monster.SnowYeti:
                                                Effects.Add(new Effect(Libraries.Monsters[(ushort)Monster.SnowYeti], 536 + (int)Direction * 3, 3, 300, this));
                                                break;
                                        }
                                    }
                                    break;
                                case 7:
                                    {   
                                        switch (BaseImage)
                                        {
                                            case Monster.ElephantMan:
                                                Effects.Add(new Effect(Libraries.Monsters[(ushort)Monster.ElephantMan], 368, 9, 900, this) { Blend = true });
                                                break;
                                            case Monster.ScalyBeast:
                                                Effects.Add(new Effect(Libraries.Monsters[(ushort)Monster.ScalyBeast], 368 + (int)Direction * 3, 3, 3 * Frame.Interval, this) { Blend = false });
                                                break;
                                        }
                                    }
                                    break;
                                case 8:
                                    {
                                        switch (BaseImage)
                                        {
                                            case Monster.StrayCat:
                                                Effects.Add(new Effect(Libraries.Monsters[(ushort)Monster.StrayCat], 584 + (int)Direction * 6, 6, 6 * Frame.Interval, this));
                                                break;
                                        }
                                    }
                                    break;
                                case 9:
                                    {
                                        switch (BaseImage)
                                        {
                                            case Monster.ScalyBeast:
                                                Effects.Add(new Effect(Libraries.Monsters[(ushort)Monster.ScalyBeast], 392, 3, 300, this) { Blend = true });
                                                break;
                                        }
                                    }
                                    break;
                                case 10:
                                    {
                                        switch (BaseImage)
                                        {
                                            case Monster.StoningStatue:
                                                Effects.Add(new Effect(Libraries.Monsters[(ushort)Monster.StoningStatue], 642, 15, 15 * 100, this));
                                                SoundManager.PlaySound(BaseSound + 7);
                                                break;
                                        }
                                    }
                                    break;
                                case 11:
                                    {
                                        switch (BaseImage)
                                        {
                                            case Monster.BlackHammerCat:
                                                Effects.Add(new Effect(Libraries.Monsters[(ushort)Monster.BlackHammerCat], 736 + (int)Direction * 8, 8, 800, this));
                                                break;
                                        }
                                    }
                                    break;
                                case 19:
                                    {
                                        switch (BaseImage)
                                        {
                                            case Monster.StoningStatue:
                                                Effects.Add(new Effect(Libraries.Monsters[(ushort)Monster.StoningStatue], 624, 8, 8 * 100, this));
                                                break;
                                        }
                                    }
                                    break;
                            }
                            if (FrameIndex == 3) PlaySwingSound();
                            NextMotion += FrameInterval;
                        }
                    }
                    break;
                case MirAction.Attack3:
                    if (CMain.Time >= NextMotion)
                    {
                        GameScene.Scene.MapControl.TextureValid = false;

                        if (SkipFrames) UpdateFrame();

                        if (UpdateFrame() >= Frame.Count)
                        {
                            FrameIndex = Frame.Count - 1;
                            SetAction();
                        }
                        else
                        {
                            switch (FrameIndex)
                            {
                                case 1:
                                    switch (BaseImage)
                                    {
                                        case Monster.OlympicFlame:
                                            if (TrackableEffect.GetOwnerEffectID(this.ObjectID, "CreatureFlame") < 0)
                                                Effects.Add(new TrackableEffect(new Effect(Libraries.Pets[((ushort)BaseImage) - 10000], 280, 4, 800, this), "CreatureFlame"));
                                            break;
                                        case Monster.GasToad:
                                            Effects.Add(new Effect(Libraries.Monsters[(ushort)Monster.GasToad], 440, 9, 9 * Frame.Interval, this));
                                            break;
                                        case Monster.HornedCommander:
                                            {
                                                //Spin
                                                int loops = CurrentActionLevel;
                                                int duration = 7 * FrameInterval;
                                                int totalDuration = loops * duration;

                                                if (FrameLoop == null)
                                                {
                                                    for (int i = 0; i < loops; i++)
                                                    {
                                                        SoundManager.PlaySound(8451, false, 0 + (i * duration));
                                                    }

                                                    Effects.Add(new Effect(Libraries.Monsters[(ushort)Monster.HornedCommander], 808 + (int)Direction * 7, 7, duration, this) { Repeat = true, RepeatUntil = CMain.Time + totalDuration });
                                                }

                                                LoopFrame(FrameIndex, 3, FrameInterval, totalDuration);

                                            }
                                            break;
                                        case Monster.SnowWolfKing:
                                            Effects.Add(new Effect(Libraries.Monsters[(ushort)Monster.SnowWolfKing], 489 + (int)Direction * 9, 9, 9 * Frame.Interval, this));
                                            break;
                                    }
                                    break;
                                case 2:
                                    break;
                                case 3:
                                    {
                                        switch (BaseImage)
                                        {
                                            case Monster.WingedTigerLord:
                                                Effects.Add(new Effect(Libraries.Monsters[(ushort)Monster.WingedTigerLord], 632, 8, 600, this, 0, true));
                                                break;
                                            case Monster.DarkWraith:
                                                Effects.Add(new Effect(Libraries.Monsters[(ushort)Monster.DarkWraith], 796 + (int)Direction * 5, 5, 500, this));
                                                break;
                                            case Monster.HornedSorceror:
                                                {
                                                    int loops = CurrentActionLevel;
                                                    int duration = 5 * FrameInterval;
                                                    int totalDuration = loops * duration;

                                                    if (FrameLoop == null)
                                                    {
                                                        for (int i = 0; i < loops; i++)
                                                        {
                                                            SoundManager.PlaySound(BaseSound + 7, false, 0 + (i * duration));
                                                        }
                                                        Effects.Add(new Effect(Libraries.Monsters[(ushort)Monster.HornedSorceror], 971 + (int)Direction * 5, 5, duration, this) { Repeat = true, RepeatUntil = CMain.Time + totalDuration });
                                                    }

                                                    LoopFrame(FrameIndex, 1, FrameInterval, totalDuration);
                                                }
                                                break;
                                        }
                                    }
                                    break;
                                case 4:
                                    switch (BaseImage)
                                    {
                                        case Monster.OlympicFlame:
                                            if (TrackableEffect.GetOwnerEffectID(this.ObjectID, "CreatureSmoke") < 0)
                                                Effects.Add(new TrackableEffect(new Effect(Libraries.Pets[((ushort)BaseImage) - 10000], 256, 3, 1000, this), "CreatureSmoke"));
                                            break;
                                        case Monster.Kirin:
                                            Effects.Add(new Effect(Libraries.Monsters[(ushort)Monster.Kirin], 824 + (int)Direction * 7, 7, 700, this));
                                            break;
                                        case Monster.FrozenAxeman:
                                            Effects.Add(new Effect(Libraries.Monsters[(ushort)Monster.FrozenAxeman], 588 + (int)Direction * 3, 3, 300, this));
                                            break;
                                        case Monster.ManTree:
                                            Effects.Add(new Effect(Libraries.Monsters[(ushort)Monster.ManTree], 504 + (int)Direction * 2, 2, 200, this));
                                            break;
                                        case Monster.DragonWarrior:
                                            Point source = Functions.PointMove(CurrentLocation, Direction, 1);
                                            Effect effect = new Effect(Libraries.Monsters[(ushort)Monster.DragonWarrior], 664, 6, 600, source, CMain.Time + 300);
                                            MapControl.Effects.Add(effect); 
                                            break;
                                    }
                                    break;
                                case 5:
                                    switch (BaseImage)
                                    {
                                        case Monster.WhiteMammoth:
                                            Effects.Add(new Effect(Libraries.Monsters[(ushort)Monster.WhiteMammoth], 376, 5, Frame.Count * Frame.Interval, this));
                                            break;
                                        case Monster.ManTree:
                                            Point source = Functions.PointMove(CurrentLocation, Direction, 1);
                                            Effect ef = new Effect(Libraries.Monsters[(ushort)Monster.ManTree], 520, 8, 800, source, CMain.Time, drawBehind: true);
                                            MapControl.Effects.Add(ef);
                                            break;
                                        case Monster.HornedSorceror:
                                            SoundManager.PlaySound(BaseSound + 5);
                                            Effects.Add(new Effect(Libraries.Monsters[(ushort)Monster.HornedSorceror], 624, 10, 10 * Frame.Interval, this));
                                            break;
                                        case Monster.HornedCommander:
                                            SoundManager.PlaySound(8452, false);
                                            Effects.Add(new Effect(Libraries.Monsters[(ushort)Monster.HornedCommander], 864, 8, 8 * Frame.Interval, this));
                                            break;
                                    }
                                    break;
                                case 6:
                                    switch (BaseImage)
                                    {
                                        case Monster.RestlessJar:
                                            Effects.Add(new Effect(Libraries.Monsters[(ushort)Monster.RestlessJar], 512, 7, 700, this));
                                            break;
                                    }
                                    break;
                                case 8:
                                    switch (BaseImage)
                                    {
                                        case Monster.Manticore:
                                            Effects.Add(new Effect(Libraries.Monsters[(ushort)Monster.Manticore], 536 + (int)Direction * 7, 7, 7 * Frame.Interval, this));
                                            break;
                                    }
                                    break;
                                case 10:
                                    switch (BaseImage)
                                    {
                                        case Monster.StrayCat:
                                            Effects.Add(new Effect(Libraries.Monsters[(ushort)Monster.StrayCat], 728 + (int)Direction * 10, 10, 1000, this));
                                            break;
                                    }
                                    break;
                            }

                            NextMotion += FrameInterval;
                        }
                    }
                    break;
                case MirAction.Attack4:
                    if (CMain.Time >= NextMotion)
                    {
                        GameScene.Scene.MapControl.TextureValid = false;

                        if (SkipFrames) UpdateFrame();

                        if (UpdateFrame() >= Frame.Count)
                        {
                            
                            FrameIndex = Frame.Count - 1;
                            SetAction();
                        }
                        else
                        {
                            switch (FrameIndex)
                            {
                                case 1:
                                    switch (BaseImage)
                                    {
                                        case Monster.HornedCommander:
                                            {
                                                //Rockfall
                                                int loops = CurrentActionLevel;
                                                int duration = 5 * FrameInterval;
                                                int totalDuration = loops * duration;

                                                if (FrameLoop == null)
                                                {
                                                    for (int i = 0; i < loops; i++)
                                                    {
                                                        SoundManager.PlaySound(8453, false, 0 + (i * duration));
                                                    }

                                                    Effects.Add(new Effect(Libraries.Monsters[(ushort)Monster.HornedCommander], 1026 + (int)Direction * 5, 5, duration, this) { Repeat = true, RepeatUntil = CMain.Time + totalDuration });
                                                }

                                                LoopFrame(FrameIndex, 3, FrameInterval, totalDuration);
                                            }
                                            break;
                                    }
                                    break;
                                case 3:
                                    switch (BaseImage)
                                    {
                                        case Monster.SnowWolfKing:
                                            Effects.Add(new Effect(Libraries.Monsters[(ushort)Monster.SnowWolfKing], 581 + (int)Direction * 3, 3, 3 * Frame.Interval, this));
                                            break;
                                    }
                                    break;
                                case 5:
                                    switch (BaseImage)
                                    {
                                        case Monster.HornedCommander:
                                            SoundManager.PlaySound(8454);
                                            Effects.Add(new Effect(Libraries.Monsters[(ushort)Monster.HornedCommander], 1078 + (int)Direction * 8, 8, 8 * Frame.Interval, this));
                                            break;
                                    }                                      
                                    break;
                            }

                            NextMotion += FrameInterval;
                        }
                    }
                    break;
                case MirAction.Attack5:
                    if (CMain.Time >= NextMotion)
                    {
                        GameScene.Scene.MapControl.TextureValid = false;

                        if (SkipFrames) UpdateFrame();

                        if (UpdateFrame() >= Frame.Count)
                        {
                            FrameIndex = Frame.Count - 1;
                            SetAction();
                        }
                        else
                        {
                            switch (FrameIndex)
                            {
                                case 4:
                                    {
                                        switch (BaseImage)
                                        {
                                            case Monster.HornedCommander:
                                                LoopFrame(FrameIndex, 2, FrameInterval, CurrentActionLevel * 1000);
                                                break;
                                        }
                                        break;
                                    }
                                    break;
                            }

                            NextMotion += FrameInterval;
                        }
                    }
                    break;
                case MirAction.AttackRange1:
                    if (CMain.Time >= NextMotion)
                    {
                        GameScene.Scene.MapControl.TextureValid = false;

                        if (SkipFrames) UpdateFrame();

                        if (UpdateFrame() >= Frame.Count)
                        {
                            switch (BaseImage)
                            {
                                case Monster.DragonStatue:
                                    MapObject ob = MapControl.GetObject(TargetID);
                                    if (ob != null)
                                    {
                                        ob.Effects.Add(new Effect(Libraries.Dragon, 350, 35, 1200, ob));
                                        SoundManager.PlaySound(BaseSound + 6);
                                    }
                                    break;



                            }
                            FrameIndex = Frame.Count - 1;
                            SetAction();
                        }
                        else
                        {
                            if (FrameIndex == 2) PlaySwingSound();
                            MapObject ob = null;
                            Missile missile;
                            switch (FrameIndex)
                            {
                                case 1:
                                    {
                                        switch (BaseImage)
                                        {
                                            case Monster.GuardianRock:
                                                ob = MapControl.GetObject(TargetID);
                                                if (ob != null)
                                                {
                                                    ob.Effects.Add(new Effect(Libraries.Magic2, 1410, 10, 400, ob));
                                                    SoundManager.PlaySound(BaseSound + 6);
                                                }
                                                break;
                                            case Monster.OmaWitchDoctor:
                                                Effects.Add(new Effect(Libraries.Monsters[(ushort)Monster.OmaWitchDoctor], 792 + (int)Direction * 7, 7, 7 * Frame.Interval, this));
                                                break;
                                            case Monster.FloatingRock:
                                                Effects.Add(new Effect(Libraries.Monsters[(ushort)Monster.FloatingRock], 159 + (int)Direction * 7, 7, 7 * Frame.Interval, this));
                                                break;
                                            case Monster.KingHydrax:
                                                Effects.Add(new Effect(Libraries.Monsters[(ushort)Monster.KingHydrax], 368 + (int)Direction * 6, 6, 6 * Frame.Interval, this));
                                                break;
                                            case Monster.BlueSoul:
                                                ob = MapControl.GetObject(TargetID);
                                                if (ob != null)
                                                {
                                                    ob.Effects.Add(new Effect(Libraries.Monsters[(ushort)Monster.BlueSoul], 240, 10, 700, ob));
                                                    SoundManager.PlaySound(BaseSound + 7);
                                                }
                                                break;
                                            case Monster.HornedCommander:
                                                Effects.Add(new Effect(Libraries.Monsters[(ushort)Monster.HornedCommander], 872 + (int)Direction * 7, 7, 7 * Frame.Interval, this));
                                                break;
                                        }
                                        break;
                                    }
                                case 2:
                                    {
                                        switch (BaseImage)
                                        {
                                            case Monster.LeftGuard:
                                                Effects.Add(new Effect(Libraries.Monsters[(ushort)Monster.LeftGuard], 336 + (int)Direction * 3, 3, 3 * Frame.Interval, this));
                                                break;
                                            case Monster.DreamDevourer:
                                                ob = MapControl.GetObject(TargetID);
                                                if (ob != null)
                                                {
                                                    ob.Effects.Add(new Effect(Libraries.Monsters[(ushort)Monster.DreamDevourer], 264, 7, 7 * Frame.Interval, ob));
                                                }
                                                break;
                                            case Monster.DarkDevourer:
                                                ob = MapControl.GetObject(TargetID);
                                                if (ob != null)
                                                {
                                                    ob.Effects.Add(new Effect(Libraries.Monsters[(ushort)Monster.DarkDevourer], 480, 7, 7 * Frame.Interval, ob));
                                                }
                                                break;
                                            case Monster.ManectricClaw:
                                                Effects.Add(new Effect(Libraries.Monsters[(ushort)Monster.ManectricClaw], 304 + (int)Direction * 10, 10, 10 * Frame.Interval, this));
                                                break;
                                            case Monster.FlameSpear:
                                                Effects.Add(new Effect(Libraries.Monsters[(ushort)Monster.FlameSpear], 544 + (int)Direction * 10, 10, 10 * 100, this));
                                                break;
                                            case Monster.FrozenMagician:
                                                Effects.Add(new Effect(Libraries.Monsters[(ushort)Monster.FrozenMagician], 512 + (int)Direction * 6, 6, 6 * Frame.Interval, this));
                                                break;
                                            case Monster.PurpleFaeFlower:
                                                missile = CreateProjectile(331, Libraries.Monsters[(ushort)Monster.PurpleFaeFlower], true, 6, 60, 0);

                                                if (missile.Target != null)
                                                {
                                                    missile.Complete += (o, e) =>
                                                    {
                                                        if (missile.Target.CurrentAction == MirAction.Dead) return;
                                                        missile.Target.Effects.Add(new Effect(Libraries.Monsters[(ushort)Monster.PurpleFaeFlower], 427, 9, 900, missile.Target) { Blend = true });
                                                    };
                                                }
                                                break;
                                        }
                                        break;
                                    }
                                case 3:
                                    {
                                        switch (BaseImage)
                                        {
                                            case Monster.Jar2:
                                                missile = CreateProjectile(688, Libraries.Monsters[(ushort)Monster.Jar2], true, 4, 50, 0);

                                                if (missile.Target != null)
                                                {
                                                    missile.Complete += (o, e) =>
                                                    {
                                                        if (missile.Target.CurrentAction == MirAction.Dead) return;
                                                        missile.Target.Effects.Add(new Effect(Libraries.Monsters[(ushort)Monster.Jar2], 752, 8, 500, missile.Target) { Blend = true });
                                                    };
                                                }
                                                break;
                                            case Monster.HardenRhino:
                                                Effects.Add(new Effect(Libraries.Monsters[(ushort)Monster.HardenRhino], 392, 5, 5 * Frame.Interval, this));
                                                break;
                                            case Monster.HornedArcher:
                                                Effects.Add(new Effect(Libraries.Monsters[(ushort)Monster.HornedArcher], 336 + (int)Direction * 3, 3, 3 * Frame.Interval, this, drawBehind: true));
                                                break;
                                            case Monster.ColdArcher:
                                                Effects.Add(new Effect(Libraries.Monsters[(ushort)Monster.ColdArcher], 336 + (int)Direction * 4, 4, 4 * Frame.Interval, this, drawBehind: true));
                                                break;
                                        }
                                        break;
                                    }
                                case 4:
                                    {
                                        switch (BaseImage)
                                        {
                                            // Sanjian
                                            case Monster.FurbolgArcher:
                                                if (MapControl.GetObject(TargetID) != null)
                                                {
                                                    CreateProjectile(344, Libraries.Monsters[(ushort)Monster.FurbolgArcher], false, 5, 30, 0);
                                                    SoundManager.PlaySound(BaseSound + 6);
                                                }
                                                break;
                                            case Monster.FurbolgGuard:
                                                missile = CreateProjectile(391, Libraries.Monsters[(ushort)Monster.FurbolgGuard], false, 1, 30, 0);
                                                if (missile.Target != null)
                                                {
                                                    missile.Complete += (o, e) =>
                                                    {
                                                        if (missile.Target.CurrentAction == MirAction.Dead) return;
                                                        missile.Target.Effects.Add(new Effect(Libraries.Monsters[(ushort)Monster.FurbolgGuard], 407, 7, 600, missile.Target));
                                                        SoundManager.PlaySound(BaseSound + 6);
                                                    };
                                                }
                                                break;












                                            case Monster.AxeSkeleton:
                                                if (MapControl.GetObject(TargetID) != null)
                                                    CreateProjectile(224, Libraries.Monsters[(ushort)Monster.AxeSkeleton], false, 3, 30, 0);
                                                break;
                                            case Monster.Dark:
                                                if (MapControl.GetObject(TargetID) != null)
                                                    CreateProjectile(224, Libraries.Monsters[(ushort)Monster.Dark], false, 3, 30, 0);
                                                break;
                                            case Monster.ZumaArcher:
                                            case Monster.BoneArcher:
                                                if (MapControl.GetObject(TargetID) != null)
                                                {
                                                    CreateProjectile(224, Libraries.Monsters[(ushort)Monster.ZumaArcher], false, 1, 30, 0);
                                                    SoundManager.PlaySound(BaseSound + 6);
                                                }
                                                break;
                                            case Monster.RedThunderZuma:
                                            case Monster.FrozenRedZuma:
                                                ob = MapControl.GetObject(TargetID);
                                                if (ob != null)
                                                {
                                                    ob.Effects.Add(new Effect(Libraries.Dragon, 400 + CMain.Random.Next(3) * 10, 5, 300, ob));
                                                    SoundManager.PlaySound(BaseSound + 6);
                                                }
                                                break;
                                            case Monster.BoneLord:
                                                if (MapControl.GetObject(TargetID) != null)
                                                    CreateProjectile(784, Libraries.Monsters[(ushort)Monster.BoneLord], true, 6, 30, 0, direction16: false);
                                                break;
                                            case Monster.RightGuard:
                                                ob = MapControl.GetObject(TargetID);
                                                if (ob != null)
                                                {
                                                    ob.Effects.Add(new Effect(Libraries.Magic2, 10, 5, 300, ob));
                                                }
                                                break;
                                            case Monster.LeftGuard:
                                                if (MapControl.GetObject(TargetID) != null)
                                                {
                                                    CreateProjectile(10, Libraries.Magic, true, 6, 30, 4);
                                                }
                                                break;
                                            case Monster.MinotaurKing:
                                                ob = MapControl.GetObject(TargetID);
                                                if (ob != null)
                                                {
                                                    ob.Effects.Add(new Effect(Libraries.Monsters[(ushort)Monster.MinotaurKing], 320, 20, 1000, ob));
                                                }
                                                break;
                                            case Monster.FrostTiger:
                                                if (MapControl.GetObject(TargetID) != null)
                                                {
                                                    CreateProjectile(410, Libraries.Magic2, true, 4, 30, 6);
                                                }
                                                break;





                                            case Monster.Yimoogi:
                                            case Monster.RedYimoogi:
                                            case Monster.Snake10:
                                            case Monster.Snake11:
                                            case Monster.Snake12:
                                            case Monster.Snake13:
                                            case Monster.Snake14:
                                            case Monster.Snake15:
                                            case Monster.Snake16:
                                            case Monster.Snake17:
                                                ob = MapControl.GetObject(TargetID);
                                                if (ob != null)
                                                {
                                                    ob.Effects.Add(new Effect(Libraries.Magic2, 1250, 15, 1000, ob));
                                                    SoundManager.PlaySound(BaseSound + 6);
                                                }
                                                break;
                                            case Monster.HolyDeva:
                                                ob = MapControl.GetObject(TargetID);
                                                if (ob != null)
                                                {
                                                    ob.Effects.Add(new Effect(Libraries.Magic2, 10, 5, 300, ob));
                                                    SoundManager.PlaySound(BaseSound + 6);
                                                }
                                                break;
                                            case Monster.CrossbowOma:
                                                if (MapControl.GetObject(TargetID) != null)
                                                    CreateProjectile(38, Libraries.Monsters[(ushort)Monster.CrossbowOma], false, 1, 30, 6);
                                                break;
                                            case Monster.DarkCrossbowOma:
                                                if (MapControl.GetObject(TargetID) != null)
                                                    CreateProjectile(38, Libraries.Monsters[(ushort)Monster.DarkCrossbowOma], false, 1, 30, 6);
                                                break;
                                            case Monster.WingedOma:
                                            case Monster.DarkWingedOma:
                                                missile = CreateProjectile(224, Libraries.Monsters[(ushort)Monster.WingedOma], false, 6, 30, 0, direction16: false);

                                                if (missile.Target != null)
                                                {
                                                    missile.Complete += (o, e) =>
                                                    {
                                                        if (missile.Target.CurrentAction == MirAction.Dead) return;
                                                        missile.Target.Effects.Add(new Effect(Libraries.Monsters[(ushort)Monster.WingedOma], 272, 2, 150, missile.Target) { Blend = false });
                                                    };
                                                }
                                                break;
                                            case Monster.FlamingMutant:
                                                ob = MapControl.GetObject(TargetID);
                                                if (ob != null)
                                                {
                                                    MapControl.Effects.Add(new Effect(Libraries.Monsters[(ushort)Monster.FlamingMutant], 320, 10, 1000, ob.CurrentLocation, CMain.Time) { Blend = true });
                                                    //SoundManager.PlaySound(BaseSound + 6);
                                                }
                                                break;
                                            case Monster.PoisonHugger:
                                                missile = CreateProjectile(208, Libraries.Monsters[(ushort)Monster.PoisonHugger], true, 1, 30, 0);

                                                if (missile.Target != null)
                                                {
                                                    missile.Complete += (o, e) =>
                                                    {
                                                        if (missile.Target.CurrentAction == MirAction.Dead) return;
                                                        missile.Target.Effects.Add(new Effect(Libraries.Monsters[(ushort)Monster.PoisonHugger], 224, 5, 150, missile.Target) { Blend = true });
                                                    };
                                                }
                                                break;
                                            case Monster.RedFoxman:
                                                ob = MapControl.GetObject(TargetID);
                                                if (ob != null)
                                                {
                                                    ob.Effects.Add(new Effect(Libraries.Monsters[(ushort)Monster.RedFoxman], 224, 9, 300, ob));
                                                    SoundManager.PlaySound(BaseSound + 6);
                                                }
                                                break;
                                            case Monster.WhiteFoxman:
                                                missile = CreateProjectile(1160, Libraries.Magic, true, 3, 30, 7);

                                                if (missile.Target != null)
                                                {
                                                    missile.Complete += (o, e) =>
                                                    {
                                                        if (missile.Target.CurrentAction == MirAction.Dead) return;
                                                        missile.Target.Effects.Add(new Effect(Libraries.Monsters[(ushort)Monster.WhiteFoxman], 352, 10, 600, missile.Target));
                                                        SoundManager.PlaySound(BaseSound + 6);
                                                    };
                                                }
                                                break;
                                            case Monster.TrapRock:
                                                ob = MapControl.GetObject(TargetID);
                                                if (ob != null)
                                                {
                                                    ob.Effects.Add(new Effect(Libraries.Monsters[(ushort)Monster.TrapRock], 26, 10, 600, ob));
                                                    SoundManager.PlaySound(BaseSound + 6);
                                                }
                                                break;
                                            case Monster.HedgeKekTal:
                                                if (MapControl.GetObject(TargetID) != null)
                                                    CreateProjectile(38, Libraries.Monsters[(ushort)Monster.HedgeKekTal], false, 4, 30, 6);
                                                break;
                                            case Monster.BigHedgeKekTal:
                                                if (MapControl.GetObject(TargetID) != null)
                                                    CreateProjectile(38, Libraries.Monsters[(ushort)Monster.BigHedgeKekTal], false, 4, 30, 6);
                                                break;
                                            case Monster.EvilMir:
                                                missile = CreateProjectile(60, Libraries.Dragon, true, 10, 10, 0);

                                                if (missile.Direction > 12)
                                                    missile.Direction = 12;
                                                if (missile.Direction < 7)
                                                    missile.Direction = 7;

                                                if (missile.Target != null)
                                                {
                                                    missile.Complete += (o, e) =>
                                                    {
                                                        if (missile.Target.CurrentAction == MirAction.Dead) return;
                                                        missile.Target.Effects.Add(new Effect(Libraries.Dragon, 200, 20, 600, missile.Target));
                                                    };
                                                }
                                                break;
                                            case Monster.ArcherGuard:
                                                if (MapControl.GetObject(TargetID) != null)
                                                    CreateProjectile(38, Libraries.Monsters[(ushort)Monster.ArcherGuard], false, 3, 30, 6);
                                                break;
                                            case Monster.SpittingToad:
                                                if (MapControl.GetObject(TargetID) != null)
                                                    CreateProjectile(280, Libraries.Monsters[(ushort)Monster.SpittingToad], true, 6, 30, 0);
                                                break;
                                            case Monster.ArcherGuard2:
                                                if (MapControl.GetObject(TargetID) != null)
                                                    CreateProjectile(38, Libraries.Monsters[(ushort)Monster.ArcherGuard], false, 3, 30, 6);
                                                break;
                                            case Monster.ArcherGuard3:
                                                if (MapControl.GetObject(TargetID) != null)
                                                    CreateProjectile(104, Libraries.Monsters[(ushort)Monster.ArcherGuard3], false, 3, 30, 0);
                                                break;
                                            case Monster.FinialTurtle:
                                                missile = CreateProjectile(272, Libraries.Monsters[(ushort)Monster.FinialTurtle], true, 3, 30, 0);

                                                if (missile.Target != null)
                                                {
                                                    missile.Complete += (o, e) =>
                                                    {
                                                        if (missile.Target.CurrentAction == MirAction.Dead) return;
                                                        missile.Target.Effects.Add(new Effect(Libraries.Monsters[(ushort)Monster.FinialTurtle], 320, 10, 500, missile.Target) { Blend = true });
                                                        SoundManager.PlaySound(20000 + (ushort)Spell.FrostCrunch * 10 + 2);
                                                    };
                                                }
                                                break;
                                            case Monster.HellBolt:
                                                ob = MapControl.GetObject(TargetID);
                                                if (ob != null)
                                                {
                                                    ob.Effects.Add(new Effect(Libraries.Monsters[(ushort)Monster.HellBolt], 315, 10, 600, ob));
                                                    SoundManager.PlaySound(BaseSound + 6);
                                                }
                                                break;
                                            case Monster.WitchDoctor:
                                                if (MapControl.GetObject(TargetID) != null)
                                                {
                                                    missile = CreateProjectile(313, Libraries.Monsters[(ushort)Monster.WitchDoctor], true, 5, 30, -5, direction16: false);

                                                    if (missile.Target != null)
                                                    {
                                                        missile.Complete += (o, e) =>
                                                        {
                                                            if (missile.Target.CurrentAction == MirAction.Dead) return;
                                                            missile.Target.Effects.Add(new Effect(Libraries.Monsters[(ushort)Monster.WitchDoctor], 318, 10, 600, missile.Target));
                                                            SoundManager.PlaySound(BaseSound + 6);
                                                        };
                                                    }
                                                }
                                                break;
                                            case Monster.WingedTigerLord:
                                                ob = MapControl.GetObject(TargetID);
                                                if (ob != null)
                                                {
                                                    ob.Effects.Add(new Effect(Libraries.Monsters[(ushort)Monster.WingedTigerLord], 640, 10, 800, ob, CMain.Time + 400, false));
                                                }
                                                break;
                                            case Monster.TrollBomber:
                                                missile = CreateProjectile(208, Libraries.Monsters[(ushort)Monster.TrollBomber], false, 4, 40, -4, direction16: false);

                                                if (missile.Target != null)
                                                {
                                                    missile.Complete += (o, e) =>
                                                    {
                                                        SoundManager.PlaySound(BaseSound + 9);
                                                        missile.Target.Effects.Add(new Effect(Libraries.Monsters[(ushort)Monster.TrollBomber], 212, 6, 600, missile.Target) { Blend = true });
                                                    };
                                                }
                                                break;
                                            case Monster.TrollStoner:
                                                SoundManager.PlaySound(BaseSound + 9);
                                                missile = CreateProjectile(208, Libraries.Monsters[(ushort)Monster.TrollStoner], false, 4, 40, -4, direction16: false);
                                                break;
                                            case Monster.FlameMage:
                                                missile = CreateProjectile(544, Libraries.Monsters[(ushort)Monster.FlameMage], true, 3, 20, 0);

                                                if (missile.Target != null)
                                                {
                                                    missile.Complete += (o, e) =>
                                                    {
                                                        missile.Target.Effects.Add(new Effect(Libraries.Monsters[(ushort)Monster.FlameMage], 592, 10, 1000, missile.Target));
                                                    };
                                                }
                                                break;
                                            case Monster.FlameScythe:
                                                ob = MapControl.GetObject(TargetID);
                                                if (ob != null)
                                                {
                                                    ob.Effects.Add(new Effect(Libraries.Monsters[(ushort)Monster.FlameScythe], 586, 9, 900, ob));
                                                }
                                                break;
                                            case Monster.FlameAssassin:
                                                missile = CreateProjectile(592, Libraries.Monsters[(ushort)Monster.FlameAssassin], true, 3, 20, 0);

                                                if (missile.Target != null)
                                                {
                                                    missile.Complete += (o, e) =>
                                                    {
                                                        missile.Target.Effects.Add(new Effect(Libraries.Monsters[(ushort)Monster.FlameAssassin], 640, 6, 600, missile.Target));
                                                    };
                                                }
                                                break;
                                            case Monster.FlameQueen:
                                                Effects.Add(new Effect(Libraries.Monsters[(ushort)Monster.FlameQueen], 729, 10, Frame.Count * Frame.Interval, this));
                                                break;
                                            case Monster.AncientBringer:
                                                missile = CreateProjectile(688, Libraries.Monsters[(ushort)Monster.AncientBringer], true, 4, 50, 0, direction16: false);

                                                if (missile.Target != null)
                                                {
                                                    missile.Complete += (o, e) =>
                                                    {
                                                        if (missile.Target.CurrentAction == MirAction.Dead) return;
                                                        missile.Target.Effects.Add(new Effect(Libraries.Monsters[(ushort)Monster.AncientBringer], 720, 10, 1000, missile.Target) { Blend = true });
                                                    };
                                                }
                                                break;
                                            case Monster.RestlessJar:
                                                missile = CreateProjectile(476, Libraries.Monsters[(ushort)Monster.RestlessJar], true, 2, 100, 0, direction16: true);

                                                if (missile.Target != null)
                                                {
                                                    missile.Complete += (o, e) =>
                                                    {
                                                        if (missile.Target.CurrentAction == MirAction.Dead) return;
                                                        missile.Target.Effects.Add(new Effect(Libraries.Monsters[(ushort)Monster.RestlessJar], 508, 3, 300, missile.Target) { Blend = true });
                                                    };
                                                }
                                                break;
                                            case Monster.IceGuard:
                                                ob = MapControl.GetObject(TargetID);
                                                if (ob != null)
                                                {
                                                    ob.Effects.Add(new Effect(Libraries.Monsters[(ushort)Monster.IceGuard], 262, 6, 600, ob) { Blend = true });
                                                    SoundManager.PlaySound(BaseSound + 6);
                                                }
                                                break;
                                            case Monster.ElementGuard:
                                                ob = MapControl.GetObject(TargetID);
                                                if (ob != null)
                                                {
                                                    ob.Effects.Add(new Effect(Libraries.Monsters[(ushort)Monster.ElementGuard], 360 + (int)ob.Direction * 7, 7, 7 * Frame.Interval, ob) { Blend = true });
                                                    SoundManager.PlaySound(BaseSound + 6);
                                                }
                                                break;
                                            case Monster.KingGuard:
                                                ob = MapControl.GetObject(TargetID);
                                                if (ob != null)
                                                {
                                                    ob.Effects.Add(new Effect(Libraries.Monsters[(ushort)Monster.KingGuard], 746, 7, 700, ob) { Blend = true });
                                                }
                                                break;
                                            case Monster.BurningZombie:
                                                ob = MapControl.GetObject(TargetID);
                                                if (ob != null)
                                                {
                                                    ob.Effects.Add(new Effect(Libraries.Monsters[(ushort)Monster.BurningZombie], 361, 12, 1000, ob));
                                                }
                                                break;
                                            case Monster.FrozenZombie:
                                                ob = MapControl.GetObject(TargetID);
                                                if (ob != null)
                                                {
                                                    ob.Effects.Add(new Effect(Libraries.Monsters[(ushort)Monster.FrozenZombie], 352, 8, 1000, ob));
                                                }
                                                break;
                                            case Monster.CatShaman:
                                                ob = MapControl.GetObject(TargetID);
                                                if (ob != null)
                                                {
                                                    ob.Effects.Add(new Effect(Libraries.Monsters[(ushort)Monster.CatShaman], 720, 12, 1500, ob) { Blend = false });
                                                }
                                                break;
                                            case Monster.GeneralMeowMeow:
                                                ob = MapControl.GetObject(TargetID);
                                                if (ob != null)
                                                {
                                                    ob.Effects.Add(new Effect(Libraries.Monsters[(ushort)Monster.GeneralMeowMeow], 512, 10, 1000, ob) { Blend = true });
                                                }
                                                break;
                                            case Monster.CannibalTentacles:
                                                if (MapControl.GetObject(TargetID) != null)
                                                    CreateProjectile(472, Libraries.Monsters[(ushort)Monster.CannibalTentacles], true, 8, 100, 0, direction16: false);
                                                break;
                                            case Monster.SwampWarrior:
                                                ob = MapControl.GetObject(TargetID);
                                                if (ob != null)
                                                {
                                                    ob.Effects.Add(new Effect(Libraries.Monsters[(ushort)Monster.SwampWarrior], 392, 8, 800, ob) { Blend = true });
                                                }
                                                break;
                                            case Monster.PeacockSpider:
                                                missile = CreateProjectile(664, Libraries.Monsters[(ushort)Monster.PeacockSpider], true, 5, 100, 0, direction16: true);

                                                if (missile.Target != null)
                                                {
                                                    missile.Complete += (o, e) =>
                                                    {
                                                        if (missile.Target.CurrentAction == MirAction.Dead) return;
                                                        missile.Target.Effects.Add(new Effect(Libraries.Monsters[(ushort)Monster.PeacockSpider], 744, 11, 1100, missile.Target) { Blend = true });
                                                    };
                                                }
                                                break;
                                            case Monster.RhinoPriest:
                                                ob = MapControl.GetObject(TargetID);
                                                if (ob != null)
                                                {
                                                    ob.Effects.Add(new Effect(Libraries.Monsters[(ushort)Monster.RhinoPriest], 376, 9, 900, ob));
                                                }
                                                break;
                                            case Monster.TreeGuardian:
                                                ob = MapControl.GetObject(TargetID);
                                                if (ob != null)
                                                {
                                                    ob.Effects.Add(new Effect(Libraries.Monsters[(ushort)Monster.TreeGuardian], 544, 8, 800, ob));
                                                }
                                                break;
                                            case Monster.CreeperPlant:
                                                ob = MapControl.GetObject(TargetID);
                                                if (ob != null)
                                                {
                                                    MapControl.Effects.Add(new Effect(Libraries.Monsters[(ushort)Monster.CreeperPlant], 250, 6, 600, ob.CurrentLocation, CMain.Time) { Blend = true });
                                                    MapControl.Effects.Add(new Effect(Libraries.Monsters[(ushort)Monster.CreeperPlant], 256, 10, 1000, ob.CurrentLocation, CMain.Time) { Blend = false });
                                                }
                                                break;
                                            case Monster.FloatingWraith:
                                                missile = CreateProjectile(248, Libraries.Monsters[(ushort)Monster.FloatingWraith], true, 2, 20, 0, direction16: true);
                                                break;
                                            case Monster.AvengingSpirit:
                                                missile = CreateProjectile(368, Libraries.Monsters[(ushort)Monster.AvengingSpirit], true, 4, 40, 0, direction16: true);

                                                if (missile.Target != null)
                                                {
                                                    missile.Complete += (o, e) =>
                                                    {
                                                        if (missile.Target.CurrentAction == MirAction.Dead) return;
                                                        missile.Target.Effects.Add(new Effect(Libraries.Monsters[(ushort)Monster.AvengingSpirit], 432, 10, 1000, missile.Target) { Blend = true });
                                                    };
                                                }
                                                break;
                                            case Monster.AvengingWarrior:
                                                missile = CreateProjectile(312, Libraries.Monsters[(ushort)Monster.AvengingWarrior], true, 5, 50, 0, direction16: true);

                                                if (missile.Target != null)
                                                {
                                                    missile.Complete += (o, e) =>
                                                    {
                                                        if (missile.Target.CurrentAction == MirAction.Dead) return;
                                                        missile.Target.Effects.Add(new Effect(Libraries.Monsters[(ushort)Monster.AvengingWarrior], 392, 7, 700, missile.Target) { Blend = true });
                                                    };
                                                }
                                                break;
                                            case Monster.LightningBead:
                                                ob = MapControl.GetObject(TargetID);
                                                if (ob != null)
                                                {
                                                    ob.Effects.Add(new Effect(Libraries.Monsters[(ushort)Monster.LightningBead], 65, 12, 1200, ob));
                                                }
                                                break;
                                            case Monster.HealingBead:
                                                ob = MapControl.GetObject(TargetID);
                                                if (ob != null)
                                                {
                                                    ob.Effects.Add(new Effect(Libraries.Monsters[(ushort)Monster.HealingBead], 61, 11, 1100, ob));
                                                }
                                                break;
                                            case Monster.PowerUpBead:
                                                ob = MapControl.GetObject(TargetID);
                                                if (ob != null)
                                                {
                                                    ob.Effects.Add(new Effect(Libraries.Monsters[(ushort)Monster.PowerUpBead], 64, 6, 600, ob));
                                                }
                                                break;
                                            case Monster.DarkOmaKing:
                                                ob = MapControl.GetObject(TargetID);
                                                if (ob != null)
                                                {
                                                    MapControl.Effects.Add(new Effect(Libraries.Monsters[(ushort)Monster.DarkOmaKing], 1715, 13, 1300, ob.CurrentLocation));
                                                }
                                                break;
                                            case Monster.ChieftainArcher:
                                                if (MapControl.GetObject(TargetID) != null)
                                                {
                                                    if (CurrentActionLevel == 0)
                                                    {
                                                        missile = CreateProjectile(312, Libraries.Monsters[(ushort)Monster.ChieftainArcher], true, 5, 50, 0, direction16: true);

                                                        if (missile.Target != null)
                                                        {
                                                            missile.Complete += (o, e) =>
                                                            {
                                                                if (missile.Target.CurrentAction == MirAction.Dead) return;
                                                                missile.Target.Effects.Add(new Effect(Libraries.Monsters[(ushort)Monster.ChieftainArcher], 392, 6, 600, missile.Target));
                                                            };
                                                        }
                                                    }
                                                    else if (CurrentActionLevel == 1)
                                                    {
                                                        missile = CreateProjectile(398, Libraries.Monsters[(ushort)Monster.ChieftainArcher], true, 5, 50, 0, direction16: true);

                                                        if (missile.Target != null)
                                                        {
                                                            missile.Complete += (o, e) =>
                                                            {
                                                                if (missile.Target.CurrentAction == MirAction.Dead) return;
                                                                missile.Target.Effects.Add(new Effect(Libraries.Monsters[(ushort)Monster.ChieftainArcher], 478, 6, 600, missile.Target));
                                                            };
                                                        }
                                                    }
                                                    else
                                                    {
                                                        missile = CreateProjectile(484, Libraries.Monsters[(ushort)Monster.ChieftainArcher], true, 5, 50, 0, direction16: true);
                                                    }
                                                }
                                                break;
                                            case Monster.ManTree:
                                                ob = MapControl.GetObject(TargetID);
                                                if (ob != null)
                                                {
                                                    ob.Effects.Add(new Effect(Libraries.Monsters[(ushort)Monster.ManTree], 520, 8, 1000, ob));
                                                }
                                                break;
                                            case Monster.ClawBeast:
                                                ob = MapControl.GetObject(TargetID);
                                                if (ob != null)
                                                {
                                                    ob.Effects.Add(new Effect(Libraries.Monsters[(ushort)Monster.ClawBeast], 568, 7, 700, ob));
                                                }
                                                break;
                                            case Monster.BlackTortoise:
                                                Point source = Functions.PointMove(CurrentLocation, Direction, 2);

                                                missile = CreateProjectile(444, Libraries.Monsters[(ushort)Monster.BlackTortoise], true, 6, 60, 0, direction16: true);
                                                
                                                if (missile.Target != null)
                                                {
                                                    missile.Complete += (o, e) =>
                                                    {
                                                        if (missile.Target.CurrentAction == MirAction.Dead) return;
                                                        missile.Target.Effects.Add(new Effect(Libraries.Monsters[(ushort)Monster.BlackTortoise], 540, 6, 600, missile.Target));
                                                    };
                                                }
                                                break;
                                            case Monster.DragonArcher:
                                                if (MapControl.GetObject(TargetID) != null)
                                                    CreateProjectile(416, Libraries.Monsters[(ushort)Monster.DragonArcher], true, 5, 50, 0);
                                                break;
                                            case Monster.HornedMage:
                                                ob = MapControl.GetObject(TargetID);
                                                if (ob != null)
                                                {
                                                    ob.Effects.Add(new Effect(Libraries.Monsters[(ushort)Monster.HornedMage], 768, 9, 800, ob) { Blend = false });
                                                }
                                                break; 
                                            case Monster.HornedArcher:
                                                missile = CreateProjectile(360, Libraries.Monsters[(ushort)Monster.HornedArcher], true, 3, 50, 0, direction16: true);

                                                if (missile.Target != null)
                                                {
                                                    missile.Complete += (o, e) =>
                                                    {
                                                        if (missile.Target.CurrentAction == MirAction.Dead) return;
                                                        missile.Target.Effects.Add(new Effect(Libraries.Monsters[(ushort)Monster.HornedArcher], 408, 6, 500, missile.Target) { Blend = true });
                                                    };
                                                }
                                                break;
                                            case Monster.KingHydrax:
                                                ob = MapControl.GetObject(TargetID);
                                                if (ob != null)
                                                {
                                                    ob.Effects.Add(new Effect(Libraries.Monsters[(ushort)Monster.KingHydrax], 416, 9, 900, ob) { DrawBehind = true });
                                                    SoundManager.PlaySound(BaseSound + 6);
                                                }
                                                break;
                                            case Monster.WaterDragon:
                                                missile = CreateProjectile(800, Libraries.Monsters[(ushort)Monster.WaterDragon], true, 6, 60, 0, direction16: true);

                                                if (missile.Target != null)
                                                {
                                                    missile.Complete += (o, e) =>
                                                    {
                                                        if (missile.Target.CurrentAction == MirAction.Dead) return;
                                                        missile.Target.Effects.Add(new Effect(Libraries.Monsters[(ushort)Monster.WaterDragon], 896, 9, 900, missile.Target) { Blend = true });
                                                    };
                                                }
                                                break;
                                            case Monster.AntCommander:
                                                missile = CreateProjectile(432, Libraries.Monsters[(ushort)Monster.AntCommander], true, 3, 100, 0, direction16: true);

                                                if (missile.Target != null)
                                                {
                                                    missile.Complete += (o, e) =>
                                                    {
                                                        if (missile.Target.CurrentAction == MirAction.Dead) return;
                                                        missile.Target.Effects.Add(new Effect(Libraries.Monsters[(ushort)Monster.AntCommander], 480, 3, 300, missile.Target) { Blend = true });
                                                    };
                                                }
                                                break;
                                            case Monster.AssassinScroll:
                                                ob = MapControl.GetObject(TargetID);
                                                if (ob != null)
                                                {
                                                    ob.Effects.Add(new Effect(Libraries.Monsters[(ushort)Monster.AssassinScroll], 299, 8, 800, ob));
                                                }
                                                break;
                                            case Monster.TaoistScroll:
                                                ob = MapControl.GetObject(TargetID);
                                                if (ob != null)
                                                {
                                                    ob.Effects.Add(new Effect(Libraries.Monsters[(ushort)Monster.TaoistScroll], 272, 10, 1000, ob) { Blend = true });                                                    
                                                }
                                                break;
                                            case Monster.WarriorScroll:
                                                ob = MapControl.GetObject(TargetID);
                                                if (ob != null)
                                                {
                                                    ob.Effects.Add(new Effect(Libraries.Monsters[(ushort)Monster.WarriorScroll], 304, 11, 1100, ob) { Blend = true });
                                                }
                                                break;
                                            case Monster.WizardScroll:
                                                missile = CreateProjectile(300, Libraries.Monsters[(ushort)Monster.WizardScroll], true, 5, 50, 0);

                                                if (missile.Target != null)
                                                {
                                                    missile.Complete += (o, e) =>
                                                    {
                                                        if (missile.Target.CurrentAction == MirAction.Dead) return;
                                                        missile.Target.Effects.Add(new Effect(Libraries.Monsters[(ushort)Monster.WizardScroll], 380, 8, 800, missile.Target) { Blend = true });
                                                    };
                                                }
                                                break;
                                            case Monster.Catapult:
                                                missile = CreateProjectile(256, Libraries.Siege[(ushort)Monster.Catapult - 940], false, 4, 40, 0);
                                                if (missile.Target != null)
                                                {
                                                    missile.Complete += (o, e) =>
                                                    {
                                                        if (missile.Target.CurrentAction == MirAction.Dead) return;
                                                        missile.Target.Effects.Add(new Effect(Libraries.Siege[(ushort)Monster.Catapult - 940], 288, 10, 1000, missile.Target) { Blend = true });
                                                    };
                                                }
                                                break;
                                            case Monster.ChariotBallista:
                                                missile = CreateProjectile(38, Libraries.Siege[(ushort)Monster.ChariotBallista - 940], false, 3, 30, 6);
                                                break;
                                        }
                                        break;
                                    }//end of case 4
                                case 5:
                                    switch (BaseImage)
                                    {
                                        case Monster.OmaCannibal:
                                            missile = CreateProjectile(360, Libraries.Monsters[(ushort)Monster.OmaCannibal], true, 6, 60, 0);

                                            if (missile.Target != null)
                                            {
                                                missile.Complete += (o, e) =>
                                                {
                                                    if (missile.Target.CurrentAction == MirAction.Dead) return;
                                                    missile.Target.Effects.Add(new Effect(Libraries.Monsters[(ushort)Monster.OmaCannibal], 456, 7, 700, missile.Target) { Blend = true });
                                                };
                                            }
                                            break;
                                        case Monster.OmaMage:
                                            missile = CreateProjectile(392, Libraries.Monsters[(ushort)Monster.OmaMage], true, 8, 80, 0, direction16: true);

                                            if (missile.Target != null)
                                            {
                                                missile.Complete += (o, e) =>
                                                {
                                                    if (missile.Target.CurrentAction == MirAction.Dead) return;
                                                    missile.Target.Effects.Add(new Effect(Libraries.Monsters[(ushort)Monster.OmaMage], 520, 9, 600, missile.Target) { Blend = true });
                                                };
                                            }
                                            break;
                                        case Monster.OmaWitchDoctor:
                                            ob = MapControl.GetObject(TargetID);
                                            if (ob != null)
                                            {
                                                SoundManager.PlaySound(BaseSound + 7);
                                                ob.Effects.Add(new Effect(Libraries.Monsters[(ushort)Monster.OmaWitchDoctor], 848, 11, 1100, ob) { Blend = true });
                                            }
                                            break;
                                        case Monster.SnowYeti:
                                            missile = CreateProjectile(560, Libraries.Monsters[(ushort)Monster.SnowYeti], true, 6, 20, 0);
                                            break;
                                        case Monster.MudZombie:
                                            ob = MapControl.GetObject(TargetID);
                                            if (ob != null)
                                            {
                                                ob.Effects.Add(new Effect(Libraries.Monsters[(ushort)Monster.MudZombie], 304, 7, 700, ob) { Blend = false } );
                                            }
                                            break;
                                        case Monster.DarkSpirit:
                                            missile = CreateProjectile(512, Libraries.Monsters[(ushort)Monster.DarkSpirit], true, 6, 60, 0);

                                            if (missile.Target != null)
                                            {
                                                missile.Complete += (o, e) =>
                                                {
                                                    if (missile.Target.CurrentAction == MirAction.Dead) return;
                                                    missile.Target.Effects.Add(new Effect(Libraries.Monsters[(ushort)Monster.DarkSpirit], 608, 10, 1000, missile.Target));
                                                };
                                            }
                                            break;
                                    }

                                    break;
                                case 6:
                                    {
                                        switch (BaseImage)
                                        {
                                            case Monster.RedFaeFlower:
                                                missile = CreateProjectile(467, Libraries.Monsters[(ushort)Monster.RedFaeFlower], true, 5, 30, 0);

                                                if (missile.Target != null)
                                                {
                                                    missile.Complete += (o, e) =>
                                                    {
                                                        missile.Target.Effects.Add(new Effect(Libraries.Monsters[(ushort)Monster.RedFaeFlower], 547, 9, 900, missile.Target));
                                                    };
                                                }
                                                break;
                                            // Sanjian
                                            case Monster.FurbolgCommander:
                                                ob = MapControl.GetObject(TargetID);
                                                if (ob != null)
                                                {
                                                    ob.Effects.Add(new Effect(Libraries.Monsters[(ushort)Monster.FurbolgCommander], 357, 6, 600, ob) { DrawBehind = true });
                                                }
                                                break;


                                            case Monster.HornedMage:
                                                ob = MapControl.GetObject(TargetID);
                                                if (ob != null)
                                                {
                                                    ob.Effects.Add(new Effect(Libraries.Monsters[(ushort)Monster.HornedMage], 777, 6, 800, ob) /*{ Blend = false }*/);
                                                }
                                                break;
                                            case Monster.FloatingRock:
                                                ob = MapControl.GetObject(TargetID);
                                                if (ob != null)
                                                {
                                                    ob.Effects.Add(new Effect(Libraries.Monsters[(ushort)Monster.FloatingRock], 226, 10, 1000, ob) /*{ Blend = false }*/);
                                                }
                                                break;
                                            case Monster.FrozenArcher:
                                                if (MapControl.GetObject(TargetID) != null)
                                                    CreateProjectile(264, Libraries.Monsters[(ushort)Monster.FrozenArcher], true, 5, 80, 0);
                                                break;
                                            case Monster.FrozenMagician:
                                                missile = CreateProjectile(560, Libraries.Monsters[(ushort)Monster.FrozenMagician], true, 6, 30, 0);

                                                if (missile.Target != null)
                                                {
                                                    missile.Complete += (o, e) =>
                                                    {
                                                        missile.Target.Effects.Add(new Effect(Libraries.Monsters[(ushort)Monster.FrozenMagician], 656, 6, 600, missile.Target));
                                                    };
                                                }
                                                break;
                                            case Monster.IceCrystalSoldier:
                                                Point source = Functions.PointMove(CurrentLocation, Direction, 1);
                                                Effect ef = new Effect(Libraries.Monsters[(ushort)Monster.IceCrystalSoldier], 476, 8, 800, source, CMain.Time);
                                                MapControl.Effects.Add(ef);
                                                break;
                                            case Monster.ColdArcher:
                                                Effects.Add(new Effect(Libraries.Monsters[(ushort)Monster.ColdArcher], 368 + (int)Direction * 2, 2, 2 * FrameInterval, this));
                                                break;
                                            case Monster.HoodedSummoner:
                                                ob = MapControl.GetObject(TargetID);
                                                if (ob != null)
                                                {
                                                    ob.Effects.Add(new Effect(Libraries.Monsters[(ushort)Monster.HoodedSummoner], 374, 13, 1300, ob) { Blend = true });
                                                }
                                                break;
                                        }
                                        break;
                                    }
                                case 7:
                                    {
                                        switch (BaseImage)
                                        {
                                            case Monster.FrozenKnight:
                                                ob = MapControl.GetObject(TargetID);
                                                if (ob != null)
                                                {
                                                    ob.Effects.Add(new Effect(Libraries.Monsters[(ushort)Monster.FrozenKnight], 456, 10, 1000, ob));
                                                }
                                                break;
                                            case Monster.IcePhantom:
                                                ob = MapControl.GetObject(TargetID);
                                                if (ob != null)
                                                {
                                                    ob.Effects.Add(new Effect(Libraries.Monsters[(ushort)Monster.IcePhantom], 682, 10, 1000, ob) { Blend = true });
                                                    SoundManager.PlaySound(BaseSound + 6); //is this the correct sound for this mob attack?
                                                }
                                                break;
                                            case Monster.FloatingRock:
                                                ob = MapControl.GetObject(TargetID);
                                                if (ob != null)
                                                {
                                                    ob.Effects.Add(new Effect(Libraries.Monsters[(ushort)Monster.FloatingRock], 226, 10, 1000, ob));
                                                    SoundManager.PlaySound(BaseSound + 6);
                                                }
                                                break;
                                        }
                                        break;
                                    }
                                case 8:
                                    {
                                        switch (BaseImage)
                                        {
                                        }
                                        break;
                                    }
                                case 9:
                                    {
                                        switch (BaseImage)
                                        {
                                            case Monster.ColdArcher:
                                                ob = MapControl.GetObject(TargetID);
                                                if (ob != null)
                                                {
                                                    ob.Effects.Add(new Effect(Libraries.Monsters[(ushort)Monster.ColdArcher], 384, 10, 1000, ob));
                                                }
                                                break;
                                                
                                        }
                                        break;
                                    }
                            }
                            NextMotion += FrameInterval;
                        }
                    }
                    break;
                case MirAction.AttackRange2:
                    if (CMain.Time >= NextMotion)
                    {
                        GameScene.Scene.MapControl.TextureValid = false;

                        if (SkipFrames) UpdateFrame();

                        if (UpdateFrame() >= Frame.Count)
                        {
                            FrameIndex = Frame.Count - 1;
                            SetAction();
                        }
                        else
                        {
                            MapObject ob = null;
                            Missile missile;
                            switch (FrameIndex)
                            {
                                case 1:
                                    {
                                        switch (BaseImage)
                                        {
                                            case Monster.RestlessJar:
                                                var point = Functions.PointMove(CurrentLocation, Direction, 2);
                                                MapControl.Effects.Add(new Effect(Libraries.Monsters[(ushort)Monster.RestlessJar], 391 + (int)Direction * 10, 10, 10 * Frame.Interval, point));
                                                break;
                                            case Monster.KingHydrax:
                                                Effects.Add(new Effect(Libraries.Monsters[(ushort)Monster.KingHydrax], 425 + (int)Direction * 6, 6, 600, this));
                                                break;
                                        }
                                        break;
                                    }
                                case 2:
                                    {
                                        switch (BaseImage)
                                        {
                                            case Monster.FrozenMagician:
                                                Effects.Add(new Effect(Libraries.Monsters[(ushort)Monster.FrozenMagician], 662 + (int)Direction * 9, 9, 9 * Frame.Interval, this));
                                                break;

                                        }
                                        break;
                                    }
                                case 4:
                                    {
                                        switch (BaseImage)
                                        {
                                            case Monster.FurbolgArcher:
                                                if (MapControl.GetObject(TargetID) != null)
                                                {
                                                    missile = CreateProjectile(429, Libraries.Monsters[(ushort)Monster.FurbolgArcher], false, 5, 30, 0);

                                                    if (missile.Target != null)
                                                    {
                                                        missile.Complete += (o, e) =>
                                                        {
                                                            if (missile.Target.CurrentAction == MirAction.Dead) return;
                                                            missile.Target.Effects.Add(new Effect(Libraries.Monsters[(ushort)Monster.FurbolgArcher], 424, 5, 500, missile.Target));
                                                            SoundManager.PlaySound(BaseSound + 7);
                                                        };
                                                    }
                                                }
                                                break;




                                            case Monster.RedFoxman:
                                                ob = MapControl.GetObject(TargetID);
                                                if (ob != null)
                                                {
                                                    ob.Effects.Add(new Effect(Libraries.Monsters[(ushort)Monster.RedFoxman], 233, 10, 400, ob));
                                                    SoundManager.PlaySound(BaseSound + 7);
                                                }
                                                break;
                                            case Monster.WhiteFoxman:
                                                missile = CreateProjectile(1160, Libraries.Magic, true, 3, 30, 7);

                                                if (missile.Target != null)
                                                {
                                                    missile.Complete += (o, e) =>
                                                    {
                                                        if (missile.Target.CurrentAction == MirAction.Dead) return;
                                                        missile.Target.Effects.Add(new Effect(Libraries.Monsters[(ushort)Monster.WhiteFoxman], 362, 15, 1800, missile.Target));
                                                        SoundManager.PlaySound(BaseSound + 7);
                                                    };
                                                }
                                                break;
                                            case Monster.TrollKing:
                                                missile = CreateProjectile(294, Libraries.Monsters[(ushort)Monster.TrollKing], false, 4, 40, -4, direction16: false);

                                                if (missile.Target != null)
                                                {
                                                    missile.Complete += (o, e) =>
                                                    {
                                                        SoundManager.PlaySound(BaseSound + 9);
                                                        missile.Target.Effects.Add(new Effect(Libraries.Monsters[(ushort)Monster.TrollKing], 298, 6, 600, missile.Target) { Blend = true });
                                                    };
                                                }
                                                break;
                                            case Monster.AncientBringer:
                                                ob = MapControl.GetObject(TargetID);
                                                if (ob != null)
                                                {
                                                    ob.Effects.Add(new Effect(Libraries.Monsters[(ushort)Monster.AncientBringer], 740, 14, 2000, ob));
                                                    SoundManager.PlaySound(BaseSound + 6);
                                                }
                                                break;
                                            case Monster.IceGuard:
                                                ob = MapControl.GetObject(TargetID);
                                                if (ob != null)
                                                {
                                                    ob.Effects.Add(new Effect(Libraries.Monsters[(ushort)Monster.IceGuard], 268, 5, 500, ob) { Blend = true });
                                                    SoundManager.PlaySound(BaseSound + 6);
                                                }
                                                break;
                                            case Monster.CatShaman:
                                                ob = MapControl.GetObject(TargetID);
                                                if (ob != null)
                                                {
                                                    ob.Effects.Add(new Effect(Libraries.Monsters[(ushort)Monster.CatShaman], 732, 6, 500, ob));
                                                    SoundManager.PlaySound(BaseSound + 6);
                                                }
                                                break;
                                            case Monster.TucsonGeneral:
                                                missile = CreateProjectile(592, Libraries.Monsters[(ushort)Monster.TucsonGeneral], true, 9, 30, 0, direction16: true);

                                                if (missile.Target != null)
                                                {
                                                    missile.Complete += (o, e) =>
                                                    {
                                                        if (missile.Target.CurrentAction == MirAction.Dead) return;
                                                        missile.Target.Effects.Add(new Effect(Libraries.Monsters[(ushort)Monster.TucsonGeneral], 736, 9, 900, missile.Target) { Blend = true });
                                                    };
                                                }
                                                break;
                                            case Monster.RhinoPriest:
                                                ob = MapControl.GetObject(TargetID);
                                                if (ob != null)
                                                {
                                                    ob.Effects.Add(new Effect(Libraries.Monsters[(ushort)Monster.RhinoPriest], 448, 7, 700, ob) { Blend = true });
                                                }
                                                break;
                                            case Monster.TreeGuardian:
                                                ob = MapControl.GetObject(TargetID);
                                                if (ob != null)
                                                {
                                                    MapControl.Effects.Add(new Effect(Libraries.Monsters[(ushort)Monster.TreeGuardian], 648 + ((int)Direction * 10), 10, 1000, ob.CurrentLocation));
                                                }
                                                break;
                                            case Monster.OmaWitchDoctor:
                                                ob = MapControl.GetObject(TargetID);
                                                if (ob != null)
                                                {
                                                    ob.Effects.Add(new Effect(Libraries.Monsters[(ushort)Monster.OmaWitchDoctor], 859, 10, 1000, ob) { Blend = true });
                                                }
                                                break;
                                            case Monster.KingHydrax:
                                                missile = CreateProjectile(473, Libraries.Monsters[(ushort)Monster.KingHydrax], true, 4, 50, 0);

                                                if (missile.Target != null)
                                                {
                                                    missile.Complete += (o, e) =>
                                                    {
                                                        if (missile.Target.CurrentAction == MirAction.Dead) return;
                                                        missile.Target.Effects.Add(new Effect(Libraries.Monsters[(ushort)Monster.KingHydrax], 537, 6, 600, missile.Target) { Blend = true });
                                                    };
                                                }
                                                break;
                                            case Monster.IcePhantom:
                                                ob = MapControl.GetObject(TargetID);
                                                if (ob != null)
                                                {
                                                    ob.Effects.Add(new Effect(Libraries.Monsters[(ushort)Monster.IcePhantom], 772, 7, 700, ob) { Blend = true });
                                                    SoundManager.PlaySound(BaseSound + 6); //is this the correct sound for this mob attack?
                                                }
                                                break;
                                            case Monster.ColdArcher:
                                                missile = CreateProjectile(394, Libraries.Monsters[(ushort)Monster.ColdArcher], true, 3, 50, 0, direction16: true);

                                                if (missile.Target != null)
                                                {
                                                    missile.Complete += (o, e) =>
                                                    {
                                                        if (missile.Target.CurrentAction == MirAction.Dead) return;
                                                        missile.Target.Effects.Add(new Effect(Libraries.Monsters[(ushort)Monster.ColdArcher], 442, 6, 500, missile.Target) { Blend = true });
                                                    };
                                                }
                                                break;
                                            case Monster.HornedArcher:
                                                missile = CreateProjectile(414, Libraries.Monsters[(ushort)Monster.HornedArcher], true, 3, 50, 0, direction16: true);

                                                if (missile.Target != null)
                                                {
                                                    missile.Complete += (o, e) =>
                                                    {
                                                        if (missile.Target.CurrentAction == MirAction.Dead) return;
                                                        missile.Target.Effects.Add(new Effect(Libraries.Monsters[(ushort)Monster.HornedArcher], 462, 6, 500, missile.Target) { Blend = true });
                                                    };
                                                }
                                                break;
                                            case Monster.HornedCommander:
                                                Effects.Add(new Effect(Libraries.Monsters[(ushort)Monster.HornedCommander], 938 + (int)Direction * 9, 9, 9 * Frame.Interval, this));
                                                Effects.Add(new Effect(Libraries.Monsters[(ushort)Monster.HornedCommander], 1010 + (int)Direction * 2, 2, 2 * Frame.Interval, this));
                                                break;
                                        }
                                        break;
                                    }
                                case 8:
                                    {
                                        switch (BaseImage)
                                        {
                                            case Monster.FrozenMagician:
                                                missile = CreateProjectile(734, Libraries.Monsters[(ushort)Monster.FrozenMagician], true, 6, 30, 0);

                                                if (missile.Target != null)
                                                {
                                                    missile.Complete += (o, e) =>
                                                    {
                                                        missile.Target.Effects.Add(new Effect(Libraries.Monsters[(ushort)Monster.FrozenMagician], 830, 10, 1000, missile.Target));
                                                    };
                                                }
                                                break;
                                        }
                                        break;

                                    }
                            }
                            NextMotion += FrameInterval;
                        }
                    }
                    break;
                case MirAction.AttackRange3:
                    if (CMain.Time >= NextMotion)
                    {
                        GameScene.Scene.MapControl.TextureValid = false;

                        if (SkipFrames) UpdateFrame();

                        if (UpdateFrame() >= Frame.Count)
                        {
                            FrameIndex = Frame.Count - 1;
                            SetAction();
                        }
                        else
                        {
                            MapObject ob = null;
                            Missile missile;
                            switch (FrameIndex)
                            {
                                case 4:
                                    {
                                        switch (BaseImage)
                                        {
                                            case Monster.TucsonGeneral:
                                                ob = MapControl.GetObject(TargetID);
                                                if (ob != null)
                                                {
                                                    ob.Effects.Add(new Effect(Libraries.Monsters[(ushort)Monster.TucsonGeneral], 745, 17, 1000, ob) { Blend = true });
                                                }
                                                break;
                                        }
                                    }
                                    break;
                            }
                            NextMotion += FrameInterval;
                        }
                    }
                    break;
                case MirAction.Struck:
                    if (CMain.Time >= NextMotion)
                    {
                        GameScene.Scene.MapControl.TextureValid = false;

                        if (SkipFrames) UpdateFrame();

                        if (UpdateFrame() >= Frame.Count)
                        {
                            FrameIndex = Frame.Count - 1;
                            SetAction();
                        }
                        else
                        {
                            NextMotion += FrameInterval;
                        }
                    }
                    break;

                case MirAction.Die:
                    if (CMain.Time >= NextMotion)
                    {
                        GameScene.Scene.MapControl.TextureValid = false;

                        if (SkipFrames) UpdateFrame();

                        if (UpdateFrame() >= Frame.Count)
                        {
                            FrameIndex = Frame.Count - 1;
                            ActionFeed.Clear();
                            ActionFeed.Add(new QueuedAction { Action = MirAction.Dead, Direction = Direction, Location = CurrentLocation });
                            SetAction();
                        }
                        else
                        {
                            switch (FrameIndex)
                            {
                                case 1:
                                    switch (BaseImage)
                                    {

                                        // Sanjian
                                        case Monster.FurbolgCommander:
                                            Effects.Add(new Effect(Libraries.Monsters[(ushort)Monster.FurbolgCommander], 320, 5, 5 * Frame.Interval, this));
                                            break;
                                        case Monster.Furball:
                                            Effects.Add(new Effect(Libraries.Monsters[(ushort)Monster.Furball], 288, 8, Frame.Count * Frame.Interval, this));
                                            break;
                                        case Monster.GlacierBeast:
                                            Effects.Add(new Effect(Libraries.Monsters[(ushort)Monster.GlacierBeast], 342, 12, 1200, this) { Blend = true });
                                            break;


                                        case Monster.PoisonHugger:
                                            Effects.Add(new Effect(Libraries.Monsters[(ushort)Monster.PoisonHugger], 224, 5, Frame.Count * FrameInterval, this));
                                            break;
                                        case Monster.Hugger:
                                            Effects.Add(new Effect(Libraries.Monsters[(ushort)Monster.Hugger], 256, 8, Frame.Count * FrameInterval, this));
                                            break;
                                        case Monster.MutatedHugger:
                                            Effects.Add(new Effect(Libraries.Monsters[(ushort)Monster.MutatedHugger], 128, 7, Frame.Count * FrameInterval, this));
                                            break;
                                        case Monster.CyanoGhast:
                                            Effects.Add(new Effect(Libraries.Monsters[(ushort)Monster.CyanoGhast], 681, 7, Frame.Count * FrameInterval, this));
                                            break;
                                        case Monster.Hydrax:
                                            Effects.Add(new Effect(Libraries.Monsters[(ushort)Monster.Hydrax], 240, 5, 5 * Frame.Interval, this));
                                            break;
                                    }
                                    break;
                                case 3:
                                    PlayDeadSound();
                                    switch (BaseImage)
                                    {
                                        case Monster.BoneSpearman:
                                        case Monster.BoneBlademan:
                                        case Monster.BoneArcher:
                                            Effects.Add(new Effect(Libraries.Monsters[(ushort)Monster.BoneSpearman], 224, 8, Frame.Count * FrameInterval, this));
                                            break;
                                        case Monster.WoodBox:
                                            Effects.Add(new Effect(Libraries.Monsters[(ushort)Monster.WoodBox], 104, 6, 6 * Frame.Interval, this) { Blend = true });
                                            break;
                                        case Monster.BoulderSpirit:
                                            Effects.Add(new Effect(Libraries.Monsters[(ushort)Monster.BoulderSpirit], 64, 8, 8 * Frame.Interval, this) { Blend = true });
                                            break;
                                    }
                                    break;
                                    // Sanjian
                                case 4:
                                    PlayDeadSound();
                                    switch (BaseImage)
                                    {
                                    }
                                    break;
                                case 5:
                                    switch (BaseImage)
                                    {
                                        case Monster.KingHydrax:
                                            Effects.Add(new Effect(Libraries.Monsters[(ushort)Monster.KingHydrax], 543 + (int)Direction * 7, 7, 700, this));
                                            break;
                                        case Monster.Bear:
                                            Effects.Add(new Effect(Libraries.Monsters[(ushort)Monster.Bear], 353, 9, Frame.Count * Frame.Interval, this));
                                            break;
                                        case Monster.SnowWolfKing:
                                            Effects.Add(new Effect(Libraries.Monsters[(ushort)Monster.SnowWolfKing], 605, 10, 10 * Frame.Interval, this) { DrawBehind = true });
                                            break;
                                    }
                                    break;
                                case 9:
                                    switch (BaseImage)
                                    {
                                        case Monster.IcePhantom:
                                            MapControl.Effects.Add(new Effect(Libraries.Monsters[(ushort)Monster.IcePhantom], 692 + (int)Direction * 10, 10, 10 * Frame.Interval, CurrentLocation));
                                            break;
                                    }
                                    break;
                            }

                            NextMotion += FrameInterval;
                        }
                    }
                    break;
                case MirAction.Revive:
                    if (CMain.Time >= NextMotion)
                    {
                        GameScene.Scene.MapControl.TextureValid = false;

                        if (SkipFrames) UpdateFrame();

                        if (UpdateFrame() >= Frame.Count)
                        {
                            FrameIndex = Frame.Count - 1;
                            ActionFeed.Clear();
                            ActionFeed.Add(new QueuedAction { Action = MirAction.Standing, Direction = Direction, Location = CurrentLocation });
                            SetAction();
                        }
                        else
                        {
                            if (FrameIndex == 3)
                                PlayReviveSound();
                            NextMotion += FrameInterval;
                        }
                    }
                    break;
                case MirAction.Dead:                
                    break;

            }

            if ((CurrentAction == MirAction.Standing || CurrentAction == MirAction.SitDown) && NextAction != null)
                SetAction();
            else if (CurrentAction == MirAction.Dead && NextAction != null && (NextAction.Action == MirAction.Skeleton || NextAction.Action == MirAction.Revive))
                SetAction();
        }

        public int UpdateFrame()
        {
            if (Frame == null) return 0;

            if (FrameLoop != null)
            {
                if (FrameLoop.CurrentCount > FrameLoop.Loops)
                {
                    FrameLoop = null;
                }
                else if (FrameIndex >= FrameLoop.End)
                {
                    FrameIndex = FrameLoop.Start - 1;
                    FrameLoop.CurrentCount++;
                }
            }

            if (Frame.Reverse) return Math.Abs(--FrameIndex);

            return ++FrameIndex;
        }

        public override Missile CreateProjectile(int baseIndex, MLibrary library, bool blend, int count, int interval, int skip, int lightDistance = 6, bool direction16 = true, Color? lightColour = null, uint targetID = 0)
        {
            if (targetID == 0)
            {
                targetID = TargetID;
            }

            MapObject ob = MapControl.GetObject(targetID);

            var targetPoint = TargetPoint;

            if (ob != null) targetPoint = ob.CurrentLocation;

            int duration = Functions.MaxDistance(CurrentLocation, targetPoint) * 50;

            Missile missile = new Missile(library, baseIndex, duration / interval, duration, this, targetPoint, direction16)
            {
                Target = ob,
                Interval = interval,
                FrameCount = count,
                Blend = blend,
                Skip = skip,
                Light = lightDistance,
                LightColour = lightColour == null ? Color.White : (Color)lightColour
            };

            Effects.Add(missile);

            return missile;
        }

        private void PlaySummonSound()
        {
            switch (BaseImage)
            {
                case Monster.HellKnight1:
                case Monster.HellKnight2:
                case Monster.HellKnight3:
                case Monster.HellKnight4:
                case Monster.LightningBead:
                case Monster.HealingBead:
                case Monster.PowerUpBead:
                    SoundManager.PlaySound(BaseSound + 0);
                    return;
                case Monster.BoneFamiliar:
                case Monster.Shinsu:
                case Monster.HolyDeva:
                    SoundManager.PlaySound(BaseSound + 5);
                    return;
            }
        }
        private void PlayWalkSound(bool left = true)
        {
            if (left)
            {
                switch (BaseImage)
                {
                    case Monster.WingedTigerLord:
                    case Monster.PoisonHugger:
                    case Monster.SnowWolfKing:
                    case Monster.Catapult:
                    case Monster.ChariotBallista:
                        SoundManager.PlaySound(BaseSound + 8);
                        return;
                }
            }
            else
            {
                switch (BaseImage)
                {
                    case Monster.WingedTigerLord:
                    case Monster.AvengerPlant:
                        SoundManager.PlaySound(BaseSound + 8);
                        return;
                    case Monster.PoisonHugger:
                    case Monster.SnowWolfKing:
                        SoundManager.PlaySound(BaseSound + 9);
                        return;
                }
            }
        }
        public void PlayAppearSound()
        {
            switch (BaseImage)
            {
                case Monster.CannibalPlant:
                case Monster.WaterDragon:
                case Monster.EvilCentipede:
                case Monster.CreeperPlant:
                    return;
                case Monster.ZumaArcher:
                case Monster.ZumaStatue:
                case Monster.ZumaGuardian:
                case Monster.RedThunderZuma:
                case Monster.FrozenRedZuma:
                case Monster.FrozenZumaStatue:
                case Monster.FrozenZumaGuardian:
                case Monster.ZumaTaurus:
                case Monster.DemonGuard:
                case Monster.Turtlegrass:
                case Monster.ManTree:
                case Monster.EarthGolem:
                case Monster.AssassinScroll:
                case Monster.WarriorScroll:
                case Monster.TaoistScroll:
                case Monster.WizardScroll:
                case Monster.PurpleFaeFlower:
                    if (Stoned) return;
                    break;
            }

            SoundManager.PlaySound(BaseSound);
        }
        public void PlayPopupSound()
        {
            switch (BaseImage)
            {
                case Monster.ZumaTaurus:
                case Monster.DigOutZombie:
                case Monster.Armadillo:
                case Monster.ArmadilloElder:
                    SoundManager.PlaySound(BaseSound + 5);
                    return;
                case Monster.Shinsu:
                    SoundManager.PlaySound(BaseSound + 6);
                    return;
            }
            SoundManager.PlaySound(BaseSound);
        }

        public void PlayRunSound()
        {
            switch (BaseImage)
            {
                case Monster.HardenRhino:
                    SoundManager.PlaySound(BaseSound + 8);
                    break;
            }
        }

        public void PlayJumpSound()
        {
            switch (BaseImage)
            {
                case Monster.Armadillo:
                case Monster.ArmadilloElder:
                case Monster.ChieftainArcher:
                    SoundManager.PlaySound(BaseSound + 8);
                    break;
            }
        }

        public void PlayDashSound()
        {
            switch (BaseImage)
            {
                case Monster.HornedSorceror:
                    SoundManager.PlaySound(BaseSound + 9);
                    break;
            }
        }

        public void PlayFlinchSound()
        {
            switch (BaseImage)
            {
                default:
                    SoundManager.PlaySound(BaseSound + 2);
                    break;
            }
        }
        public void PlayStruckSound()
        {
            switch (StruckWeapon)
            {
                case 0:
                case 23:
                case 28:
                case 40:
                    SoundManager.PlaySound(SoundList.StruckWooden);
                    break;
                case 1:
                case 12:
                    SoundManager.PlaySound(SoundList.StruckShort);
                    break;
                case 2:
                case 8:
                case 11:
                case 15:
                case 18:
                case 20:
                case 25:
                case 31:
                case 33:
                case 34:
                case 37:
                case 41:
                    SoundManager.PlaySound(SoundList.StruckSword);
                    break;
                case 3:
                case 5:
                case 7:
                case 9:
                case 13:
                case 19:
                case 24:
                case 26:
                case 29:
                case 32:
                case 35:
                    SoundManager.PlaySound(SoundList.StruckSword2);
                    break;
                case 4:
                case 14:
                case 16:
                case 38:
                    SoundManager.PlaySound(SoundList.StruckAxe);
                    break;
                case 6:
                case 10:
                case 17:
                case 22:
                case 27:
                case 30:
                case 36:
                case 39:
                    SoundManager.PlaySound(SoundList.StruckShort);
                    break;
                case 21:
                    SoundManager.PlaySound(SoundList.StruckClub);
                    break;
            }
        }
        public void PlayAttackSound()
        {
            switch (BaseImage)
            {
                default:
                    SoundManager.PlaySound(BaseSound + 1);
                    break;
            }
        }

        public void PlaySecondAttackSound()
        {
            switch (BaseImage)
            {
                default:
                    SoundManager.PlaySound(BaseSound + 6);
                    break;

            }            
        }

        public void PlayThirdAttackSound()
        {
            switch (BaseImage)
            {
                case Monster.DarkCaptain:
                case Monster.HornedSorceror:
                case Monster.HornedCommander:
                    return;
                default:
                    SoundManager.PlaySound(BaseSound + 7);
                    return;
            }
        }

        public void PlayFourthAttackSound()
        {
            switch (BaseImage)
            {
                case Monster.HornedCommander:
                    return;
                case Monster.SnowWolfKing:
                    SoundManager.PlaySound(BaseSound + 5);
                    return;
                default:
                    SoundManager.PlaySound(BaseSound + 8);
                    return;
            }
        }

        public void PlayFithAttackSound()
        {
            SoundManager.PlaySound(BaseSound + 9);
        }

        public void PlaySwingSound()
        {
            switch (BaseImage)
            {
                case Monster.DarkCaptain:
                    return;
                default:
                    SoundManager.PlaySound(BaseSound + 4);
                    return;
            }
        }
        public void PlayDieSound()
        {
            switch (BaseImage)
            {
                default:
                    SoundManager.PlaySound(BaseSound + 3);
                    return;
            }
        }
        public void PlayDeadSound()
        {
            switch (BaseImage)
            {
                case Monster.CaveBat:
                case Monster.HellKnight1:
                case Monster.HellKnight2:
                case Monster.HellKnight3:
                case Monster.HellKnight4:
                case Monster.CyanoGhast:
                case Monster.WoodBox:
                    SoundManager.PlaySound(BaseSound + 5);
                    return;
            }
        }
        public void PlayReviveSound()
        {
            switch (BaseImage)
            {
                case Monster.ClZombie:
                case Monster.NdZombie:
                case Monster.CrawlerZombie:
                    SoundManager.PlaySound(SoundList.ZombieRevive);
                    return;
            }
        }
        public void PlayRangeSound()
        {
            switch (BaseImage)
            {
                case Monster.RedThunderZuma:
                case Monster.FrozenRedZuma:
                case Monster.KingScorpion:
                case Monster.DarkDevil:
                case Monster.Khazard:
                case Monster.BoneLord:
                case Monster.LeftGuard:
                case Monster.RightGuard:
                case Monster.FrostTiger:
                case Monster.GreatFoxSpirit:
                case Monster.BoneSpearman:
                case Monster.MinotaurKing:
                case Monster.WingedTigerLord:
                case Monster.ManectricClaw:
                case Monster.ManectricKing:
                case Monster.HellBolt:
                case Monster.WitchDoctor:
                case Monster.FlameSpear:
                case Monster.FlameMage:
                case Monster.FlameScythe:
                case Monster.FlameAssassin:
                case Monster.FlameQueen:
                case Monster.DarkDevourer:
                case Monster.DreamDevourer:
                case Monster.FlyingStatue:
                case Monster.IceGuard:
                case Monster.ElementGuard:
                case Monster.KingGuard:
                case Monster.Yimoogi:
                case Monster.RedYimoogi:
                case Monster.Snake10:
                case Monster.Snake11:
                case Monster.Snake12:
                case Monster.Snake13:
                case Monster.Snake14:
                case Monster.Snake15:
                case Monster.Snake16:
                case Monster.Snake17:
                case Monster.BurningZombie:
                case Monster.MudZombie:
                case Monster.FrozenZombie:
                case Monster.UndeadWolf:
                case Monster.CatShaman:
                case Monster.CannibalTentacles:
                case Monster.SwampWarrior:
                case Monster.GeneralMeowMeow:
                case Monster.RhinoPriest:
                case Monster.HardenRhino:
                case Monster.TreeGuardian:
                case Monster.OmaCannibal:
                case Monster.OmaMage:
                case Monster.OmaWitchDoctor:
                case Monster.CreeperPlant:
                case Monster.AvengingSpirit:
                case Monster.AvengingWarrior:
                case Monster.PeacockSpider:
                case Monster.FlamingMutant:
                case Monster.KingHydrax:
                case Monster.DarkCaptain:
                case Monster.DarkOmaKing:
                case Monster.HornedMage:
                case Monster.FrozenKnight:
                case Monster.IcePhantom:
                case Monster.WaterDragon:
                case Monster.BlackTortoise:
                    SoundManager.PlaySound(BaseSound + 5);
                    return;
                case Monster.AncientBringer:
                case Monster.SeedingsGeneral:
                    SoundManager.PlaySound(BaseSound + 7);
                    return;
                case Monster.RestlessJar:
                    SoundManager.PlaySound(BaseSound + 8);
                    return;
                case Monster.TucsonGeneral:
                    return;
                default:
                    PlayAttackSound();
                    return;
            }
        }
        public void PlaySecondRangeSound()
        {
            switch (BaseImage)
            {
                case Monster.TucsonGeneral:
                    SoundManager.PlaySound(BaseSound + 5);
                    return;
                case Monster.TurtleKing:
                    return;
                case Monster.KingGuard:
                case Monster.TreeGuardian:
                case Monster.DarkCaptain:
                case Monster.HornedCommander:
                    SoundManager.PlaySound(BaseSound + 7);
                    return;
                case Monster.AncientBringer:
                case Monster.SeedingsGeneral:
                    SoundManager.PlaySound(BaseSound + 8);
                    return;
                default:
                    PlaySecondAttackSound();
                    return;
            }
        }

        public void PlayThirdRangeSound()
        {
            switch (BaseImage)
            {
                case Monster.TucsonGeneral:
                    SoundManager.PlaySound(BaseSound + 7);
                    return;
                default:
                    PlayThirdAttackSound();
                    return;
            }
        }

        public void PlayPickupSound()
        {
            SoundManager.PlaySound(SoundList.PetPickup);
        }

        public void PlayPetSound()
        {
            int petSound = (ushort)BaseImage - 10000 + 10500;

            switch (BaseImage)
            {
                case Monster.Chick:
                case Monster.BabyPig:
                case Monster.Kitten:
                case Monster.BabySkeleton:
                case Monster.Baekdon:
                case Monster.Wimaen:
                case Monster.BlackKitten:
                case Monster.BabyDragon:
                case Monster.OlympicFlame:
                case Monster.BabySnowMan:
                case Monster.Frog:
                case Monster.BabyMonkey:
                case Monster.AngryBird:
                case Monster.Foxey:
                case Monster.MedicalRat:
                    SoundManager.PlaySound(petSound);
                    break;
            }
        }
        public override void Draw()
        {
            DrawBehindEffects(Settings.Effect);

            float oldOpacity = DXManager.Opacity;
            if (Hidden && !DXManager.Blending) DXManager.SetOpacity(0.5F);

            if (BodyLibrary == null || Frame == null) return;

            bool oldGrayScale = DXManager.GrayScale;
            Color drawColour = ApplyDrawColour();
            
            if (!DXManager.Blending && Frame.Blend)
                BodyLibrary.DrawBlend(DrawFrame, DrawLocation, drawColour, true);
            else
                BodyLibrary.Draw(DrawFrame, DrawLocation, drawColour, true);

            DXManager.SetGrayscale(oldGrayScale);
            DXManager.SetOpacity(oldOpacity);
        }


        public override bool MouseOver(Point p)
        {
            return MapControl.MapLocation == CurrentLocation || BodyLibrary != null && BodyLibrary.VisiblePixel(DrawFrame, p.Subtract(FinalDrawLocation), false);
        }

        public override void DrawBehindEffects(bool effectsEnabled)
        {
            for (int i = 0; i < Effects.Count; i++)
            {
                if (!Effects[i].DrawBehind) continue;
                Effects[i].Draw();
            }
        }

        public override void DrawEffects(bool effectsEnabled)
        {
            if (!effectsEnabled) return;

            for (int i = 0; i < Effects.Count; i++)
            {
                if (Effects[i].DrawBehind) continue;
                Effects[i].Draw();
            }

            switch (BaseImage)
            {
                case Monster.Scarecrow:
                    switch (CurrentAction)
                    {
                        case MirAction.Die:
                            Libraries.Monsters[(ushort)Monster.Scarecrow].DrawBlend(224 + FrameIndex, DrawLocation, Color.White, true);
                            break;
                    }
                    break;
                case Monster.CaveMaggot:
                    switch (CurrentAction)
                    {
                        case MirAction.Attack1:
                            if (FrameIndex >= 1)
                                Libraries.Monsters[(ushort)Monster.CaveMaggot].DrawBlend(175 + FrameIndex + (int)Direction * 5, DrawLocation, Color.White, true);
                            break;
                    }
                    break;
                case Monster.Skeleton:
                case Monster.BoneFighter:
                case Monster.AxeSkeleton:
                case Monster.BoneWarrior:
                case Monster.BoneElite:
                case Monster.BoneWhoo:
                    switch (CurrentAction)
                    {
                        case MirAction.Die:
                            Libraries.Monsters[(ushort)Monster.Skeleton].DrawBlend(224 + FrameIndex, DrawLocation, Color.White, true);
                            break;
                    }
                    break;
                case Monster.WoomaTaurus:
                    switch (CurrentAction)
                    {
                        case MirAction.Attack1:
                            Libraries.Monsters[(ushort)Monster.WoomaTaurus].DrawBlend(224 + FrameIndex + (int)Direction * 6, DrawLocation, Color.White, true);
                            break;
                    }
                    break;
                case Monster.Dung:
                    switch (CurrentAction)
                    {
                        case MirAction.Attack1:
                            if (FrameIndex >= 1)
                                Libraries.Monsters[(ushort)Monster.Dung].DrawBlend(223 + FrameIndex + (int)Direction * 5, DrawLocation, Color.White, true);
                            break;
                    }
                    break;
                case Monster.WedgeMoth:
                    switch (CurrentAction)
                    {
                        case MirAction.Attack1:
                            Libraries.Monsters[(ushort)Monster.WedgeMoth].DrawBlend(224 + FrameIndex + (int)Direction * 6, DrawLocation, Color.White, true);
                            break;
                    }
                    break;
                case Monster.RedThunderZuma:
                case Monster.FrozenRedZuma:
                    switch (CurrentAction)
                    {
                        case MirAction.Standing:
                            Libraries.Monsters[(ushort)Monster.RedThunderZuma].DrawBlend(320 + FrameIndex + (int)Direction * 4, DrawLocation, Color.White, true);
                            break;
                        case MirAction.Walking:
                        case MirAction.Pushed:
                            Libraries.Monsters[(ushort)Monster.RedThunderZuma].DrawBlend(352 + FrameIndex + (int)Direction * 6, DrawLocation, Color.White, true);
                            break;
                        case MirAction.Attack1:
                            Libraries.Monsters[(ushort)Monster.RedThunderZuma].DrawBlend(400 + FrameIndex + (int)Direction * 6, DrawLocation, Color.White, true);
                            break;
                        case MirAction.Struck:
                            Libraries.Monsters[(ushort)Monster.RedThunderZuma].DrawBlend(448 + FrameIndex + (int)Direction * 2, DrawLocation, Color.White, true);
                            break;
                        case MirAction.AttackRange1:
                            Libraries.Monsters[(ushort)Monster.RedThunderZuma].DrawBlend(464 + FrameIndex + (int)Direction * 6, DrawLocation, Color.White, true);
                            break;
                    }
                    break;
                //case Monster.FurbolgGuard:
                //    switch (CurrentAction)
                //    {
                //        case MirAction.Standing:
                //            Libraries.Monsters[(ushort)Monster.FurbolgGuard].DrawBlend(384 + FrameIndex + (int)Direction * 4, DrawLocation, Color.White, true);
                //            break;
                //        case MirAction.Walking:
                //            Libraries.Monsters[(ushort)Monster.FurbolgGuard].DrawBlend(432 + FrameIndex + (int)Direction * 6, DrawLocation, Color.White, true);
                //            break;
                //        case MirAction.Attack1:
                //            Libraries.Monsters[(ushort)Monster.FurbolgGuard].DrawBlend(480 + FrameIndex + (int)Direction * 6, DrawLocation, Color.White, true);
                //            break;
                //        case MirAction.AttackRange1:
                //            Libraries.Monsters[(ushort)Monster.FurbolgGuard].DrawBlend(536 + FrameIndex + (int)Direction * 6, DrawLocation, Color.White, true);
                //            break;
                //        case MirAction.Pushed:
                //            Libraries.Monsters[(ushort)Monster.FurbolgGuard].DrawBlend(604 + FrameIndex + (int)Direction * 6, DrawLocation, Color.White, true);
                //            break;
                //        case MirAction.Struck:
                //            Libraries.Monsters[(ushort)Monster.FurbolgGuard].DrawBlend(656 + FrameIndex + (int)Direction * 2, DrawLocation, Color.White, true);
                //            break;
                //        case MirAction.Die:
                //            Libraries.Monsters[(ushort)Monster.FurbolgGuard].DrawBlend(704 + FrameIndex + (int)Direction * 6, DrawLocation, Color.White, true);
                //            break;
                //    }
                //    break;
                case Monster.KingHog:
                    switch (CurrentAction)
                    {
                        case MirAction.Attack1:
                            Libraries.Monsters[(ushort)Monster.KingHog].DrawBlend(224 + FrameIndex + (int)Direction * 6, DrawLocation, Color.White, true);
                            break;
                    }
                    break;
                case Monster.DarkDevil:
                    switch (CurrentAction)
                    {
                        case MirAction.Attack1:
                            Libraries.Monsters[(ushort)Monster.DarkDevil].DrawBlend(342 + FrameIndex + (int)Direction * 6, DrawLocation, Color.White, true);
                            break;
                    }
                    break;
                case Monster.BoneLord:
                    switch (CurrentAction)
                    {
                        case MirAction.Standing:
                            Libraries.Monsters[(ushort)Monster.BoneLord].DrawBlend(400 + FrameIndex + (int)Direction * 4, DrawLocation, Color.White, true);
                            break;
                        case MirAction.Walking:
                        case MirAction.Pushed:
                            Libraries.Monsters[(ushort)Monster.BoneLord].DrawBlend(432 + FrameIndex + (int)Direction * 6, DrawLocation, Color.White, true);
                            break;
                        case MirAction.Attack1:
                            Libraries.Monsters[(ushort)Monster.BoneLord].DrawBlend(480 + FrameIndex + (int)Direction * 6, DrawLocation, Color.White, true);
                            break;
                        case MirAction.Attack2:
                            Libraries.Monsters[(ushort)Monster.BoneLord].DrawBlend(528 + FrameIndex + (int)Direction * 6, DrawLocation, Color.White, true);
                            break;
                        case MirAction.AttackRange1:
                            Libraries.Monsters[(ushort)Monster.BoneLord].DrawBlend(576 + FrameIndex + (int)Direction * 6, DrawLocation, Color.White, true);
                            break;
                        case MirAction.Struck:
                            Libraries.Monsters[(ushort)Monster.BoneLord].DrawBlend(624 + FrameIndex + (int)Direction * 2, DrawLocation, Color.White, true);
                            break;
                        case MirAction.Die:
                            Libraries.Monsters[(ushort)Monster.BoneLord].DrawBlend(640 + FrameIndex + (int)Direction * 20, DrawLocation, Color.White, true);
                            break;
                    }
                    break;
                case Monster.HolyDeva:
                    switch (CurrentAction)
                    {
                        case MirAction.Standing:
                            Libraries.Monsters[(ushort)Monster.HolyDeva].Draw(226 + FrameIndex + (int)Direction * 4, DrawLocation, Color.White, true);
                            break;
                        case MirAction.Walking:
                        case MirAction.Pushed:
                            Libraries.Monsters[(ushort)Monster.HolyDeva].Draw(258 + FrameIndex + (int)Direction * 6, DrawLocation, Color.White, true);
                            break;
                        case MirAction.AttackRange1:
                            Libraries.Monsters[(ushort)Monster.HolyDeva].Draw(306 + FrameIndex + (int)Direction * 6, DrawLocation, Color.White, true);
                            break;
                        case MirAction.Struck:
                            Libraries.Monsters[(ushort)Monster.HolyDeva].Draw(354 + FrameIndex + (int)Direction * 2, DrawLocation, Color.White, true);
                            break;
                        case MirAction.Die:
                            if (FrameIndex <= 6) Libraries.Monsters[(ushort)Monster.HolyDeva].Draw(370 + FrameIndex + (int)Direction * 6, DrawLocation, Color.White, true);
                            break;
                        case MirAction.Appear:
                            if (FrameIndex >= 5) Libraries.Monsters[(ushort)Monster.HolyDeva].Draw(418 + FrameIndex - 5, DrawLocation, Color.White, true);
                            break;
                    }
                    break;
                case Monster.YinDevilNode:
                    switch (CurrentAction)
                    {
                        case MirAction.Standing:
                            Libraries.Monsters[(ushort)Monster.YinDevilNode].DrawBlend(22 + FrameIndex, DrawLocation, Color.White, true);
                            break;
                    }
                    break;
                case Monster.YangDevilNode:
                    switch (CurrentAction)
                    {
                        case MirAction.Standing:
                            Libraries.Monsters[(ushort)Monster.YangDevilNode].DrawBlend(22 + FrameIndex, DrawLocation, Color.White, true);
                            break;
                    }
                    break;
                case Monster.OmaKing:
                    switch (CurrentAction)
                    {
                        case MirAction.Attack1:
                            if (FrameIndex >= 3) Libraries.Monsters[(ushort)Monster.OmaKing].DrawBlend((624 + FrameIndex + (int)Direction * 4) - 3, DrawLocation, Color.White, true);
                            break;
                        case MirAction.Attack2:
                            Libraries.Monsters[(ushort)Monster.OmaKing].DrawBlend(656 + FrameIndex, DrawLocation, Color.White, true);
                            break;
                        case MirAction.Die:
                            Libraries.Monsters[(ushort)Monster.OmaKing].DrawBlend(304 + FrameIndex + (int)Direction * 20, DrawLocation, Color.White, true);
                            break;
                    }
                    break;
                case Monster.BlackFoxman:
                    switch (CurrentAction)
                    {
                        case MirAction.Attack2:
                            if (FrameIndex >= 3) Libraries.Monsters[(ushort)Monster.BlackFoxman].DrawBlend((234 + FrameIndex + (int)Direction * 4) - 3, DrawLocation, Color.White, true);
                            break;
                    }
                    break;

                case Monster.ManectricKing:
                    switch (CurrentAction)
                    {
                        case MirAction.Standing:
                            Libraries.Monsters[(ushort)Monster.ManectricKing].DrawBlend(360 + FrameIndex + (int)Direction * 4, DrawLocation, Color.White, true);
                            break;
                        case MirAction.Walking:
                            Libraries.Monsters[(ushort)Monster.ManectricKing].DrawBlend(392 + FrameIndex + (int)Direction * 6, DrawLocation, Color.White, true);
                            break;
                        case MirAction.Attack1:
                            Libraries.Monsters[(ushort)Monster.ManectricKing].DrawBlend(440 + FrameIndex + (int)Direction * 6, DrawLocation, Color.White, true);
                            break;
                        case MirAction.Attack2:
                            Libraries.Monsters[(ushort)Monster.ManectricKing].DrawBlend(576 + FrameIndex + (int)Direction * 8, DrawLocation, Color.White, true);
                            break;
                        case MirAction.Struck:
                            Libraries.Monsters[(ushort)Monster.ManectricKing].DrawBlend(488 + FrameIndex + (int)Direction * 2, DrawLocation, Color.White, true);
                            break;
                    }
                    break;
                case Monster.ManectricStaff:
                    switch (CurrentAction)
                    {
                        case MirAction.Attack2:
                            Libraries.Monsters[(ushort)Monster.ManectricStaff].DrawBlend(296 + FrameIndex + (int)Direction * 6, DrawLocation, Color.White, true);
                            break;
                    }
                    break;
                case Monster.ManectricBlest:
                    switch (CurrentAction)
                    {
                        case MirAction.Attack2:
                            if (FrameIndex >= 4) Libraries.Monsters[(ushort)Monster.ManectricBlest].DrawBlend((328 + FrameIndex + (int)Direction * 4) - 4, DrawLocation, Color.White, true);
                            break;
                        case MirAction.Attack3:
                            if (FrameIndex >= 2) Libraries.Monsters[(ushort)Monster.ManectricBlest].DrawBlend((360 + FrameIndex + (int)Direction * 5) - 2, DrawLocation, Color.White, true);
                            break;
                    }
                    break;
                case Monster.KingGuard:
                    switch (CurrentAction)
                    {
                        case MirAction.Standing:
                            Libraries.Monsters[(ushort)Monster.KingGuard].DrawBlend(392 + FrameIndex + (int)Direction * 4, DrawLocation, Color.White, true);
                            break;
                        case MirAction.Walking:
                            Libraries.Monsters[(ushort)Monster.KingGuard].DrawBlend(424 + FrameIndex + (int)Direction * 6, DrawLocation, Color.White, true);
                            break;
                        case MirAction.Attack1:
                            Libraries.Monsters[(ushort)Monster.KingGuard].DrawBlend(472 + FrameIndex + (int)Direction * 6, DrawLocation, Color.White, true);
                            break;
                        case MirAction.Attack2:
                            Libraries.Monsters[(ushort)Monster.KingGuard].DrawBlend(616 + FrameIndex + (int)Direction * 6, DrawLocation, Color.White, true);
                            break;
                        case MirAction.Pushed:
                            Libraries.Monsters[(ushort)Monster.KingGuard].DrawBlend(352 + FrameIndex + (int)Direction * 6, DrawLocation, Color.White, true);
                            break;
                        case MirAction.Struck:
                            Libraries.Monsters[(ushort)Monster.KingGuard].DrawBlend(520 + FrameIndex + (int)Direction * 2, DrawLocation, Color.White, true);
                            break;
                        case MirAction.AttackRange1:
                            Libraries.Monsters[(ushort)Monster.KingGuard].DrawBlend(664 + FrameIndex + (int)Direction * 8, DrawLocation, Color.White, true);
                            break;
                        case MirAction.AttackRange2:
                            Libraries.Monsters[(ushort)Monster.KingGuard].DrawBlend(728 + FrameIndex + (int)Direction * 7, DrawLocation, Color.White, true);
                            break;
                    }
                    break;
                case Monster.Jar2:
                    switch (CurrentAction)
                    {
                        case MirAction.Standing:
                            Libraries.Monsters[(ushort)Monster.Jar2].DrawBlend(312 + FrameIndex + (int)Direction * 10, DrawLocation, Color.White, true);
                            break;
                        case MirAction.Attack1:
                            Libraries.Monsters[(ushort)Monster.Jar2].DrawBlend(392 + FrameIndex + (int)Direction * 6, DrawLocation, Color.White, true);
                            break;
                        case MirAction.AttackRange1:
                            Libraries.Monsters[(ushort)Monster.Jar2].DrawBlend(440 + FrameIndex + (int)Direction * 10, DrawLocation, Color.White, true);
                            break;
                        case MirAction.Struck:
                            Libraries.Monsters[(ushort)Monster.Jar2].DrawBlend(520 + FrameIndex + (int)Direction * 3, DrawLocation, Color.White, true);
                            break;
                        case MirAction.Die:
                            Libraries.Monsters[(ushort)Monster.Jar2].DrawBlend(544 + FrameIndex + (int)Direction * 10, DrawLocation, Color.White, true);
                            break;
                    }
                    break;
                case Monster.SeedingsGeneral:
                    switch (CurrentAction)
                    {
                        case MirAction.Standing:
                            Libraries.Monsters[(ushort)Monster.SeedingsGeneral].DrawBlend(536 + FrameIndex + (int)Direction * 4, DrawLocation, Color.White, true);
                            break;
                        case MirAction.Walking:
                            Libraries.Monsters[(ushort)Monster.SeedingsGeneral].DrawBlend(568 + FrameIndex + (int)Direction * 4, DrawLocation, Color.White, true);
                            break;
                        case MirAction.Attack1:
                            Libraries.Monsters[(ushort)Monster.SeedingsGeneral].DrawBlend(704 + FrameIndex + (int)Direction * 9, DrawLocation, Color.White, true);
                            break;
                        case MirAction.Attack2:
                            Libraries.Monsters[(ushort)Monster.SeedingsGeneral].DrawBlend(776 + FrameIndex + (int)Direction * 9, DrawLocation, Color.White, true);
                            break;
                        case MirAction.Dead:
                            Libraries.Monsters[(ushort)Monster.SeedingsGeneral].DrawBlend(1015 + FrameIndex + (int)Direction * 1, DrawLocation, Color.White, true);
                            break;
                        case MirAction.Struck:
                            Libraries.Monsters[(ushort)Monster.SeedingsGeneral].DrawBlend(984 + FrameIndex + (int)Direction * 3, DrawLocation, Color.White, true);
                            break;
                        case MirAction.Die:
                            Libraries.Monsters[(ushort)Monster.SeedingsGeneral].DrawBlend(1008 + FrameIndex + (int)Direction * 8, DrawLocation, Color.White, true);
                            break;
                        case MirAction.AttackRange1:
                            Libraries.Monsters[(ushort)Monster.SeedingsGeneral].DrawBlend(848 + FrameIndex + (int)Direction * 8, DrawLocation, Color.White, true);
                            break;
                        case MirAction.AttackRange2:
                            Libraries.Monsters[(ushort)Monster.SeedingsGeneral].DrawBlend(912 + FrameIndex + (int)Direction * 9, DrawLocation, Color.White, true);
                            break;
                    }
                    break;

                case Monster.HellSlasher:
                    switch (CurrentAction)
                    {
                        case MirAction.Attack1:
                            if (FrameIndex >= 2 && FrameIndex < 6) Libraries.Monsters[(ushort)Monster.HellSlasher].DrawBlend((304 + FrameIndex + (int)Direction * 4) - 2, DrawLocation, Color.White, true);
                            break;
                    }
                    break;

                case Monster.HellPirate:
                    switch (CurrentAction)
                    {
                        case MirAction.Attack2:
                            if (FrameIndex >= 3) Libraries.Monsters[(ushort)Monster.HellPirate].DrawBlend((280 + FrameIndex + (int)Direction * 4) - 3, DrawLocation, Color.White, true);
                            break;
                    }
                    break;

                case Monster.HellCannibal:
                    switch (CurrentAction)
                    {
                        case MirAction.Attack1:
                            Libraries.Monsters[(ushort)Monster.HellCannibal].DrawBlend(304 + FrameIndex, DrawLocation, Color.White, true);
                            break;
                    }
                    break;

                case Monster.HellKeeper:
                    switch (CurrentAction)
                    {
                        case MirAction.Attack2:
                            Libraries.Monsters[(ushort)Monster.HellKeeper].DrawBlend(40 + FrameIndex, DrawLocation, Color.White, true);
                            break;
                    }
                    break;
                case Monster.Manticore:
                    switch (CurrentAction)
                    {
                        case MirAction.Attack2:
                            Libraries.Monsters[(ushort)Monster.Manticore].DrawBlend((536 + FrameIndex + (int)Direction * 7), DrawLocation, Color.White, true);
                            break;
                    }
                    break;
                case Monster.GuardianRock:
                    switch (CurrentAction)
                    {
                        case MirAction.AttackRange1:
                            Libraries.Monsters[(ushort)Monster.GuardianRock].DrawBlend(8 + FrameIndex, DrawLocation, Color.White, true);
                            break;
                    }
                    break;
                case Monster.ThunderElement:
                    switch (CurrentAction)
                    {
                        case MirAction.Standing:
                            Libraries.Monsters[(ushort)Monster.ThunderElement].DrawBlend(44 + FrameIndex, DrawLocation, Color.White, true);
                            break;
                        case MirAction.Walking:
                        case MirAction.Pushed:
                            Libraries.Monsters[(ushort)Monster.ThunderElement].DrawBlend(54 + FrameIndex, DrawLocation, Color.White, true);
                            break;
                        case MirAction.Attack1:
                            Libraries.Monsters[(ushort)Monster.ThunderElement].DrawBlend(64 + FrameIndex, DrawLocation, Color.White, true);
                            break;
                        case MirAction.Struck:
                            Libraries.Monsters[(ushort)Monster.ThunderElement].DrawBlend(74 + FrameIndex, DrawLocation, Color.White, true);
                            break;
                        case MirAction.Die:
                            Libraries.Monsters[(ushort)Monster.ThunderElement].DrawBlend(78 + FrameIndex, DrawLocation, Color.White, true);
                            break;
                    }
                    break;
                case Monster.CloudElement:
                    switch (CurrentAction)
                    {
                        case MirAction.Standing:
                            Libraries.Monsters[(ushort)Monster.CloudElement].DrawBlend(44 + FrameIndex, DrawLocation, Color.White, true);
                            break;
                        case MirAction.Walking:
                        case MirAction.Pushed:
                            Libraries.Monsters[(ushort)Monster.CloudElement].DrawBlend(54 + FrameIndex, DrawLocation, Color.White, true);
                            break;
                        case MirAction.Attack1:
                            Libraries.Monsters[(ushort)Monster.CloudElement].DrawBlend(64 + FrameIndex, DrawLocation, Color.White, true);
                            break;
                        case MirAction.Struck:
                            Libraries.Monsters[(ushort)Monster.CloudElement].DrawBlend(74 + FrameIndex, DrawLocation, Color.White, true);
                            break;
                        case MirAction.Die:
                            Libraries.Monsters[(ushort)Monster.CloudElement].DrawBlend(78 + FrameIndex, DrawLocation, Color.White, true);
                            break;
                    }
                    break;
                case Monster.GreatFoxSpirit:
                    switch (CurrentAction)
                    {
                        case MirAction.Standing:
                            Libraries.Monsters[(ushort)Monster.GreatFoxSpirit].DrawBlend(Frame.Start + 30 + FrameIndex, DrawLocation, Color.White, true);
                            break;
                        case MirAction.Attack1:
                        case MirAction.AttackRange1:
                            Libraries.Monsters[(ushort)Monster.GreatFoxSpirit].DrawBlend(Frame.Start + 30 + FrameIndex, DrawLocation, Color.White, true);
                            break;
                        case MirAction.Struck:
                            Libraries.Monsters[(ushort)Monster.GreatFoxSpirit].DrawBlend(Frame.Start + 30 + FrameIndex, DrawLocation, Color.White, true);
                            break;
                        case MirAction.Die:
                            Libraries.Monsters[(ushort)Monster.GreatFoxSpirit].DrawBlend(318 + FrameIndex, DrawLocation, Color.White, true);
                            break;
                    }
                    break;
                case Monster.TaoistGuard:
                    switch (CurrentAction)
                    {
                        case MirAction.Attack1:
                            Libraries.Monsters[(ushort)Monster.TaoistGuard].DrawBlend(80 + ((int)Direction * 3) + FrameIndex, DrawLocation, Color.White, true);
                            break;
                    }
                    break;
                case Monster.CyanoGhast: //mob glow effect
                    switch (CurrentAction)
                    {
                        case MirAction.Standing:
                            Libraries.Monsters[(ushort)Monster.CyanoGhast].DrawBlend(448 + FrameIndex + (int)Direction * 4, DrawLocation, Color.White, true);
                            break;
                        case MirAction.Walking:
                            Libraries.Monsters[(ushort)Monster.CyanoGhast].DrawBlend(480 + FrameIndex + (int)Direction * 6, DrawLocation, Color.White, true);
                            break;
                        case MirAction.Attack1:
                            Libraries.Monsters[(ushort)Monster.CyanoGhast].DrawBlend(528 + FrameIndex + (int)Direction * 6, DrawLocation, Color.White, true);
                            break;
                        case MirAction.Struck:
                            Libraries.Monsters[(ushort)Monster.CyanoGhast].DrawBlend(576 + FrameIndex + (int)Direction * 2, DrawLocation, Color.White, true);
                            break;
                        case MirAction.Die:
                        case MirAction.Revive:
                            Libraries.Monsters[(ushort)Monster.CyanoGhast].DrawBlend(592 + FrameIndex + (int)Direction * 10, DrawLocation, Color.White, true);
                            break;
                    }
                    break;
                case Monster.MutatedManworm:
                    switch (CurrentAction)
                    {
                        case MirAction.Attack1:
                            Libraries.Monsters[(ushort)Monster.MutatedManworm].DrawBlend(285 + FrameIndex + (int)Direction * 6, DrawLocation, Color.White, true);
                            break;
                        case MirAction.Attack2:
                            Libraries.Monsters[(ushort)Monster.MutatedManworm].DrawBlend(333 + FrameIndex + (int)Direction * 8, DrawLocation, Color.White, true);
                            break;
                    }
                    break;
                case Monster.CrazyManworm:
                    switch (CurrentAction)
                    {
                        case MirAction.Attack2:
                            Libraries.Monsters[(ushort)Monster.CrazyManworm].DrawBlend(272 + FrameIndex + (int)Direction * 8, DrawLocation, Color.White, true);
                            break;
                    }
                    break;

                case Monster.Behemoth:
                    switch (CurrentAction)
                    {
                        case MirAction.Walking:
                        case MirAction.Struck:
                            Libraries.Monsters[(ushort)Monster.Behemoth].DrawBlend(464 + FrameIndex + (int)Direction * 6, DrawLocation, Color.White, true);
                            break;
                        case MirAction.Standing:
                        case MirAction.Revive:
                            Libraries.Monsters[(ushort)Monster.Behemoth].DrawBlend(512 + FrameIndex + (int)Direction * 10, DrawLocation, Color.White, true);
                            break;
                        case MirAction.Attack2:
                        case MirAction.Attack3:
                        case MirAction.AttackRange1:
                        case MirAction.AttackRange2:
                            Libraries.Monsters[(ushort)Monster.Behemoth].DrawBlend(592 + FrameIndex + (int)Direction * 7, DrawLocation, Color.White, true);
                            break;
                        case MirAction.Attack1:
                            if (FrameIndex >= 4) Libraries.Monsters[(ushort)Monster.Behemoth].DrawBlend((667 + FrameIndex + (int)Direction * 2) - 4, DrawLocation, Color.White, true);
                            Libraries.Monsters[(ushort)Monster.Behemoth].DrawBlend(592 + FrameIndex + (int)Direction * 7, DrawLocation, Color.White, true);
                            break;
                        case MirAction.Die:
                            if (FrameIndex >= 1) Libraries.Monsters[(ushort)Monster.Behemoth].DrawBlend(658 + FrameIndex - 1, DrawLocation, Color.White, true);
                            break;
                    }

                    if (CurrentAction != MirAction.Dead)
                        Libraries.Monsters[(ushort)Monster.Behemoth].DrawBlend(648 + FrameIndex, DrawLocation, Color.White, true);
                    break;

                case Monster.DarkDevourer:
                    switch (CurrentAction)
                    {
                        case MirAction.Standing:
                            Libraries.Monsters[(ushort)Monster.DarkDevourer].DrawBlend(272 + FrameIndex + (int)Direction * 4, DrawLocation, Color.White, true);
                            break;
                        case MirAction.Walking:
                            Libraries.Monsters[(ushort)Monster.DarkDevourer].DrawBlend(304 + FrameIndex + (int)Direction * 6, DrawLocation, Color.White, true);
                            break;
                        case MirAction.Attack1:
                            Libraries.Monsters[(ushort)Monster.DarkDevourer].DrawBlend(352 + FrameIndex + (int)Direction * 6, DrawLocation, Color.White, true);
                            break;
                        case MirAction.AttackRange1:
                            Libraries.Monsters[(ushort)Monster.DarkDevourer].DrawBlend(540 + FrameIndex + (int)Direction * 8, DrawLocation, Color.White, true);
                            break;
                        case MirAction.Struck:
                            Libraries.Monsters[(ushort)Monster.DarkDevourer].DrawBlend(400 + FrameIndex + (int)Direction * 2, DrawLocation, Color.White, true);
                            break;
                        case MirAction.Die:
                        case MirAction.Revive:
                            Libraries.Monsters[(ushort)Monster.DarkDevourer].DrawBlend(416 + FrameIndex + (int)Direction * 8, DrawLocation, Color.White, true);
                            break;
                    }
                    break;

                case Monster.DreamDevourer:
                    switch (CurrentAction)
                    {
                        case MirAction.AttackRange1:
                            if (FrameIndex >= 3) Libraries.Monsters[(ushort)Monster.DreamDevourer].DrawBlend(320 + (FrameIndex + (int)Direction * 5) - 3, DrawLocation, Color.White, true);
                            break;
                    }
                    break;

                case Monster.TurtleKing:
                    switch (CurrentAction)
                    {
                        case MirAction.Standing:
                            Libraries.Monsters[(ushort)Monster.TurtleKing].DrawBlend(456 + FrameIndex + (int)Direction * 4, DrawLocation, Color.White, true);
                            break;
                        case MirAction.Walking:
                            Libraries.Monsters[(ushort)Monster.TurtleKing].DrawBlend(488 + FrameIndex + (int)Direction * 6, DrawLocation, Color.White, true);
                            break;
                        case MirAction.Attack1:
                            Libraries.Monsters[(ushort)Monster.TurtleKing].DrawBlend(536 + FrameIndex + (int)Direction * 10, DrawLocation, Color.White, true);
                            break;
                        case MirAction.Struck:
                            Libraries.Monsters[(ushort)Monster.TurtleKing].DrawBlend(616 + FrameIndex + (int)Direction * 2, DrawLocation, Color.White, true);
                            break;
                        case MirAction.Die:
                        case MirAction.Revive:
                            Libraries.Monsters[(ushort)Monster.TurtleKing].DrawBlend(632 + FrameIndex + (int)Direction * 9, DrawLocation, Color.White, true);
                            break;
                        case MirAction.Attack2:
                            Libraries.Monsters[(ushort)Monster.TurtleKing].DrawBlend(704 + FrameIndex + (int)Direction * 6, DrawLocation, Color.White, true);
                            break;
                        case MirAction.AttackRange1:
                            Libraries.Monsters[(ushort)Monster.TurtleKing].DrawBlend(752 + FrameIndex + (int)Direction * 6, DrawLocation, Color.White, true);
                            break;
                        case MirAction.AttackRange2:
                            Libraries.Monsters[(ushort)Monster.TurtleKing].DrawBlend(800 + FrameIndex + (int)Direction * 6, DrawLocation, Color.White, true);
                            break;
                        case MirAction.AttackRange3:
                            Libraries.Monsters[(ushort)Monster.TurtleKing].DrawBlend(848 + FrameIndex + (int)Direction * 8, DrawLocation, Color.White, true);
                            break;
                    }
                    break;

                case Monster.WingedTigerLord:
                    switch (CurrentAction)
                    {
                        case MirAction.Attack1:
                            if (FrameIndex >= 2) Libraries.Monsters[(ushort)Monster.WingedTigerLord].DrawBlend(584 + (FrameIndex + (int)Direction * 6) - 2, DrawLocation, Color.White, true);
                            break;
                        case MirAction.Attack2:
                            if (FrameIndex >= 2) Libraries.Monsters[(ushort)Monster.WingedTigerLord].DrawBlend(560 + (FrameIndex + (int)Direction * 3) - 2, DrawLocation, Color.White, true);
                            break;
                    }
                    break;
                case Monster.StoningStatue:
                    switch (CurrentAction)
                    {
                        case MirAction.Attack1:
                            if (FrameIndex == 4)
                            {
                                SoundManager.PlaySound(BaseSound + 5);
                            }
                            break;
                        case MirAction.Attack2:
                            Libraries.Monsters[(ushort)Monster.StoningStatue].DrawBlend(464 + FrameIndex + (int)Direction * 20, DrawLocation, Color.White, true);
                            break;
                    }
                    break;
                case Monster.FlameSpear:
                case Monster.FlameMage:
                case Monster.FlameScythe:
                case Monster.FlameAssassin:
                    switch (CurrentAction)
                    {
                        case MirAction.Standing:
                            Libraries.Monsters[(ushort)BaseImage].DrawBlend(272 + FrameIndex + (int)Direction * 4, DrawLocation, Color.White, true);
                            break;
                        case MirAction.Walking:
                            Libraries.Monsters[(ushort)BaseImage].DrawBlend(304 + FrameIndex + (int)Direction * 6, DrawLocation, Color.White, true);
                            break;
                        case MirAction.Attack1:
                            Libraries.Monsters[(ushort)BaseImage].DrawBlend(352 + FrameIndex + (int)Direction * 6, DrawLocation, Color.White, true);
                            break;
                        case MirAction.Struck:
                            Libraries.Monsters[(ushort)BaseImage].DrawBlend(400 + FrameIndex + (int)Direction * 2, DrawLocation, Color.White, true);
                            break;
                        case MirAction.Die:
                            Libraries.Monsters[(ushort)BaseImage].DrawBlend(416 + FrameIndex + (int)Direction * 10, DrawLocation, Color.White, true);
                            break;
                        case MirAction.AttackRange1:
                            Libraries.Monsters[(ushort)BaseImage].DrawBlend(496 + FrameIndex + (int)Direction * 6, DrawLocation, Color.White, true);
                            if (BaseImage == Monster.FlameScythe && (int)Direction > 0)
                            {
                                Libraries.Monsters[(ushort)BaseImage].DrawBlend(544 + FrameIndex + (int)Direction * 6 - 6, DrawLocation, Color.White, true);
                            }
                            else if (BaseImage == Monster.FlameAssassin)
                            {
                                Libraries.Monsters[(ushort)BaseImage].DrawBlend(544 + FrameIndex + (int)Direction * 6, DrawLocation, Color.White, true);
                            }
                            break;
                    }
                    break;
                case Monster.FlameQueen:
                    switch (CurrentAction)
                    {
                        case MirAction.Standing:
                            Libraries.Monsters[(ushort)Monster.FlameQueen].DrawBlend(360 + FrameIndex + (int)Direction * 4, DrawLocation, Color.White, true);
                            break;
                        case MirAction.Walking:
                            Libraries.Monsters[(ushort)Monster.FlameQueen].DrawBlend(392 + FrameIndex + (int)Direction * 6, DrawLocation, Color.White, true);
                            break;
                        case MirAction.Attack1:
                            Libraries.Monsters[(ushort)Monster.FlameQueen].DrawBlend(440 + FrameIndex + (int)Direction * 6, DrawLocation, Color.White, true);
                            break;
                        case MirAction.Struck:
                            Libraries.Monsters[(ushort)Monster.FlameQueen].DrawBlend(488 + FrameIndex + (int)Direction * 2, DrawLocation, Color.White, true);
                            break;
                        case MirAction.Die:
                            Libraries.Monsters[(ushort)Monster.FlameQueen].DrawBlend(504 + FrameIndex + (int)Direction * 10, DrawLocation, Color.White, true);
                            break;
                        case MirAction.AttackRange1:
                            Libraries.Monsters[(ushort)Monster.FlameQueen].DrawBlend(584 + FrameIndex + (int)Direction * 9, DrawLocation, Color.White, true);
                            break;
                    }
                    break;
                case Monster.HellKnight1:
                case Monster.HellKnight2:
                case Monster.HellKnight3:
                case Monster.HellKnight4:
                    switch (CurrentAction)
                    {
                        case MirAction.Appear:
                            Libraries.Monsters[(ushort)BaseImage].DrawBlend(224 + FrameIndex + (int)Direction * 4, DrawLocation, Color.White, true);
                            break;
                        case MirAction.Standing:
                            Libraries.Monsters[(ushort)BaseImage].DrawBlend(224 + FrameIndex + (int)Direction * 4, DrawLocation, Color.White, true);
                            break;
                        case MirAction.Walking:
                            Libraries.Monsters[(ushort)BaseImage].DrawBlend(256 + FrameIndex + (int)Direction * 6, DrawLocation, Color.White, true);
                            break;
                        case MirAction.Attack1:
                            Libraries.Monsters[(ushort)BaseImage].DrawBlend(304 + FrameIndex + (int)Direction * 6, DrawLocation, Color.White, true);
                            break;
                        case MirAction.Struck:
                            Libraries.Monsters[(ushort)BaseImage].DrawBlend(352 + FrameIndex + (int)Direction * 2, DrawLocation, Color.White, true);
                            break;
                        case MirAction.Die:
                            Libraries.Monsters[(ushort)BaseImage].DrawBlend(368 + FrameIndex + (int)Direction * 4, DrawLocation, Color.White, true);
                            break;
                        case MirAction.Attack2:
                            Libraries.Monsters[(ushort)BaseImage].DrawBlend(400 + FrameIndex + (int)Direction * 6, DrawLocation, Color.White, true);
                            break;
                    }
                    break;
                case Monster.HellLord:
                    switch (CurrentAction)
                    {
                        case MirAction.Standing:
                        case MirAction.Attack1:
                        case MirAction.Struck:
                            Libraries.Monsters[(ushort)Monster.HellLord].Draw(15, DrawLocation, Color.White, true);
                            break;
                        case MirAction.Die:
                            Libraries.Monsters[(ushort)Monster.HellLord].Draw(16 + FrameIndex, DrawLocation, Color.White, true);
                            break;
                        case MirAction.Dead:
                            Libraries.Monsters[(ushort)Monster.HellLord].Draw(20, DrawLocation, Color.White, true);
                            break;
                    }
                    break;
                case Monster.WaterGuard:
                    switch (CurrentAction)
                    {
                        case MirAction.Attack2:
                            if (FrameIndex >= 4) Libraries.Monsters[(ushort)Monster.WaterGuard].DrawBlend(264 + (FrameIndex + (int)Direction * 3) - 4, DrawLocation, Color.White, true);
                            break;
                    }
                    break;
                case Monster.HardenRhino:
                    switch (CurrentAction)
                    {
                        case MirAction.Running:
                            Libraries.Monsters[(ushort)Monster.HardenRhino].DrawBlend(397 + FrameIndex + (int)Direction * 6, DrawLocation, Color.White, true);
                            break;
                    }
                    break;
                case Monster.AncientBringer:
                    switch (CurrentAction)
                    {
                        case MirAction.AttackRange1:
                            if (FrameIndex >= 3) Libraries.Monsters[(ushort)Monster.AncientBringer].DrawBlend((648 + FrameIndex + (int)Direction * 5) - 3, DrawLocation, Color.White, true);
                            break; //on mob
                        case MirAction.AttackRange2:
                            if (FrameIndex >= 3) Libraries.Monsters[(ushort)Monster.AncientBringer].DrawBlend((730 + FrameIndex + (int)Direction * 10) - 3, DrawLocation, Color.White, true);
                            break; //on mob
                    }
                    break;
                case Monster.BurningZombie:
                    switch (CurrentAction)
                    {
                        case MirAction.AttackRange1:
                            Libraries.Monsters[(ushort)Monster.BurningZombie].DrawBlend(352 + FrameIndex, DrawLocation, Color.White, true);
                            break;
                    }
                    break;
                case Monster.MudZombie:
                    switch (CurrentAction)
                    {
                        case MirAction.Die:
                            Libraries.Monsters[(ushort)Monster.MudZombie].DrawBlend(304 + FrameIndex, DrawLocation, Color.White, true);
                            break;
                    }
                    break;
                case Monster.BlackHammerCat:
                    switch (CurrentAction)
                    {
                        case MirAction.Standing:
                            Libraries.Monsters[(ushort)Monster.BlackHammerCat].DrawBlend(336 + FrameIndex + (int)Direction * 4, DrawLocation, Color.White, true);
                            break;
                        case MirAction.Walking:
                            Libraries.Monsters[(ushort)Monster.BlackHammerCat].DrawBlend(368 + FrameIndex + (int)Direction * 6, DrawLocation, Color.White, true);
                            break;
                        case MirAction.Attack1:
                            Libraries.Monsters[(ushort)Monster.BlackHammerCat].DrawBlend(416 + FrameIndex + (int)Direction * 7, DrawLocation, Color.White, true);
                            break;
                        case MirAction.Attack2:
                            Libraries.Monsters[(ushort)Monster.BlackHammerCat].DrawBlend(472 + FrameIndex + (int)Direction * 12, DrawLocation, Color.White, true);
                            break;
                        case MirAction.Struck:
                            Libraries.Monsters[(ushort)Monster.BlackHammerCat].DrawBlend(568 + FrameIndex + (int)Direction * 3, DrawLocation, Color.White, true);
                            break;
                        case MirAction.Die:
                            Libraries.Monsters[(ushort)Monster.BlackHammerCat].DrawBlend(589 + FrameIndex + (int)Direction * 7, DrawLocation, Color.White, true);
                            break;
                    }
                    break;
                case Monster.StrayCat:
                    switch (CurrentAction)
                    {
                        case MirAction.Attack3:
                            Libraries.Monsters[(ushort)Monster.StrayCat].DrawBlend(632 + FrameIndex + (int)Direction * 12, DrawLocation, Color.White, true);
                            break;
                    }
                    break;
                case Monster.CatShaman:
                    switch (CurrentAction)
                    {
                        case MirAction.Standing:
                            Libraries.Monsters[(ushort)Monster.CatShaman].DrawBlend(360 + FrameIndex + (int)Direction * 4, DrawLocation, Color.White, true);
                            break;
                        case MirAction.Walking:
                            Libraries.Monsters[(ushort)Monster.CatShaman].DrawBlend(392 + FrameIndex + (int)Direction * 10, DrawLocation, Color.White, true);
                            break;
                        case MirAction.Attack1:
                            Libraries.Monsters[(ushort)Monster.CatShaman].DrawBlend(472 + FrameIndex + (int)Direction * 6, DrawLocation, Color.White, true);
                            break;
                        case MirAction.AttackRange1:
                            Libraries.Monsters[(ushort)Monster.CatShaman].DrawBlend(520 + FrameIndex + (int)Direction * 7, DrawLocation, Color.White, true);
                            break;
                        case MirAction.AttackRange2:
                            Libraries.Monsters[(ushort)Monster.CatShaman].DrawBlend(576 + FrameIndex + (int)Direction * 7, DrawLocation, Color.White, true);
                            Libraries.Monsters[(ushort)Monster.CatShaman].DrawBlend(746 + FrameIndex, DrawLocation, Color.White, true);
                            break;
                        case MirAction.Struck:
                            Libraries.Monsters[(ushort)Monster.CatShaman].DrawBlend(632 + FrameIndex + (int)Direction * 2, DrawLocation, Color.White, true);
                            break;
                        case MirAction.Die:
                            Libraries.Monsters[(ushort)Monster.CatShaman].DrawBlend(648 + FrameIndex + (int)Direction * 9, DrawLocation, Color.White, true);
                            break;
                    }
                    break;
                case Monster.TucsonGeneral:
                    switch (CurrentAction)
                    {
                        case MirAction.Attack1:
                            if (FrameIndex >= 2) Libraries.Monsters[(ushort)Monster.TucsonGeneral].DrawBlend((504 + FrameIndex + (int)Direction * 5) - 2, DrawLocation, Color.White, true);
                            break;
                    }
                    break;
                case Monster.RhinoWarrior:
                    switch (CurrentAction)
                    {
                        case MirAction.Attack1:
                            Libraries.Monsters[(ushort)Monster.RhinoWarrior].DrawBlend(320 + FrameIndex + (int)Direction * 7, DrawLocation, Color.White, true);
                            break;
                    }
                    break;
                case Monster.TreeGuardian:
                    switch (CurrentAction)
                    {
                        case MirAction.Attack2:
                            if (FrameIndex >= 5) Libraries.Monsters[(ushort)Monster.TreeGuardian].DrawBlend(608 + FrameIndex + (int)Direction * 5, DrawLocation, Color.White, true);
                            break;
                    }
                    break;
                case Monster.OmaWitchDoctor:
                    switch (CurrentAction)
                    {
                        case MirAction.Standing:
                            Libraries.Monsters[(ushort)Monster.OmaWitchDoctor].DrawBlend(400 + FrameIndex + (int)Direction * 9, DrawLocation, Color.White, true);
                            break;
                        case MirAction.Walking:
                            Libraries.Monsters[(ushort)Monster.OmaWitchDoctor].DrawBlend(472 + FrameIndex + (int)Direction * 6, DrawLocation, Color.White, true);
                            break;
                        case MirAction.Attack1:
                            Libraries.Monsters[(ushort)Monster.OmaWitchDoctor].DrawBlend(520 + FrameIndex + (int)Direction * 7, DrawLocation, Color.White, true);
                            break;
                        case MirAction.AttackRange1:
                            Libraries.Monsters[(ushort)Monster.OmaWitchDoctor].DrawBlend(576 + FrameIndex + (int)Direction * 7, DrawLocation, Color.White, true);
                            break;
                        case MirAction.AttackRange2:
                            Libraries.Monsters[(ushort)Monster.OmaWitchDoctor].DrawBlend(632 + FrameIndex + (int)Direction * 9, DrawLocation, Color.White, true);
                            break;
                        case MirAction.Struck:
                            Libraries.Monsters[(ushort)Monster.OmaWitchDoctor].DrawBlend(704 + FrameIndex + (int)Direction * 3, DrawLocation, Color.White, true);
                            break;
                        case MirAction.Die:
                            Libraries.Monsters[(ushort)Monster.OmaWitchDoctor].DrawBlend(727 + FrameIndex + (int)Direction * 8, DrawLocation, Color.White, true);
                            break;
                    }
                    break;
                case Monster.PlagueCrab:
                    switch (CurrentAction)
                    {
                        case MirAction.Standing:
                            Libraries.Monsters[(ushort)Monster.PlagueCrab].DrawBlend(248 + FrameIndex + (int)Direction * 4, DrawLocation, Color.White, true);
                            break;
                        case MirAction.Walking:
                            Libraries.Monsters[(ushort)Monster.PlagueCrab].DrawBlend(280 + FrameIndex + (int)Direction * 6, DrawLocation, Color.White, true);
                            break;
                        case MirAction.Attack1:
                            Libraries.Monsters[(ushort)Monster.PlagueCrab].DrawBlend(328 + FrameIndex + (int)Direction * 8, DrawLocation, Color.White, true);
                            break;
                        case MirAction.Struck:
                            Libraries.Monsters[(ushort)Monster.PlagueCrab].DrawBlend(392 + FrameIndex + (int)Direction * 3, DrawLocation, Color.White, true);
                            break;
                        case MirAction.Die:
                            Libraries.Monsters[(ushort)Monster.PlagueCrab].DrawBlend(423 + FrameIndex + (int)Direction * 7, DrawLocation, Color.White, true);
                            break;
                    }
                    break;
                case Monster.ClawBeast:
                    switch (CurrentAction)
                    {
                        case MirAction.Standing:
                            Libraries.Monsters[(ushort)Monster.ClawBeast].DrawBlend(256 + FrameIndex + (int)Direction * 4, DrawLocation, Color.White, true);
                            break;
                        case MirAction.Walking:
                            Libraries.Monsters[(ushort)Monster.ClawBeast].DrawBlend(288 + FrameIndex + (int)Direction * 6, DrawLocation, Color.White, true);
                            break;
                        case MirAction.Attack1:
                            Libraries.Monsters[(ushort)Monster.ClawBeast].DrawBlend(336 + FrameIndex + (int)Direction * 10, DrawLocation, Color.White, true);
                            break;
                        case MirAction.Struck:
                            Libraries.Monsters[(ushort)Monster.ClawBeast].DrawBlend(416 + FrameIndex + (int)Direction * 3, DrawLocation, Color.White, true);
                            break;
                        case MirAction.Die:
                            Libraries.Monsters[(ushort)Monster.ClawBeast].DrawBlend(440 + FrameIndex + (int)Direction * 8, DrawLocation, Color.White, true);
                            break;
                    }
                    break;
                case Monster.DarkCaptain:
                    switch (CurrentAction)
                    {
                        case MirAction.Standing:
                            Libraries.Monsters[(ushort)Monster.DarkCaptain].DrawBlend(584 + FrameIndex + (int)Direction * 10, DrawLocation, Color.White, true);
                            break;
                        case MirAction.Walking:
                            Libraries.Monsters[(ushort)Monster.DarkCaptain].DrawBlend(664 + FrameIndex + (int)Direction * 8, DrawLocation, Color.White, true);
                            break;
                        case MirAction.Attack1:
                            Libraries.Monsters[(ushort)Monster.DarkCaptain].DrawBlend(728 + FrameIndex + (int)Direction * 7, DrawLocation, Color.White, true);
                            break;
                        case MirAction.Attack2:
                            Libraries.Monsters[(ushort)Monster.DarkCaptain].DrawBlend(784 + FrameIndex + (int)Direction * 7, DrawLocation, Color.White, true);
                            break;
                        case MirAction.AttackRange1:
                            Libraries.Monsters[(ushort)Monster.DarkCaptain].DrawBlend(840 + FrameIndex + (int)Direction * 7, DrawLocation, Color.White, true);
                            break;
                        case MirAction.AttackRange2:
                            Libraries.Monsters[(ushort)Monster.DarkCaptain].DrawBlend(896 + FrameIndex + (int)Direction * 7, DrawLocation, Color.White, true);
                            break;
                        case MirAction.Attack3:
                            Libraries.Monsters[(ushort)Monster.DarkCaptain].DrawBlend(952 + FrameIndex + (int)Direction * 7, DrawLocation, Color.White, true);
                            break;
                        case MirAction.AttackRange3:
                            Libraries.Monsters[(ushort)Monster.DarkCaptain].DrawBlend(1008 + FrameIndex + (int)Direction * 7, DrawLocation, Color.White, true);
                            break;
                        case MirAction.Struck:
                            Libraries.Monsters[(ushort)Monster.DarkCaptain].DrawBlend(1064 + FrameIndex + (int)Direction * 3, DrawLocation, Color.White, true);
                            break;
                        case MirAction.Die:
                            Libraries.Monsters[(ushort)Monster.DarkCaptain].DrawBlend(1088 + FrameIndex + (int)Direction * 10, DrawLocation, Color.White, true);
                            break;
                    }
                    break;
                case Monster.FrozenGolem:
                    switch (CurrentAction)
                    {
                        case MirAction.Standing:
                            Libraries.Monsters[(ushort)Monster.FrozenGolem].DrawBlend(264 + FrameIndex + (int)Direction * 4, DrawLocation, Color.White, true);
                            break;
                        case MirAction.Walking:
                            Libraries.Monsters[(ushort)Monster.FrozenGolem].DrawBlend(296 + FrameIndex + (int)Direction * 6, DrawLocation, Color.White, true);
                            break;
                        case MirAction.Attack1:
                            Libraries.Monsters[(ushort)Monster.FrozenGolem].DrawBlend(344 + FrameIndex + (int)Direction * 8, DrawLocation, Color.White, true);
                            break;
                        case MirAction.Die:
                            Libraries.Monsters[(ushort)Monster.FrozenGolem].DrawBlend(408 + FrameIndex + (int)Direction * 12, DrawLocation, Color.White, true);
                            break;
                    }
                    break;
                case Monster.IcePhantom:
                    switch (CurrentAction)
                    {
                        case MirAction.Standing:
                            Libraries.Monsters[(ushort)Monster.IcePhantom].DrawBlend(320 + FrameIndex + (int)Direction * 4, DrawLocation, Color.White, true);
                            break;
                        case MirAction.Walking:
                            Libraries.Monsters[(ushort)Monster.IcePhantom].DrawBlend(352 + FrameIndex + (int)Direction * 6, DrawLocation, Color.White, true);
                            break;
                        case MirAction.Attack1:
                            Libraries.Monsters[(ushort)Monster.IcePhantom].DrawBlend(400 + FrameIndex + (int)Direction * 9, DrawLocation, Color.White, true);
                            break;
                        case MirAction.AttackRange1:
                            Libraries.Monsters[(ushort)Monster.IcePhantom].DrawBlend(472 + FrameIndex + (int)Direction * 8, DrawLocation, Color.White, true);
                            break;
                        case MirAction.AttackRange2:
                            Libraries.Monsters[(ushort)Monster.IcePhantom].DrawBlend(472 + FrameIndex + (int)Direction * 8, DrawLocation, Color.White, true);
                            break;
                        case MirAction.Struck:
                            Libraries.Monsters[(ushort)Monster.IcePhantom].DrawBlend(536 + FrameIndex + (int)Direction * 3, DrawLocation, Color.White, true);
                            break;
                        case MirAction.Die:
                            Libraries.Monsters[(ushort)Monster.IcePhantom].DrawBlend(560 + FrameIndex + (int)Direction * 10, DrawLocation, Color.White, true);
                            break;
                    }
                    break;

                case Monster.HornedMage:
                    {
                        switch (CurrentAction)
                        {
                            case MirAction.Standing:
                                Libraries.Monsters[(ushort)Monster.HornedMage].DrawBlend((384 + FrameIndex + (int)Direction * 4), DrawLocation, Color.White, true);
                                break;
                            case MirAction.Walking:
                                Libraries.Monsters[(ushort)Monster.HornedMage].DrawBlend((416 + FrameIndex + (int)Direction * 6), DrawLocation, Color.White, true);
                                break;
                            case MirAction.Attack1:
                                Libraries.Monsters[(ushort)Monster.HornedMage].DrawBlend((464 + FrameIndex + (int)Direction * 8), DrawLocation, Color.White, true);
                                break;
                            case MirAction.AttackRange1:
                                Libraries.Monsters[(ushort)Monster.HornedMage].DrawBlend((528 + FrameIndex + (int)Direction * 9), DrawLocation, Color.White, true);
                                break;
                            case MirAction.AttackRange2:
                                Libraries.Monsters[(ushort)Monster.HornedMage].DrawBlend((600 + FrameIndex + (int)Direction * 8), DrawLocation, Color.White, true);
                                break;
                            case MirAction.Struck:
                                Libraries.Monsters[(ushort)Monster.HornedMage].DrawBlend((664 + FrameIndex + (int)Direction * 3), DrawLocation, Color.White, true);
                                break;
                            case MirAction.Die:
                                Libraries.Monsters[(ushort)Monster.HornedMage].DrawBlend((688 + FrameIndex + (int)Direction * 10), DrawLocation, Color.White, true);
                                break;
                        }
                    }
                    break;
                case Monster.Kirin:
                    {
                        switch (CurrentAction)
                        {
                            case MirAction.Standing:
                                Libraries.Monsters[(ushort)Monster.Kirin].DrawBlend((392 + FrameIndex + (int)Direction * 4), DrawLocation, Color.White, true);
                                break;
                            case MirAction.Walking:
                                Libraries.Monsters[(ushort)Monster.Kirin].DrawBlend((496 + FrameIndex + (int)Direction * 6), DrawLocation, Color.White, true);
                                break;
                            case MirAction.Attack1:
                                Libraries.Monsters[(ushort)Monster.Kirin].DrawBlend((544 + FrameIndex + (int)Direction * 7), DrawLocation, Color.White, true);
                                break;
                            case MirAction.Attack2:
                                Libraries.Monsters[(ushort)Monster.Kirin].DrawBlend((600 + FrameIndex + (int)Direction * 12), DrawLocation, Color.White, true);
                                break;
                            case MirAction.Attack3:
                                Libraries.Monsters[(ushort)Monster.Kirin].DrawBlend((696 + FrameIndex + (int)Direction * 6), DrawLocation, Color.White, true);
                                break;
                            case MirAction.Struck:
                                Libraries.Monsters[(ushort)Monster.Kirin].DrawBlend((744 + FrameIndex + (int)Direction * 3), DrawLocation, Color.White, true);
                                break;
                            case MirAction.Die:
                                Libraries.Monsters[(ushort)Monster.Kirin].DrawBlend((744 + FrameIndex + (int)Direction * 1) - 1, DrawLocation, Color.White, true);
                                break;
                        }
                    }
                    break;
                case Monster.DarkWraith:
                    {
                        switch (CurrentAction)
                        {
                            case MirAction.Standing:
                                Libraries.Monsters[(ushort)Monster.DarkWraith].DrawBlend((360 + FrameIndex + (int)Direction * 4), DrawLocation, Color.White, true);
                                break;
                            case MirAction.Walking:
                                Libraries.Monsters[(ushort)Monster.DarkWraith].DrawBlend((392 + FrameIndex + (int)Direction * 6), DrawLocation, Color.White, true);
                                break;
                            case MirAction.Attack1:
                                Libraries.Monsters[(ushort)Monster.DarkWraith].DrawBlend((440 + FrameIndex + (int)Direction * 8), DrawLocation, Color.White, true);
                                break;
                            case MirAction.Attack2:
                                Libraries.Monsters[(ushort)Monster.DarkWraith].DrawBlend((504 + FrameIndex + (int)Direction * 10), DrawLocation, Color.White, true);
                                break;
                            case MirAction.Attack3:
                                Libraries.Monsters[(ushort)Monster.DarkWraith].DrawBlend((584 + FrameIndex + (int)Direction * 4), DrawLocation, Color.White, true);
                                break;
                            case MirAction.Struck:
                                Libraries.Monsters[(ushort)Monster.DarkWraith].DrawBlend((616 + FrameIndex + (int)Direction * 3), DrawLocation, Color.White, true);
                                break;
                            case MirAction.Die:
                                Libraries.Monsters[(ushort)Monster.DarkWraith].DrawBlend((640 + FrameIndex + (int)Direction * 10), DrawLocation, Color.White, true);
                                break;
                        }
                        break;
                    }
                case Monster.DarkSpirit:
                    {
                        switch (CurrentAction)
                        {
                            case MirAction.Standing:
                                Libraries.Monsters[(ushort)Monster.DarkSpirit].DrawBlend((256 + FrameIndex + (int)Direction * 4), DrawLocation, Color.White, true);
                                break;
                            case MirAction.Walking:
                                Libraries.Monsters[(ushort)Monster.DarkSpirit].DrawBlend((288 + FrameIndex + (int)Direction * 6), DrawLocation, Color.White, true);
                                break;
                            case MirAction.AttackRange1:
                                Libraries.Monsters[(ushort)Monster.DarkSpirit].DrawBlend((336 + FrameIndex + (int)Direction * 9), DrawLocation, Color.White, true);
                                break;
                            case MirAction.Struck:
                                Libraries.Monsters[(ushort)Monster.DarkSpirit].DrawBlend((408 + FrameIndex + (int)Direction * 3), DrawLocation, Color.White, true);
                                break;
                            case MirAction.Die:
                                Libraries.Monsters[(ushort)Monster.DarkSpirit].DrawBlend((432 + FrameIndex + (int)Direction * 10), DrawLocation, Color.White, true);
                                break;
                        }
                        break;
                    }
                case Monster.LightningBead:
                    switch (CurrentAction)
                    {
                        case MirAction.Standing:
                            Libraries.Monsters[(ushort)Monster.LightningBead].DrawBlend(30 + FrameIndex, DrawLocation, Color.White, true);
                            break;
                        case MirAction.AttackRange1:
                            Libraries.Monsters[(ushort)Monster.LightningBead].DrawBlend(37 + FrameIndex, DrawLocation, Color.White, true);
                            break;
                        case MirAction.Struck:
                            Libraries.Monsters[(ushort)Monster.LightningBead].DrawBlend(43 + FrameIndex, DrawLocation, Color.White, true);
                            break;
                        case MirAction.Die:
                            Libraries.Monsters[(ushort)Monster.LightningBead].DrawBlend(50 + FrameIndex, DrawLocation, Color.White, true);
                            break;
                        case MirAction.Appear:
                            Libraries.Monsters[(ushort)Monster.LightningBead].DrawBlend(58 + FrameIndex, DrawLocation, Color.White, true);
                            break;
                    }
                    break;
                case Monster.HealingBead:
                    switch (CurrentAction)
                    {
                        case MirAction.Standing:
                            Libraries.Monsters[(ushort)Monster.HealingBead].DrawBlend(30 + FrameIndex, DrawLocation, Color.White, true);
                            break;
                        case MirAction.AttackRange1:
                            Libraries.Monsters[(ushort)Monster.HealingBead].DrawBlend(37 + FrameIndex, DrawLocation, Color.White, true);
                            break;
                        case MirAction.Struck:
                            Libraries.Monsters[(ushort)Monster.HealingBead].DrawBlend(43 + FrameIndex, DrawLocation, Color.White, true);
                            break;
                        case MirAction.Die:
                            Libraries.Monsters[(ushort)Monster.HealingBead].DrawBlend(46 + FrameIndex, DrawLocation, Color.White, true);
                            break;
                        case MirAction.Appear:
                            Libraries.Monsters[(ushort)Monster.HealingBead].DrawBlend(54 + FrameIndex, DrawLocation, Color.White, true);
                            break;
                    }
                    break;
                case Monster.PowerUpBead:
                    switch (CurrentAction)
                    {
                        case MirAction.Standing:
                            Libraries.Monsters[(ushort)Monster.PowerUpBead].DrawBlend(30 + FrameIndex, DrawLocation, Color.White, true);
                            break;
                        case MirAction.AttackRange1:
                            Libraries.Monsters[(ushort)Monster.PowerUpBead].DrawBlend(37 + FrameIndex, DrawLocation, Color.White, true);
                            break;
                        case MirAction.Struck:
                            Libraries.Monsters[(ushort)Monster.PowerUpBead].DrawBlend(43 + FrameIndex, DrawLocation, Color.White, true);
                            break;
                        case MirAction.Die:
                            Libraries.Monsters[(ushort)Monster.PowerUpBead].DrawBlend(49 + FrameIndex, DrawLocation, Color.White, true);
                            break;
                        case MirAction.Appear:
                            Libraries.Monsters[(ushort)Monster.PowerUpBead].DrawBlend(58 + FrameIndex, DrawLocation, Color.White, true);
                            break;
                    }
                    break;
                case Monster.DarkOmaKing:
                    switch (CurrentAction)
                    {
                        case MirAction.Standing:
                            Libraries.Monsters[(ushort)Monster.DarkOmaKing].DrawBlend((784 + FrameIndex + (int)Direction * 10), DrawLocation, Color.White, true);
                            break;
                        case MirAction.Walking:
                            Libraries.Monsters[(ushort)Monster.DarkOmaKing].DrawBlend((864 + FrameIndex + (int)Direction * 6), DrawLocation, Color.White, true);
                            break;
                        case MirAction.Attack1:
                            Libraries.Monsters[(ushort)Monster.DarkOmaKing].DrawBlend((912 + FrameIndex + (int)Direction * 9), DrawLocation, Color.White, true);
                            break;
                        case MirAction.Attack2:
                            Libraries.Monsters[(ushort)Monster.DarkOmaKing].DrawBlend((984 + FrameIndex + (int)Direction * 34), DrawLocation, Color.White, true);
                            break;
                        case MirAction.Attack3:
                            Libraries.Monsters[(ushort)Monster.DarkOmaKing].DrawBlend((1256 + FrameIndex + (int)Direction * 8), DrawLocation, Color.White, true);
                            break;
                        case MirAction.Attack4:
                            Libraries.Monsters[(ushort)Monster.DarkOmaKing].DrawBlend((1320 + FrameIndex + (int)Direction * 9), DrawLocation, Color.White, true);
                            break;
                        case MirAction.AttackRange1:
                            Libraries.Monsters[(ushort)Monster.DarkOmaKing].DrawBlend((1392 + FrameIndex + (int)Direction * 9), DrawLocation, Color.White, true);
                            break;
                        case MirAction.Struck:
                            Libraries.Monsters[(ushort)Monster.DarkOmaKing].DrawBlend((1464 + FrameIndex + (int)Direction * 3), DrawLocation, Color.White, true);
                            break;
                        case MirAction.Die:
                            Libraries.Monsters[(ushort)Monster.DarkOmaKing].DrawBlend((1488 + FrameIndex + (int)Direction * 10), DrawLocation, Color.White, true);
                            break;
                    }
                    break;
                case Monster.HornedWarrior:
                    {
                        switch (CurrentAction)
                        {
                            case MirAction.Standing:
                                Libraries.Monsters[(ushort)Monster.HornedWarrior].DrawBlend((376 + FrameIndex + (int)Direction * 4), DrawLocation, Color.White, true);
                                break;
                            case MirAction.Walking:
                                Libraries.Monsters[(ushort)Monster.HornedWarrior].DrawBlend((408 + FrameIndex + (int)Direction * 6), DrawLocation, Color.White, true);
                                break;
                            case MirAction.Attack1:
                                Libraries.Monsters[(ushort)Monster.HornedWarrior].DrawBlend((456 + FrameIndex + (int)Direction * 8), DrawLocation, Color.White, true);
                                break;
                            case MirAction.Attack2:
                                Libraries.Monsters[(ushort)Monster.HornedWarrior].DrawBlend((520 + FrameIndex + (int)Direction * 9), DrawLocation, Color.White, true);
                                break;
                            case MirAction.Attack3:
                                Libraries.Monsters[(ushort)Monster.HornedWarrior].DrawBlend((592 + FrameIndex + (int)Direction * 8), DrawLocation, Color.White, true);
                                break;                   
                            case MirAction.Struck:
                                Libraries.Monsters[(ushort)Monster.HornedWarrior].DrawBlend((656 + FrameIndex + (int)Direction * 3), DrawLocation, Color.White, true);
                                break;
                            case MirAction.Die:
                                Libraries.Monsters[(ushort)Monster.HornedWarrior].DrawBlend((680 + FrameIndex + (int)Direction * 9), DrawLocation, Color.White, true);
                                break;
                        }
                        break;
                    }
                case Monster.FloatingRock:
                    {
                        switch (CurrentAction)
                        {
                            case MirAction.AttackRange1:
                                if (FrameIndex <= 6) Libraries.Monsters[(ushort)Monster.FloatingRock].DrawBlend(160 + (FrameIndex) + (int)Direction * 7, DrawLocation, Color.White, true);
                                break;
                        }
                        break;
                    }
                case Monster.FrostTiger:
                    {
                        if (Effect == 1)
                            switch (CurrentAction)
                            {
                                case MirAction.Standing:
                                    Libraries.Monsters[(ushort)Monster.ManTree].DrawBlend((528 + FrameIndex + (int)Direction * 4), DrawLocation, Color.Gray, true);
                                    break;
                                case MirAction.Walking:
                                    Libraries.Monsters[(ushort)Monster.ManTree].DrawBlend((560 + FrameIndex + (int)Direction * 6), DrawLocation, Color.Gray, true);
                                    break;
                                case MirAction.Attack1:
                                    Libraries.Monsters[(ushort)Monster.ManTree].DrawBlend((608 + FrameIndex + (int)Direction * 6), DrawLocation, Color.Gray, true);
                                    break;
                                case MirAction.Struck:
                                    Libraries.Monsters[(ushort)Monster.ManTree].DrawBlend((656 + FrameIndex + (int)Direction * 2), DrawLocation, Color.Gray, true);
                                    break;
                                case MirAction.Die:
                                    Libraries.Monsters[(ushort)Monster.ManTree].DrawBlend((672 + FrameIndex + (int)Direction * 10), DrawLocation, Color.Gray, true);
                                    break;
                                case MirAction.AttackRange1:
                                    Libraries.Monsters[(ushort)Monster.ManTree].DrawBlend((752 + FrameIndex + (int)Direction * 6), DrawLocation, Color.Gray, true);
                                    break;
                                case MirAction.SitDown:
                                    Libraries.Monsters[(ushort)Monster.ManTree].DrawBlend((800 + FrameIndex + (int)Direction * 4), DrawLocation, Color.Gray, true);
                                    break;
                            }
                        break;
                    }
                case Monster.WaterDragon:
                    {
                        switch (CurrentAction)
                        {
                            case MirAction.Show:
                                Libraries.Monsters[(ushort)Monster.WaterDragon].DrawBlend(400 + FrameIndex + (int)Direction * 8, DrawLocation, Color.White, true);
                                break;
                            case MirAction.Standing:
                                Libraries.Monsters[(ushort)Monster.WaterDragon].DrawBlend(464 + FrameIndex + (int)Direction * 6, DrawLocation, Color.White, true);
                                break;
                            case MirAction.AttackRange1:
                                Libraries.Monsters[(ushort)Monster.WaterDragon].DrawBlend(512 + FrameIndex + (int)Direction * 8, DrawLocation, Color.White, true);
                                break;
                            case MirAction.Attack1:
                                Libraries.Monsters[(ushort)Monster.WaterDragon].DrawBlend(576 + FrameIndex + (int)Direction * 10, DrawLocation, Color.White, true);
                                break;
                            case MirAction.Struck:
                                Libraries.Monsters[(ushort)Monster.WaterDragon].DrawBlend(656 + FrameIndex + (int)Direction * 3, DrawLocation, Color.White, true);
                                break;
                            case MirAction.Die:
                                Libraries.Monsters[(ushort)Monster.WaterDragon].DrawBlend(680 + FrameIndex + (int)Direction * 15, DrawLocation, Color.White, true);
                                break;
                            case MirAction.Hide:
                                Libraries.Monsters[(ushort)Monster.WaterDragon].DrawBlend(407 + (FrameIndex * -1) + (int)Direction * 8, DrawLocation, Color.White, true);
                                break;
                        }
                        break;
                    }

            } //END OF DRAW EFFECTS
        }

        public override void DrawName()
        {
            if (!Name.Contains("_"))
            {
                base.DrawName();
                return;
            }

            string[] splitName = Name.Split('_');

            //IntelligentCreature
            int yOffset = 0;
            switch (BaseImage)
            {
                case Monster.Chick:
                    yOffset = -10;
                    break;
                case Monster.BabyPig:
                case Monster.Kitten:
                case Monster.BabySkeleton:
                case Monster.Baekdon:
                case Monster.Wimaen:
                case Monster.BlackKitten:
                case Monster.BabyDragon:
                case Monster.OlympicFlame:
                case Monster.BabySnowMan:
                case Monster.Frog:
                case Monster.BabyMonkey:
                case Monster.AngryBird:
                case Monster.Foxey:
                case Monster.MedicalRat:
                    yOffset = -20;
                    break;
            }

            for (int s = 0; s < splitName.Count(); s++)
            {
                CreateMonsterLabel(splitName[s], s);

                TempLabel.Text = splitName[s];
                TempLabel.Location = new Point(DisplayRectangle.X + (48 - TempLabel.Size.Width) / 2, DisplayRectangle.Y - (32 - TempLabel.Size.Height / 2) + (Dead ? 35 : 8) - (((splitName.Count() - 1) * 10) / 2) + (s * 12) + yOffset);
                TempLabel.Draw();
            }
        }

        public void CreateMonsterLabel(string word, int wordOrder)
        {
            TempLabel = null;

            for (int i = 0; i < LabelList.Count; i++)
            {
                if (LabelList[i].Text != word) continue;
                TempLabel = LabelList[i];
                break;
            }

            if (TempLabel != null && !TempLabel.IsDisposed && NameColour == OldNameColor) return;

            OldNameColor = NameColour;

            TempLabel = new MirLabel
            {
                AutoSize = true,
                BackColour = Color.Transparent,
                ForeColour = NameColour,
                OutLine = true,
                OutLineColour = Color.Black,
                Text = word,
            };

            TempLabel.Disposing += (o, e) => LabelList.Remove(TempLabel);
            LabelList.Add(TempLabel);
        }

        public override void DrawChat()
        {
            if (ChatLabel == null || ChatLabel.IsDisposed) return;

            if (CMain.Time > ChatTime)
            {
                ChatLabel.Dispose();
                ChatLabel = null;
                return;
            }

            //IntelligentCreature
            int yOffset = 0;
            switch (BaseImage)
            {
                case Monster.Chick:
                    yOffset = 30;
                    break;
                case Monster.BabyPig:
                case Monster.Kitten:
                case Monster.BabySkeleton:
                case Monster.Baekdon:
                case Monster.Wimaen:
                case Monster.BlackKitten:
                case Monster.BabyDragon:
                case Monster.OlympicFlame:
                case Monster.BabySnowMan:
                case Monster.Frog:
                case Monster.BabyMonkey:
                case Monster.AngryBird:
                case Monster.Foxey:
                case Monster.MedicalRat:
                    yOffset = 20;
                    break;
            }

            ChatLabel.ForeColour = Dead ? Color.Gray : Color.White;
            ChatLabel.Location = new Point(DisplayRectangle.X + (48 - ChatLabel.Size.Width) / 2, DisplayRectangle.Y - (60 + ChatLabel.Size.Height) - (Dead ? 35 : 0) + yOffset);
            ChatLabel.Draw();
        }
    }
}
