using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Giving_Api.Security
{
    public class EnumsManager
    {
        public enum DeviceChannel
        {
            Web = 1,
            Mobile = 2,
            ApiCall = 3
        }
        public enum TransactionType
        {
            Campaign = 1,
            GroupContributions = 2,
            ImpactInvestment = 3,
            Volunteer = 4
        }

        public enum UserCode
        {
            CampaignCode = 1,
            GroupContributionsCode = 2,
            ImpactInvestmentCode = 3,
            VolunteerCode = 4
        }
    }
}
