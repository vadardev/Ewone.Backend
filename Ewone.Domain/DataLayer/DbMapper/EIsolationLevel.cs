namespace Ewone.Domain.DataLayer.DbMapper
{
    public enum EIsolationLevel
    {
        ReadUncommited,
        ReadCommited,
        RepeatableRead,
        Serializable
    }
}