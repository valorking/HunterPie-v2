﻿using HunterPie.Core.Architecture;
using HunterPie.Core.Client.Configuration.Overlay;
using HunterPie.UI.Architecture.Graphs;
using LiveCharts;
using LiveCharts.Defaults;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace HunterPie.UI.Overlay.Widgets.Damage.ViewModel
{
    public class MeterViewModel : Bindable
    {
        public DamageMeterWidgetConfig Settings { get; internal set; }
        private double _timeElapsed = 1;
        private int _deaths;
        private bool _inHuntingZone;
        private ObservableCollection<PlayerViewModel> _players = new();

        public Func<double, string> TimeFormatter { get; } = 
            new Func<double, string>((value) => TimeSpan.FromSeconds(value).ToString("mm\\:ss"));

        public Func<double, string> DPSFormatter { get; } =
            new Func<double, string>((value) => $"{value:0.00}/s");

        public List<ChartValues<ObservablePoint>> PlayerChartValues { get; } = new();
        public SeriesCollection Series { get; protected set; } = new();

        public ObservableCollection<PlayerViewModel> Players { get => _players; private set { SetValue(ref _players, value); } }

        public double TimeElapsed
        {
            get => _timeElapsed;
            set { SetValue(ref _timeElapsed, value); }
        }

        public int Deaths
        {
            get => _deaths;
            set { SetValue(ref _deaths, value); }
        }

        public bool InHuntingZone { get => _inHuntingZone; set { SetValue(ref _inHuntingZone, value); } }

        public void ToggleHighlight() => Settings.ShouldHighlightMyself.Value = !Settings.ShouldHighlightMyself;
        public void ToggleBlur() => Settings.ShouldBlurNames.Value = !Settings.ShouldBlurNames;

        public void SortPlayers()
        {
            Players = new(Players.OrderByDescending(e => e.Damage));
        }
    }
}
