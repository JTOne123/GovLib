using Xunit;
using static GovLib.Util.EnumConvert;

namespace GovLib.Tests.Core.Util
{
    public class EnumConvertTests
    {
        [Fact]
        public void StateEnumToCodeIsValid()
        {
            Assert.Equal(StateEnumToCode(State.Alabama), "AL");
            Assert.Equal(StateEnumToCode(State.Alaska), "AK");
            Assert.Equal(StateEnumToCode(State.Arizona), "AZ");
            Assert.Equal(StateEnumToCode(State.Arkansas), "AR");
            Assert.Equal(StateEnumToCode(State.California), "CA");
            Assert.Equal(StateEnumToCode(State.Colorado), "CO");
            Assert.Equal(StateEnumToCode(State.Connecticut), "CT");
            Assert.Equal(StateEnumToCode(State.Delaware), "DE");
            Assert.Equal(StateEnumToCode(State.Florida), "FL");
            Assert.Equal(StateEnumToCode(State.Georgia), "GA");
            Assert.Equal(StateEnumToCode(State.Hawaii), "HI");
            Assert.Equal(StateEnumToCode(State.Idaho), "ID");
            Assert.Equal(StateEnumToCode(State.Illinois), "IL");
            Assert.Equal(StateEnumToCode(State.Indiana), "IN");
            Assert.Equal(StateEnumToCode(State.Iowa), "IA");
            Assert.Equal(StateEnumToCode(State.Kansas), "KS");
            Assert.Equal(StateEnumToCode(State.Kentucky), "KY");
            Assert.Equal(StateEnumToCode(State.Louisiana), "LA");
            Assert.Equal(StateEnumToCode(State.Maine), "ME");
            Assert.Equal(StateEnumToCode(State.Maryland), "MD");
            Assert.Equal(StateEnumToCode(State.Massachusetts), "MA");
            Assert.Equal(StateEnumToCode(State.Michigan), "MI");
            Assert.Equal(StateEnumToCode(State.Minnesota), "MN");
            Assert.Equal(StateEnumToCode(State.Mississippi), "MS");
            Assert.Equal(StateEnumToCode(State.Missouri), "MO");
            Assert.Equal(StateEnumToCode(State.Montana), "MT");
            Assert.Equal(StateEnumToCode(State.Nebraska), "NE");
            Assert.Equal(StateEnumToCode(State.Nevada), "NV");
            Assert.Equal(StateEnumToCode(State.NewHampshire), "NH");
            Assert.Equal(StateEnumToCode(State.NewJersey), "NJ");
            Assert.Equal(StateEnumToCode(State.NewMexico), "NM");
            Assert.Equal(StateEnumToCode(State.NewYork), "NY");
            Assert.Equal(StateEnumToCode(State.NorthCarolina), "NC");
            Assert.Equal(StateEnumToCode(State.NorthDakota), "ND");
            Assert.Equal(StateEnumToCode(State.Ohio), "OH");
            Assert.Equal(StateEnumToCode(State.Oklahoma), "OK");
            Assert.Equal(StateEnumToCode(State.Oregon), "OR");
            Assert.Equal(StateEnumToCode(State.Pennsylvania), "PA");
            Assert.Equal(StateEnumToCode(State.RhodeIsland), "RI");
            Assert.Equal(StateEnumToCode(State.SouthCarolina), "SC");
            Assert.Equal(StateEnumToCode(State.SouthDakota), "SD");
            Assert.Equal(StateEnumToCode(State.Tennessee), "TN");
            Assert.Equal(StateEnumToCode(State.Texas), "TX");
            Assert.Equal(StateEnumToCode(State.Utah), "UT");
            Assert.Equal(StateEnumToCode(State.Vermont), "VT");
            Assert.Equal(StateEnumToCode(State.Virginia), "VA");
            Assert.Equal(StateEnumToCode(State.Washington), "WA");
            Assert.Equal(StateEnumToCode(State.WestVirginia), "WV");
            Assert.Equal(StateEnumToCode(State.Wisconsin), "WI");
            Assert.Equal(StateEnumToCode(State.Wyoming), "WY");
            Assert.Equal(StateEnumToCode(State.Wyoming), "WY");
        }

