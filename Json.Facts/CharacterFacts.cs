using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Json.Facts
{
    public class CharacterFacts
    {
        [Fact]
        public void FirstCharacterMatches()
        {
            Char caracter = new Char('a');
            IMatch match = caracter.Match(new StringView(0, "abc"));
            Assert.True(match.Success());
        }

        [Fact]
        public void FirstCharacterDoesntMatch()
        {
            Char caracter = new Char('a');
            IMatch match = caracter.Match(new StringView(0, "bac"));
            Assert.False(match.Success());
        }
    }
}
