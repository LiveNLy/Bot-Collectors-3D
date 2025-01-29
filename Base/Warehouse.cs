using System.Collections.Generic;
using UnityEngine;

public class Warehouse : MonoBehaviour
{
    private List<Resour�e> _freeResourses = new();
    private List<Resour�e> _occupiedResourses = new();

    public List<Resour�e> FreeResourses => _freeResourses;
    public List<Resour�e> OccupiedResourses => _occupiedResourses;

    public void GetFoundedResourses(Resour�e resourse)
    {
        if (resourse != null)
            _freeResourses.Add(resourse);
    }

    public void UnfreedResources(Resour�e resourse)
    {
        _occupiedResourses.Add(resourse);
        _freeResourses.Remove(resourse);
    }
}