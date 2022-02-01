using System.Threading.Tasks;
using Module4HW6.Helpers;

namespace Module4HW6
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            await using (var context = new SampleContextFactory().CreateDbContext(args))
            {
                var init = new DbInit(context, new GoTransaction(context));
                await init.InitializeArtistTable();
                await init.InitializeGenreTable();
                await init.InitializeSongTable();

                await new Queries(context).FirstQuery();
                await new Queries(context).SecondQuery();
                await new Queries(context).ThirdQuery();
            }
        }
    }
}