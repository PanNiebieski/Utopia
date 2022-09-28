using DeclarationPlus.Domain.Ddd;
using DeclarationPlus.Domain.ValueObjects;
using DeclarationPlus.Domain.ValueObjects.CitizenValues;
using DeclarationPlus.Domain.ValueObjects.Ids;
using DeclarationPlus.Domain.ValueObjects.Scoring;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace DeclarationPlus.Domain.Entities
{
    public class Declaration : Entity<DeclarationId>
    {
        public Citizen Citizen { get; set; }

        public DeclarationScoringResult Result { get; set; }

        public Decision FinalDecision { get; set; }

        public Territory Territory { get; set; }

        public DeclarationStatus Status { get; private set; }

        public Declaration(Citizen citizen,
               DeclarationId declarationId, Territory territory)
        {
            if (citizen == null)
                throw new ArgumentException("citizen cannot be null");
            if (declarationId == null)
                throw new ArgumentException("declarationId cannot be null");
            if (territory == null)
                throw new ArgumentException("territory cannot be null");


            Id = declarationId;
            Citizen = citizen;
            Territory = territory;
        }
    }
}
