using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class GameController : MonoBehaviour
{

    public Text CrystalCounterText;
    public Text CountdownText;
    public Text EndOfGameText;


    public AudioClip GameWinSound;
    public AudioClip GameLooseSound;

	// Use this for initialization
	void Start ()
	{
	    UpdateCrystalCounterText();

        EndOfGameText.enabled = false;

        StartCoroutine(CountdownCorutine());
    }

    // countdown at game start
    IEnumerator CountdownCorutine()
    {
        SetIfSphereCanMove(false);
        
        CountdownText.enabled = true;
        for(int i=5; i>0; i--)
        {
            CountdownText.text = i.ToString();
            yield return new WaitForSeconds(1f);
        }

        CountdownText.text = "START!";
        // the sphere can move now
        SetIfSphereCanMove(true);
        yield return new WaitForSeconds(1f);

        CountdownText.enabled = false;
    }

    private void SetIfSphereCanMove(bool canMove)
    {
        var sphere = FindObjectOfType<Sphere>();
        sphere.CanMove = canMove;

        sphere.GetComponent<Rigidbody>().velocity = Vector3.zero;

    }

    public void UpdateCrystalCounterText()
    {
        // array of crystals on whole level
        var crystals = FindObjectsOfType<Crystal>();

        // number of all crystals
        var crystalCount = crystals.Length;

        // obtained crystals
        var crystalInactive = crystals.Count(crystal => !crystal.Active);

        // displayed text
        var text = crystalInactive + " / " + crystalCount;
        CrystalCounterText.text = text;
    }

    public void CheckIfEndOfGame()
    {
        // check all inactive crystals
        var endOfGame = FindObjectsOfType<Crystal>().All(crystal => !crystal.Active);

        if (!endOfGame) return;
        Debug.Log("Sphere has crossed the line");

        EndOfGame(true);
    }

    public void EndOfGame(bool win)
    {
        StartCoroutine(EndOfGameCorutine(win));
    }

    IEnumerator EndOfGameCorutine(bool win)
    {
        SetIfSphereCanMove(false);

        EndOfGameText.enabled = true;
        EndOfGameText.text = win ? "WIN" : "LOOSE";

        var audioSource = GetComponent<AudioSource>();
        audioSource.clip = win ? GameWinSound : GameLooseSound;
        audioSource.Play();



        yield return new WaitForSeconds(3f);
        Debug.Log("You lost. End of the game!");
        Application.Quit();
    }
}
