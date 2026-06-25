using System.Collections.Generic;
using _Scripts.GrowthFund._Shared.Analytics;
using _Scripts.GrowthFund._Shared.Consumables;

namespace _Scripts.GrowthFund.DataEvents
{
    public class GrowthFundEventDataService : IGrowthFundEventDataService
    {
        private readonly ITransactionHandlerService _transactionHandlerService;
        private readonly ITransactionDataGenerator _transactionDataGenerator;
        private readonly IAnalyticsBus _analyticsBus;

        public GrowthFundEventDataService(
            ITransactionHandlerService transactionHandlerService,
            ITransactionDataGenerator transactionDataGenerator,
            IAnalyticsBus analyticsBus)
        {
            _transactionHandlerService = transactionHandlerService;
            _transactionDataGenerator = transactionDataGenerator;
            _analyticsBus = analyticsBus;
        }

        public void SendMilestoneRewardCollectedEconomyTransaction(
            int growthFundId,
            int milestoneId,
            int lastMilestoneUnlocked,
            IEnumerable<IConsumablePackage> consumablesReceived)
        {
            _transactionHandlerService
                .OnTransactionBatch(
                    TransactionSource.GrowthFundMilestone,
                    transactionsReceived: _transactionDataGenerator.ConsumablePackagesToTransactionData(consumablesReceived),
                    sourceContext: AnalyticsContextGenerator.GrowthFundRewardCollected(growthFundId, milestoneId, lastMilestoneUnlocked)
                );
        }

        public void SendMilestoneReachedDataEvent(
            int growthFundId,
            int milestoneId,
            bool isFinalMilestone,
            bool isGrowthFundBought)
        {
            var payload = new GrowthFundMilestoneReachedPayload
            {
                GrowthFundId = growthFundId,
                GrowthFundMilestoneID = milestoneId,
                GrowthFundFinalMilestone = isFinalMilestone,
                GrowthFundBought = isGrowthFundBought
            };

            _analyticsBus.Publish(payload);
        }

        public void OnBubbleClicked(
            int growthFundId,
            string liveOfferId,
            bool hasBoughtOffer)
        {
            _analyticsBus.Publish(new UiInteractionPayload
            {
                GameObjectName = GrowthFundConstants.K_growthFundBubbleEventName,
                Trigger = GrowthFundConstants.K_growthFundBubbleClicked,
                Context = GetGrowthFundUIContext(growthFundId, liveOfferId, hasBoughtOffer)
            });
        }

        public void OnShopClicked(int growthFundId, string liveOfferId, bool hasBoughtOffer)
        {
            _analyticsBus.Publish(new UiInteractionPayload
            {
                GameObjectName = GrowthFundConstants.K_growthFundShopEventName,
                Trigger = GrowthFundConstants.K_growthFundShopClicked,
                Context = GetGrowthFundUIContext(growthFundId, liveOfferId, hasBoughtOffer)
            });
        }

        public void OnPanelOpen(
            int growthFundId,
            string liveOfferId,
            bool growthFundBought,
            int lastMilestoneUnlocked,
            string source,
            bool isOpen)
        {
            _analyticsBus.Publish(new UiInteractionPayload
            {
                PanelName = GrowthFundConstants.K_growthFundMainPanelName,
                Trigger = isOpen
                    ? GrowthFundConstants.K_growthFundMainPanelOpen
                    : GrowthFundConstants.K_growthFundMainPanelClose,
                Source = source,
                Context = GetGrowthFundUIContext(growthFundId, liveOfferId, growthFundBought, lastMilestoneUnlocked)
            });
        }

        public void OnPurchasePopupOpen(
            int growthFundId,
            string liveOfferId,
            int milestoneId,
            int lastMilestoneUnlocked,
            bool isOpen)
        {
            _analyticsBus.Publish(new UiInteractionPayload
            {
                PanelName = GrowthFundConstants.K_growthFundMainPanelName,
                Trigger = isOpen
                    ? GrowthFundConstants.K_growthFundPurchasePanelOpen
                    : GrowthFundConstants.K_growthFundPurchasePanelClosed,
                Source = string.Format(GrowthFundConstants.K_growthFundMilestoneName, milestoneId),
                Context = new Dictionary<string, string>
                {
                    { AnalyticsContextKeys.GrowthFundId.ToString(), growthFundId.ToString() },
                    {
                        AnalyticsContextKeys.GrowthFundLastMilestoneUnlocked.ToString(),
                        lastMilestoneUnlocked.ToString()
                    }
                }
            });
        }

        public void OnMilestoneClicked(
            int milestoneId,
            int growthFundId,
            string liveOfferId,
            bool growthFundBought,
            int lastMilestoneUnlocked)
        {
            _analyticsBus.Publish(new UiInteractionPayload
            {
                PanelName = GrowthFundConstants.K_growthFundMainPanelName,
                GameObjectName = string.Format(GrowthFundConstants.K_growthFundMilestoneName, milestoneId),
                Trigger = GrowthFundConstants.K_growthFundMilestoneClicked,
                Context = GetGrowthFundUIContext(growthFundId, liveOfferId, growthFundBought, lastMilestoneUnlocked)
            });
        }

        public void OnBuyGrowthFundClicked(
            int growthFundId,
            string liveOfferId,
            bool growthFundBought,
            int lastMilestoneUnlocked)
        {
            _analyticsBus.Publish(new UiInteractionPayload
            {
                PanelName = GrowthFundConstants.K_growthFundMainPanelName,
                GameObjectName = GrowthFundConstants.K_growthFundBuyIapEventName,
                Trigger = GrowthFundConstants.K_growthFundBuyIapClicked,
                Context = GetGrowthFundUIContext(growthFundId, liveOfferId, growthFundBought, lastMilestoneUnlocked)
            });
        }

        public void OnInterstitialOpenTriggered(
            int growthFundId,
            string liveOfferId,
            bool growthFundBought,
            int lastMilestoneUnlocked,
            string source,
            bool isOpen)
        {
            _analyticsBus.Publish(new UiInteractionPayload
            {
                PanelName = GrowthFundConstants.K_growthFundInsterstitialPanelName,
                Trigger = isOpen
                    ? GrowthFundConstants.K_growthFundInterstitialPanelOpen
                    : GrowthFundConstants.K_growthFundInterstitialPanelClose,
                Source = source,
                Context = new Dictionary<string, string>
                {
                    { AnalyticsContextKeys.GrowthFundId.ToString(), growthFundId.ToString() },
                    {
                        AnalyticsContextKeys.GrowthFundLastMilestoneUnlocked.ToString(),
                        lastMilestoneUnlocked.ToString()
                    }
                }
            });
        }

        private Dictionary<string, string> GetGrowthFundUIContext(
            int growthFundId, 
            string liveOfferId,
            bool growthFundBought,
            int lastMilestoneUnlocked = -1)
        {
            var context = new Dictionary<string, string>
            {
                { AnalyticsContextKeys.GrowthFundId.ToString(), growthFundId.ToString() },
                { AnalyticsContextKeys.GrowthFundBought.ToString(), growthFundBought.ToString() },
            };
            
            if (lastMilestoneUnlocked > -1)
                context.Add(AnalyticsContextKeys.GrowthFundLastMilestoneUnlocked.ToString(), lastMilestoneUnlocked.ToString());

            return context;
        }
    }
}