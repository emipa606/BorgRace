using RimWorld;
using Verse; // Base C# library
// RimWorld's base game library. Contains lots of hardcodedgame data
// RimWorld's second main library. Holds more "functional" classes than RimWorld's game data classes
// Reflection is a way to access private data that is origally intended to not be accessed or simply hidden


namespace BorgAssimilate
{
    public class Hediff_BorgInfection : Hediff_Injury
    {
        public override void Notify_PawnDied()
        {
            base.Notify_PawnDied();

            if (pawn.def.race.Animal == false)
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
            }
            else if (pawn.def.race.Animal)
            {
                Messages.Message(
                    "an animal has succumbed to nanite infection, and have been deemed inappropriate for assimilation. The nanites have consumed and destroyed the corpse.",
                    MessageTypeDefOf.NeutralEvent);
                pawn.Corpse.Destroy();
            }
        }
    }
}