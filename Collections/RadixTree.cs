namespace Collections
{
    using System;
    using System.Collections.Generic;
    using System.Reflection.Metadata.Ecma335;
    using Generic = System.Collections.Generic;

    public class RadixTree<T>
        where T : IEquatable<T>
    {
        private readonly Node root;

        public RadixTree()
        {
            this.root = new Node([]);
        }

        public void Insert(IEnumerable<T> input)
        {
            var sequence = SequenceInitialization(input);
            if (sequence.Count == 0)
            {
                return;
            }

            (Node lastNode, int lastnodeIndex, int sequenceIndex) = this.TreeTraversal(sequence);
            lastNode.InsertSuffix(lastnodeIndex, sequence, sequenceIndex);
        }

        public bool Contains(IEnumerable<T> input)
        {
            var sequence = SequenceInitialization(input);
            if (sequence.Count == 0)
            {
                return false;
            }

            (Node lastNode, int lastNodeIndex, int sequenceIndex) = this.TreeTraversal(sequence);
            return sequenceIndex == sequence.Count && lastNode.End &&
                            lastNodeIndex == lastNode.Label.Count;
        }

        public bool Remove(IEnumerable<T> input)
        {
            var sequence = SequenceInitialization(input);
            if (this.root.SubNodes.Count == 0 || sequence.Count == 0)
            {
                return false;
            }

            return this.root.RemoveSuffix(sequence, 0, out _);
        }

        public IEnumerable<Generic.List<T>>? FindAllWithPrefix(IEnumerable<T> input)
        {
            var sequence = SequenceInitialization(input);
            if (sequence.Count == 0)
            {
                return default;
            }

            var result = new Generic.List<Generic.List<T>>();
            (Node lastNode, int lastNodeIndex, int sequenceIndex) = this.TreeTraversal(sequence);
            if (sequenceIndex < sequence.Count)
            {
                return default;
            }

            sequence.AddRange(lastNode.Label[lastNodeIndex..]);
            if (lastNode.End)
            {
                result.Add(sequence);
            }

            lastNode.GetNodeSuffixes(sequence, result, []);
            return result;
        }

        private static Generic.List<T> SequenceInitialization(IEnumerable<T> input) =>
            input == null ? [] : new Generic.List<T>(input);

        private (Node node, int nodeIndex, int sequenceIndex) TreeTraversal(Generic.List<T> sequence)
        {
            int sequenceIndex;
            var node = this.root;
            int nodeIndex = 0;
            for (sequenceIndex = 0; nodeIndex == node.Label.Count && sequenceIndex < sequence.Count;
                sequenceIndex += nodeIndex)
            {
                node = node.NextNode(sequence[sequenceIndex], out bool nodeFound);
                if (!nodeFound)
                {
                    return (node, 0, sequenceIndex);
                }

                nodeIndex = node.EqualConsecutiveElements(sequence, sequenceIndex);
            }

            return (node, nodeIndex, sequenceIndex);
        }

        private sealed class Node
        {
            internal Node(Generic.List<T> label, bool end = false)
            {
                this.SubNodes = [];
                this.Label = label;
                this.End = end;
            }

            internal Generic.List<Node> SubNodes { get; set; }

            internal bool End { get; set; }

            internal Generic.List<T> Label { get; set; }

            internal void InsertSuffix(int nodeIndex, Generic.List<T> sequence, int sequenceIndex)
            {
                if (sequenceIndex == sequence.Count && nodeIndex == this.Label.Count)
                {
                    this.End = true;
                }
                else if (nodeIndex == 0)
                {
                    this.SubNodes.Add(new Node(sequence[sequenceIndex..], true));
                }
                else
                {
                    this.SplitNode(sequence, sequenceIndex, nodeIndex);
                    if (sequenceIndex < sequence.Count)
                    {
                        var newSuffixNode = new Node(
                            sequence.GetRange(sequenceIndex, sequence.Count - sequenceIndex), true);
                        this.SubNodes.Add(newSuffixNode);
                    }
                }
            }

            internal Node NextNode(T element, out bool nodeFound)
            {
                foreach (var node in this.SubNodes)
                {
                    if (node.Label[0].Equals(element))
                    {
                        nodeFound = true;
                        return node;
                    }
                }

                nodeFound = false;
                return this;
            }

            internal int EqualConsecutiveElements(Generic.List<T> sequence, int index)
            {
                int minCount = Math.Min(this.Label.Count, sequence.Count - index);
                for (int i = 0; i < minCount; i++)
                {
                    if (!sequence[i + index].Equals(this.Label[i]))
                    {
                        return i;
                    }
                }

                return minCount;
            }

            internal bool RemoveSuffix(Generic.List<T> sequence, int index, out Node nextNode)
            {
                nextNode = this;
                if (index == sequence.Count && this.End)
                {
                    this.End = false;
                    return true;
                }

                bool matchFound = false;
                foreach (var node in this.SubNodes)
                {
                    if (node.EqualConsecutiveElements(sequence, index) == node.Label.Count)
                    {
                        matchFound =
                            node.RemoveSuffix(sequence, index + node.Label.Count, out nextNode);
                        break;
                    }
                }

                if (!matchFound)
                {
                    return false;
                }

                this.DeleteNode(nextNode);
                nextNode = this;
                return true;
            }

            internal void GetNodeSuffixes(
                        Generic.List<T> sequence,
                        Generic.List<Generic.List<T>> result,
                        Generic.List<T> carry)
            {
                foreach (var node in this.SubNodes)
                {
                    carry.AddRange(node.Label);
                    if (node.End)
                    {
                        var temp = new Generic.List<T>(sequence);
                        temp.AddRange(carry);
                        result.Add(temp);
                    }

                    node.GetNodeSuffixes(sequence, result, carry);
                    carry.RemoveRange(carry.Count - node.Label.Count, node.Label.Count);
                }
            }

            internal void SmallestSuffix(
                Generic.List<T> carry,
                Generic.List<T> result,
                ref int minLength)
            {
                foreach (var node in this.SubNodes)
                {
                    if (carry.Count + node.Label.Count >= minLength)
                    {
                        continue;
                    }
                    else if (node.End)
                    {
                        minLength = carry.Count + node.Label.Count;
                        result.Clear();
                        result.AddRange(carry);
                        result.AddRange(node.Label);
                        continue;
                    }

                    carry.AddRange(node.Label);
                    node.SmallestSuffix(carry, result, ref minLength);
                    carry.RemoveRange(carry.Count - node.Label.Count, node.Label.Count);
                }
            }

            internal void SplitNode(Generic.List<T> sequence, int sequenceIndex, int matches)
            {
                var previousSuffixNode = new Node(this.Label[matches..], this.End);
                previousSuffixNode.SubNodes.AddRange(this.SubNodes);
                this.End = sequenceIndex == sequence.Count;
                this.Label = sequence[(sequenceIndex - matches)..sequenceIndex];
                this.SubNodes.Clear();
                this.SubNodes.Add(previousSuffixNode);
            }

            private void DeleteNode(Node nextNode)
            {
                if (!nextNode.End && nextNode.SubNodes.Count == 0)
                {
                    this.SubNodes.Remove(nextNode);
                }
                else if (!nextNode.End && nextNode.SubNodes.Count == 1)
                {
                    nextNode.Label.AddRange(nextNode.SubNodes[0].Label);
                    nextNode.End = nextNode.SubNodes[0].End;
                    nextNode.SubNodes.Clear();
                }
            }
        }
    }
}
