using ItAcademy.DataAccess.Repositories;
using ItAcademy.Database.Entities;

namespace ItAcademy.DataAccess;

public interface IUnitOfWork
{
    //Transactions 
    //Task Rollback(); 
    Task<int> Commit(CancellationToken ct);//Save -> save changes

    IArticleRepository Articles { get; }
    IRepository<Source> Sources { get; }
    IRepository<User> Users { get; }
    IRepository<Role> Roles { get; }

}