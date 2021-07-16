using RimWorld;
using Verse;

namespace BorgAssimilate
{
    public class Hediff_BorgInfectionPlayer : Hediff_Injury
    {
        public override void Notify_PawnDied()
        {
            base.Notify_PawnDied();

            if (pawn.def.race.Animal == false)
            {
                var corpse = pawn.Corpse;
                var newBorg1 = PawnGenerator.GeneratePawn(PawnKindDef.Named("PlayerBorgDrone"),
                    FactionUtility.DefaultFactionFrom(FactionDef.Named("BorgCollective")));
                newBorg1.SetFaction(Faction.OfPlayer);
                newBorg1.Position = corpse.Position;
                newBorg1.SpawnSetup(corpse.Map, false);

                if (corpse != null)
                {
                    corpse.Destroy();
                }
            }
            else if (pawn.def.race.Animal)
            {
                Messages.Message(
                    "an animal has succumbed to the nanite infection, and have been deemed inappropriate for assimilation. The nanites have consumed and destroyed the corpse.",
                    MessageTypeDefOf.NeutralEvent);
                pawn.Corpse.Destroy();
            }
        }
    }
}