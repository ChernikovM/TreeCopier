namespace TreeCopier
{
    public class BinaryTree
    {
        public int? Payload { get; set; }

        public BinaryTree Parrent { get; set; }

        public BinaryTree LeftChild { get; set; }

        public BinaryTree RightChild { get; set; }

        public void Add(int payload)
        {
            if(Payload is null)
            {
                Payload = payload;
                return;
            }

            if(payload >= Payload)
            {
                if(RightChild is not null)
                {
                    RightChild.Add(payload);
                    return;
                }
                RightChild = new BinaryTree() { Payload = payload, Parrent = this };
                return;
            }

            if(payload < Payload)
            {
                if(LeftChild is not null)
                {
                    LeftChild.Add(payload);
                    return;
                }
                LeftChild = new BinaryTree() { Payload = payload, Parrent = this };
                return;
            }
        }
 
    }
}
