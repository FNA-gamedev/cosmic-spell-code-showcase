using System.Collections.Generic;
using System.Linq;

namespace _Scripts.GrowthFund.Persistence
{
    public class GrowthFundPersistenceProvider : IGrowthFundPersistenceProvider
    {
        private readonly GrowthFundSavegame _growthFundSavegame;
        private readonly GrowthFundPersistence.IFactory _growthFundPersistenceFactory;
        private readonly Dictionary<int, IGrowthFundPersistence> _growthFundPersistenceMapping;

        public GrowthFundPersistenceProvider(GrowthFundSavegame growthFundSavegame,
            GrowthFundPersistence.IFactory growthFundPersistenceFactory)
        {
            _growthFundSavegame = growthFundSavegame;
            _growthFundPersistenceFactory = growthFundPersistenceFactory;

            _growthFundPersistenceMapping = _growthFundSavegame.GrowthFundProgress
                .ToDictionary(savegame => savegame.Id, _growthFundPersistenceFactory.Create);
        }

        public IGrowthFundPersistence GetGrowthFundPersistence(int growthFundId)
        {
            return _growthFundPersistenceMapping.TryGetValue(growthFundId, out var persistence)
                ? persistence
                : CreateGrowthFundPersistence(growthFundId);
        }
        
        private IGrowthFundPersistence CreateGrowthFundPersistence(int growthFundId)
        {
            var savegame = new GrowthFundProgressSavegame { Id = growthFundId };
            _growthFundSavegame.GrowthFundProgress.Add(savegame);

            var newPersistence = _growthFundPersistenceFactory.Create(savegame);
            _growthFundPersistenceMapping.Add(growthFundId, newPersistence);

            return newPersistence;
        }
    }
}