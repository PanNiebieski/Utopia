using Common.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeclarationPlus.Core.CQRS.Declarations.Commands.SubmitDeclaration
{
    public class SubmitDeclarationCommandResponse
    {
        public SubmitDeclarationCommandResponse(ValidationStatus validatorResult)
        {
            ValidatorResult = validatorResult;

            foreach (var item in ValidatorResult.ValidationErrors)
            {
                MessageError += item;
            }

            Success = false;
        }

        public SubmitDeclarationCommandResponse(int value)
        {
            Value = value;
            Success = true;
        }

        public ValidationStatus ValidatorResult { get; }
        public int? Value { get; }

        public bool Success { get; }

        public string MessageError { get; set; }

        public SubmitDeclarationCommandResponse(string error)
        {
            Success = false;
            MessageError = error;
        }
    }
}
