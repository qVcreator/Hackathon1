namespace UwULearn.Data.Interfaces;

public interface ICatsRepository
{
    public string Rename(int catId, string newName);
    public int HealthUpdate(int catId, int newHealth);

}