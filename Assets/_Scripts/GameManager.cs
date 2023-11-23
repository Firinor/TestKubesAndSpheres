using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class Gamemanager : MonoBehaviour
{
    [SerializeField]
    private float nextSceneDistance;
    [SerializeField]
    private float spheresDistance;

    [SerializeField]
    private CubeController red;
    [SerializeField]
    private CubeController green;
    [SerializeField]
    private DistanceView distanceText;
    [SerializeField]
    private GameObject SpheresParent;

    [HideInInspector]
    public UnityEvent<float> NewDistanceEvent = new();

    void Start()
    {
        distanceText.Initialize(NewDistanceEvent);

        red.MoveEvent.AddListener(CheckDistanceBetweenCubes);
        green.MoveEvent.AddListener(CheckDistanceBetweenCubes);
    }

    private void CheckDistanceBetweenCubes()
    {
        float distance = Vector3.Distance(red.transform.position, green.transform.position);

        if (distance < nextSceneDistance)
            SceneManager.LoadScene(1);
        else
        {
            bool activity = distance < spheresDistance;
            SpheresParent.SetActive(activity);

            NewDistanceEvent?.Invoke(distance);
        }
    }

    private void OnDestroy()
    {
        red?.MoveEvent.RemoveListener(CheckDistanceBetweenCubes);
        green?.MoveEvent.RemoveListener(CheckDistanceBetweenCubes);
    }
}
