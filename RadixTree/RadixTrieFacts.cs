using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Collections.RadixTrie;

namespace Collections.Facts
{
    public class RadixTrieFacts
    {
        [Fact]
        public void main()
        {
            var tree = new RadixTrie();
            tree.Insert("romane");
            Assert.True(tree.Lookup("romane"));
            tree.Insert("romanus");
            Assert.True(tree.Lookup("romanus"));
            tree.Insert("romulus");
            Assert.True(tree.Lookup("romulus"));
           /* tree.Insert("romulu");
            Assert.True(tree.Lookup("romulu"));*/
            tree.Insert("rubens");
            Assert.True(tree.Lookup("rubens"));
            tree.Insert("ruber");
            Assert.True(tree.Lookup("ruber"));
            tree.Insert("rubicon");
            Assert.True(tree.Lookup("rubicon"));
            tree.Insert("rubicundus");


            Assert.Equal("romane", tree.FindPredecessor("romanes"));
             tree.Insert("rubi");
            Assert.True(tree.Lookup("rubi"));
            Assert.True(tree.Lookup("rubicon"));
            //Assert.Equal("rubi", tree.FindPredecessor("rubic"));
            Assert.Equal("roman", tree.FindSuccessor("rom"));

            tree.Delete("romanus");
            Assert.False(tree.Lookup("romanus"));
             
        }
    }
}