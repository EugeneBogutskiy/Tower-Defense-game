using UnityEngine;
using UnityEngine.UI;

public class BuyNewTurret : MonoBehaviour
{
    public GameObject newTorretPrefab;
    public GameObject buildTurretEffect;
    public int costNewTurret = 500;

    public GameObject costCanvas;
    public Text costText;

    void Start()
    {
        costText.text = costNewTurret.ToString();
    }

    void OnMouseEnter()
    {
        costCanvas.SetActive(true);
    }

    void OnMouseExit()
    {
        costCanvas.SetActive(false);
    }

    void OnMouseDown()
    {
        if (PlayerStats.gold < costNewTurret)
        {
            return;
        }

        PlayerStats.gold -= costNewTurret;
        Instantiate(newTorretPrefab, transform.position, transform.rotation);
        GameObject buildEffectGO = Instantiate(buildTurretEffect, transform.position, Quaternion.identity);
        Destroy(buildEffectGO, 5f);
        Destroy(gameObject);
    }
}
