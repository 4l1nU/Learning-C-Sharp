using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Collections.Facts
{
    public class RadixTreeFacts
    {
        [Fact]
        public void CanInsertDifferentSequences()
        {
            var tree = new RadixTree<char>();
            tree.Insert("ab");
            tree.Insert("bc");
            Assert.True(tree.Contains("ab"));
            Assert.True(tree.Contains("bc"));
        }

        [Fact]
        public void CanInsertSequenceWitCommonPrefix()
        {
            var tree = new RadixTree<char>();
            tree.Insert("ab");
            tree.Insert("ac");
            Assert.True(tree.Contains("ab"));
            Assert.True(tree.Contains("ac"));
            Assert.False(tree.Contains("a"));
        }

        [Fact]
        public void CanInsertSequenceThatExistsAsAPrefixNode()
        {
            var tree = new RadixTree<char>();
            tree.Insert("ab");
            tree.Insert("ac");
            tree.Insert("a");
            Assert.True(tree.Contains("a"));
        }

        [Fact]
        public void CanInsertSequenceThatExistsAsAPartialPrefixNode()
        {
            var tree = new RadixTree<char>();
            tree.Insert("abc");
            tree.Insert("ab");
            Assert.True(tree.Contains("ab"));
        }

        [Fact]
        public void DoesNotInsertSequenceTwice()
        {
            var tree = new RadixTree<char>();
            tree.Insert("abc");
            tree.Insert("abc");
            Assert.True(tree.Contains("abc"));
        }

        [Fact]
        public void CanNotInsertEmptySequenceAndSearchReturnsFalse()
        {
            var tree = new RadixTree<char>();
            tree.Insert("");
            Assert.False(tree.Contains(""));
        }

        [Fact]
        public void ReturnsFalseWhenSearchingAPrefix()
        {
            var tree = new RadixTree<char>();
            tree.Insert("ab");
            Assert.False(tree.Contains("a"));
            tree.Insert("aa");
            Assert.False(tree.Contains("a"));
        }

        [Fact]
        public void ReturnsFalseWhenSearchingAnInexistentSequence()
        {
            var tree = new RadixTree<char>();
            tree.Insert("abc");
            Assert.False(tree.Contains("abb"));
        }

        [Fact]
        public void ReturnsTrueWhenSearchingInsertedSequences()
        {
            var tree = new RadixTree<char>();
            tree.Insert("abc");
            tree.Insert("abcd");
            tree.Insert("abce");
            tree.Insert("abaa");
            Assert.True(tree.Contains("abc"));
            Assert.True(tree.Contains("abcd"));
            Assert.True(tree.Contains("abce"));
            Assert.True(tree.Contains("abaa"));
        }

        [Fact]
        public void RemoveSingleSequenceInTree()
        {
            var tree = new RadixTree<char>();
            tree.Insert("abc");
            Assert.True(tree.Remove("abc"));
            Assert.False(tree.Contains("abc"));
        }

        [Fact]
        public void RemoveReturnsFalseWhenTreeIsEmpty()
        {
            var tree = new RadixTree<char>();
            Assert.False(tree.Remove("abc"));
        }

        [Fact]
        public void RemoveReturnsFalseWhenSequenceDoesNotExist()
        {
            var tree = new RadixTree<char>();
            tree.Insert("abc");
            Assert.False(tree.Remove("def"));
            Assert.True(tree.Contains("abc"));
        }

        [Fact]
        public void RemoveReturnsFalseWhenSequenceIsOnlyAPrefix()
        {
            var tree = new RadixTree<char>();
            tree.Insert("abc");
            Assert.False(tree.Remove("ab"));
            Assert.True(tree.Contains("abc"));
        }

        [Fact]
        public void RemoveInputWithSharedPrefixAndDifferentEndNode()
        {
            var tree = new RadixTree<char>();
            tree.Insert("abc");
            tree.Insert("abcd");
            Assert.True(tree.Remove("abcd"));
            Assert.True(tree.Contains("abc"));
            Assert.False(tree.Contains("abcd"));
        }

        [Fact]
        public void RemoveSharedPrefixMakesNodesMerge()
        {
            var tree = new RadixTree<char>();
            tree.Insert("abc");
            tree.Insert("abcd");
            Assert.True(tree.Remove("abc"));
            Assert.True(tree.Contains("abcd"));
            Assert.False(tree.Contains("abc"));
        }

        [Fact]
        public void RemoveCorrectlySequenceInAComplexTree()
        {
            var tree = new RadixTree<char>();
            tree.Insert("abcdefghh");
            tree.Insert("abcdefgah");
            tree.Insert("abcabcabc");
            tree.Insert("abcdeeeeh");
            tree.Insert("abcdddddh");
            tree.Insert("abcddddd");
            Assert.True(tree.Remove("abcdefgah"));
            Assert.False(tree.Contains("abcdefgah"));
            Assert.True(tree.Contains("abcdefghh"));
        }

        [Fact]
        public void FindAllWithPrefixReturnsSequenceWithValidPrefix()
        {
            var tree = new RadixTree<char>();
            tree.Insert("ab");
            var result = new System.Collections.Generic.List<System.Collections.Generic.List<char>>
            {
                new System.Collections.Generic.List<char>("ab")
            };
            Assert.Equal(result, tree.FindAllWithPrefix("a"));
        }

        [Fact]
        public void FindAllWithPrefixReturnsDefaultSequenceWithInvalidPrefix()
        {
            var tree = new RadixTree<char>();
            tree.Insert("ab");
            Assert.Equal(default, tree.FindAllWithPrefix("b"));
        }

        [Fact]
        public void FindAllWithPrefixReturnsBothSequencesWithValidPrefix()
        {
            var tree = new RadixTree<char>();
            tree.Insert("ab");
            tree.Insert("ac");
            var result = new System.Collections.Generic.List<System.Collections.Generic.List<char>>
            {
                new System.Collections.Generic.List<char>("ab"),
                new System.Collections.Generic.List<char>("ac")
            };
            Assert.Equal(result, tree.FindAllWithPrefix("a"));
        }

        [Fact]
        public void FindAllWithPrefixReturnsSequencesWhenPrefixIsMiddleOfNode()
        {
            var tree = new RadixTree<char>();
            tree.Insert("aba");
            tree.Insert("abb");
            var result = new System.Collections.Generic.List<System.Collections.Generic.List<char>>
            {
                new System.Collections.Generic.List<char>("aba"),
                new System.Collections.Generic.List<char>("abb")
            };
            Assert.Equal(result, tree.FindAllWithPrefix("a"));
        }

        [Fact]
        public void FindAllWithPrefixReturnsSequencesWhenTreeIsComplex()
        {
            var tree = new RadixTree<char>();
            tree.Insert("abcdefghh");
            tree.Insert("abcdefgah");
            tree.Insert("abcabcabc");
            tree.Insert("abcdeeeeh");
            tree.Insert("abcdddddh");
            tree.Insert("abcddddd");
            tree.Insert("abcdf");
            tree.Insert("abcd");
            tree.Insert("abcde");

            var result = new System.Collections.Generic.List<System.Collections.Generic.List<char>>
            {
                new System.Collections.Generic.List<char>("abcde"),
                new System.Collections.Generic.List<char>("abcdefghh"),
                new System.Collections.Generic.List<char>("abcdefgah"),
                new System.Collections.Generic.List<char>("abcdeeeeh")
            };
            Assert.Equal(result, tree.FindAllWithPrefix("abcde"));
        }

        [Fact]
        public void FindAllWithPrefixReturnsAllSequencesWhenTreeIsComplex()
        {
            var tree = new RadixTree<char>();
            tree.Insert("abcdefghh");
            tree.Insert("abcdefgah");
            tree.Insert("abcabcabc");
            tree.Insert("abcdeeeeh");
            tree.Insert("abcdddddh");
            tree.Insert("abcddddd");
            tree.Insert("abcdf");
            tree.Insert("abcd");
            tree.Insert("abcde");

            var result = new System.Collections.Generic.List<System.Collections.Generic.List<char>>
            {
                new System.Collections.Generic.List<char>("abcd"),
                new System.Collections.Generic.List<char>("abcde"),
                new System.Collections.Generic.List<char>("abcdefghh"),
                new System.Collections.Generic.List<char>("abcdefgah"),
                new System.Collections.Generic.List<char>("abcdeeeeh"),
                new System.Collections.Generic.List<char>("abcddddd"),
                new System.Collections.Generic.List<char>("abcdddddh"),
                new System.Collections.Generic.List<char>("abcdf"),
                new System.Collections.Generic.List<char>("abcabcabc")
            };
            Assert.Equal(result, tree.FindAllWithPrefix("abc"));
        }

        [Theory]

        [InlineData("")]
        [InlineData(default)]

        public void CanGiveNullOrEmptySequencesToMethodsWithoutErrors(string input)
        {
            var tree = new RadixTree<char>();
            tree.Insert(input);
            Assert.False(tree.Contains(input));
            Assert.False(tree.Remove(input));
            Assert.Null(tree.FindAllWithPrefix(input));
        }
    }
}
