using indice.Edi.Serialization;

namespace indice.Edi.Tests.Models
{

    [EdiMessage]
    public class Issue5Message
    {
        public SegmentA SegmentA { get;set; }
        public SegmentB SegmentB { get;set; }
    }

    [EdiElement]
    public class CompositeDataElement
    {
        [EdiValue("X(18)", Path="?/?/0")]
        public string A{ get; set; }    

        [EdiValue("X(3)", Path="?/?/1")]
        public string B { get; set; }    

        [EdiValue("X(70)", Path="?/?/2")]
        public string C { get; set; }
    }

    [EdiSegment, EdiPath("AAA")]
    public class SegmentA
    { 
        [EdiPath("AAA/1")]
        public CompositeDataElement Element1 { get; set;}
    }

    [EdiSegment, EdiPath("BBB")]
    public class SegmentB
    { 
        [EdiPath("BBB/1")]
        public CompositeDataElement Element1 { get; set;}
    }
}