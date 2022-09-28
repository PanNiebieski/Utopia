namespace DeclarationPlus.Domain.Scoring
{
    public interface IScoringRejectRule
    {
        bool IsSatisfiedBy(/*Declaration  dec*/);

        string Message { get; }
    }
}