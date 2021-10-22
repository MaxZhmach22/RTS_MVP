using UnityEngine;

public class UnitProductionTask : IUnitProductionTask
{
    public Sprite Icon { get; }
    public float TimeLeft { get; set; }
    public float ProductionTime { get; }
    public string UnitName { get; }
    public GameObject UnitPrefab { get; }

    public UnitProductionTask(
        float time, 
        Sprite icon, 
        GameObject unitPrefab, 
        string unitName)
    {
        TimeLeft = time;
        Icon = icon;
        ProductionTime = time;
        UnitPrefab = unitPrefab;
        UnitName = unitName;
    }
}