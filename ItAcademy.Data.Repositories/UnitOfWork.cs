using ItAcademy.DataAccess.Repositories;
using ItAcademy.Database;
using ItAcademy.Database.Entities;

namespace ItAcademy.DataAccess;

public class UnitOfWork : IUnitOfWork
{
    private readonly ArticleAggregatorContext _context;
    private readonly IArticleRepository _articleRepository;
    private readonly IRepository<User> _userRepository;
    private readonly IRepository<Role> _roleRepository;

    public UnitOfWork(ArticleAggregatorContext context, 
        IArticleRepository articleRepository, 
        IRepository<Source> sourceRepository, 
        IRepository<User> userRepository, 
        IRepository<Role> roleRepository)
    {
        _context = context;
        _articleRepository = articleRepository;
        Sources = sourceRepository;
        _userRepository = userRepository;
        _roleRepository = roleRepository;
    }

    public IArticleRepository Articles => _articleRepository;
    public IRepository<Source> Sources { get; }

    public IRepository<User> Users => _userRepository;
    public IRepository<Role> Roles => _roleRepository;
    
    public async Task<int> Commit(CancellationToken ct)
    {
        return await _context.SaveChangesAsync(ct);
    }
}