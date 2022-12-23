namespace Lab1
{
    internal class Friend
    {
        private readonly IHall _hall;

        public Friend(IHall hall)
        {
            _hall = hall;
        }

        public bool CompareСandidates(IСandidateForPrincess сandidate1, IСandidateForPrincess сandidate2)
        {
            return _hall.GetMarkByName(сandidate1) > _hall.GetMarkByName(сandidate2);
        }
    }
}