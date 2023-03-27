namespace Library
{
    public class Document
    {
        public DocumentState State { get; private set; }
        public Document()
        {
            this.State = new DraftState();
        }

        public void Draft()
        {
            this.State = State.Draft();
        }
        public void Moderate()
        {
            this.State = State.Moderate();
        }
        public void Publish()
        {
            this.State = State.Publish();
        }
        public void Archive()
        {
            this.State = State.Archive();
        }
    }
}