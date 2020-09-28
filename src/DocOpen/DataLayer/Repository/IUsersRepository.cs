namespace DocOpen.Data
{
    public interface IUsersRepository : IDataRepository<User>
    {
         int Commit();
    }
}