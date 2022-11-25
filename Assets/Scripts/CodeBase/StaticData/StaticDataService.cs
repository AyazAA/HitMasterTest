using System.Collections.Generic;
using System.Linq;
using CodeBase.Infrastructure.Services;
using UnityEngine;

namespace CodeBase.StaticData
{
    public class StaticDataService : IStaticDataService
    {
        private const string StaticDataHeroPath = "StaticData/Hero/HeroData";
        private HeroStaticData _heroData;

        public void Load() => 
            _heroData = Resources.Load<HeroStaticData>(StaticDataHeroPath);

        public HeroStaticData ForHero() => 
            _heroData != null 
                ? _heroData 
                : null;
    }
}