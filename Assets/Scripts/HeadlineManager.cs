using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class HeadlineManager : MonoBehaviour
{
    public List<Headline> headlines;
    public List<Headline> currentHeadlines;
    public Text headlineList;
    public UnityEvent Show { get { if (show == null) show = new UnityEvent(); return show; } }
    [SerializeField] private UnityEvent show;

    public Text text;

    void Start()
    {
        
    }

    public void AddHeadline(Headline headline)
    {
        headlines.Add(headline);
    }

    public void ShowHeadline()
    {
        
      //  for (int i = 0; i < 3; i++)
      //  {
            int random = Random.Range(0, headlines.Count - 1);
            Headline headline;
            headline = headlines[random] ;
            headlines.RemoveAt(random);
            text.text = headline.title;
            PropertyManager.tags.Find(x => x.tagName == headline.tag).InfluenceFactor *= headline.factor;
            currentHeadlines.Add(headline);
            Show.Invoke();
        headlineList.text = headlineList.text + "\""+ headline.title + "\" \n";
        //  }

    }
}
