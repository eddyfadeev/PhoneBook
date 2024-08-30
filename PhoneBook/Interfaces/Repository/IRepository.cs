namespace PhoneBook.Interfaces.Repository;

internal interface IRepository<TEntity>
{
    int AddContact(TEntity entity);
    int UpdateContact(TEntity entity);
    int DeleteContact(TEntity entity);
    TEntity? GetContact(int id);
    List<TEntity> GetAllContacts();
}