namespace Lab1
{
    internal interface IHallForPrincess
    {
        public int GetMark(IСandidateForPrincess сandidate);
        public int GetСandidatesCount();
        public Сandidate GetNextСandidate();
    }
}