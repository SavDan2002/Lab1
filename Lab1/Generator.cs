namespace Lab1
{
    public class Generator : IGenerator
    {
        public List<Сandidate> CreateListСandidate()
        {
            var candidates = new List<Сandidate>();
            for (int i = 0; i < 100; i++)
            {
                candidates.Add(new Сandidate());
            }
            return candidates;
        }
    }
}
