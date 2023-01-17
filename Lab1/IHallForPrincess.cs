namespace Lab1
{
    public interface IHallForPrincess
    {
        public int GetMark(IСandidateForPrincess сandidate);
        public int GetСandidatesCount();
        public Сandidate GetNextСandidate();
    }
}