namespace Data.GNB.Seeder
{
    using System.Threading.Tasks;

    public interface IDbGenerate
    {
        Task Generate();
    }
}