namespace Ewone.Domain.DataLayer.DbMapper
{
    public interface IDbTransactionScope : IDisposable
    {
        void Commit();
    }
}