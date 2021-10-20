using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SystemGlobalServicesTestTask.Input.Entities
{
    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse); 
    
    public abstract class ValuteBase
    {
        public string ID { get; init; }
        public string NumCode { get; init; }
        public string CharCode { get; init; }
        public int Nominal { get; init; }
        public string Name { get; init; }
        public double Value { get; init; }
        public double Previous { get; init; }
    }

    public class AUD : ValuteBase { }

    public class AZN : ValuteBase { }

    public class GBP : ValuteBase { }

    public class AMD : ValuteBase { }

    public class BYN : ValuteBase { }

    public class BGN : ValuteBase { }

    public class BRL : ValuteBase { }

    public class HUF : ValuteBase { }

    public class HKD : ValuteBase { }

    public class DKK : ValuteBase { }

    public class USD : ValuteBase { }

    public class EUR : ValuteBase { }

    public class INR : ValuteBase { }

    public class KZT : ValuteBase { }

    public class CAD : ValuteBase { }

    public class KGS : ValuteBase { }

    public class CNY : ValuteBase { }

    public class MDL : ValuteBase { }

    public class NOK : ValuteBase { }

    public class PLN : ValuteBase { }

    public class RON : ValuteBase { }

    public class XDR : ValuteBase { }

    public class SGD : ValuteBase { }

    public class TJS : ValuteBase { }

    public class TRY : ValuteBase { }

    public class TMT : ValuteBase { }

    public class UZS : ValuteBase { }

    public class UAH : ValuteBase { }

    public class CZK : ValuteBase { }

    public class SEK : ValuteBase { }

    public class CHF : ValuteBase { }

    public class ZAR : ValuteBase { }

    public class KRW : ValuteBase { }

    public class JPY : ValuteBase { }

    public class Valute
    {
        public AUD AUD { get; set; }
        public AZN AZN { get; set; }
        public GBP GBP { get; set; }
        public AMD AMD { get; set; }
        public BYN BYN { get; set; }
        public BGN BGN { get; set; }
        public BRL BRL { get; set; }
        public HUF HUF { get; set; }
        public HKD HKD { get; set; }
        public DKK DKK { get; set; }
        public USD USD { get; set; }
        public EUR EUR { get; set; }
        public INR INR { get; set; }
        public KZT KZT { get; set; }
        public CAD CAD { get; set; }
        public KGS KGS { get; set; }
        public CNY CNY { get; set; }
        public MDL MDL { get; set; }
        public NOK NOK { get; set; }
        public PLN PLN { get; set; }
        public RON RON { get; set; }
        public XDR XDR { get; set; }
        public SGD SGD { get; set; }
        public TJS TJS { get; set; }
        public TRY TRY { get; set; }
        public TMT TMT { get; set; }
        public UZS UZS { get; set; }
        public UAH UAH { get; set; }
        public CZK CZK { get; set; }
        public SEK SEK { get; set; }
        public CHF CHF { get; set; }
        public ZAR ZAR { get; set; }
        public KRW KRW { get; set; }
        public JPY JPY { get; set; }
    }

}
