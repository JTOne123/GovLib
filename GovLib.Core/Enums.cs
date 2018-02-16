namespace GovLib
{
    #pragma warning disable CS1591
    
    public enum Chamber
    {
        Senate,
        House
    }

    public enum Gender
    {
        Male,
        Female
    }

    public enum State
    {
        Alabama,
        Alaska,
        Arizona,
        Arkansas,
        California,
        Colorado,
        Connecticut,
        Delaware,
        Florida,
        Georgia,
        Hawaii,
        Idaho,
        Illinois,
        Indiana,
        Iowa,
        Kansas,
        Kentucky,
        Louisiana,
        Maine,
        Maryland,
        Massachusetts,
        Michigan,
        Minnesota,
        Mississippi,
        Missouri,
        Montana,
        Nebraska,
        Nevada,
        NewHampshire,
        NewJersey,
        NewMexico,
        NewYork,
        NorthCarolina,
        NorthDakota,
        Ohio,
        Oklahoma,
        Oregon,
        Pennsylvania,
        RhodeIsland,
        SouthCarolina,
        SouthDakota,
        Tennessee,
        Texas,
        Utah,
        Vermont,
        Virginia,
        Washington,
        WestVirginia,
        Wisconsin,
        Wyoming
    }

    public enum BillStatus
    {
        ///<summary>Bill has been introduced by a member of congress.</summary>
        Introduced,
        ///<summary>Bill status has changed recently.</summary>
        Updated,
        ///<summary>Bill has seen action beyond introduction and committee referral.</summary>
        Active,
        ///<summary>Bill has been passed and awaits Presidential signature.</summary>
        Passed,
        ///<summary>Bill has been passed and signed into law.</summary>
        Enacted,
        ///<summary>Bill has been passed but vetoed by the President.</summary>
        Vetoed
    }
}