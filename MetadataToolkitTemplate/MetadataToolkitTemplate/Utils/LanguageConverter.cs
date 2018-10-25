/*
COPYRIGHT 1995-2009 ESRI
TRADE SECRETS: ESRI PROPRIETARY AND CONFIDENTIAL
Unpublished material - all rights reserved under the 
Copyright Laws of the United States.
For additional information, contact:
Environmental Systems Research Institute, Inc.
Attn: Contracts Dept
380 New York Street
Redlands, California, USA 92373
email: contracts@esri.com
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace $safeprojectname$
{
  internal class LanguageConverter
  {
    private static Dictionary<string, string> langDict = new Dictionary<string, string>();

    public static string GetThreeLetterCode(string twoLetterCode)
    {
      if (0 == langDict.Count)
        AddData();

      if (langDict.ContainsKey(twoLetterCode))
        return langDict[twoLetterCode];
      else
        return null;
    }

    private static void AddData()
    {
      langDict.Add("aa", "aar");
      langDict.Add("ab", "abk");
      langDict.Add("af", "afr");
      langDict.Add("ak", "aka");
      langDict.Add("sq", "alb");
      langDict.Add("am", "amh");
      langDict.Add("ar", "ara");
      langDict.Add("an", "arg");
      langDict.Add("hy", "arm");
      langDict.Add("as", "asm");
      langDict.Add("av", "ava");
      langDict.Add("ae", "ave");
      langDict.Add("ay", "aym");
      langDict.Add("az", "aze");
      langDict.Add("ba", "bak");
      langDict.Add("bm", "bam");
      langDict.Add("eu", "baq");
      langDict.Add("be", "bel");
      langDict.Add("bn", "ben");
      langDict.Add("bh", "bih");
      langDict.Add("bi", "bis");
      langDict.Add("bs", "bos");
      langDict.Add("br", "bre");
      langDict.Add("bg", "bul");
      langDict.Add("my", "bur");
      langDict.Add("ca", "cat");
      langDict.Add("ch", "cha");
      langDict.Add("ce", "che");
      langDict.Add("zh", "chi");
      langDict.Add("cu", "chu");
      langDict.Add("cv", "chv");
      langDict.Add("kw", "cor");
      langDict.Add("co", "cos");
      langDict.Add("cr", "cre");
      langDict.Add("cs", "cze");
      langDict.Add("da", "dan");
      langDict.Add("dv", "div");
      langDict.Add("nl", "dut");
      langDict.Add("dz", "dzo");
      langDict.Add("en", "eng");
      langDict.Add("eo", "epo");
      langDict.Add("et", "est");
      langDict.Add("ee", "ewe");
      langDict.Add("fo", "fao");
      langDict.Add("fj", "fij");
      langDict.Add("fi", "fin");
      langDict.Add("fr", "fre");
      langDict.Add("fy", "fry");
      langDict.Add("ff", "ful");
      langDict.Add("ka", "geo");
      langDict.Add("de", "ger");
      langDict.Add("gd", "gla");
      langDict.Add("ga", "gle");
      langDict.Add("gl", "glg");
      langDict.Add("gv", "glv");
      langDict.Add("el", "gre");
      langDict.Add("gn", "grn");
      langDict.Add("gu", "guj");
      langDict.Add("ht", "hat");
      langDict.Add("ha", "hau");
      langDict.Add("he", "heb");
      langDict.Add("hz", "her");
      langDict.Add("hi", "hin");
      langDict.Add("ho", "hmo");
      langDict.Add("hr", "hrv");
      langDict.Add("hu", "hun");
      langDict.Add("ig", "ibo");
      langDict.Add("is", "ice");
      langDict.Add("io", "ido");
      langDict.Add("ii", "iii");
      langDict.Add("iu", "iku");
      langDict.Add("ie", "ile");
      langDict.Add("ia", "ina");
      langDict.Add("id", "ind");
      langDict.Add("ik", "ipk");
      langDict.Add("it", "ita");
      langDict.Add("jv", "jav");
      langDict.Add("ja", "jpn");
      langDict.Add("kl", "kal");
      langDict.Add("kn", "kan");
      langDict.Add("ks", "kas");
      langDict.Add("kr", "kau");
      langDict.Add("kk", "kaz");
      langDict.Add("km", "khm");
      langDict.Add("ki", "kik");
      langDict.Add("rw", "kin");
      langDict.Add("ky", "kir");
      langDict.Add("kv", "kom");
      langDict.Add("kg", "kon");
      langDict.Add("ko", "kor");
      langDict.Add("kj", "kua");
      langDict.Add("ku", "kur");
      langDict.Add("lo", "lao");
      langDict.Add("la", "lat");
      langDict.Add("lv", "lav");
      langDict.Add("li", "lim");
      langDict.Add("ln", "lin");
      langDict.Add("lt", "lit");
      langDict.Add("lb", "ltz");
      langDict.Add("lu", "lub");
      langDict.Add("lg", "lug");
      langDict.Add("mk", "mac");
      langDict.Add("mh", "mah");
      langDict.Add("ml", "mal");
      langDict.Add("mi", "mao");
      langDict.Add("mr", "mar");
      langDict.Add("ms", "may");
      langDict.Add("mg", "mlg");
      langDict.Add("mt", "mlt");
      langDict.Add("mn", "mon");
      langDict.Add("na", "nau");
      langDict.Add("nv", "nav");
      langDict.Add("nr", "nbl");
      langDict.Add("nd", "nde");
      langDict.Add("ng", "ndo");
      langDict.Add("ne", "nep");
      langDict.Add("nn", "nno");
      langDict.Add("nb", "nob");
      langDict.Add("no", "nor");
      langDict.Add("ny", "nya");
      langDict.Add("oc", "oci");
      langDict.Add("oj", "oji");
      langDict.Add("or", "ori");
      langDict.Add("om", "orm");
      langDict.Add("os", "oss");
      langDict.Add("pa", "pan");
      langDict.Add("fa", "per");
      langDict.Add("pi", "pli");
      langDict.Add("pl", "pol");
      langDict.Add("pt", "por");
      langDict.Add("ps", "pus");
      langDict.Add("qu", "que");
      langDict.Add("rm", "roh");
      langDict.Add("ro", "rum");
      langDict.Add("rn", "run");
      langDict.Add("ru", "rus");
      langDict.Add("sg", "sag");
      langDict.Add("sa", "san");
      langDict.Add("si", "sin");
      langDict.Add("sk", "slo");
      langDict.Add("sl", "slv");
      langDict.Add("se", "sme");
      langDict.Add("sm", "smo");
      langDict.Add("sn", "sna");
      langDict.Add("sd", "snd");
      langDict.Add("so", "som");
      langDict.Add("st", "sot");
      langDict.Add("es", "spa");
      langDict.Add("sc", "srd");
      langDict.Add("sr", "srp");
      langDict.Add("ss", "ssw");
      langDict.Add("su", "sun");
      langDict.Add("sw", "swa");
      langDict.Add("sv", "swe");
      langDict.Add("ty", "tah");
      langDict.Add("ta", "tam");
      langDict.Add("tt", "tat");
      langDict.Add("te", "tel");
      langDict.Add("tg", "tgk");
      langDict.Add("tl", "tgl");
      langDict.Add("th", "tha");
      langDict.Add("bo", "tib");
      langDict.Add("ti", "tir");
      langDict.Add("to", "ton");
      langDict.Add("tn", "tsn");
      langDict.Add("ts", "tso");
      langDict.Add("tk", "tuk");
      langDict.Add("tr", "tur");
      langDict.Add("tw", "twi");
      langDict.Add("ug", "uig");
      langDict.Add("uk", "ukr");
      langDict.Add("ur", "urd");
      langDict.Add("uz", "uzb");
      langDict.Add("ve", "ven");
      langDict.Add("vi", "vie");
      langDict.Add("vo", "vol");
      langDict.Add("cy", "wel");
      langDict.Add("wa", "wln");
      langDict.Add("wo", "wol");
      langDict.Add("xh", "xho");
      langDict.Add("yi", "yid");
      langDict.Add("yo", "yor");
      langDict.Add("za", "zha");
      langDict.Add("zu", "zul");
    }
  }
}
