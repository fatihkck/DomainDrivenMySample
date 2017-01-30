using Infrastructure.Caching;
using Infrastructure.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationServices.Implementations
{
    public abstract class ImplementationCacheService
    {

        private readonly ICacheManager _cacheManager;
        private readonly IConfigurationRepository _configurationRepository;


        public ImplementationCacheService(ICacheManager cacheManager, IConfigurationRepository configurationRepository
)
        {
            if (cacheManager == null) throw new ArgumentNullException("CacheStorage");
            if (configurationRepository == null) throw new ArgumentNullException("ConfigurationRepository");

            _cacheManager = cacheManager;
            _configurationRepository = configurationRepository;
        }

        protected ICacheManager CacheManager
        {
            get {
                return _cacheManager;
            }
        }

        protected IConfigurationRepository ConfigurationRepository
        {
            get
            {
                return _configurationRepository;
            }
        }
    }
    
}
