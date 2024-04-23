using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinController : MonoBehaviour
{
    [SerializeField] SaveableItem _coinItem;
    [SerializeField] int _amount;
    private void Awake()
    {
        this.gameObject.SetActive(false);

        //if(PlayerPrefs.GetInt($"{this.gameObject.transform.parent.name}Coin", 0).Equals(1))
        //{
        //    Destroy(gameObject);
        //}
    }
    private void OnTriggerEnter(Collider iCollidedObject)
    {
        if (iCollidedObject.CompareTag(Abs.Tags.BallTag))
        {

            if (_coinItem._ChangeAmount(_amount, false))
            {
                PlayerPrefs.SetInt($"{this.gameObject.transform.parent.name}Coin", 1);
                Destroy(gameObject);
            }
        }
    }
}
