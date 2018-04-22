using System;
using System.Linq;
using GovLib.ProPublica.Util.ApiModels.BillModels;
using GovLib.Util;
using Newtonsoft.Json;

namespace GovLib.ProPublica.Util.ApiModels.VoteModels
{
    internal class ApiVote
    {
        [JsonProperty("congress")]
        internal int Congress { get; set; }
        
        [JsonProperty("session")]
        internal int Session { get; set; }
        
        [JsonProperty("chamber")]
        internal string Chamber { get; set; }
        
        [JsonProperty("roll_call")]
        internal int RollCall { get; set; }
        
        [JsonProperty("question")]
        internal string Question { get; set; }
        
        [JsonProperty("description")]
        internal string Description { get; set; }
        
        [JsonProperty("vote_type")]
        internal string VoteType { get; set; }
        
        [JsonProperty("date")]
        internal string Date { get; set; }
        
        [JsonProperty("time")]
        internal string Time { get; set; }
        
        [JsonProperty("result")]
        internal string Result { get; set; }
        
        [JsonProperty("title")]
        internal string Title { get; set; }
        
        [JsonProperty("document_title")]
        internal string DocumentTitle { get; set; }
        
        [JsonProperty("bill")]
        internal ApiVoteBill Bill { get; set; }
        
        [JsonProperty("amendment")]
        internal ApiVoteAmendment Amendment { get; set; }
        
        [JsonProperty("nomination")]
        internal ApiVoteNomination Nomination { get; set; }
        
        [JsonProperty("republican")]
        internal ApiPartyVote RepublicanVotes { get; set; }
        
        [JsonProperty("democratic")]
        internal ApiPartyVote DemocraticVotes { get; set; }
        
        [JsonProperty("independent")]
        internal ApiPartyVote IndependentVotes { get; set; }
        
        [JsonProperty("total")]
        internal ApiPartyVote TotalVotes { get; set; }

        public static Vote Convert(ApiVote entity)
        {
            if (entity == null)
                return null;
            
            Vote vote;

            if (!string.IsNullOrEmpty(entity.Nomination?.NominationID))
            {
                var nominationVote = new NominationVote();
                nominationVote.NominationID = entity.Nomination.NominationID;
                nominationVote.Number = entity.Nomination.Number;
                nominationVote.Name = entity.Nomination.Name;
                nominationVote.Agency = entity.Nomination.Agency;
                vote = nominationVote;
            }
            else if (!string.IsNullOrEmpty(entity.Amendment?.AmendmentID))
            {
                var amendmentVote = new AmendmentVote();
                amendmentVote.AmendmentID = entity.Amendment.AmendmentID;
                vote = amendmentVote;
            }
            else if (entity.Bill.Number.Equals("JOURNAL", StringComparison.InvariantCultureIgnoreCase))
            {
                var jounralVote = new JournalVote();
                jounralVote.BillID = entity.Bill.BillID;
                vote = jounralVote;
            }
            else
            {
                var billVote = new BillVote();
                billVote.BillID = entity.Bill.BillID;
                billVote.SponsorID = entity.Bill.SponsorID;
                billVote.Number = entity.Bill.Number;
                vote = billVote;
            }
            
            var democraticVotes = new VoteResult
            {
                Yes = entity.DemocraticVotes.Yes,
                No = entity.DemocraticVotes.No,
                NotVoting = entity.DemocraticVotes.NotVoting,
                Present = entity.DemocraticVotes.Present,
            };
            
            var republicanVotes = new VoteResult
            {
                Yes = entity.RepublicanVotes.Yes,
                No = entity.RepublicanVotes.No,
                NotVoting = entity.RepublicanVotes.NotVoting,
                Present = entity.RepublicanVotes.Present,
            };
            
            var independentVotes = new VoteResult
            {
                Yes = entity.IndependentVotes.Yes,
                No = entity.IndependentVotes.No,
                NotVoting = entity.IndependentVotes.NotVoting,
                Present = entity.IndependentVotes.Present,
            };
            
            var totalVotes = new VoteResult
            {
                Yes = entity.TotalVotes.Yes,
                No = entity.TotalVotes.No,
                NotVoting = entity.TotalVotes.NotVoting,
                Present = entity.TotalVotes.Present,
            };
            
            if (entity.Chamber.Equals("senate", StringComparison.InvariantCultureIgnoreCase))
                vote.Chamber = GovLib.Chamber.Senate;
            else
                vote.Chamber = GovLib.Chamber.House;

            vote.Congress = entity.Congress;
            vote.Session = entity.Session;
            vote.RollCall = entity.RollCall;
            vote.Question = entity.Question;
            vote.Title = entity.Title ?? entity.DocumentTitle;
            vote.Description = entity.Description;
            vote.VoteType = entity.VoteType;
            vote.TimeStamp = DateTime.Parse($"{entity.Date} {entity.Time}");
            vote.Passed = entity.Result.Equals("Passed", StringComparison.InvariantCultureIgnoreCase);
            vote.DemocraticVotes = democraticVotes;
            vote.RepublicanVotes = republicanVotes;
            vote.IndependentVotes = independentVotes;
            vote.TotalVotes = totalVotes;

            return vote;
        }
    }
}