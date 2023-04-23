using Microsoft.EntityFrameworkCore;
using PCStore.Domain.Repositories;
using PCStore.Infrastructure.PCStoreDataBaseContext;

namespace PCStore.Infrastructure.Repositories;

public class UnitOfWork : IUnitOfWork
{
    protected readonly PcstoreContext databaseContext;

    public IBrandsRepository eFBrandsRepository { get; }

    public ICommentsRepository eFCommentsRepository { get; }

    public IOrdersRepository eFOrdersRepository { get; }

    public IPartOrdersRepository eFPartOrdersRepository { get; }

    public IProductsRepository eFProductsRepository { get; }

    public IStatusesRepository eFStatusesRepository { get; }

    public IUsersRepository eFUsersRepository { get; }

    public ITypesRepository EFTypesRepository { get; }

    public UnitOfWork(
        PcstoreContext databaseContext,
        IBrandsRepository eFBrandsRepository,
        ICommentsRepository eFCommentsRepository,
        IOrdersRepository eFOrdersRepository,
        IPartOrdersRepository eFPartOrdersRepository,
        IProductsRepository eFProductsRepository,
        IStatusesRepository eFStatusesRepository,
        ITypesRepository eFTypesRepository,
        IUsersRepository eFUsersRepository)
    {
        this.databaseContext = databaseContext;
        EFTypesRepository = eFTypesRepository;
        this.eFBrandsRepository = eFBrandsRepository;
        this.eFProductsRepository = eFProductsRepository;
        this.eFPartOrdersRepository = eFPartOrdersRepository;
        this.eFCommentsRepository = eFCommentsRepository;
        this.eFOrdersRepository = eFOrdersRepository;
        this.eFUsersRepository = eFUsersRepository;
        this.eFStatusesRepository = eFStatusesRepository;
    }

    public async Task SaveChangesAsync()
    {
        await databaseContext.SaveChangesAsync();
    }
}