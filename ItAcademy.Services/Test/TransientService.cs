using ItAcademy.Services.Abstractions.Test;

namespace ItAcademy.Services.Test;

public class TransientService : ITransientService
{
    public int X;
    public Guid ServiceId = Guid.NewGuid();

    public int Do()
    {
        X++;
        return X;
    }
}