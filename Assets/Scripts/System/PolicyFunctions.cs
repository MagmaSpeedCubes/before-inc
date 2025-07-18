using UnityEngine;

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
}
