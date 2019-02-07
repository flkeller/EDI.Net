using System.IO;
using System.Text;
using indice.Edi.Tests.Models;
using Xunit;

namespace indice.Edi.Tests
{
    public class ReusableDataElementTest
    {
        [Fact, Trait(Traits.Tag, "Writer"), Trait(Traits.Bug, "#5")]
        public void WriteReusableElement() {
            var instance = new Issue5Message() {
                SegmentA = new SegmentA() {Element1 = new CompositeDataElement() {A = "SAEA", B = "SAEB", C = "SAEC"}},
                SegmentB = new SegmentB() {Element1 = new CompositeDataElement() {A = "SBEA", B = "SBEB", C = "SBEC"}}
            };
            var grammar = EdiGrammar.NewEdiFact();
            var expected = "UNA:+.? '\r\nAAA++SAEA:SAEB:SAEC\r\nBBB++SBEA:SBEB:SBEC";


            var sb = new StringBuilder();
            new EdiSerializer().Serialize(new EdiTextWriter(new StringWriter(sb), grammar), instance);
            var msg = sb.ToString();
            Assert.Equal(expected, msg);
        }
    }
}