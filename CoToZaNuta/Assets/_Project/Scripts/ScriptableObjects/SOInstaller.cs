using UnityEngine;
using Zenject;

[CreateAssetMenu(fileName = "SOInstaller", menuName = "Installers/SOInstaller")]
public class SOInstaller : ScriptableObjectInstaller<SOInstaller>
{
    public Categories categories;
    
    public override void InstallBindings()
    {
        Container.BindInstance(categories).IfNotBound();
    }
}