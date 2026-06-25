using System;
using System.Collections.Generic;
using _Scripts.GrowthFund._Shared.Consumables;
using _Scripts.GrowthFund.DTOs;
using UnityEngine;

namespace _Scripts.GrowthFund.Data
{
    [Serializable]
    public class GrowthFundMilestone
    {
        [SerializeField] private int _milestoneId;
        [SerializeField] private Sprite _milestoneIcon;
        [SerializeField] private int _targetMineId;
        [SerializeField] private List<ConsumableDto> _rewards;
        [SerializeField] private List<ConditionDto> _conditions;

        public int MilestoneId => _milestoneId;
        public Sprite MilestoneIcon => _milestoneIcon;
        public int TargetMineId => _targetMineId;
        public List<ConsumableDto> Rewards => _rewards;
        public List<ConditionDto> Conditions => _conditions;

        public GrowthFundMilestone(MilestoneDto milestoneDto, Sprite milestoneIcon)
        {
            _milestoneId = milestoneDto.MilestoneId;
            _milestoneIcon = milestoneIcon;
            _targetMineId = milestoneDto.TargetMineId;
            _rewards = milestoneDto.Rewards;
            _conditions = milestoneDto.Conditions;
        }
    }
}