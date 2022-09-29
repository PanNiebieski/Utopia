using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeclarationPlus.Core.CQRS.Declarations.Commands.AcceptDeclaration
{
    public class AcceptDeclarationCommandResponse
    {
        public AcceptDeclarationCommandResponse()
        {
            Success = true;
        }

        public AcceptDeclarationCommandResponse(string message)
        {
            Message = message;
            Success = false;
        }

        public string Message { get; }

        public bool Success { get; }
    }
}
