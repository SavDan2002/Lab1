namespace Lab1
{
    internal class Сandidate : IСandidateForPrincess
    {
        public string Name { get; private set; } = null;
        public int Mark { get; private set; } = -1;
        
        private void InitСandidate()
        {
            Name = Randomizer.GetRandomName();
            Mark = Randomizer.GetRandomWithoutRepeatMark();
        }
        public Сandidate()
        {
            InitСandidate();
        }
        
        public override bool Equals(object obj)
        {
            Сandidate сandidate = (Сandidate)obj;
            return (сandidate.Name == Name && сandidate.Mark == Mark);
        }
    }
}
