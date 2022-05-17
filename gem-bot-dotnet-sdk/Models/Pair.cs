namespace GemBotSdk.Models;

public class Pair<T>
{
    public T Param1 { get; }
    public T Param2 { get; }

    public Pair(T p1, T p2)
    {
        Param1 = p1;
        Param2 = p2;
    }
}
