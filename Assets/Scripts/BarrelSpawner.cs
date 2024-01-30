using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class BarrelSpawner : MonoBehaviour
{
    [SerializeField] private GameObject Barrel;
    private int delay = 8000;
    private async Task Timer()
    {
        await Task.Delay(delay);
        GenerateBarrel();
        await Timer();
    }
    
    private async void Start()
    {
        GenerateBarrel();
        await Timer();
    }

    private void GenerateBarrel()
    {
        Instantiate(Barrel, transform.position, Quaternion.identity);
    }
}
