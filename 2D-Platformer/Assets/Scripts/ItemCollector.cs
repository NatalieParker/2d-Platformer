using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ItemCollector : MonoBehaviour
{
    private int bananaCount = 0;
    [SerializeField] private TextMeshProUGUI bananaText;

    private void OnTriggerEnter2D(Collider2D collision){
        if (collision.gameObject.CompareTag("Banana")){
            Destroy(collision.gameObject);
            bananaCount++;
            Debug.Log("BANANAS: " + bananaCount );
            bananaText.text = "Bananas: " + bananaCount.ToString();
        }
    }
}
