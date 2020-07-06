using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Giving_Api.Security
{
    public class EnumsManager
    {
        public enum MessageStatusEnum
        {
            Pending = 1,
            Attempted = 2,
            Sent = 3
        }
        public enum MessageContentCode
        {
            RecurringDonation = 1,
            
        }

        public enum UserCode
        {
            CampaignCode = 1,
            GroupContributionsCode = 2,
            ImpactInvestmentCode = 3,
            VolunteerCode = 4
        }

        public enum RecurringFrequency
        {
            Weekly = 1,
            Monthly = 2,
            Quaterly = 3,
            Annually = 4
        }
    }
}
