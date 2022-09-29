using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeclarationPlus.Core.CQRS.Declarations.Commands.EvaluateDeclaration
{
    public class EvaluateDeclarationCommandResponse
    {
        public EvaluateDeclarationCommandResponse()
        {
            Success = true;
        }

        public EvaluateDeclarationCommandResponse(string message)
        {
            Message = message;
            Success = false;
        }

        public string Message { get; }

        public bool Success { get; }
    }
}
