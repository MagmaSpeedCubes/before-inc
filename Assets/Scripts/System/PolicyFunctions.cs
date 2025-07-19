using UnityEngine;
using System;
public class PolicyFunctions : MonoBehaviour
{
    //the sole purpose of this script is to house the functions of every policy

    [SerializeField] private MapRegion[] mapRegions;
    public void Support1()
    {
        for (int i = 0; i < mapRegions.Length; i++)
        {
            mapRegions[i].supportLevel += 7;
        }
    }

    public void Support2()
    {
        for (int i = 0; i < mapRegions.Length; i++)
        {
            mapRegions[i].supportLevel += 20;
        }
    }

    public void Support3()
    {
        for (int i = 0; i < mapRegions.Length; i++)
        {
            mapRegions[i].supportLevel += 35;
        }

    }

    public void Censorship()
    {

    }

    public void FakeNews()
    {

    }

    public void Education1()
    {

    }

    public void Education2()
    {

    }

    /*Emissions*/

    //Transportation

    public void TransportationInitiative()
    {
        //does nothing, just allows others to be unlocked
    }

    public void FuelEfficiency()
    {
        for (int i = 0; i < mapRegions.Length; i++)
        {
            float wealth = mapRegions[i].GetWealth();
            float population = mapRegions[i].GetPopulation();
            mapRegions[i].ReduceEmissions((float)Math.Max((wealth - 10) * 0.01, 0));
        }
    }

    public void ElectricCars()
    {
        for (int i = 0; i < mapRegions.Length; i++)
        {
            float wealth = mapRegions[i].GetWealth();
            float population = mapRegions[i].GetPopulation();
            mapRegions[i].ReduceEmissions((float)Math.Max((wealth - 30) * 0.03, 0));
            mapRegions[i].supportLevel -= (float)Math.Max((30 - wealth) * 0.15, 0);
        }
    }

    public void HybridCars()
    {
        for (int i = 0; i < mapRegions.Length; i++)
        {
            float wealth = mapRegions[i].GetWealth();
            float population = mapRegions[i].GetPopulation();
            mapRegions[i].ReduceEmissions((float)Math.Max((wealth - 15) * 0.01, 0));
            mapRegions[i].supportLevel -= (float)Math.Max((15 - wealth) * 0.05, 0);
        }
    }

    public void ElectrifyRailways()
    {
        for (int i = 0; i < mapRegions.Length; i++)
        {
            mapRegions[i].ReduceEmissions(0.15f);
        }
    }

    public void ImprovePassengerRailways()
    {
        for (int i = 0; i < mapRegions.Length; i++)
        {
            float wealth = mapRegions[i].GetWealth();
            float population = mapRegions[i].GetPopulation();
            mapRegions[i].ReduceEmissions((float)Math.Max((15 - wealth) * 0.05, 0.25));
            mapRegions[i].supportLevel += 3;
        }
    }

    public void ImproveCargoRailways()
    {
        for (int i = 0; i < mapRegions.Length; i++)
        {
            mapRegions[i].ReduceEmissions(0.5f);
        }
    }


    public void ActiveTransportation()
    {
        for (int i = 0; i < mapRegions.Length; i++)
        {
            mapRegions[i].ReduceEmissions(0.05f);
        }
    }

    // Active Transportation
    // Improve walking and bike paths in cities and encourage people to use active transportation. Slightly decreases emissions.

    // Walkable Cities
    // Rezone cities to allow for mixed use walkable developments. Decreases emissions over time. Increases support. 


}
