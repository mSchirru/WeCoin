using AutoMapper;

namespace Presentation.AutoMapper
{
    public class AutoMapperConfig
    {
        public static void RegisterMappings()
        {
            Mapper.Initialize(x =>
            {
                x.AddProfile<EntityViewModelMappingProfile>();
                x.AddProfile<ViewModelEntityMappingProfile>();
            });
        }
    }
}