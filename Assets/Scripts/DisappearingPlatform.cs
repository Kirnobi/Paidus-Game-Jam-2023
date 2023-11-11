using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisappearingPlatform : MonoBehaviour
{
    public GameObject platform;
    public float interval;
    IEnumerator Start()
    {
        while (true)
        {
            yield return new WaitForSeconds(interval);
            platform.SetActive(!platform.activeSelf);
        }
    }
}
