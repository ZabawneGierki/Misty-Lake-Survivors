using UnityEngine;
using Cinemachine;
using System.Collections;

[RequireComponent(typeof(CinemachineVirtualCamera))]
public class CameraAutoFollow : MonoBehaviour
{
    public string playerTag = "Player";
    public string levelTag = "LevelGrid";
    public float searchInterval = 0.5f;

    CinemachineVirtualCamera vcam;
    CinemachineConfiner2D confiner;

    void Awake()
    {
        vcam = GetComponent<CinemachineVirtualCamera>();
        confiner = GetComponent<CinemachineConfiner2D>();
        
        // Start both search coroutines
        StartCoroutine(SearchForPlayer());
        StartCoroutine(SearchForLevel());
    }

    IEnumerator SearchForPlayer()
    {
        while (vcam.Follow == null)
        {
            GameObject player = GameObject.FindGameObjectWithTag(playerTag);
            if (player)
            {
                vcam.Follow = player.transform;
                yield break; // Stop coroutine once player is found
            }
            yield return new WaitForSeconds(searchInterval);
        }
    }

    IEnumerator SearchForLevel()
    {
        while (confiner.m_BoundingShape2D == null)
        {
            GameObject level = GameObject.FindGameObjectWithTag(levelTag);
            if (level)
            {
                Debug.Log("Found level for confiner");
                var confinerTarget = level.GetComponent<PolygonCollider2D>();
                if (confinerTarget)
                {
                    confiner.m_BoundingShape2D = confinerTarget;
                    yield break; // Stop coroutine once level is found
                }
            }
            yield return new WaitForSeconds(searchInterval);
        }
    }
}
