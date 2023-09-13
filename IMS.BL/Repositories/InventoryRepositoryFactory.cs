namespace IMS.BL.Repositories
{
    public class InventoryRepositoryFactory : IInventoryRepositoryFactory

    {
    private readonly InventoryRepository _inventoryRepository;

    public InventoryRepositoryFactory(InventoryRepository inventoryRepository)
    {
        _inventoryRepository = inventoryRepository;
    }


    public InventoryRepository SetWithMongoInventoryService(IInventoryService mongoService)
    {
        _inventoryRepository.SetInventoryRepository(mongoService);

        return _inventoryRepository;
    }

    public InventoryRepository SetWithMsSqlInventoryService(IInventoryService msSqlService)
    {
        _inventoryRepository.SetInventoryRepository(msSqlService);

        return _inventoryRepository;
    }
    }
}