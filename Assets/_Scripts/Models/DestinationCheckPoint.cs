using System;

[Serializable]
public class DestinationCheckPoint
{
    public enum State
    {
        Uncompleted,
        Completed
    }

    public State state;
}