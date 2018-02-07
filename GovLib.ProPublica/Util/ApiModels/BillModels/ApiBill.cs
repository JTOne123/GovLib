using System;
using System.Globalization;
using GovLib.Contracts;

namespace GovLib.ProPublica.Util.ApiModels.BillModels
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
        public bool active;
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

        public static Bill Convert(ApiBill entity, MemberCache cache)
        {
            if (entity == null)
                return null;
            
            var bill = new Bill();

            bill.ID = entity.bill_id;
            bill.Url = entity.bill_uri;
            bill.Title = entity.short_title;
            bill.BillType = entity.bill_type;
            bill.Introduced = DateTime.ParseExact(entity.introduced_date, "yyyy-MM-dd", CultureInfo.InvariantCulture);
            bill.LatestAction = entity.latest_major_action;
            bill.LatestActionDate = DateTime.ParseExact(entity.latest_major_action_date, "yyyy-MM-dd", CultureInfo.InvariantCulture);
            bill.SponsorID = entity.sponsor_id;

            if (entity.sponsor_title == "Sen.")
                bill.Sponsor = cache.Senators[entity.sponsor_id];
            else
                bill.Sponsor = cache.Representatives[entity.sponsor_id];
            
            return bill;
        }
    }
}