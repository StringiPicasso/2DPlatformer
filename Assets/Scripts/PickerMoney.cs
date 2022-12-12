using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PickerMoney : MonoBehaviour
{
    private const string Money = "Money";

    [SerializeField] private TMP_Text _moneyText;

    private float _money;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == Money)
        {
            _money++;
            _moneyText.text = _money.ToString();
            Destroy(collision.gameObject);
        }
    }
}
