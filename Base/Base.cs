using UnityEngine;

public class Base : MonoBehaviour
{
    [SerializeField] private ResourceAllocator _resourceWarehouse;
    [SerializeField] private BaseBotsGarage _botsGarage;

    private void Update()
    {
        GiveJobToBots();
    }

    private void GiveJobToBots()
    {
        if (_resourceWarehouse.FreeObjects.Count == 0)
            return;

        Bot bot = _botsGarage.GetNextItem();
        Resource resource = _resourceWarehouse.GetNextItem();

        _botsGarage.FreedBot();

        if (bot == null || resource == null)
            return;

        DispatchBot(bot, resource);
    }

    private void DispatchBot(Bot bot, Resource resource)
    {
        _resourceWarehouse.UnfreedResources(resource);
        _botsGarage.UnfreedBot(bot);

        bot.GetMission(resource);
    }
}