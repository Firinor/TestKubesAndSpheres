using TMPro;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(TextMeshProUGUI))]
public class DistanceView : MonoBehaviour
{
    private TextMeshProUGUI text;
    private UnityEvent<float> newDistanceEvent;

    public void Awake()
    {
        text = GetComponent<TextMeshProUGUI>();
    }

    public void Initialize(UnityEvent<float> newDistanceEvent)
    {
        this.newDistanceEvent = newDistanceEvent;
        newDistanceEvent.AddListener(UpdateText);
    }

    private void UpdateText(float distance)
    {
        text.text = "Distance : " + distance;
    }

    private void OnDestroy()
    {
        newDistanceEvent?.RemoveListener(UpdateText);
    }
}
