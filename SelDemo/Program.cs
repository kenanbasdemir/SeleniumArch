using SelDemo.Abstract;
using SelDemo.Models;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace SelDemo
{
    class Program
    {
        static async System.Threading.Tasks.Task Main(string[] args)
        {
            //var c = new CancellationTokenSource();
            using (var browserService = new ChromeBrowserManager())
            {
                IBrowserBatch<VisitResult> visitBrowserBatch = new VisitBrowserBatch("username", "password");

                await browserService.ExecuteAsync(visitBrowserBatch, (cb, wd) =>
                {
                    VisitResult result = cb.Data;
                    Console.WriteLine($"Result: {result.SomeData}");
                }, new CancellationToken());

                await Task.Delay(-1);

                //await browserService.ExecuteAsync(visitBrowserBatch, (cb, wd) =>
                //{
                //    VisitResult result = cb.Data;
                //    Console.WriteLine($"Result: {result.SomeData}");
                //}, c.Token);
                //c.Cancel();
            }
        }
    }
}
