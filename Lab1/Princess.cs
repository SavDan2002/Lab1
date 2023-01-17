using Microsoft.Extensions.Hosting;

namespace Lab1
{
    public class Princess : IHostedService
    {
        private readonly Friend _friend;
        private readonly IHallForPrincess _hall;
        private List<IСandidateForPrincess> _topСandidates = new List<IСandidateForPrincess>();
        IHostApplicationLifetime _lifeTime;

        public Princess(IHallForPrincess hall, Friend friend, IHostApplicationLifetime lifeTime)
        {
            _friend = friend;
            _hall = hall;
            _lifeTime = lifeTime;
        }

        public bool ThinkAboutСandidate(IСandidateForPrincess сandidate)
        {
            int i = 0;
            if (_topСandidates.Count != 0)
            {
                while (i < _topСandidates.Count)
                {
                    if (_friend.CompareСandidates(сandidate, _topСandidates[i]) == true)
                    {
                        _topСandidates.Insert(i, сandidate);
                        return i == 0;
                    }

                    i++;
                }

                _topСandidates.Insert(i, сandidate);
                return false;
            }

            _topСandidates.Add(сandidate);
            return false;
        }

        public int GetMark(IСandidateForPrincess сandidate)
        {
            return _hall.GetMark(сandidate);
        }

        public void FindBestСandidate()
        {
            IСandidateForPrincess сandidate;
            for (int i = 0; i < 0.37 * _hall.GetСandidatesCount(); i++)
            {
                сandidate = _hall.GetNextСandidate();
                Console.WriteLine($"{i} сandidate: {сandidate.Name}");
                ThinkAboutСandidate(сandidate);
            }

            for (int i = (int)(0.37 * _hall.GetСandidatesCount()); i < _hall.GetСandidatesCount(); i++)
            {
                сandidate = _hall.GetNextСandidate();
                Console.WriteLine($"{i} сandidate: {сandidate.Name}");
                if (ThinkAboutСandidate(сandidate))
                {
                    Console.WriteLine($"Total score: {GetMark(сandidate)}");
                    break;
                }

                if (i == _hall.GetСandidatesCount() - 1)
                {
                    Console.WriteLine("Total score: 20");
                }
            }
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            try
            {
                FindBestСandidate();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                _lifeTime.StopApplication();
            }

            return Task.CompletedTask;
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }
    }
}