using System;

namespace FubuMVC.Core.Registration.Nodes
{
    public interface IMayHaveInputType
    {
        Type InputType();
    }

    public interface IMayHaveResourceType
    {
        Type ResourceType();
    }
}