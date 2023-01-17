namespace Lab1
{
    public class Сandidate : IСandidateForPrincess
    {
        public string Name { get; private set; } = null;
        public int Mark { get; private set; } = -1;
        
        public Сandidate()
        {
            Name = Randomizer.GetRandomName();
            Mark = Randomizer.GetRandomWithoutRepeatMark();
        }
        
        public override bool Equals(object obj)
        {
            Сandidate сandidate = (Сandidate)obj;
            return (сandidate.Name == Name && сandidate.Mark == Mark);
        }
    }
}
