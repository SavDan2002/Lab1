namespace Lab1
{
    internal class Hall : IHallForPrincess, IHall
    {
        private const int _СandidatesCount = 100;
        private List<Сandidate> _hall = new List<Сandidate>();
        private List<Сandidate> _hallSort = new List<Сandidate>();

        public Hall()
        {
            for (int i = 0; i < _СandidatesCount; i++)
            {
                _hall.Add(new Сandidate());
            }

            _hallSort.AddRange(from c in _hall orderby c.Mark select c);
        }

        public Сandidate GetNextСandidate()
        {
            Сandidate сandidate = _hall[0];
            _hall.RemoveAt(0);
            return сandidate;
        }

        public int GetСandidatesCount()
        {
            return _СandidatesCount;
        }

        public bool CheckContederInHall(IСandidateForPrincess сandidate)
        {
            return _hall.Exists(x => x.Equals(сandidate));
        }

        public int GetMarkByName(IСandidateForPrincess сandidate)
        {
            Сandidate? сandidateWithMark =
                _hallSort.Find(x => x.Name == сandidate.Name);

            return сandidateWithMark.Mark;
        }

        public int GetMark(IСandidateForPrincess сandidate)
        {
            var cc = new СandidateComparer();
            int index = _hallSort.BinarySearch((Сandidate)сandidate, cc) + 1;
            if (index <= 50) index = 0;
            return index;
        }
    }
}