using CodeBase.StaticData;

namespace CodeBase.Infrastructure.Services
{
    public interface IStaticDataService : IService
    {
        void Load();
        HeroStaticData ForHero();
    }
}