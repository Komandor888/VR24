using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;
using UnityEngine.Networking;
using UnityEngine.EventSystems;

public class VRScript : MonoBehaviour
{
    public Text sur;
    public Text nm;
    public Text otch;
    public string jsonURL;
    public Jsonclass jsnData;
    void Start()
    {
        StartCoroutine(getData());
    }
    IEnumerator getData()
    {
        Debug.Log("Загрузка...");
        var uwr = new UnityWebRequest(jsonURL);
        uwr.method = UnityWebRequest.kHttpVerbGET;
        var resultFile = Path.Combine(Application.persistentDataPath, "result.json");
        var dh = new DownloadHandlerFile(resultFile);
        dh.removeFileOnAbort = true;
        uwr.downloadHandler = dh;
        yield return uwr.SendWebRequest();
        Debug.Log("Файл сохранён по пути:" + resultFile);
        jsnData = JsonUtility.FromJson<Jsonclass>(File.ReadAllText(Application.persistentDataPath + "/result.json"));
        sur.text = jsnData.Sur;
        nm.text = jsnData.Name;
        otch.text = jsnData.Otch;
        yield return StartCoroutine(getData());
    }
    [System.Serializable]
    public class Jsonclass
    {
        public string Sur;
        public string Name;
        public string Otch;
    }
}