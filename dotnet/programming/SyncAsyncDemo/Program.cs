var time = DateTime.Now;
CPUBoundExample();
var endtime = DateTime.Now - time;
Console.WriteLine($"Time taken: {endtime.TotalMilliseconds} ms");
var ptime = DateTime.Now;
ParallelForEachExample();
var pendtime = DateTime.Now - ptime;
Console.WriteLine($"Parallel Time taken: {pendtime.TotalMilliseconds} ms");
static void CPUBoundExample()
{
    Console.WriteLine("Cpu bound Example");
    long sum = 0;
    for (int i = 0; i < 10000000; i++)
    {
        sum += i;
    }
    Console.WriteLine($"Sum: {sum}");
}

static void ParallelForEachExample()
{
    Console.WriteLine("Parallel Foreach Example");
    long sum = 0;
    Parallel.ForEach(Enumerable.Range(0, 10000000), i =>
    {
       Interlocked.Add(ref sum, i);
    });

    Console.WriteLine($"Sum: {sum}");
}