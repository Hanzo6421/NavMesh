using UnityEngine;

public class CollectItems : MonoBehaviour
{
    public SlidingDoors door;
    public int collectedItems;
    public int requiredItems = 3;

    public string collectableTag = "Collectable";

    // Update is called once per frame
    void Update()
    {
        if (collectedItems >= requiredItems)
        {
            door.OpenTheDoor();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == collectableTag)
        {
            collectedItems++;
            Destroy(other.gameObject);
        }
    }
}
