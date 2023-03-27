using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    public abstract class DocumentState
    {
        public virtual DocumentState Draft()
        {
            throw new NotSupportedException();
        }
        public virtual DocumentState Moderate()
        {
            throw new NotSupportedException();
        }
        public virtual DocumentState Publish()
        {
            throw new NotSupportedException();
        }
        public virtual DocumentState Archive()
        {
            throw new NotSupportedException();
        }
    }
    public class DraftState : DocumentState
    {
        public override DocumentState Moderate()
        {
            return new ModerationState();
        }

        public override DocumentState Archive()
        {
            return new ArchivedState();
        }
    }
    public class ModerationState : DocumentState
    {
        public override DocumentState Draft()
        {
            return new DraftState();
        }
        public override DocumentState Publish()
        {
            return new PublishedState();
        }
    }
    public class PublishedState : DocumentState
    {
        public override DocumentState Archive()
        {
            return new ArchivedState();
        }
    }
    public class ArchivedState : DocumentState
    {
    }
}
