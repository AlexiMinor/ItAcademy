using ItAcademy.Services.Abstractions;
using ItAcademy.Services.Abstractions.Test;

namespace ItAcademy.Services;

public class TestService : ITestService
{
    public readonly ITransientService _transientService1;
    public readonly ITransientService _transientService2;

    public readonly IScopedService _scopedService1;
    public readonly IScopedService _scopedService2;

    public readonly ISingletonService _singletonService;

    public TestService(ITransientService transientService1,
        ITransientService transientService2,
        IScopedService scopedService1,
        IScopedService scopedService2,
        ISingletonService singletonService)
    {
        _transientService1 = transientService1;
        _transientService2 = transientService2;
        _singletonService = singletonService;
        _scopedService1 = scopedService1;
        _scopedService2 = scopedService2;
    }

    public int[] Do()
    {
        var arr = new int[5];

        arr[0] = _transientService1.Do();
        arr[1] = _transientService2.Do();
        arr[2] = _scopedService1.Do();
        arr[3] = _scopedService2.Do();
        arr[4] = _singletonService.Do();

        return arr;
    }
}