using Domains.Bootstrap.Code.Logic.Base.Systems;
using Domains.Bootstrap.Code.Logic.Systems;

namespace Domains.Bootstrap.Code.Logic
{
    public class BootstrapFeature : BaseFeature
    {
        protected override void Init()
        {
            Add<TimerSystem>();
        }
    }
}