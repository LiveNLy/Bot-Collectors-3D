using System.Collections.Generic;
using UnityEngine;

public class Warehouse : MonoBehaviour
{
    private List<Resourñe> _freeResourses = new();
    private List<Resourñe> _occupiedResourses = new();

    public List<Resourñe> FreeResourses => _freeResourses;
    public List<Resourñe> OccupiedResourses => _occupiedResourses;

    public void GetFoundedResourses(Resourñe resourse)
    {
        if (resourse != null)
            _freeResourses.Add(resourse);
    }

    public void UnfreedResources(Resourñe resourse)
    {
        _occupiedResourses.Add(resourse);
        _freeResourses.Remove(resourse);
    }
}