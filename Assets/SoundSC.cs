using System;
using System.Text;
using UnityEngine;
using UnityEngine.Windows.Speech;

public class SoundSC : MonoBehaviour
{
	private string[] ks;
	private KeywordRecognizer rec;
    private Rigidbody rd;
    public float speed;


    void Start()
	{
        rd = GetComponent<Rigidbody>();
        ks = new string[]{"l","right","up","back","stop","pe","jump","big","small"};
		rec = new KeywordRecognizer (ks);
		rec.OnPhraseRecognized += recd;
		rec.Start ();
	}
	private void recd(PhraseRecognizedEventArgs pre)
	{
		print (pre.text);
		processCommand (pre.text);
	}
	void processCommand(String s)
	{
        if (s.Equals("l")) {
            rd.AddForce(new Vector3(-1.0f, 0.0f, 0.0f) * speed);
        }
        else if (s.Equals("right")) {
            rd.AddForce(new Vector3(1.0f, 0.0f, 0.0f) * speed);
        }
        else if (s.Equals("up")) {
            rd.AddForce(new Vector3(0.0f, 0.0f, 1.0f) * speed);
        }
        else if (s.Equals("back")) {
            rd.AddForce(new Vector3(0.0f, 0.0f, -1.0f) * speed);
        }
        else if (s.Equals("stop") || s.Equals("ting")) {
            rd.velocity = Vector3.zero;
        }
        else if (s.Equals("jump")) {
            rd.AddForce(new Vector3(0, 300.0f, 0));
        }
        else if (s.Equals("pe") || s.Equals("big"))
        {
            rd.transform.localScale += Vector3.one;
        }
        else if (s.Equals("small"))
        {
            rd.transform.localScale = Vector3.one;
        }
	}
}