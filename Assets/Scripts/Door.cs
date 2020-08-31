using UnityEngine;

public class Door : MonoBehaviour
{
    private bool _isDoorOpen;
    
    public GameObject openedDoor;
    public GameObject closedDoor;
    
    private void Start()
    {
        openedDoor.SetActive(false);
        closedDoor.SetActive(true);
    }

    private void Update()
    {
        if (GameObject.Find("Player"))
        {
            _isDoorOpen = GameObject.Find("Player").GetComponent<Player>().doorOpen;
            
            if (_isDoorOpen)
            {
                OpenTheDoor();
            }
        }
    }

    private void OpenTheDoor()
    {
        openedDoor.SetActive(true);
        closedDoor.SetActive(false);
    }
}
