using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerHealth : HealthSystem
{
    [SerializeField] private GameObject textObject;
    private Text _text;

    public void Start()
    {
        _text = textObject.GetComponent<Text>();
        _text.text = "Health: " + health;
    }

    public override void OnDeath()
    {
        SceneManager.LoadScene("GameOverScene");
    }
    public override void OnDamaged()
    {
        _text.text = "Health: " + health;
    }
}
