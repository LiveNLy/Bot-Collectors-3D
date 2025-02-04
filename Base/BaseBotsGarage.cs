using System.Collections.Generic;

public class BaseBotsGarage : Allocator<Bot>
{
    public List<Bot> FreeObjects => _freeObjects;

    public void UnfreedBot(Bot bot)
    {
        _occupiedObjects.Add(bot);
        _freeObjects.Remove(bot);
    }

    public void FreedBot()
    {
        foreach(Bot bot in _occupiedObjects)
        {
            if(bot.GotMission == false)
            {
                _freeObjects.Add(bot);
            }
        }

        foreach(Bot bot in _freeObjects)
        {
            _occupiedObjects.Remove(bot);
        }
    }
}