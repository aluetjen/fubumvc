using System;
using System.Collections.Generic;
using FubuMVC.Core.Registration.Nodes;
using FubuMVC.Core.Registration.ObjectGraph;

namespace FubuMVC.Core.Resources.Conneg
{
    public abstract class ReaderNode : Node<ReaderNode, ReaderChain>, IContainerModel
    {
        public abstract Type InputType { get; }
        public abstract IEnumerable<string> Mimetypes { get; }

        ObjectDef IContainerModel.ToObjectDef()
        {
            var objectDef = toReaderDef();

            // TODO -- validate that it's a Reader
            return objectDef;
        }

        protected abstract ObjectDef toReaderDef();
    }
}