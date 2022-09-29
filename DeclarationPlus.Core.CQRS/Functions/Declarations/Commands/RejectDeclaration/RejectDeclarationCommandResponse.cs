using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeclarationPlus.Core.CQRS.Declarations.Commands.RejectDeclaration
{
    public class RejectDeclarationCommandResponse
    {
        public RejectDeclarationCommandResponse()
        {
            Success = true;
        }

        public RejectDeclarationCommandResponse(string message)
        {
            Message = message;
            Success = false;
        }

        public string Message { get; }

        public bool Success { get; }
    }
}
