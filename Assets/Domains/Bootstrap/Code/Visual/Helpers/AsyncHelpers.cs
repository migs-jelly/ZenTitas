using System.Threading.Tasks;
using UnityEngine;

namespace Domains.Bootstrap.Code.Visual.Helpers
{
    public static class AsyncHelpers
    {
        public static async Task<AsyncOperation> ConfigureAwait(this AsyncOperation operation)
        {
            while (!operation.isDone)
            {
                await Task.Yield();
            }

            return operation;
        }
    }
}