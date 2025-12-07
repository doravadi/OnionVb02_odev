using OnionVb02.WebApi.MappingProfiles;

namespace OnionVb02.WebApi.DependencyResolvers
{
    public static class VmMapperResolver
    {
        public static void AddVmMapperService(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(VmMappingProfile));
        }
    }
}
