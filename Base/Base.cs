using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Base : MonoBehaviour
{
    [SerializeField] private Warehouse _warehouse;
    [SerializeField] private BaseBotsGarage _botsGarage;
    [SerializeField] private BaseScanerForResourses _scanerForResourses;

    private Coroutine _coroutine;
    private WaitForSeconds _wait = new WaitForSeconds(1);

    private void Start()
    {
        _coroutine = StartCoroutine(CheckScaner());
    }

    private void Update()
    {
        GiveJobToBots();
    }

    private void GiveJobToBots()
    {
        if (_warehouse.FreeResourses.Count == 0)
            return;

        Bot bot = GetNextBot();
        Resourñe resource = GetNextResource();

        _botsGarage.FreedBot();

        if (bot == null || resource == null)
            return;

        DispatchBot(bot, resource);
    }

    private void DispatchBot(Bot bot, Resourñe resource)
    {
        _warehouse.UnfreedResources(resource);
        _botsGarage.UnfreedBot(bot);

        bot.GetMission(resource);
    }

    private Bot GetNextBot() => GetNextItem(_botsGarage.FreeBots);

    private Resourñe GetNextResource() => GetNextItem(_warehouse.FreeResourses);

    private T GetNextItem<T>(List<T> itemList)
    {
        if (itemList.Count == 0)
            return default;

        return itemList[0];
    }

    private IEnumerator CheckScaner()
    {
        while (enabled)
        {
            _warehouse.GetFoundedResourses(_scanerForResourses.GetResourse());

            yield return _wait;
        }
    }
}