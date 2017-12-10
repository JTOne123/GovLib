using Gov.NET.Core.Models;
using Gov.NET.Models;

namespace Gov.NET.ProPublica.Util.ApiModels.BillModels
{
    internal class ApiSearchBills
    {
        public string bill_id;
        public string bill_type;
        public string number;
        public string bill_uri;
        public string title;
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
        public bool? active;
        public bool? house_passage;
        public bool? senate_passage;
        public bool? enacted;
        public bool? vetoed;
        public int cosponsors;
        public string committees;
        public string[] committee_codes;
        public string[] subcommittee_codes;
        public string primary_subject;
        public string summary;
        public string summary_short;
        public string latest_major_action_date;
        public string latest_major_action;

        public static Bill Convert(ApiSearchBills entity)
        {
            if (entity == null)
                return null;
            
            var bill = new Bill();

            if (entity.bill_type == "s") bill.Chamber = Chamber.Senate;
            else bill.Chamber = Chamber.House;

            bill.ID = entity.bill_id;
            bill.Url = entity.bill_uri;
            bill.Title = entity.title;
            bill.Text = entity.summary;
            bill.TextSnippet = entity.summary_short;
            
            return bill;
        }
    }
}