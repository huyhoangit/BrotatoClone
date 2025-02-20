using UnityEngine;

public class Coin : MonoBehaviour
{
    #region Variables
    public float rotationSpeed = 100f;
    #endregion

    #region Mono Methods
    void Start()
    {

    }

    void Update()
    {
        RotateCoin();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Player player = other.GetComponent<Player>();
            if (player != null)
            {
                player.IncreaseCoins(1);
                Debug.Log("Player collected a coin!");
            }

            Destroy(gameObject);
        }
    }
    #endregion

    #region Methods
    private void RotateCoin()
    {
        transform.Rotate(Vector3.up * rotationSpeed * Time.deltaTime);
    }
    #endregion
}
