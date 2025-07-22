using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
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

        string title = "Global Climate Cooperation";
        string text = "In a rare move, regions around the globe have agreed to work together to prevent climate change";
        PopupWindow.ShowPopupWindowDelayed(null, title, text, 3f);

    }

    public void Censorship()
    {
        StartCoroutine(CensorshipCoroutine());
    }

    private IEnumerator CensorshipCoroutine()
    {
        float startTick = Mathf.Floor(Timer.GetTime());
        int ticksRun = 0;
        float lastTick = startTick;

        // Store the original support levels
        float[] originalSupportLevels = new float[mapRegions.Length];
        for (int i = 0; i < mapRegions.Length; i++)
        {
            originalSupportLevels[i] = mapRegions[i].supportLevel;
        }

        while (ticksRun < 24)
        {
            float currentTick = Mathf.Floor(Timer.GetTime());
            if (currentTick > lastTick)
            {
                // Freeze supportLevel each tick
                for (int i = 0; i < mapRegions.Length; i++)
                {
                    mapRegions[i].supportLevel = originalSupportLevels[i];
                }
                ticksRun++;
                lastTick = currentTick;
            }
            yield return null;
        }

        // After 24 ticks, drop supportLevel by 10
        for (int i = 0; i < mapRegions.Length; i++)
        {
            mapRegions[i].supportLevel -= 10f;
        }

        int randomIndex = UnityEngine.Random.Range(0, mapRegions.Length);
        MapRegion randomRegion = mapRegions[randomIndex];
        string regionName = randomRegion.GetName();
        string title = regionName + " thwarts censorship attempts";
        string text = "The censorship initiative is being uncovered by " + regionName + " journalists. Support no longer frozen.";
        PopupWindow.ShowPopupWindow(null, title, text);
    }
    public void FakeNews()
    {
        StartCoroutine(FakeNewsCoroutine());
    }

    private IEnumerator FakeNewsCoroutine()
    {
        float startTick = Mathf.Floor(Timer.GetTime());
        int ticksRun = 0;
        float lastTick = startTick;

        // Store the original support levels
        float[] originalSupportLevels = new float[mapRegions.Length];
        for (int i = 0; i < mapRegions.Length; i++)
        {
            originalSupportLevels[i] = mapRegions[i].supportLevel;
        }

        while (ticksRun < 24)
        {
            float currentTick = Mathf.Floor(Timer.GetTime());
            if (currentTick > lastTick)
            {
                // Freeze supportLevel each tick
                for (int i = 0; i < mapRegions.Length; i++)
                {
                    mapRegions[i].supportLevel = originalSupportLevels[i];
                }
                ticksRun++;
                lastTick = currentTick;
            }
            yield return null;
        }

        // After 24 ticks, drop supportLevel by 10
        for (int i = 0; i < mapRegions.Length; i++)
        {
            mapRegions[i].supportLevel -= 20f;
        }
        int randomIndex = UnityEngine.Random.Range(0, mapRegions.Length);
        MapRegion randomRegion = mapRegions[randomIndex];
        string regionName = randomRegion.GetName();
        string title = regionName + " debunks fake news";
        string text = "The fake news initiative is being uncovered by " + regionName + " journalists. Support no longer frozen.";
        PopupWindow.ShowPopupWindow(null, title, text);
    }

    public void Education1()
    {
        StartCoroutine(EducationCoroutine());
    }

    public void Education2()
    {
        StartCoroutine(EducationCoroutine());
    }

    private IEnumerator EducationCoroutine()
    {
        float startTick = Mathf.Floor(Timer.GetTime());
        int ticksRun = 0;
        float lastTick = startTick;

        while (ticksRun < 24)
        {
            float currentTick = Mathf.Floor(Timer.GetTime());
            if (currentTick > lastTick)
            {
                // Run your command once per tick
                for (int i = 0; i < mapRegions.Length; i++)
                {
                    mapRegions[i].supportLevel += 0.5f;
                }
                ticksRun++;
                lastTick = currentTick;
            }
            yield return null;
        }

    }

    public void Taxes1()
    {
        for (int i = 0; i < mapRegions.Length; i++)
        {
            float wealth = mapRegions[i].GetWealth();
            if (wealth >= 40)
            {
                mapRegions[i].contributionLevel += 0.5f;
            }

        }
    }

    public void Taxes2()
    {
        for (int i = 0; i < mapRegions.Length; i++)
        {
            float wealth = mapRegions[i].GetWealth();
            if (wealth >= 25)
            {
                mapRegions[i].contributionLevel += 0.5f;
                mapRegions[i].supportLevel -= 5f;
            }

        }
    }

    public void Taxes3()
    {
        for (int i = 0; i < mapRegions.Length; i++)
        {
            float wealth = mapRegions[i].GetWealth();
            if (wealth >= 12)
            {
                mapRegions[i].contributionLevel += 0.5f;
                mapRegions[i].supportLevel -= 10f;
            }

        }

        int randomIndex = UnityEngine.Random.Range(0, mapRegions.Length);
        MapRegion randomRegion = mapRegions[randomIndex];
        string regionName = randomRegion.GetName();
        string title = "People of " + regionName + " fed up with taxes";
        string text = "Citizens from the region of " + regionName + " are tired of working long hours only to lose the majority of their income";
        PopupWindow.ShowPopupWindowDelayed(null, title, text, 3f);
    }

    public void Taxes4()
    {
        for (int i = 0; i < mapRegions.Length; i++)
        {
            float wealth = mapRegions[i].GetWealth();

            mapRegions[i].contributionLevel += 0.5f;
            mapRegions[i].supportLevel -= 20f;

        }


    }

    public void CarbonCredits()
    {
        for (int i = 0; i < mapRegions.Length; i++)
        {
            float wealth = mapRegions[i].GetWealth();
            if (wealth >= 25)
            {
                mapRegions[i].ReduceEmissions(mapRegions[i].GetEmissions() / 10);
            }

        }

    }

    public void CarbonTax()
    {
        List<MapRegion> eligibleRegions = new List<MapRegion>();
        for (int i = 0; i < mapRegions.Length; i++)
        {
            float wealth = mapRegions[i].GetWealth();
            mapRegions[i].ReduceEmissions(mapRegions[i].GetEmissions() / 10);
            mapRegions[i].contributionLevel *= 1.2f;

            if (wealth <= 25)
            {
                eligibleRegions.Add(mapRegions[i]);
                mapRegions[i].supportLevel -= 6;
            }
            if (eligibleRegions.Count > 0)
            {
                int randomIndex = UnityEngine.Random.Range(0, eligibleRegions.Count);
                MapRegion randomRegion = eligibleRegions[randomIndex];

                string regionName = randomRegion.GetName();
                string title = regionName + " Leader Criticizes Carbon Tax";
                string text = "Conservative leaders of " + regionName + " claim that a carbon tax would only harm working people and do little to save the planet";
                PopupWindow.ShowPopupWindow(null, title, text);
            }

        }
    }


    /*Emissions*/

    //Transportation

    public void TransportationInitiative()
    {
        int randomIndex = UnityEngine.Random.Range(0, mapRegions.Length);
        MapRegion randomRegion = mapRegions[randomIndex];
        string regionName = randomRegion.GetName();
        string title = regionName + " Plans to build new transportation infrastructure";
        string text = "Leaders of " + regionName + " aim to overhaul the region's aging transportation network";
        PopupWindow.ShowPopupWindowDelayed(null, title, text, 3f);
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

        int randomIndex = UnityEngine.Random.Range(0, mapRegions.Length);
        MapRegion randomRegion = mapRegions[randomIndex];
        string regionName = randomRegion.GetName();
        string title = regionName + " urbanist criticizes electric cars";
        string text = "An urbanist based in " + regionName + " states that electric cars will do little to actually solve the climate crisis";
        PopupWindow.ShowPopupWindowDelayed(null, title, text, 3f);
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

    public void WalkableCities()
    {
        StartCoroutine(WalkableCitiesCoroutine());
    }
    private IEnumerator WalkableCitiesCoroutine()
    {
        float startTick = Mathf.Floor(Timer.GetTime());
        int ticksRun = 0;
        float lastTick = startTick;

        while (ticksRun < 24)
        {
            float currentTick = Mathf.Floor(Timer.GetTime());
            if (currentTick > lastTick)
            {
                // Run your command once per tick
                for (int i = 0; i < mapRegions.Length; i++)
                {
                    mapRegions[i].ReduceEmissions(0.01f);
                }
                ticksRun++;
                lastTick = currentTick;
            }
            yield return null;
        }

        // After 24 ticks, run your end command
        for (int i = 0; i < mapRegions.Length; i++)
        {
            mapRegions[i].supportLevel += 3; // Example end command
        }
    }

    public void EnergyInitiative()
    {
        int randomIndex = UnityEngine.Random.Range(0, mapRegions.Length);
        MapRegion randomRegion = mapRegions[randomIndex];
        string regionName = randomRegion.GetName();
        string title = regionName + " Prepares for transition to green energy";
        string text = "The progressive leaders of " + regionName + " claims that climate change is the greatest threat to humanity and radical changes must be made to prevent them";
        PopupWindow.ShowPopupWindowDelayed(null, title, text, 3f);
        //this policy does not change any values, it only allows others to be unlocked.
    }


    // Insulation
    // Retrofit buildings to decrease thermal transfer and retain indoor temperatures. Decreases emissions.

    // Electric Appliances
    // Redesign existing household appliances to run on electrical power. Slightly decreases emissions.

    // Energy Efficient Appliances
    // Research and develop household appliances designed to run on low energy. Decreases emissions.

    // LED Lighting
    // Invest in and encourage the use of LED light bulbs. Slightly decreases emissions. 

    // Renewable Energy
    // Invest in and construct solar and wind power plants to generate clean energy. Significantly decreases emissions. Slightly increases support.

    // Nuclear Energy
    // Invest in and construct nuclear power plants to generate clean energy. Significantly decreases emissions. Slightly decreases support.

    // Cleaner Coal
    // Retrofit older fossil fuel power plants to run more efficiently and produce less pollution. Slightly decreases emissions. Decreases support.












}
