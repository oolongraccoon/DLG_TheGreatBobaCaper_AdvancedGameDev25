using UnityEngine;

public class Collector : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D collision)
    {
        IItem item = collision.GetComponent<IItem>();//get the IItem interface from the collided object
        if (item != null)
        {
            item.Collect(); // calls the collect here

        }

        if (collision.CompareTag("Exit"))
        {
            Debug.Log("Triggered");
            GameOverManager.instance.TriggerWin("Boba Heist Successful!");
        }
    }

}
