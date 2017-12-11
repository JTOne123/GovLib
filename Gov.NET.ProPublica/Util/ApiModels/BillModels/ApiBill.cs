using Gov.NET.Models;

namespace Gov.NET.ProPublica.Util.ApiModels.BillModels
{
    internal class ApiBill
    {
        public string bill_id;
        public string bill_type;
        public string number;
        public string bill_uri;
        public string title;
        public string short_title;
        public string sponsor_title;
        public string sponsor_id;
        public string sponsor_name;
        public string sponsor_state;
        public string sponsor_party;
        public string sponsor_uri;
        public string gpo_pdf_uri;
        public string congressdotgov_url;
        public string govtrack_url;
        public string introduced_date;
        public string active;
        public string house_passage;
        public string senate_passage;
        public string enacted;
        public string vetoed;
        public int cosponsors;
        public string committees;
        public string[] committee_codes;
        public string[] subcommittee_codes;
        public string primary_subject;
        public string summary;
        public string summary_short;
        public string latest_major_action_date;
        public string latest_major_action;

        public static Bill Convert(ApiBill entity)
        {
            if (entity == null)
                return null;
            
            var bill = new Bill();

            if (entity.bill_type == "s") bill.Chamber = Chamber.Senate;
            else bill.Chamber = Chamber.House;

            bill.ID = entity.bill_id;
            bill.Url = entity.bill_uri;
            bill.Title = entity.title;
            bill.Text = entity.short_title;
            
            return bill;
        }
    }
}