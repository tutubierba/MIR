using System;
using Server.MirDatabase;
using S = ServerPackets;

namespace Server.MirObjects.Monsters
{
    public class RedFaeFlower : MonsterObject
    {

        private byte _stage = 0;
        protected virtual byte AttackRange
        {
            get
            {
                return 8;
            }
        }

        protected internal RedFaeFlower(MonsterInfo info)
            : base(info)
        {
        }

        protected override bool InAttackRange()
        {
            return CurrentMap == Target.CurrentMap && Functions.InRange(CurrentLocation, Target.CurrentLocation, AttackRange);
        }

        protected override void Attack()
        {
            if (!Target.IsAttackTarget(this))
            {
                Target = null;
                return;
            }

            ShockTime = 0;

            Direction = Functions.DirectionFromPoint(CurrentLocation, Target.CurrentLocation);
            bool ranged = CurrentLocation == Target.CurrentLocation || !Functions.InRange(CurrentLocation, Target.CurrentLocation, 1);

            ActionTime = Envir.Time + 300;
            AttackTime = Envir.Time + AttackSpeed;

            int damage = GetAttackPower(Stats[Stat.MinDC], Stats[Stat.MaxDC]);
            if (!ranged)
            {
                Broadcast(new S.ObjectAttack { ObjectID = ObjectID, Direction = Direction, Location = CurrentLocation });
                if (damage == 0) return;

                DelayedAction action = new DelayedAction(DelayedType.Damage, Envir.Time + 300, Target, damage, DefenceType.MACAgility);
                ActionList.Add(action);
            }
            else
            {

                Broadcast(new S.ObjectRangeAttack { ObjectID = ObjectID, Direction = Direction, Location = CurrentLocation, TargetID = Target.ObjectID });
                AttackTime = Envir.Time + AttackSpeed + 500;
                if (damage == 0) return;

                DelayedAction action = new DelayedAction(DelayedType.RangeDamage, Envir.Time + 500, Target, damage, DefenceType.MAC);
                ActionList.Add(action);

            }
        }

        protected override void ProcessTarget()
        {
            if (Target == null) return;

            if (InAttackRange() && CanAttack)
            {
                Attack();
                return;
            }

            if (Envir.Time < ShockTime)
            {
                Target = null;
                return;
            }

            MoveTo(Target.CurrentLocation);
        }

        private void SpawnSlaves()
        {
            if (SlaveList.Count != 0)
            {
                for(int i = 0; i < SlaveList.Count; i++)
                {
                    SlaveList[i].Despawn();
                }
                SlaveList.Clear();
            }
            int count = Math.Min(4, 4 - SlaveList.Count);
            System.Drawing.Point p = Front;
            for (int i = 0; i < count; i++)
            {
                MonsterObject mob = GetMonster(Envir.GetMonsterInfo("雪花"));

                if (mob == null) continue;
                switch (i){
                    case 0:
                        p.X = Front.X + 1;
                        break;
                    case 1:
                        p.X = Front.X - 1;
                        break;
                    case 2:
                        p.Y = Front.Y + 1;
                        break;
                    case 3:
                        p.Y = Front.Y - 1;
                        break;
                }
                if (!mob.Spawn(CurrentMap, p))
                    mob.Spawn(CurrentMap, CurrentLocation);

                mob.Target = Target;
                mob.ActionTime = Envir.Time + 2000;
                SlaveList.Add(mob);
            }
        }

        public override void Die() { 
            for(int i = 0; i < SlaveList.Count;i++)
            {
                SlaveList[i].Die();
            }
            base.Die();
        }

        protected override void ProcessAI()
        {
            if (Dead) return;
            if( HP < ( Stats[Stat.HP] / 2 ))
            {
                if(_stage == 0)
                {
                    _stage = 1;
                    SpawnSlaves();
                }
            }
            else
            {
                _stage = 0;
            }
            base.ProcessAI();
        }
    }
}
