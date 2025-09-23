using UnityEngine;
using Cinemachine;

[RequireComponent(typeof(CinemachineVirtualCamera))]
public class CameraAutoFollow : MonoBehaviour
{
    public string playerTag = "Player";     // or use a reference if you prefer
    public float searchInterval = 0.5f;     // how often to look

    CinemachineVirtualCamera vcam;
    float timer;

    void Awake()
    {
        vcam = GetComponent<CinemachineVirtualCamera>();
    }

    void Update()
    {
        // If we already have a target, stop checking
        if (vcam.Follow != null) return;

        timer -= Time.deltaTime;
        if (timer <= 0f)
        {
            timer = searchInterval;
            GameObject player = GameObject.FindGameObjectWithTag(playerTag);
            if (player)
            {
                vcam.Follow = player.transform;
            }
        }
    }
}
