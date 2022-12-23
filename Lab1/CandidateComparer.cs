namespace Lab1
{
    internal class СandidateComparer : IComparer<Сandidate>
    {
        public int Compare(Сandidate сandidate1, Сandidate сandidate2)
        {
            if (сandidate1.Mark > сandidate2.Mark)
            {
                return 1;
            }
            else if (сandidate1.Mark < сandidate2.Mark)
            {
                return -1;
            }
            else
            {
                return 0;
            }
        }
    }
}