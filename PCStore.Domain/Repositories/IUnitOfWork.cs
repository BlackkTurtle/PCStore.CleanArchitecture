namespace PCStore.Domain.Repositories;

public interface IUnitOfWork
{
    ITypesRepository EFTypesRepository { get; }
    IBrandsRepository eFBrandsRepository { get; }
    ICommentsRepository eFCommentsRepository { get; }
    IOrdersRepository eFOrdersRepository { get; }
    IPartOrdersRepository eFPartOrdersRepository { get; }
    IProductsRepository eFProductsRepository { get; }
    IStatusesRepository eFStatusesRepository { get; }
    IUsersRepository eFUsersRepository { get; }
    Task SaveChangesAsync();
}
