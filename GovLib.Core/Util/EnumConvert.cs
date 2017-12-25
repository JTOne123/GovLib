using GovLib.Contracts;

namespace GovLib.Util
{
    #pragma warning disable CS1591
    public class EnumConvert
    {
        public static State? StateCodeToEnum(string state)
        {
            switch (state.ToUpper())
            {
                case "AL":    
                    return State.Alabama;
                case "AK":    
                    return State.Alaska;
                case "AZ":    
                    return State.Arizona;
                case "AR":    
                    return State.Arkansas;
                case "CA":    
                    return State.California;
                case "CO":    
                    return State.Colorado;
                case "CT":    
                    return State.Connecticut;
                case "DE":    
                    return State.Delaware;
                case "FL":    
                    return State.Florida;
                case "GA":    
                    return State.Georgia;
                case "HI":    
                    return State.Hawaii;
                case "ID":    
                    return State.Idaho;
                case "IL":    
                    return State.Illinois;
                case "IN":    
                    return State.Indiana;
                case "IA":    
                    return State.Iowa;
                case "KS":    
                    return State.Kansas;
                case "KY":    
                    return State.Kentucky;
                case "LA":    
                    return State.Louisiana;
                case "ME":    
                    return State.Maine;
                case "MD":    
                    return State.Maryland;
                case "MA":    
                    return State.Massachusetts;
                case "MI":    
                    return State.Michigan;
                case "MN":    
                    return State.Minnesota;
                case "MS":    
                    return State.Mississippi;
                case "MO":    
                    return State.Missouri;
                case "MT":    
                    return State.Montana;
                case "NE":    
                    return State.Nebraska;
                case "NV":    
                    return State.Nevada;
                case "NH":    
                    return State.NewHampshire;
                case "NJ":    
                    return State.NewJersey;
                case "NM":    
                    return State.NewMexico;
                case "NY":    
                    return State.NewYork;
                case "NC":    
                    return State.NorthCarolina;
                case "ND":    
                    return State.NorthDakota;
                case "OH":    
                    return State.Ohio;
                case "OK":    
                    return State.Oklahoma;
                case "OR":    
                    return State.Oregon;
                case "PA":    
                    return State.Pennsylvania;
                case "RI":    
                    return State.RhodeIsland;
                case "SC":    
                    return State.SouthCarolina;
                case "SD":    
                    return State.SouthDakota;
                case "TN":    
                    return State.Tennessee;
                case "TX":    
                    return State.Texas;
                case "UT":    
                    return State.Utah;
                case "VT":    
                    return State.Vermont;
                case "VA":    
                    return State.Virginia;
                case "WA":    
                    return State.Washington;
                case "WV":    
                    return State.WestVirginia;
                case "WI":    
                    return State.Wisconsin;
                case "WY":    
                    return State.Wyoming;
                default:
                    return null;
            }
        }

        public static string StateEnumToCode(State state)
        {
            switch (state)
            {
                case State.Alabama:    
                    return "AL";
                case State.Alaska:    
                    return "AK";
                case State.Arizona:    
                    return "AZ";
                case State.Arkansas:    
                    return "AR";
                case State.California:    
                    return "CA";
                case State.Colorado:    
                    return "CO";
                case State.Connecticut:    
                    return "CT";
                case State.Delaware:    
                    return "DE";
                case State.Florida:    
                    return "FL";
                case State.Georgia:    
                    return "GA";
                case State.Hawaii:    
                    return "HI";
                case State.Idaho:    
                    return "ID";
                case State.Illinois:    
                    return "IL";
                case State.Indiana:    
                    return "IN";
                case State.Iowa:    
                    return "IA";
                case State.Kansas:    
                    return "KS";
                case State.Kentucky:    
                    return "KY";
                case State.Louisiana:    
                    return "LA";
                case State.Maine:    
                    return "ME";
                case State.Maryland:    
                    return "MD";
                case State.Massachusetts:    
                    return "MA";
                case State.Michigan:    
                    return "MI";
                case State.Minnesota:    
                    return "MN";
                case State.Mississippi:    
                    return "MS";
                case State.Missouri:    
                    return "MO";
                case State.Montana:    
                    return "MT";
                case State.Nebraska:    
                    return "NE";
                case State.Nevada:    
                    return "NV";
                case State.NewHampshire:    
                    return "NH";
                case State.NewJersey:    
                    return "NJ";
                case State.NewMexico:    
                    return "NM";
                case State.NewYork:    
                    return "NY";
                case State.NorthCarolina:    
                    return "NC";
                case State.NorthDakota:    
                    return "ND";
                case State.Ohio:    
                    return "OH";
                case State.Oklahoma:    
                    return "OK";
                case State.Oregon:    
                    return "OR";
                case State.Pennsylvania:    
                    return "PA";
                case State.RhodeIsland:    
                    return "RI";
                case State.SouthCarolina:    
                    return "SC";
                case State.SouthDakota:    
                    return "SD";
                case State.Tennessee:    
                    return "TN";
                case State.Texas:    
                    return "TX";
                case State.Utah:    
                    return "UT";
                case State.Vermont:    
                    return "VT";
                case State.Virginia:    
                    return "VA";
                case State.Washington:    
                    return "WA";
                case State.WestVirginia:    
                    return "WV";
                case State.Wisconsin:    
                    return "WI";
                case State.Wyoming:    
                    return "WY";
                default:
                    return null;
            }
        }

        public static string ChamberEnumToString(Chamber chamber)
        {
            switch (chamber)
            {
                case Chamber.House:
                    return "house";
                case Chamber.Senate:
                    return "senate";
                default:
                    return null;
            }
        }

        public static string BillStatusEnumToString(BillStatus status)
        {
            switch (status)
            {
                case BillStatus.Active:
                    return "active";
                case BillStatus.Enacted:
                    return "enacted";
                case BillStatus.Introduced:
                    return "introduced";
                case BillStatus.Passed:
                    return "passed";
                case BillStatus.Updated:
                    return "updated";
                case BillStatus.Vetoed:
                    return "vetoed";
                default:
                    return null;
            }
        }
    }
}