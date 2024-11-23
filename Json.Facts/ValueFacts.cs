using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using static System.Net.Mime.MediaTypeNames;

namespace Json.Facts
{
    public class ValueFacts
    {
       [Fact]

        public void CanHaveObjectWithWS()
        {
            var value = new Value();
            IMatch match = value.Match(new StringView(0, @"{ }"));
            Assert.True(match.Success());
            Assert.True(match.RemainingText().StartsWith(""));

        }

        [Fact]

        public void CanHaveObjectWihStringAndValue()
        {
            var value = new Value();
            IMatch match = value.Match(new StringView(0, @"{ ""abc"" :""abc""}"));
            Assert.True(match.Success());
            Assert.True(match.RemainingText().StartsWith(""));

        }

        [Fact]

        public void CanHaveMultipleElements()
        {
            var value = new Value();
            IMatch match = value.Match(new StringView(0, @"{
    ""glossary"": {
        ""title"": ""example glossary"",
		""GlossDiv"": {
            ""title"": ""S"",
			""GlossList"": {
                ""GlossEntry"": {
                    ""ID"": ""SGML"",
					""SortAs"": ""SGML"",
					""GlossTerm"": ""Standard Generalized Markup Language"",
					""Acronym"": ""SGML"",
					""Abbrev"": ""ISO 8879:1986"",
					""GlossDef"": {
                        ""para"": ""A meta-markup language, used to create markup languages such as DocBook."",
						""GlossSeeAlso"": [""GML"", ""XML""]
                    },
					""GlossSee"": ""markup""
                }
            }
        }
    }
}"));
            Assert.True(match.Success());
            Assert.True(match.RemainingText().StartsWith(""));

        }
    }
}

