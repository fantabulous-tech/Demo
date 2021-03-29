using System.Text;
using Ink.Runtime;
using Naninovel;
using UnityEngine;

public class NaninovelInkAdapter : MonoBehaviour {
    private static NaninovelInkAdapter s_Instance;

    /// <summary>
    /// Use @startInk in Naninovel to start the ink story.
    /// </summary>
    public static void StartStory() {
        s_Instance.StartStoryInternal();
    }

    public static void Choose(int index) {
        s_Instance.ChooseInternal(index);
    }

    [SerializeField] private TextAsset inkJSONAsset;

    public Story Story;
    private IScriptPlayer m_ScriptPlayer;
    private Script m_CurrentScript;
    private int m_ScriptIndex;

    private void Start() {
        if (s_Instance) {
            Debug.LogError("Duplicate InkPlayerAdapter found! (original)", s_Instance);
            Debug.LogError("Duplicate InkPlayerAdapter found! (duplicate)", this);
            return;
        }

        s_Instance = this;
    }

    private void StartStoryInternal() {
        Story = new Story(inkJSONAsset.text);
        m_ScriptPlayer = Engine.GetService<IScriptPlayer>();
        Continue();
    }

    private void Continue() {
        StringBuilder sb = new StringBuilder(Story.ContinueMaximally());

        AddChoices(sb);

        string storyName = $"{inkJSONAsset.name}{m_ScriptIndex++}";
        string naniStoryText = sb.ToString();
        Debug.Log($"Creating story '{storyName}':\n{naniStoryText}");

        m_CurrentScript = Script.FromScriptText(storyName, naniStoryText);
        m_ScriptPlayer.Stop();
        m_ScriptPlayer.Play(m_CurrentScript);
    }

    private void AddChoices(StringBuilder sb) {
        // Add @choice commands to end of script.
        foreach (Choice choice in Story.currentChoices) {
            sb.AppendLine($"@choice \"{choice.text}\" goto:.Choice{choice.index}");
        }

        // Add # Choice goto labels
        foreach (Choice choice in Story.currentChoices) {
            sb.AppendLine();
            sb.AppendLine($"# Choice{choice.index}");
            sb.AppendLine($"@inkChoice {choice.index}");
            sb.AppendLine($"@stop");
        }
    }

    private void ChooseInternal(int choiceIndex) {
        Story.ChooseChoiceIndex(choiceIndex);
        Continue();
    }
}