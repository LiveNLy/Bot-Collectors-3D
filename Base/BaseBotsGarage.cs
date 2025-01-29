using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class BaseBotsGarage : MonoBehaviour
{
    [SerializeField] private List<Bot> _freeBots;
    private List<Bot> _occupiedBots = new();

    public List<Bot> FreeBots => _freeBots;
    public List<Bot> OccupiedBots => _occupiedBots;

    public void UnfreedBot(Bot bot)
    {
        _occupiedBots.Add(bot);
        _freeBots.Remove(bot);
    }

    public void FreedBot()
    {
        foreach(Bot bot in _occupiedBots)
        {
            if(bot.GotMission == false)
            {
                _freeBots.Add(bot);
            }
        }

        foreach(Bot bot in _freeBots)
        {
            _occupiedBots.Remove(bot);
        }
    }
}