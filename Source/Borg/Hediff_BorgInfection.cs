using RimWorld;
using Verse;

namespace BorgAssimilate;

public class Hediff_BorgInfection : Hediff_Injury
{
    public override void Notify_PawnDied()
    {
        base.Notify_PawnDied();

        if (!pawn.def.race.Animal)
        {
            var corpse = pawn.Corpse;
            var newBorg = PawnGenerator.GeneratePawn(PawnKindDef.Named("BorgDrone3"),
                FactionUtility.DefaultFactionFrom(FactionDef.Named("BorgCollective")));
            newBorg.Position = corpse.Position;
            newBorg.SpawnSetup(corpse.Map, false);

            if (corpse != null)
            {
                corpse.Destroy();
            }

            return;
        }

        Messages.Message(
            "an animal has succumbed to nanite infection, and have been deemed inappropriate for assimilation. The nanites have consumed and destroyed the corpse.",
            MessageTypeDefOf.NeutralEvent);
        pawn.Corpse.Destroy();
    }
}