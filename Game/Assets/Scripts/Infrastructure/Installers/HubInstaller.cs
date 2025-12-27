using Zenject;
using UnityEngine;

public class HubInstaller : MonoInstaller
{
    [SerializeField] private HubCanvasManager hubCanvas;
    [SerializeField] private TraderPanelManager traderPanel;

    public override void InstallBindings()
    {
        Container.BindInstance(hubCanvas).AsSingle();
        Container.BindInstance(traderPanel).AsSingle();
    }
}