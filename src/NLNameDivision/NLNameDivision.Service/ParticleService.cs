using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.Configuration;
using NLNameDivision.Constant;
using NLNameDivision.Service.Abstraction;

namespace NLNameDivision.Service
{
    public class ParticleService : IParticleService
    {
        private static List<string> _particleListLoaded;
        private readonly IConfiguration _configuration;
        
        public ParticleService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public List<string> ReportParticleList() =>
            GetParticleList();

        public bool IsParticle(string valueToVerify) =>
            GetParticleList().Any(x => x.Equals(valueToVerify, StringComparison.InvariantCultureIgnoreCase));
        
        private List<string> GetParticleList()
        {
            if (IsParticleListUnloaded()) LoadParticleList();
            return _particleListLoaded;
        }

        private bool IsParticleListUnloaded() => (_particleListLoaded == default);

        private void LoadParticleList() =>
            _particleListLoaded = SplitParticleListConfigValue(GetParticleListConfigValue()).ToList();
        
        private string GetParticleListConfigValue() =>
            _configuration.GetSection(ParticleConstant.ListEnvironmentVariable).Value ??
            ParticleConstant.ListDefault;

        private string[] SplitParticleListConfigValue(string particleConfigValue) =>
            particleConfigValue.Split(ParticleConstant.ListSplitChar);
    }
}