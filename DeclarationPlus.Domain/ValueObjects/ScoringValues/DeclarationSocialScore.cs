using Common.Domain.Ddd;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeclarationPlus.Domain.ValueObjects.Scoring
{
    public class DeclarationSocialScore : ValueObject<DeclarationSocialScore>, 
        IComparable<DeclarationSocialScore>
    {
        private readonly int socialScore;

        public int SocialScore
        {
            get { return socialScore; }
        }

        public DeclarationSocialScore(int socialScore)
        {
            this.socialScore = socialScore;
        }

        protected override IEnumerable<object> GetAttributesToIncludeInEqualityCheck()
        {
            yield return socialScore;
        }

        public static bool operator >(DeclarationSocialScore one, DeclarationSocialScore two) => one.CompareTo(two) > 0;

        public static bool operator <(DeclarationSocialScore one, DeclarationSocialScore two) => one.CompareTo(two) < 0;

        public static bool operator >=(DeclarationSocialScore one, DeclarationSocialScore two) => one.CompareTo(two) >= 0;

        public static bool operator <=(DeclarationSocialScore one, DeclarationSocialScore two) => one.CompareTo(two) <= 0;


        public int CompareTo(DeclarationSocialScore other)
        {
            return socialScore.CompareTo(other.socialScore);
        }
    }
}
