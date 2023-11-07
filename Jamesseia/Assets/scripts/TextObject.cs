public class TextObject
{
    public string text = "";
    public float x = 0;
    public float y = 0;
    public bool isFinal = true;
    public bool isDequeued = false;

    public TextObject(float x, float y, string text, bool isFinal){
        this.x = x;
        this.y = y;
        this.text = text;
        this.isFinal = isFinal;
        this.isDequeued = false;
    }   
}