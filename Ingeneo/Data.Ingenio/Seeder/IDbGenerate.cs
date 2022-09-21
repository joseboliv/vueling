namespace Data.Ingenio.Seeder
{
    using System.Threading.Tasks;

    public interface IDbGenerate
    {
        Task Generate();
    }
}