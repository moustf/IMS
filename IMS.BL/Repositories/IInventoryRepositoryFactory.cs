namespace IMS.BL.Repositories
{
    public interface IInventoryRepositoryFactory
    {
        InventoryRepository SetWithMongoInventoryService(IInventoryService mongoService);
        InventoryRepository SetWithMsSqlInventoryService(IInventoryService msSqlService);
    }
}