        [Fact]
        public void StateCodeToEnumIsValid()
        {
            Assert.Equal(StateCodeToEnum("AL"), State.Alabama);
            Assert.Equal(StateCodeToEnum("AK"), State.Alaska);
            Assert.Equal(StateCodeToEnum("AZ"), State.Arizona);
            Assert.Equal(StateCodeToEnum("AR"), State.Arkansas);
            Assert.Equal(StateCodeToEnum("CA"), State.California);
            Assert.Equal(StateCodeToEnum("CO"), State.Colorado);
            Assert.Equal(StateCodeToEnum("CT"), State.Connecticut);
            Assert.Equal(StateCodeToEnum("DE"), State.Delaware);
            Assert.Equal(StateCodeToEnum("FL"), State.Florida);
            Assert.Equal(StateCodeToEnum("GA"), State.Georgia);
            Assert.Equal(StateCodeToEnum("HI"), State.Hawaii);
            Assert.Equal(StateCodeToEnum("ID"), State.Idaho);
            Assert.Equal(StateCodeToEnum("IL"), State.Illinois);
            Assert.Equal(StateCodeToEnum("IN"), State.Indiana);
            Assert.Equal(StateCodeToEnum("IA"), State.Iowa);
            Assert.Equal(StateCodeToEnum("KS"), State.Kansas);
            Assert.Equal(StateCodeToEnum("KY"), State.Kentucky);
            Assert.Equal(StateCodeToEnum("LA"), State.Louisiana);
            Assert.Equal(StateCodeToEnum("ME"), State.Maine);
            Assert.Equal(StateCodeToEnum("MD"), State.Maryland);
            Assert.Equal(StateCodeToEnum("MA"), State.Massachusetts);
            Assert.Equal(StateCodeToEnum("MI"), State.Michigan);
            Assert.Equal(StateCodeToEnum("MN"), State.Minnesota);
            Assert.Equal(StateCodeToEnum("MS"), State.Mississippi);
            Assert.Equal(StateCodeToEnum("MO"), State.Missouri);
            Assert.Equal(StateCodeToEnum("MT"), State.Montana);
            Assert.Equal(StateCodeToEnum("NE"), State.Nebraska);
            Assert.Equal(StateCodeToEnum("NV"), State.Nevada);
            Assert.Equal(StateCodeToEnum("NH"), State.NewHampshire);
            Assert.Equal(StateCodeToEnum("NJ"), State.NewJersey);
            Assert.Equal(StateCodeToEnum("NM"), State.NewMexico);
            Assert.Equal(StateCodeToEnum("NY"), State.NewYork);
            Assert.Equal(StateCodeToEnum("NC"), State.NorthCarolina);
            Assert.Equal(StateCodeToEnum("ND"), State.NorthDakota);
            Assert.Equal(StateCodeToEnum("OH"), State.Ohio);
            Assert.Equal(StateCodeToEnum("OK"), State.Oklahoma);
            Assert.Equal(StateCodeToEnum("OR"), State.Oregon);
            Assert.Equal(StateCodeToEnum("PA"), State.Pennsylvania);
            Assert.Equal(StateCodeToEnum("RI"), State.RhodeIsland);
            Assert.Equal(StateCodeToEnum("SC"), State.SouthCarolina);
            Assert.Equal(StateCodeToEnum("SD"), State.SouthDakota);
            Assert.Equal(StateCodeToEnum("TN"), State.Tennessee);
            Assert.Equal(StateCodeToEnum("TX"), State.Texas);
            Assert.Equal(StateCodeToEnum("UT"), State.Utah);
            Assert.Equal(StateCodeToEnum("VT"), State.Vermont);
            Assert.Equal(StateCodeToEnum("VA"), State.Virginia);
            Assert.Equal(StateCodeToEnum("WA"), State.Washington);
            Assert.Equal(StateCodeToEnum("WV"), State.WestVirginia);
            Assert.Equal(StateCodeToEnum("WI"), State.Wisconsin);
            Assert.Equal(StateCodeToEnum("WY"), State.Wyoming);
            Assert.Null(StateCodeToEnum("XX"));
        }


        [Fact]
        public void ChamberEnumToStringIsValid()
        {
            Assert.Equal(ChamberEnumToString(Chamber.Senate), "senate");
            Assert.Equal(ChamberEnumToString(Chamber.House), "house");
        }

        [Fact]
        public void ChamberStringToEnumIsValid()
        {
            Assert.Equal(ChamberStringToEnum("SenaTe"), Chamber.Senate);
            Assert.Equal(ChamberStringToEnum("HouSE"), Chamber.House);
            Assert.Null(ChamberStringToEnum("President"));
        }
    }
}