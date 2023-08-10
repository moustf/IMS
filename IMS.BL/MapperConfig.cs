using AutoMapper;

namespace IMS.BL
{
    public class MapperConfig
    {
        public Mapper InitializeAutomapper()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<ProductData, Product>();
            });

            return new Mapper(config);
        }
    }
}