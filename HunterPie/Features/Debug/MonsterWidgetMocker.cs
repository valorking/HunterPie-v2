﻿using HunterPie.Core.Client;
using HunterPie.Core.Client.Configuration.Overlay;
using HunterPie.UI.Overlay;
using HunterPie.UI.Overlay.Widgets.Monster.ViewModels;
using HunterPie.UI.Overlay.Widgets.Monster.Views;

namespace HunterPie.Features.Debug
{
    internal class MonsterWidgetMocker : IWidgetMocker
    {
        public void Mock()
        {
            var mockConfig = ClientConfig.Config.Rise.Overlay;

            if (ClientConfig.Config.Development.MockBossesWidget)
                WidgetManager.Register<MonstersView, MonsterWidgetConfig>(
                    new MonstersView(mockConfig.BossesWidget)
                    {
                        DataContext = new MockMonstersViewModel(mockConfig.BossesWidget)
                    }
                );
        }
    }
}
