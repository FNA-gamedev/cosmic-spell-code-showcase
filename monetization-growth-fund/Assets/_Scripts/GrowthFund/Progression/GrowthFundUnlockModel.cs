using System;
using System.Collections.Generic;
using System.Linq;
using _Scripts.GrowthFund._Shared.Consumables;
using UniRx;
using UnityEngine;
using Zenject;

namespace _Scripts.GrowthFund.Progression
{
    public class GrowthFundUnlockModel : IInitializable
    {
        private readonly IGrowthFundProgressModelProvider _progressModelProvider;
        private readonly IConsumableItemModelPool _consumableItemModelPool;
        private readonly IDisposable _disposer;
        
        public GrowthFundUnlockModel(
            IGrowthFundProgressModelProvider progressModelProvider,
            IConsumableItemModelPool consumableItemModelPool,
            IDisposable disposer)
        {
            _progressModelProvider = progressModelProvider;
            _consumableItemModelPool = consumableItemModelPool;
            _disposer = disposer;
        }
        
        public void Initialize()
        {
            foreach (var progressModel in _progressModelProvider.AllProgressModels)
            {
                SubscribePassBought(progressModel.Value);
            }
            
            _progressModelProvider.AllProgressModels
                .ObserveAdd()
                .Select(addEvent => addEvent.Value)
                .Subscribe(SubscribePassBought)
                .AddTo(_disposer as ICollection<IDisposable>);
        }
        
        private void SubscribePassBought(IGrowthFundProgressModel progressModel)
        {
            var passConsumable = progressModel.OfferModel.Packages
                .Where(package => package.Consumable.Type == ConsumableType.GrowthFundPass)
                .Select(consumable => consumable.Consumable.Id)
                .First();

            if (passConsumable != null)
            {
                var consumablePass = _consumableItemModelPool.GetConsumableItem(passConsumable);
                
                if (consumablePass == null)
                {
                    Debug.LogError($"Cannot find consumable pass ID {passConsumable} for growth fund {progressModel.GrowthFundData.GrowthFundId}");
                    
                    return;
                }

                consumablePass.Consumable?.StoredAmount
                    .Subscribe(value =>
                    {
                        if (value > 0)
                        {
                            progressModel.GrowthFundPersistence.HasBoughtOffer.Value = true;
                        }
                    })
                    .AddTo(_disposer as ICollection<IDisposable>); 
                
            }
            else
            {
                Debug.LogError($"Growth fund {progressModel.GrowthFundData.GrowthFundId} does not contain a growth fund pass consumable, offer will not be unlocked");
            }
        }
    }
}