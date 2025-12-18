public class CooldownTimer
{
    private float remainingTime;
    private readonly float duration;
    private bool isRunning;
    public bool IsReady => !this.isRunning;

    public CooldownTimer(float duration)
    {
        this.duration = duration;
        this.isRunning = false;
    }

    public void Tick(float deltaTime)
    {
        if (!this.isRunning) 
            return;
        this.remainingTime -= deltaTime;
        if (this.remainingTime <= 0f)
        {
            this.remainingTime = 0f;
            this.isRunning = false;
        }
    }

    public void Reset()
    {
        this.remainingTime = this.duration;
        this.isRunning = true;
    }

    public void ForceReady()
    {
        this.remainingTime = 0f;
        this.isRunning = false;
    }
}