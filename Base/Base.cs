using System.Collections.Generic;
using UnityEngine;

public class Base : MonoBehaviour
{
    [SerializeField] private Warehouse _warehouse;
    [SerializeField] private BaseBotsGarage _botsGarage;

    private Coroutine _coroutine;
    private WaitForSeconds _wait = new WaitForSeconds(1);

    private void Update()
    {
        GiveJobToBots();
    }

    private void GiveJobToBots()
    {
        if (_warehouse.FreeResources.Count == 0)
            return;

        Bot bot = GetNextBot();
        Resource resource = GetNextResource();

        _botsGarage.FreedBot();

        if (bot == null || resource == null)
            return;

        DispatchBot(bot, resource);
    }

    private void DispatchBot(Bot bot, Resource resource)
    {
        _warehouse.UnfreedResources(resource);
        _botsGarage.UnfreedBot(bot);

        bot.GetMission(resource);
    }

    private Bot GetNextBot() => GetNextItem(_botsGarage.FreeBots);

    private Resource GetNextResource() => GetNextItem(_warehouse.FreeResources);

    private T GetNextItem<T>(List<T> itemList)
    {
        if (itemList.Count == 0)
            return default;

        return itemList[0];
    }
}