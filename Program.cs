using hwLesson17;

namespace hwLesson17
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var candidates = new List<Candidate>()
            {
                new Candidate("Maria", 2006, 2.1),
                new Candidate("Paul", 2000, 3.2),
                new Candidate("Mark", 1997, 0.3),
                new Candidate("Sarah", 1999, 5.6),
                new Candidate("Sonya", 2000, 7),
                new Candidate("John", 1977, 15.2),
                new Candidate("Mona", 1967, 15),
                new Candidate("Connor", 1999, 5)
            };

            Candidate bestCandidate = candidates.Where(x => x.Experience > 1 && x.YearOfBirth < 2005)
                .OrderByDescending(x => x.Experience).First();

            MailSender.SendMessageConfirmation(bestCandidate, 200000);

            candidates.Where(x => x.Name != bestCandidate.Name && x.Experience != bestCandidate.Experience).ToList()
                .ForEach(x => MailSender.SendMessageDecline(x));
        }
    }
}
