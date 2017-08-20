
namespace Adre.SEA.Database.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    using System.Globalization;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<ASEAContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(ASEAContext context)
        {
            //SeedEvents(context);
            SeedMatchGroupType(context);
            SeedPhases(context);
            SeedContingent(context);
            //SeedAthletes(context);
            ClearData(context);
            //SeedEventAthlete(context);

            base.Seed(context);
        }
        
        void SeedEvents(ASEAContext context)
        {
            context.Events.AddOrUpdate(
                new Event { Id = new Guid("B75A0E3F-4204-489E-80C0-6B6595339CAB"), Gender = "M", Name = "Men's Single", Code = "MR" },
                new Event { Id = new Guid("29DA89CB-2B1C-495B-8F53-095915362DC0"), Gender = "F", Name = "Women's Single", Code = "WR" },
                new Event { Id = new Guid("2A4003BE-FE5D-4087-8F03-A34DA7B837B7"), Gender = "M", Name = "Men's Doubles", Code = "MD" },
                new Event { Id = new Guid("6341B7E7-3F44-4DF6-9CA2-48CE86DEED48"), Gender = "F", Name = "Women's Doubles", Code = "WD" }
            );
            context.SaveChanges();
        }

        void SeedMatchGroupType(ASEAContext context)
        {
            context.MatchGroupType.AddOrUpdate(
                new MatchGroupType { Id = new Guid("EF738556-71F0-4C65-9DD4-245663DD01CE"), Name = "", Order = 0 },
                new MatchGroupType { Id = new Guid("53F15089-7A3E-45F8-B277-F0E880C93CB5"), Name = "A", Order = 1 },
                new MatchGroupType { Id = new Guid("348422BC-47FF-4F3F-A0BE-9A41901BC266"), Name = "B", Order = 2 },
                new MatchGroupType { Id = new Guid("25D5D0B2-5803-475A-82D0-F663BDF02E0E"), Name = "C", Order = 3 },
                new MatchGroupType { Id = new Guid("9F37B749-E5D1-46FB-9AF9-A55CDB137B4A"), Name = "D", Order = 4 }
            );

            context.SaveChanges();
        }

        private void SeedContingent(ASEAContext context)
        {
            context.Contingents.AddOrUpdate(
                new Contingent { Id = new Guid("E27C77C3-BC18-446C-8934-C772A1FE3765"), Name = "Malaysia", Code = "MAS" },
                new Contingent { Id = new Guid("1F8294A6-D871-4FCE-8409-F097F7665083"), Name = "Cambodia", Code = "CAM" },
                new Contingent { Id = new Guid("745FA236-AB5C-46B1-93F7-45A14A8C7EC0"), Name = "Indonesia", Code = "INA" },
                new Contingent { Id = new Guid("2C668FCB-708B-4D40-AE75-381325460813"), Name = "Brunei", Code = "BRU" },
                new Contingent { Id = new Guid("8A707FFD-DDC3-4ADC-AC2E-46CB4842BDF4"), Name = "Laos", Code = "LAO" }
            );

            context.SaveChanges();
        }

        void SeedPhases(ASEAContext context)
        {
            context.Phases.AddOrUpdate(
                new Phase { Id = new Guid("21ABC201-591D-44AE-97E3-723715925AF8"), Name = "Reapercharge", Order = -2},
                new Phase { Id = new Guid("41669197-C0F9-4137-AEE2-B13D03622C91"), Name = "Round Robin", Order = -1},
                new Phase { Id = new Guid("19838D9D-8000-4EF0-99EE-9A97E44A7770"), Name = "Preliminary Round", Order = 0 },
                new Phase { Id = new Guid("B32C1F89-1507-46C0-8A83-403C8D3BF806"), Name = "Quarter Final", Order = 1},
                new Phase { Id = new Guid("A37EF34A-6305-4778-9CFA-1E452F290949"), Name = "Semi Final", Order = 2},
                new Phase { Id = new Guid("36588A0B-29EA-4294-BD69-72B2EFFE45DB"), Name = "Final", Order = 3 }
            );

            context.SaveChanges();
        }

        private void SeedAthletes(ASEAContext context)
        {
            context.Athletes.AddOrUpdate(
                new Athlete { Id = new Guid("36588A0B-29EA-4294-BD69-72B2EFFE45DB"), Gender = "M", Contingent = context.Contingents.First(c => c.Name == "Brunei"), FullName = "ABD KARIM ABD WAHAB", PreferredName = "ABD KARIM ABD WAHAB" },
                new Athlete { Id = new Guid("1492EA62-5100-45D5-91A3-3E71714F0739"), Gender = "M", Contingent = context.Contingents.First(c => c.Name == "Brunei"), FullName = "ABU BAKAR HAJI JUMAHAT", PreferredName = "ABU BAKAR HAJI JUMAHAT" },
                new Athlete { Id = new Guid("A7896569-7706-4445-9A22-9A04CB72E19E"), Gender = "F", Contingent = context.Contingents.First(c => c.Name == "Brunei"), FullName = "AUDREY LOUISE LUCIENNE", PreferredName = "AUDREY LOUISE LUCIENNE" },
                new Athlete { Id = new Guid("EF4BEE11-619A-4AC3-AE19-64F1A3502C2D"), Gender = "F", Contingent = context.Contingents.First(c => c.Name == "Brunei"), FullName = "DR SURITA MOHD TAIB", PreferredName = "DR SURITA MOHD TAIB" },
                new Athlete { Id = new Guid("EC1F46E5-C9D8-4B4D-9933-5F695549BC8B"), Gender = "M", Contingent = context.Contingents.First(c => c.Name == "Cambodia"), FullName = "AN SOVADTHYA", PreferredName = "AN SOVADTHYA" },
                new Athlete { Id = new Guid("70B032A8-1470-457C-A944-7BF8F4E2171A"), Gender = "M", Contingent = context.Contingents.First(c => c.Name == "Cambodia"), FullName = "ANEIROS ROMERO BRAEN SANTIAGO", PreferredName = "ANEIROS ROMERO BRAEN SANTIAGO" },
                new Athlete { Id = new Guid("82B42B46-2033-40FF-86A3-B3AA562BFD06"), Gender = "F", Contingent = context.Contingents.First(c => c.Name == "Cambodia"), FullName = "BEN ZINA CLAIR ANNE", PreferredName = "BEN ZINA CLAIR ANNE" },
                new Athlete { Id = new Guid("585B6C71-6A43-4026-A5CD-E8882E642E0E"), Gender = "F", Contingent = context.Contingents.First(c => c.Name == "Cambodia"), FullName = "CHHIN CHANTHACH", PreferredName = "CHHIN CHANTHACH" },
                new Athlete { Id = new Guid("26FC48D6-70C5-4A8A-8A19-9FAA3F10FFEE"), Gender = "M", Contingent = context.Contingents.First(c => c.Name == "Indonesia"), FullName = "AAS NASRULLAH", PreferredName = "AAS NASRULLAH" },
                new Athlete { Id = new Guid("FBDF5D5C-78DC-443C-A4B9-319352925CA8"), Gender = "M", Contingent = context.Contingents.First(c => c.Name == "Indonesia"), FullName = "ABBAS AKBAR DJAFAR", PreferredName = "ABBAS AKBAR DJAFAR" },
                new Athlete { Id = new Guid("D48A504C-2690-4633-82C1-CFEAEA1A56BB"), Gender = "F", Contingent = context.Contingents.First(c => c.Name == "Indonesia"), FullName = "ADE NOVI INDRIANY IRSYAD", PreferredName = "ADE NOVI INDRIANY IRSYAD" },
                new Athlete { Id = new Guid("D061686D-86B9-4EC9-A6D4-38DDBE7CD592"), Gender = "F", Contingent = context.Contingents.First(c => c.Name == "Indonesia"), FullName = "ANNA NASEKINA", PreferredName = "ANNA NASEKINA" },
                new Athlete { Id = new Guid("64C238EC-6A17-44F7-BED9-36482FC08C32"), Gender = "F", Contingent = context.Contingents.First(c => c.Name == "Laos"), FullName = "SILIVANH BOUNLAI", PreferredName = "SILIVANH BOUNLAI" },
                new Athlete { Id = new Guid("63D0E2B8-7C17-4F30-B385-ABF11A7354DC"), Gender = "F", Contingent = context.Contingents.First(c => c.Name == "Laos"), FullName = "VONGSOUTHI BOUTSABA", PreferredName = "VONGSOUTHI BOUTSABA" },
                new Athlete { Id = new Guid("857C7227-9CD2-4A85-8811-BBC7D09768A7"), Gender = "M", Contingent = context.Contingents.First(c => c.Name == "Laos"), FullName = "SAYSANSOUK ALENG", PreferredName = "SAYSANSOUK ALENG" },
                new Athlete { Id = new Guid("7AA0AF83-EF39-4DFA-82DB-5784EB21E2FC"), Gender = "M", Contingent = context.Contingents.First(c => c.Name == "Laos"), FullName = "PHENGSAVANH ALONGKONE", PreferredName = "PHENGSAVANH ALONGKONE" },
                new Athlete { Id = new Guid("833D5C0C-B266-449D-8816-677C5DF4CAD8"), Gender = "M", Contingent = context.Contingents.First(c => c.Name == "Malaysia"), FullName = "AHMAD FAUZI MUSTAFA", PreferredName = "AHMAD FAUZI MUSTAFA" },
                new Athlete { Id = new Guid("725C7F98-675F-42CD-942F-258C99A1D918"), Gender = "M", Contingent = context.Contingents.First(c => c.Name == "Malaysia"), FullName = "MURALI A/L ARUMUGAM", PreferredName = "MURALI A/L ARUMUGAM" },
                new Athlete { Id = new Guid("2EFD3AEB-9840-4BEE-8ED1-A48C22DA0C3F"), Gender = "F", Contingent = context.Contingents.First(c => c.Name == "Malaysia"), FullName = "NUR ADIBAH BINTI AHMAD IZAM", PreferredName = "NUR ADIBAH BINTI AHMAD IZAM" },
                new Athlete { Id = new Guid("5A746632-AFD9-46DD-B113-C000DFF4821A"), Gender = "F", Contingent = context.Contingents.First(c => c.Name == "Malaysia"), FullName = "ADILA BINTI MOHAMMAD", PreferredName = "ADILA BINTI MOHAMMAD" }
            );

            context.SaveChanges();

        }

        void SeedEventAthlete(ASEAContext context)
        {
            using (var d = new ASEAContext())
            {
                var e = d.Events.Find(Guid.Parse("B75A0E3F-4204-489E-80C0-6B6595339CAB"));
                e.Athlete.AddRange(d.Athletes.Where(m => m.Gender == "M"));

                e = d.Events.Find(Guid.Parse("2A4003BE-FE5D-4087-8F03-A34DA7B837B7"));
                e.Athlete.AddRange(d.Athletes.Where(m => m.Gender == "M"));

                e = d.Events.Find(Guid.Parse("29DA89CB-2B1C-495B-8F53-095915362DC0"));
                e.Athlete.AddRange(d.Athletes.Where(m => m.Gender == "F"));

                e = d.Events.Find(Guid.Parse("6341B7E7-3F44-4DF6-9CA2-48CE86DEED48"));
                e.Athlete.AddRange(d.Athletes.Where(m => m.Gender == "F"));

                d.SaveChanges();
            };
        }

        void ClearData(ASEAContext context)
        {
            context.Rankings.RemoveRange(context.Rankings);
            context.MatchAthlete.RemoveRange(context.MatchAthlete);
            context.Result.RemoveRange(context.Result);
            context.Matches.RemoveRange(context.Matches);
            context.SaveChanges();
        }
    }
}
