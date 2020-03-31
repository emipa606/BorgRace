using System; // Base C# library
using RimWorld; // RimWorld's base game library. Contains lots of hardcodedgame data
using Verse; // RimWorld's second main library. Holds more "functional" classes than RimWorld's game data classes
using System.Reflection; // Reflection is a way to access private data that is origally intended to not be accessed or simply hidden


namespace BorgAssimilate
{
    public class Hediff_BorgInfection : Hediff_Injury
    {
        public override void Notify_PawnDied()
        {
            base.Notify_PawnDied();

            if (pawn.def.race.Animal == false)
            {
                Corpse corpse = pawn.Corpse;
                Pawn newBorg = PawnGenerator.GeneratePawn(PawnKindDef.Named("BorgDrone3"), FactionUtility.DefaultFactionFrom(FactionDef.Named("BorgCollective")));
                newBorg.Position = corpse.Position;
                newBorg.SpawnSetup(corpse.Map, false);

                if (corpse != null)
                    corpse.Destroy();
            }
            else if (pawn.def.race.Animal == true)
            {
                Messages.Message("an animal has succumbed to nanite infection, and have been deemed inappropriate for assimilation. The nanites have consumed and destroyed the corpse.", MessageTypeDefOf.NeutralEvent);
                pawn.Corpse.Destroy();
            }
        }
    }




    public class Hediff_BorgInfectionPlayer : Hediff_Injury
    {
        public override void Notify_PawnDied()
        {
            base.Notify_PawnDied();

            if (pawn.def.race.Animal == false)
            {
                Corpse corpse = pawn.Corpse;
                Pawn newBorg1 = PawnGenerator.GeneratePawn(PawnKindDef.Named("PlayerBorgDrone"), FactionUtility.DefaultFactionFrom(FactionDef.Named("BorgCollective")));
                newBorg1.SetFaction(Faction.OfPlayer);
                newBorg1.Position = corpse.Position;
                newBorg1.SpawnSetup(corpse.Map, false);

                if (corpse != null)
                    corpse.Destroy();
            }
            else if (pawn.def.race.Animal == true)
            {
                Messages.Message("an animal has succumbed to the nanite infection, and have been deemed inappropriate for assimilation. The nanites have consumed and destroyed the corpse.", MessageTypeDefOf.NeutralEvent);
                pawn.Corpse.Destroy();
            }

        }
    }
}

