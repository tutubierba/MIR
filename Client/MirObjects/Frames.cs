using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Client.MirObjects
{
    public class FrameSet : Dictionary<MirAction, Frame>
    {
        public static FrameSet Player;
        public static FrameSet DefaultNPC, IceCrystalSoldier, SnowYeti, FrozenMagician, DefaultMonster, SqSacrifice, GlacierWarrior, ShardGuardian, FrozenGolem, BestKing, Riklebites, Windblade, Butcher, Serpentirian, AncientStoneGolem, UndeadHammerDwarf, UndeadDwarfArcher,BlueMutantPlant, RedMutantPlant, WarBear, Swain, NobleAssassin,NoblePriest, NobleArcher, NobleWarrior, ArcherDwarf, HammerDwarf,MutantGuardian, MutantBeserker, MutantHighPriest, ReaperPriest,ReaperWizard, ReaperAssassin, MysteriousAssassin, BlueMonk, MysteriousMage, MysteriousMonk, FeatheredWolf, LivingVines, ManEatingPlant, SqArcherSoul, SqBuddhaSoul, SqGuru0verLord, SqGuruBloodWizard, SqWizardSoul, SqAssassinSoul,SqTaoistSoul, SqChampion, SqWarriorSoul, SqWarlock, SqSkeletonsoldier, SqAssassin, SqTerraWarrior, RedFaeFlower, Manticore, SqAlizard, Sqmouse, SqTombMonster, SqWarrior, SqBalrog, SqWoodenbox, Sq0rgan, SqTerraArcher,Sqmoth;
        public static FrameSet HoodedSummoner, DarkWraith, SnowWolfKing, FrozenKnight, FrozenArcher, FrozenFighter, FrozenSoldier, CharmedSnake, Jar2, Jar1, FightingCat, FireCat, StainHammerCat, BlackHammerCat, StrayCat, RestlessJar,SandSnail, CannibalTentacles, TucsonFighter, TucsonWarrior, FrozenZombie, WhiteMammoth, DeathCrawler, BurningZombie, ZumaTaurus, DarkDevil, PurpleFaeFlower, GlacierSnail, FurbolgWarrior, FurbolgArcher, FurbolgGuard, FurbolgCommander, GlacierBeast, WereTiger, SackWarrior, Hydrax, KingHydrax, HornedMage, HornedArcher, ColdArcher, HornedWarrior, FloatingRock, ScalyBeast, BoulderSpirit, HornedSorceror, PeacockSpider, HornedCommander, Mandrill, PlagueCrab, Nadz, CreeperPlant, FloatingWraith, ArmedPlant, AvengerPlant, AvengingSpirit, AxePlant, AvengingWarrior, WoodBox, ClawBeast, BlueSoul, DarkCaptain, YangDevilNode, YinDevilNode, HoodedPriest, Furball, ShardMaiden, HoodedIceMage, ABBC;
        public static FrameSet KingHog, GreenTurtle, DarkGhost, Football, ArcherGuard3, Guard3, CrystalBeast, DarkSpirit, FrozenAxeman, FrozenMiner, SnowWolf, ArcherGuard, Guard, TaoistGuard, Guard2, CatWidow, CatShaman, SeedingsGeneral, GeneralMeowMeow, PlaguedTucson, Armadillo, ArmadilloElder, VisceralWorm, Tucson, TucsonMage, TucsonGeneral, MudZombie, DemonWolf, UndeadWolf, DarkBeast, LightBeast, HardenRhino, BloodBaboon, AncientBringer, WaterDragon, BlackTortoise, DragonWarrior, DragonArcher, Tornado , Kirin, FrostTiger, ManTree, Bear, Turtlegrass, Leopard, ChieftainArcher, ChieftainSword, DarkWingedOma, DarkBaboon, TwinHeadBeast, OmaCannibal, OmaBlest, OmaSlasher, OmaAssassin, OmaMage, OmaWitchDoctor, LightningBead, HealingBead, PowerUpBead, DarkOmaKing, GasToad, Mantis, SwampWarrior, AssassinBird, RhinoWarrior, RhinoPriest, ElephantMan, StoneGolem, EarthGolem, TreeGuardian, TreeQueen, EvilTongs, EvilSnake, Ghoul, ZumaArcher, ZumaStatue, ZumaGuardian, WoomaGuardian, WhiteBoar, KingScorpion,WoomaTaurus;
        public static FrameSet HellPirate, TurtleKing, LightTurtle, FinialTurtle, TowerTurtle, BlueTurtle, RedTurtle, KatanaGuard, BombSpider, RootSpider, SpiderBat, VenomSpider, GangSpider, GreatSpider, LureSpider, BigApe, GrayEvilApe, RedEvilApe, CrystalSpider, RedMoonEvil, EvilApe, ValeBat, Weaver, FlamingMutant, CrackingWeaver, ArmingWeaver, CrystalWeaver, GreaterWeaver, SpiderWarrior, FrozenZumaGuardian, FrozenZumaStatue, FlyingStatue, StoningStatue, ToxicGhoul, RoninGhoul, BoneArcher, BoneBlademan, BoneSpearman, BoneCaptain, BoneLord, Minotaur, IceMinotaur, ElectricMinotaur, WindMinotaur, FireMinotaur, RightGuard, LeftGuard, MinotaurKing, AxeOma, SwordOma, CrossbowOma, WingedOma, FlailOma, OmaGuard, OmaKing, ManectricHammer, ManectricClub, ManectricClaw, ManectricStaff, ManectricBlest, ManectricKing, Blank2, IcePillar, GhastlyLeecher, MutatedManworm, CrazyManworm, CyanoGhast, DreamDevourer, DarkDevourer, HellSlasher,HellCannibal, HellBolt, WitchDoctor, HellKeeper;
        public static FrameSet DigOutZombie, DarkTurtle, BoneFamiliar, Shinsu, HolyDeva, VampireSpider, SpittingToad, SnakeTotem, IcePhantom, Hen, Deer, Pig, Bull, Sheep, Wolf, Yob, Scarecrow, HookingCat, RakingCat, SpittingSpider, CannibalPlant, Oma, OmaFighter, OmaWarrior, ForestYeti, ChestnutTree, EbonyTree, CherryTree, LargeMushroom, RedSnake, TigerSnake, Keratoid, ShellNipper, SkyStinger, SandWorm, GiantKeratoid, CaveBat, CaveMaggot, Scorpion, AxeSkeleton, Skeleton, BoneFighter, BoneWarrior, BoneElite, BoneWhoo, CrawlerZombie, BlueSnake, YellowSnake, GiantWhiteSnake, Yimoogi, Treasurebox, Centipede, GiantWorm, WhimperingBee, Tongs, EvilCentipede, WedgeMoth, BugBat, BugBatMaggot, BlackMaggot, SnakeScorpion, RedBoar, BlackBoar, BigRat, RedThunderZuma, RedFoxman, BlackFoxman, WhiteFoxman, TrapRock, GuardianRock, ThunderElement, CloudElement, HedgeKekTal, BigHedgeKekTal, BrownFrogSpider, RedFrogSpider, SpiderFrog, HoroBlaster, BlueHoroBlaster, KekTal, VioletKekTal, Khazard, Dark, Dung, WoomaSoldier, WoomaFighter, WoomaWarrior, FlamingWooma, ShamanZombie, ClZombie, NdZombie;
        public static FrameSet TrollBomber, KingKong, Kite, Ram1, Ram2, AngryReindeer, Doe, CargoBoxwithlogo, AntCommander, FatalLotus, WhiteOrb, GreenOrb, YellowOrb, BlueOrb, RedOrb, TucsonEgg, Bunny, Snake17, Snake16, Snake15, Snake13, Snake12, Snake11, Snake10, MutatedHugger, PoisonHugger, DemonGuard, ElementGuard, WaterGuard, IceGuard, FrostYeti, ChaosGhost, NamelessGhost, LionRiderFemale, LionRiderMale, BattleStandard, SiegeRepairman, Shinsu1, ArcherGuard2, Bush, ChristmasTree, HighAssassin, DarkDustPile, DarkBrownWolf, GingerBreadman, HalloweenScythe, MudPile, TailedLion, SnowPile, Snowman, SnowTree, GiantEgg, Catapult2, OldSpittingSpider, BlueSanta, RedYimoogi, FlameTiger, WingedTigerLord, AssassinScroll, WizardScroll, TaoistScroll, WarriorScroll,  Snake14, Behemoth, HellLord, HellKnight4, HellKnight3, HellKnight2, HellKnight1, FlameQueen, TrollKing, FlameAssassin, FlameScythe, FlameSpear, FlameMage, TrollStoner, TrollHammer, ManectricSlave;
        public static List<FrameSet> DragonStatue,  GreatFoxSpirit, HellBomb, CaveStatue;

        static FrameSet()
        {
            FrameSet frame;

            Player = new FrameSet();

            //Default NPC
            DefaultNPC = new FrameSet
            {
                { MirAction.Standing, new Frame(0, 4, 0, 450) },
                { MirAction.Harvest, new Frame(12, 10, 0, 200) }
            };

            //Default Monster
            DefaultMonster = new FrameSet
            {
                { MirAction.Standing, new Frame(0, 8, 0, 500) },
                { MirAction.Walking, new Frame(64, 6, 0, 100) },
                { MirAction.Attack1, new Frame(176, 8, 0, 100) },
                { MirAction.Struck, new Frame(112, 8, 0, 200) },
                { MirAction.Die, new Frame(144, 10, 0, 100) },
                { MirAction.Dead, new Frame(153, 1, 9, 1000) },
                { MirAction.Revive, new Frame(144, 10, 0, 100) { Reverse = true } }
            };

            RedFaeFlower = new FrameSet           //教母雪花动作帧
            {
                { MirAction.Standing, new Frame(0, 8, 0, 250) },
                { MirAction.Walking, new Frame(64, 6, 0, 100) },
                { MirAction.Attack1, new Frame(176, 6, 0, 100) },
                { MirAction.AttackRange1, new Frame(112, 8, 0, 100) },
                { MirAction.AttackRange2, new Frame(224, 9, 0, 100) },
                { MirAction.AttackRange3, new Frame(296, 7, 0, 100) },
                { MirAction.Struck, new Frame(352, 5, 0, 100) },
                { MirAction.Die, new Frame(392, 9, 0, 100) },
                { MirAction.Dead, new Frame(400, 1, 8, 1000) },
                { MirAction.Revive, new Frame(392, 9, 0, 100) { Reverse = true } }
            };
            Manticore = new FrameSet           //穷奇动作帧
            {
                { MirAction.Standing, new Frame(0, 4, 0, 500) },
                { MirAction.Walking, new Frame(112, 8, 0, 100) },
                { MirAction.Attack1, new Frame(176, 8, 0, 100) },
                { MirAction.Attack2, new Frame(240, 7, 0, 100) },
                { MirAction.Attack3, new Frame(296, 7, 0, 100) },
                { MirAction.Struck, new Frame(352, 3, 0, 200) },
                { MirAction.Die, new Frame(376, 15, 0, 100) },
                { MirAction.Dead, new Frame(390, 1, 14, 1000) },
                { MirAction.Revive, new Frame(376, 15, 0, 100) { Reverse = true } }
            };
            
            Sqmoth = new FrameSet           //毒蛾动作帧
            {
                { MirAction.Standing, new Frame(0, 6, 4, 500) },
                { MirAction.Walking, new Frame(80, 6, 4, 200) },
                { MirAction.Attack1, new Frame(160, 8, 2, 100) },
                { MirAction.Attack2, new Frame(240, 9, 1, 100) },
                { MirAction.Struck, new Frame(320, 3, 7, 300) },
                { MirAction.Die, new Frame(400, 10, 0, 100) },
                { MirAction.Dead, new Frame(409, 1, 9, 1000) },
                { MirAction.Revive, new Frame(400, 10, 0, 100) { Reverse = true } }
            };

            SqAlizard = new FrameSet           //变异蜥蜴动作帧
            {
                { MirAction.Standing, new Frame(0, 6, 4, 500) },
                { MirAction.Walking, new Frame(80, 6, 4, 200) },
                { MirAction.Attack1, new Frame(160, 8, 2, 100) },
                { MirAction.Attack2, new Frame(240, 8, 2, 100) },
                { MirAction.Struck, new Frame(320, 3, 7, 300) },
                { MirAction.Die, new Frame(400, 10, 0, 100) },
                { MirAction.Dead, new Frame(409, 1, 9, 1000) },
                { MirAction.Revive, new Frame(400, 10, 0, 100) { Reverse = true } }
            };

            Sqmouse = new FrameSet           //变异老鼠动作帧
            {
                { MirAction.Standing, new Frame(0, 6, 4, 500) },
                { MirAction.Walking, new Frame(80, 6, 4, 200) },
                { MirAction.Attack1, new Frame(160, 8, 2, 100) },
                { MirAction.Struck, new Frame(240, 3, 7, 300) },
                { MirAction.Die, new Frame(320, 9, 1, 100) },
                { MirAction.Dead, new Frame(328, 1, 9, 1000) },
                { MirAction.Revive, new Frame(320, 9, 1, 100) { Reverse = true } }
            };

            SqTombMonster = new FrameSet           //镇墓兽动作帧
            {
                { MirAction.Stoned, new Frame(0, 1, 9, 100) },
                { MirAction.Show, new Frame(80, 7, 3, 200) },
                { MirAction.Standing, new Frame(160, 6, 4, 500) },
                { MirAction.Walking, new Frame(240, 6, 4, 100) },
                { MirAction.Attack1, new Frame(320, 9, 1, 100) },
                { MirAction.Attack2, new Frame(400, 9, 1, 100) },
                { MirAction.Struck, new Frame(480, 3, 7, 200) },
                { MirAction.Die, new Frame(560, 10, 0, 100) },
                { MirAction.Dead, new Frame(569, 1, 9, 1000) },
                { MirAction.Revive, new Frame(560, 10, 0, 100) { Reverse = true } }

            };
            SqBalrog = new FrameSet           //守护炎魔动作帧
            {
                { MirAction.Standing, new Frame(0, 6, 4, 500) },
                { MirAction.Walking, new Frame(80, 4, 6, 200) },
                { MirAction.Attack1, new Frame(160, 7, 3, 100) },
                { MirAction.Attack2, new Frame(240, 9, 1, 100) },
                { MirAction.AttackRange1, new Frame(320, 8, 2, 100) },
                { MirAction.Struck, new Frame(400, 3, 7, 200) },
                { MirAction.Die, new Frame(480, 10, 0, 150) },
                { MirAction.Dead, new Frame(489, 1, 9, 1000) },
            };

            SqWoodenbox = new FrameSet           //木盒动作帧
            {
                { MirAction.Standing, new Frame(0, 1, 9, 300) },
                { MirAction.Walking, new Frame(80, 3, 7, 100) },
                { MirAction.Attack1, new Frame(80, 3, 7, 100) },
                { MirAction.Struck, new Frame(80, 3, 7, 100) },
                { MirAction.Die, new Frame(160, 7, 3, 200) },
                { MirAction.Dead, new Frame(166, 1, 9, 1000) },
            };
            Sq0rgan = new FrameSet           //秘密机关装置动作帧
            {
                { MirAction.Standing, new Frame(0, 6, 4, 500) },
                { MirAction.Walking, new Frame(80, 7, 3, 200) },
                { MirAction.Attack1, new Frame(160, 10, 0, 100) },
                { MirAction.Struck, new Frame(240, 3, 7, 200) },
                { MirAction.Die, new Frame(320, 10, 0, 200) },
                { MirAction.Dead, new Frame(329, 1, 9, 1000) },
            };
            SqTerraWarrior = new FrameSet           //陶俑枪兵动作帧
            {
                { MirAction.Standing, new Frame(0, 1, 9, 500) },
                { MirAction.Walking, new Frame(80, 6, 4, 200) },
                { MirAction.Attack1, new Frame(160, 9, 1, 100) },
                { MirAction.Attack2, new Frame(240, 10, 0, 100) },
                { MirAction.Struck, new Frame(320, 3, 7, 200) },
                { MirAction.Die, new Frame(400, 9, 1, 200) },
                { MirAction.Dead, new Frame(409, 1, 9, 1000) },
            };
            SqTerraArcher = new FrameSet           //陶俑弩兵动作帧
            {
                { MirAction.Standing, new Frame(0, 1, 9, 500) },
                { MirAction.Walking, new Frame(80, 6, 4, 200) },
                { MirAction.Attack1, new Frame(160, 6, 4, 100) },
                { MirAction.Struck, new Frame(240, 3, 7, 200) },
                { MirAction.Die, new Frame(320, 10, 0, 200) },
                { MirAction.Dead, new Frame(329, 1, 9, 1000) },
            };
            SqWarrior = new FrameSet           //修炼剑士动作帧
            {
                { MirAction.Standing, new Frame(0, 6, 4, 500) },
                { MirAction.Walking, new Frame(80, 6, 4, 200) },
                { MirAction.Attack1, new Frame(160, 10, 0, 100) },
                { MirAction.Attack2, new Frame(240, 10, 0, 100) },
                { MirAction.Struck, new Frame(320, 3, 7, 200) },
                { MirAction.Die, new Frame(400, 9, 1, 200) },
                { MirAction.Dead, new Frame(408, 1, 9, 1000) },
            };
            SqAssassin = new FrameSet           //修炼刺客动作帧
            {
                { MirAction.Standing, new Frame(0, 6, 4, 500) },
                { MirAction.Walking, new Frame(80, 6, 4, 200) },
                { MirAction.Attack1, new Frame(160, 10, 0, 100) },
                { MirAction.Attack2, new Frame(240, 10, 0, 100) },
                { MirAction.Struck, new Frame(320, 3, 7, 200) },
                { MirAction.Die, new Frame(400, 9, 1, 200) },
                { MirAction.Dead, new Frame(408, 1, 9, 1000) },
            };
            SqSkeletonsoldier = new FrameSet           //陈旧的遗骨动作帧
            {
                { MirAction.Stoned, new Frame(0, 6, 4, 100) },
                { MirAction.Show, new Frame(80, 3, 7, 250) },
                { MirAction.Standing, new Frame(160, 4, 6, 500) },
                { MirAction.Walking, new Frame(240, 4, 6, 200) },
                { MirAction.Attack1, new Frame(320, 8, 2, 100) },
                { MirAction.Struck, new Frame(400, 3, 7, 300) },
                { MirAction.Die, new Frame(480, 10, 0, 100) },
                { MirAction.Dead, new Frame(489, 1, 9, 1000) },
            };
            SqChampion = new FrameSet           //道场战士动作帧
            {
                { MirAction.Standing, new Frame(0, 6, 4, 500) },
                { MirAction.Walking, new Frame(80, 6, 4, 200) },
                { MirAction.Attack1, new Frame(160, 8, 2, 100) },
                { MirAction.Attack2, new Frame(240, 8, 2, 100) },
                { MirAction.Struck, new Frame(320, 3, 7, 200) },
                { MirAction.Die, new Frame(400, 9, 1, 100) },
                { MirAction.Dead, new Frame(408, 1, 9, 1000) },
            };
            SqWarlock = new FrameSet           //道场术士动作帧
            {
                { MirAction.Standing, new Frame(0, 6, 4, 500) },
                { MirAction.Walking, new Frame(80, 6, 4, 200) },
                { MirAction.Attack1, new Frame(160, 8, 2, 100) },
                { MirAction.Attack2, new Frame(240, 8, 2, 100) },
                { MirAction.Struck, new Frame(320, 3, 7, 200) },
                { MirAction.Die, new Frame(400, 9, 1, 100) },
                { MirAction.Dead, new Frame(408, 1, 9, 1000) },
            };
            SqSacrifice = new FrameSet           //道场禅僧动作帧
            {
                { MirAction.Standing, new Frame(160, 6, 4, 500) },
                { MirAction.Walking, new Frame(240, 6, 4, 200) },
                { MirAction.Attack1, new Frame(320, 8, 8, 100) },
                { MirAction.Attack2, new Frame(480, 9, 1, 100) },
                { MirAction.Struck, new Frame(640, 3, 7, 300) },
                { MirAction.Die, new Frame(720, 10, 0, 100) },
                { MirAction.Dead, new Frame(729, 1, 9, 1000) },
            };
            SqWarriorSoul = new FrameSet           //先代战士长老魂魄动作帧
            {
                { MirAction.Standing, new Frame(0, 6, 4, 500) },
                { MirAction.Walking, new Frame(80, 6, 4, 200) },
                { MirAction.Attack1, new Frame(160, 8, 2, 100) },
                { MirAction.Attack2, new Frame(240, 10, 0, 100) },
                { MirAction.Attack3, new Frame(320, 8, 2, 100) },
                { MirAction.Struck, new Frame(400, 4, 6, 300) },
                { MirAction.Die, new Frame(480, 10, 0, 100) },
                { MirAction.Dead, new Frame(487, 1, 9, 1000) },
                { MirAction.Revive, new Frame(480, 10, 0, 100) { Reverse = true } }
            };
            SqArcherSoul = new FrameSet           //先代弓手长老魂魄动作帧
            {
                { MirAction.Standing, new Frame(0, 6, 4, 500) },
                { MirAction.Walking, new Frame(80, 6, 4, 200) },
                { MirAction.AttackRange1, new Frame(160, 9, 1, 100) },
                { MirAction.AttackRange2, new Frame(240, 10, 0, 100) },
                { MirAction.Attack1, new Frame(320, 8, 2, 100) },
                { MirAction.Struck, new Frame(400, 3, 7, 300) },
                { MirAction.Die, new Frame(480, 8, 2, 100) },
                { MirAction.Dead, new Frame(487, 1, 9, 1000) },
                { MirAction.Revive, new Frame(480, 8, 2, 100) { Reverse = true } }
            };
            SqTaoistSoul = new FrameSet           //先代道士长老魂魄动作帧
            {
                { MirAction.Standing, new Frame(0, 6, 4, 500) },
                { MirAction.Walking, new Frame(80, 6, 4, 200) },
                { MirAction.Attack1, new Frame(160, 8, 2, 100) },
                { MirAction.Attack2, new Frame(240, 8, 2, 100) },
                { MirAction.Attack3, new Frame(320, 9, 1, 100) },
                { MirAction.AttackRange1, new Frame(240, 8, 2, 100) },
                { MirAction.Struck, new Frame(400, 3, 7, 200) },
                { MirAction.Die, new Frame(480, 10, 0, 100) },
                { MirAction.Dead, new Frame(489, 1, 9, 1000) },
                { MirAction.Revive, new Frame(480, 10, 0, 100) { Reverse = true } }
            };
            SqAssassinSoul = new FrameSet           //先代刺客长老魂魄动作帧
            {
                { MirAction.Standing, new Frame(0, 6, 4, 500) },
                { MirAction.Walking, new Frame(80, 6, 4, 200) },
                { MirAction.Attack1, new Frame(160, 7, 3, 100) },
                { MirAction.Attack2, new Frame(240, 8, 2, 100) },
                { MirAction.Attack3, new Frame(320, 9, 1, 100) },
                { MirAction.Struck, new Frame(400, 4, 6, 200) },
                { MirAction.Die, new Frame(480, 9, 1, 100) },
                { MirAction.Dead, new Frame(488, 1, 9, 1000) },
                { MirAction.Revive, new Frame(480, 9, 1, 100) { Reverse = true } }
            };
            SqWizardSoul = new FrameSet           //先代术士长老魂魄动作帧
            {
                { MirAction.Standing, new Frame(0, 6, 4, 500) },
                { MirAction.Walking, new Frame(80, 6, 4, 200) },
                { MirAction.Attack1, new Frame(160, 8, 2, 100) },
                { MirAction.Attack2, new Frame(240, 9, 1, 100) },
                { MirAction.AttackRange1, new Frame(320, 8, 2, 100) },
                { MirAction.Struck, new Frame(400, 3, 7, 300) },
                { MirAction.Die, new Frame(480, 10, 0, 100) },
                { MirAction.Dead, new Frame(489, 1, 9, 1000) },
                { MirAction.Revive, new Frame(480, 10, 0, 100) { Reverse = true } }
            };
            SqGuru0verLord = new FrameSet           //古代宗师霸皇动作帧
            {
                { MirAction.Standing, new Frame(0, 6, 4, 500) },
                { MirAction.Walking, new Frame(80, 6, 4, 200) },
                { MirAction.Attack1, new Frame(160, 9, 1, 100) },
                { MirAction.Attack2, new Frame(240, 10, 0, 100) },
                { MirAction.Attack3, new Frame(320, 10, 0, 100) },
                { MirAction.Struck, new Frame(560, 3, 7, 200) },
                { MirAction.Die, new Frame(640, 10, 0, 100) },
                { MirAction.Dead, new Frame(649, 1, 9, 1000) },
                { MirAction.Hide, new Frame(400, 9, 1, 100) },
                { MirAction.Show, new Frame(480, 9, 1, 100) },
            };
            SqGuruBloodWizard = new FrameSet           //古代宗师血魔动作帧
            {
                { MirAction.Standing, new Frame(0, 6, 4, 500) },
                { MirAction.Walking, new Frame(80, 6, 4, 200) },
                { MirAction.Attack1, new Frame(160, 9, 1, 100) },
                { MirAction.Attack2, new Frame(240, 10, 0, 100) },
                { MirAction.Attack3, new Frame(320, 10, 0, 100) },
                { MirAction.Struck, new Frame(560, 3, 7, 300) },
                { MirAction.Die, new Frame(640, 10, 0, 100) },
                { MirAction.Dead, new Frame(649, 1, 9, 1000) },
                { MirAction.Hide, new Frame(400, 10, 0, 100) },
                { MirAction.Show, new Frame(480, 10, 0, 100) },
            };
            SqBuddhaSoul = new FrameSet           //天尊的魂魄动作帧
            {
                { MirAction.Standing, new Frame(0, 8, 2, 500) },
                { MirAction.Walking, new Frame(80, 6, 4, 200) },
                { MirAction.Attack1, new Frame(160, 10, 0, 100) },
                { MirAction.Attack2, new Frame(240, 10, 0, 100) },
                { MirAction.Attack3, new Frame(320, 10, 0, 100) },
                { MirAction.AttackRange1, new Frame(400, 9, 1, 100) },
                { MirAction.AttackRange2, new Frame(480, 9, 1, 100) },
                { MirAction.Struck, new Frame(560, 3, 7, 300) },
                { MirAction.Die, new Frame(640, 10, 0, 100) },
                { MirAction.Dead, new Frame(649, 1, 9, 1000) },
                { MirAction.Appear, new Frame(760, 20, 0, 300) },
                { MirAction.AttackRange3, new Frame(320, 10, 0, 100) },
            };
            GlacierWarrior = new FrameSet      //士兵凯伊动作帧
            {
                { MirAction.Standing, new Frame(0, 6, 0, 500) },
                { MirAction.Walking, new Frame(48, 6, 4, 200) },
                { MirAction.Attack1, new Frame(96, 7, 0, 100) },
                { MirAction.Struck, new Frame(208, 3, 0, 300) },
                { MirAction.Die, new Frame(232, 8, 0, 100) },
                { MirAction.Dead, new Frame(239, 1, 7, 1000) },
                { MirAction.Revive, new Frame(232, 8, 0, 100) { Reverse = true } }
            };
            ManEatingPlant = new FrameSet           //变异食虫草动作帧
            {
                { MirAction.Show, new Frame(0, 6, 4, 100) },
                { MirAction.Standing, new Frame(80, 6, 4, 500) },
                { MirAction.Walking, new Frame(160, 9, 1, 200) },
                { MirAction.Attack1, new Frame(160, 7, 3, 100) },
                { MirAction.Attack2, new Frame(240, 8, 2, 100) },
                { MirAction.AttackRange1, new Frame(240, 8, 2, 100) },
                { MirAction.Struck, new Frame(320, 3, 7, 250) },
                { MirAction.Die, new Frame(400, 10, 0, 100) },
                { MirAction.Dead, new Frame(409, 1, 9, 1000) },
                { MirAction.Revive, new Frame(400, 10, 0, 100) { Reverse = true } }
            };
            LivingVines = new FrameSet           //变异极蔓草动作帧
            {
                { MirAction.Standing, new Frame(0, 6, 4, 500) },
                { MirAction.Walking, new Frame(80, 6, 4, 200) },
                { MirAction.Attack1, new Frame(160, 8, 2, 100) },
                { MirAction.Attack2, new Frame(240, 9, 1, 100) },
                { MirAction.AttackRange1, new Frame(240, 9, 1, 100) },
                { MirAction.Struck, new Frame(320, 3, 7, 250) },
                { MirAction.Show, new Frame(480, 6, 4, 200) },
                { MirAction.Die, new Frame(400, 10, 0, 100) },
                { MirAction.Dead, new Frame(409, 1, 9, 1000) },
                { MirAction.Hide, new Frame(480, 6, 4, 200) },
                { MirAction.Revive, new Frame(400, 10, 0, 100) { Reverse = true } }
            };
            FeatheredWolf = new FrameSet           //变异宠物狐狸动作帧
            {
                { MirAction.Standing, new Frame(0, 6, 4, 500) },
                { MirAction.Walking, new Frame(80, 6, 4, 200) },
                { MirAction.Attack1, new Frame(160, 7, 3, 100) },
                { MirAction.Attack2, new Frame(240, 9, 1, 100) },
                { MirAction.AttackRange1, new Frame(320, 10, 0, 100) },
                { MirAction.Struck, new Frame(400, 3, 7, 250) },
                { MirAction.Die, new Frame(480, 10, 0, 100) },
                { MirAction.Dead, new Frame(489, 1, 9, 1000) },
                { MirAction.Revive, new Frame(480, 10, 0, 100) { Reverse = true } }
            };
            WarBear = new FrameSet           //变异宠物熊动作帧
            {
                { MirAction.Standing, new Frame(0, 6, 4, 500) },
                { MirAction.Walking, new Frame(80, 6, 4, 200) },
                { MirAction.Attack1, new Frame(160, 8, 2, 100) },
                { MirAction.Attack2, new Frame(240, 9, 1, 100) },
                { MirAction.Struck, new Frame(320, 3, 7, 250) },
                { MirAction.Die, new Frame(400, 10, 0, 100) },
                { MirAction.Dead, new Frame(409, 1, 9, 1000) },
                { MirAction.Revive, new Frame(400, 10, 0, 100) { Reverse = true } }
            };
            MysteriousMonk = new FrameSet           //战士高手动作帧
            {
                { MirAction.Standing, new Frame(0, 8, 2, 500) },
                { MirAction.Walking, new Frame(80, 6, 4, 200) },
                { MirAction.Attack1, new Frame(160, 6, 4, 100) },
                { MirAction.Attack2, new Frame(240, 10, 0, 100) },
                { MirAction.Attack3, new Frame(320, 10, 0, 100) },
                { MirAction.AttackRange1, new Frame(320, 10, 0, 100) },
                { MirAction.Struck, new Frame(400, 3, 7, 250) },
                { MirAction.Die, new Frame(480, 10, 0, 100) },
                { MirAction.Dead, new Frame(489, 1, 9, 1000) },
                { MirAction.Revive, new Frame(480, 10, 0, 100) { Reverse = true } }
            };
            MysteriousMage = new FrameSet           //法师高手动作帧
            {
                { MirAction.Standing, new Frame(0, 6, 4, 500) },
                { MirAction.Walking, new Frame(80, 6, 4, 200) },
                { MirAction.Attack1, new Frame(160, 8, 2, 100) },
                { MirAction.Attack2, new Frame(240, 8, 2, 100) },
                { MirAction.AttackRange1, new Frame(320, 8, 2, 100) },
                { MirAction.Struck, new Frame(400, 3, 7, 250) },
                { MirAction.Die, new Frame(480, 10, 0, 100) },
                { MirAction.Dead, new Frame(489, 1, 9, 1000) },
                { MirAction.Revive, new Frame(480, 10, 0, 100) { Reverse = true } }
            };
            BlueMonk = new FrameSet           //道士高手动作帧
            {
                { MirAction.Standing, new Frame(0, 6, 4, 500) },
                { MirAction.Walking, new Frame(80, 6, 4, 200) },
                { MirAction.Attack1, new Frame(160, 8, 2, 100) },
                { MirAction.Attack2, new Frame(240, 8, 2, 100) },
                { MirAction.AttackRange1, new Frame(320, 8, 2, 100) },
                { MirAction.Struck, new Frame(400, 3, 7, 250) },
                { MirAction.Die, new Frame(480, 10, 0, 100) },
                { MirAction.Dead, new Frame(489, 1, 9, 1000) },
                { MirAction.Revive, new Frame(480, 10, 0, 100) { Reverse = true } }
            };
            MysteriousAssassin = new FrameSet           //刺客高手动作帧
            {
                { MirAction.Standing, new Frame(0, 6, 4, 500) },
                { MirAction.Walking, new Frame(80, 6, 4, 200) },
                { MirAction.Attack1, new Frame(160, 8, 2, 100) },
                { MirAction.Attack2, new Frame(240, 8, 2, 100) },
                { MirAction.Attack3, new Frame(320, 9, 1, 100) },
                { MirAction.Struck, new Frame(400, 3, 7, 250) },
                { MirAction.Die, new Frame(480, 10, 0, 100) },
                { MirAction.Dead, new Frame(489, 1, 9, 1000) },
                { MirAction.Revive, new Frame(480, 10, 0, 100) { Reverse = true } }
            };
            ReaperAssassin = new FrameSet           //尼尔刺客动作帧
            {
                { MirAction.Standing, new Frame(0, 6, 4, 500) },
                { MirAction.Walking, new Frame(80, 6, 4, 200) },
                { MirAction.Attack1, new Frame(160, 10, 0, 100) },
                { MirAction.Attack2, new Frame(240, 5, 5, 100) },
                { MirAction.Attack3, new Frame(320, 5, 5, 100) },
                { MirAction.Attack4, new Frame(400, 10, 0, 100) },
                { MirAction.Struck, new Frame(480, 3, 7, 250) },
                { MirAction.Die, new Frame(560, 10, 0, 100) },
                { MirAction.Dead, new Frame(568, 1, 9, 1000) },
                { MirAction.Revive, new Frame(560, 10, 0, 100) { Reverse = true } }
            };
            ReaperWizard = new FrameSet           //尼尔术士动作帧
            {
                { MirAction.Standing, new Frame(0, 6, 4, 500) },
                { MirAction.Walking, new Frame(80, 6, 4, 200) },
                { MirAction.Attack1, new Frame(160, 8, 2, 100) },
                { MirAction.Attack2, new Frame(240, 8, 2, 100) },
                { MirAction.Attack3, new Frame(320, 8, 2, 100) },
                { MirAction.Struck, new Frame(400, 3, 7, 250) },
                { MirAction.Die, new Frame(480, 10, 0, 100) },
                { MirAction.Dead, new Frame(489, 1, 9, 1000) },
                { MirAction.Revive, new Frame(480, 10, 0, 100) { Reverse = true } }
            };
            ReaperPriest = new FrameSet           //尼尔道士动作帧
            {
                { MirAction.Standing, new Frame(0, 6, 4, 500) },
                { MirAction.Walking, new Frame(80, 6, 4, 200) },
                { MirAction.Attack1, new Frame(160, 8, 2, 100) },
                { MirAction.Attack2, new Frame(240, 8, 2, 100) },
                { MirAction.Attack3, new Frame(320, 8, 2, 100) },
                { MirAction.Attack4, new Frame(320, 10, 0, 100) },
                { MirAction.Struck, new Frame(480, 3, 7, 250) },
                { MirAction.Die, new Frame(560, 10, 0, 100) },
                { MirAction.Dead, new Frame(568, 1, 9, 1000) },
                { MirAction.Revive, new Frame(560, 10, 0, 100) { Reverse = true } }
            };
            MutantHighPriest = new FrameSet           //变异项锁奥玛动作帧
            {
                { MirAction.Standing, new Frame(0, 6, 4, 500) },
                { MirAction.Walking, new Frame(80, 6, 4, 200) },
                { MirAction.Attack1, new Frame(160, 8, 2, 100) },
                { MirAction.Attack2, new Frame(240, 10, 0, 100) },
                { MirAction.AttackRange1, new Frame(240, 10, 0, 100) },
                { MirAction.Struck, new Frame(320, 3, 7, 250) },
                { MirAction.Die, new Frame(400, 10, 0, 100) },
                { MirAction.Dead, new Frame(409, 1, 9, 1000) },
                { MirAction.Revive, new Frame(400, 10, 0, 100) { Reverse = true } }
            };
            MutantBeserker = new FrameSet           //变异多头奥玛动作帧
            {
                { MirAction.Standing, new Frame(0, 6, 4, 500) },
                { MirAction.Walking, new Frame(80, 6, 4, 200) },
                { MirAction.Attack1, new Frame(160, 10, 0, 100) },
                { MirAction.Attack2, new Frame(240, 10, 0, 100) },
                { MirAction.Struck, new Frame(320, 3, 7, 250) },
                { MirAction.Die, new Frame(400, 9, 1, 100) },
                { MirAction.Dead, new Frame(408, 1, 9, 1000) },
                { MirAction.Revive, new Frame(400, 10, 0, 100) { Reverse = true } }
            };
            MutantGuardian = new FrameSet           //变异巨头奥玛动作帧
            {
                { MirAction.Standing, new Frame(0, 8, 2, 500) },
                { MirAction.Walking, new Frame(80, 6, 4, 200) },
                { MirAction.Attack1, new Frame(160, 10, 0, 100) },
                { MirAction.Attack2, new Frame(240, 8, 2, 100) },
                { MirAction.Attack3, new Frame(320, 7, 3, 100) },
                { MirAction.AttackRange1, new Frame(320, 7, 3, 100) },
                { MirAction.Struck, new Frame(400, 3, 7, 250) },
                { MirAction.Die, new Frame(480, 9, 1, 100) },
                { MirAction.Dead, new Frame(488, 1, 9, 1000) },
                { MirAction.Revive, new Frame(480, 9, 1, 100) { Reverse = true } }
            };
            HammerDwarf = new FrameSet             //毒妖族战士动作帧
            {
                { MirAction.Standing, new Frame(0, 6, 4, 500) },
                { MirAction.Walking, new Frame(80, 6, 4, 200) },
                { MirAction.Attack1, new Frame(160, 8, 2, 100) },
                { MirAction.Attack2, new Frame(240, 9, 1, 100) },
                { MirAction.Attack3, new Frame(320, 8, 2, 100) },
                { MirAction.AttackRange1, new Frame(320, 8, 2, 100) },
                { MirAction.Struck, new Frame(400, 3, 7, 250) },
                { MirAction.Die, new Frame(480, 8, 2, 100) },
                { MirAction.Dead, new Frame(487, 1, 9, 1000) },
                { MirAction.Revive, new Frame(480, 8, 2, 100) { Reverse = true } }
            };
            ArcherDwarf = new FrameSet             //毒妖族弓手动作帧
            {
                { MirAction.Standing, new Frame(0, 6, 4, 500) },
                { MirAction.Walking, new Frame(80, 6, 4, 200) },
                { MirAction.Attack1, new Frame(160, 7, 3, 100) },
                { MirAction.Attack2, new Frame(240, 9, 1, 100) },
                { MirAction.AttackRange2, new Frame(160, 7, 3, 100) },
                { MirAction.AttackRange1, new Frame(240, 9, 1, 100) },
                { MirAction.Struck, new Frame(320, 3, 7, 250) },
                { MirAction.Die, new Frame(400, 8, 2, 100) },
                { MirAction.Dead, new Frame(407, 1, 9, 1000) },
                { MirAction.Revive, new Frame(400, 8, 2, 100) { Reverse = true } }
            };
            NobleWarrior = new FrameSet           //战士长老_天尊动作帧
            {
                { MirAction.Standing, new Frame(0, 6, 4, 500) },
                { MirAction.Walking, new Frame(80, 6, 4, 200) },
                { MirAction.Attack1, new Frame(160, 8, 2, 100) },
                { MirAction.Attack2, new Frame(240, 8, 0, 100) },
                { MirAction.Attack3, new Frame(320, 8, 2, 100) },
                { MirAction.Struck, new Frame(400, 4, 6, 250) },
                { MirAction.Die, new Frame(480, 8, 2, 100) },
                { MirAction.Dead, new Frame(487, 1, 9, 1000) },
                { MirAction.Revive, new Frame(480, 8, 2, 100) { Reverse = true } }
            };
            NobleArcher = new FrameSet            //弓手长老_无极帝动作帧
            {
                { MirAction.Standing, new Frame(0, 6, 4, 500) },
                { MirAction.Walking, new Frame(80, 6, 4, 200) },
                { MirAction.Attack1, new Frame(160, 9, 1, 100) },
                { MirAction.Attack2, new Frame(240, 10, 0, 100) },
                { MirAction.Attack3, new Frame(320, 8, 2, 100) },
                { MirAction.AttackRange1, new Frame(240, 10, 0, 100) },
                { MirAction.AttackRange2, new Frame(320, 8, 2, 100) },
                { MirAction.Struck, new Frame(400, 3, 7, 250) },
                { MirAction.Die, new Frame(480, 8, 2, 100) },
                { MirAction.Dead, new Frame(487, 1, 9, 1000) },
                { MirAction.Revive, new Frame(480, 8, 2, 100) { Reverse = true } }
            };
            NoblePriest = new FrameSet            //道士长老_医仙动作帧
            {
                { MirAction.Standing, new Frame(0, 6, 4, 500) },
                { MirAction.Walking, new Frame(80, 6, 4, 200) },
                { MirAction.Attack1, new Frame(160, 8, 2, 100) },
                { MirAction.Attack2, new Frame(240, 8, 0, 100) },
                { MirAction.Attack3, new Frame(320, 9, 1, 100) },
                { MirAction.AttackRange1, new Frame(320, 9, 1, 100) },
                { MirAction.Struck, new Frame(400, 3, 7, 250) },
                { MirAction.Die, new Frame(480, 10, 0, 100) },
                { MirAction.Dead, new Frame(489, 1, 9, 1000) },
                { MirAction.Revive, new Frame(480, 10, 0, 100) { Reverse = true } }
            };
            NobleAssassin = new FrameSet         //刺客长老_魔灵动作帧
            {
                { MirAction.Standing, new Frame(0, 6, 4, 500) },
                { MirAction.Walking, new Frame(80, 6, 4, 200) },
                { MirAction.Attack1, new Frame(160, 8, 2, 150) },
                { MirAction.Attack2, new Frame(240, 9, 1, 150) },
                { MirAction.Attack3, new Frame(320, 9, 1, 150) },
                { MirAction.Struck, new Frame(400, 3, 7, 250) },
                { MirAction.Die, new Frame(480, 9, 1, 100) },
                { MirAction.Dead, new Frame(488, 1, 9, 1000) },
                { MirAction.Revive, new Frame(480, 9, 1, 100) { Reverse = true } }
            };
            Swain = new FrameSet                //堕落的法师长老_雷帝_红花草动作帧
            {
                { MirAction.Standing, new Frame(0, 6, 4, 500) },
                { MirAction.Walking, new Frame(80, 6, 4, 200) },
                { MirAction.Attack1, new Frame(160, 8, 2, 100) },
                { MirAction.Attack2, new Frame(240, 9, 1, 100) },
                { MirAction.Attack3, new Frame(320, 9, 1, 100) },
                { MirAction.Struck, new Frame(400, 3, 7, 250) },
                { MirAction.Die, new Frame(480, 9, 1, 100) },
                { MirAction.Dead, new Frame(488, 1, 9, 1000) },
                { MirAction.Revive, new Frame(480, 9, 1, 100) { Reverse = true } }
            };
            RedMutantPlant = new FrameSet       //毒妖林_红花草动作帧
            {
                { MirAction.Standing, new Frame(0, 10, 0, 500) },
                { MirAction.Walking, new Frame(80, 6, 4, 200) },
                { MirAction.Attack1, new Frame(160, 6, 4, 100) },
                { MirAction.Struck, new Frame(240, 3, 7, 200) },
                { MirAction.Die, new Frame(320, 10, 0, 100) },
                { MirAction.Dead, new Frame(329, 1, 9, 1000) },
                { MirAction.Revive, new Frame(329, 1, 9, 100) { Reverse = true } }
            };
            BlueMutantPlant = new FrameSet          //毒妖林_青花草动作帧
            {
                { MirAction.Standing, new Frame(0, 10, 0, 500) },
                { MirAction.Walking, new Frame(80, 6, 4, 200) },
                { MirAction.Attack1, new Frame(160, 6, 4, 100) },
                { MirAction.Struck, new Frame(240, 3, 7, 200) },
                { MirAction.Die, new Frame(320, 10, 0, 100) },
                { MirAction.Dead, new Frame(329, 1, 9, 1000) },
                { MirAction.Revive, new Frame(329, 1, 9, 100) { Reverse = true } }
            };
            UndeadHammerDwarf = new FrameSet      //变异毒妖战士动作帧
            {
                { MirAction.Standing, new Frame(0, 7, 3, 500) },
                { MirAction.Walking, new Frame(80, 6, 4, 200) },
                { MirAction.Attack1, new Frame(160, 10, 0, 100) },
                { MirAction.Attack2, new Frame(160, 10, 0, 100) },
                { MirAction.Attack3, new Frame(160, 10, 0, 100) },
                { MirAction.Struck, new Frame(240, 3, 7, 250) },
                { MirAction.Die, new Frame(320, 8, 2, 100) },
                { MirAction.Dead, new Frame(327, 1, 9, 1000) },
                { MirAction.Revive, new Frame(320, 8, 2, 100) { Reverse = true } }
            };
            UndeadDwarfArcher = new FrameSet       //变异毒妖弓手动作帧
            {
                { MirAction.Standing, new Frame(0, 6, 4, 500) },
                { MirAction.Walking, new Frame(80, 6, 4, 200) },
                { MirAction.Attack1, new Frame(160, 7, 3, 100) },
                { MirAction.Attack2, new Frame(160, 7, 3, 100) },
                { MirAction.Attack3, new Frame(160, 7, 3, 100) },
                { MirAction.Struck, new Frame(240, 3, 7, 250) },
                { MirAction.Die, new Frame(320, 8, 2, 100) },
                { MirAction.Dead, new Frame(327, 1, 9, 1000) },
                { MirAction.Revive, new Frame(320, 8, 2, 100) { Reverse = true } }
            };
            AncientStoneGolem = new FrameSet      //变异昆仑石碑兽动作帧
            {
                { MirAction.Standing, new Frame(0, 6, 4, 500) },
                { MirAction.Walking, new Frame(80, 6, 4, 200) },
                { MirAction.Attack1, new Frame(160, 7, 3, 100) },
                { MirAction.Attack2, new Frame(240, 9, 1, 100) },
                { MirAction.Attack3, new Frame(320, 8, 1, 100) },
                { MirAction.Attack4, new Frame(320, 8, 1, 100) },
                { MirAction.Struck, new Frame(400, 3, 7, 250) },
                { MirAction.Die, new Frame(480, 10, 0, 100) },
                { MirAction.Dead, new Frame(489, 1, 9, 1000) },
                { MirAction.Revive, new Frame(480, 10, 0, 100) { Reverse = true } }
            };
            Serpentirian = new FrameSet          //变异多头毒妖鬼动作帧
            {
                { MirAction.Standing, new Frame(0, 6, 4, 500) },
                { MirAction.Walking, new Frame(80, 6, 4, 200) },
                { MirAction.Attack1, new Frame(160, 8, 2, 100) },
                { MirAction.Attack2, new Frame(240, 10, 0, 100) },
                { MirAction.Attack3, new Frame(320, 8, 2, 100) },
                { MirAction.Attack4, new Frame(320, 8, 2, 100) },
                { MirAction.Struck, new Frame(400, 3, 7, 250) },
                { MirAction.Die, new Frame(480, 9, 1, 100) },
                { MirAction.Dead, new Frame(488, 1, 9, 1000) },
                { MirAction.Revive, new Frame(480, 9, 1, 100) { Reverse = true } }
            };
            Butcher = new FrameSet        //变异巨型奥玛动作帧
            {
                { MirAction.Standing, new Frame(0, 6, 4, 500) },
                { MirAction.Walking, new Frame(80, 6, 4, 200) },
                { MirAction.Attack1, new Frame(160, 8, 2, 100) },
                { MirAction.Attack2, new Frame(240, 9, 1, 100) },
                { MirAction.Attack3, new Frame(320, 9, 1, 100) },
                { MirAction.Attack4, new Frame(400, 10, 0, 100) },
                { MirAction.AttackRange1, new Frame(480, 8, 2, 100) },
                { MirAction.AttackRange2, new Frame(480, 8, 2, 100) },
                { MirAction.Struck, new Frame(560, 3, 7, 250) },
                { MirAction.Die, new Frame(640, 7, 3, 100) },
                { MirAction.Dead, new Frame(646, 1, 9, 1000) },
                { MirAction.Revive, new Frame(640, 7, 3, 100) { Reverse = true } }
            }; 
             Riklebites = new FrameSet    //卡瓦尔动作帧
            {
                { MirAction.Standing, new Frame(0, 6, 4, 500) },
                { MirAction.Walking, new Frame(80, 6, 4, 200) },
                { MirAction.Attack1, new Frame(160, 8, 2, 100) },
                { MirAction.Attack2, new Frame(240, 9, 1, 100) },
                { MirAction.Attack3, new Frame(320, 9, 1, 100) },
                { MirAction.Attack4, new Frame(400, 9, 1, 100) },
                { MirAction.AttackRange1, new Frame(480, 8, 2, 100) },
                { MirAction.Struck, new Frame(560, 3, 7, 250) },
                { MirAction.Die, new Frame(640, 8, 2, 100) },
                { MirAction.Dead, new Frame(647, 1, 9, 1000) },
                { MirAction.Revive, new Frame(640, 8, 2, 100) { Reverse = true } }
            };
            Windblade = new FrameSet      //刃风动作帧
            {
                { MirAction.Standing, new Frame(0, 7, 3, 500) },
                { MirAction.Walking, new Frame(80, 7, 3, 200) },
                { MirAction.Attack1, new Frame(160, 8, 2, 100) },
                { MirAction.Struck, new Frame(240, 3, 7, 250) },
                { MirAction.Die, new Frame(320, 10, 0, 100) },
                { MirAction.Dead, new Frame(329, 1, 9, 1000) },
                { MirAction.Revive, new Frame(320, 10, 0, 100) { Reverse = true } }
            };
            FrozenGolem = new FrameSet    //雪恶鬼动作帧
            {
                { MirAction.Standing, new Frame(0, 4, 0, 500) },
                { MirAction.Walking, new Frame(32, 6, 0, 200) },
                { MirAction.Attack1, new Frame(80, 8, 0, 100) },
                { MirAction.Struck, new Frame(144, 3, 0, 200) },
                { MirAction.Die, new Frame(168, 12, 0, 100) },
                { MirAction.Dead, new Frame(999, 1, 11, 1000) },
                { MirAction.Revive, new Frame(168, 10, 0, 100) { Reverse = true } }
            };
            BestKing = new FrameSet      //野兽王动作帧
            {
                { MirAction.Standing, new Frame(0, 6, 0, 500) },
                { MirAction.Walking, new Frame(48, 6, 0, 200) },
                { MirAction.Attack1, new Frame(96, 8, 0, 100) },
                { MirAction.Attack2, new Frame(184, 9, 0, 100) },
                { MirAction.Attack3, new Frame(256, 5, 0, 100) },
                { MirAction.Attack4, new Frame(296, 8, 0, 100) },
                { MirAction.Struck, new Frame(464, 5, 0, 250) },
                { MirAction.Die, new Frame(570, 5, 0, 100) },
                { MirAction.Dead, new Frame(574, 1, 4, 1000) },
                { MirAction.Revive, new Frame(570, 5, 0, 100) { Reverse = true } }
            };
            ShardGuardian = new FrameSet      //冰白的士兵凯伊动作帧
            {
                { MirAction.Standing, new Frame(0, 6, 0, 500) },
                { MirAction.Walking, new Frame(48, 6, 0, 200) },
                { MirAction.Attack1, new Frame(96, 6, 0, 100) },
                { MirAction.Attack2, new Frame(144, 8, 0, 100) },
                { MirAction.Attack3, new Frame(208, 9, 0, 100) },
                { MirAction.Struck, new Frame(280, 3, 0, 250) },
                { MirAction.Die, new Frame(304, 10, 0, 100) },
                { MirAction.Dead, new Frame(313, 1, 9, 1000) },
                { MirAction.Revive, new Frame(304, 10, 0, 100) { Reverse = true } }
            };
            HoodedSummoner = new FrameSet      //学者凯伊动作帧
            {
                { MirAction.Standing, new Frame(0, 8, 0, 500) },
                { MirAction.Walking, new Frame(64, 6, 0, 200) },
                { MirAction.Attack1, new Frame(112, 9, 0, 100) },
                { MirAction.Attack2, new Frame(112, 9, 0, 100) },
                { MirAction.Attack3, new Frame(184, 9, 0, 100) },
                { MirAction.Struck, new Frame(256, 3, 0, 250) },
                { MirAction.Die, new Frame(280, 9, 0, 100) },
                { MirAction.Dead, new Frame(288, 1, 8, 1000) },
                { MirAction.Revive, new Frame(280, 9, 0, 100) { Reverse = true } }
            };
            HoodedIceMage = new FrameSet      //冰白的学者凯伊动作帧
            {
                { MirAction.Standing, new Frame(0, 6, 0, 500) },
                { MirAction.Walking, new Frame(48, 6, 0, 200) },
                { MirAction.Attack1, new Frame(96, 7, 0, 100) },
                { MirAction.Attack2, new Frame(152, 7, 0, 100) },
                { MirAction.Attack3, new Frame(208, 7, 0, 100) },
                { MirAction.Struck, new Frame(264, 3, 0, 250) },
                { MirAction.Die, new Frame(288, 10, 0, 100) },
                { MirAction.Dead, new Frame(297, 1, 9, 1000) },
                { MirAction.Revive, new Frame(288, 10, 0, 100) { Reverse = true } }
            };
           HoodedPriest = new FrameSet        //贤者凯伊动作帧
           {
                { MirAction.Standing, new Frame(0, 6, 0, 500) },
                { MirAction.Walking, new Frame(48, 6, 0, 200) },
                { MirAction.Attack1, new Frame(96, 7, 0, 100) },
                { MirAction.Attack2, new Frame(152, 7, 0, 100) },
                { MirAction.Attack3, new Frame(208, 7, 0, 100) },
                { MirAction.Struck, new Frame(256, 3, 0, 280) },
                { MirAction.Die, new Frame(280, 10, 0, 100) },
                { MirAction.Dead, new Frame(289, 1, 9, 1000) },
                { MirAction.Revive, new Frame(280, 10, 0, 100) { Reverse = true } }
            };
            ShardMaiden = new FrameSet        //冰灵凯伊动作帧
           {
                { MirAction.Standing, new Frame(0, 8, 0, 500) },
                { MirAction.Walking, new Frame(64, 6, 0, 200) },
                { MirAction.Attack1, new Frame(112, 7, 0, 100) },
                { MirAction.Attack2, new Frame(168, 9, 0, 100) },
                { MirAction.Attack3, new Frame(248, 8, 0, 100) },
                { MirAction.Struck, new Frame(312, 4, 0, 250) },
                { MirAction.Die, new Frame(344, 10, 0, 100) },
                { MirAction.Dead, new Frame(353, 1, 9, 1000) },
                { MirAction.Revive, new Frame(344, 10, 0, 100) { Reverse = true } }
            };
            Furball = new FrameSet        //雪球动作帧
           {
                { MirAction.Standing, new Frame(0, 7, 0, 500) },
                { MirAction.Walking, new Frame(56, 6, 0, 200) },
                { MirAction.Attack1, new Frame(104, 7, 0, 100) },
                { MirAction.Struck, new Frame(160, 5, 0, 100) },
                { MirAction.Die, new Frame(200, 7, 0, 100) },
                { MirAction.Dead, new Frame(206, 1, 6, 1000) },
                { MirAction.Revive, new Frame(200, 7, 0, 200) { Reverse = true } }
            };
            PeacockSpider = new FrameSet        //孔雀蛛动作帧
           {
                { MirAction.Standing, new Frame(0, 9, 0, 500) },
                { MirAction.Walking, new Frame(72, 6, 0, 200) },
                { MirAction.Attack1, new Frame(120, 9, 0, 100) },
                { MirAction.Attack2, new Frame(192, 10, 0, 100) },
                { MirAction.Attack3, new Frame(272, 9, 0, 100) },
                { MirAction.Attack4, new Frame(344, 9, 0, 100) },
                { MirAction.Attack5, new Frame(416, 10, 0, 100) },
                { MirAction.Struck, new Frame(496, 3, 0, 280) },
                { MirAction.Die, new Frame(520, 9, 0, 100) },
                { MirAction.Dead, new Frame(529, 1, 8, 1000) },
                { MirAction.Revive, new Frame(520, 9, 0, 100) { Reverse = true } }
            };
            YangDevilNode = new FrameSet           //龙魂石动作帧
            {
                { MirAction.Standing, new Frame(0, 4, -4, 1000) },
                { MirAction.Attack1, new Frame(4, 6, -6, 180) },
                { MirAction.Struck, new Frame(10, 2, -2, 200) },
                { MirAction.Die, new Frame(12, 10, -10, 150) },
                { MirAction.Dead, new Frame(21, 1, -1, 1000) },
                { MirAction.Revive, new Frame(12, 10, -10, 150) { Reverse = true } }
            };
            YinDevilNode = new FrameSet           //镇魂石动作帧
            {
                { MirAction.Standing, new Frame(0, 4, -4, 1000) },
                { MirAction.Attack1, new Frame(4, 6, -6, 180) },
                { MirAction.Struck, new Frame(10, 2, -2, 200) },
                { MirAction.Die, new Frame(12, 10, -10, 150) },
                { MirAction.Dead, new Frame(21, 1, -1, 1000) },
                { MirAction.Revive, new Frame(12, 10, -10, 150) { Reverse = true } }
            };
            PeacockSpider = new FrameSet        //黑暗船长动作帧
           {
                { MirAction.Standing, new Frame(0, 10, 0, 500) },
                { MirAction.Walking, new Frame(80, 8, 0, 200) },
                { MirAction.Attack1, new Frame(144, 7, 0, 100) },
                { MirAction.Attack2, new Frame(200, 7, 0, 100) },
                { MirAction.Attack3, new Frame(368, 7, 0, 100) },
                { MirAction.AttackRange1, new Frame(256, 7, 0, 100) },
                { MirAction.AttackRange2, new Frame(312, 7, 0, 100) },
                { MirAction.AttackRange3, new Frame(424, 7, 0, 100) },
                { MirAction.Struck, new Frame(480, 3, 0, 200) },
                { MirAction.Die, new Frame(504, 10, 0, 100) },
                { MirAction.Dead, new Frame(513, 1, 9, 1000) },
                { MirAction.Revive, new Frame(504, 10, 0, 100) { Reverse = true } }
            };
            BlueSoul = new FrameSet           //魂火动作帧
            {
                { MirAction.Standing, new Frame(0, 4, 0, 100) },
                { MirAction.Walking, new Frame(32, 6, 0, 100) },
                { MirAction.Attack1, new Frame(80, 7, 0, 100) },
                { MirAction.Struck, new Frame(136, 3, 0, 200) },
                { MirAction.Die, new Frame(160, 10, 0, 100) },
                { MirAction.Dead, new Frame(169, 1, 9, 1000) },
                { MirAction.Revive, new Frame(160, 10, 0, 100) { Reverse = true } }
            };
            WoodBox = new FrameSet           //诅咒的箱子动作帧
            {
                { MirAction.Standing, new Frame(0, 1, 0, 500) },
                { MirAction.Struck, new Frame(0, 1, 0, 200) },
                { MirAction.Die, new Frame(8, 12, 0, 100) },
                { MirAction.Dead, new Frame(19, 1, 11, 1000) },
            };
            ClawBeast = new FrameSet           //变异的监视员动作帧
            {
                { MirAction.Standing, new Frame(0, 4, 0, 500) },
                { MirAction.Walking, new Frame(32, 6, 0, 100) },
                { MirAction.AttackRange1, new Frame(80, 10, 0, 100) },
                { MirAction.Struck, new Frame(160, 3, 0, 200) },
                { MirAction.Die, new Frame(184, 9, 0, 100) },
                { MirAction.Dead, new Frame(192, 1, 8, 1000) },
                { MirAction.Revive, new Frame(184, 9, 0, 100) { Reverse = true } }
            };
            AxePlant = new FrameSet           //船木工动作帧
            {
                { MirAction.Standing, new Frame(0, 4, 0, 500) },
                { MirAction.Walking, new Frame(32, 6, 0, 100) },
                { MirAction.Attack1, new Frame(80, 10, 0, 100) },
                { MirAction.Struck, new Frame(160, 3, 0, 200) },
                { MirAction.Die, new Frame(184, 9, 0, 100) },
                { MirAction.Dead, new Frame(192, 1, 8, 1000) },
                { MirAction.Revive, new Frame(184, 9, 0, 100) { Reverse = true } }
            };
            AvengingWarrior = new FrameSet           //农奴军动作帧
            {
                { MirAction.Standing, new Frame(0, 4, 0, 500) },
                { MirAction.Walking, new Frame(32, 6, 0, 100) },
                { MirAction.Attack1, new Frame(80, 6, 0, 100) },
                { MirAction.AttackRange1, new Frame(128, 6, 0, 100) },
                { MirAction.Struck, new Frame(178, 2, 0, 200) },
                { MirAction.Die, new Frame(192, 10, 0, 100) },
                { MirAction.Dead, new Frame(201, 1, 9, 1000) },
                { MirAction.Revive, new Frame(192, 10, 0, 100) { Reverse = true } }
            };
            AvengingSpirit = new FrameSet           //船舶的恶灵动作帧
            {
                { MirAction.Standing, new Frame(0, 4, 0, 500) },
                { MirAction.Walking, new Frame(32, 6, 0, 200) },
                { MirAction.Attack1, new Frame(80, 8, 0, 100) },
                { MirAction.AttackRange1, new Frame(144, 7, 0, 100) },
                { MirAction.Struck, new Frame(200, 3, 0, 200) },
                { MirAction.Die, new Frame(224, 7, 0, 100) },
                { MirAction.Dead, new Frame(230, 1, 6, 1000) },
                { MirAction.Revive, new Frame(224, 7, 0, 100) { Reverse = true } }
            };
            Nadz = new FrameSet           //溺死的奴隶动作帧
            {
                { MirAction.Standing, new Frame(0, 4, 0, 500) },
                { MirAction.Walking, new Frame(32, 6, 0, 200) },
                { MirAction.Attack1, new Frame(80, 8, 0, 100) },
                { MirAction.Attack2, new Frame(128, 8, 0, 100) },
                { MirAction.Struck, new Frame(192, 3, 0, 200) },
                { MirAction.Die, new Frame(216, 8, 0, 100) },
                { MirAction.Dead, new Frame(223, 1, 7, 1000) },
                { MirAction.Revive, new Frame(216, 8, 0, 100) { Reverse = true } }
            };
            AvengerPlant = new FrameSet           //游荡的船员动作帧
            {
                { MirAction.Standing, new Frame(0, 4, 0, 500) },
                { MirAction.Walking, new Frame(32, 6, 0, 200) },
                { MirAction.Attack1, new Frame(80, 7, 0, 100) },
                { MirAction.Struck, new Frame(136, 3, 0, 200) },
                { MirAction.Die, new Frame(160, 8, 0, 100) },
                { MirAction.Dead, new Frame(167, 1, 7, 1000) },
                { MirAction.Revive, new Frame(160, 8, 0, 100) { Reverse = true } }
            };
            ArmedPlant = new FrameSet           //熏黑的厨师动作帧
            {
                { MirAction.Standing, new Frame(0, 6, 0, 500) },
                { MirAction.Walking, new Frame(48, 6, 0, 200) },
                { MirAction.Attack1, new Frame(96, 6, 0, 100) },
                { MirAction.Struck, new Frame(144, 6, 0, 200) },
                { MirAction.Die, new Frame(192, 8, 0, 100) },
                { MirAction.Dead, new Frame(198, 1, 7, 1000) },
                { MirAction.Revive, new Frame(192, 8, 0, 100) { Reverse = true } }
            };
            FloatingWraith = new FrameSet           //徘徊的弓兵动作帧
            {
                { MirAction.Standing, new Frame(0, 4, 0, 500) },
                { MirAction.Walking, new Frame(32, 6, 0, 100) },
                { MirAction.Attack1, new Frame(80, 8, 0, 100) },
                { MirAction.Struck, new Frame(143, 3, 0, 200) },
                { MirAction.Die, new Frame(167, 10, 0, 100) },
                { MirAction.Dead, new Frame(176, 1, 9, 1000) },
                { MirAction.Revive, new Frame(167, 10, 0, 100) { Reverse = true } }
            };
            CreeperPlant = new FrameSet           //巨僵花动作帧
            {
                { MirAction.Standing, new Frame(0, 4, 0, 500) },
                { MirAction.Attack1, new Frame(32, 7, 0, 100) },
                { MirAction.Attack2, new Frame(88, 7, 0, 100) },
                { MirAction.Struck, new Frame(136, 3, 0, 200) },
                { MirAction.Die, new Frame(160, 9, 0, 100) },
                { MirAction.Dead, new Frame(168, 1, 8, 1000) },
                { MirAction.Show, new Frame(232, 9, -9, 150) },
                { MirAction.Hide, new Frame(241, 9, -9, 150) },
                { MirAction.Revive, new Frame(160, 9, 0, 100) { Reverse = true } }
            };
            PlagueCrab = new FrameSet           //变异甲虫动作帧
            {
                { MirAction.Standing, new Frame(0, 4, 0, 500) },
                { MirAction.Walking, new Frame(32, 6, 0, 200) },
                { MirAction.Attack1, new Frame(80, 8, 0, 100) },
                { MirAction.Struck, new Frame(144, 3, 0, 200) },
                { MirAction.Die, new Frame(168, 10, 0, 100) },
                { MirAction.Dead, new Frame(177, 1, 9, 1000) },
                { MirAction.Revive, new Frame(168, 10, 0, 100) { Reverse = true } }
            };
            Mandrill = new FrameSet           //长鼻猿猴动作帧
            {
                { MirAction.Standing, new Frame(0, 4, 0, 500) },
                { MirAction.Walking, new Frame(32, 6, 0, 200) },
                { MirAction.Attack1, new Frame(80, 7, 0, 100) },
                { MirAction.Attack2, new Frame(136, 3, 0, 200) },
                { MirAction.Struck, new Frame(160, 3, 0, 200) },
                { MirAction.Die, new Frame(184, 10, 0, 100) },
                { MirAction.Dead, new Frame(193, 1, 9, 1000) },
                { MirAction.Revive, new Frame(184, 10, 0, 100) { Reverse = true } }
            };
            HornedCommander = new FrameSet        //魔风石怪动作帧
           {
                { MirAction.Standing, new Frame(0, 4, 0, 200) },
                { MirAction.Walking, new Frame(32, 8, 0, 100) },
                { MirAction.Attack1, new Frame(96, 10, 0, 100) },
                { MirAction.Attack2, new Frame(176, 8, 0, 100) },
                { MirAction.Attack3, new Frame(240, 10, 0, 100) },
                { MirAction.AttackRange1, new Frame(320, 8, 0, 100) },
                { MirAction.AttackRange2, new Frame(384, 8, 0, 100) },
                { MirAction.AttackRange3, new Frame(448, 8, 0, 100) },
                { MirAction.Attack4, new Frame(512, 10, 0, 100) },
                { MirAction.Attack5, new Frame(592, 8, 0, 100) },
                { MirAction.Struck, new Frame(656, 3, 0, 200) },
                { MirAction.Die, new Frame(680, 13, 0, 100) },
                { MirAction.Dead, new Frame(692, 1, 12, 1000) },
                { MirAction.Revive, new Frame(680, 13, 0, 100) { Reverse = true } }
            };
            HornedSorceror = new FrameSet           //长鼻猿猴动作帧
            {
                { MirAction.Standing, new Frame(0, 4, 0, 500) },
                { MirAction.Walking, new Frame(32, 8, 0, 100) },
                { MirAction.Attack1, new Frame(96, 8, 0, 100) },
                { MirAction.Attack2, new Frame(160, 9, 0, 100) },
                { MirAction.Attack3, new Frame(232, 9, 0, 100) },
                { MirAction.Attack4, new Frame(304, 8, 0, 100) },
                { MirAction.DashAttack, new Frame(368, 8, 0, 100) },
                { MirAction.Struck, new Frame(432, 3, 0, 200) },
                { MirAction.Die, new Frame(456, 10, 0, 100) },
                { MirAction.Dead, new Frame(465, 1, 9, 1000) },
                { MirAction.Revive, new Frame(456, 10, 0, 100) { Reverse = true } }
            };
            BoulderSpirit = new FrameSet           //岩石炸弹动作帧
            {
                { MirAction.Standing, new Frame(0, 4, 0, 200) },
                { MirAction.Struck, new Frame(32, 3, 0, 200) },
                { MirAction.Die, new Frame(56, 8, -8, 100) },
                { MirAction.Dead, new Frame(63, 1, -1, 1000) },
            };
            ScalyBeast = new FrameSet      //魔石巨人动作帧
            {
                { MirAction.Standing, new Frame(0, 4, 0, 500) },
                { MirAction.Walking, new Frame(32, 10, 0, 200) },
                { MirAction.Attack1, new Frame(112, 8, 0, 100) },
                { MirAction.Attack2, new Frame(176, 10, 0, 100) },
                { MirAction.Struck, new Frame(256, 2, 0, 200) },
                { MirAction.Die, new Frame(272, 9, 0, 100) },
                { MirAction.Dead, new Frame(280, 1, 8, 1000) },
                { MirAction.Revive, new Frame(272, 9, 0, 100) { Reverse = true } }
            };
            FloatingRock = new FrameSet      //厉鬼石动作帧
            {
                { MirAction.Standing, new Frame(0, 10, 0, 500) },
                { MirAction.AttackRange1, new Frame(80, 8, 0, 100) },
                { MirAction.Struck, new Frame(80, 3, 5, 200) },
                { MirAction.Die, new Frame(144, 8, -8, 100) },
                { MirAction.Dead, new Frame(151, 1, 1, 1000) },
                { MirAction.Revive, new Frame(144, 7, -7, 100) { Reverse = true } }
            };
            HornedWarrior = new FrameSet      //咒魔剑士动作帧
            {
                { MirAction.Standing, new Frame(0, 4, 0, 500) },
                { MirAction.Walking, new Frame(32, 6, 0, 200) },
                { MirAction.Attack1, new Frame(80, 8, 0, 100) },
                { MirAction.Attack2, new Frame(144, 9, 0, 100) },
                { MirAction.Attack3, new Frame(216, 8, 0, 100) },
                { MirAction.Struck, new Frame(280, 3, 0, 200) },
                { MirAction.Die, new Frame(304, 9, 0, 100) },
                { MirAction.Dead, new Frame(312, 1, 8, 1000) },
                { MirAction.Revive, new Frame(304, 9, 0, 100) { Reverse = true } }
            };
            ColdArcher = new FrameSet      //咒魔风弓士动作帧
            {
                { MirAction.Standing, new Frame(0, 4, 0, 500) },
                { MirAction.Walking, new Frame(32, 6, 0, 200) },
                { MirAction.Attack1, new Frame(80, 10, 0, 100) },
                { MirAction.Attack2, new Frame(160, 9, 0, 100) },
                { MirAction.Struck, new Frame(232, 3, 0, 200) },
                { MirAction.Die, new Frame(256, 10, 0, 100) },
                { MirAction.Dead, new Frame(265, 1, 9, 1000) },
                { MirAction.Revive, new Frame(256, 10, 0, 100) { Reverse = true } }
            };
            HornedArcher = new FrameSet      //咒魔火弓士动作帧
            {
                { MirAction.Standing, new Frame(0, 4, 0, 500) },
                { MirAction.Walking, new Frame(32, 6, 0, 200) },
                { MirAction.AttackRange1, new Frame(80, 10, 0, 100) },
                { MirAction.AttackRange2, new Frame(160, 9, 0, 100) },
                { MirAction.Struck, new Frame(232, 3, 0, 200) },
                { MirAction.Die, new Frame(256, 10, 0, 100) },
                { MirAction.Dead, new Frame(265, 1, 9, 1000) },
                { MirAction.Revive, new Frame(256, 10, 0, 100) { Reverse = true } }
            };
            HornedMage = new FrameSet      //咒魔术士动作帧
            {
                { MirAction.Standing, new Frame(0, 4, 0, 500) },
                { MirAction.Walking, new Frame(32, 6, 0, 200) },
                { MirAction.Attack1, new Frame(80, 8, 0, 100) },
                { MirAction.AttackRange1, new Frame(144, 9, 0, 100) },
                { MirAction.AttackRange2, new Frame(216, 9, 0, 100) },
                { MirAction.Struck, new Frame(280, 3, 0, 200) },
                { MirAction.Die, new Frame(304, 10, 0, 100) },
                { MirAction.Dead, new Frame(313, 1, 9, 1000) },
                { MirAction.Revive, new Frame(304, 10, 0, 100) { Reverse = true } }
            };
            KingHydrax = new FrameSet      //双头蟒动作帧
            {
                { MirAction.Standing, new Frame(0, 4, 0, 500) },
                { MirAction.Walking, new Frame(32, 6, 0, 200) },
                { MirAction.Attack1, new Frame(80, 8, 0, 100) },
                { MirAction.AttackRange1, new Frame(144, 7, 0, 100) },
                { MirAction.AttackRange2, new Frame(200, 8, 0, 100) },
                { MirAction.Struck, new Frame(264, 3, 0, 200) },
                { MirAction.Die, new Frame(288, 10, 0, 100) },
                { MirAction.Dead, new Frame(297, 1, 9, 1000) },
                { MirAction.Revive, new Frame(288, 10, 0, 100) { Reverse = true } }
            };
            Hydrax = new FrameSet      //小蟒动作帧
            {
                { MirAction.Standing, new Frame(0, 4, 0, 500) },
                { MirAction.Walking, new Frame(32, 6, 0, 200) },
                { MirAction.Attack1, new Frame(80, 8, 0, 100) },
                { MirAction.Struck, new Frame(144, 3, 0, 200) },
                { MirAction.Die, new Frame(168, 9, 0, 100) },
                { MirAction.Dead, new Frame(176, 1, 8, 1000) },
                { MirAction.Revive, new Frame(168, 9, 0, 100) { Reverse = true } }
            };
            SackWarrior = new FrameSet      //厉鬼动作帧
            {
                { MirAction.Standing, new Frame(0, 4, 0, 500) },
                { MirAction.Walking, new Frame(32, 6, 0, 200) },
                { MirAction.Attack1, new Frame(80, 8, 0, 100) },
                { MirAction.Attack2, new Frame(144, 9, 0, 100) },
                { MirAction.Struck, new Frame(216, 3, 0, 200) },
                { MirAction.Die, new Frame(240, 13, 0, 100) },
                { MirAction.Dead, new Frame(252, 1, 12, 1000) },
                { MirAction.Revive, new Frame(240, 13, 0, 100) { Reverse = true } }
            };
            WereTiger = new FrameSet      //钛骨鼠动作帧
            {
                { MirAction.Standing, new Frame(0, 4, 0, 500) },
                { MirAction.Walking, new Frame(32, 6, 0, 100) },
                { MirAction.Attack1, new Frame(80, 10, 0, 100) },
                { MirAction.Attack2, new Frame(160, 10, 0, 100) },
                { MirAction.Struck, new Frame(240, 3, 0, 200) },
                { MirAction.Die, new Frame(264, 10, 0, 100) },
                { MirAction.Dead, new Frame(273, 1, 9, 1000) },
                { MirAction.Revive, new Frame(264, 10, 0, 100) { Reverse = true } }
            };
            GlacierBeast = new FrameSet      //冰虎像动作帧
            {
                { MirAction.Standing, new Frame(0, 5, 0, 500) },
                { MirAction.Walking, new Frame(40, 6, 0, 100) },
                { MirAction.Attack1, new Frame(88, 6, 0, 100) },
                { MirAction.Attack2, new Frame(136, 7, 0, 100) },
                { MirAction.Struck, new Frame(192, 4, 0, 100) },
                { MirAction.Die, new Frame(224, 10, 0, 100) },
                { MirAction.Dead, new Frame(233, 1, 9, 1000) },
                { MirAction.Revive, new Frame(224, 10, 0, 100) { Reverse = true } }
            };
            FurbolgCommander = new FrameSet      //格斗豹人动作帧
            {
                { MirAction.Standing, new Frame(0, 6, 0, 500) },
                { MirAction.Walking, new Frame(48, 6, 0, 500) },
                { MirAction.Attack1, new Frame(160, 8, 0, 100) },
                { MirAction.AttackRange1, new Frame(96, 8, 0, 100) },
                { MirAction.Struck, new Frame(224, 5, 0, 100) },
                { MirAction.Die, new Frame(264, 7, 0, 100) },
                { MirAction.Dead, new Frame(270, 1, 6, 1000) },
                { MirAction.Revive, new Frame(264, 7, 0, 100) { Reverse = true } }
            };
            FurbolgGuard = new FrameSet      //鱼叉豹人动作帧
            {
                { MirAction.Standing, new Frame(0, 6, 0, 500) },
                { MirAction.Walking, new Frame(48, 6, 0, 500) },
                { MirAction.Attack1, new Frame(96, 7, 0, 100) },
                { MirAction.AttackRange1, new Frame(152, 9, 0, 100) },
                { MirAction.Jump, new Frame(224, 6, 0, 100) },
                { MirAction.Struck, new Frame(272, 6, 0, 100) },
                { MirAction.Die, new Frame(320, 8, 0, 100) },
                { MirAction.Dead, new Frame(327, 1, 7, 1000) },
                { MirAction.Revive, new Frame(320, 8, 0, 100) { Reverse = true } }
            };
            FurbolgArcher = new FrameSet      //石弓豹人动作帧
            {
                { MirAction.Standing, new Frame(0, 4, 0, 500) },
                { MirAction.Walking, new Frame(32, 6, 0, 500) },
                { MirAction.AttackRange1, new Frame(80, 6, 0, 100) },
                { MirAction.AttackRange2, new Frame(128, 7, 0, 100) },
                { MirAction.Jump, new Frame(184, 6, 0, 100) },
                { MirAction.Struck, new Frame(232, 4, 0, 200) },
                { MirAction.Die, new Frame(264, 10, 0, 100) },
                { MirAction.Dead, new Frame(273, 1, 9, 1000) },
                { MirAction.Revive, new Frame(264, 10, 0, 100) { Reverse = true } }
            };
            FurbolgWarrior = new FrameSet      //杀戮豹人动作帧
            {
                { MirAction.Standing, new Frame(0, 4, 0, 500) },
                { MirAction.Walking, new Frame(32, 8, 0, 250) },
                { MirAction.Attack1, new Frame(96, 9, 0, 100) },
                { MirAction.Attack2, new Frame(168, 7, 0, 100) },
                { MirAction.Struck, new Frame(224, 3, 0, 200) },
                { MirAction.Die, new Frame(248, 9, 0, 100) },
                { MirAction.Dead, new Frame(256, 1, 8, 1000) },
                { MirAction.Revive, new Frame(248, 9, 0, 100) { Reverse = true } }
            };
            GlacierSnail = new FrameSet      //冰蜗牛动作帧
            {
                { MirAction.Standing, new Frame(0, 7, 0, 500) },
                { MirAction.Walking, new Frame(56, 6, 0, 500) },
                { MirAction.Attack1, new Frame(104, 8, 0, 100) },
                { MirAction.Attack2, new Frame(168, 10, 0, 100) },
                { MirAction.Struck, new Frame(248, 5, 0, 200) },
                { MirAction.Die, new Frame(288, 7, 0, 100) },
                { MirAction.Dead, new Frame(294, 1, 6, 1000) },
                { MirAction.Revive, new Frame(288, 7, 0, 100) { Reverse = true } }
            };
            PurpleFaeFlower = new FrameSet      //雪花动作帧
            {
                { MirAction.Stoned, new Frame(0, 9, 0, 100) },
                { MirAction.Show, new Frame(72, 7, 0, 200) },
                { MirAction.Hide, new Frame(72, 7, 0, 200) },
                { MirAction.Standing, new Frame(72, 7, 0, 200) },
                { MirAction.Attack1, new Frame(184, 8, 0, 100) },
                { MirAction.AttackRange1, new Frame(128, 7, 0, 100) },
                { MirAction.Struck, new Frame(248, 3, 0, 100) },
                { MirAction.Die, new Frame(272, 7, 0, 100) },
                { MirAction.Dead, new Frame(278, 1, 6, 1000) },
                { MirAction.Revive, new Frame(272, 7, 0, 100) { Reverse = true } }
            };
            DarkDevil = new FrameSet      //黑天魔王,黑暗魔王动作帧
            {
                { MirAction.Standing, new Frame(0, 4, 0, 500) },
                { MirAction.Walking, new Frame(32, 6, 0, 100) },
                { MirAction.Attack1, new Frame(80, 6, 0, 100) },
                { MirAction.AttackRange1, new Frame(144, 10, 0, 100) },
                { MirAction.Struck, new Frame(128, 2, 0, 200) },
                { MirAction.Die, new Frame(144, 10, 0, 100) },
                { MirAction.Dead, new Frame(153, 1, 9, 1000) },
                { MirAction.Revive, new Frame(144, 10, 0, 100) { Reverse = true } }
            };
            ZumaTaurus = new FrameSet      //咒魔王,咒魔王9,咒魔石尊,魔化祖玛教主动作帧
            {
                { MirAction.Stoned, new Frame(0, 1, -1, 100) },
                { MirAction.Show, new Frame(0, 20, -20, 100) },
                { MirAction.Standing, new Frame(20, 4, 0, 1000) },
                { MirAction.Walking, new Frame(52, 6, 0, 100) },
                { MirAction.Attack1, new Frame(100, 6, 0, 100) },
                { MirAction.Struck, new Frame(148, 2, 0, 200) },
                { MirAction.Die, new Frame(164, 10, 0, 100) },
                { MirAction.Dead, new Frame(173, 1, 9, 1000) },
                { MirAction.Revive, new Frame(164, 10, 0, 100) { Reverse = true } }
            };
            WoomaTaurus = new FrameSet      //牛面鬼王,牛面鬼王1,牛面鬼王9,远古牛面鬼王,魔化沃玛教主,牛魔鬼尊动作帧
            {
                { MirAction.Standing, new Frame(0, 4, 0, 500) },
                { MirAction.Walking, new Frame(32, 6, 0, 100) },
                { MirAction.Attack1, new Frame(80, 6, 0, 100) },
                { MirAction.Struck, new Frame(128, 2, 0, 200) },
                { MirAction.Die, new Frame(144, 10, 0, 100) },
                { MirAction.Dead, new Frame(153, 1, 9, 1000) },
                { MirAction.Revive, new Frame(144, 10, 0, 100) { Reverse = true } }
            };
            KingHog = new FrameSet      //邪恶猪王,远古猪王,虹魔猪卫,黑暗猪王动作帧
            {
                { MirAction.Standing, new Frame(0, 4, 0, 500) },
                { MirAction.Walking, new Frame(32, 6, 0, 100) },
                { MirAction.Attack1, new Frame(80, 6, 0, 100) },
                { MirAction.Struck, new Frame(128, 2, 0, 200) },
                { MirAction.Die, new Frame(144, 10, 0, 100) },
                { MirAction.Dead, new Frame(153, 1, 9, 1000) },
                { MirAction.Revive, new Frame(144, 10, 0, 100) { Reverse = true } }
            };
            KingScorpion = new FrameSet      //虹魔蝎卫,黑暗蛇王动作帧
            {
                { MirAction.Standing, new Frame(0, 4, 0, 500) },
                { MirAction.Walking, new Frame(32, 6, 0, 100) },
                { MirAction.Attack1, new Frame(80, 6, 0, 100) },
                { MirAction.AttackRange1, new Frame(224, 6, 0, 100) },
                { MirAction.Struck, new Frame(128, 2, 0, 200) },
                { MirAction.Die, new Frame(144, 10, 0, 100) },
                { MirAction.Dead, new Frame(153, 1, 9, 1000) },
                { MirAction.Revive, new Frame(144, 10, 0, 100) { Reverse = true } }
            };
            WoomaGuardian = new FrameSet      //牛面鬼将,牛面鬼将1,牛面鬼将2,远古牛面鬼将,沃玛卫士5,沃玛卫士6,墨龙鬼将动作帧
            {
                { MirAction.Standing, new Frame(0, 4, 0, 500) },
                { MirAction.Walking, new Frame(32, 6, 0, 100) },
                { MirAction.Attack1, new Frame(80, 6, 0, 100) },
                { MirAction.Struck, new Frame(128, 2, 0, 200) },
                { MirAction.Die, new Frame(144, 10, 0, 100) },
                { MirAction.Dead, new Frame(153, 1, 9, 1000) },
                { MirAction.Revive, new Frame(144, 10, 0, 100) { Reverse = true } }
            };
            WhiteBoar = new FrameSet      //白野猪,远古白野猪白野猪20,白野猪21,墨龙白野猪动作帧
            {
                { MirAction.Standing, new Frame(0, 4, 0, 500) },
                { MirAction.Walking, new Frame(32, 6, 0, 100) },
                { MirAction.Attack1, new Frame(80, 6, 0, 100) },
                { MirAction.Struck, new Frame(128, 2, 0, 200) },
                { MirAction.Die, new Frame(144, 10, 0, 100) },
                { MirAction.Dead, new Frame(153, 1, 9, 1000) },
                { MirAction.Revive, new Frame(144, 10, 0, 100) { Reverse = true } }
            };
            ZumaGuardian = new FrameSet      //守护护法,咒魔护法,咒魔护法0,咒魔护法3,远古咒魔护法,祖玛卫士20,祖玛卫士21,墨龙护法动作帧
            {
                { MirAction.Stoned, new Frame(0, 1, 5, 100) },
                { MirAction.Show, new Frame(0, 6, 0, 100) },
                { MirAction.Hide, new Frame(5, 6, 0, 200) },
                { MirAction.Standing, new Frame(48, 4, 0, 1000) },
                { MirAction.Walking, new Frame(80, 6, 0, 100) },
                { MirAction.Attack1, new Frame(128, 6, 0, 100) },
                { MirAction.Struck, new Frame(176, 2, 0, 200) },
                { MirAction.Die, new Frame(192, 10, 0, 100) },
                { MirAction.Dead, new Frame(201, 1, 9, 1000) },
                { MirAction.Revive, new Frame(192, 10, 0, 100) { Reverse = true } }
            };
            ZumaStatue = new FrameSet      //守护神将,咒魔神将,咒魔神将0,咒魔神将3,远古咒魔神将,祖玛雕像20,祖玛雕像21,墨龙神将动作帧
            {
                { MirAction.Stoned, new Frame(0, 1, 5, 100) },
                { MirAction.Show, new Frame(0, 6, 0, 100) },
                { MirAction.Hide, new Frame(5, 6, 0, 100) },
                { MirAction.Standing, new Frame(48, 4, 0, 1000) },
                { MirAction.Walking, new Frame(80, 6, 0, 100) },
                { MirAction.Attack1, new Frame(128, 6, 0, 100) },
                { MirAction.Struck, new Frame(176, 2, 0, 200) },
                { MirAction.Die, new Frame(192, 10, 0, 100) },
                { MirAction.Dead, new Frame(201, 1, 9, 1000) },
                { MirAction.Revive, new Frame(192, 10, 0, 100) { Reverse = true } }
            };
            ZumaArcher = new FrameSet      //守护弓箭手,咒魔弓箭手,咒魔弓箭手0,咒魔弓箭手3,远古咒魔弓箭手,祖玛弓箭手20,祖玛弓箭手21,墨龙弓箭手动作帧
            {
                { MirAction.Standing, new Frame(0, 4, 0, 500) },
                { MirAction.Walking, new Frame(32, 6, 0, 100) },
                { MirAction.Attack1, new Frame(80, 6, 0, 100) },
                { MirAction.Struck, new Frame(128, 2, 0, 200) },
                { MirAction.Die, new Frame(144, 10, 0, 100) },
                { MirAction.Dead, new Frame(153, 1, 9, 1000) },
                { MirAction.Revive, new Frame(144, 10, 0, 100) { Reverse = true } }
            };
            Ghoul = new FrameSet      //尸王,巨链尸王,尸王10,尸王20,尸王21,墨龙尸王,大尸王动作帧
            {
                { MirAction.Standing, new Frame(0, 4, 0, 500) },
                { MirAction.Walking, new Frame(32, 6, 0, 100) },
                { MirAction.Attack1, new Frame(80, 6, 0, 100) },
                { MirAction.Struck, new Frame(128, 2, 0, 200) },
                { MirAction.Die, new Frame(144, 10, 0, 100) },
                { MirAction.Dead, new Frame(153, 1, 9, 1000) },
                { MirAction.Revive, new Frame(144, 10, 0, 100) { Reverse = true } }
            };
            EvilSnake = new FrameSet      //邪恶毒蛇,邪恶毒蛇20,邪恶毒蛇21,墨龙毒蛇动作帧
            {
                { MirAction.Standing, new Frame(0, 4, 0, 500) },
                { MirAction.Walking, new Frame(32, 6, 0, 100) },
                { MirAction.Attack1, new Frame(80, 6, 0, 100) },
                { MirAction.Struck, new Frame(128, 2, 0, 200) },
                { MirAction.Die, new Frame(144, 10, 0, 100) },
                { MirAction.Dead, new Frame(153, 1, 9, 1000) },
                { MirAction.Revive, new Frame(144, 10, 0, 100) { Reverse = true } }
            };
            EvilTongs = new FrameSet      //邪恶钳虫,邪恶钳虫20,邪恶钳虫21,墨龙钳虫动作帧
            {
                { MirAction.Standing, new Frame(0, 4, 0, 500) },
                { MirAction.Walking, new Frame(32, 6, 0, 100) },
                { MirAction.Attack1, new Frame(80, 6, 0, 100) },
                { MirAction.Struck, new Frame(128, 2, 0, 200) },
                { MirAction.Die, new Frame(144, 10, 0, 100) },
                { MirAction.Dead, new Frame(153, 1, 9, 1000) },
                { MirAction.Revive, new Frame(144, 10, 0, 100) { Reverse = true } }
            };
            TreeQueen = new FrameSet      //如何树动作帧
            {
                { MirAction.Standing, new Frame(0, 10, -10, 500) },
                { MirAction.Attack1, new Frame(11, 10, -10, 100) },
                { MirAction.Attack2, new Frame(11, 10, -10, 100) },
                { MirAction.AttackRange1, new Frame(11, 10, -10, 100) },
                { MirAction.AttackRange2, new Frame(11, 10, -10, 100) },
                { MirAction.Struck, new Frame(21, 3, -3, 200) },
                { MirAction.Die, new Frame(24, 11, -11, 100) },
                { MirAction.Dead, new Frame(34, 1, -1, 1000) },
                { MirAction.Revive, new Frame(24, 11, -11, 100) { Reverse = true } }
            };
            TreeGuardian = new FrameSet      //思维兽动作帧
            {
                { MirAction.Standing, new Frame(0, 9, 0, 500) },
                { MirAction.Walking, new Frame(72, 6, 0, 200) },
                { MirAction.Attack1, new Frame(120, 10, 0, 100) },
                { MirAction.Attack2, new Frame(280, 10, 0, 100) },
                { MirAction.AttackRange1, new Frame(200, 10, 0, 100) },
                { MirAction.AttackRange2, new Frame(360, 10, 0, 100) },
                { MirAction.Struck, new Frame(440, 3, 0, 200) },
                { MirAction.Die, new Frame(464, 10, 0, 100) },
                { MirAction.Dead, new Frame(473, 1, 9, 1000) },
            };
            EarthGolem = new FrameSet      //泥巨人动作帧
            {
                { MirAction.Stoned, new Frame(360, 1, 8, 100) },
                { MirAction.Show, new Frame(360, 9, 0, 100) },
                { MirAction.Hide, new Frame(360, 9, 0, 100) },
                { MirAction.Standing, new Frame(0, 8, 0, 500) },
                { MirAction.Walking, new Frame(64, 6, 0, 200) },
                { MirAction.Attack1, new Frame(112, 10, 0, 100) },
                { MirAction.AttackRange1, new Frame(192, 10, 0, 100) },
                { MirAction.Struck, new Frame(272, 3, 0, 200) },
                { MirAction.Die, new Frame(296, 8, 0, 100) },
                { MirAction.Dead, new Frame(303, 1, 7, 1000) },
                { MirAction.Revive, new Frame(396, 8, 0, 100) { Reverse = true } }
            };
            StoneGolem = new FrameSet      //石巨人动作帧
            {
                { MirAction.Standing, new Frame(0, 9, 0, 500) },
                { MirAction.Walking, new Frame(72, 6, 0, 200) },
                { MirAction.Attack1, new Frame(120, 10, 0, 100) },
                { MirAction.Attack2, new Frame(200, 10, 0, 100) },
                { MirAction.Struck, new Frame(280, 3, 0, 200) },
                { MirAction.Die, new Frame(304, 8, 0, 100) },
                { MirAction.Dead, new Frame(311, 1, 7, 1000) },
                { MirAction.Revive, new Frame(304, 8, 0, 100) { Reverse = true } }
            };
            ElephantMan = new FrameSet      //白象人动作帧
            {
                { MirAction.Standing, new Frame(0, 10, 0, 500) },
                { MirAction.Walking, new Frame(80, 6, 0, 200) },
                { MirAction.Attack1, new Frame(128, 10, 0, 100) },
                { MirAction.Attack2, new Frame(208, 10, 0, 100) },
                { MirAction.Struck, new Frame(288, 3, 0, 200) },
                { MirAction.Die, new Frame(312, 7, 0, 100) },
                { MirAction.Dead, new Frame(318, 1, 6, 1000) },
                { MirAction.Revive, new Frame(312, 7, 0, 100) { Reverse = true } }
            };
            RhinoPriest = new FrameSet      //大角犀牛人动作帧
            {
                { MirAction.Standing, new Frame(0, 6, 0, 500) },
                { MirAction.Walking, new Frame(48, 6, 0, 200) },
                { MirAction.Attack1, new Frame(96, 7, 0, 100) },
                { MirAction.Attack2, new Frame(152, 7, 0, 100) },
                { MirAction.Attack3, new Frame(208, 9, 0, 100) },
                { MirAction.Struck, new Frame(280, 3, 0, 200) },
                { MirAction.Die, new Frame(304, 9, 0, 100) },
                { MirAction.Dead, new Frame(312, 1, 8, 1000) },
                { MirAction.Revive, new Frame(304, 9, 0, 100) { Reverse = true } }
            };
            RhinoWarrior = new FrameSet      //小角犀牛人动作帧
            {
                { MirAction.Standing, new Frame(0, 10, 0, 500) },
                { MirAction.Walking, new Frame(80, 6, 0, 200) },
                { MirAction.Attack1, new Frame(128, 7, 0, 100) },
                { MirAction.Attack2, new Frame(184, 7, 0, 100) },
                { MirAction.Struck, new Frame(240, 3, 0, 200) },
                { MirAction.Die, new Frame(264, 7, 0, 100) },
                { MirAction.Dead, new Frame(370, 1, 6, 1000) },
                { MirAction.Revive, new Frame(264, 7, 0, 100) { Reverse = true } }
            };
            AssassinBird = new FrameSet      //文鸟人动作帧
            {
                { MirAction.Standing, new Frame(0, 7, 0, 500) },
                { MirAction.Walking, new Frame(56, 6, 0, 200) },
                { MirAction.Attack1, new Frame(104, 7, 0, 100) },
                { MirAction.Attack2, new Frame(160, 9, 0, 100) },
                { MirAction.Attack3, new Frame(232, 9, 0, 100) },
                { MirAction.Struck, new Frame(304, 3, 0, 200) },
                { MirAction.Die, new Frame(328, 8, 0, 100) },
                { MirAction.Dead, new Frame(335, 1, 7, 1000) },
                { MirAction.Revive, new Frame(328, 8, 0, 100) { Reverse = true } }
            };
            SwampWarrior = new FrameSet      //人形树动作帧
            {
                { MirAction.Standing, new Frame(0, 10, 0, 500) },
                { MirAction.Walking, new Frame(80, 6, 0, 200) },
                { MirAction.Attack1, new Frame(128, 10, 0, 100) },
                { MirAction.Attack2, new Frame(208, 10, 0, 100) },
                { MirAction.Struck, new Frame(288, 3, 0, 200) },
                { MirAction.Die, new Frame(312, 10, 0, 100) },
                { MirAction.Dead, new Frame(321, 1, 9, 1000) },
                { MirAction.Revive, new Frame(312, 10, 0, 100) { Reverse = true } }
            };
            Mantis = new FrameSet      //蚁人动作帧
            {
                { MirAction.Standing, new Frame(0, 7, 0, 500) },
                { MirAction.Walking, new Frame(56, 6, 0, 200) },
                { MirAction.Attack1, new Frame(104, 8, 0, 100) },
                { MirAction.Attack2, new Frame(168, 7, 0, 100) },
                { MirAction.Struck, new Frame(224, 3, 0, 200) },
                { MirAction.Die, new Frame(248, 8, 0, 100) },
                { MirAction.Dead, new Frame(255, 1, 7, 1000) },
                { MirAction.Revive, new Frame(248, 8, 0, 100) { Reverse = true } }
            };
            GasToad = new FrameSet      //铜壳毒蟾动作帧
            {
                { MirAction.Standing, new Frame(0, 8, 0, 500) },
                { MirAction.Walking, new Frame(64, 6, 0, 200) },
                { MirAction.Attack1, new Frame(112, 10, 0, 100) },
                { MirAction.Attack2, new Frame(192, 8, 0, 100) },
                { MirAction.Attack3, new Frame(256, 10, 0, 100) },
                { MirAction.Struck, new Frame(336, 3, 0, 200) },
                { MirAction.Die, new Frame(360, 10, 0, 100) },
                { MirAction.Dead, new Frame(369, 1, 9, 1000) },
                { MirAction.Revive, new Frame(360, 10, 0, 100) { Reverse = true } }
            };
            DarkOmaKing = new FrameSet      //奥玛黑灵动作帧
            {
                { MirAction.Standing, new Frame(0, 10, 0, 200) },
                { MirAction.Walking, new Frame(80, 6, 0, 200) },
                { MirAction.Attack1, new Frame(128, 9, 0, 100) },
                { MirAction.Attack2, new Frame(200, 34, 0, 100) },
                { MirAction.Attack3, new Frame(472, 8, 0, 100) },
                { MirAction.Attack4, new Frame(536, 9, 0, 100) },
                { MirAction.AttackRange1, new Frame(608, 9, 0, 100) },
                { MirAction.Struck, new Frame(680, 3, 0, 200) },
                { MirAction.Die, new Frame(704, 10, 0, 100) },
                { MirAction.Dead, new Frame(713, 1, 9, 1000) },
                { MirAction.Revive, new Frame(704, 10, 0, 100) { Reverse = true } }
            };
            PowerUpBead = new FrameSet      //攻击力上升玉动作帧
            {
                { MirAction.Standing, new Frame(0, 7, -7, 100) },
                { MirAction.Attack1, new Frame(7, 6, -6, 100) },
                { MirAction.Appear, new Frame(24, 6, -6, 100) },
                { MirAction.Struck, new Frame(13, 3, -3, 200) },
                { MirAction.Die, new Frame(16, 8, -8, 120) },
                { MirAction.Dead, new Frame(23, 1, -1, 1000) },
            };
            HealingBead = new FrameSet      //恢复玉动作帧
            {
                { MirAction.Standing, new Frame(0, 7, -7, 100) },
                { MirAction.Attack1, new Frame(7, 6, -6, 100) },
                { MirAction.Appear, new Frame(24, 6, -6, 100) },
                { MirAction.Struck, new Frame(13, 3, -3, 200) },
                { MirAction.Die, new Frame(16, 8, -8, 120) },
                { MirAction.Dead, new Frame(23, 1, -1, 1000) },
            };
            LightningBead = new FrameSet      //闪电玉动作帧
            {
                { MirAction.Standing, new Frame(0, 7, -7, 100) },
                { MirAction.AttackRange1, new Frame(7, 6, -6, 80) },
                { MirAction.Appear, new Frame(24, 6, -6, 100) },
                { MirAction.Struck, new Frame(13, 3, -3, 200) },
                { MirAction.Die, new Frame(16, 8, -8, 120) },
                { MirAction.Dead, new Frame(23, 1, -1, 1000) },
            };
            OmaWitchDoctor = new FrameSet      //奥玛祭祀长动作帧
            {
                { MirAction.Standing, new Frame(0, 9, 0, 500) },
                { MirAction.Walking, new Frame(72, 6, 0, 200) },
                { MirAction.Attack1, new Frame(120, 7, 0, 100) },
                { MirAction.AttackRange1, new Frame(176, 7, 0, 100) },
                { MirAction.AttackRange2, new Frame(232, 9, 0, 100) },
                { MirAction.Struck, new Frame(304, 3, 0, 200) },
                { MirAction.Die, new Frame(328, 9, 0, 100) },
                { MirAction.Dead, new Frame(336, 1, 8, 1000) },
                { MirAction.Revive, new Frame(328, 9, 0, 100) { Reverse = true } }
            };
            OmaMage = new FrameSet      //奥玛赤兵动作帧
            {
                { MirAction.Standing, new Frame(0, 10, 0, 500) },
                { MirAction.Walking, new Frame(80, 6, 0, 200) },
                { MirAction.Attack1, new Frame(128, 10, 0, 100) },
                { MirAction.Attack2, new Frame(208, 10, 0, 100) },
                { MirAction.Struck, new Frame(288, 3, 0, 200) },
                { MirAction.Die, new Frame(312, 10, 0, 100) },
                { MirAction.Dead, new Frame(321, 1, 9, 1000) },
                { MirAction.Revive, new Frame(312, 10, 0, 100) { Reverse = true } }
            };
            OmaAssassin = new FrameSet      //奥玛黑兵动作帧
            {
                { MirAction.Standing, new Frame(0, 10, 0, 500) },
                { MirAction.Walking, new Frame(80, 6, 0, 200) },
                { MirAction.Attack1, new Frame(128, 10, 0, 100) },
                { MirAction.Struck, new Frame(208, 3, 0, 200) },
                { MirAction.Die, new Frame(232, 10, 0, 100) },
                { MirAction.Dead, new Frame(241, 1, 9, 1000) },
                { MirAction.Revive, new Frame(232, 10, 0, 100) { Reverse = true } }
            };
            OmaSlasher = new FrameSet      //多目奥玛动作帧
            {
                { MirAction.Standing, new Frame(0, 10, 0, 500) },
                { MirAction.Walking, new Frame(80, 6, 0, 200) },
                { MirAction.Attack1, new Frame(128, 10, 0, 100) },
                { MirAction.Struck, new Frame(208, 3, 0, 200) },
                { MirAction.Die, new Frame(232, 9, 0, 100) },
                { MirAction.Dead, new Frame(240, 1, 8, 1000) },
                { MirAction.Revive, new Frame(232, 9, 0, 100) { Reverse = true } }
            };
            OmaBlest = new FrameSet      //巨拳奥玛动作帧
            {
                { MirAction.Standing, new Frame(0, 10, 0, 500) },
                { MirAction.Walking, new Frame(80, 6, 0, 200) },
                { MirAction.Attack1, new Frame(128, 10, 0, 100) },
                { MirAction.Attack2, new Frame(208, 10, 0, 100) },
                { MirAction.Struck, new Frame(288, 3, 0, 200) },
                { MirAction.Die, new Frame(312, 10, 0, 100) },
                { MirAction.Dead, new Frame(321, 1, 9, 1000) },
                { MirAction.Revive, new Frame(312, 10, 0, 100) { Reverse = true } }
            };
            OmaCannibal = new FrameSet      //苔口奥玛动作帧
            {
                { MirAction.Standing, new Frame(0, 9, 0, 500) },
                { MirAction.Walking, new Frame(72, 6, 0, 200) },
                { MirAction.Attack1, new Frame(120, 8, 0, 100) },
                { MirAction.AttackRange1, new Frame(184, 9, 0, 100) },
                { MirAction.Struck, new Frame(256, 3, 0, 200) },
                { MirAction.Die, new Frame(280, 10, 0, 100) },
                { MirAction.Dead, new Frame(289, 1, 9, 1000) },
                { MirAction.Revive, new Frame(280, 10, 0, 100) { Reverse = true } }
            };
            TwinHeadBeast = new FrameSet      //双头黑虎动作帧
            {
                { MirAction.Standing, new Frame(0, 9, 0, 500) },
                { MirAction.Walking, new Frame(72, 6, 0, 200) },
                { MirAction.Attack1, new Frame(120, 9, 0, 100) },
                { MirAction.Attack2, new Frame(296, 7, 0, 100) },
                { MirAction.Struck, new Frame(192, 3, 0, 200) },
                { MirAction.Die, new Frame(216, 10, 0, 100) },
                { MirAction.Dead, new Frame(225, 1, 9, 1000) },
                { MirAction.Revive, new Frame(216, 10, 0, 100) { Reverse = true } }
            };
            DarkBaboon = new FrameSet      //剑银黑猩猩动作帧
            {
                { MirAction.Standing, new Frame(0, 6, 0, 500) },
                { MirAction.Walking, new Frame(48, 6, 0, 200) },
                { MirAction.Attack1, new Frame(96, 7, 0, 100) },
                { MirAction.Attack2, new Frame(232, 8, 0, 100) },
                { MirAction.Attack3, new Frame(296, 7, 0, 100) },
                { MirAction.Struck, new Frame(152, 3, 0, 200) },
                { MirAction.Die, new Frame(176, 7, 0, 100) },
                { MirAction.Dead, new Frame(182, 1, 6, 1000) },
                { MirAction.Revive, new Frame(176, 7, 0, 100) { Reverse = true } }
            };
            DarkWingedOma = new FrameSet      //青飞翼奥玛动作帧
            {
                { MirAction.Standing, new Frame(0, 4, 0, 500) },
                { MirAction.Walking, new Frame(32, 6, 0, 100) },
                { MirAction.Attack1, new Frame(80, 6, 0, 100) },
                { MirAction.Struck, new Frame(128, 2, 0, 200) },
                { MirAction.Die, new Frame(144, 10, 0, 100) },
                { MirAction.Dead, new Frame(153, 1, 9, 1000) },
                { MirAction.Revive, new Frame(144, 10, 0, 100) { Reverse = true } }
            };
            ChieftainSword = new FrameSet      //阳龙王动作帧
            {
                { MirAction.Standing, new Frame(0, 4, 0, 500) },
                { MirAction.Walking, new Frame(32, 8, 0, 200) },
                { MirAction.Attack1, new Frame(96, 8, 0, 100) },
                { MirAction.Attack2, new Frame(160, 9, 0, 100) },
                { MirAction.Attack3, new Frame(232, 10, 0, 100) },
                { MirAction.AttackRange1, new Frame(312, 10, 0, 200) },
                { MirAction.AttackRange2, new Frame(384, 9, 0, 200) },
                { MirAction.Struck, new Frame(658, 2, 0, 200) },
                { MirAction.Die, new Frame(672, 10, 0, 100) },
                { MirAction.Dead, new Frame(681, 1, 9, 1000) },
                { MirAction.Revive, new Frame(672, 10, 0, 100) { Reverse = true } }
            };
            ChieftainArcher = new FrameSet      //流觞弓将动作帧
            {
                { MirAction.Standing, new Frame(0, 4, 0, 500) },
                { MirAction.Walking, new Frame(32, 6, 0, 200) },
                { MirAction.Attack1, new Frame(80, 9, 0, 100) },
                { MirAction.Jump, new Frame(152, 8, 0, 100) },
                { MirAction.Struck, new Frame(216, 3, 0, 200) },
                { MirAction.Die, new Frame(240, 9, 0, 100) },
                { MirAction.Dead, new Frame(248, 1, 8, 1000) },
                { MirAction.Revive, new Frame(240, 9, 0, 100) { Reverse = true } }
            };
            Leopard = new FrameSet      //金钱豹动作帧
            {
                { MirAction.Standing, new Frame(0, 4, 0, 500) },
                { MirAction.Walking, new Frame(32, 6, 0, 100) },
                { MirAction.Attack1, new Frame(80, 10, 0, 100) },
                { MirAction.Struck, new Frame(160, 3, 0, 200) },
                { MirAction.Die, new Frame(184, 8, 0, 100) },
                { MirAction.Dead, new Frame(191, 1, 7, 1000) },
            };
            Turtlegrass = new FrameSet      //石草龟动作帧
            {
                { MirAction.Stoned, new Frame(0, 1, 0, 1000) },
                { MirAction.Show, new Frame(8, 4, 0, 200) },
                { MirAction.Hide, new Frame(11, 4, 0, 100) },
                { MirAction.Standing, new Frame(40, 4, 0, 200) },
                { MirAction.Walking, new Frame(72, 6, 0, 100) },
                { MirAction.Attack1, new Frame(120, 8, 0, 100) },
                { MirAction.Attack2, new Frame(184, 9, 0, 100) },
                { MirAction.Struck, new Frame(256, 3, 0, 200) },
                { MirAction.Die, new Frame(280, 10, 0, 100) },
                { MirAction.Dead, new Frame(289, 1, 9, 1000) },
                { MirAction.Revive, new Frame(280, 10, 0, 100) { Reverse = true } }
            };
            Bear = new FrameSet      //熊动作帧
            {
                { MirAction.Standing, new Frame(0, 4, 0, 500) },
                { MirAction.Walking, new Frame(32, 6, 0, 100) },
                { MirAction.Attack1, new Frame(80, 9, 0, 100) },
                { MirAction.Attack2, new Frame(152, 8, 0, 100) },
                { MirAction.Struck, new Frame(216, 3, 0, 200) },
                { MirAction.Die, new Frame(240, 9, 0, 100) },
                { MirAction.Dead, new Frame(248, 1, 8, 1000) },
            };
            ManTree = new FrameSet      //杉树精魄动作帧
            {
                { MirAction.Stoned, new Frame(0, 1, 0, 1000) },
                { MirAction.Show, new Frame(8, 7, 0, 200) },
                { MirAction.Hide, new Frame(15, 7, 0, 200) },
                { MirAction.Standing, new Frame(64, 4, 0, 500) },
                { MirAction.Walking, new Frame(96, 6, 0, 100) },
                { MirAction.Attack1, new Frame(144, 8, 0, 100) },
                { MirAction.Attack2, new Frame(208, 10, 0, 100) },
                { MirAction.Attack3, new Frame(288, 10, 0, 100) },
                { MirAction.Struck, new Frame(368, 3, 0, 200) },
                { MirAction.Die, new Frame(392, 10, 0, 100) },
                { MirAction.Dead, new Frame(401, 1, 9, 1000) },
            };
            FrostTiger = new FrameSet      //弦月幻虎动作帧
            {
                { MirAction.Standing, new Frame(0, 4, 0, 500) },
                { MirAction.Walking, new Frame(32, 6, 0, 100) },
                { MirAction.Attack1, new Frame(80, 6, 0, 100) },
                { MirAction.AttackRange1, new Frame(244, 6, 0, 100) },
                { MirAction.Struck, new Frame(128, 2, 0, 200) },
                { MirAction.SitDown, new Frame(272, 4, 0, 500) },
                { MirAction.Die, new Frame(144, 10, 0, 100) },
                { MirAction.Dead, new Frame(248, 1, 9, 1000) },
                { MirAction.Revive, new Frame(144, 10, 0, 100) { Reverse = true } }
            };
            Kirin = new FrameSet      //麒麟动作帧
            {
                { MirAction.Standing, new Frame(0, 4, 0, 500) },
                { MirAction.Walking, new Frame(104, 6, 0, 200) },
                { MirAction.Attack1, new Frame(152, 7, 0, 100) },
                { MirAction.Attack2, new Frame(208, 12, 0, 100) },
                { MirAction.Attack3, new Frame(304, 6, 0, 100) },
                { MirAction.Struck, new Frame(352, 3, 0, 200) },
                { MirAction.Die, new Frame(376, 2, 0, 100) },
                { MirAction.Dead, new Frame(248, 1, 1, 1000) },
                { MirAction.Revive, new Frame(376, 2, 0, 100) { Reverse = true } }
            };
            Tornado = new FrameSet      //沙尘暴动作帧
            {
                { MirAction.Standing, new Frame(0, 4, 0, 500) },
                { MirAction.Walking, new Frame(32, 6, 0, 200) },
                { MirAction.Attack1, new Frame(80, 6, 0, 100) },
                { MirAction.AttackRange1, new Frame(116, 8, 0, 100) },
                { MirAction.Struck, new Frame(128, 2, 0, 200) },
                { MirAction.Die, new Frame(200, 9, 0, 100) },
                { MirAction.Dead, new Frame(271, 1, 9, 1000) },
                { MirAction.Revive, new Frame(208, 9, 0, 100) { Reverse = true } }
            };
            DragonArcher = new FrameSet      //龙骨弓箭手动作帧
            {
                { MirAction.Standing, new Frame(0, 4, 0, 500) },
                { MirAction.Walking, new Frame(112, 8, 0, 200) },
                { MirAction.Attack1, new Frame(176, 8, 0, 100) },
                { MirAction.Jump, new Frame(240, 6, 0, 100) },
                { MirAction.Struck, new Frame(288, 3, 0, 200) },
                { MirAction.Die, new Frame(312, 13, 0, 100) },
                { MirAction.Dead, new Frame(324, 1, 12, 1000) },
                { MirAction.Revive, new Frame(312, 13, 0, 100) { Reverse = true } }
            };
            DragonWarrior = new FrameSet      //龙骨战士动作帧
            {
                { MirAction.Standing, new Frame(0, 4, 0, 500) },
                { MirAction.Walking, new Frame(112, 8, 0, 200) },
                { MirAction.Attack1, new Frame(176, 8, 0, 100) },
                { MirAction.Attack2, new Frame(240, 10, 0, 100) },
                { MirAction.Attack3, new Frame(320, 7, 0, 100) },
                { MirAction.Struck, new Frame(376, 3, 0, 200) },
                { MirAction.Die, new Frame(400, 13, 0, 100) },
                { MirAction.Dead, new Frame(412, 1, 12, 1000) },
                { MirAction.Revive, new Frame(400, 13, 0, 100) { Reverse = true } }
            };
            BlackTortoise = new FrameSet      //沼玄武动作帧
            {
                { MirAction.Standing, new Frame(0, 4, 0, 500) },
                { MirAction.Walking, new Frame(112, 4, 0, 200) },
                { MirAction.Attack1, new Frame(144, 6, 0, 100) },
                { MirAction.Attack2, new Frame(192, 7, 0, 100) },
                { MirAction.AttackRange1, new Frame(248, 6, 0, 100) },
                { MirAction.Struck, new Frame(296, 2, 0, 200) },
                { MirAction.Die, new Frame(312, 6, 0, 100) },
                { MirAction.Dead, new Frame(317, 1, 5, 1000) },
                { MirAction.Revive, new Frame(312, 6, 0, 100) { Reverse = true } }
            };
            WaterDragon = new FrameSet      //水龙动作帧
            {
                { MirAction.Show, new Frame(0, 8, 0, 100) },
                { MirAction.Hide, new Frame(7, 8, 0, 100) },
                { MirAction.Standing, new Frame(64, 6, 0, 200) },
                { MirAction.AttackRange1, new Frame(112, 8, 0, 100) },
                { MirAction.Attack1, new Frame(176, 10, 0, 100) },
                { MirAction.Struck, new Frame(256, 3, 0, 200) },
                { MirAction.Die, new Frame(280, 15, 0, 100) },
                { MirAction.Dead, new Frame(294, 1, 14, 1000) },
                { MirAction.Revive, new Frame(280, 15, 0, 100) { Reverse = true } }
            };
            AncientBringer = new FrameSet      //丹墨武动作帧
            {
                { MirAction.Standing, new Frame(0, 6, 0, 500) },
                { MirAction.Walking, new Frame(48, 8, 0, 200) },
                { MirAction.Attack1, new Frame(112, 10, 0, 100) },
                { MirAction.Attack2, new Frame(304, 10, 0, 100) },
                { MirAction.AttackRange1, new Frame(384, 8, 0, 100) },
                { MirAction.AttackRange2, new Frame(448, 8, 0, 100) },
                { MirAction.Struck, new Frame(192, 4, 0, 200) },
                { MirAction.Die, new Frame(224, 10, 0, 100) },
                { MirAction.Dead, new Frame(233, 1, 9, 1000) },
                { MirAction.Revive, new Frame(224, 10, 0, 100) { Reverse = true } }
            };
            BurningZombie = new FrameSet      //黑天鬼动作帧
            {
                { MirAction.Standing, new Frame(0, 4, 0, 500) },
                { MirAction.Walking, new Frame(32, 8, 0, 200) },
                { MirAction.Attack1, new Frame(96, 7, 0, 100) },
                { MirAction.AttackRange1, new Frame(256, 7, 0, 100) },
                { MirAction.Struck, new Frame(152, 3, 0, 200) },
                { MirAction.Die, new Frame(176, 10, 0, 100) },
                { MirAction.Dead, new Frame(185, 1, 9, 1000) },
                { MirAction.Revive, new Frame(176, 10, 0, 100) { Reverse = true } }
            };
            DeathCrawler = new FrameSet      //逆天鬼动作帧
            {
                { MirAction.Standing, new Frame(0, 4, 0, 500) },
                { MirAction.Walking, new Frame(32, 8, 0, 200) },
                { MirAction.Attack1, new Frame(96, 7, 0, 100) },
                { MirAction.Struck, new Frame(152, 3, 0, 200) },
                { MirAction.Die, new Frame(176, 9, 0, 100) },
                { MirAction.Dead, new Frame(184, 1, 8, 1000) },
                { MirAction.Revive, new Frame(176, 9, 0, 100) { Reverse = true } }
            };
            HardenRhino = new FrameSet      //犀牛动作帧
            {
                { MirAction.Standing, new Frame(0, 6, 0, 500) },
                { MirAction.Walking, new Frame(48, 10, 0, 200) },
                { MirAction.Attack1, new Frame(128, 7, 0, 100) },
                { MirAction.Attack2, new Frame(288, 7, 0, 100) },
                { MirAction.Struck, new Frame(184, 3, 0, 200) },
                { MirAction.Die, new Frame(208, 10, 0, 100) },
                { MirAction.Dead, new Frame(217, 1, 9, 1000) },
                { MirAction.Running, new Frame(344, 6, 0, 100) },
            };
            BloodBaboon = new FrameSet      //猩猩动作帧
            {
                { MirAction.Standing, new Frame(0, 6, 0, 500) },
                { MirAction.Walking, new Frame(48, 6, 0, 200) },
                { MirAction.Attack1, new Frame(96, 7, 0, 100) },
                { MirAction.Attack2, new Frame(240, 9, 0, 100) },
                { MirAction.Struck, new Frame(152, 3, 0, 200) },
                { MirAction.Die, new Frame(176, 8, 0, 100) },
                { MirAction.Dead, new Frame(183, 1, 7, 1000) },
                { MirAction.Revive, new Frame(176, 8, 0, 100) { Reverse = true } }
            };
            LightBeast = new FrameSet      //南蛮白虎动作帧
            {
                { MirAction.Standing, new Frame(0, 6, 0, 500) },
                { MirAction.Walking, new Frame(48, 6, 0, 200) },
                { MirAction.Attack1, new Frame(96, 7, 0, 100) },
                { MirAction.Attack2, new Frame(248, 6, 0, 100) },
                { MirAction.Struck, new Frame(152, 3, 0, 200) },
                { MirAction.Die, new Frame(176, 9, 0, 100) },
                { MirAction.Dead, new Frame(184, 1, 8, 1000) },
                { MirAction.Revive, new Frame(176, 9, 0, 100) { Reverse = true } }
            };
            DarkBeast = new FrameSet      //南蛮黑虎动作帧
            {
                { MirAction.Standing, new Frame(0, 6, 0, 500) },
                { MirAction.Walking, new Frame(48, 6, 0, 200) },
                { MirAction.Attack1, new Frame(96, 7, 0, 100) },
                { MirAction.Attack2, new Frame(248, 6, 0, 100) },
                { MirAction.Struck, new Frame(152, 3, 0, 200) },
                { MirAction.Die, new Frame(176, 9, 0, 100) },
                { MirAction.Dead, new Frame(184, 1, 8, 1000) },
                { MirAction.Revive, new Frame(176, 9, 0, 100) { Reverse = true } }
            };
            WhiteMammoth = new FrameSet      //白象动作帧
            {
                { MirAction.Standing, new Frame(0, 6, 0, 500) },
                { MirAction.Walking, new Frame(48, 10, 0, 200) },
                { MirAction.Attack1, new Frame(128, 6, 0, 100) },
                { MirAction.Attack2, new Frame(280, 6, 0, 100) },
                { MirAction.Attack3, new Frame(328, 6, 0, 100) },
                { MirAction.Struck, new Frame(176, 3, 0, 200) },
                { MirAction.Die, new Frame(200, 10, 0, 100) },
                { MirAction.Dead, new Frame(209, 1, 9, 1000) },
                { MirAction.Revive, new Frame(200, 10, 0, 100) { Reverse = true } }
            };
            UndeadWolf = new FrameSet      //悍豺动作帧
            {
                { MirAction.Standing, new Frame(0, 4, 0, 500) },
                { MirAction.Walking, new Frame(32, 6, 0, 200) },
                { MirAction.Attack1, new Frame(80, 8, 0, 100) },
                { MirAction.Struck, new Frame(144, 3, 0, 200) },
                { MirAction.Die, new Frame(168, 10, 0, 100) },
                { MirAction.Dead, new Frame(177, 1, 9, 1000) },
                { MirAction.Revive, new Frame(168, 10, 0, 100) { Reverse = true } }
            };
            DemonWolf = new FrameSet      //狂悍豺动作帧
            {
                { MirAction.Standing, new Frame(0, 4, 0, 500) },
                { MirAction.Walking, new Frame(32, 6, 0, 200) },
                { MirAction.Attack1, new Frame(80, 8, 0, 100) },
                { MirAction.Attack2, new Frame(248, 8, 0, 100) },
                { MirAction.Struck, new Frame(144, 3, 0, 200) },
                { MirAction.Die, new Frame(168, 10, 0, 100) },
                { MirAction.Dead, new Frame(177, 1, 9, 1000) },
                { MirAction.Revive, new Frame(168, 10, 0, 100) { Reverse = true } }
            };
            FrozenZombie = new FrameSet      //寒天鬼动作帧
            {
                { MirAction.Standing, new Frame(0, 4, 0, 500) },
                { MirAction.Walking, new Frame(32, 8, 0, 200) },
                { MirAction.Attack1, new Frame(96, 7, 0, 100) },
                { MirAction.Attack2, new Frame(256, 7, 0, 100) },
                { MirAction.Struck, new Frame(152, 3, 0, 200) },
                { MirAction.Die, new Frame(176, 10, 0, 100) },
                { MirAction.Dead, new Frame(185, 1, 9, 1000) },
                { MirAction.Revive, new Frame(176, 10, 0, 100) { Reverse = true } }
            };
            MudZombie = new FrameSet      //灭鬼动作帧
            {
                { MirAction.Standing, new Frame(0, 6, 0, 500) },
                { MirAction.Walking, new Frame(48, 10, 0, 200) },
                { MirAction.Attack1, new Frame(128, 6, 0, 100) },
                { MirAction.Attack2, new Frame(248, 1, 7, 1000) },
                { MirAction.Struck, new Frame(176, 3, 0, 200) },
                { MirAction.Die, new Frame(200, 6, 0, 100) },
                { MirAction.Dead, new Frame(205, 1, 5, 1000) },
                { MirAction.Revive, new Frame(200, 6, 0, 100) { Reverse = true } }
            };
            TucsonGeneral = new FrameSet      //鱼鬼动作帧
            {
                { MirAction.Standing, new Frame(0, 8, 0, 500) },
                { MirAction.Walking, new Frame(64, 6, 0, 200) },
                { MirAction.Attack1, new Frame(112, 7, 0, 100) },
                { MirAction.Attack2, new Frame(168, 7, 0, 100) },
                { MirAction.AttackRange1, new Frame(224, 7, 0, 100) },
                { MirAction.AttackRange2, new Frame(280, 8, 0, 100) },
                { MirAction.AttackRange3, new Frame(344, 8, 0, 100) },
                { MirAction.Struck, new Frame(408, 4, 0, 200) },
                { MirAction.Die, new Frame(440, 8, 0, 100) },
                { MirAction.Dead, new Frame(447, 1, 7, 1000) },
                { MirAction.Revive, new Frame(440, 8, 0, 100) { Reverse = true } }
            };
            TucsonWarrior = new FrameSet      //鱼将军动作帧
            {
                { MirAction.Standing, new Frame(0, 5, 0, 500) },
                { MirAction.Walking, new Frame(40, 6, 0, 200) },
                { MirAction.Attack1, new Frame(88, 8, 0, 100) },
                { MirAction.Attack2, new Frame(152, 8, 0, 100) },
                { MirAction.Struck, new Frame(216, 3, 0, 200) },
                { MirAction.Die, new Frame(240, 7, 0, 100) },
                { MirAction.Dead, new Frame(246, 1, 6, 1000) },
                { MirAction.Revive, new Frame(240, 7, 0, 100) { Reverse = true } }
            };
            TucsonMage = new FrameSet      //鱼术士动作帧
            {
                { MirAction.Standing, new Frame(0, 7, 0, 500) },
                { MirAction.Walking, new Frame(56, 6, 0, 200) },
                { MirAction.Attack1, new Frame(104, 7, 0, 100) },
                { MirAction.Attack2, new Frame(160, 7, 0, 100) },
                { MirAction.Struck, new Frame(216, 3, 0, 200) },
                { MirAction.Die, new Frame(240, 7, 0, 100) },
                { MirAction.Dead, new Frame(246, 1, 6, 1000) },
                { MirAction.Revive, new Frame(240, 7, 0, 100) { Reverse = true } }
            };
            TucsonFighter = new FrameSet      //鱼枪兵动作帧
            {
                { MirAction.Standing, new Frame(0, 6, 0, 500) },
                { MirAction.Walking, new Frame(48, 6, 0, 200) },
                { MirAction.Attack1, new Frame(96, 9, 0, 100) },
                { MirAction.Attack2, new Frame(168, 8, 0, 100) },
                { MirAction.Struck, new Frame(232, 3, 0, 200) },
                { MirAction.Die, new Frame(256, 8, 0, 100) },
                { MirAction.Dead, new Frame(263, 1, 7, 1000) },
                { MirAction.Revive, new Frame(256, 8, 0, 100) { Reverse = true } }
            };
            Tucson = new FrameSet      //幼年魚人动作帧
            {
                { MirAction.Standing, new Frame(0, 6, 0, 500) },
                { MirAction.Walking, new Frame(48, 6, 0, 200) },
                { MirAction.Attack1, new Frame(96, 9, 0, 100) },
                { MirAction.Struck, new Frame(168, 3, 0, 200) },
                { MirAction.Die, new Frame(192, 9, 0, 100) },
                { MirAction.Dead, new Frame(200, 1, 8, 1000) },
                { MirAction.Revive, new Frame(192, 10, 0, 100) { Reverse = true } }
            };
            CannibalTentacles = new FrameSet      //血蛞蝓动作帧
            {
                { MirAction.Standing, new Frame(0, 9, 0, 500) },
                { MirAction.Walking, new Frame(72, 5, 0, 200) },
                { MirAction.Attack1, new Frame(112, 8, 0, 100) },
                { MirAction.Attack2, new Frame(176, 8, 0, 100) },
                { MirAction.AttackRange1, new Frame(240, 8, 0, 100) },
                { MirAction.Struck, new Frame(304, 3, 0, 200) },
                { MirAction.Die, new Frame(328, 9, 0, 100) },
                { MirAction.Dead, new Frame(336, 1, 8, 1000) },
                { MirAction.Revive, new Frame(328, 9, 0, 100) { Reverse = true } }
            };
            SandSnail = new FrameSet      //壳蟾动作帧
            {
                { MirAction.Standing, new Frame(0, 9, 0, 500) },
                { MirAction.Walking, new Frame(72, 6, 0, 200) },
                { MirAction.Attack1, new Frame(120, 8, 0, 100) },
                { MirAction.Attack2, new Frame(184, 10, 0, 100) },
                { MirAction.Attack3, new Frame(264, 10, 0, 100) },
                { MirAction.Struck, new Frame(344, 3, 0, 200) },
                { MirAction.Die, new Frame(368, 10, 0, 100) },
                { MirAction.Dead, new Frame(377, 1, 9, 1000) },
                { MirAction.Revive, new Frame(368, 10, 0, 100) { Reverse = true } }
            };
            VisceralWorm = new FrameSet      //肠虫,血肠虫动作帧
            {
                { MirAction.Standing, new Frame(0, 4, 0, 500) },
                { MirAction.Walking, new Frame(32, 6, 0, 100) },
                { MirAction.Attack1, new Frame(80, 6, 0, 100) },
                { MirAction.Struck, new Frame(128, 2, 0, 200) },
                { MirAction.Die, new Frame(144, 10, 0, 100) },
                { MirAction.Dead, new Frame(153, 1, 9, 1000) },
                { MirAction.Revive, new Frame(144, 10, 0, 100) { Reverse = true } }
            };
            ArmadilloElder = new FrameSet      //角鲮鲤动作帧
            {
                { MirAction.Standing, new Frame(0, 5, 0, 500) },
                { MirAction.Walking, new Frame(40, 6, 0, 200) },
                { MirAction.Attack1, new Frame(88, 10, 0, 100) },
                { MirAction.Attack2, new Frame(168, 10, 0, 100) },
                { MirAction.Jump, new Frame(248, 9, 0, 100) },
                { MirAction.Show, new Frame(424, 7, 0, 200) },
                { MirAction.Struck, new Frame(320, 3, 0, 200) },
                { MirAction.Die, new Frame(344, 10, 0, 100) },
                { MirAction.Dead, new Frame(353, 1, 9, 1000) },
                { MirAction.Revive, new Frame(336, 10, 0, 100) { Reverse = true } }
            };
            Armadillo = new FrameSet      //鲮鲤动作帧
            {
                { MirAction.Standing, new Frame(0, 6, 0, 500) },
                { MirAction.Walking, new Frame(48, 6, 0, 200) },
                { MirAction.Attack1, new Frame(96, 8, 0, 100) },
                { MirAction.Attack2, new Frame(160, 10, 0, 100) },
                { MirAction.Jump, new Frame(240, 9, 0, 100) },
                { MirAction.Show, new Frame(416, 7, 0, 200) },
                { MirAction.Struck, new Frame(312, 3, 0, 200) },
                { MirAction.Die, new Frame(336, 10, 0, 100) },
                { MirAction.Dead, new Frame(345 , 1, 9, 1000) },
                { MirAction.Revive, new Frame(336, 10, 0, 100) { Reverse = true } }
            };
            PlaguedTucson = new FrameSet      //鱼卵动作帧
            {
                { MirAction.Standing, new Frame(0, 6, 0, 500) },
                { MirAction.Walking, new Frame(48, 6, 0, 200) },
                { MirAction.Attack1, new Frame(96, 8, 0, 100) },
                { MirAction.Struck, new Frame(160, 3, 0, 200) },
                { MirAction.Die, new Frame(184, 8, 0, 100) },
                { MirAction.Dead, new Frame(191 , 1, 7, 1000) },
                { MirAction.Revive, new Frame(184, 8, 0, 100) { Reverse = true } }
            };
            GeneralMeowMeow = new FrameSet      //真猫将军动作帧
            {
                { MirAction.Standing, new Frame(0, 6, 0, 500) },
                { MirAction.Walking, new Frame(48, 10, 0, 100) },
                { MirAction.Attack1, new Frame(128, 10, 0, 100) },
                { MirAction.Attack2, new Frame(208, 8, 0, 100) },
                { MirAction.AttackRange1, new Frame(272, 8, 0, 100) },
                { MirAction.DashAttack, new Frame(352, 8, 0, 100) },
                { MirAction.Struck, new Frame(336, 2, 0, 200) },
                { MirAction.Die, new Frame(352, 8, 0, 100) },
                { MirAction.Dead, new Frame(359 , 1, 7, 1000) },
                { MirAction.Revive, new Frame(352, 8, 0, 100) { Reverse = true } }
            };
            RestlessJar = new FrameSet      //壶中天动作帧
            {
                { MirAction.Standing, new Frame(0, 6, 0, 500) },
                { MirAction.Attack1, new Frame(48, 7, 0, 100) },
                { MirAction.Attack2, new Frame(104, 6, 0, 100) },
                { MirAction.Attack3, new Frame(208, 8, 0, 100) },
                { MirAction.AttackRange1, new Frame(152, 7, 0, 100) },
                { MirAction.Struck, new Frame(272, 4, 0, 100) },
                { MirAction.Die, new Frame(304, 10, 0, 100) },
                { MirAction.Dead, new Frame(313, 1, 9, 1000) },
                { MirAction.Revive, new Frame(304, 10, 0, 100) { Reverse = true } }
            };
            SeedingsGeneral = new FrameSet      //九命猫妖动作帧
            {
                { MirAction.SitDown, new Frame(0, 4, 0, 500) },
                { MirAction.Standing, new Frame(32, 4, 0, 500) },
                { MirAction.Walking, new Frame(64, 7, 0, 200) },
                { MirAction.Attack1, new Frame(168, 9, 0, 100) },
                { MirAction.Attack2, new Frame(240, 9, 0, 100) },
                { MirAction.AttackRange1, new Frame(312, 8, 0, 100) },
                { MirAction.AttackRange2, new Frame(376, 9, 0, 100) },
                { MirAction.Struck, new Frame(448, 3, 0, 200) },
                { MirAction.Die, new Frame(472, 8, 0, 100) },
                { MirAction.Dead, new Frame(479, 1, 7, 1000) },
                { MirAction.Revive, new Frame(472, 10, 0, 100) { Reverse = true } }
            };
            CatShaman = new FrameSet      //灵猫法师动作帧
            {
                { MirAction.Standing, new Frame(0, 4, 0, 500) },
                { MirAction.Walking, new Frame(32, 10, 0, 200) },
                { MirAction.Attack1, new Frame(112, 6, 0, 100) },
                { MirAction.AttackRange1, new Frame(160, 7, 0, 100) },
                { MirAction.AttackRange2, new Frame(216, 7, 0, 100) },
                { MirAction.Struck, new Frame(272, 2, 0, 200) },
                { MirAction.Die, new Frame(288, 9, 0, 100) },
                { MirAction.Dead, new Frame(296, 1, 8, 1000) },
                { MirAction.Revive, new Frame(288, 9, 0, 100) { Reverse = true } }
            };
            StrayCat = new FrameSet      //猫妖武士动作帧
            {
                { MirAction.Standing, new Frame(0, 4, 0, 500) },
                { MirAction.Walking, new Frame(112, 6, 0, 200) },
                { MirAction.Attack1, new Frame(160, 10, 0, 100) },
                { MirAction.Attack2, new Frame(240, 10, 0, 100) },
                { MirAction.Attack3, new Frame(320, 13, 0, 100) },
                { MirAction.Struck, new Frame(424, 3, 0, 200) },
                { MirAction.Die, new Frame(448, 10, 0, 100) },
                { MirAction.Dead, new Frame(457, 1, 9, 1000) },
                { MirAction.Revive, new Frame(448, 10, 0, 100) { Reverse = true } }
            };
            BlackHammerCat = new FrameSet      //黑锤猫卫动作帧
            {
                { MirAction.Standing, new Frame(0, 4, 0, 500) },
                { MirAction.Walking, new Frame(32, 6, 0, 200) },
                { MirAction.Attack1, new Frame(80, 7, 0, 100) },
                { MirAction.Attack2, new Frame(136, 12, 0, 100) },
                { MirAction.Struck, new Frame(232, 3, 0, 200) },
                { MirAction.Die, new Frame(256, 10, 0, 100) },
                { MirAction.Dead, new Frame(265, 1, 9, 1000) },
                { MirAction.Revive, new Frame(256, 10, 0, 100) { Reverse = true } }
            };
            StainHammerCat = new FrameSet      //白锤猫卫动作帧
            {
                { MirAction.Standing, new Frame(0, 4, 0, 500) },
                { MirAction.Walking, new Frame(32, 6, 0, 200) },
                { MirAction.Attack1, new Frame(80, 7, 0, 100) },
                { MirAction.Struck, new Frame(136, 3, 0, 200) },
                { MirAction.Die, new Frame(160, 10, 0, 100) },
                { MirAction.Dead, new Frame(169, 1, 9, 1000) },
                { MirAction.Revive, new Frame(160, 10, 0, 100) { Reverse = true } }
            };
            CatWidow = new FrameSet      //长枪猫卫动作帧
            {
                { MirAction.Standing, new Frame(0, 4, 0, 500) },
                { MirAction.Walking, new Frame(32, 6, 0, 200) },
                { MirAction.Attack1, new Frame(80, 6, 0, 100) },
                { MirAction.Attack2, new Frame(128, 6, 0, 100) },
                { MirAction.Struck, new Frame(176, 2, 0, 200) },
                { MirAction.Die, new Frame(192, 8, 0, 100) },
                { MirAction.Dead, new Frame(199, 1, 7, 1000) },
                { MirAction.Revive, new Frame(192, 8, 0, 100) { Reverse = true } }
            };
            FireCat = new FrameSet      //火焰猫妖动作帧
            {
                { MirAction.Standing, new Frame(0, 4, 0, 500) },
                { MirAction.Walking, new Frame(32, 6, 0, 200) },
                { MirAction.Attack1, new Frame(80, 5, 0, 100) },
                { MirAction.Attack2, new Frame(120, 6, 0, 100) },
                { MirAction.Struck, new Frame(168, 2, 0, 200) },
                { MirAction.Die, new Frame(184, 8, 0, 100) },
                { MirAction.Dead, new Frame(191, 1, 7, 1000) },
                { MirAction.Revive, new Frame(184, 8, 0, 100) { Reverse = true } }
            };
            FightingCat = new FrameSet      //灵猫斗士动作帧
            {
                { MirAction.Standing, new Frame(0, 4, 0, 500) },
                { MirAction.Walking, new Frame(32, 6, 0, 200) },
                { MirAction.Attack1, new Frame(80, 6, 0, 100) },
                { MirAction.Struck, new Frame(128, 2, 0, 200) },
                { MirAction.Die, new Frame(144, 8, 0, 100) },
                { MirAction.Dead, new Frame(151, 1, 7, 1000) },
                { MirAction.Revive, new Frame(144, 8, 0, 100) { Reverse = true } }
            };
            Jar2 = new FrameSet      //四耳圣壶动作帧
            {
                { MirAction.Standing, new Frame(0, 10, 0, 500) },
                { MirAction.Attack1, new Frame(80, 6, 0, 100) },
                { MirAction.AttackRange1, new Frame(128, 10, 0, 100) },
                { MirAction.Struck, new Frame(208, 3, 0, 200) },
                { MirAction.Die, new Frame(232, 10, 0, 100) },
                { MirAction.Dead, new Frame(241, 1, 9, 1000) },
                { MirAction.Revive, new Frame(232, 10, 0, 100) { Reverse = true } }
            };
            Jar1 = new FrameSet      //三眼圣壶动作帧
            {
                { MirAction.Standing, new Frame(0, 1, 3, 200) },
                { MirAction.Attack1, new Frame(0, 4, 0, 200) },
                { MirAction.Struck, new Frame(32, 2, 0, 200) },
                { MirAction.Die, new Frame(48, 10, 0, 100) },
                { MirAction.Dead, new Frame(57, 1, 9, 1000) },
                { MirAction.Revive, new Frame(48, 10, 0, 100) { Reverse = true } }
            };
            HellKeeper = new FrameSet      //地狱守门人动作帧
            {
                { MirAction.Standing, new Frame(0, 4, -4, 500) },
                { MirAction.Attack1, new Frame(4, 8, 0, 100) },
                { MirAction.Attack2, new Frame(22, 10, -10, 100) },
                { MirAction.Struck, new Frame(12, 2, -2, 200) },
                { MirAction.Die, new Frame(14, 8, -8, 100) },
                { MirAction.Dead, new Frame(21, 1, -1, 1000) },
                { MirAction.Revive, new Frame(21, 1, 0, 100) { Reverse = true } }
            };
            WitchDoctor = new FrameSet      //溶魂鬼动作帧
            {
                { MirAction.Standing, new Frame(0, 4, 0, 500) },
                { MirAction.Walking, new Frame(32, 6, 0, 200) },
                { MirAction.Attack1, new Frame(80, 10, 0, 100) },
                { MirAction.AttackRange1, new Frame(256, 6, 0, 100) },
                { MirAction.Struck, new Frame(160, 2, 0, 200) },
                { MirAction.Die, new Frame(176, 10, 0, 100) },
                { MirAction.Dead, new Frame(185, 1, 9, 1000) },
                { MirAction.Revive, new Frame(176, 10, 0, 100) { Reverse = true } }
            };
            HellBolt = new FrameSet      //灭魂鬼动作帧
            {
                { MirAction.Standing, new Frame(0, 4, 0, 500) },
                { MirAction.Walking, new Frame(32, 6, 0, 200) },
                { MirAction.Attack1, new Frame(80, 10, 0, 100) },
                { MirAction.AttackRange1, new Frame(256, 6, 0, 100) },
                { MirAction.Struck, new Frame(160, 2, 0, 200) },
                { MirAction.Die, new Frame(176, 10, 0, 100) },
                { MirAction.Dead, new Frame(185, 1, 9, 1000) },
                { MirAction.Revive, new Frame(176, 10, 0, 100) { Reverse = true } }
            };
            HellCannibal = new FrameSet      //吞魂鬼动作帧
            {
                { MirAction.Standing, new Frame(0, 4, 0, 500) },
                { MirAction.Walking, new Frame(32, 6, 0, 200) },
                { MirAction.Attack1, new Frame(80, 6, 0, 100) },
                { MirAction.Attack2, new Frame(224, 10, 0, 100) },
                { MirAction.Struck, new Frame(128, 2, 0, 200) },
                { MirAction.Die, new Frame(144, 10, 0, 100) },
                { MirAction.Dead, new Frame(153, 1, 9, 1000) },
                { MirAction.Revive, new Frame(144, 10, 0, 100) { Reverse = true } }
            };
            HellPirate = new FrameSet      //钢刀鬼动作帧
            {
                { MirAction.Standing, new Frame(0, 4, 0, 500) },
                { MirAction.Walking, new Frame(32, 6, 0, 200) },
                { MirAction.Attack1, new Frame(80, 6, 0, 100) },
                { MirAction.Attack2, new Frame(224, 7, 0, 100) },
                { MirAction.Struck, new Frame(128, 2, 0, 200) },
                { MirAction.Die, new Frame(144, 10, 0, 100) },
                { MirAction.Dead, new Frame(153, 1, 9, 1000) },
                { MirAction.Revive, new Frame(144, 10, 0, 100) { Reverse = true } }
            };
            HellSlasher = new FrameSet      //斩怨鬼动作帧
            {
                { MirAction.Standing, new Frame(0, 4, 0, 500) },
                { MirAction.Walking, new Frame(32, 6, 0, 200) },
                { MirAction.Attack1, new Frame(80, 6, 0, 100) },
                { MirAction.Attack2, new Frame(224, 7, 0, 100) },
                { MirAction.Struck, new Frame(128, 2, 0, 200) },
                { MirAction.Die, new Frame(144, 10, 0, 100) },
                { MirAction.Dead, new Frame(153, 1, 9, 1000) },
                { MirAction.Revive, new Frame(144, 10, 0, 100) { Reverse = true } }
            };
            DarkDevourer = new FrameSet      //黑炼魂怪兽动作帧
            {
                { MirAction.Standing, new Frame(0, 4, 0, 500) },
                { MirAction.Walking, new Frame(32, 6, 0, 200) },
                { MirAction.Attack1, new Frame(80, 6, 0, 100) },
                { MirAction.AttackRange1, new Frame(208, 8, 0, 100) },
                { MirAction.Struck, new Frame(128, 2, 0, 200) },
                { MirAction.Die, new Frame(144, 8, 0, 100) },
                { MirAction.Dead, new Frame(151, 1, 7, 1000) },
                { MirAction.Revive, new Frame(144, 8, 0, 100) { Reverse = true } }
            };
            DreamDevourer = new FrameSet      //炼魂怪兽动作帧
            {
                { MirAction.Standing, new Frame(0, 4, 0, 500) },
                { MirAction.Walking, new Frame(32, 6, 0, 100) },
                { MirAction.Attack1, new Frame(80, 6, 0, 100) },
                { MirAction.AttackRange1, new Frame(208, 7, 0, 100) },
                { MirAction.Struck, new Frame(128, 2, 0, 200) },
                { MirAction.Die, new Frame(144, 8, 0, 100) },
                { MirAction.Dead, new Frame(151, 1, 7, 1000) },
                { MirAction.Revive, new Frame(144, 8, 0, 100) { Reverse = true } }
            };
            CyanoGhast = new FrameSet      //青行尸动作帧
            {
                { MirAction.Standing, new Frame(0, 4, 0, 500) },
                { MirAction.Walking, new Frame(32, 6, 0, 100) },
                { MirAction.Attack1, new Frame(80, 6, 0, 100) },
                { MirAction.Struck, new Frame(128, 2, 0, 200) },
                { MirAction.Die, new Frame(144, 10, 0, 100) },
                { MirAction.Dead, new Frame(153, 1, 9, 1000) },
                { MirAction.Revive, new Frame(144, 10, 0, 100) { Reverse = true } }
            };
            CrazyManworm = new FrameSet      //狂鼠怪动作帧
            {
                { MirAction.Standing, new Frame(0, 4, 0, 500) },
                { MirAction.Walking, new Frame(32, 6, 0, 200) },
                { MirAction.Attack1, new Frame(80, 6, 0, 100) },
                { MirAction.Attack2, new Frame(208, 8, 0, 100) },
                { MirAction.Attack3, new Frame(272, 7, 0, 100) },
                { MirAction.Struck, new Frame(128, 2, 0, 200) },
                { MirAction.Die, new Frame(144, 8, 0, 100) },
                { MirAction.Dead, new Frame(154, 1, 7, 1000) },
                { MirAction.Revive, new Frame(144, 8, 0, 100) { Reverse = true } }
            };
            MutatedManworm = new FrameSet      //鼠怪动作帧
            {
                { MirAction.Standing, new Frame(0, 4, 0, 500) },
                { MirAction.Walking, new Frame(32, 6, 0, 200) },
                { MirAction.Attack1, new Frame(80, 6, 0, 100) },
                { MirAction.Attack2, new Frame(208, 8, 0, 100) },
                { MirAction.Attack3, new Frame(272, 7, 0, 100) },
                { MirAction.Struck, new Frame(128, 2, 0, 200) },
                { MirAction.Die, new Frame(144, 8, 0, 100) },
                { MirAction.Dead, new Frame(151, 1, 7, 1000) },
                { MirAction.Revive, new Frame(144, 8, 0, 100) { Reverse = true } }
            };
            GhastlyLeecher = new FrameSet      //行尸动作帧
            {
                { MirAction.Standing, new Frame(0, 4, 0, 500) },
                { MirAction.Walking, new Frame(32, 6, 0, 100) },
                { MirAction.Attack1, new Frame(80, 6, 0, 100) },
                { MirAction.Struck, new Frame(128, 2, 0, 200) },
                { MirAction.Die, new Frame(144, 10, 0, 100) },
                { MirAction.Dead, new Frame(153, 1, 9, 1000) },
                { MirAction.Revive, new Frame(144, 10, 0, 100) { Reverse = true } }
            };
            IcePillar = new FrameSet      //冰柱动作帧
            {
                { MirAction.Standing, new Frame(0, 1, -1, 1000) },
                { MirAction.Attack1, new Frame(0, 1, -1, 1000) },
                { MirAction.Struck, new Frame(1, 4, -4, 200) },
                { MirAction.Die, new Frame(5, 7, -7, 150) },
                { MirAction.Dead, new Frame(11, 1, -1, 1000) },
                { MirAction.Revive, new Frame(5, 7, -7, 150) { Reverse = true } }
            };
            Blank2 = new FrameSet      //寒冰门动作帧
            {
                { MirAction.Standing, new Frame(0, 2, -2, 500) },
                { MirAction.Struck, new Frame(0, 4, -4, 200) },
                { MirAction.Die, new Frame(4, 4, -4, 100) },
                { MirAction.Dead, new Frame(10, 1, -1, 1000) },
            };
            ManectricKing = new FrameSet      //冰狱魔王动作帧
            {
                { MirAction.Standing, new Frame(0, 4, 0, 500) },
                { MirAction.Walking, new Frame(32, 6, 0, 200) },
                { MirAction.Attack1, new Frame(80, 6, 0, 100) },
                { MirAction.Attack2, new Frame(224, 8, 0, 100) },
                { MirAction.AttackRange1, new Frame(288, 9, 0, 100) },
                { MirAction.AttackRange2, new Frame(224, 8, 0, 100) },
                { MirAction.Struck, new Frame(128, 2, 0, 200) },
                { MirAction.Die, new Frame(144, 10, 0, 100) },
                { MirAction.Dead, new Frame(153, 1, 9, 1000) },
                { MirAction.Revive, new Frame(144, 10, 0, 100) { Reverse = true } }
            };
            ManectricBlest = new FrameSet      //夜叉守护将动作帧
            {
                { MirAction.Standing, new Frame(0, 4, 0, 500) },
                { MirAction.Walking, new Frame(32, 6, 0, 200) },
                { MirAction.Attack1, new Frame(80, 6, 0, 100) },
                { MirAction.Attack2, new Frame(208, 8, 0, 100) },
                { MirAction.Attack3, new Frame(272, 7, 0, 100) },
                { MirAction.Struck, new Frame(128, 2, 0, 200) },
                { MirAction.Die, new Frame(144, 8, 0, 100) },
                { MirAction.Dead, new Frame(151, 1, 7, 1000) },
                { MirAction.Revive, new Frame(144, 8, 0, 100) { Reverse = true } }
            };
            ManectricStaff = new FrameSet      //枪寒夜叉动作帧
            {
                { MirAction.Standing, new Frame(0, 4, 0, 500) },
                { MirAction.Walking, new Frame(32, 6, 0, 200) },
                { MirAction.Attack1, new Frame(80, 10, 0, 100) },
                { MirAction.Attack2, new Frame(248, 6, 0, 100) },
                { MirAction.Struck, new Frame(160, 2, 0, 200) },
                { MirAction.Die, new Frame(176, 9, 0, 100) },
                { MirAction.Dead, new Frame(184, 1, 8, 1000) },
                { MirAction.Revive, new Frame(176, 9, 0, 100) { Reverse = true } }
            };
            ManectricClaw = new FrameSet      //玄冰夜叉动作帧
            {
                { MirAction.Standing, new Frame(0, 4, 0, 500) },
                { MirAction.Walking, new Frame(32, 6, 0, 200) },
                { MirAction.Attack1, new Frame(80, 6, 0, 100) },
                { MirAction.AttackRange1, new Frame(224, 10, 0, 100) },
                { MirAction.Struck, new Frame(128, 2, 0, 200) },
                { MirAction.Die, new Frame(144, 10, 0, 100) },
                { MirAction.Dead, new Frame(153, 1, 9, 1000) },
                { MirAction.Revive, new Frame(144, 10, 0, 100) { Reverse = true } }
            };
            ManectricClub = new FrameSet      //雪寒夜叉动作帧
            {
                { MirAction.Standing, new Frame(0, 4, 0, 500) },
                { MirAction.Walking, new Frame(32, 6, 0, 200) },
                { MirAction.Attack1, new Frame(80, 6, 0, 100) },
                { MirAction.Attack2, new Frame(224, 10, 0, 100) },
                { MirAction.Struck, new Frame(128, 2, 0, 200) },
                { MirAction.Die, new Frame(144, 10, 0, 100) },
                { MirAction.Dead, new Frame(153, 1, 9, 1000) },
                { MirAction.Revive, new Frame(144, 10, 0, 100) { Reverse = true } }
            };
            ManectricHammer = new FrameSet      //雪人魁动作帧
            {
                { MirAction.Standing, new Frame(0, 4, 0, 500) },
                { MirAction.Walking, new Frame(32, 6, 0, 200) },
                { MirAction.Attack1, new Frame(80, 6, 0, 100) },
                { MirAction.Struck, new Frame(128, 2, 0, 200) },
                { MirAction.Die, new Frame(144, 7, 0, 100) },
                { MirAction.Dead, new Frame(150, 1, 6, 1000) },
                { MirAction.Revive, new Frame(144, 7, 0, 100) { Reverse = true } }
            };
            OmaKing = new FrameSet      //破凰魔神动作帧
            {
                { MirAction.Standing, new Frame(0, 4, 0, 1000) },
                { MirAction.Walking, new Frame(32, 6, 0, 200) },
                { MirAction.Attack1, new Frame(80, 6, 0, 100) },
                { MirAction.Attack2, new Frame(464, 20, 0, 100) },
                { MirAction.Struck, new Frame(128, 2, 0, 200) },
                { MirAction.Die, new Frame(144, 20, 0, 100) },
                { MirAction.Dead, new Frame(163, 1, 19, 1000) },
                { MirAction.Revive, new Frame(144, 20, 0, 100) { Reverse = true } }
            };
            OmaGuard = new FrameSet      //奥玛亲卫动作帧
            {
                { MirAction.Standing, new Frame(0, 4, 0, 500) },
                { MirAction.Walking, new Frame(32, 6, 0, 100) },
                { MirAction.Attack1, new Frame(80, 6, 0, 100) },
                { MirAction.Struck, new Frame(128, 2, 0, 200) },
                { MirAction.Die, new Frame(144, 10, 0, 100) },
                { MirAction.Dead, new Frame(153, 1, 9, 1000) },
                { MirAction.Revive, new Frame(144, 10, 0, 100) { Reverse = true } }
            };
            FlailOma = new FrameSet      //奥玛中卫动作帧
            {
                { MirAction.Standing, new Frame(0, 4, 0, 500) },
                { MirAction.Walking, new Frame(32, 6, 0, 100) },
                { MirAction.Attack1, new Frame(80, 6, 0, 100) },
                { MirAction.Struck, new Frame(128, 2, 0, 200) },
                { MirAction.Die, new Frame(144, 10, 0, 100) },
                { MirAction.Dead, new Frame(153, 1, 9, 1000) },
                { MirAction.Revive, new Frame(144, 10, 0, 100) { Reverse = true } }
            };
            WingedOma = new FrameSet      //飞翼奥玛动作帧
            {
                { MirAction.Standing, new Frame(0, 4, 0, 500) },
                { MirAction.Walking, new Frame(32, 6, 0, 100) },
                { MirAction.Attack1, new Frame(80, 6, 0, 100) },
                { MirAction.Struck, new Frame(128, 2, 0, 200) },
                { MirAction.Die, new Frame(144, 10, 0, 100) },
                { MirAction.Dead, new Frame(153, 1, 9, 1000) },
                { MirAction.Revive, new Frame(144, 10, 0, 100) { Reverse = true } }
            };
            CrossbowOma = new FrameSet      //奥玛石弓兵动作帧
            {
                { MirAction.Standing, new Frame(0, 4, 0, 1000) },
                { MirAction.Walking, new Frame(32, 6, 0, 100) },
                { MirAction.AttackRange1, new Frame(88, 6, 0, 100) },
                { MirAction.Struck, new Frame(144, 1, 0, 200) },
                { MirAction.Die, new Frame(160, 10, 0, 150) },
                { MirAction.Dead, new Frame(169, 1, 9, 1000) },
                { MirAction.Revive, new Frame(160, 10, 0, 150) { Reverse = true } }
            };
            SwordOma = new FrameSet      //奥玛刀兵动作帧
            {
                { MirAction.Standing, new Frame(0, 4, 0, 500) },
                { MirAction.Walking, new Frame(32, 6, 0, 100) },
                { MirAction.Attack1, new Frame(80, 6, 0, 100) },
                { MirAction.Struck, new Frame(128, 2, 0, 200) },
                { MirAction.Die, new Frame(144, 10, 0, 100) },
                { MirAction.Dead, new Frame(153, 1, 9, 1000) },
                { MirAction.Revive, new Frame(144, 10, 0, 100) { Reverse = true } }
            };
            AxeOma = new FrameSet      //奥玛斧兵动作帧
            {
                { MirAction.Standing, new Frame(0, 4, 0, 500) },
                { MirAction.Walking, new Frame(32, 6, 0, 100) },
                { MirAction.Attack1, new Frame(80, 6, 0, 100) },
                { MirAction.Struck, new Frame(128, 2, 0, 200) },
                { MirAction.Die, new Frame(144, 10, 0, 100) },
                { MirAction.Dead, new Frame(153, 1, 9, 1000) },
                { MirAction.Revive, new Frame(144, 10, 0, 100) { Reverse = true } }
            };
            MinotaurKing = new FrameSet      //牛魔王动作帧
            {
                { MirAction.Standing, new Frame(0, 4, 0, 500) },
                { MirAction.Walking, new Frame(32, 6, 0, 100) },
                { MirAction.Attack1, new Frame(80, 6, 0, 100) },
                { MirAction.AttackRange1, new Frame(224, 6, 0, 100) },
                { MirAction.Struck, new Frame(128, 2, 0, 200) },
                { MirAction.Die, new Frame(144, 10, 0, 100) },
                { MirAction.Dead, new Frame(153, 1, 9, 1000) },
                { MirAction.Revive, new Frame(144, 10, 0, 100) { Reverse = true } }
            };
            LeftGuard = new FrameSet      //般若左使动作帧
            {
                { MirAction.Standing, new Frame(0, 4, 0, 500) },
                { MirAction.Walking, new Frame(32, 6, 0, 100) },
                { MirAction.Attack1, new Frame(80, 6, 0, 100) },
                { MirAction.AttackRange1, new Frame(224, 6, 0, 100) },
                { MirAction.Struck, new Frame(128, 2, 0, 200) },
                { MirAction.Die, new Frame(144, 10, 0, 100) },
                { MirAction.Dead, new Frame(153, 1, 9, 1000) },
                { MirAction.Revive, new Frame(144, 10, 0, 100) { Reverse = true } }
            };
            RightGuard = new FrameSet      //般若右使动作帧
            {
                { MirAction.Standing, new Frame(0, 4, 0, 500) },
                { MirAction.Walking, new Frame(32, 6, 0, 100) },
                { MirAction.Attack1, new Frame(80, 6, 0, 100) },
                { MirAction.AttackRange1, new Frame(224, 6, 0, 100) },
                { MirAction.Struck, new Frame(128, 2, 0, 200) },
                { MirAction.Die, new Frame(144, 10, 0, 100) },
                { MirAction.Dead, new Frame(153, 1, 9, 1000) },
                { MirAction.Revive, new Frame(144, 10, 0, 100) { Reverse = true } }
            };
            FireMinotaur = new FrameSet      //般若火鬼动作帧
            {
                { MirAction.Standing, new Frame(0, 4, 0, 500) },
                { MirAction.Walking, new Frame(32, 6, 0, 100) },
                { MirAction.Attack1, new Frame(80, 6, 0, 100) },
                { MirAction.Struck, new Frame(128, 2, 0, 200) },
                { MirAction.Die, new Frame(144, 10, 0, 100) },
                { MirAction.Dead, new Frame(153, 1, 9, 1000) },
                { MirAction.Revive, new Frame(144, 10, 0, 100) { Reverse = true } }
            };
            WindMinotaur = new FrameSet      //般若风鬼动作帧
            {
                { MirAction.Standing, new Frame(0, 4, 0, 500) },
                { MirAction.Walking, new Frame(32, 6, 0, 100) },
                { MirAction.Attack1, new Frame(80, 6, 0, 100) },
                { MirAction.Struck, new Frame(128, 2, 0, 200) },
                { MirAction.Die, new Frame(144, 10, 0, 100) },
                { MirAction.Dead, new Frame(153, 1, 9, 1000) },
                { MirAction.Revive, new Frame(144, 10, 0, 100) { Reverse = true } }
            };
            ElectricMinotaur = new FrameSet      //般若云鬼动作帧
            {
                { MirAction.Standing, new Frame(0, 4, 0, 500) },
                { MirAction.Walking, new Frame(32, 6, 0, 100) },
                { MirAction.Attack1, new Frame(80, 6, 0, 100) },
                { MirAction.Struck, new Frame(128, 2, 0, 200) },
                { MirAction.Die, new Frame(144, 10, 0, 100) },
                { MirAction.Dead, new Frame(153, 1, 9, 1000) },
                { MirAction.Revive, new Frame(144, 10, 0, 100) { Reverse = true } }
            };
            IceMinotaur = new FrameSet      //般若冰鬼动作帧
            {
                { MirAction.Standing, new Frame(0, 4, 0, 500) },
                { MirAction.Walking, new Frame(32, 6, 0, 100) },
                { MirAction.Attack1, new Frame(80, 6, 0, 100) },
                { MirAction.Struck, new Frame(128, 2, 0, 200) },
                { MirAction.Die, new Frame(144, 10, 0, 100) },
                { MirAction.Dead, new Frame(153, 1, 9, 1000) },
                { MirAction.Revive, new Frame(144, 10, 0, 100) { Reverse = true } }
            };
            Minotaur = new FrameSet      //般若鬼卒动作帧
            {
                { MirAction.Standing, new Frame(0, 4, 0, 500) },
                { MirAction.Walking, new Frame(32, 6, 0, 100) },
                { MirAction.Attack1, new Frame(80, 6, 0, 100) },
                { MirAction.Struck, new Frame(128, 2, 0, 200) },
                { MirAction.Die, new Frame(144, 10, 0, 100) },
                { MirAction.Dead, new Frame(153, 1, 9, 1000) },
                { MirAction.Revive, new Frame(144, 10, 0, 100) { Reverse = true } }
            };
            BoneLord = new FrameSet      //远古黄泉教主动作帧
            {
                { MirAction.Standing, new Frame(0, 4, 0, 500) },
                { MirAction.Walking, new Frame(32, 6, 0, 100) },
                { MirAction.Attack1, new Frame(80, 6, 0, 100) },
                { MirAction.Attack2, new Frame(128, 6, 0, 200) },
                { MirAction.AttackRange1, new Frame(176, 6, 0, 100) },
                { MirAction.Struck, new Frame(224, 2, 0, 200) },
                { MirAction.Die, new Frame(240, 20, 0, 150) },
                { MirAction.Dead, new Frame(259, 1, 19, 1000) },
                { MirAction.Revive, new Frame(240, 20, 0, 150) { Reverse = true } }
            };
            BoneCaptain = new FrameSet      //远古骷髅武将动作帧
            {
                { MirAction.Standing, new Frame(0, 4, 0, 500) },
                { MirAction.Walking, new Frame(32, 6, 0, 100) },
                { MirAction.Attack1, new Frame(80, 6, 0, 100) },
                { MirAction.Struck, new Frame(128, 2, 0, 200) },
                { MirAction.Die, new Frame(144, 10, 0, 100) },
                { MirAction.Dead, new Frame(153, 1, 9, 1000) },
                { MirAction.Revive, new Frame(144, 10, 0, 100) { Reverse = true } }
            };
            BoneSpearman = new FrameSet      //远古骷髅士兵动作帧
            {
                { MirAction.Standing, new Frame(0, 4, 0, 500) },
                { MirAction.Walking, new Frame(32, 6, 0, 100) },
                { MirAction.Attack1, new Frame(80, 6, 0, 100) },
                { MirAction.Struck, new Frame(128, 2, 0, 200) },
                { MirAction.Die, new Frame(144, 10, 0, 100) },
                { MirAction.Dead, new Frame(153, 1, 9, 1000) },
                { MirAction.Revive, new Frame(144, 10, 0, 100) { Reverse = true } }
            };
            BoneBlademan = new FrameSet      //远古骷髅武士动作帧
            {
                { MirAction.Standing, new Frame(0, 4, 0, 500) },
                { MirAction.Walking, new Frame(32, 6, 0, 100) },
                { MirAction.Attack1, new Frame(80, 6, 0, 100) },
                { MirAction.Struck, new Frame(128, 2, 0, 200) },
                { MirAction.Die, new Frame(144, 10, 0, 100) },
                { MirAction.Dead, new Frame(153, 1, 9, 1000) },
                { MirAction.Revive, new Frame(144, 10, 0, 100) { Reverse = true } }
            };
            BoneArcher = new FrameSet      //远古骷髅弓手动作帧
            {
                { MirAction.Standing, new Frame(0, 4, 0, 500) },
                { MirAction.Walking, new Frame(32, 6, 0, 100) },
                { MirAction.Attack1, new Frame(80, 6, 0, 100) },
                { MirAction.Struck, new Frame(128, 2, 0, 200) },
                { MirAction.Die, new Frame(144, 10, 0, 100) },
                { MirAction.Dead, new Frame(153, 1, 9, 1000) },
                { MirAction.Revive, new Frame(144, 10, 0, 100) { Reverse = true } }
            };
            RoninGhoul = new FrameSet      //远古浪人鬼动作帧
            {
                { MirAction.Standing, new Frame(0, 4, 0, 500) },
                { MirAction.Walking, new Frame(32, 6, 0, 100) },
                { MirAction.Attack1, new Frame(80, 6, 0, 100) },
                { MirAction.Struck, new Frame(128, 2, 0, 200) },
                { MirAction.Die, new Frame(144, 10, 0, 100) },
                { MirAction.Dead, new Frame(153, 1, 9, 1000) },
                { MirAction.Revive, new Frame(144, 10, 0, 100) { Reverse = true } }
            };
            ToxicGhoul = new FrameSet      //远古腐蚀鬼动作帧
            {
                { MirAction.Standing, new Frame(0, 4, 0, 500) },
                { MirAction.Walking, new Frame(32, 6, 0, 100) },
                { MirAction.Attack1, new Frame(80, 6, 0, 100) },
                { MirAction.Struck, new Frame(128, 2, 0, 200) },
                { MirAction.Die, new Frame(144, 10, 0, 100) },
                { MirAction.Dead, new Frame(153, 1, 9, 1000) },
                { MirAction.Revive, new Frame(144, 10, 0, 100) { Reverse = true } }
            };
            StoningStatue = new FrameSet      //炎月魔王动作帧
            {
                { MirAction.Standing, new Frame(0, 4, 0, 500) },
                { MirAction.Walking, new Frame(32, 6, 0, 100) },
                { MirAction.Attack1, new Frame(80, 6, 0, 100) },
                { MirAction.Attack2, new Frame(304, 20, 0, 100) },
                { MirAction.Struck, new Frame(128, 2, 0, 200) },
                { MirAction.Die, new Frame(144, 20, 0, 100) },
                { MirAction.Dead, new Frame(163, 1, 19, 1000) },
                { MirAction.Revive, new Frame(144, 20, 0, 100) { Reverse = true } }
            };
            FlyingStatue = new FrameSet      //妖月教主动作帧
            {
                { MirAction.Standing, new Frame(0, 4, 0, 500) },
                { MirAction.Walking, new Frame(32, 6, 0, 200) },
                { MirAction.Attack1, new Frame(80, 6, 0, 200) },
                { MirAction.Attack2, new Frame(80, 6, 0, 200) },
                { MirAction.AttackRange1, new Frame(224, 10, 0, 100) },
                { MirAction.Struck, new Frame(128, 2, 0, 200) },
                { MirAction.Die, new Frame(144, 10, 0, 150) },
                { MirAction.Dead, new Frame(153, 1, 9, 1000) },
                { MirAction.Revive, new Frame(144, 10, 0, 150) { Reverse = true } }
            };
            FrozenZumaStatue = new FrameSet      //月氏神将动作帧
            {
                { MirAction.Stoned, new Frame(0, 1, 5, 100) },
                { MirAction.Show, new Frame(0, 6, 0, 100) },
                { MirAction.Hide, new Frame(5, 6, 0, 100) },
                { MirAction.Standing, new Frame(48, 4, 0, 1000) },
                { MirAction.Walking, new Frame(80, 6, 0, 100) },
                { MirAction.Attack1, new Frame(128, 6, 0, 100) },
                { MirAction.Struck, new Frame(176, 2, 0, 200) },
                { MirAction.Die, new Frame(192, 10, 0, 100) },
                { MirAction.Dead, new Frame(201, 1, 9, 1000) },
                { MirAction.Revive, new Frame(192, 10, 0, 100) { Reverse = true } }
            };
            FrozenZumaGuardian = new FrameSet      //月氏护法动作帧
            {
                { MirAction.Stoned, new Frame(0, 1, 5, 100) },
                { MirAction.Show, new Frame(0, 6, 0, 100) },
                { MirAction.Hide, new Frame(5, 6, 0, 100) },
                { MirAction.Standing, new Frame(48, 4, 0, 1000) },
                { MirAction.Walking, new Frame(80, 6, 0, 100) },
                { MirAction.Attack1, new Frame(128, 6, 0, 100) },
                { MirAction.Struck, new Frame(176, 2, 0, 200) },
                { MirAction.Die, new Frame(192, 10, 0, 100) },
                { MirAction.Dead, new Frame(201, 1, 9, 1000) },
                { MirAction.Revive, new Frame(192, 10, 0, 100) { Reverse = true } }
            };
            SpiderWarrior = new FrameSet      //月氏斗神动作帧
            {
                { MirAction.Standing, new Frame(0, 4, 0, 500) },
                { MirAction.Walking, new Frame(32, 6, 0, 100) },
                { MirAction.Attack1, new Frame(80, 6, 0, 100) },
                { MirAction.Struck, new Frame(128, 2, 0, 200) },
                { MirAction.Die, new Frame(144, 10, 0, 100) },
                { MirAction.Dead, new Frame(153, 1, 9, 1000) },
                { MirAction.Revive, new Frame(144, 10, 0, 100) { Reverse = true } }
            };
            GreaterWeaver = new FrameSet      //邪影魔蛛动作帧
            {
                { MirAction.Standing, new Frame(0, 4, 18, 1000) },
                { MirAction.Attack1, new Frame(4, 6, 16, 100) },
                { MirAction.Struck, new Frame(10, 2, 20, 200) },
                { MirAction.Die, new Frame(12, 10, 12, 150) },
                { MirAction.Dead, new Frame(21, 1, 21, 1000) },
                { MirAction.Revive, new Frame(12, 10, 12, 100) { Reverse = true } }
            };
            CrystalWeaver = new FrameSet      //月氏魔蛛动作帧
            {
                { MirAction.Standing, new Frame(0, 4, 0, 500) },
                { MirAction.Walking, new Frame(32, 6, 0, 100) },
                { MirAction.Attack1, new Frame(80, 6, 0, 100) },
                { MirAction.Attack2, new Frame(224, 6, 0, 100) },
                { MirAction.Struck, new Frame(128, 2, 0, 200) },
                { MirAction.Die, new Frame(144, 10, 0, 100) },
                { MirAction.Dead, new Frame(153, 1, 9, 1000) },
                { MirAction.Revive, new Frame(144, 10, 0, 100) { Reverse = true } }
            };
            ArmingWeaver = new FrameSet      //花吻魔蛛动作帧
            {
                { MirAction.Standing, new Frame(0, 4, 0, 500) },
                { MirAction.Walking, new Frame(32, 6, 0, 100) },
                { MirAction.Attack1, new Frame(80, 6, 0, 100) },
                { MirAction.Struck, new Frame(128, 2, 0, 200) },
                { MirAction.Die, new Frame(144, 10, 0, 100) },
                { MirAction.Dead, new Frame(153, 1, 9, 1000) },
                { MirAction.Revive, new Frame(144, 10, 0, 100) { Reverse = true } }
            };
            CrackingWeaver = new FrameSet      //花吻魔蛛动作帧
            {
                { MirAction.Standing, new Frame(0, 4, 0, 500) },
                { MirAction.Walking, new Frame(32, 6, 0, 100) },
                { MirAction.Attack1, new Frame(80, 6, 0, 100) },
                { MirAction.Struck, new Frame(128, 2, 0, 200) },
                { MirAction.Die, new Frame(144, 10, 0, 100) },
                { MirAction.Dead, new Frame(153, 1, 9, 1000) },
                { MirAction.Revive, new Frame(144, 10, 0, 100) { Reverse = true } }
            };
            FlamingMutant = new FrameSet      //月氏镰神将动作帧
            {
                { MirAction.Standing, new Frame(0, 4, 0, 500) },
                { MirAction.Walking, new Frame(32, 6, 0, 200) },
                { MirAction.Attack1, new Frame(80, 6, 0, 100) },
                { MirAction.AttackRange1, new Frame(224, 10, 0, 100) },
                { MirAction.Struck, new Frame(128, 2, 0, 200) },
                { MirAction.Die, new Frame(144, 10, 0, 100) },
                { MirAction.Dead, new Frame(153, 1, 9, 1000) },
                { MirAction.Revive, new Frame(144, 10, 0, 100) { Reverse = true } }
            };
            Weaver = new FrameSet      //天狼魔蛛、山月魔蛛动作帧
            {
                { MirAction.Standing, new Frame(0, 4, 0, 500) },
                { MirAction.Walking, new Frame(32, 6, 0, 100) },
                { MirAction.Attack1, new Frame(80, 6, 0, 100) },
                { MirAction.Struck, new Frame(128, 2, 0, 200) },
                { MirAction.Die, new Frame(144, 10, 0, 100) },
                { MirAction.Dead, new Frame(153, 1, 9, 1000) },
                { MirAction.Revive, new Frame(144, 10, 0, 100) { Reverse = true } }
            };
            ValeBat = new FrameSet      //飞毒魔蛛动作帧
            {
                { MirAction.Standing, new Frame(0, 4, 0, 500) },
                { MirAction.Walking, new Frame(32, 6, 0, 100) },
                { MirAction.Attack1, new Frame(80, 6, 0, 100) },
                { MirAction.Struck, new Frame(128, 2, 0, 200) },
                { MirAction.Die, new Frame(144, 10, 0, 100) },
                { MirAction.Dead, new Frame(153, 1, 9, 1000) },
                { MirAction.Revive, new Frame(144, 10, 0, 100) { Reverse = true } }
            };
            EvilApe = new FrameSet      //邪恶巨猿,邪恶巨人动作帧
            {
                { MirAction.Standing, new Frame(0, 4, 0, 500) },
                { MirAction.Walking, new Frame(32, 6, 0, 100) },
                { MirAction.Attack1, new Frame(80, 6, 0, 100) },
                { MirAction.Struck, new Frame(128, 2, 0, 200) },
                { MirAction.Die, new Frame(144, 10, 0, 100) },
                { MirAction.Dead, new Frame(153, 1, 9, 1000) },
                { MirAction.Revive, new Frame(144, 10, 0, 100) { Reverse = true } }
            };
            RedMoonEvil = new FrameSet      //赤月恶魔动作帧
            {
                { MirAction.Standing, new Frame(0, 4, -4, 1000) },
                { MirAction.Attack1, new Frame(4, 6, -6, 100) },
                { MirAction.Struck, new Frame(10, 2, -2, 200) },
                { MirAction.Die, new Frame(12, 20, -20, 100) },
                { MirAction.Dead, new Frame(31, 1, -1, 1000) },
                { MirAction.Revive, new Frame(12, 20, -20, 100) { Reverse = true } }
            };
            CrystalSpider = new FrameSet      //邪恶蜘蛛,神石毒魔蛛动作帧
            {
                { MirAction.Standing, new Frame(0, 4, 0, 500) },
                { MirAction.Walking, new Frame(32, 6, 0, 100) },
                { MirAction.Attack1, new Frame(80, 6, 0, 100) },
                { MirAction.Attack2, new Frame(224, 6, 0, 100) },
                { MirAction.Struck, new Frame(128, 2, 0, 200) },
                { MirAction.Die, new Frame(144, 10, 0, 100) },
                { MirAction.Dead, new Frame(153, 1, 9, 1000) },
                { MirAction.Revive, new Frame(144, 10, 0, 100) { Reverse = true } }
            };
            RedEvilApe = new FrameSet      //双头血魔动作帧
            {
                { MirAction.Standing, new Frame(0, 4, 0, 500) },
                { MirAction.Walking, new Frame(32, 6, 0, 100) },
                { MirAction.Attack1, new Frame(80, 6, 0, 100) },
                { MirAction.Struck, new Frame(128, 2, 0, 200) },
                { MirAction.Die, new Frame(144, 10, 0, 100) },
                { MirAction.Dead, new Frame(153, 1, 9, 1000) },
                { MirAction.Revive, new Frame(144, 10, 0, 100) { Reverse = true } }
            };
            GrayEvilApe = new FrameSet      //双头金刚动作帧
            {
                { MirAction.Standing, new Frame(0, 4, 0, 500) },
                { MirAction.Walking, new Frame(32, 6, 0, 100) },
                { MirAction.Attack1, new Frame(80, 6, 0, 100) },
                { MirAction.Struck, new Frame(128, 2, 0, 200) },
                { MirAction.Die, new Frame(144, 10, 0, 100) },
                { MirAction.Dead, new Frame(153, 1, 9, 1000) },
                { MirAction.Revive, new Frame(144, 10, 0, 100) { Reverse = true } }
            };
            BigApe = new FrameSet      //血巨人动作帧
            {
                { MirAction.Standing, new Frame(0, 4, 0, 500) },
                { MirAction.Walking, new Frame(32, 6, 0, 100) },
                { MirAction.Attack1, new Frame(80, 6, 0, 100) },
                { MirAction.Struck, new Frame(128, 2, 0, 200) },
                { MirAction.Die, new Frame(144, 10, 0, 100) },
                { MirAction.Dead, new Frame(153, 1, 9, 1000) },
                { MirAction.Revive, new Frame(144, 10, 0, 100) { Reverse = true } }
            };
            LureSpider = new FrameSet      //花吻蜘蛛动作帧
            {
                { MirAction.Standing, new Frame(0, 4, 0, 500) },
                { MirAction.Walking, new Frame(32, 6, 0, 100) },
                { MirAction.Attack1, new Frame(80, 6, 0, 100) },
                { MirAction.Struck, new Frame(128, 2, 0, 200) },
                { MirAction.Die, new Frame(144, 10, 0, 100) },
                { MirAction.Dead, new Frame(153, 1, 9, 1000) },
                { MirAction.Revive, new Frame(144, 10, 0, 100) { Reverse = true } }
            };
            GreatSpider = new FrameSet      //黑颚蜘蛛动作帧
            {
                { MirAction.Standing, new Frame(0, 4, 0, 500) },
                { MirAction.Walking, new Frame(32, 6, 0, 100) },
                { MirAction.Attack1, new Frame(80, 6, 0, 100) },
                { MirAction.Struck, new Frame(128, 2, 0, 200) },
                { MirAction.Die, new Frame(144, 10, 0, 100) },
                { MirAction.Dead, new Frame(153, 1, 9, 1000) },
                { MirAction.Revive, new Frame(144, 10, 0, 100) { Reverse = true } }
            };
            GreatSpider = new FrameSet      //黑颚蜘蛛动作帧
            {
                { MirAction.Standing, new Frame(0, 4, 0, 500) },
                { MirAction.Walking, new Frame(32, 6, 0, 100) },
                { MirAction.Attack1, new Frame(80, 6, 0, 100) },
                { MirAction.Struck, new Frame(128, 2, 0, 200) },
                { MirAction.Die, new Frame(144, 10, 0, 100) },
                { MirAction.Dead, new Frame(153, 1, 9, 1000) },
                { MirAction.Revive, new Frame(144, 10, 0, 100) { Reverse = true } }
            };
            GangSpider = new FrameSet      //钢牙蜘蛛动作帧
            {
                { MirAction.Standing, new Frame(0, 4, 0, 500) },
                { MirAction.Walking, new Frame(32, 6, 0, 100) },
                { MirAction.Attack1, new Frame(80, 6, 0, 100) },
                { MirAction.Struck, new Frame(128, 2, 0, 200) },
                { MirAction.Die, new Frame(144, 10, 0, 100) },
                { MirAction.Dead, new Frame(153, 1, 9, 1000) },
                { MirAction.Revive, new Frame(144, 10, 0, 100) { Reverse = true } }
            };
            VenomSpider = new FrameSet      //天狼蜘蛛动作帧
            {
                { MirAction.Standing, new Frame(0, 4, 0, 500) },
                { MirAction.Walking, new Frame(32, 6, 0, 100) },
                { MirAction.Attack1, new Frame(80, 6, 0, 100) },
                { MirAction.Struck, new Frame(128, 2, 0, 200) },
                { MirAction.Die, new Frame(144, 10, 0, 100) },
                { MirAction.Dead, new Frame(153, 1, 9, 1000) },
                { MirAction.Revive, new Frame(144, 10, 0, 100) { Reverse = true } }
            };
            SpiderBat = new FrameSet      //月魔蜘蛛动作帧
            {
                { MirAction.Standing, new Frame(0, 4, 0, 500) },
                { MirAction.Walking, new Frame(32, 6, 0, 100) },
                { MirAction.Attack1, new Frame(80, 6, 0, 100) },
                { MirAction.Struck, new Frame(128, 2, 0, 200) },
                { MirAction.Die, new Frame(144, 10, 0, 100) },
                { MirAction.Dead, new Frame(153, 1, 9, 1000) },
                { MirAction.Revive, new Frame(144, 10, 0, 100) { Reverse = true } }
            };
            RootSpider = new FrameSet      //幻影蜘蛛动作帧
            {
                { MirAction.Standing, new Frame(0, 4, 18, 500) },
                { MirAction.Attack1, new Frame(4, 6, 16, 100) },
                { MirAction.Struck, new Frame(10, 2, 20, 200) },
                { MirAction.Die, new Frame(12, 10, 12, 150) },
                { MirAction.Dead, new Frame(21, 1, 21, 1000) },
                { MirAction.Revive, new Frame(12, 10, 12, 150) { Reverse = true } }
            };
            BombSpider = new FrameSet      //爆裂蜘蛛动作帧
            {
                { MirAction.Standing, new Frame(0, 1, 5, 1000) },
                { MirAction.Walking, new Frame(0, 6, 0, 100) },
                { MirAction.Struck, new Frame(0, 1, 5, 200) },
                { MirAction.Die, new Frame(48, 10, 0, 150) },
                { MirAction.Dead, new Frame(57, 1, 9, 1000) },
                { MirAction.Revive, new Frame(48, 10, 0, 150) { Reverse = true } }
            };
            NdZombie = new FrameSet      //僵尸4,僵尸40,干瘪恶尸,巫毒僵尸,饥饿僵尸动作帧
            {
                { MirAction.Standing, new Frame(0, 4, 0, 500) },
                { MirAction.Walking, new Frame(32, 6, 0, 100) },
                { MirAction.Attack1, new Frame(80, 6, 0, 100) },
                { MirAction.Struck, new Frame(128, 2, 0, 200) },
                { MirAction.Die, new Frame(144, 10, 0, 100) },
                { MirAction.Dead, new Frame(153, 1, 9, 1000) },
                { MirAction.Revive, new Frame(224, 10, 0, 100) { Reverse = true } }
            };
            ClZombie = new FrameSet      //僵尸3,僵尸30,腐肉僵尸,石僵尸,诅咒僵尸动作帧
            {
                { MirAction.Standing, new Frame(0, 4, 0, 500) },
                { MirAction.Walking, new Frame(32, 6, 0, 100) },
                { MirAction.Attack1, new Frame(80, 6, 0, 100) },
                { MirAction.Struck, new Frame(128, 2, 0, 200) },
                { MirAction.Die, new Frame(144, 10, 0, 100) },
                { MirAction.Dead, new Frame(153, 1, 9, 1000) },
                { MirAction.Revive, new Frame(224, 10, 0, 100) { Reverse = true } }
            };
            DigOutZombie = new FrameSet      //僵尸2,僵尸20,僧侣僵尸,诅咒牧师,诅咒祭司动作帧
            {
                { MirAction.Show, new Frame(224, 10, 0, 200) },
                { MirAction.Standing, new Frame(0, 4, 0, 500) },
                { MirAction.Walking, new Frame(32, 6, 0, 100) },
                { MirAction.Attack1, new Frame(80, 6, 0, 100) },
                { MirAction.Struck, new Frame(128, 2, 0, 200) },
                { MirAction.Die, new Frame(144, 10, 0, 100) },
                { MirAction.Dead, new Frame(153, 1, 9, 1000) },
                { MirAction.Revive, new Frame(144, 10, 0, 100) { Reverse = true } }
            };
            ShamanZombie = new FrameSet      //僵尸1,僵尸10,电僵尸,墨辰,僵尸51,诅咒电僵尸动作帧
            {
                { MirAction.Standing, new Frame(0, 4, 0, 500) },
                { MirAction.Walking, new Frame(32, 6, 0, 100) },
                { MirAction.Attack1, new Frame(80, 6, 0, 100) },
                { MirAction.Struck, new Frame(128, 2, 0, 200) },
                { MirAction.Die, new Frame(144, 10, 0, 100) },
                { MirAction.Dead, new Frame(153, 1, 9, 1000) },
                { MirAction.Revive, new Frame(144, 10, 0, 100) { Reverse = true } }
            };
            FlamingWooma = new FrameSet      //火焰牛面鬼,火焰牛面鬼0,火焰牛面鬼2,远古火焰牛面鬼动作帧
            {
                { MirAction.Standing, new Frame(0, 4, 0, 500) },
                { MirAction.Walking, new Frame(32, 6, 0, 100) },
                { MirAction.Attack1, new Frame(80, 6, 0, 100) },
                { MirAction.Struck, new Frame(128, 2, 0, 200) },
                { MirAction.Die, new Frame(144, 10, 0, 100) },
                { MirAction.Dead, new Frame(153, 1, 9, 1000) },
                { MirAction.Revive, new Frame(144, 10, 0, 100) { Reverse = true } }
            };
            WoomaWarrior = new FrameSet      //牛面鬼卒,牛面鬼卒0,远古牛面鬼卒动作帧
            {
                { MirAction.Standing, new Frame(0, 4, 0, 500) },
                { MirAction.Walking, new Frame(32, 6, 0, 100) },
                { MirAction.Attack1, new Frame(80, 6, 0, 100) },
                { MirAction.Struck, new Frame(128, 2, 0, 200) },
                { MirAction.Die, new Frame(144, 10, 0, 100) },
                { MirAction.Dead, new Frame(153, 1, 9, 1000) },
                { MirAction.Revive, new Frame(144, 10, 0, 100) { Reverse = true } }
            };
            WoomaFighter = new FrameSet      //牛面鬼兵,牛面鬼兵0,远古牛面鬼兵动作帧
            {
                { MirAction.Standing, new Frame(0, 4, 0, 500) },
                { MirAction.Walking, new Frame(32, 6, 0, 100) },
                { MirAction.Attack1, new Frame(80, 6, 0, 100) },
                { MirAction.Struck, new Frame(128, 2, 0, 200) },
                { MirAction.Die, new Frame(144, 10, 0, 100) },
                { MirAction.Dead, new Frame(153, 1, 9, 1000) },
                { MirAction.Revive, new Frame(144, 10, 0, 100) { Reverse = true } }
            };
            WoomaSoldier = new FrameSet      //牛面鬼,牛面鬼0,远古牛面鬼动作帧
            {
                { MirAction.Standing, new Frame(0, 4, 0, 500) },
                { MirAction.Walking, new Frame(32, 6, 0, 100) },
                { MirAction.Attack1, new Frame(80, 6, 0, 100) },
                { MirAction.Struck, new Frame(128, 2, 0, 200) },
                { MirAction.Die, new Frame(144, 10, 0, 100) },
                { MirAction.Dead, new Frame(153, 1, 9, 1000) },
                { MirAction.Revive, new Frame(144, 10, 0, 100) { Reverse = true } }
            };
            Dung = new FrameSet      //粪虫,粪虫0动作帧
            {
                { MirAction.Standing, new Frame(0, 4, 0, 500) },
                { MirAction.Walking, new Frame(32, 6, 0, 100) },
                { MirAction.Attack1, new Frame(80, 6, 0, 100) },
                { MirAction.Struck, new Frame(128, 2, 0, 200) },
                { MirAction.Die, new Frame(144, 10, 0, 100) },
                { MirAction.Dead, new Frame(153, 1, 9, 1000) },
                { MirAction.Revive, new Frame(144, 10, 0, 100) { Reverse = true } }
            };
            Dark = new FrameSet      //黑暗战士,黑暗战士0动作帧
            {
                { MirAction.Standing, new Frame(0, 4, 0, 500) },
                { MirAction.Walking, new Frame(32, 6, 0, 100) },
                { MirAction.Attack1, new Frame(80, 6, 0, 100) },
                { MirAction.Struck, new Frame(128, 2, 0, 200) },
                { MirAction.Die, new Frame(144, 10, 0, 100) },
                { MirAction.Dead, new Frame(153, 1, 9, 1000) },
                { MirAction.Revive, new Frame(144, 10, 0, 100) { Reverse = true } }
            };
            Khazard = new FrameSet      //赤毒蜥蜴动作帧
            {
                { MirAction.Standing, new Frame(0, 4, 0, 500) },
                { MirAction.Walking, new Frame(32, 6, 0, 100) },
                { MirAction.Attack1, new Frame(80, 6, 0, 100) },
                { MirAction.AttackRange1, new Frame(224, 6, 0, 100) },
                { MirAction.Struck, new Frame(128, 2, 0, 200) },
                { MirAction.Die, new Frame(144, 10, 0, 100) },
                { MirAction.Dead, new Frame(153, 1, 9, 1000) },
                { MirAction.Revive, new Frame(144, 10, 0, 100) { Reverse = true } }
            };
            VioletKekTal = new FrameSet      //多角虫,多角虫0动作帧
            {
                { MirAction.Standing, new Frame(0, 4, 0, 500) },
                { MirAction.Walking, new Frame(32, 6, 0, 100) },
                { MirAction.Attack1, new Frame(80, 6, 0, 100) },
                { MirAction.Struck, new Frame(128, 2, 0, 200) },
                { MirAction.Die, new Frame(144, 10, 0, 100) },
                { MirAction.Dead, new Frame(153, 1, 9, 1000) },
                { MirAction.Revive, new Frame(144, 10, 0, 100) { Reverse = true } }
            };
            KekTal = new FrameSet      //多脚虫,多脚虫0动作帧
            {
                { MirAction.Standing, new Frame(0, 4, 0, 500) },
                { MirAction.Walking, new Frame(32, 6, 0, 100) },
                { MirAction.Attack1, new Frame(80, 6, 0, 100) },
                { MirAction.Struck, new Frame(128, 2, 0, 200) },
                { MirAction.Die, new Frame(144, 10, 0, 100) },
                { MirAction.Dead, new Frame(153, 1, 9, 1000) },
                { MirAction.Revive, new Frame(144, 10, 0, 100) { Reverse = true } }
            };
            BlueHoroBlaster = new FrameSet      //凸眼虫,凸眼虫0动作帧
            {
                { MirAction.Standing, new Frame(0, 4, 0, 500) },
                { MirAction.Walking, new Frame(32, 6, 0, 100) },
                { MirAction.Attack1, new Frame(80, 6, 0, 100) },
                { MirAction.Struck, new Frame(128, 2, 0, 200) },
                { MirAction.Die, new Frame(144, 10, 0, 100) },
                { MirAction.Dead, new Frame(153, 1, 9, 1000) },
                { MirAction.Revive, new Frame(144, 10, 0, 100) { Reverse = true } }
            };
            HoroBlaster = new FrameSet      //抱眼虫,抱眼虫0动作帧
            {
                { MirAction.Standing, new Frame(0, 4, 0, 500) },
                { MirAction.Walking, new Frame(32, 6, 0, 100) },
                { MirAction.Attack1, new Frame(80, 6, 0, 100) },
                { MirAction.Struck, new Frame(128, 2, 0, 200) },
                { MirAction.Die, new Frame(144, 10, 0, 100) },
                { MirAction.Dead, new Frame(153, 1, 9, 1000) },
                { MirAction.Revive, new Frame(144, 10, 0, 100) { Reverse = true } }
            };
            SpiderFrog = new FrameSet      //齿虫,齿虫0动作帧
            {
                { MirAction.Standing, new Frame(0, 4, 0, 500) },
                { MirAction.Walking, new Frame(32, 6, 0, 100) },
                { MirAction.Attack1, new Frame(80, 6, 0, 100) },
                { MirAction.Struck, new Frame(128, 2, 0, 200) },
                { MirAction.Die, new Frame(144, 10, 0, 100) },
                { MirAction.Dead, new Frame(153, 1, 9, 1000) },
                { MirAction.Revive, new Frame(144, 10, 0, 100) { Reverse = true } }
            };
            SpiderFrog = new FrameSet      //齿虫,齿虫0动作帧
            {
                { MirAction.Standing, new Frame(0, 4, 0, 500) },
                { MirAction.Walking, new Frame(32, 6, 0, 100) },
                { MirAction.Attack1, new Frame(80, 6, 0, 100) },
                { MirAction.Struck, new Frame(128, 2, 0, 200) },
                { MirAction.Die, new Frame(144, 10, 0, 100) },
                { MirAction.Dead, new Frame(153, 1, 9, 1000) },
                { MirAction.Revive, new Frame(144, 10, 0, 100) { Reverse = true } }
            };
            RedFrogSpider = new FrameSet      //悲月角虫动作帧
            {
                { MirAction.Standing, new Frame(0, 4, 0, 500) },
                { MirAction.Walking, new Frame(32, 6, 0, 100) },
                { MirAction.Attack1, new Frame(80, 6, 0, 100) },
                { MirAction.Struck, new Frame(128, 2, 0, 200) },
                { MirAction.Die, new Frame(144, 10, 0, 100) },
                { MirAction.Dead, new Frame(153, 1, 9, 1000) },
                { MirAction.Revive, new Frame(144, 10, 0, 100) { Reverse = true } }
            };
            BrownFrogSpider = new FrameSet      //悲月虎虫动作帧
            {
                { MirAction.Standing, new Frame(0, 4, 0, 500) },
                { MirAction.Walking, new Frame(32, 6, 0, 100) },
                { MirAction.Attack1, new Frame(80, 6, 0, 100) },
                { MirAction.Struck, new Frame(128, 2, 0, 200) },
                { MirAction.Die, new Frame(144, 10, 0, 100) },
                { MirAction.Dead, new Frame(153, 1, 9, 1000) },
                { MirAction.Revive, new Frame(144, 10, 0, 100) { Reverse = true } }
            };
            BigHedgeKekTal = new FrameSet      //悲月紫蛙动作帧
            {
                { MirAction.Standing, new Frame(0, 4, 0, 500) },
                { MirAction.Walking, new Frame(32, 6, 4, 100) },
                { MirAction.Attack1, new Frame(112, 6, 4, 100) },
                { MirAction.AttackRange1, new Frame(288, 6, 0, 100) },
                { MirAction.Struck, new Frame(192, 2, 0, 200) },
                { MirAction.Die, new Frame(208, 10, 0, 100) },
                { MirAction.Dead, new Frame(217, 1, 9, 1000) },
                { MirAction.Revive, new Frame(208, 10, 0, 100) { Reverse = true } }
            };
            HedgeKekTal = new FrameSet      //悲月刺蛙动作帧
            {
                { MirAction.Standing, new Frame(0, 4, 0, 500) },
                { MirAction.Walking, new Frame(32, 6, 4, 100) },
                { MirAction.Attack1, new Frame(112, 6, 4, 100) },
                { MirAction.AttackRange1, new Frame(288, 6, 0, 100) },
                { MirAction.Struck, new Frame(192, 2, 0, 200) },
                { MirAction.Die, new Frame(208, 10, 0, 100) },
                { MirAction.Dead, new Frame(217, 1, 9, 1000) },
                { MirAction.Revive, new Frame(208, 10, 0, 100) { Reverse = true } }
            };
            CloudElement = new FrameSet      //云雾元素动作帧
            {
                { MirAction.Standing, new Frame(0, 10, -10, 800) },
                { MirAction.Walking, new Frame(10, 10, -10, 80) },
                { MirAction.Attack1, new Frame(20, 10, -10, 80) },
                { MirAction.Struck, new Frame(30, 4, -4, 200) },
                { MirAction.Die, new Frame(34, 10, -10, 120) },
                { MirAction.Dead, new Frame(43, 1, -1, 1000) },
                { MirAction.Revive, new Frame(34, 10, -10, 150) { Reverse = true } }
            };
            ThunderElement = new FrameSet      //闪电元素动作帧
            {
                { MirAction.Standing, new Frame(0, 10, -10, 800) },
                { MirAction.Walking, new Frame(10, 10, -10, 80) },
                { MirAction.Attack1, new Frame(20, 10, -10, 80) },
                { MirAction.Struck, new Frame(30, 4, -4, 200) },
                { MirAction.Die, new Frame(34, 10, -10, 120) },
                { MirAction.Dead, new Frame(43, 1, -1, 1000) },
                { MirAction.Revive, new Frame(34, 10, -10, 150) { Reverse = true } }
            };
            GuardianRock = new FrameSet      //九尾魂石动作帧
            {
                { MirAction.Standing, new Frame(0, 4, -4, 500) },
                { MirAction.Walking, new Frame(4, 4, -4, 200) },
            };
            TrapRock = new FrameSet      //狐魂石动作帧
            {
                { MirAction.Standing, new Frame(0, 4, -4, 500) },
                { MirAction.Show, new Frame(4, 5, -5, 200) },
                { MirAction.Attack1, new Frame(9, 5, -5, 100) },
                { MirAction.Struck, new Frame(14, 2, -2, 200) },
                { MirAction.Die, new Frame(16, 10, -10, 100) },
                { MirAction.Dead, new Frame(25, 1, -1, 1000) },
                { MirAction.Revive, new Frame(16, 10, -10, 100) { Reverse = true } }
            };
            WhiteFoxman = new FrameSet      //悲月白狐动作帧
            {
                { MirAction.Standing, new Frame(0, 4, 0, 500) },
                { MirAction.Walking, new Frame(32, 6, 0, 100) },
                { MirAction.Attack1, new Frame(80, 6, 0, 100) },
                { MirAction.Attack2, new Frame(224, 6, 0, 100) },
                { MirAction.Struck, new Frame(128, 2, 0, 200) },
                { MirAction.Die, new Frame(144, 10, 0, 100) },
                { MirAction.Dead, new Frame(153, 1, 9, 1000) },
                { MirAction.Revive, new Frame(144, 10, 0, 100) { Reverse = true } }
            };
            BlackFoxman = new FrameSet      //悲月黑狐动作帧
            {
                { MirAction.Standing, new Frame(0, 4, 0, 500) },
                { MirAction.Walking, new Frame(32, 6, 0, 100) },
                { MirAction.Attack1, new Frame(80, 6, 0, 100) },
                { MirAction.Attack2, new Frame(80, 6, 0, 100) },
                { MirAction.Struck, new Frame(128, 2, 0, 200) },
                { MirAction.Die, new Frame(144, 10, 0, 100) },
                { MirAction.Dead, new Frame(153, 1, 9, 1000) },
                { MirAction.Revive, new Frame(144, 10, 0, 100) { Reverse = true } }
            };
            RedFoxman = new FrameSet      //悲月赤狐动作帧
            {
                { MirAction.Standing, new Frame(0, 4, 0, 500) },
                { MirAction.Walking, new Frame(32, 6, 0, 100) },
                { MirAction.AttackRange1, new Frame(80, 6, 0, 100) },
                { MirAction.AttackRange2, new Frame(80, 6, 0, 100) },
                { MirAction.Struck, new Frame(128, 2, 0, 200) },
                { MirAction.Die, new Frame(144, 10, 0, 100) },
                { MirAction.Dead, new Frame(153, 1, 9, 1000) },
                { MirAction.Revive, new Frame(144, 10, 0, 100) { Reverse = true } }
            };
            RedThunderZuma = new FrameSet      //赤雷咒魔,远古赤雷咒魔动作帧
            {
                { MirAction.Show, new Frame(272, 6, 0, 100) },
                { MirAction.Hide, new Frame(277, 6, 0, 100) },
                { MirAction.Stoned, new Frame(272, 1, 5, 100) },
                { MirAction.Standing, new Frame(0, 4, 0, 500) },
                { MirAction.Walking, new Frame(32, 6, 0, 100) },
                { MirAction.Attack1, new Frame(80, 6, 0, 100) },
                { MirAction.AttackRange1, new Frame(224, 6, 0, 100) },
                { MirAction.Struck, new Frame(128, 2, 0, 200) },
                { MirAction.Die, new Frame(144, 10, 0, 100) },
                { MirAction.Dead, new Frame(153, 1, 9, 1000) },
                { MirAction.Revive, new Frame(144, 10, 0, 100) { Reverse = true } }
            };
            BigRat = new FrameSet      //大老鼠,大老鼠0,远古大老鼠动作帧
            {
                { MirAction.Standing, new Frame(0, 4, 0, 500) },
                { MirAction.Walking, new Frame(32, 6, 0, 100) },
                { MirAction.Attack1, new Frame(80, 6, 0, 100) },
                { MirAction.Struck, new Frame(128, 2, 0, 200) },
                { MirAction.Die, new Frame(144, 10, 0, 100) },
                { MirAction.Dead, new Frame(153, 1, 9, 1000) },
                { MirAction.Revive, new Frame(144, 10, 0, 100) { Reverse = true } }
            };
            BlackBoar = new FrameSet      //黑野猪,远古黑野猪动作帧
            {
                { MirAction.Standing, new Frame(0, 4, 0, 500) },
                { MirAction.Walking, new Frame(32, 6, 0, 100) },
                { MirAction.Attack1, new Frame(80, 6, 0, 100) },
                { MirAction.Struck, new Frame(128, 2, 0, 200) },
                { MirAction.Die, new Frame(144, 10, 0, 100) },
                { MirAction.Dead, new Frame(153, 1, 9, 1000) },
                { MirAction.Revive, new Frame(144, 10, 0, 100) { Reverse = true } }
            };
            RedBoar = new FrameSet      //红野猪,远古红野猪动作帧
            {
                { MirAction.Standing, new Frame(0, 4, 0, 500) },
                { MirAction.Walking, new Frame(32, 6, 0, 100) },
                { MirAction.Attack1, new Frame(80, 6, 0, 100) },
                { MirAction.Struck, new Frame(128, 2, 0, 200) },
                { MirAction.Die, new Frame(144, 10, 0, 100) },
                { MirAction.Dead, new Frame(153, 1, 9, 1000) },
                { MirAction.Revive, new Frame(144, 10, 0, 100) { Reverse = true } }
            };
            SnakeScorpion = new FrameSet      //蝎蛇,远古蝎蛇动作帧
            {
                { MirAction.Standing, new Frame(0, 4, 0, 500) },
                { MirAction.Walking, new Frame(32, 6, 0, 100) },
                { MirAction.Attack1, new Frame(80, 6, 0, 100) },
                { MirAction.Struck, new Frame(128, 2, 0, 200) },
                { MirAction.Die, new Frame(144, 10, 0, 100) },
                { MirAction.Dead, new Frame(153, 1, 9, 1000) },
                { MirAction.Revive, new Frame(144, 10, 0, 100) { Reverse = true } }
            };
            BlackMaggot = new FrameSet      //黑色恶蛆,远古黑色恶蛆动作帧
            {
                { MirAction.Standing, new Frame(0, 4, 0, 500) },
                { MirAction.Walking, new Frame(32, 6, 0, 100) },
                { MirAction.Attack1, new Frame(80, 6, 0, 100) },
                { MirAction.Struck, new Frame(128, 2, 0, 200) },
                { MirAction.Die, new Frame(144, 10, 0, 100) },
                { MirAction.Dead, new Frame(153, 1, 9, 1000) },
                { MirAction.Revive, new Frame(144, 10, 0, 100) { Reverse = true } }
            };
            BugBatMaggot = new FrameSet      //角蝇动作帧
            {
                { MirAction.Standing, new Frame(0, 4, -4, 1000) },
                { MirAction.Attack1, new Frame(4, 6, -6, 100) },
                { MirAction.Struck, new Frame(10, 2, -2, 200) },
                { MirAction.Die, new Frame(12, 10, -10, 150) },
                { MirAction.Dead, new Frame(21, 1, -1, 1000) },
                { MirAction.Revive, new Frame(12, 10, -10, 150) { Reverse = true } }
            };
            BugBat = new FrameSet      //蝙蝠动作帧
            {
                { MirAction.Standing, new Frame(0, 4, 0, 500) },
                { MirAction.Walking, new Frame(32, 6, 0, 100) },
                { MirAction.Attack1, new Frame(80, 6, 0, 100) },
                { MirAction.Struck, new Frame(128, 2, 0, 200) },
                { MirAction.Die, new Frame(144, 10, 0, 100) },
                { MirAction.Dead, new Frame(153, 1, 9, 1000) },
                { MirAction.Revive, new Frame(144, 10, 0, 100) { Reverse = true } }
            };
            WedgeMoth = new FrameSet      //楔蛾动作帧
            {
                { MirAction.Standing, new Frame(0, 4, 0, 500) },
                { MirAction.Walking, new Frame(32, 6, 0, 100) },
                { MirAction.Attack1, new Frame(80, 6, 0, 100) },
                { MirAction.Struck, new Frame(128, 2, 0, 200) },
                { MirAction.Die, new Frame(144, 10, 0, 100) },
                { MirAction.Dead, new Frame(153, 1, 9, 1000) },
                { MirAction.Revive, new Frame(144, 10, 0, 100) { Reverse = true } }
            };
            EvilCentipede = new FrameSet      //触龙神动作帧
            {
                { MirAction.Show, new Frame(22, 10, -10, 150) },
                { MirAction.Hide, new Frame(31, 10, -10, 150) },
                { MirAction.Standing, new Frame(0, 4, -4, 1000) },
                { MirAction.Attack1, new Frame(4, 6, -6, 100) },
                { MirAction.Struck, new Frame(10, 2, -2, 200) },
                { MirAction.Die, new Frame(12, 10, -10, 150) },
                { MirAction.Dead, new Frame(21, 1, -1, 1000) },
                { MirAction.Revive, new Frame(12, 10, -10, 150) { Reverse = true } }
            };
            Tongs = new FrameSet      //钳虫动作帧
            {
                { MirAction.Standing, new Frame(0, 4, 0, 500) },
                { MirAction.Walking, new Frame(32, 6, 0, 100) },
                { MirAction.Attack1, new Frame(80, 6, 0, 100) },
                { MirAction.Struck, new Frame(128, 2, 0, 200) },
                { MirAction.Die, new Frame(144, 10, 0, 100) },
                { MirAction.Dead, new Frame(153, 1, 9, 1000) },
                { MirAction.Revive, new Frame(144, 10, 0, 100) { Reverse = true } }
            };
            WhimperingBee = new FrameSet      //跳跳蜂动作帧
            {
                { MirAction.Standing, new Frame(0, 4, 0, 500) },
                { MirAction.Walking, new Frame(32, 6, 0, 100) },
                { MirAction.Attack1, new Frame(80, 6, 0, 100) },
                { MirAction.Struck, new Frame(128, 2, 0, 200) },
                { MirAction.Die, new Frame(144, 10, 0, 100) },
                { MirAction.Dead, new Frame(153, 1, 9, 1000) },
                { MirAction.Revive, new Frame(144, 10, 0, 100) { Reverse = true } }
            };
            GiantWorm = new FrameSet      //蠕虫动作帧
            {
                { MirAction.Standing, new Frame(0, 4, 0, 500) },
                { MirAction.Walking, new Frame(32, 6, 0, 100) },
                { MirAction.Attack1, new Frame(80, 6, 0, 100) },
                { MirAction.Struck, new Frame(128, 2, 0, 200) },
                { MirAction.Die, new Frame(144, 10, 0, 100) },
                { MirAction.Dead, new Frame(153, 1, 9, 1000) },
                { MirAction.Revive, new Frame(144, 10, 0, 100) { Reverse = true } }
            };
            Centipede = new FrameSet      //蜈蚣动作帧
            {
                { MirAction.Standing, new Frame(0, 4, 0, 500) },
                { MirAction.Walking, new Frame(32, 6, 0, 100) },
                { MirAction.Attack1, new Frame(80, 6, 0, 100) },
                { MirAction.Struck, new Frame(128, 2, 0, 200) },
                { MirAction.Die, new Frame(144, 10, 0, 100) },
                { MirAction.Dead, new Frame(153, 1, 9, 1000) },
                { MirAction.Revive, new Frame(144, 10, 0, 100) { Reverse = true } }
            };
            Treasurebox = new FrameSet      //宝箱动作帧
            {
                { MirAction.Standing, new Frame(0, 3, -3, 1000) },
                { MirAction.Struck, new Frame(3, 3, -3, 200) },
                { MirAction.Die, new Frame(3, 7, -7, 150) },
                { MirAction.Dead, new Frame(9, 1, -1, 1000) },
                { MirAction.Revive, new Frame(3, 7, -7, 150) { Reverse = true } }
            };
            Yimoogi = new FrameSet      //浮龙金蛇动作帧
            {
                { MirAction.Standing, new Frame(0, 4, 0, 500) },
                { MirAction.Walking, new Frame(32, 6, 0, 100) },
                { MirAction.Attack1, new Frame(80, 6, 0, 100) },
                { MirAction.Attack2, new Frame(224, 6, 0, 100) },
                { MirAction.Attack3, new Frame(224, 6, 0, 100) },
                { MirAction.AttackRange1, new Frame(224, 6, 0, 100) },
                { MirAction.Struck, new Frame(128, 2, 0, 200) },
                { MirAction.Die, new Frame(144, 10, 0, 100) },
                { MirAction.Dead, new Frame(153, 1, 9, 1000) },
                { MirAction.Revive, new Frame(144, 10, 0, 100) { Reverse = true } }
            };
            GiantWhiteSnake = new FrameSet      //白灵蛇,白蛇动作帧
            {
                { MirAction.Standing, new Frame(0, 4, 0, 500) },
                { MirAction.Walking, new Frame(32, 6, 0, 100) },
                { MirAction.Attack1, new Frame(80, 6, 0, 100) },
                { MirAction.Struck, new Frame(128, 2, 0, 200) },
                { MirAction.Die, new Frame(144, 10, 0, 100) },
                { MirAction.Dead, new Frame(153, 1, 9, 1000) },
                { MirAction.Revive, new Frame(144, 10, 0, 100) { Reverse = true } }
            };
            YellowSnake = new FrameSet      //黄蝰蛇动作帧
            {
                { MirAction.Standing, new Frame(0, 4, 0, 500) },
                { MirAction.Walking, new Frame(32, 6, 0, 100) },
                { MirAction.Attack1, new Frame(80, 6, 0, 100) },
                { MirAction.Struck, new Frame(128, 2, 0, 200) },
                { MirAction.Die, new Frame(144, 10, 0, 100) },
                { MirAction.Dead, new Frame(153, 1, 9, 1000) },
                { MirAction.Revive, new Frame(144, 10, 0, 100) { Reverse = true } }
            };
            BlueSnake = new FrameSet      //蓝蝰蛇动作帧
            {
                { MirAction.Standing, new Frame(0, 4, 0, 500) },
                { MirAction.Walking, new Frame(32, 6, 0, 100) },
                { MirAction.Attack1, new Frame(80, 6, 0, 100) },
                { MirAction.Struck, new Frame(128, 2, 0, 200) },
                { MirAction.Die, new Frame(144, 10, 0, 100) },
                { MirAction.Dead, new Frame(153, 1, 9, 1000) },
                { MirAction.Revive, new Frame(144, 10, 0, 100) { Reverse = true } }
            };
            CrawlerZombie = new FrameSet      //僵尸5,僵尸50,残肢僵尸动作帧
            {
                { MirAction.Standing, new Frame(0, 4, 0, 500) },
                { MirAction.Walking, new Frame(32, 6, 0, 100) },
                { MirAction.Attack1, new Frame(80, 6, 0, 100) },
                { MirAction.Struck, new Frame(128, 2, 0, 200) },
                { MirAction.Die, new Frame(144, 10, 0, 100) },
                { MirAction.Dead, new Frame(153, 1, 9, 1000) },
                { MirAction.Revive, new Frame(244, 10, 0, 100) { Reverse = true } }
            };
            BoneWhoo = new FrameSet      //远古骷髅王动作帧
            {
                { MirAction.Standing, new Frame(0, 4, 0, 500) },
                { MirAction.Walking, new Frame(32, 6, 0, 100) },
                { MirAction.Attack1, new Frame(80, 6, 0, 100) },
                { MirAction.Struck, new Frame(128, 2, 0, 200) },
                { MirAction.Die, new Frame(144, 10, 0, 100) },
                { MirAction.Dead, new Frame(153, 1, 9, 1000) },
                { MirAction.Revive, new Frame(144, 10, 0, 100) { Reverse = true } }
            };
            BoneElite = new FrameSet      //骷髅精灵,远古骷髅精灵动作帧
            {
                { MirAction.Standing, new Frame(0, 4, 0, 500) },
                { MirAction.Walking, new Frame(32, 6, 0, 100) },
                { MirAction.Attack1, new Frame(80, 6, 0, 100) },
                { MirAction.Struck, new Frame(128, 2, 0, 200) },
                { MirAction.Die, new Frame(144, 10, 0, 100) },
                { MirAction.Dead, new Frame(153, 1, 9, 1000) },
                { MirAction.Revive, new Frame(144, 10, 0, 100) { Reverse = true } }
            };
            BoneWarrior = new FrameSet      //骷髅战将,远古骷髅战将动作帧
            {
                { MirAction.Standing, new Frame(0, 4, 0, 500) },
                { MirAction.Walking, new Frame(32, 6, 0, 100) },
                { MirAction.Attack1, new Frame(80, 6, 0, 100) },
                { MirAction.Struck, new Frame(128, 2, 0, 200) },
                { MirAction.Die, new Frame(144, 10, 0, 100) },
                { MirAction.Dead, new Frame(153, 1, 9, 1000) },
                { MirAction.Revive, new Frame(144, 10, 0, 100) { Reverse = true } }
            };
            BoneFighter = new FrameSet      //骷髅战士,远古骷髅战士动作帧
            {
                { MirAction.Standing, new Frame(0, 4, 0, 500) },
                { MirAction.Walking, new Frame(32, 6, 0, 100) },
                { MirAction.Attack1, new Frame(80, 6, 0, 100) },
                { MirAction.Struck, new Frame(128, 2, 0, 200) },
                { MirAction.Die, new Frame(144, 10, 0, 100) },
                { MirAction.Dead, new Frame(153, 1, 9, 1000) },
                { MirAction.Revive, new Frame(144, 10, 0, 100) { Reverse = true } }
            };
            Skeleton = new FrameSet      //骷髅,远古骷髅动作帧
            {
                { MirAction.Standing, new Frame(0, 4, 0, 500) },
                { MirAction.Walking, new Frame(32, 6, 0, 100) },
                { MirAction.Attack1, new Frame(80, 6, 0, 100) },
                { MirAction.Struck, new Frame(128, 2, 0, 200) },
                { MirAction.Die, new Frame(144, 10, 0, 100) },
                { MirAction.Dead, new Frame(153, 1, 9, 1000) },
                { MirAction.Revive, new Frame(144, 10, 0, 100) { Reverse = true } }
            };
            AxeSkeleton = new FrameSet      //掷斧骷髅,远古掷斧骷髅动作帧
            {
                { MirAction.Standing, new Frame(0, 4, 0, 500) },
                { MirAction.Walking, new Frame(32, 6, 0, 100) },
                { MirAction.Attack1, new Frame(80, 6, 0, 100) },
                { MirAction.Struck, new Frame(128, 2, 0, 200) },
                { MirAction.Die, new Frame(144, 10, 0, 100) },
                { MirAction.Dead, new Frame(153, 1, 9, 1000) },
                { MirAction.Revive, new Frame(144, 10, 0, 100) { Reverse = true } }
            };
            Scorpion = new FrameSet      //蝎子动作帧
            {
                { MirAction.Standing, new Frame(0, 4, 0, 500) },
                { MirAction.Walking, new Frame(32, 6, 0, 100) },
                { MirAction.Attack1, new Frame(80, 6, 0, 100) },
                { MirAction.Attack2, new Frame(128, 6, 0, 100) },
                { MirAction.Struck, new Frame(176, 2, 0, 200) },
                { MirAction.Die, new Frame(192, 10, 0, 100) },
                { MirAction.Dead, new Frame(201, 1, 9, 1000) },
                { MirAction.Revive, new Frame(192, 10, 0, 100) { Reverse = true } }
            };
            CaveMaggot = new FrameSet      //洞蛆动作帧
            {
                { MirAction.Standing, new Frame(0, 4, 0, 500) },
                { MirAction.Walking, new Frame(32, 6, 0, 100) },
                { MirAction.Attack1, new Frame(80, 6, 0, 100) },
                { MirAction.Struck, new Frame(128, 2, 0, 200) },
                { MirAction.Die, new Frame(144, 4, 0, 100) },
                { MirAction.Dead, new Frame(147, 1, 3, 1000) },
                { MirAction.Revive, new Frame(144, 4, 0, 100) { Reverse = true } }
            };
            CaveBat = new FrameSet      //山洞蝙蝠动作帧
            {
                { MirAction.Standing, new Frame(0, 4, 0, 500) },
                { MirAction.Walking, new Frame(32, 6, 0, 100) },
                { MirAction.Attack1, new Frame(80, 6, 0, 100) },
                { MirAction.Struck, new Frame(128, 2, 0, 200) },
                { MirAction.Die, new Frame(144, 10, 0, 100) },
                { MirAction.Dead, new Frame(153, 1, 9, 1000) },
                { MirAction.Revive, new Frame(144, 10, 0, 100) { Reverse = true } }
            };
            GiantKeratoid = new FrameSet      //巨型角甲虫动作帧
            {
                { MirAction.Standing, new Frame(0, 4, 0, 500) },
                { MirAction.Walking, new Frame(32, 6, 0, 100) },
                { MirAction.Attack1, new Frame(80, 6, 0, 100) },
                { MirAction.Struck, new Frame(128, 2, 0, 200) },
                { MirAction.Die, new Frame(144, 10, 0, 100) },
                { MirAction.Dead, new Frame(153, 1, 9, 1000) },
                { MirAction.Revive, new Frame(144, 10, 0, 100) { Reverse = true } }
            };
            SandWorm = new FrameSet      //沙虫动作帧
            {
                { MirAction.Standing, new Frame(0, 4, 0, 500) },
                { MirAction.Walking, new Frame(32, 6, 0, 100) },
                { MirAction.Attack1, new Frame(80, 6, 0, 100) },
                { MirAction.Struck, new Frame(128, 2, 0, 200) },
                { MirAction.Die, new Frame(144, 10, 0, 100) },
                { MirAction.Dead, new Frame(153, 1, 9, 1000) },
                { MirAction.Revive, new Frame(144, 10, 0, 100) { Reverse = true } }
            };
            SkyStinger = new FrameSet      //猎鹰动作帧
            {
                { MirAction.Standing, new Frame(0, 4, 0, 500) },
                { MirAction.Walking, new Frame(32, 6, 0, 100) },
                { MirAction.Attack1, new Frame(80, 6, 0, 100) },
                { MirAction.Struck, new Frame(128, 2, 0, 200) },
                { MirAction.Die, new Frame(144, 10, 0, 100) },
                { MirAction.Dead, new Frame(153, 1, 9, 1000) },
                { MirAction.Revive, new Frame(144, 10, 0, 100) { Reverse = true } }
            };
            ShellNipper = new FrameSet      //盔甲虫动作帧
            {
                { MirAction.Standing, new Frame(0, 4, 0, 500) },
                { MirAction.Walking, new Frame(32, 6, 0, 100) },
                { MirAction.Attack1, new Frame(80, 6, 0, 100) },
                { MirAction.Struck, new Frame(128, 2, 0, 200) },
                { MirAction.Die, new Frame(144, 10, 0, 100) },
                { MirAction.Dead, new Frame(153, 1, 9, 1000) },
                { MirAction.Revive, new Frame(144, 10, 0, 100) { Reverse = true } }
            };
            Keratoid = new FrameSet      //角甲虫动作帧
            {
                { MirAction.Standing, new Frame(0, 4, 0, 500) },
                { MirAction.Walking, new Frame(32, 6, 0, 100) },
                { MirAction.Attack1, new Frame(80, 6, 0, 100) },
                { MirAction.Struck, new Frame(128, 2, 0, 200) },
                { MirAction.Die, new Frame(144, 10, 0, 100) },
                { MirAction.Dead, new Frame(153, 1, 9, 1000) },
                { MirAction.Revive, new Frame(144, 10, 0, 100) { Reverse = true } }
            };
            TigerSnake = new FrameSet      //虎蛇动作帧
            {
                { MirAction.Standing, new Frame(0, 4, 0, 500) },
                { MirAction.Walking, new Frame(32, 6, 0, 100) },
                { MirAction.Attack1, new Frame(80, 6, 0, 100) },
                { MirAction.Struck, new Frame(128, 2, 0, 200) },
                { MirAction.Die, new Frame(144, 10, 0, 100) },
                { MirAction.Dead, new Frame(153, 1, 9, 1000) },
                { MirAction.Revive, new Frame(144, 10, 0, 100) { Reverse = true } }
            };
            RedSnake = new FrameSet      //红蛇动作帧
            {
                { MirAction.Standing, new Frame(0, 4, 0, 500) },
                { MirAction.Walking, new Frame(32, 6, 0, 100) },
                { MirAction.Attack1, new Frame(80, 6, 0, 100) },
                { MirAction.Struck, new Frame(128, 2, 0, 200) },
                { MirAction.Die, new Frame(144, 10, 0, 100) },
                { MirAction.Dead, new Frame(153, 1, 9, 1000) },
                { MirAction.Revive, new Frame(144, 10, 0, 100) { Reverse = true } }
            };
            LargeMushroom = new FrameSet      //大蘑菇动作帧
            {
                { MirAction.Standing, new Frame(0, 10, -10, 500) },
                { MirAction.Struck, new Frame(10, 2, -2, 200) },
                { MirAction.Die, new Frame(12, 10, -10, 100) },
                { MirAction.Dead, new Frame(21, 1, -1, 1000) },
                { MirAction.Revive, new Frame(12, 10, -10, 100) { Reverse = true } }
            };
            CherryTree = new FrameSet      //樱桃树动作帧
            {
                { MirAction.Standing, new Frame(0, 10, -10, 500) },
                { MirAction.Struck, new Frame(10, 2, -2, 200) },
                { MirAction.Die, new Frame(12, 10, -10, 100) },
                { MirAction.Dead, new Frame(21, 1, -1, 1000) },
                { MirAction.Revive, new Frame(12, 10, -10, 100) { Reverse = true } }
            };
            EbonyTree = new FrameSet      //乌木树动作帧
            {
                { MirAction.Standing, new Frame(0, 10, -10, 500) },
                { MirAction.Struck, new Frame(10, 2, -2, 200) },
                { MirAction.Die, new Frame(12, 10, -10, 100) },
                { MirAction.Dead, new Frame(21, 1, -1, 1000) },
                { MirAction.Revive, new Frame(12, 10, -10, 100) { Reverse = true } }
            };
            ChestnutTree = new FrameSet      //栗子树动作帧
            {
                { MirAction.Standing, new Frame(0, 10, -10, 500) },
                { MirAction.Struck, new Frame(10, 2, -2, 200) },
                { MirAction.Die, new Frame(12, 10, -10, 100) },
                { MirAction.Dead, new Frame(21, 1, -1, 1000) },
                { MirAction.Revive, new Frame(12, 10, -10, 100) { Reverse = true } }
            };
            ForestYeti = new FrameSet      //森林雪人动作帧
            {
                { MirAction.Standing, new Frame(0, 4, 0, 500) },
                { MirAction.Walking, new Frame(32, 6, 0, 100) },
                { MirAction.Attack1, new Frame(80, 6, 0, 100) },
                { MirAction.Struck, new Frame(128, 2, 0, 200) },
                { MirAction.Die, new Frame(144, 4, 0, 100) },
                { MirAction.Dead, new Frame(147, 1, 3, 1000) },
                { MirAction.Revive, new Frame(144, 4, 0, 100) { Reverse = true } }
            };
            OmaWarrior = new FrameSet      //半兽勇士动作帧
            {
                { MirAction.Standing, new Frame(0, 4, 0, 500) },
                { MirAction.Walking, new Frame(32, 6, 0, 100) },
                { MirAction.Attack1, new Frame(80, 6, 0, 100) },
                { MirAction.Struck, new Frame(128, 2, 0, 200) },
                { MirAction.Die, new Frame(144, 10, 0, 100) },
                { MirAction.Dead, new Frame(153, 1, 9, 1000) },
                { MirAction.Revive, new Frame(144, 10, 0, 100) { Reverse = true } }
            };
            OmaFighter = new FrameSet      //半兽战士动作帧
            {
                { MirAction.Standing, new Frame(0, 4, 0, 500) },
                { MirAction.Walking, new Frame(32, 6, 0, 100) },
                { MirAction.Attack1, new Frame(80, 6, 0, 100) },
                { MirAction.Struck, new Frame(128, 2, 0, 200) },
                { MirAction.Die, new Frame(144, 10, 0, 100) },
                { MirAction.Dead, new Frame(153, 1, 9, 1000) },
                { MirAction.Revive, new Frame(144, 10, 0, 100) { Reverse = true } }
            };
            Oma = new FrameSet      //半兽人动作帧
            {
                { MirAction.Standing, new Frame(0, 4, 0, 500) },
                { MirAction.Walking, new Frame(32, 6, 0, 100) },
                { MirAction.Attack1, new Frame(80, 6, 0, 100) },
                { MirAction.Struck, new Frame(128, 2, 0, 200) },
                { MirAction.Die, new Frame(144, 10, 0, 100) },
                { MirAction.Dead, new Frame(153, 1, 9, 1000) },
                { MirAction.Revive, new Frame(144, 10, 0, 100) { Reverse = true } }
            };
            CannibalPlant = new FrameSet      //食人花动作帧
            {
                { MirAction.Standing, new Frame(0, 4, -4, 500) },
                { MirAction.Show, new Frame(4, 8, -8, 200) },
                { MirAction.Hide, new Frame(12, 8, -8, 200) },
                { MirAction.Attack1, new Frame(20, 6, 0, 100) },
                { MirAction.Struck, new Frame(68, 2, 0, 200) },
                { MirAction.Die, new Frame(84, 10, 0, 100) },
                { MirAction.Dead, new Frame(93, 1, 9, 1000) },
                { MirAction.Revive, new Frame(84, 10, 0, 100) { Reverse = true } }
            };
            SpittingSpider = new FrameSet      //毒蜘蛛动作帧
            {
                { MirAction.Standing, new Frame(0, 4, 0, 500) },
                { MirAction.Walking, new Frame(32, 6, 0, 100) },
                { MirAction.Attack1, new Frame(80, 6, 0, 100) },
                { MirAction.Struck, new Frame(128, 2, 0, 200) },
                { MirAction.Die, new Frame(144, 10, 0, 100) },
                { MirAction.Dead, new Frame(153, 1, 9, 1000) },
                { MirAction.Revive, new Frame(144, 10, 0, 100) { Reverse = true } }
            };
            RakingCat = new FrameSet      //钉耙猫动作帧
            {
                { MirAction.Standing, new Frame(0, 4, 0, 500) },
                { MirAction.Walking, new Frame(32, 6, 0, 100) },
                { MirAction.Attack1, new Frame(80, 6, 0, 100) },
                { MirAction.Struck, new Frame(128, 2, 0, 200) },
                { MirAction.Die, new Frame(144, 10, 0, 100) },
                { MirAction.Dead, new Frame(153, 1, 9, 1000) },
                { MirAction.Revive, new Frame(144, 10, 0, 100) { Reverse = true } }
            };
            HookingCat = new FrameSet      //多钩猫动作帧
            {
                { MirAction.Standing, new Frame(0, 4, 0, 500) },
                { MirAction.Walking, new Frame(32, 6, 0, 100) },
                { MirAction.Attack1, new Frame(80, 6, 0, 100) },
                { MirAction.Struck, new Frame(128, 2, 0, 200) },
                { MirAction.Die, new Frame(144, 10, 0, 100) },
                { MirAction.Dead, new Frame(153, 1, 9, 1000) },
                { MirAction.Revive, new Frame(144, 10, 0, 100) { Reverse = true } }
            };
            Scarecrow = new FrameSet      //稻草人动作帧
            {
                { MirAction.Standing, new Frame(0, 4, 0, 500) },
                { MirAction.Walking, new Frame(32, 6, 0, 100) },
                { MirAction.Attack1, new Frame(80, 6, 0, 100) },
                { MirAction.Struck, new Frame(128, 2, 0, 200) },
                { MirAction.Die, new Frame(144, 10, 0, 100) },
                { MirAction.Dead, new Frame(153, 1, 9, 1000) },
                { MirAction.Revive, new Frame(144, 10, 0, 100) { Reverse = true } }
            };
            Yob = new FrameSet      //蛤蟆动作帧
            {
                { MirAction.Standing, new Frame(0, 4, 0, 500) },
                { MirAction.Walking, new Frame(32, 6, 0, 100) },
                { MirAction.Attack1, new Frame(80, 6, 0, 100) },
                { MirAction.Struck, new Frame(128, 2, 0, 200) },
                { MirAction.Die, new Frame(144, 10, 0, 100) },
                { MirAction.Dead, new Frame(153, 1, 9, 1000) },
                { MirAction.Revive, new Frame(144, 10, 0, 100) { Reverse = true } }
            };
            Wolf = new FrameSet      //恶狼动作帧
            {
                { MirAction.Standing, new Frame(0, 4, 0, 500) },
                { MirAction.Walking, new Frame(32, 6, 0, 100) },
                { MirAction.Attack1, new Frame(80, 6, 0, 100) },
                { MirAction.Struck, new Frame(128, 2, 0, 200) },
                { MirAction.Die, new Frame(144, 10, 0, 100) },
                { MirAction.Dead, new Frame(153, 1, 9, 1000) },
                { MirAction.Skeleton, new Frame(224, 1, 0, 1000) },
                { MirAction.Revive, new Frame(144, 10, 0, 100) { Reverse = true } }
            };
            Sheep = new FrameSet      //羊动作帧
            {
                { MirAction.Standing, new Frame(0, 4, 0, 500) },
                { MirAction.Walking, new Frame(32, 6, 0, 100) },
                { MirAction.Attack1, new Frame(80, 6, 0, 100) },
                { MirAction.Struck, new Frame(128, 2, 0, 200) },
                { MirAction.Die, new Frame(144, 10, 0, 100) },
                { MirAction.Dead, new Frame(153, 1, 9, 1000) },
                { MirAction.Skeleton, new Frame(224, 1, 0, 1000) },
                { MirAction.Revive, new Frame(144, 10, 0, 100) { Reverse = true } }
            };
            Bull = new FrameSet      //牛动作帧
            {
                { MirAction.Standing, new Frame(0, 4, 0, 500) },
                { MirAction.Walking, new Frame(32, 6, 0, 100) },
                { MirAction.Attack1, new Frame(80, 6, 0, 100) },
                { MirAction.Struck, new Frame(128, 2, 0, 200) },
                { MirAction.Die, new Frame(144, 10, 0, 100) },
                { MirAction.Dead, new Frame(153, 1, 9, 1000) },
                { MirAction.Skeleton, new Frame(224, 1, 0, 1000) },
                { MirAction.Revive, new Frame(144, 10, 0, 100) { Reverse = true } }
            };
            Pig = new FrameSet      //猪动作帧
            {
                { MirAction.Standing, new Frame(0, 4, 0, 500) },
                { MirAction.Walking, new Frame(32, 6, 0, 100) },
                { MirAction.Attack1, new Frame(80, 6, 0, 100) },
                { MirAction.Struck, new Frame(128, 2, 0, 200) },
                { MirAction.Die, new Frame(144, 10, 0, 100) },
                { MirAction.Dead, new Frame(153, 1, 9, 1000) },
                { MirAction.Skeleton, new Frame(224, 1, 0, 1000) },
                { MirAction.Revive, new Frame(144, 10, 0, 100) { Reverse = true } }
            };
            Deer = new FrameSet      //鹿动作帧
            {
                { MirAction.Standing, new Frame(0, 4, 0, 500) },
                { MirAction.Walking, new Frame(32, 6, 0, 100) },
                { MirAction.Attack1, new Frame(80, 6, 0, 100) },
                { MirAction.Struck, new Frame(128, 2, 0, 200) },
                { MirAction.Die, new Frame(144, 10, 0, 100) },
                { MirAction.Dead, new Frame(153, 1, 9, 1000) },
                { MirAction.Skeleton, new Frame(224, 1, 0, 1000) },
                { MirAction.Revive, new Frame(144, 10, 0, 100) { Reverse = true } }
            };
            Hen = new FrameSet      //鸡动作帧
            {
                { MirAction.Standing, new Frame(0, 4, 0, 500) },
                { MirAction.Walking, new Frame(32, 6, 0, 100) },
                { MirAction.Attack1, new Frame(80, 6, 0, 100) },
                { MirAction.Struck, new Frame(128, 2, 0, 200) },
                { MirAction.Die, new Frame(144, 10, 0, 100) },
                { MirAction.Dead, new Frame(153, 1, 9, 1000) },
                { MirAction.Skeleton, new Frame(224, 1, 0, 1000) },
                { MirAction.Revive, new Frame(144, 10, 0, 100) { Reverse = true } }
            };
            IcePhantom = new FrameSet      //恶鬼动作帧
            {
                { MirAction.Standing, new Frame(0, 4, 0, 500) },
                { MirAction.Walking, new Frame(32, 6, 0, 200) },
                { MirAction.Attack1, new Frame(80, 9, 0, 100) },
                { MirAction.AttackRange1, new Frame(152, 8, 0, 100) },
                { MirAction.Struck, new Frame(216, 3, 0, 200) },
                { MirAction.Die, new Frame(240, 10, 0, 100) },
                { MirAction.Dead, new Frame(999, 1, 9, 1000) },
                { MirAction.Revive, new Frame(240, 10, 0, 100) { Reverse = true } }
            };
            SnakeTotem = new FrameSet      //蛇图腾动作帧
            {
                { MirAction.Standing, new Frame(0, 2, -2, 500) },
                { MirAction.Walking, new Frame(0, 2, -2, 100) },
                { MirAction.Struck, new Frame(0, 1, -1, 100) },
                { MirAction.Die, new Frame(0, 1, -1, 100) },
                { MirAction.Dead, new Frame(0, 1, -1, 100) },
            };
            SpittingToad = new FrameSet      //蟾蜍动作帧
            {
                { MirAction.Standing, new Frame(0, 4, 0, 500) },
                { MirAction.AttackRange1, new Frame(32, 9, 0, 100) },
                { MirAction.Hide, new Frame(208, 4, 0, 100) },
                { MirAction.Show, new Frame(211, 4, 0, 100) },
                { MirAction.Struck, new Frame(104, 3, 0, 200) },
                { MirAction.Die, new Frame(128, 10, 0, 100) },
                { MirAction.Dead, new Frame(137, 1, 9, 1000) },
            };
            VampireSpider = new FrameSet      //吸血蜘蛛动作帧
            {
                { MirAction.Standing, new Frame(72, 4, 0, 500) },
                { MirAction.Attack1, new Frame(152, 5, 0, 100) },
                { MirAction.Walking, new Frame(104, 6, 0, 100) },
                { MirAction.Hide, new Frame(29, 6, 0, 150) },
                { MirAction.Show, new Frame(24, 6, 0, 150) },
                { MirAction.Struck, new Frame(192, 3, 0, 200) },
                { MirAction.Die, new Frame(216, 10, 0, 100) },
                { MirAction.Dead, new Frame(225, 1, 9, 1000) },
            };
            HolyDeva = new FrameSet      //精灵动作帧
            {
                { MirAction.Standing, new Frame(0, 4, 0, 500) },
                { MirAction.Walking, new Frame(32, 6, 0, 100) },
                { MirAction.Appear, new Frame(216, 10, -10, 100) },
                { MirAction.AttackRange1, new Frame(80, 6, 0, 100) },
                { MirAction.Struck, new Frame(128, 2, 0, 200) },
                { MirAction.Die, new Frame(144, 9, 0, 100) },
                { MirAction.Revive, new Frame(144, 9, 0, 100) { Reverse = true } }
            };
            Shinsu = new FrameSet      //神兽动作帧
            {
                { MirAction.Standing, new Frame(80, 4, 0, 500) },
                { MirAction.Appear, new Frame(0, 10, 0, 100) },
                { MirAction.Walking, new Frame(112, 6, 0, 100) },
                { MirAction.Hide, new Frame(265, 10, 0, 100) },
                { MirAction.Show, new Frame(256, 10, 0, 100) },
                { MirAction.Struck, new Frame(160, 2, 0, 200) },
                { MirAction.Die, new Frame(176, 10, 0, 100) },
                { MirAction.Revive, new Frame(176, 10, 0, 100) },
            };
            BoneFamiliar = new FrameSet      //变异骷髅动作帧
            {
                { MirAction.Standing, new Frame(0, 4, 0, 500) },
                { MirAction.Appear, new Frame(224, 10, -10, 100) },
                { MirAction.Walking, new Frame(32, 6, 0, 100) },
                { MirAction.Attack1, new Frame(80, 6, 0, 100) },
                { MirAction.Hide, new Frame(265, 10, 0, 100) },
                { MirAction.Show, new Frame(256, 10, 0, 100) },
                { MirAction.Struck, new Frame(128, 2, 0, 200) },
                { MirAction.Die, new Frame(144, 10, 0, 100) },
                { MirAction.Dead, new Frame(153, 1, 9, 1000) },
                { MirAction.Revive, new Frame(144, 10, 0, 100) },
            };
            KatanaGuard = new FrameSet      //练功师动作帧
            {
                { MirAction.Standing, new Frame(0, 4, 0, 500) },
                { MirAction.Walking, new Frame(32, 6, 0, 100) },
                { MirAction.Attack1, new Frame(80, 6, 0, 100) },
                { MirAction.Struck, new Frame(128, 2, 0, 200) },
                { MirAction.Die, new Frame(144, 10, 0, 100) },
                { MirAction.Dead, new Frame(153, 1, 9, 1000) },
                { MirAction.Revive, new Frame(144, 10, 0, 100) { Reverse = true } }
            };
            Guard2 = new FrameSet            //远古飞天护卫动作帧
            {
                { MirAction.Standing, new Frame(0, 4, 0, 500) },
                { MirAction.Walking, new Frame(32, 6, 0, 100) },
                { MirAction.Attack1, new Frame(80, 6, 0, 100) },
            };
            TaoistGuard = new FrameSet            //带刀护卫动作帧
            {
                { MirAction.Standing, new Frame(0, 4, 0, 500) },
                { MirAction.Attack1, new Frame(32, 6, 0, 100) },
            };
            Guard = new FrameSet            //卫士动作帧
            {
                { MirAction.Standing, new Frame(0, 4, 0, 500) },
                { MirAction.Walking, new Frame(32, 6, 0, 100) },
                { MirAction.Attack1, new Frame(80, 6, 0, 100) },
            };
            ArcherGuard = new FrameSet      //练功师动作帧
            {
                { MirAction.Standing, new Frame(0, 4, 0, 500) },
                { MirAction.Walking, new Frame(32, 6, 0, 100) },
                { MirAction.Attack1, new Frame(104, 6, 0, 100) },
                { MirAction.Struck, new Frame(176, 2, 0, 100) },
                { MirAction.Die, new Frame(192, 10, 0, 100) },
                { MirAction.Dead, new Frame(201, 1, 9, 1000) },
            };
            CharmedSnake = new FrameSet      //鬼魅蛇动作帧
            {
                { MirAction.Standing, new Frame(0, 5, 0, 200) },
                { MirAction.Walking, new Frame(0, 5, 0, 100) },
                { MirAction.Attack1, new Frame(0, 5, 0, 100) },
                { MirAction.Struck, new Frame(0, 5, 0, 100) },
                { MirAction.Die, new Frame(52, 8, 0, 100) },
                { MirAction.Dead, new Frame(59, 1, 7, 1000) },
            };
            FrozenSoldier = new FrameSet      //冰原鬼动作帧
            {
                { MirAction.Standing, new Frame(0, 4, 0, 500) },
                { MirAction.Walking, new Frame(32, 6, 0, 100) },
                { MirAction.Attack1, new Frame(80, 6, 0, 100) },
                { MirAction.Struck, new Frame(152, 3, 0, 200) },
                { MirAction.Die, new Frame(176, 10, 0, 100) },
                { MirAction.Dead, new Frame(185, 1, 9, 1000) },
                { MirAction.Revive, new Frame(176, 10, 0, 100) },
            };
            FrozenFighter = new FrameSet      //冰原鬼兵动作帧
            {
                { MirAction.Standing, new Frame(0, 4, 0, 500) },
                { MirAction.Walking, new Frame(32, 6, 0, 200) },
                { MirAction.Attack1, new Frame(80, 10, 0, 100) },
                { MirAction.Attack2, new Frame(160, 9, 0, 100) },
                { MirAction.Struck, new Frame(232, 3, 0, 200) },
                { MirAction.Die, new Frame(256, 10, 0, 100) },
                { MirAction.Dead, new Frame(265, 1, 9, 1000) },
                { MirAction.Revive, new Frame(256, 10, 0, 100) },
            };
            FrozenArcher = new FrameSet      //冰原鬼弓士动作帧
            {
                { MirAction.Standing, new Frame(0, 4, 0, 500) },
                { MirAction.Walking, new Frame(32, 6, 0, 200) },
                { MirAction.Attack1, new Frame(80, 10, 0, 100) },
                { MirAction.Struck, new Frame(160, 3, 0, 200) },
                { MirAction.Die, new Frame(184, 10, 0, 100) },
                { MirAction.Dead, new Frame(193, 1, 9, 1000) },
                { MirAction.Revive, new Frame(184, 10, 0, 100) },
            };
            FrozenKnight = new FrameSet      //冰原鬼尊动作帧
            {
                { MirAction.Standing, new Frame(0, 4, 0, 500) },
                { MirAction.Walking, new Frame(32, 6, 0, 200) },
                { MirAction.Attack1, new Frame(96, 10, 0, 100) },
                { MirAction.AttackRange1, new Frame(176, 10, 0, 100) },
                { MirAction.Struck, new Frame(256, 3, 0, 200) },
                { MirAction.Die, new Frame(280, 10, 0, 100) },
                { MirAction.Dead, new Frame(289, 1, 9, 1000) },
                { MirAction.Revive, new Frame(280, 10, 0, 100) },
            };
            SnowWolf = new FrameSet      //雪狼动作帧
            {
                { MirAction.Standing, new Frame(0, 4, 0, 500) },
                { MirAction.Walking, new Frame(32, 6, 0, 200) },
                { MirAction.Attack1, new Frame(80, 10, 0, 100) },
                { MirAction.Attack2, new Frame(160, 9, 0, 100) },
                { MirAction.Struck, new Frame(232, 3, 0, 200) },
                { MirAction.Die, new Frame(256, 9, 0, 100) },
                { MirAction.Dead, new Frame(264, 1, 8, 1000) },
                { MirAction.Revive, new Frame(256, 9, 0, 100) },
            };
            SnowWolfKing = new FrameSet      //雪太狼动作帧
            {
                { MirAction.Standing, new Frame(0, 4, 0, 500) },
                { MirAction.Walking, new Frame(32, 8, 0, 100) },
                { MirAction.Attack1, new Frame(96, 8, 0, 100) },
                { MirAction.Attack2, new Frame(160, 9, 0, 100) },
                { MirAction.Attack3, new Frame(232, 10, 0, 100) },
                { MirAction.Attack4, new Frame(312, 5, 0, 100) },
                { MirAction.Struck, new Frame(352, 3, 0, 200) },
                { MirAction.Die, new Frame(376, 10, 0, 100) },
                { MirAction.Dead, new Frame(385, 1, 9, 1000) },
                { MirAction.Revive, new Frame(376, 10, 0, 100) },
            };
            FrozenMiner = new FrameSet      //雪原鬼卒动作帧
            {
                { MirAction.Standing, new Frame(0, 4, 0, 500) },
                { MirAction.Walking, new Frame(112, 6, 0, 200) },
                { MirAction.Attack1, new Frame(160, 10, 0, 100) },
                { MirAction.Attack2, new Frame(240, 10, 0, 100) },
                { MirAction.Stance2, new Frame(32, 10, 0, 100) },
                { MirAction.Struck, new Frame(320, 4, 0, 200) },
                { MirAction.Die, new Frame(352, 10, 0, 100) },
                { MirAction.Dead, new Frame(361, 1, 9, 1000) },
                { MirAction.Revive, new Frame(352, 10, 0, 100) },
            };
            FrozenAxeman = new FrameSet      //雪原鬼兵动作帧
            {
                { MirAction.Standing, new Frame(0, 4, 0, 500) },
                { MirAction.Walking, new Frame(112, 8, 0, 200) },
                { MirAction.Attack1, new Frame(176, 10, 0, 100) },
                { MirAction.Attack2, new Frame(256, 10, 0, 100) },
                { MirAction.Attack3, new Frame(336, 10, 0, 100) },
                { MirAction.Struck, new Frame(416, 4, 0, 200) },
                { MirAction.Die, new Frame(448, 10, 0, 100) },
                { MirAction.Dead, new Frame(457, 1, 9, 1000) },
                { MirAction.Revive, new Frame(448, 10, 0, 100) },
            };
            FrozenMagician = new FrameSet      //雪原鬼监动作帧
            {
                { MirAction.Standing, new Frame(0, 4, 0, 500) },
                { MirAction.Walking, new Frame(112, 6, 0, 200) },
                { MirAction.AttackRange1, new Frame(160, 10, 0, 100) },
                { MirAction.AttackRange2, new Frame(240, 10, 0, 100) },
                { MirAction.Attack1, new Frame(330, 10, 0, 100) },
                { MirAction.Struck, new Frame(400, 4, 0, 200) },
                { MirAction.Die, new Frame(432, 10, 0, 100) },
                { MirAction.Dead, new Frame(441, 1, 9, 1000) },
                { MirAction.Revive, new Frame(432, 10, 0, 100) },
            };
            SnowYeti = new FrameSet      //雪怪动作帧
            {
                { MirAction.Standing, new Frame(0, 7, 0, 500) },
                { MirAction.Walking, new Frame(136, 8, 0, 200) },
                { MirAction.Attack1, new Frame(200, 9, 0, 100) },
                { MirAction.Attack2, new Frame(272, 9, 0, 100) },
                { MirAction.Attack3, new Frame(344, 8, 0, 100) },
                { MirAction.Struck, new Frame(408, 3, 0, 200) },
                { MirAction.Die, new Frame(432, 9, 0, 100) },
                { MirAction.Dead, new Frame(440, 1, 8, 1000) },
                { MirAction.Revive, new Frame(432, 9, 0, 100) },
            };
            IceCrystalSoldier = new FrameSet      //冰雪人动作帧
            {
                { MirAction.Standing, new Frame(0, 6, 0, 500) },
                { MirAction.Walking, new Frame(48, 8, 0, 200) },
                { MirAction.Attack1, new Frame(112, 10, 0, 100) },
                { MirAction.Attack2, new Frame(192, 10, 0, 100) },
                { MirAction.Attack3, new Frame(272, 10, 0, 100) },
                { MirAction.Struck, new Frame(352, 4, 0, 200) },
                { MirAction.Die, new Frame(384, 10, 0, 100) },
                { MirAction.Dead, new Frame(393, 1, 9, 1000) },
                { MirAction.Revive, new Frame(384, 10, 0, 100) },
            };
            DarkWraith = new FrameSet      //黑暗亡灵动作帧
            {
                { MirAction.Standing, new Frame(0, 4, 0, 500) },
                { MirAction.Walking, new Frame(32, 8, 0, 200) },
                { MirAction.Attack1, new Frame(80, 8, 0, 100) },
                { MirAction.Attack2, new Frame(144, 10, 0, 100) },
                { MirAction.Attack3, new Frame(224, 4, 0, 100) },
                { MirAction.Struck, new Frame(256, 4, 0, 200) },
                { MirAction.Die, new Frame(280, 10, 0, 100) },
                { MirAction.Dead, new Frame(289, 1, 9, 1000) },
                { MirAction.Revive, new Frame(280, 10, 0, 100) },
            };
            DarkSpirit = new FrameSet      //黑暗恶灵动作帧
            {
                { MirAction.Standing, new Frame(0, 4, 0, 500) },
                { MirAction.Walking, new Frame(32, 6, 0, 200) },
                { MirAction.AttackRange1, new Frame(80, 9, 0, 100) },
                { MirAction.Struck, new Frame(152, 3, 0, 200) },
                { MirAction.Die, new Frame(176, 10, 0, 100) },
                { MirAction.Dead, new Frame(175, 1, 9, 1000) },
                { MirAction.Revive, new Frame(176, 10, 0, 100) },
            };
            CrystalBeast = new FrameSet      //青神石魔人动作帧
            {
                { MirAction.Standing, new Frame(0, 6, 0, 500) },
                { MirAction.Walking, new Frame(48, 6, 0, 200) },
                { MirAction.Attack1, new Frame(96, 10, 0, 100) },
                { MirAction.Attack2, new Frame(176, 8, 0, 100) },
                { MirAction.Attack3, new Frame(240, 6, 0, 100) },
                { MirAction.AttackRange1, new Frame(288, 5, 0, 100) },
                { MirAction.AttackRange2, new Frame(328, 2, 0, 100) },
                { MirAction.AttackRange3, new Frame(344, 8, 0, 100) },
                { MirAction.Struck, new Frame(408, 3, 0, 200) },
                { MirAction.Die, new Frame(432, 8, 0, 100) },
                { MirAction.Dead, new Frame(440, 1, 7, 1000) },
                { MirAction.Revive, new Frame(432, 10, 0, 100) },
            };
            Guard3 = new FrameSet      //夏间警戒兵动作帧
            {
                { MirAction.Standing, new Frame(0, 7, 0, 200) },
                { MirAction.AttackRange1, new Frame(56, 7, 0, 100) },
            };
            ArcherGuard3 = new FrameSet      //夏间弓手警戒兵动作帧
            {
                { MirAction.Standing, new Frame(0, 6, 0, 500) },
                { MirAction.AttackRange1, new Frame(48, 7, 0, 100) },
            };
            Football = new FrameSet      //足球动作帧
            {
                { MirAction.Standing, new Frame(0, 1, 0, 1000) },
                { MirAction.AttackRange1, new Frame(8, 6, 0, 100) },
            };
            DarkGhost = new FrameSet      //精魂动作帧
            {
                { MirAction.Standing, new Frame(0, 4, 0, 500) },
                { MirAction.Walking, new Frame(32, 6, 0, 200) },
                { MirAction.Attack1, new Frame(80, 6, 0, 100) },
                { MirAction.Attack2, new Frame(208, 8, 0, 100) },
                { MirAction.Attack3, new Frame(272, 8, 0, 100) },
                { MirAction.Struck, new Frame(128, 2, 0, 200) },
                { MirAction.Die, new Frame(144, 8, 0, 100) },
                { MirAction.Dead, new Frame(151, 1, 7, 1000) },
                { MirAction.Revive, new Frame(144, 8, 0, 100) },
            };
            RedTurtle = new FrameSet      //红海龟动作帧
            {
                { MirAction.Standing, new Frame(0, 4, 0, 500) },
                { MirAction.Walking, new Frame(32, 6, 0, 100) },
                { MirAction.Attack1, new Frame(80, 6, 0, 100) },
                { MirAction.Struck, new Frame(128, 2, 0, 200) },
                { MirAction.Die, new Frame(144, 10, 0, 100) },
                { MirAction.Dead, new Frame(153, 1, 9, 1000) },
                { MirAction.Revive, new Frame(144, 10, 0, 100) { Reverse = true } }
            };
            GreenTurtle = new FrameSet      //绿海龟动作帧
            {
                { MirAction.Standing, new Frame(0, 4, 0, 500) },
                { MirAction.Walking, new Frame(32, 6, 0, 100) },
                { MirAction.Attack1, new Frame(80, 6, 0, 100) },
                { MirAction.Struck, new Frame(128, 2, 0, 200) },
                { MirAction.Die, new Frame(144, 10, 0, 100) },
                { MirAction.Dead, new Frame(153, 1, 9, 1000) },
                { MirAction.Revive, new Frame(144, 10, 0, 100) { Reverse = true } }
            };
            BlueTurtle = new FrameSet      //蓝海龟动作帧
            {
                { MirAction.Standing, new Frame(0, 4, 0, 500) },
                { MirAction.Walking, new Frame(32, 6, 0, 100) },
                { MirAction.Attack1, new Frame(80, 6, 0, 100) },
                { MirAction.Struck, new Frame(128, 2, 0, 200) },
                { MirAction.Die, new Frame(144, 10, 0, 100) },
                { MirAction.Dead, new Frame(153, 1, 9, 1000) },
                { MirAction.Revive, new Frame(144, 10, 0, 100) { Reverse = true } }
            };
            TowerTurtle = new FrameSet      //宝塔龟动作帧
            {
                { MirAction.Standing, new Frame(0, 4, 0, 500) },
                { MirAction.Walking, new Frame(32, 6, 0, 100) },
                { MirAction.Attack1, new Frame(80, 6, 0, 100) },
                { MirAction.Struck, new Frame(128, 2, 0, 200) },
                { MirAction.Die, new Frame(144, 10, 0, 100) },
                { MirAction.Dead, new Frame(153, 1, 9, 1000) },
                { MirAction.Revive, new Frame(144, 10, 0, 100) { Reverse = true } }
            };
            FinialTurtle = new FrameSet      //水箭龟动作帧
            {
                { MirAction.Standing, new Frame(0, 4, 0, 500) },
                { MirAction.Walking, new Frame(32, 6, 0, 100) },
                { MirAction.Attack1, new Frame(80, 6, 0, 100) },
                { MirAction.AttackRange1, new Frame(224, 6, 0, 100) },
                { MirAction.Struck, new Frame(128, 2, 0, 200) },
                { MirAction.Die, new Frame(144, 10, 0, 100) },
                { MirAction.Dead, new Frame(153, 1, 9, 1000) },
                { MirAction.Revive, new Frame(144, 10, 0, 100) { Reverse = true } }
            };
            DarkTurtle = new FrameSet      //幽冥龟动作帧
            {
                { MirAction.Standing, new Frame(0, 4, 0, 500) },
                { MirAction.Walking, new Frame(32, 6, 0, 100) },
                { MirAction.Attack1, new Frame(80, 6, 0, 100) },
                { MirAction.Struck, new Frame(128, 2, 0, 200) },
                { MirAction.Die, new Frame(144, 10, 0, 100) },
                { MirAction.Dead, new Frame(153, 1, 9, 1000) },
                { MirAction.Revive, new Frame(144, 10, 0, 100) { Reverse = true } }
            };
            LightTurtle = new FrameSet      //光耀龟动作帧
            {
                { MirAction.Standing, new Frame(0, 4, 0, 500) },
                { MirAction.Walking, new Frame(32, 6, 0, 100) },
                { MirAction.Attack1, new Frame(80, 6, 0, 100) },
                { MirAction.Attack2, new Frame(224, 6, 0, 100) },
                { MirAction.Struck, new Frame(128, 2, 0, 200) },
                { MirAction.Die, new Frame(144, 10, 0, 100) },
                { MirAction.Dead, new Frame(153, 1, 9, 1000) },
                { MirAction.Revive, new Frame(144, 10, 0, 100) { Reverse = true } }
            };
            TurtleKing = new FrameSet      //玄武将军动作帧
            {
                { MirAction.Standing, new Frame(0, 4, 0, 500) },
                { MirAction.Walking, new Frame(32, 6, 0, 100) },
                { MirAction.Attack1, new Frame(80, 10, 0, 150) },
                { MirAction.Attack2, new Frame(248, 6, 0, 150) },
                { MirAction.Struck, new Frame(160, 2, 0, 200) },
                { MirAction.Die, new Frame(176, 9, 0, 100) },
                { MirAction.Dead, new Frame(1000, 1, 8, 1000) },
                { MirAction.AttackRange1, new Frame(296, 6, 0, 150) },
                { MirAction.AttackRange2, new Frame(344, 6, 0, 150) },
                { MirAction.AttackRange3, new Frame(392, 8, 0, 150) },
                { MirAction.Revive, new Frame(176, 9, 0, 100) { Reverse = true } }
            };
            ManectricSlave = new FrameSet      //地狱奴隶动作帧
            {
                { MirAction.Standing, new Frame(0, 4, 0, 500) },
                { MirAction.Walking, new Frame(32, 6, 0, 100) },
                { MirAction.Attack1, new Frame(80, 6, 0, 100) },
                { MirAction.Attack2, new Frame(208, 6, 0, 100) },
                { MirAction.Attack3, new Frame(256, 8, 0, 100) },
                { MirAction.Struck, new Frame(128, 2, 0, 200) },
                { MirAction.Die, new Frame(144, 8, 0, 100) },
                { MirAction.Dead, new Frame(151, 1, 7, 1000) },
                { MirAction.Revive, new Frame(144, 8, 0, 100) { Reverse = true } }
            };
            TrollHammer = new FrameSet      //地狱锤兵动作帧
            {
                { MirAction.Standing, new Frame(0, 4, 0, 500) },
                { MirAction.Walking, new Frame(32, 6, 0, 200) },
                { MirAction.Attack1, new Frame(80, 6, 0, 100) },
                { MirAction.Attack2, new Frame(208, 8, 0, 100) },
                { MirAction.Attack3, new Frame(272, 7, 0, 100) },
                { MirAction.Struck, new Frame(128, 2, 0, 200) },
                { MirAction.Die, new Frame(144, 8, 0, 100) },
                { MirAction.Dead, new Frame(151, 1, 7, 1000) },
                { MirAction.Revive, new Frame(144, 8, 0, 100) { Reverse = true } }
            };
            TrollBomber = new FrameSet      //地狱炮兵动作帧
            {
                { MirAction.Standing, new Frame(0, 4, 0, 500) },
                { MirAction.Walking, new Frame(32, 6, 0, 200) },
                { MirAction.Attack1, new Frame(80, 6, 0, 100) },
                { MirAction.Attack2, new Frame(208, 8, 0, 100) },
                { MirAction.Attack3, new Frame(272, 7, 0, 100) },
                { MirAction.Struck, new Frame(128, 2, 0, 200) },
                { MirAction.Die, new Frame(144, 8, 0, 100) },
                { MirAction.Dead, new Frame(151, 1, 7, 1000) },
                { MirAction.Revive, new Frame(144, 8, 0, 100) { Reverse = true } }
            };
            TrollStoner = new FrameSet      //地狱投石手动作帧
            {
                { MirAction.Standing, new Frame(0, 4, 0, 500) },
                { MirAction.Walking, new Frame(32, 6, 0, 200) },
                { MirAction.Attack1, new Frame(80, 6, 0, 100) },
                { MirAction.Attack2, new Frame(208, 8, 0, 100) },
                { MirAction.Attack3, new Frame(272, 7, 0, 100) },
                { MirAction.Struck, new Frame(128, 2, 0, 200) },
                { MirAction.Die, new Frame(144, 8, 0, 100) },
                { MirAction.Dead, new Frame(151, 1, 7, 1000) },
                { MirAction.Revive, new Frame(144, 8, 0, 100) { Reverse = true } }
            };
            FlameMage = new FrameSet      //地狱魔焰鬼动作帧
            {
                { MirAction.Standing, new Frame(0, 4, 0, 500) },
                { MirAction.Walking, new Frame(32, 6, 0, 200) },
                { MirAction.Attack1, new Frame(80, 6, 0, 100) },
                { MirAction.Attack2, new Frame(224, 6, 0, 100) },
                { MirAction.AttackRange1, new Frame(224, 6, 0, 100) },
                { MirAction.Struck, new Frame(128, 2, 0, 200) },
                { MirAction.Die, new Frame(144, 10, 0, 100) },
                { MirAction.Dead, new Frame(153, 1, 9, 1000) },
                { MirAction.Revive, new Frame(144, 10, 0, 100) { Reverse = true } }
            };
            FlameSpear = new FrameSet      //地狱长矛鬼动作帧
            {
                { MirAction.Standing, new Frame(0, 4, 0, 500) },
                { MirAction.Walking, new Frame(32, 6, 0, 200) },
                { MirAction.Attack1, new Frame(80, 6, 0, 100) },
                { MirAction.Attack2, new Frame(224, 6, 0, 100) },
                { MirAction.AttackRange1, new Frame(224, 6, 0, 100) },
                { MirAction.Struck, new Frame(128, 2, 0, 200) },
                { MirAction.Die, new Frame(144, 10, 0, 100) },
                { MirAction.Dead, new Frame(153, 1, 9, 1000) },
                { MirAction.Revive, new Frame(144, 10, 0, 100) { Reverse = true } }
            };
            FlameScythe = new FrameSet      //地狱巨镰鬼动作帧
            {
                { MirAction.Standing, new Frame(0, 4, 0, 500) },
                { MirAction.Walking, new Frame(32, 6, 0, 200) },
                { MirAction.Attack1, new Frame(80, 6, 0, 100) },
                { MirAction.Attack2, new Frame(224, 6, 0, 100) },
                { MirAction.AttackRange1, new Frame(224, 6, 0, 100) },
                { MirAction.Struck, new Frame(128, 2, 0, 200) },
                { MirAction.Die, new Frame(144, 10, 0, 100) },
                { MirAction.Dead, new Frame(153, 1, 9, 1000) },
                { MirAction.Revive, new Frame(144, 10, 0, 100) { Reverse = true } }
            };
            FlameAssassin = new FrameSet      //地狱双刀鬼动作帧
            {
                { MirAction.Standing, new Frame(0, 4, 0, 500) },
                { MirAction.Walking, new Frame(32, 6, 0, 200) },
                { MirAction.Attack1, new Frame(80, 6, 0, 100) },
                { MirAction.Attack2, new Frame(224, 6, 0, 100) },
                { MirAction.AttackRange1, new Frame(224, 6, 0, 100) },
                { MirAction.Struck, new Frame(128, 2, 0, 200) },
                { MirAction.Die, new Frame(144, 10, 0, 100) },
                { MirAction.Dead, new Frame(153, 1, 9, 1000) },
                { MirAction.Revive, new Frame(144, 10, 0, 100) { Reverse = true } }
            };
            TrollKing = new FrameSet      //巨锤王动作帧
            {
                { MirAction.Standing, new Frame(0, 4, 0, 500) },
                { MirAction.Walking, new Frame(32, 6, 0, 200) },
                { MirAction.Attack1, new Frame(80, 6, 0, 100) },
                { MirAction.Attack2, new Frame(224, 8, 0, 100) },
                { MirAction.AttackRange1, new Frame(288, 9, 0, 100) },
                { MirAction.AttackRange2, new Frame(224, 8, 0, 100) },
                { MirAction.Struck, new Frame(128, 2, 0, 200) },
                { MirAction.Die, new Frame(144, 10, 0, 100) },
                { MirAction.Dead, new Frame(153, 1, 9, 1000) },
                { MirAction.Revive, new Frame(144, 10, 0, 100) { Reverse = true } }
            };
            FlameQueen = new FrameSet      //剑妖王动作帧
            {
                { MirAction.Standing, new Frame(0, 4, 0, 500) },
                { MirAction.Walking, new Frame(32, 6, 0, 200) },
                { MirAction.Attack1, new Frame(80, 6, 0, 100) },
                { MirAction.Attack2, new Frame(224, 9, 0, 100) },
                { MirAction.AttackRange1, new Frame(296, 8, 0, 100) },
                { MirAction.Struck, new Frame(128, 2, 0, 200) },
                { MirAction.Die, new Frame(144, 10, 0, 100) },
                { MirAction.Dead, new Frame(153, 1, 9, 1000) },
                { MirAction.Revive, new Frame(144, 10, 0, 100) { Reverse = true } }
            };
            HellKnight1 = new FrameSet      //魔焰守护动作帧
            {
                { MirAction.Appear, new Frame(0, 4, 0, 500) },
                { MirAction.Standing, new Frame(0, 4, 0, 500) },
                { MirAction.Walking, new Frame(32, 6, 0, 200) },
                { MirAction.Attack1, new Frame(80, 6, 0, 100) },
                { MirAction.Attack2, new Frame(176, 6, 0, 100) },
                { MirAction.AttackRange1, new Frame(80, 6, 0, 100) },
                { MirAction.AttackRange2, new Frame(176, 6, 0, 100) },
                { MirAction.Struck, new Frame(128, 2, 0, 200) },
                { MirAction.Die, new Frame(144, 4, 0, 100) },
                { MirAction.Dead, new Frame(147, 1, 3, 1000) },
                { MirAction.Revive, new Frame(144, 4, 0, 100) { Reverse = true } }
            };
            HellKnight2 = new FrameSet      //寒冰守护动作帧
            {
                { MirAction.Appear, new Frame(0, 4, 0, 500) },
                { MirAction.Standing, new Frame(0, 4, 0, 500) },
                { MirAction.Walking, new Frame(32, 6, 0, 200) },
                { MirAction.Attack1, new Frame(80, 6, 0, 100) },
                { MirAction.Attack2, new Frame(176, 6, 0, 100) },
                { MirAction.AttackRange1, new Frame(80, 6, 0, 100) },
                { MirAction.AttackRange2, new Frame(176, 6, 0, 100) },
                { MirAction.Struck, new Frame(128, 2, 0, 200) },
                { MirAction.Die, new Frame(144, 4, 0, 100) },
                { MirAction.Dead, new Frame(147, 1, 3, 1000) },
                { MirAction.Revive, new Frame(144, 4, 0, 100) { Reverse = true } }
            };
            HellKnight3 = new FrameSet      //定土守护动作帧
            {
                { MirAction.Appear, new Frame(0, 4, 0, 500) },
                { MirAction.Standing, new Frame(0, 4, 0, 500) },
                { MirAction.Walking, new Frame(32, 6, 0, 200) },
                { MirAction.Attack1, new Frame(80, 6, 0, 100) },
                { MirAction.Attack2, new Frame(176, 6, 0, 100) },
                { MirAction.AttackRange1, new Frame(80, 6, 0, 100) },
                { MirAction.AttackRange2, new Frame(176, 6, 0, 100) },
                { MirAction.Struck, new Frame(128, 2, 0, 200) },
                { MirAction.Die, new Frame(144, 4, 0, 100) },
                { MirAction.Dead, new Frame(147, 1, 3, 1000) },
                { MirAction.Revive, new Frame(144, 4, 0, 100) { Reverse = true } }
            };
            HellKnight4 = new FrameSet      //延火守护动作帧
            {
                { MirAction.Appear, new Frame(0, 4, 0, 500) },
                { MirAction.Standing, new Frame(0, 4, 0, 500) },
                { MirAction.Walking, new Frame(32, 6, 0, 200) },
                { MirAction.Attack1, new Frame(80, 6, 0, 100) },
                { MirAction.Attack2, new Frame(176, 6, 0, 100) },
                { MirAction.AttackRange1, new Frame(80, 6, 0, 100) },
                { MirAction.AttackRange2, new Frame(176, 6, 0, 100) },
                { MirAction.Struck, new Frame(128, 2, 0, 200) },
                { MirAction.Die, new Frame(144, 4, 0, 100) },
                { MirAction.Dead, new Frame(147, 1, 3, 1000) },
                { MirAction.Revive, new Frame(144, 4, 0, 100) { Reverse = true } }
            };
            HellLord = new FrameSet      //阎魔太子动作帧
            {
                { MirAction.Standing, new Frame(0, 4, -4, 500) },
                { MirAction.Attack1, new Frame(4, 6, -6, 200) },
                { MirAction.Struck, new Frame(0, 2, -2, 200) },
                { MirAction.Die, new Frame(10, 5, -5, 100) },
                { MirAction.Dead, new Frame(14, 1, -1, 1000) },
                { MirAction.Revive, new Frame(10, 5, -5, 100) { Reverse = true } }
            };
            Behemoth = new FrameSet      //怨恶动作帧
            {
                { MirAction.Standing, new Frame(0, 4, 0, 500) },
                { MirAction.Walking, new Frame(32, 6, 0, 100) },
                { MirAction.Attack1, new Frame(80, 6, 0, 100) },
                { MirAction.Attack2, new Frame(224, 6, 0, 100) },
                { MirAction.Attack3, new Frame(352, 7, 0, 100) },
                { MirAction.AttackRange1, new Frame(272, 10, 0, 100) },
                { MirAction.AttackRange2, new Frame(408, 7, 0, 100) },
                { MirAction.Struck, new Frame(128, 2, 0, 200) },
                { MirAction.Die, new Frame(144, 10, 0, 100) },
                { MirAction.Dead, new Frame(153, 1, 9, 1000) },
                { MirAction.Revive, new Frame(144, 10, 0, 100) { Reverse = true } }
            };
            Snake14 = new FrameSet      //螭动作帧
            {
                { MirAction.Standing, new Frame(0, 4, 0, 500) },
                { MirAction.Walking, new Frame(32, 6, 0, 100) },
                { MirAction.Attack1, new Frame(80, 6, 0, 100) },
                { MirAction.Attack2, new Frame(224, 6, 0, 100) },
                { MirAction.Attack3, new Frame(224, 6, 0, 100) },
                { MirAction.AttackRange1, new Frame(224, 6, 0, 100) },
                { MirAction.Struck, new Frame(128, 2, 0, 200) },
                { MirAction.Die, new Frame(144, 10, 0, 100) },
                { MirAction.Dead, new Frame(153, 1, 9, 1000) },
                { MirAction.Revive, new Frame(144, 10, 0, 100) { Reverse = true } }
            };
            WarriorScroll = new FrameSet           //秘密画轴1动作帧
            {
                { MirAction.Stoned, new Frame(0, 4, 0, 500) },
                { MirAction.Hide, new Frame(32, 5, 0, 100) },
                { MirAction.Show, new Frame(32, 5, 0, 100) },
                { MirAction.Standing, new Frame(32, 5, 0, 100) },
                { MirAction.Walking, new Frame(72, 6, 0, 100) },
                { MirAction.AttackRange1, new Frame(120, 9, 0, 100) },
                { MirAction.Struck, new Frame(192, 4, 0, 200) },
                { MirAction.Die, new Frame(224, 9, 0, 200) },
                { MirAction.Dead, new Frame(232, 1, 8, 1000) },
                { MirAction.Revive, new Frame(224, 9, 0, 100) { Reverse = true } }
            };
            TaoistScroll = new FrameSet           //秘密画轴2动作帧
            {
                { MirAction.Stoned, new Frame(0, 4, 0, 500) },
                { MirAction.Show, new Frame(32, 5, 0, 100) },
                { MirAction.Hide, new Frame(32, 5, 0, 100) },
                { MirAction.Standing, new Frame(32, 5, 0, 100) },
                { MirAction.Walking, new Frame(72, 6, 0, 100) },
                { MirAction.AttackRange1, new Frame(120, 9, 0, 100) },
                { MirAction.Struck, new Frame(192, 4, 0, 200) },
                { MirAction.Die, new Frame(224, 6, 0, 100) },
                { MirAction.Dead, new Frame(229, 1, 5, 100) },
                { MirAction.Revive, new Frame(224, 6, 0, 100) { Reverse = true } }
            };
            WizardScroll = new FrameSet           //秘密画轴3动作帧
            {
                { MirAction.Stoned, new Frame(0, 4, 0, 500) },
                { MirAction.Show, new Frame(32, 5, 0, 100) },
                { MirAction.Hide, new Frame(32, 5, 0, 100) },
                { MirAction.Standing, new Frame(32, 5, 0, 100) },
                { MirAction.Walking, new Frame(72, 6, 0, 100) },
                { MirAction.AttackRange1, new Frame(120, 9, 0, 100) },
                { MirAction.Struck, new Frame(192, 4, 0, 200) },
                { MirAction.Die, new Frame(224, 9, 0, 100) },
                { MirAction.Dead, new Frame(232, 1, 8, 1000) },
                { MirAction.Revive, new Frame(224, 9, 0, 100) { Reverse = true } }
            };
            AssassinScroll = new FrameSet           //秘密画轴4动作帧
            {
                { MirAction.Stoned, new Frame(0, 4, 0, 500) },
                { MirAction.Show, new Frame(32, 5, 0, 100) },
                { MirAction.Hide, new Frame(32, 5, 0, 100) },
                { MirAction.Standing, new Frame(32, 5, 0, 100) },
                { MirAction.Walking, new Frame(72, 6, 0, 100) },
                { MirAction.AttackRange1, new Frame(120, 9, 0, 100) },
                { MirAction.Struck, new Frame(192, 4, 0, 200) },
                { MirAction.Die, new Frame(224, 9, 0, 100) },
                { MirAction.Dead, new Frame(232, 1, 8, 1000) },
                { MirAction.Revive, new Frame(224, 9, 0, 100) { Reverse = true } }
            };
            WingedTigerLord = new FrameSet           //虎头鹰王动作帧
            {
                { MirAction.Standing, new Frame(0, 6, 0, 500) },
                { MirAction.Walking, new Frame(48, 10, 0, 100) },
                { MirAction.Attack1, new Frame(328, 8, 0, 100) },
                { MirAction.Attack2, new Frame(288, 5, 0, 100) },
                { MirAction.Attack3, new Frame(392, 5, 0, 150) },
                { MirAction.AttackRange1, new Frame(432, 8, 0, 150) },
                { MirAction.Struck, new Frame(192, 3, 0, 200) },
                { MirAction.Die, new Frame(216, 9, 0, 100) },
                { MirAction.Dead, new Frame(224, 1, 8, 1000) },
                { MirAction.Revive, new Frame(216, 9, 0, 100) { Reverse = true } }
            };
            FlameTiger = new FrameSet      //赤炎虎动作帧
            {
                { MirAction.Standing, new Frame(0, 4, 0, 500) },
                { MirAction.Walking, new Frame(32, 6, 0, 100) },
                { MirAction.Attack1, new Frame(80, 6, 0, 100) },
                { MirAction.SitDown, new Frame(272, 4, 0, 500) },
                { MirAction.AttackRange1, new Frame(224, 6, 0, 100) },
                { MirAction.Struck, new Frame(128, 2, 0, 200) },
                { MirAction.Die, new Frame(144, 10, 0, 100) },
                { MirAction.Dead, new Frame(153, 1, 9, 1000) },
                { MirAction.Revive, new Frame(144, 10, 0, 100) { Reverse = true } }
            };
            RedYimoogi = new FrameSet      //红金龙动作帧
            {
                { MirAction.Standing, new Frame(0, 4, 0, 500) },
                { MirAction.Walking, new Frame(32, 6, 0, 100) },
                { MirAction.Attack1, new Frame(80, 6, 0, 100) },
                { MirAction.Attack2, new Frame(224, 6, 0, 100) },
                { MirAction.Attack3, new Frame(224, 6, 0, 100) },
                { MirAction.AttackRange1, new Frame(224, 6, 0, 100) },
                { MirAction.Struck, new Frame(128, 2, 0, 200) },
                { MirAction.Die, new Frame(144, 10, 0, 100) },
                { MirAction.Dead, new Frame(153, 1, 9, 1000) },
                { MirAction.Revive, new Frame(144, 10, 0, 100) { Reverse = true } }
            };
            BlueSanta = new FrameSet      //蓝色圣诞老人动作帧
            {
                { MirAction.Standing, new Frame(0, 4, 0, 500) },
                { MirAction.Walking, new Frame(32, 8, 0, 100) },
                { MirAction.Attack1, new Frame(96, 6, 0, 100) },
                { MirAction.Struck, new Frame(144, 3, 0, 200) },
                { MirAction.Die, new Frame(168, 5, 0, 100) },
                { MirAction.Dead, new Frame(172, 1, 4, 1000) },
                { MirAction.Revive, new Frame(168, 5, 0, 100) { Reverse = true } }
            };
            OldSpittingSpider = new FrameSet      //远古吐痰蜘蛛动作帧
            {
                { MirAction.Standing, new Frame(0, 4, 0, 500) },
                { MirAction.Walking, new Frame(32, 8, 0, 500) },
                { MirAction.Attack1, new Frame(80, 6, 0, 80) },
                { MirAction.Struck, new Frame(128, 2, 0, 150) },
                { MirAction.Die, new Frame(144, 3, 1, 200) },
                { MirAction.Dead, new Frame(147, 1, 3, 1000) },
            };
            Catapult2 = new FrameSet      //攻城车动作帧
            {
                { MirAction.Standing, new Frame(0, 4, 0, 500) },
                { MirAction.Walking, new Frame(32, 6, 0, 100) },
                { MirAction.Attack1, new Frame(80, 6, 0, 80) },
            };
            GiantEgg = new FrameSet      //巨蛋动作帧
            {
                { MirAction.Standing, new Frame(0, 1, -1, 1000) },
                { MirAction.Attack1, new Frame(0, 1, -1, 1000) },
                { MirAction.Struck, new Frame(0, 4, -4, 200) },
                { MirAction.Die, new Frame(5, 7, -7, 150) },
                { MirAction.Dead, new Frame(11, 1, -1, 1000) },
                { MirAction.Revive, new Frame(5, 7, -7, 150) { Reverse = true } }
            };
            SnowTree = new FrameSet      //雪树动作帧
            {
                { MirAction.Standing, new Frame(0, 10, -10, 500) },
                { MirAction.Struck, new Frame(10, 2, -2, 200) },
                { MirAction.Die, new Frame(12, 10, -10, 100) },
                { MirAction.Dead, new Frame(21, 1, -1, 1000) },
                { MirAction.Revive, new Frame(12, 10, -10, 100) { Reverse = true } }
            };
            Snowman = new FrameSet      //雪人动作帧
            {
                { MirAction.Standing, new Frame(0, 2, 0, 500) },
                { MirAction.Struck, new Frame(16, 2, 0, 200) },
                { MirAction.Die, new Frame(32, 8, 0, 100) },
                { MirAction.Dead, new Frame(39, 1, 7, 1000) },
                { MirAction.Revive, new Frame(32, 8,0, 100) { Reverse = true } }
            };
            SnowPile = new FrameSet      //雪堆动作帧
            {
                { MirAction.Standing, new Frame(0, 3, -3, 1000) },
                { MirAction.Struck, new Frame(3, 3, -3, 200) },
                { MirAction.Die, new Frame(3, 7, -7, 150) },
                { MirAction.Dead, new Frame(9, 1, -1, 1000) },
                { MirAction.Revive, new Frame(3, 7, -7, 150) { Reverse = true } }
            };
            TailedLion = new FrameSet      //赤狼动作帧
            {
                { MirAction.Standing, new Frame(0, 4, 0, 500) },
                { MirAction.Walking, new Frame(32, 8, 0, 100) },
                { MirAction.Attack1, new Frame(120, 6, 0, 100) },
                { MirAction.Struck, new Frame(96, 3, 0, 200) },
                { MirAction.Die, new Frame(168, 6, 0, 100) },
                { MirAction.Dead, new Frame(173, 1, 5, 1000) },
                { MirAction.Revive, new Frame(168, 6, 0, 100) { Reverse = true } }
            };
            MudPile = new FrameSet      //泥浆动作帧
            {
                { MirAction.Standing, new Frame(0, 3, -3, 1000) },
                { MirAction.Struck, new Frame(3, 3, -3, 200) },
                { MirAction.Die, new Frame(3, 7, -7, 150) },
                { MirAction.Dead, new Frame(9, 1, -1, 1000) },
                { MirAction.Revive, new Frame(3, 7, -7, 150) { Reverse = true } }
            };
            HalloweenScythe = new FrameSet      //万圣节死神动作帧
            {
                { MirAction.Standing, new Frame(0, 4, 0, 500) },
                { MirAction.Walking, new Frame(32, 6, 0, 100) },
                { MirAction.Attack1, new Frame(80, 6, 0, 100) },
                { MirAction.Struck, new Frame(128, 2, 0, 200) },
                { MirAction.Die, new Frame(144, 10, 0, 100) },
                { MirAction.Dead, new Frame(153, 1, 9, 1000) },
                { MirAction.Revive, new Frame(144, 10, 0, 100) { Reverse = true } }
            };
            GingerBreadman = new FrameSet      //生姜面包人动作帧
            {
                { MirAction.Standing, new Frame(0, 4, 0, 500) },
                { MirAction.Walking, new Frame(32, 6, 0, 100) },
                { MirAction.Attack1, new Frame(80, 6, 0, 100) },
                { MirAction.Struck, new Frame(128, 3, 0, 200) },
                { MirAction.Die, new Frame(152, 6, 0, 100) },
                { MirAction.Dead, new Frame(157, 1, 5, 1000) },
                { MirAction.Revive, new Frame(152, 6, 0, 100) { Reverse = true } }
            };
            DarkBrownWolf = new FrameSet      //黑棕狼动作帧
            {
                { MirAction.Standing, new Frame(0, 4, 0, 500) },
                { MirAction.Walking, new Frame(32, 6, 0, 100) },
                { MirAction.Attack1, new Frame(80, 6, 0, 100) },
                { MirAction.Struck, new Frame(128, 2, 0, 200) },
                { MirAction.Die, new Frame(144, 10, 0, 100) },
                { MirAction.Dead, new Frame(153, 1, 9, 1000) },
                { MirAction.Skeleton, new Frame(224, 1, 0, 1000) },
                { MirAction.Revive, new Frame(144, 10, 0, 100) { Reverse = true } }
            };
            DarkDustPile = new FrameSet      //黑暗之堆动作帧
            {
                { MirAction.Standing, new Frame(0, 3, -3, 1000) },
                { MirAction.Struck, new Frame(3, 3, -3, 200) },
                { MirAction.Die, new Frame(3, 7, -7, 150) },
                { MirAction.Dead, new Frame(9, 1, -1, 1000) },
                { MirAction.Revive, new Frame(3, 7, -7, 150) { Reverse = true } }
            };
            HighAssassin = new FrameSet      //高级刺客动作帧
            {
                { MirAction.Standing, new Frame(0, 4, 0, 500) },
                { MirAction.Walking, new Frame(32, 6, 0, 100) },
                { MirAction.Attack1, new Frame(80, 6, 0, 100) },
                { MirAction.Struck, new Frame(128, 3, 0, 200) },
                { MirAction.Die, new Frame(152, 4, 0, 100) },
                { MirAction.Dead, new Frame(155, 1, 3, 1000) },
                { MirAction.Revive, new Frame(152, 4, 0, 100) { Reverse = true } }
            };
            ChristmasTree = new FrameSet      //圣诞树动作帧
            {
                { MirAction.Standing, new Frame(0, 10, -10, 500) },
                { MirAction.Struck, new Frame(10, 2, -2, 200) },
                { MirAction.Die, new Frame(12, 10, -10, 100) },
                { MirAction.Dead, new Frame(21, 1, -1, 1000) },
                { MirAction.Revive, new Frame(12, 10, -10, 100) { Reverse = true } }
            };
            Bush = new FrameSet      //青草动作帧
            {
                { MirAction.Standing, new Frame(0, 4, -4, 500) },
                { MirAction.Struck, new Frame(4, 4, -4, 200) },
                { MirAction.Die, new Frame(8, 4, -4, 100) },
                { MirAction.Dead, new Frame(15, 1, -1, 1000) },
            };
            ArcherGuard2 = new FrameSet      //弓箭护卫2动作帧
            {
                { MirAction.Standing, new Frame(0, 4, 0, 500) },
                { MirAction.Walking, new Frame(32, 6, 3, 100) },
                { MirAction.AttackRange1, new Frame(104, 10, 3, 100) },
                { MirAction.Struck, new Frame(208, 3, 0, 100) },
                { MirAction.Die, new Frame(232, 4, 0, 100) },
                { MirAction.Dead, new Frame(235, 1, 3, 1000) },
            };
            Shinsu1 = new FrameSet      //神兽1动作帧
            {
                { MirAction.Standing, new Frame(0, 4, 0, 500) },
                { MirAction.Walking, new Frame(32, 6, 0, 100) },
                { MirAction.Attack1, new Frame(80, 6, 0, 100) },
                { MirAction.Struck, new Frame(128, 2, 0, 200) },
                { MirAction.Die, new Frame(144, 10, 0, 100) },
                { MirAction.Dead, new Frame(153, 1, 9, 1000) },
                { MirAction.Revive, new Frame(144, 10, 0, 100) },
            };
            SiegeRepairman = new FrameSet      //围攻修理工动作帧
            {
                { MirAction.Standing, new Frame(0, 4, 0, 500) },
                { MirAction.Struck, new Frame(32, 6, 0, 100) },
                { MirAction.Attack1, new Frame(80, 6, 0, 100) }, 
            };
            BattleStandard = new FrameSet      //战旗动作帧
            {
                { MirAction.Standing, new Frame(0, 8, -8, 500) },
                { MirAction.Struck, new Frame(8, 3, -3, 200) },
                { MirAction.Die, new Frame(11, 8, -8, 100) },
                { MirAction.Dead, new Frame(17, 1, -1, 1000) },
            };
            LionRiderMale = new FrameSet      //雄狮骑士动作帧
            {
                { MirAction.Standing, new Frame(0, 4, 0, 500) },
                { MirAction.Walking, new Frame(32, 6, 0, 100) },
                { MirAction.Attack1, new Frame(80, 6, 0, 100) },
            };
            LionRiderFemale = new FrameSet      //雌狮骑士动作帧
            {
                { MirAction.Standing, new Frame(0, 4, 0, 500) },
                { MirAction.Walking, new Frame(32, 6, 0, 100) },
                { MirAction.Attack1, new Frame(80, 6, 0, 100) },
            };
            NamelessGhost = new FrameSet      //无名幽灵动作帧
            {
                { MirAction.Standing, new Frame(0, 4, 0, 500) },
                { MirAction.Walking, new Frame(32, 6, 0, 200) },
                { MirAction.Attack1, new Frame(80, 6, 0, 100) },
                { MirAction.Attack2, new Frame(208, 8, 0, 100) },
                { MirAction.Attack3, new Frame(272, 7, 0, 100) },
                { MirAction.Struck, new Frame(128, 2, 0, 200) },
                { MirAction.Die, new Frame(144, 8, 0, 100) },
                { MirAction.Dead, new Frame(151, 1, 7, 1000) },
                { MirAction.Revive, new Frame(144, 8, 0, 100) },
            };
            ChaosGhost = new FrameSet      //混沌幽灵动作帧
            {
                { MirAction.Standing, new Frame(0, 4, 0, 500) },
                { MirAction.Walking, new Frame(32, 6, 0, 200) },
                { MirAction.Attack1, new Frame(80, 6, 0, 100) },
                { MirAction.Attack2, new Frame(208, 8, 0, 100) },
                { MirAction.Attack3, new Frame(272, 7, 0, 100) },
                { MirAction.Struck, new Frame(128, 2, 0, 200) },
                { MirAction.Die, new Frame(144, 8, 0, 100) },
                { MirAction.Dead, new Frame(151, 1, 7, 1000) },
                { MirAction.Revive, new Frame(144, 8, 0, 100) },
            };
            FrostYeti = new FrameSet      //冰霜雪人动作帧
            {
                { MirAction.Standing, new Frame(0, 4, 0, 500) },
                { MirAction.Walking, new Frame(32, 6, 0, 100) },
                { MirAction.Attack1, new Frame(80, 6, 0, 100) },
                { MirAction.Struck, new Frame(128, 2, 0, 200) },
                { MirAction.Die, new Frame(144, 4, 0, 100) },
                { MirAction.Dead, new Frame(147, 1, 3, 1000) },
                { MirAction.Revive, new Frame(144, 4, 0, 100) },
            };
            IceGuard = new FrameSet      //冰之守卫动作帧
            {
                { MirAction.Standing, new Frame(0, 4, 0, 500) },
                { MirAction.Walking, new Frame(32, 6, 0, 200) },
                { MirAction.Attack1, new Frame(80, 6, 0, 100) },
                { MirAction.Attack2, new Frame(208, 6, 0, 100) },
                { MirAction.Struck, new Frame(128, 2, 0, 200) },
                { MirAction.Die, new Frame(144, 8, 0, 100) },
                { MirAction.Dead, new Frame(151, 1, 7, 1000) },
                { MirAction.Revive, new Frame(144, 8, 0, 100) },
            };
            WaterGuard = new FrameSet      //水之守卫动作帧
            {
                { MirAction.Standing, new Frame(0, 4, 0, 500) },
                { MirAction.Walking, new Frame(32, 6, 0, 200) },
                { MirAction.Attack1, new Frame(80, 6, 0, 100) },
                { MirAction.Attack2, new Frame(208, 7, 0, 100) },
                { MirAction.Struck, new Frame(128, 2, 0, 200) },
                { MirAction.Die, new Frame(144, 8, 0, 100) },
                { MirAction.Dead, new Frame(151, 1, 7, 1000) },
                { MirAction.Revive, new Frame(144, 8, 0, 100) },
            };
            ElementGuard = new FrameSet      //元素守卫动作帧
            {
                { MirAction.Standing, new Frame(0, 4, 0, 500) },
                { MirAction.Walking, new Frame(32, 6, 0, 200) },
                { MirAction.Attack1, new Frame(80, 6, 0, 100) },
                { MirAction.Attack2, new Frame(208, 6, 0, 100) },
                { MirAction.Struck, new Frame(128, 2, 0, 200) },
                { MirAction.Die, new Frame(144, 8, 0, 100) },
                { MirAction.Dead, new Frame(151, 1, 7, 1000) },
                { MirAction.Revive, new Frame(144, 8, 0, 100) },
            };
            DemonGuard = new FrameSet      //元素守卫动作帧
            {
                { MirAction.Standing, new Frame(0, 4, 0, 500) },
                { MirAction.Walking, new Frame(32, 6, 0, 200) },
                { MirAction.Attack1, new Frame(80, 4, 0, 100) },
                { MirAction.Attack2, new Frame(192, 6, 0, 100) },
                { MirAction.Struck, new Frame(112, 2, 0, 200) },
                { MirAction.Die, new Frame(128, 8, 0, 100) },
                { MirAction.Dead, new Frame(135, 1, 7, 1000) },
                { MirAction.Show, new Frame(240, 6, 0, 200) },
                { MirAction.Stoned, new Frame(240, 1, 5, 100) },
                { MirAction.Revive, new Frame(128, 8, 0, 100) },
            };
            PoisonHugger = new FrameSet      //人面蜘蛛动作帧
            {
                { MirAction.Standing, new Frame(0, 4, 0, 500) },
                { MirAction.Walking, new Frame(32, 6, 0, 200) },
                { MirAction.Attack1, new Frame(80, 6, 0, 100) },
                { MirAction.Struck, new Frame(128, 2, 0, 200) },
                { MirAction.Die, new Frame(144, 8, 0, 100) },
                { MirAction.Dead, new Frame(151, 1, 7, 1000) },
                { MirAction.Revive, new Frame(144, 8, 0, 100) },
            };
            MutatedHugger = new FrameSet      //鬼面蜘蛛动作帧
            {
                { MirAction.Standing, new Frame(0, 1, 5, 1000) },
                { MirAction.Walking, new Frame(0, 6, 0, 100) },
                { MirAction.Struck, new Frame(0, 1, 5, 200) },
                { MirAction.Die, new Frame(48, 10, 0, 150) },
                { MirAction.Dead, new Frame(57, 1, 9, 1000) },
                { MirAction.Revive, new Frame(48, 10, 0, 150) },
            };
            Snake10 = new FrameSet      //金螭动作帧
            {
                { MirAction.Standing, new Frame(0, 4, 0, 500) },
                { MirAction.Walking, new Frame(32, 6, 0, 100) },
                { MirAction.Attack1, new Frame(80, 6, 0, 100) },
                { MirAction.Attack2, new Frame(224, 6, 0, 100) },
                { MirAction.Attack3, new Frame(224, 6, 0, 100) },
                { MirAction.AttackRange1, new Frame(224, 6, 0, 100) },
                { MirAction.Struck, new Frame(128, 2, 0, 200) },
                { MirAction.Die, new Frame(144, 10, 0, 100) },
                { MirAction.Dead, new Frame(153, 1, 9, 1000) },
                { MirAction.Revive, new Frame(144, 10, 0, 100) { Reverse = true } }
            };
            Snake11 = new FrameSet      //绿螭动作帧
            {
                { MirAction.Standing, new Frame(0, 4, 0, 500) },
                { MirAction.Walking, new Frame(32, 6, 0, 100) },
                { MirAction.Attack1, new Frame(80, 6, 0, 100) },
                { MirAction.Attack2, new Frame(224, 6, 0, 100) },
                { MirAction.Attack3, new Frame(224, 6, 0, 100) },
                { MirAction.AttackRange1, new Frame(224, 6, 0, 100) },
                { MirAction.Struck, new Frame(128, 2, 0, 200) },
                { MirAction.Die, new Frame(144, 10, 0, 100) },
                { MirAction.Dead, new Frame(153, 1, 9, 1000) },
                { MirAction.Revive, new Frame(144, 10, 0, 100) { Reverse = true } }
            };
            Snake12 = new FrameSet      //红螭动作帧
            {
                { MirAction.Standing, new Frame(0, 4, 0, 500) },
                { MirAction.Walking, new Frame(32, 6, 0, 100) },
                { MirAction.Attack1, new Frame(80, 6, 0, 100) },
                { MirAction.Attack2, new Frame(224, 6, 0, 100) },
                { MirAction.Attack3, new Frame(224, 6, 0, 100) },
                { MirAction.AttackRange1, new Frame(224, 6, 0, 100) },
                { MirAction.Struck, new Frame(128, 2, 0, 200) },
                { MirAction.Die, new Frame(144, 10, 0, 100) },
                { MirAction.Dead, new Frame(153, 1, 9, 1000) },
                { MirAction.Revive, new Frame(144, 10, 0, 100) { Reverse = true } }
            };
            Snake13 = new FrameSet      //黄螭动作帧
            {
                { MirAction.Standing, new Frame(0, 4, 0, 500) },
                { MirAction.Walking, new Frame(32, 6, 0, 100) },
                { MirAction.Attack1, new Frame(80, 6, 0, 100) },
                { MirAction.Attack2, new Frame(224, 6, 0, 100) },
                { MirAction.Attack3, new Frame(224, 6, 0, 100) },
                { MirAction.AttackRange1, new Frame(224, 6, 0, 100) },
                { MirAction.Struck, new Frame(128, 2, 0, 200) },
                { MirAction.Die, new Frame(144, 10, 0, 100) },
                { MirAction.Dead, new Frame(153, 1, 9, 1000) },
                { MirAction.Revive, new Frame(144, 10, 0, 100) { Reverse = true } }
            };
            Snake15 = new FrameSet      //褐螭动作帧
            {
                { MirAction.Standing, new Frame(0, 4, 0, 500) },
                { MirAction.Walking, new Frame(32, 6, 0, 100) },
                { MirAction.Attack1, new Frame(80, 6, 0, 100) },
                { MirAction.Attack2, new Frame(224, 6, 0, 100) },
                { MirAction.Attack3, new Frame(224, 6, 0, 100) },
                { MirAction.AttackRange1, new Frame(224, 6, 0, 100) },
                { MirAction.Struck, new Frame(128, 2, 0, 200) },
                { MirAction.Die, new Frame(144, 10, 0, 100) },
                { MirAction.Dead, new Frame(153, 1, 9, 1000) },
                { MirAction.Revive, new Frame(144, 10, 0, 100) { Reverse = true } }
            };
            Snake16 = new FrameSet      //紫螭动作帧
            {
                { MirAction.Standing, new Frame(0, 4, 0, 500) },
                { MirAction.Walking, new Frame(32, 6, 0, 100) },
                { MirAction.Attack1, new Frame(80, 6, 0, 100) },
                { MirAction.Attack2, new Frame(224, 6, 0, 100) },
                { MirAction.Attack3, new Frame(224, 6, 0, 100) },
                { MirAction.AttackRange1, new Frame(224, 6, 0, 100) },
                { MirAction.Struck, new Frame(128, 2, 0, 200) },
                { MirAction.Die, new Frame(144, 10, 0, 100) },
                { MirAction.Dead, new Frame(153, 1, 9, 1000) },
                { MirAction.Revive, new Frame(144, 10, 0, 100) { Reverse = true } }
            };
            Snake17 = new FrameSet      //灰螭动作帧
            {
                { MirAction.Standing, new Frame(0, 4, 0, 500) },
                { MirAction.Walking, new Frame(32, 6, 0, 100) },
                { MirAction.Attack1, new Frame(80, 6, 0, 100) },
                { MirAction.Attack2, new Frame(224, 6, 0, 100) },
                { MirAction.Attack3, new Frame(224, 6, 0, 100) },
                { MirAction.AttackRange1, new Frame(224, 6, 0, 100) },
                { MirAction.Struck, new Frame(128, 2, 0, 200) },
                { MirAction.Die, new Frame(144, 10, 0, 100) },
                { MirAction.Dead, new Frame(153, 1, 9, 1000) },
                { MirAction.Revive, new Frame(144, 10, 0, 100) { Reverse = true } }
            };
            Bunny = new FrameSet      //兔子动作帧
            {
                { MirAction.Standing, new Frame(0, 4, 0, 500) },
                { MirAction.Walking, new Frame(32, 5, 0, 200) },
                { MirAction.Attack1, new Frame(72, 7, 0, 100) },
                { MirAction.Struck, new Frame(128, 2, 0, 200) },
                { MirAction.Die, new Frame(144, 6, 0, 100) },
                { MirAction.Dead, new Frame(149, 1, 4, 1000) },
                { MirAction.Revive, new Frame(144, 6, 0, 100) { Reverse = true } }
            };
            TucsonEgg = new FrameSet      //异秘蛋动作帧
            {
                { MirAction.Standing, new Frame(0, 1, -1, 500) },
                { MirAction.Struck, new Frame(1, 1, -1, 200) },
                { MirAction.Die, new Frame(1, 10, -10, 100) },
                { MirAction.Dead, new Frame(11, 1, -1, 1000) },
                { MirAction.Revive, new Frame(1, 10, -10, 100) { Reverse = true } }
            };
            RedOrb = new FrameSet      //红球动作帧
            {
                { MirAction.Standing, new Frame(0, 4, 0, 500) },
                { MirAction.Walking, new Frame(32, 5, 0, 200) },
                { MirAction.Attack1, new Frame(80, 5, 0, 100) },
                { MirAction.Attack2, new Frame(120, 5, 0, 100) },
                { MirAction.Struck, new Frame(160, 2, 0, 200) },
                { MirAction.Die, new Frame(176, 5, 0, 100) },
                { MirAction.Dead, new Frame(180, 1, 4, 1000) },
                { MirAction.Revive, new Frame(176, 5, 0, 100) { Reverse = true } }
            };
            BlueOrb = new FrameSet      //蓝球动作帧
            {
                { MirAction.Standing, new Frame(0, 4, 0, 500) },
                { MirAction.Walking, new Frame(32, 5, 0, 200) },
                { MirAction.Attack1, new Frame(80, 5, 0, 100) },
                { MirAction.Attack2, new Frame(120, 5, 0, 100) },
                { MirAction.Struck, new Frame(160, 2, 0, 200) },
                { MirAction.Die, new Frame(176, 5, 0, 100) },
                { MirAction.Dead, new Frame(180, 1, 4, 1000) },
                { MirAction.Revive, new Frame(176, 5, 0, 100) { Reverse = true } }
            };
            YellowOrb = new FrameSet      //黄球动作帧
            {
                { MirAction.Standing, new Frame(0, 4, 0, 500) },
                { MirAction.Walking, new Frame(32, 5, 0, 200) },
                { MirAction.Attack1, new Frame(80, 5, 0, 100) },
                { MirAction.Attack2, new Frame(120, 5, 0, 100) },
                { MirAction.Struck, new Frame(160, 2, 0, 200) },
                { MirAction.Die, new Frame(176, 5, 0, 100) },
                { MirAction.Dead, new Frame(180, 1, 4, 1000) },
                { MirAction.Revive, new Frame(176, 5, 0, 100) { Reverse = true } }
            };
            GreenOrb = new FrameSet      //绿球动作帧
            {
                { MirAction.Standing, new Frame(0, 4, 0, 500) },
                { MirAction.Walking, new Frame(32, 5, 0, 200) },
                { MirAction.Attack1, new Frame(80, 5, 0, 100) },
                { MirAction.Attack2, new Frame(120, 5, 0, 100) },
                { MirAction.Struck, new Frame(160, 2, 0, 200) },
                { MirAction.Die, new Frame(176, 5, 0, 100) },
                { MirAction.Dead, new Frame(180, 1, 4, 1000) },
                { MirAction.Revive, new Frame(176, 5, 0, 100) { Reverse = true } }
            };
            WhiteOrb = new FrameSet      //白球动作帧
            {
                { MirAction.Standing, new Frame(0, 4, 0, 500) },
                { MirAction.Walking, new Frame(32, 5, 0, 200) },
                { MirAction.Attack1, new Frame(80, 5, 0, 100) },
                { MirAction.Attack2, new Frame(120, 5, 0, 100) },
                { MirAction.Struck, new Frame(160, 2, 0, 200) },
                { MirAction.Die, new Frame(176, 5, 0, 100) },
                { MirAction.Dead, new Frame(180, 1, 4, 1000) },
                { MirAction.Revive, new Frame(176, 5, 0, 100) { Reverse = true } }
            };
            FatalLotus = new FrameSet      //致命莲花动作帧
            {
                { MirAction.Standing, new Frame(0, 6, 0, 500) },
                { MirAction.Walking, new Frame(48, 6, 0, 200) },
                { MirAction.Attack1, new Frame(96, 8, 0, 100) },
                { MirAction.Attack2, new Frame(160, 8, 0, 100) },
                { MirAction.Struck, new Frame(224, 2, 0, 200) },
                { MirAction.Die, new Frame(240, 6, 0, 100) },
                { MirAction.Dead, new Frame(245, 1, 5, 1000) },
                { MirAction.Revive, new Frame(224, 6, 0, 100) { Reverse = true } }
            };
            AntCommander = new FrameSet      //蚂蚁司令动作帧
            {
                { MirAction.Standing, new Frame(0, 6, 0, 500) },
                { MirAction.Walking, new Frame(48, 8, 0, 200) },
                { MirAction.Attack1, new Frame(112, 8, 0, 100) },
                { MirAction.AttackRange1, new Frame(176, 8, 0, 100) },
                { MirAction.Attack2, new Frame(240, 8, 0, 100) },
                { MirAction.Struck, new Frame(304, 2, 0, 200) },
                { MirAction.Die, new Frame(320, 6, 0, 100) },
                { MirAction.Dead, new Frame(393, 1, 5, 1000) },
                { MirAction.Revive, new Frame(320, 6, 0, 100) { Reverse = true } }
            };
            CargoBoxwithlogo = new FrameSet      //带标志的货箱动作帧
            {
                { MirAction.Standing, new Frame(0, 1, 0, 500) },
                { MirAction.Struck, new Frame(8, 2, 0, 200) },
                { MirAction.Die, new Frame(24, 6, 0, 100) },
                { MirAction.Dead, new Frame(29, 1, 0, 1000) },
                { MirAction.Revive, new Frame(24, 6, 0, 100) { Reverse = true } }
            };
            Doe = new FrameSet      //梅花鹿动作帧
            {
                { MirAction.Standing, new Frame(0, 6, 0, 500) },
                { MirAction.Walking, new Frame(48, 6, 0, 200) },
                { MirAction.Attack1, new Frame(96, 6, 0, 100) },
                { MirAction.Struck, new Frame(144, 2, 0, 200) },
                { MirAction.Die, new Frame(160, 6, 0, 100) },
                { MirAction.Dead, new Frame(165, 1, 5, 1000) },
                { MirAction.Revive, new Frame(160, 6, 0, 100) { Reverse = true } }
            };
            AngryReindeer = new FrameSet      //愤怒的驯鹿动作帧
            {
                { MirAction.Standing, new Frame(0, 7, 0, 500) },
                { MirAction.Walking, new Frame(56, 8, 0, 200) },
                { MirAction.Attack1, new Frame(120, 8, 0, 100) },
                { MirAction.Attack2, new Frame(184, 9, 0, 100) },
                { MirAction.Attack3, new Frame(256, 7, 0, 100) },
                { MirAction.Struck, new Frame(312, 2, 0, 200) },
                { MirAction.Die, new Frame(328, 8, 0, 100) },
                { MirAction.Dead, new Frame(335, 1, 7, 1000) },
                { MirAction.Revive, new Frame(328, 8, 0, 100) { Reverse = true } }
            };
            Ram1 = new FrameSet      //公牛动作帧
            {
                { MirAction.Standing, new Frame(0, 7, 0, 500) },
                { MirAction.Walking, new Frame(56, 8, 0, 200) },
                { MirAction.Attack1, new Frame(120, 8, 0, 100) },
                { MirAction.Attack2, new Frame(184, 9, 0, 100) },
                { MirAction.Struck, new Frame(256, 2, 0, 200) },
                { MirAction.Die, new Frame(272, 9, 0, 100) },
                { MirAction.Dead, new Frame(280, 1, 8, 1000) },
                { MirAction.Revive, new Frame(272, 9, 0, 100) { Reverse = true } }
            };
            Ram2 = new FrameSet      //母牛动作帧
            {
                { MirAction.Standing, new Frame(0, 7, 0, 500) },
                { MirAction.Walking, new Frame(56, 8, 0, 200) },
                { MirAction.Attack1, new Frame(120, 8, 0, 100) },
                { MirAction.Attack2, new Frame(184, 9, 0, 100) },
                { MirAction.Attack3, new Frame(256, 9, 0, 100) },
                { MirAction.Struck, new Frame(328, 2, 0, 200) },
                { MirAction.Die, new Frame(344, 9, 0, 100) },
                { MirAction.Dead, new Frame(352, 1, 8, 1000) },
                { MirAction.Revive, new Frame(344, 9, 0, 100) { Reverse = true } }
            };
            Kite = new FrameSet      //风筝动作帧
            {
                { MirAction.Standing, new Frame(0, 4, 0, 500) },
                { MirAction.Walking, new Frame(32, 5, 0, 200) },
                { MirAction.Attack1, new Frame(72, 5, 0, 100) },
                { MirAction.Die, new Frame(194, 10, 0, 100) },
                { MirAction.Dead, new Frame(203, 1, 9, 1000) },
                { MirAction.Revive, new Frame(194, 10, 0, 100) { Reverse = true } }
            };
            KingKong = new FrameSet      //金刚动作帧
            {
                { MirAction.Stoned, new Frame(120, 6, 0, 100) },
                { MirAction.Standing, new Frame(0, 6, 0, 500) },
                { MirAction.Walking, new Frame(48, 9, 0, 200) },
                { MirAction.Attack1, new Frame(168, 8, 0, 100) },
                { MirAction.Struck, new Frame(232, 3, 0, 200) },
                { MirAction.Die, new Frame(256, 9, 0, 100) },
                { MirAction.Dead, new Frame(203, 1, 8, 1000) },
                { MirAction.Revive, new Frame(256, 9, 0, 100) { Reverse = true } }
            };
            #region DragonStatue
            //DragonStatue 1
            DragonStatue = new List<FrameSet> { (frame = new FrameSet()) };
            frame.Add(MirAction.Standing, new Frame(300, 1, -1, 1000));
            frame.Add(MirAction.AttackRange1, new Frame(300, 1, -1, 120));
            frame.Add(MirAction.Struck, new Frame(300, 1, -1, 200));

            //DragonStatue 2
            DragonStatue.Add(frame = new FrameSet());
            frame.Add(MirAction.Standing, new Frame(301, 1, -1, 1000));
            frame.Add(MirAction.AttackRange1, new Frame(301, 1, -1, 120));
            frame.Add(MirAction.Struck, new Frame(301, 1, -1, 200));

            //DragonStatue 3
            DragonStatue.Add(frame = new FrameSet());
            frame.Add(MirAction.Standing, new Frame(302, 1, -1, 1000));
            frame.Add(MirAction.AttackRange1, new Frame(302, 1, -1, 120));
            frame.Add(MirAction.Struck, new Frame(302, 1, -1, 200));

            //DragonStatue 4
            DragonStatue.Add(frame = new FrameSet());
            frame.Add(MirAction.Standing, new Frame(320, 1, -1, 1000));
            frame.Add(MirAction.AttackRange1, new Frame(320, 1, -1, 120));
            frame.Add(MirAction.Struck, new Frame(320, 1, -1, 200));

            //DragonStatue 5
            DragonStatue.Add(frame = new FrameSet());
            frame.Add(MirAction.Standing, new Frame(321, 1, -1, 1000));
            frame.Add(MirAction.AttackRange1, new Frame(321, 1, -1, 120));
            frame.Add(MirAction.Struck, new Frame(321, 1, -1, 200));

            //DragonStatue 6
            DragonStatue.Add(frame = new FrameSet());
            frame.Add(MirAction.Standing, new Frame(322, 1, -1, 1000));
            frame.Add(MirAction.AttackRange1, new Frame(322, 1, -1, 120));
            frame.Add(MirAction.Struck, new Frame(322, 1, -1, 200));
            #endregion

            #region GreatFoxSpirit
            //GreatFoxSpirit level 0
            GreatFoxSpirit = new List<FrameSet> { (frame = new FrameSet()) };
            frame.Add(MirAction.Standing, new Frame(0, 20, -20, 100));
            frame.Add(MirAction.Attack1, new Frame(22, 8, -8, 120));
            frame.Add(MirAction.Struck, new Frame(20, 2, -2, 200));
            frame.Add(MirAction.Die, new Frame(300, 18, -18, 120));
            frame.Add(MirAction.Dead, new Frame(317, 1, -1, 1000));
            frame.Add(MirAction.Revive, new Frame(300, 18, -18, 150) { Reverse = true });

            //GreatFoxSpirit level 1
            GreatFoxSpirit.Add(frame = new FrameSet());
            frame.Add(MirAction.Standing, new Frame(60, 20, -20, 100));
            frame.Add(MirAction.Attack1, new Frame(82, 8, -8, 120));
            frame.Add(MirAction.Struck, new Frame(80, 2, -2, 200));
            frame.Add(MirAction.Die, new Frame(300, 18, -18, 120));
            frame.Add(MirAction.Dead, new Frame(317, 1, -1, 1000));
            frame.Add(MirAction.Revive, new Frame(300, 18, -18, 150) { Reverse = true });

            //GreatFoxSpirit level 2
            GreatFoxSpirit.Add(frame = new FrameSet());
            frame.Add(MirAction.Standing, new Frame(120, 20, -20, 100));
            frame.Add(MirAction.Attack1, new Frame(142, 8, -8, 120));
            frame.Add(MirAction.Struck, new Frame(140, 2, -2, 200));
            frame.Add(MirAction.Die, new Frame(300, 18, -18, 120));
            frame.Add(MirAction.Dead, new Frame(317, 1, -1, 1000));
            frame.Add(MirAction.Revive, new Frame(300, 18, -18, 150) { Reverse = true });

            //GreatFoxSpirit level 3
            GreatFoxSpirit.Add(frame = new FrameSet());
            frame.Add(MirAction.Standing, new Frame(180, 20, -20, 100));
            frame.Add(MirAction.Attack1, new Frame(202, 8, -8, 120));
            frame.Add(MirAction.Struck, new Frame(200, 2, -2, 200));
            frame.Add(MirAction.Die, new Frame(300, 18, -18, 120));
            frame.Add(MirAction.Dead, new Frame(317, 1, -1, 1000));
            frame.Add(MirAction.Revive, new Frame(300, 18, -18, 150) { Reverse = true });

            //GreatFoxSpirit level 4
            GreatFoxSpirit.Add(frame = new FrameSet());
            frame.Add(MirAction.Standing, new Frame(240, 20, -20, 100));
            frame.Add(MirAction.Attack1, new Frame(262, 8, -8, 120));
            frame.Add(MirAction.Struck, new Frame(260, 2, -2, 200));
            frame.Add(MirAction.Die, new Frame(300, 18, -18, 120));
            frame.Add(MirAction.Dead, new Frame(317, 1, -1, 1000));
            frame.Add(MirAction.Revive, new Frame(300, 18, -18, 150) { Reverse = true });
            #endregion

            #region HellBombs
            //HellBomb1
            HellBomb = new List<FrameSet> { (frame = new FrameSet()) };
            frame.Add(MirAction.Standing, new Frame(52, 9, -9, 100) { Blend = true });
            frame.Add(MirAction.Attack1, new Frame(999, 1, -1, 120) { Blend = true });
            frame.Add(MirAction.Struck, new Frame(52, 9, -9, 100) { Blend = true });

            //HellBomb2
            HellBomb.Add(frame = new FrameSet());
            frame.Add(MirAction.Standing, new Frame(70, 9, -9, 100) { Blend = true });
            frame.Add(MirAction.Attack1, new Frame(999, 1, -1, 120) { Blend = true });
            frame.Add(MirAction.Struck, new Frame(70, 9, -9, 100) { Blend = true });

            //HellBomb3
            HellBomb.Add(frame = new FrameSet());
            frame.Add(MirAction.Standing, new Frame(88, 9, -9, 100) { Blend = true });
            frame.Add(MirAction.Attack1, new Frame(999, 1, -1, 120) { Blend = true });
            frame.Add(MirAction.Struck, new Frame(88, 9, -9, 100) { Blend = true });
            #endregion

            #region CaveStatues
            //CaveStatue1
            CaveStatue = new List<FrameSet> { (frame = new FrameSet()) };
            frame.Add(MirAction.Standing, new Frame(0, 1, -1, 100) { Blend = false });
            frame.Add(MirAction.Struck, new Frame(0, 1, -1, 100) { Blend = false });
            frame.Add(MirAction.Die, new Frame(2, 8, -8, 100) { Blend = false });
            frame.Add(MirAction.Dead, new Frame(9, 1, -1, 100) { Blend = false });

            //CaveStatue2
            CaveStatue.Add(frame = new FrameSet());
            frame.Add(MirAction.Standing, new Frame(18, 1, -1, 100) { Blend = false });
            frame.Add(MirAction.Struck, new Frame(18, 1, -1, 100) { Blend = false });
            frame.Add(MirAction.Die, new Frame(20, 8, -8, 100) { Blend = false });
            frame.Add(MirAction.Dead, new Frame(27, 1, -1, 100) { Blend = false });
            #endregion

            #region Player
            //Common
            Player.Add(MirAction.Standing, new Frame(0, 4, 0, 500, 0, 8, 0, 250));
            Player.Add(MirAction.Walking, new Frame(32, 6, 0, 100, 64, 6, 0, 100));
            Player.Add(MirAction.Running, new Frame(80, 6, 0, 100, 112, 6, 0, 100));
            Player.Add(MirAction.Stance, new Frame(128, 1, 0, 1000, 160, 1, 0, 1000));
            Player.Add(MirAction.Stance2, new Frame(300, 1, 5, 1000, 332, 1, 5, 1000));
            Player.Add(MirAction.Attack1, new Frame(136, 6, 0, 100, 168, 6, 0, 100));
            Player.Add(MirAction.Attack2, new Frame(184, 6, 0, 100, 216, 6, 0, 100));
            Player.Add(MirAction.Attack3, new Frame(232, 8, 0, 100, 264, 8, 0, 100));
            Player.Add(MirAction.Attack4, new Frame(416, 6, 0, 100, 448, 6, 0, 100));
            Player.Add(MirAction.Spell, new Frame(296, 6, 0, 100, 328, 6, 0, 100));
            Player.Add(MirAction.Harvest, new Frame(344, 2, 0, 300, 376, 2, 0, 300));
            Player.Add(MirAction.Struck, new Frame(360, 3, 0, 100, 392, 3, 0, 100));
            Player.Add(MirAction.Die, new Frame(384, 4, 0, 100, 416, 4, 0, 100));
            Player.Add(MirAction.Dead, new Frame(387, 1, 3, 1000, 419, 1, 3, 1000));
            Player.Add(MirAction.Revive, new Frame(384, 4, 0, 100, 416, 4, 0, 100) { Reverse = true });
            Player.Add(MirAction.Mine, new Frame(184, 6, 0, 100, 216, 6, 0, 100));
            Player.Add(MirAction.Lunge, new Frame(139, 1, 5, 1000, 300, 1, 5, 1000));

            //刺客
            Player.Add(MirAction.Sneek, new Frame(464, 6, 0, 100, 496, 6, 0, 100));
            Player.Add(MirAction.DashAttack, new Frame(80, 3, 3, 100, 112, 3, 3, 100));

            //弓箭手
            Player.Add(MirAction.WalkingBow, new Frame(0, 6, 0, 100, 0, 6, 0, 100));
            Player.Add(MirAction.RunningBow, new Frame(48, 6, 0, 100, 48, 6, 0, 100));
            Player.Add(MirAction.AttackRange1, new Frame(96, 8, 0, 100, 96, 8, 0, 100));
            Player.Add(MirAction.AttackRange2, new Frame(160, 8, 0, 100, 160, 8, 0, 100));
            Player.Add(MirAction.AttackRange3, new Frame(224, 8, 0, 100, 224, 8, 0, 100));
            Player.Add(MirAction.Jump, new Frame(288, 8, 0, 100, 288, 8, 0, 100));

            //Mounts
            Player.Add(MirAction.MountStanding, new Frame(416, 4, 0, 500, 448, 4, 0, 500));
            Player.Add(MirAction.MountWalking, new Frame(448, 8, 0, 100, 480, 8, 0, 500));
            Player.Add(MirAction.MountRunning, new Frame(512, 6, 0, 100, 544, 6, 0, 100));
            Player.Add(MirAction.MountStruck, new Frame(560, 3, 0, 100, 592, 3, 0, 100));
            Player.Add(MirAction.MountAttack, new Frame(584, 6, 0, 100, 616, 6, 0, 100));

            //Fishing
            Player.Add(MirAction.FishingCast, new Frame(632, 8, 0, 100));
            Player.Add(MirAction.FishingWait, new Frame(696, 6, 0, 120));
            Player.Add(MirAction.FishingReel, new Frame(744, 8, 0, 100));

            #endregion
        }
    }

    public class Frame
    {
        public int Start, Count, Skip, EffectStart, EffectCount, EffectSkip;
        public int Interval, EffectInterval;
        public bool Reverse, Blend;

        public int OffSet
        {
            get { return Count + Skip; }
        }

        public int EffectOffSet
        {
            get { return EffectCount + EffectSkip; }
        }

        public Frame(int start, int count, int skip, int interval, int effectstart = 0, int effectcount = 0, int effectskip = 0, int effectinterval = 0)
        {
            Start = start;
            Count = count;
            Skip = skip;
            Interval = interval;
            EffectStart = effectstart;
            EffectCount = effectcount;
            EffectSkip = effectskip;
            EffectInterval = effectinterval;
        }

        public Frame(BinaryReader reader)
        {
            Start = reader.ReadInt32();
            Count = reader.ReadInt32();
            Skip = reader.ReadInt32();
            Interval = reader.ReadInt32();
            EffectStart = reader.ReadInt32();
            EffectCount = reader.ReadInt32();
            EffectSkip = reader.ReadInt32();
            EffectInterval = reader.ReadInt32();
            Reverse = reader.ReadBoolean();
            Blend = reader.ReadBoolean();
        }
    }

}
